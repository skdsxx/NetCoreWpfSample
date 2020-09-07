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

using System.Collections.ObjectModel;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;
using Prism.Mvvm;

namespace ModularApp.FlightModule.ViewModels
{
    public class FlightContentViewModel : BindableBase
    {
        #region Fields

        private readonly IFlightService _flightSerivce;

        #endregion

        private ObservableCollection<Flight> _allFlights;
        //所有航班信息列表
        public ObservableCollection<Flight> AllFlights
        {
            get { return _allFlights; }
            set { SetProperty(ref _allFlights, value); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="flightSerivce"></param>
        public FlightContentViewModel(IFlightService flightSerivce)
        {
            _flightSerivce = flightSerivce;
            AllFlights = new ObservableCollection<Flight>(_flightSerivce.GetAllFlights());
        }
    }
}
