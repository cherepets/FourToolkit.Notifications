using FourToolkit.Notifications.InteractiveToast.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;

namespace FourToolkit.Notifications.InteractiveToast
{
    public class Action : ActionBase, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "action";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "content", Content },
                { "arguments", Arguments },
                { "activationType", ActivationType },
                { "imageUri", ImageUri },
                { "hint-inputId", InputId }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren => null;

        string IXmlDescriptor.XmlCustomContent => null;
        
        public string Content { get; set; }
        public string Arguments { get; set; }
        public string ImageUri { get; set; }
        public ActivationType ActivationType { get; set; }
        public string InputId { get; set; }

        protected override void OnDataContextChanged(object value) { }
    }
}