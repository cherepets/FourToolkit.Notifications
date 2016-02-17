using FourToolkit.Notifications.Xml;
using System.Collections.Generic;

namespace FourToolkit.Notifications.InteractiveToast
{
    public class Text : ToastUiElement, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "text";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "lang", Language }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren => null;

        string IXmlDescriptor.XmlCustomContent => Content;
        
        public string Language { get; set; }
        public string Content { get; set; }

        protected override void OnDataContextChanged(object value) { }
    }
}
