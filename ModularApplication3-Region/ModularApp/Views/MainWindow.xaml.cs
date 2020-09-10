using CommonServiceLocator;
using MahApps.Metro.Controls;
using ModularApp.Infrastructure.Constants;
using Prism.Regions;

namespace ModularApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            //if (regionManager != null)
            //{
            //    RegionManager.SetRegionName(PassengerContent, "PassengerListRegion");
            //    RegionManager.SetRegionManager(PassengerContent, regionManager);
            //}

            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            if (regionManager != null)
            {
                RegionManager.SetRegionName(FlyoutsControlRegion, RegionNames.FlyoutRegion);
                RegionManager.SetRegionManager(FlyoutsControlRegion,regionManager);

                //RegionManager.SetRegionName(RightWindowCommandsRegion,RegionNames.ShowSearchPassengerRegion);
                //RegionManager.SetRegionManager(RightWindowCommandsRegion,regionManager);
                RegionManager.SetRegionName(Control, RegionNames.ShowSearchPassengerRegion);
                RegionManager.SetRegionManager(Control, regionManager);
            }
        }
    }
}
