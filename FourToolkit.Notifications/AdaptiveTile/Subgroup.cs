using FourToolkit.Notifications.AdaptiveTile.Enum;
using FourToolkit.Notifications.Extensions;
using FourToolkit.Notifications.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FourToolkit.Notifications.AdaptiveTile
{
    public sealed class Subgroup : TileUiElement, IXmlDescriptor, IList<TileUiElement>
    {
        string IXmlDescriptor.XmlTagName => "subgroup";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "hint-weight", Weight },
                { "hint-textStacking", TextStacking }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren 
            => Items?.Select(t => (IXmlDescriptor)t);

        string IXmlDescriptor.XmlCustomContent => null;

        public double Weight { get; set; }
        public TextStacking TextStacking { get; set; }

        public IList<TileUiElement> Items { get; set; }

        protected override void OnDataContextChanged(object value)
            => Items.ForEach(i => i.DataContext = value);

        public Subgroup()
        {
            Items = new List<TileUiElement>();
        }

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
