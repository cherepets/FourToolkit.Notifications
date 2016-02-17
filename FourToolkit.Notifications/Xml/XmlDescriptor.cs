using System.Collections.Generic;

namespace FourToolkit.Notifications.Xml
{
    internal class XmlDescriptor : IXmlDescriptor
    {
        public string XmlTagName { get; set; }

        public IDictionary<string, object> XmlAttributes { get; set; }

        public IEnumerable<IXmlDescriptor> XmlChildren { get; set; }

        public string XmlCustomContent { get; set; }
    }
}
