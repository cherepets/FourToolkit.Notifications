using FourToolkit.Notifications.AdaptiveTile.Enum;
using FourToolkit.Notifications.Extensions;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace FourToolkit.Notifications.AdaptiveTile
{
    public class Tile : Bindable, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "tile";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes => null;

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren
            => new IXmlDescriptor[]
            {
                new XmlDescriptor
                {
                    XmlTagName = "visual",
                    XmlAttributes = new Dictionary<string, object>
                    {
                        { "version", Version },
                        { "lang", Language },
                        { "baseUri", BaseUri },
                        { "branding", Branding },
                        { "addImageQuery", AddImageQuery },
                        { "contentId", ContentId },
                        { "displayName", DisplayName }
                    },
                    XmlChildren = Visual?.Select(t => (IXmlDescriptor)t)
                }
            };

        string IXmlDescriptor.XmlCustomContent => null;

        public int Version { get; set; }
        public string Language { get; set; }
        public string BaseUri { get; set; }
        public Branding Branding { get; set; }
        public bool AddImageQuery { get; set; }
        public string ContentId { get; set; }
        public string DisplayName { get; set; }

        public IList<Visual> Visual { get; set; }

        public Tile()
        {
            Visual = new List<Visual>();
        }            

        public TileNotification CreateNotification()
        {
            var xml = XmlBuilder.Build(this).ToString();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            var notification = new TileNotification(xmlDocument);
            return notification;
        }

        protected override void OnDataContextChanged(object value)
            => Visual.ForEach(b => b.DataContext = value);
    }
}
