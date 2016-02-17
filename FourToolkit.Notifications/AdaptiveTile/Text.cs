using FourToolkit.Notifications.AdaptiveTile.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;

namespace FourToolkit.Notifications.AdaptiveTile
{
    public class Text : TileUiElement, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "text";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "lang", Language },
                { "hint-style", TextStyle },
                { "hint-wrap", Wrap },
                { "hint-maxLines", MaxLines },
                { "hint-minLines", MinLines },
                { "hint-align", Alignment },
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren => null;

        string IXmlDescriptor.XmlCustomContent => Content;
        
        public string Language { get; set; }
        public TextStyle TextStyle { get; set; }
        public bool Wrap { get; set; }
        public int MaxLines { get; set; }
        public int MinLines { get; set; }
        public Enum.TextAlignment Alignment { get; set; }
        public string Content { get; set; }

        protected override void OnDataContextChanged(object value) { }
    }
}
