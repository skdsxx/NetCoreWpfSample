using MahApps.Metro.Controls;
using ModularApp.Infrastructure.Constants;
using ModularApp.Infrastructure.IServices;

namespace ModularApp.PassengerModule.Views
{
    /// <summary>
    /// PassengerDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class PassengerDetailView : Flyout,IFlyoutView
    {
        public PassengerDetailView()
        {
            InitializeComponent();
        }
        //实现窗体命名
        public string FlyoutName { get { return FlyoutNames.PassengerDetailFlyout; } }
    }
}
