using System.Windows;
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
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            if (regionManager != null)
            {
                SetRegionManager(regionManager, FlyoutsControlRegion, RegionNames.FlyoutRegion);
                //SetRegionManager(regionManager, RightWindowCommandsRegion, RegionNames.ShowSearchPatientRegion);
            }
        }

        void SetRegionManager(IRegionManager regionManager, DependencyObject regionTarget, string regionName)
        {
            RegionManager.SetRegionName(regionTarget, regionName);
            RegionManager.SetRegionManager(regionTarget, regionManager);
        }
    }
}
