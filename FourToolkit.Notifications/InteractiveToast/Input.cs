using FourToolkit.Notifications.InteractiveToast.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FourToolkit.Notifications.InteractiveToast
{
    public class Input : ActionBase, IXmlDescriptor, IList<Selection>
    {
        string IXmlDescriptor.XmlTagName => "input";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "id ", Id },
                { "type", Type },
                { "title", Title },
                { "placeHolderContent", Placeholder },
                { "defaultInput", DefaultInput }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren
            => Items?.Select(t => (IXmlDescriptor)t);

        string IXmlDescriptor.XmlCustomContent => null;
        
        public string Id { get; set; }
        public InputType Type { get; set; }        
        public string Title { get; set; }
        public string Placeholder { get; set; }
        public string DefaultInput { get; set; }

        public List<Selection> Items { get; set; }

        public Input()
        {
            Items = new List<Selection>();
        }

        protected override void OnDataContextChanged(object value)
            => Items.ForEach(i => i.DataContext = value);

        #region IList
        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public Selection this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }

        public void Add(Selection item) => Items.Add(item);

        public void Clear() => Items.Clear();

        public bool Contains(Selection item) => Items.Contains(item);

        public void CopyTo(Selection[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

        public bool Remove(Selection item) => Items.Remove(item);

        public IEnumerator<Selection> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public int IndexOf(Selection item) => Items.IndexOf(item);

        public void Insert(int index, Selection item) => Items.Insert(index, item);

        public void RemoveAt(int index) => Items.RemoveAt(index);
        #endregion
    }
}