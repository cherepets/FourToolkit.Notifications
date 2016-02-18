using FourToolkit.Notifications.Xml;

namespace FourToolkit.Notifications.InteractiveToast
{
    public sealed class Audio : Bindable
    {
        public string Source { get; set; }
        public bool Loop { get; set; }
        public bool Silent { get; set; }

        protected override void OnDataContextChanged(object value) { }
    }
}