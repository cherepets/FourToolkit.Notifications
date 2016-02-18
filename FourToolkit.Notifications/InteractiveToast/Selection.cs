using FourToolkit.Notifications.Xml;
using System.Collections.Generic;

namespace FourToolkit.Notifications.InteractiveToast
{
    public sealed class Selection : ActionBase, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "selection";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "id ", Id },
                { "content", Content }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren => null;

        string IXmlDescriptor.XmlCustomContent => null;
        
        public string Id { get; set; }
        public string Content { get; set; }

        protected override void OnDataContextChanged(object value) { }
    }
}