using FourToolkit.Notifications.InteractiveToast.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;

namespace FourToolkit.Notifications.InteractiveToast
{
    public class Image : ToastUiElement, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "image";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "src", Source },
                { "placement", Placement },
                { "alt", Alt },
                { "addImageQuery", AddImageQuery },
                { "hint-crop", Crop }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren => null;

        string IXmlDescriptor.XmlCustomContent => null;

        public Placement Placement { get; set; }
        public string Alt { get; set; }
        public bool AddImageQuery { get; set; }
        public Crop Crop { get; set; }        
        public string Source { get; set; }

        protected override void OnDataContextChanged(object value) { }
    }
}
