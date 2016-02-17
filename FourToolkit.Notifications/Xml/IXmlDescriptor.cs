using System.Collections.Generic;

namespace FourToolkit.Notifications.Xml
{
    internal interface IXmlDescriptor
    {
        string XmlTagName { get; }
        IDictionary<string, object> XmlAttributes { get; }
        IEnumerable<IXmlDescriptor> XmlChildren { get; }
        string XmlCustomContent { get; }
    }
}
