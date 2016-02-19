using FourToolkit.Notifications.AdaptiveTile.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using FourToolkit.Notifications.Extensions;

namespace FourToolkit.Notifications.AdaptiveTile
{
    public sealed class Visual : Bindable, IXmlDescriptor, IList<TileUiElement>
    {
        string IXmlDescriptor.XmlTagName => "binding";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "template", Template },
                { "lang", Language },
                { "baseUri", BaseUri },
                { "branding", Branding },
                { "addImageQuery", AddImageQuery },
                { "contentId", ContentId },
                { "displayName", DisplayName },
                { "hint-textStacking", TextStacking },
                { "hint-overlay", Overlay },
                { "hint-presentation", Presentation },
                { "hint-lockDetailedStatus1", LockDetailedStatus1 },
                { "hint-lockDetailedStatus2", LockDetailedStatus2 },
                { "hint-lockDetailedStatus3", LockDetailedStatus3 }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren 
            => Items?.Select(t => (IXmlDescriptor)t);

        string IXmlDescriptor.XmlCustomContent => null;

        public Template Template { get; set; }
        public string Language { get; set; }
        public string BaseUri { get; set; }
        public Branding Branding { get; set; }
        public bool AddImageQuery { get; set; }
        public string ContentId { get; set; }
        public string DisplayName { get; set; }
        public TextStacking TextStacking { get; set; }
        public int? Overlay { get; set; }
        public Presentation Presentation { get; set; }
        public string LockDetailedStatus1 { get; set; }
        public string LockDetailedStatus2 { get; set; }
        public string LockDetailedStatus3 { get; set; }

        public IList<TileUiElement> Items { get; set; }

        public Visual()
        {
            Items = new List<TileUiElement>();
        }

        protected override void OnDataContextChanged(object value)
            => Items.ForEach(i => i.DataContext = value);

        #region IList
        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public TileUiElement this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }

        public void Add(TileUiElement item) => Items.Add(item);

        public void Clear() => Items.Clear();

        public bool Contains(TileUiElement item) => Items.Contains(item);

        public void CopyTo(TileUiElement[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

        public bool Remove(TileUiElement item) => Items.Remove(item);

        public IEnumerator<TileUiElement> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public int IndexOf(TileUiElement item) => Items.IndexOf(item);

        public void Insert(int index, TileUiElement item) => Items.Insert(index, item);

        public void RemoveAt(int index) => Items.RemoveAt(index);
        #endregion
    }
}
