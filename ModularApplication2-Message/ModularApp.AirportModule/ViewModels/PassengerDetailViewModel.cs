//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: PassengerDetailViewModel
//命名空间名称: ModularApp.PassengerModule.ViewModels
//文件名: PassengerDetailViewModel
//当前系统时间: 2020/9/1 15:55:01
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Collections.ObjectModel;
using System.Windows.Input;
using ModularApp.Infrastructure.Events;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace ModularApp.PassengerModule.ViewModels
{
    /// <summary>
    /// 旅客详情
    /// </summary>
    public class PassengerDetailViewModel:BindableBase
    {
        //航班服务
        private readonly IFlightService _flightSerivce;

        //事件聚合器
        private readonly IEventAggregator _msgEvent;


        #region 当前要查看显示的乘客信息			
        //当前要查看显示的乘客信息
        private Passenger _currentPassenger;

        /// <summary>
        /// 当前要查看显示的乘客信息
        /// </summary>
        public Passenger CurrentPassenger
        {
            get => _currentPassenger;
            set=> SetProperty(ref _currentPassenger, value);
        }
        #endregion

        //旅客所在航班信息

        #region 旅客航班信息			
        //旅客航班信息
        private ObservableCollection<Flight> _passengerFlight;

        /// <summary>
        /// 旅客航班信息
        /// </summary>
        public ObservableCollection<Flight> PassengerFlight
        {
            get => _passengerFlight;
            set => SetProperty(ref _passengerFlight, value);
        }
        #endregion

        /// <summary>
        /// 取消命令
        /// </summary>
        public ICommand CancleAddFlightMsgCmd { get; }

        public PassengerDetailViewModel(IEventAggregator msgEvent,IFlightService flightSerivce)
        {
            _flightSerivce = flightSerivce;
            _msgEvent = msgEvent;

            CancleAddFlightMsgCmd = new DelegateCommand(OnCancleAddFlightMsg);

            //订阅旅客航班信息的查询消息
            _msgEvent.GetEvent<PassengerSentEvent>().Subscribe(PassengerMessageReceived);
            _msgEvent.GetEvent<FlightSentEvent>().Subscribe(AddFlight,ThreadOption.UIThread,false,f=>f.Id!=CurrentPassenger?.FlightId);
        }
        /// <summary>
        /// 旅客查询事件消息接收方法
        /// </summary>
        /// <param name="obj"></param>
        private void PassengerMessageReceived(Passenger obj)
        {
            if (obj == null)
            {
                return;
            }
            CurrentPassenger = obj;
            PassengerFlight = new ObservableCollection<Flight>();

            var aa = _flightSerivce.GetFlightById(obj.FlightId);
            PassengerFlight.Add(aa);
        }

        //增加旅客航班
        private void AddFlight(Flight f)
        {
            PassengerFlight.Add(f);
        }


        /// <summary>
        /// 取消订阅航班添加消息
        /// </summary>
        private void OnCancleAddFlightMsg()
        {
            _msgEvent?.GetEvent<FlightSentEvent>().Unsubscribe(AddFlight);
        }
    }
}
