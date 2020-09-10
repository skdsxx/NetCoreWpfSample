//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: MainWindowViewModel
//命名空间名称: ModularApp.ViewModels
//文件名: MainWindowViewModel
//当前系统时间: 2020/8/25 10:34:32
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Linq;
using System.Windows;
using ModularApp.FlightModule.Views;
using ModularApp.PassengerModule.Views;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ModularApp.ViewModels
{
    /// <summary>
    /// 主窗体View Model
    /// </summary>
    public class MainWindowViewModel:BindableBase
    {
        #region Fields

        //模块管理器
        IModuleManager _moduleManager;
        private IRegionManager _regionManager;
        private IRegion _passengerRegion;
        private PassengerListView _passengerListView;

        private IRegion _flightRegion;

        private FlightContentView _flightListView;

        #endregion

        #region Commands
        //页面加载命令
        private DelegateCommand _loadCmd;
        public DelegateCommand LoadCmd =>
            _loadCmd ?? (_loadCmd = new DelegateCommand(OnLoad));

        //加载机场的命令
        private DelegateCommand _loadFlightModuleCmd;
        public DelegateCommand LoadFlightModuleCmd =>
            _loadFlightModuleCmd ??= new DelegateCommand(ExecuteLoadFlightModuleCmd);

        //激活旅客列表命令
        private DelegateCommand _activePassengerListCmd;
        /// <summary>
        /// 激活旅客列表命令
        /// </summary>
        public DelegateCommand ActivePassengerListCmd=>_activePassengerListCmd??=new DelegateCommand(OnActivePassengerList);


        //卸载旅客列表命令
        private DelegateCommand _deactivePassengerListCmd;
        /// <summary>
        /// 卸载旅客列表命令
        /// </summary>
        public DelegateCommand DeactivePassengerListCmd => _deactivePassengerListCmd ??= new DelegateCommand(OnDeactivePassengerList);

        private DelegateCommand _activeFlightListCmd;
        public DelegateCommand ActiveFlightListCmd => _activeFlightListCmd ??= new DelegateCommand(OnActiveFlightList);

        private DelegateCommand _deactiveFlightListCmd;
        public DelegateCommand DeactiveFlightListCmd => _deactiveFlightListCmd ??= new DelegateCommand(OnDeactiveFlightList);

        #endregion

        /// <summary>
        /// 激活旅客列表方法
        /// </summary>
        private void OnActivePassengerList()
        {
            _passengerRegion.Activate(_passengerListView);
        }

        /// <summary>
        /// 卸载旅客列表方法
        /// </summary>
        private void OnDeactivePassengerList()
        {
            _passengerRegion.Deactivate(_passengerListView);
        }

        /// <summary>
        /// 激活航班列表方法
        /// </summary>
        private void OnActiveFlightList()
        {
            _flightRegion.Activate(_flightListView);
        }

        /// <summary>
        /// 卸载航班列表方法
        /// </summary>
        private void OnDeactiveFlightList()
        {
            _flightRegion.Deactivate(_flightListView);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="moduleManager"></param>
        /// <param name="regionManager"></param>
        public MainWindowViewModel(IModuleManager moduleManager,IRegionManager regionManager)
        {
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
        }
        

        /// <summary>
        /// 航班模块加载方法实现
        /// </summary>
        private void ExecuteLoadFlightModuleCmd()
        {
            _moduleManager.LoadModule("FlightModule");

            _flightListView =  (FlightContentView) _flightRegion.Views.FirstOrDefault(p =>
            p.GetType() == typeof(FlightContentView));
        }

        //页面加载方法
        private void OnLoad()
        {
            _passengerRegion = _regionManager.Regions["PassengerListRegion"];
            _passengerListView =
                (PassengerListView) _passengerRegion.Views.FirstOrDefault(p =>
                    p.GetType() == typeof(PassengerListView));

            _flightRegion = _regionManager.Regions["FlightMainContentRegion"];
            //_flightListView = CommonServiceLocator.ServiceLocator.Current.GetInstance<FlightContentView>();
            //_flightRegion.Add(_flightListView);
        }

        /// <summary>
        /// 模块加载完成事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            MessageBox.Show($"{e.ModuleInfo.ModuleName}模块被加载了");
        }

    }
}
