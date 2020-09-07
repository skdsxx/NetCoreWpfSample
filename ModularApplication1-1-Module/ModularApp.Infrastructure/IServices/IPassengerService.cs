//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: IAirport
//命名空间名称: ModularApp.Infrastructure.IServices
//文件名: IAirportService
//当前系统时间: 2020/8/25 14:22:08
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Collections.Generic;
using ModularApp.Infrastructure.Models;

namespace ModularApp.Infrastructure.IServices
{
    /// <summary>
    /// 旅客服务接口
    /// </summary>
    public interface IPassengerService
    {
        /// <summary>
        /// 获取所有旅客
        /// </summary>
        /// <returns></returns>
        List<Passenger> GetAllPassengers();
    }
}
