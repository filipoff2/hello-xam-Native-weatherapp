using GalaSoft.MvvmLight;

namespace WeatherApp.Services
{
    /// <summary>
    /// POCO describing navigation request sent by some view model.
    /// </summary>
    public class NavigationRequest
    {
        public string Key { get; set; }
        public ViewModelBase Sender { get; set; }
        public object Parameter { get; set; }
    }
}
