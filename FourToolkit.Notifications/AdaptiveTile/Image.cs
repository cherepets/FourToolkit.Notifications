using FourToolkit.Notifications.AdaptiveTile.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;

namespace FourToolkit.Notifications.AdaptiveTile
{
    public sealed class Image : TileUiElement, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "image";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "src", Source },
                { "placement", Placement },
                { "alt", Alt },
                { "addImageQuery", AddImageQuery },
                { "hint-crop", Crop },
                { "hint-removeMargin", RemoveMargin },
                { "hint-align", Alignment },
                { "hint-overlay", Overlay }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren => null;

        string IXmlDescriptor.XmlCustomContent => null;

        public Placement Placement { get; set; }
        public string Alt { get; set; }
        public bool AddImageQuery { get; set; }
        public Crop Crop { get; set; }
        public bool RemoveMargin { get; set; }
        public ImageAlignment Alignment { get; set; }
        public int Overlay { get; set; }        
        public string Source { get; set; }
        
        protected override void OnDataContextChanged(object value) { }
    }
}
