using MahApps.Metro.Controls;
using ModularApp.Infrastructure.Constants;
using ModularApp.Infrastructure.IServices;

namespace ModularApp.FlightModule.Views
{
    /// <summary>
    /// SearchFlightView.xaml 的交互逻辑
    /// </summary>
    public partial class SearchFlightView : Flyout,IFlyoutView
    {
        public SearchFlightView()
        {
            InitializeComponent();
        }
        public string FlyoutName { get { return FlyoutNames.SearchFlightFlyout; } }
    }
}
