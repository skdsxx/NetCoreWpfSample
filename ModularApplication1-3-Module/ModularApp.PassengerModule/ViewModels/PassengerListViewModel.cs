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
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;
using Prism.Mvvm;

namespace ModularApp.PassengerModule.ViewModels
{
    public class PassengerListViewModel:BindableBase
    {
        #region Fields

        private readonly IPassengerService _passengerService;

        #endregion

        private ObservableCollection<Passenger> _allPassengers;
        /// <summary>
        /// 旅客列表
        /// </summary>
        public ObservableCollection<Passenger> AllPassengers
        {
            get { return _allPassengers; }
            set { SetProperty(ref _allPassengers, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passengerService"></param>
        public PassengerListViewModel(IPassengerService passengerService)
        {
            _passengerService = passengerService;
            AllPassengers = new ObservableCollection<Passenger>(_passengerService.GetAllPassengers());
        }
    }
}
