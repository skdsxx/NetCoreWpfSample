//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: PassengerListViewModel
//命名空间名称: ModularApp.PassengerModule.ViewModels
//文件名: PassengerListViewModel
//当前系统时间: 2020/8/25 16:13:43
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Collections.ObjectModel;
using System.Windows.Input;
using ModularApp.Infrastructure;
using ModularApp.Infrastructure.Constants;
using ModularApp.Infrastructure.Events;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace ModularApp.PassengerModule.ViewModels
{
    public class PassengerListViewModel:BindableBase
    {
        #region Fields

        private readonly IPassengerService _passengerService;
        private readonly IEventAggregator _msgEvent;
        //private readonly IRegionManager _regionManager;
        //private IRegion _region;
        //private PatientList _patientListView;

        #endregion

        #region Properties
        private ObservableCollection<Passenger> _allPassengers;
        //所有旅客信息集合
        public ObservableCollection<Passenger> AllPassengers
        {
            get { return _allPassengers; }
            set { SetProperty(ref _allPassengers, value); }
        }

        private IApplicationCommands _applicationCommands;
        //全局复合命令
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
        #endregion
        /// <summary>
        /// 列表双击命令
        /// </summary>
        public ICommand MouseDoubleClickCmd { get; set; }
        public PassengerListViewModel(IPassengerService passengerService,IEventAggregator msgEvent,IApplicationCommands appCmd)
        {
            _passengerService = passengerService;
            _msgEvent = msgEvent;
            ApplicationCommands = appCmd;
            AllPassengers = new ObservableCollection<Passenger>(_passengerService.GetAllPassengers());

            MouseDoubleClickCmd=new DelegateCommand<Passenger>(OnMouseDoubleClick);
        }

        /// <summary>
        /// 列表双击事件
        /// </summary>
        /// <param name="p"></param>
        private void OnMouseDoubleClick(Passenger p)
        {
            //打开窗体
            ApplicationCommands.ShowCommand.Execute(FlyoutNames.PassengerDetailFlyout);

            //发布消息
            _msgEvent.GetEvent<PassengerSentEvent>().Publish(p);
        }
    }
}
