using FourToolkit.Notifications.Extensions;
using FourToolkit.Notifications.InteractiveToast.Enum;
using FourToolkit.Notifications.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace FourToolkit.Notifications.InteractiveToast
{
    public class Toast : Bindable, IXmlDescriptor
    {
        string IXmlDescriptor.XmlTagName => "toast";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes 
            => new Dictionary<string, object>
            {
                { "launch", Launch },
                { "duration", Duration },
                { "activationType", ActivationType },
                { "scenario", Scenario }
            };

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
                        { "addImageQuery", AddImageQuery }
                    },
                    XmlChildren = Visual?.Select(t => (IXmlDescriptor)t)
                },
                new XmlDescriptor
                {
                    XmlTagName = "actions",
                    XmlChildren = Actions?.Select(t => (IXmlDescriptor)t)
                },
                new XmlDescriptor
                {
                    XmlTagName = "audio",
                    XmlAttributes = new Dictionary<string, object>
                    {
                        { "src", Audio?.Source },
                        { "loop", Audio?.Loop },
                        { "silent", Audio?.Silent }
                    }
                }
            };

        string IXmlDescriptor.XmlCustomContent => null;
        
        public string Launch { get; set; }
        public DateTime Duration { get; set; }
        public ActivationType ActivationType { get; set; }
        public Scenario Scenario { get; set; }

        public int Version { get; set; }
        public string Language { get; set; }
        public string BaseUri { get; set; }
        public bool AddImageQuery { get; set; }

        public Audio Audio { get; set; }

        public IList<Visual> Visual { get; set; }

        public IList<ActionBase> Actions { get; set; }
        
        public Toast()
        {
            Visual = new List<Visual>();
            Actions = new List<ActionBase>();
        }

        public ToastNotification CreateNotification()
        {
            var xml = XmlBuilder.Build(this).ToString();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            var notification = new ToastNotification(xmlDocument);
            return notification;
        }

        protected override void OnDataContextChanged(object value)
        {
            Visual.ForEach(b => b.DataContext = value);
            Actions.ForEach(b => b.DataContext = value);
        }
    }
}
