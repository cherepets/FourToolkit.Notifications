using System.Xml.Linq;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;
using FourToolkit.Notifications.Extensions;

namespace FourToolkit.Notifications.Xml
{
    internal static class XmlBuilder
    {
        public static XElement Build(IXmlDescriptor descriptor, BuilderState state = null)
        {
            if (state == null) state = new BuilderState();
            descriptor = ProcessBindings(descriptor, state);
            var xelement = new XElement(descriptor.XmlTagName);
            if (descriptor.XmlAttributes != null)
                foreach (var attribute in descriptor.XmlAttributes)
                {
                    if (attribute.Key != null && !attribute.Value.IsDefault())
                    {
                        var xattribute = new XAttribute(attribute.Key, attribute.Value);
                        xelement.Add(xattribute);
                    }
                }
            if (descriptor.XmlChildren != null)
                foreach (var child in descriptor.XmlChildren)
                    if (child != null)
                    {
                        var xchild = Build(child, state);
                        xelement.Add(xchild);
                    }
            if (descriptor.XmlCustomContent != null)
                xelement.Add(descriptor.XmlCustomContent);
            return xelement;
        }

        private static IXmlDescriptor ProcessBindings(IXmlDescriptor descriptor, BuilderState state)
        {
            var bindable = descriptor as IBindable;
            if (bindable != null && bindable.DataContext != null)
            {
                var data = bindable.DataContext;
                var bindableType = bindable.GetType();
                var bindableProps = state.GetTypeProps(bindableType);
                var bindablePropValues = bindableProps
                    .Select(b => new { Property = b, Value = b.IsIndexed() ? null : b.GetValue(bindable)?.ToString() })
                    .Where(b => b.Value.IsBindingDefenition());
                if (bindablePropValues.Any())
                {
                    var dataType = data.GetType();
                    var dataProps = state.GetTypeProps(dataType);
                    var correspondingProperties = bindablePropValues
                        .Select(b => new { BindablePropery = b.Property, DataProperty = dataProps.FirstOrDefault(d => d.Name.ToBindingDefenition() == b.Value && d.PropertyType == b.Property.PropertyType) })
                        .Where(p => p.DataProperty != null).ToList();
                    foreach (var pair in correspondingProperties)
                    {
                        var value = pair.DataProperty.GetValue(data);
                        pair.BindablePropery.SetValue(bindable, value);
                    }
                }
            }            
            return descriptor;
        }

        internal class BuilderState
        {
            private Dictionary<Type, PropertyInfo[]> _cache = new Dictionary<Type, PropertyInfo[]>();

            public PropertyInfo[] GetTypeProps(Type type)
            {
                if (!_cache.ContainsKey(type))
                    _cache.Add(type, type.GetProperties());
                return _cache[type];
            }
        }
    }
}
