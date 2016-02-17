namespace FourToolkit.Notifications.Xml
{
    public abstract class Bindable : IBindable
    {
        public object DataContext
        {
            get
            {
                return _dataContext;
            }
            set
            {
                _dataContext = value;
                OnDataContextChanged(value);
            }
        }

        private object _dataContext;

        protected abstract void OnDataContextChanged(object value);
    }
}
