using FourToolkit.Notifications.Extensions;
using FourToolkit.Notifications.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FourToolkit.Notifications.AdaptiveTile
{
    public sealed class Group : TileUiElement, IXmlDescriptor, IList<Subgroup>
    {
        string IXmlDescriptor.XmlTagName => "group";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes => null;

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren 
            => Items?.Select(t => (IXmlDescriptor)t);

        string IXmlDescriptor.XmlCustomContent => null;
        
        public IList<Subgroup> Items { get; set; }
        
        protected override void OnDataContextChanged(object value)
            => Items.ForEach(i => i.DataContext = value);

        public Group()
        {
            Items = new List<Subgroup>();
        }

        #region IList
        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public Subgroup this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }

        public void Add(Subgroup item) => Items.Add(item);

        public void Clear() => Items.Clear();

        public bool Contains(Subgroup item) => Items.Contains(item);

        public void CopyTo(Subgroup[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

        public bool Remove(Subgroup item) => Items.Remove(item);

        public IEnumerator<Subgroup> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public int IndexOf(Subgroup item) => Items.IndexOf(item);

        public void Insert(int index, Subgroup item) => Items.Insert(index, item);

        public void RemoveAt(int index) => Items.RemoveAt(index);
        #endregion
    }
}
