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

using System.Windows;
using ModularApp.Infrastructure.Constants;
using ModularApp.PassengerModule.Views;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

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
        private readonly IDialogService _dialogService;
        private IRegion _passengerListRegion;
        private IRegion _flightListRegion;
        private PassengerListView _passengerListView;
        //private FlightContentView _flightContentView;

        #endregion

        #region Properties

        public IRegionManager RegionManager { get; }

        private bool _isCanExcute = false;
        public bool IsCanExcute
        {
            get { return _isCanExcute; }
            set { SetProperty(ref _isCanExcute, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand _loadedCmd;
        public DelegateCommand LoadedCmd =>
            _loadedCmd ?? (_loadedCmd = new DelegateCommand(ExecuteLoadedCommand));

        //private DelegateCommand _activePassengerListCmd;
        //public DelegateCommand ActivePassengerListCmd =>
        //    _activePassengerListCmd ?? (_activePassengerListCmd = new DelegateCommand(ExecuteActivePassengerListCommand));

        //private DelegateCommand _deactivePassengerListCmd;
        //public DelegateCommand DeactivePassengerListCmd =>
        //    _deactivePassengerListCmd ?? (_deactivePassengerListCmd = new DelegateCommand(ExecuteDeactivePassengerListCommand));

        //private DelegateCommand _activeFlightListCmd;
        //public DelegateCommand ActiveFlightListCommand =>
        //    _activeFlightListCmd ?? (_activeFlightListCmd = new DelegateCommand(ExecuteActiveFlightListCommand).ObservesCanExecute(() => IsCanExcute));

        //private DelegateCommand _deactiveFlightListCmd;
        //public DelegateCommand DeactiveMedicineListCommand =>
        //    _deactiveFlightListCmd ?? (_deactiveFlightListCmd = new DelegateCommand(ExecuteDeactiveFlightListCommand).ObservesCanExecute(() => IsCanExcute));


        //加载机场的命令
        private DelegateCommand _loadFlightModuleCmd;
        public DelegateCommand LoadFlightModuleCmd =>
            _loadFlightModuleCmd ??= new DelegateCommand(ExecuteLoadFlightModuleCmd);

        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="moduleManager"></param>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IDialogService dialogService)
        {
            _moduleManager = moduleManager;
            RegionManager = regionManager;
            _dialogService = dialogService;
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
        }
        

        /// <summary>
        /// 航班模块加载方法实现
        /// </summary>
        private void ExecuteLoadFlightModuleCmd()
        {
            _moduleManager.LoadModule("FlightModule");
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

        #region  Excutes

        void ExecuteLoadedCommand()
        {

            _passengerListRegion = RegionManager.Regions[RegionNames.PassengerListRegion];
            _passengerListView = CommonServiceLocator.ServiceLocator.Current.GetInstance<PassengerListView>();
            _passengerListRegion.Add(_passengerListView);

            //var uniformContentRegion = RegionMannager.Regions["UniformContentRegion"];
            //var regionAdapterView1 = CommonServiceLocator.ServiceLocator.Current.GetInstance<RegionAdapterView1>();
            //uniformContentRegion.Add(regionAdapterView1);
            //var regionAdapterView2 = CommonServiceLocator.ServiceLocator.Current.GetInstance<RegionAdapterView2>();
            //uniformContentRegion.Add(regionAdapterView2);

            _flightListRegion = RegionManager.Regions[RegionNames.FlightMainContentRegion];
        }


        //void ExecuteDeactiveMedicineListCommand()
        //{
        //    _medicineListRegion.Deactivate(_medicineMainContentView);
        //}

        //void ExecuteActiveMedicineListCommand()
        //{
        //    _medicineListRegion.Activate(_medicineMainContentView);
        //}

        //void ExecuteLoadMedicineModuleCommand()
        //{
        //    _moduleManager.LoadModule("MedicineModule");
        //    _medicineMainContentView = (MedicineMainContent)_medicineListRegion.Views.Where(t => t.GetType() == typeof(MedicineMainContent)).FirstOrDefault();
        //    this.IsCanExcute = true;
        //}

        //void ExecuteDeactivePaientListCommand()
        //{
        //    _paientListRegion.Deactivate(_patientListView);
        //}

        //void ExecuteActivePaientListCommand()
        //{
        //    _paientListRegion.Activate(_patientListView);
        //}

        #endregion
    }
}
