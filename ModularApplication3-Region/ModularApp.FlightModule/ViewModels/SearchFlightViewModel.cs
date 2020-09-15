//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: SearchFlightViewModel
//命名空间名称: ModularApp.FlightModule.ViewModels
//文件名: SearchFlightViewModel
//当前系统时间: 2020/9/14 9:59:20
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;

namespace ModularApp.FlightModule.ViewModels
{
    public class SearchFlightViewModel:BindableBase
    {
        #region fields

        private IFlightService _flightService;
        #endregion

        //航班信息集合
        private ObservableCollection<Flight> _currentFlights;

        /// <summary>
        /// 航班信息集合
        /// </summary>
        public ObservableCollection<Flight> CurrentFlights
        {
            get => _currentFlights;
            set
            {
                SetProperty(ref _currentFlights, value);
            }
        }

        #region  查询条件			
        // 查询条件
        private string _condition;

        /// <summary>
        ///  查询条件
        /// </summary>
        public string Condition
        {
            get => _condition;
            set
            {
                SetProperty(ref _condition, value);
            }
        }
        #endregion


        private DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand=new DelegateCommand(OnSearch));

        private void OnSearch()
        {
            CurrentFlights.Clear();
            CurrentFlights.AddRange(_flightService.GetAllFlights()
                .Where(p => p.FlightNo.Contains(Condition) || p.AirlineNames.Contains(Condition)));
        }

        //构造函数
        public SearchFlightViewModel(IFlightService flightService)
        {
            _flightService = flightService;

            CurrentFlights=new ObservableCollection<Flight>(_flightService.GetAllFlights());
        }
    }
}
