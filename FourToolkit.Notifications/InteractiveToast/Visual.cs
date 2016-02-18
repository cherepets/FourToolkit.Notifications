using FourToolkit.Notifications.InteractiveToast.Enum;
using FourToolkit.Notifications.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace FourToolkit.Notifications.InteractiveToast
{
    public sealed class Visual : Bindable, IXmlDescriptor, IList<ToastUiElement>
    {
        string IXmlDescriptor.XmlTagName => "binding";

        IDictionary<string, object> IXmlDescriptor.XmlAttributes
            => new Dictionary<string, object>
            {
                { "template", Template },
                { "lang", Language },
                { "baseUri", BaseUri },
                { "addImageQuery", AddImageQuery }
            };

        IEnumerable<IXmlDescriptor> IXmlDescriptor.XmlChildren 
            => Items?.Select(t => (IXmlDescriptor)t);

        string IXmlDescriptor.XmlCustomContent => null;

        public Template Template { get; set; }
        public string Language { get; set; }
        public string BaseUri { get; set; }
        public bool AddImageQuery { get; set; }

        public List<ToastUiElement> Items { get; set; }

        public Visual()
        {
            Items = new List<ToastUiElement>();
        }

        protected override void OnDataContextChanged(object value)
            => Items.ForEach(i => i.DataContext = value);

        #region IList
        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public ToastUiElement this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }

        public void Add(ToastUiElement item) => Items.Add(item);

        public void Clear() => Items.Clear();

        public bool Contains(ToastUiElement item) => Items.Contains(item);

        public void CopyTo(ToastUiElement[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

        public bool Remove(ToastUiElement item) => Items.Remove(item);

        public IEnumerator<ToastUiElement> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public int IndexOf(ToastUiElement item) => Items.IndexOf(item);

        public void Insert(int index, ToastUiElement item) => Items.Insert(index, item);

        public void RemoveAt(int index) => Items.RemoveAt(index);
        #endregion
    }
}
