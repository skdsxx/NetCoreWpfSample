//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: ShowSearchPassengerViewModel
//命名空间名称: ModularApp.FlightModule.ViewModels
//文件名: ShowSearchPassengerViewModel
//当前系统时间: 2020/9/10 15:40:35
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Linq;
using System.Threading.Tasks;
using ModularApp.FlightModule.Views;
using ModularApp.Infrastructure;
using ModularApp.Infrastructure.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ModularApp.FlightModule.ViewModels
{
    public class ShowSearchPassengerViewModel:BindableBase
    {
        #region Fields

        private readonly IRegionManager _regionManager;
        private ShowSearchPassengerView _showSearchPassengerView;
        private IRegion _region;

        #endregion

        #region Properties

        private bool _isShow = true;
        public bool IsShow
        {
            get { return _isShow = true; }
            set
            {
                SetProperty(ref _isShow, value);
                if (_isShow)
                {
                    ActiveShowSearchPatient();
                }
                else
                {
                    DeactiveShowSearchPaitent();
                }
            }
        }

        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand _showSearchLoadingCommand;
        public DelegateCommand ShowSearchLoadingCommand =>
            _showSearchLoadingCommand ?? (_showSearchLoadingCommand = new DelegateCommand(ExecuteShowSearchLoadingCommand));

        #endregion

        public ShowSearchPassengerViewModel(IRegionManager regionManager, IApplicationCommands appCmd)
        {
            _regionManager = regionManager;
            ApplicationCommands = appCmd;
        }

        void ExecuteShowSearchLoadingCommand()
        {
            _region = _regionManager.Regions[RegionNames.ShowSearchPassengerRegion];
            _showSearchPassengerView = (ShowSearchPassengerView)_region.Views.Where(t => t.GetType() == typeof(ShowSearchPassengerView)).FirstOrDefault();
        }

        //视图激活
        private void ActiveShowSearchPatient()
        {
            if (!_region.ActiveViews.Contains(_showSearchPassengerView))
            {
                _region.Add(_showSearchPassengerView);
            }
        }

        //视图失效
        private async void DeactiveShowSearchPaitent()
        {
            _region.Remove(_showSearchPassengerView);
            await Task.Delay(2000);
            IsShow = true;
        }
    }
}
