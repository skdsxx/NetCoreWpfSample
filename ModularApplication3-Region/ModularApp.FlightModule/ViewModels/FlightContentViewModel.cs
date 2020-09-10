//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: FlightContentViewModel
//命名空间名称: ModularApp.FlightModule.ViewModels
//文件名: FlightContentViewModel
//当前系统时间: 2020/8/24 15:23:54
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ModularApp.Infrastructure.Events;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;
using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ModularApp.FlightModule.ViewModels
{
    public class FlightContentViewModel : BindableBase, IActiveAware
    {
        #region 监控视图激活状态
        public event EventHandler IsActiveChanged;

        bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (_isActive)
                {
                    MessageBox.Show("视图被激活了");
                }
                else
                {
                    MessageBox.Show("视图失效了");
                }
                IsActiveChanged?.Invoke(this, new EventArgs());
            }
        }

        #endregion
        #region Fields

        private readonly IFlightService _flightSerivce;
        private readonly IEventAggregator _msgEvent;
        private readonly IDialogService _dialogService;


        #endregion

        private ObservableCollection<Flight> _allFlights;
        public ObservableCollection<Flight> AllFlights
        {
            get { return _allFlights; }
            set { SetProperty(ref _allFlights, value); }
        }

        /// <summary>
        /// 添加旅客航班
        /// </summary>
        public ICommand AddPassengerFlightCmd { get;}


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="flightSerivce"></param>
        /// <param name="msgEvent"></param>
        /// <param name="dialogService"></param>
        public FlightContentViewModel(IFlightService flightSerivce, IEventAggregator msgEvent, IDialogService dialogService)
        {
            _flightSerivce = flightSerivce;
            _msgEvent = msgEvent;
            _dialogService = dialogService;

            AddPassengerFlightCmd = new DelegateCommand<Flight>(OnAddPassengerFlight);
            AllFlights = new ObservableCollection<Flight>(_flightSerivce.GetAllFlights());

        }

        /// <summary>
        /// 添加旅客航班信息
        /// </summary>
        /// <param name="flight"></param>
        private void OnAddPassengerFlight(Flight flight)
        {
            _msgEvent.GetEvent<FlightSentEvent>().Publish(flight);
        }
    }
}
