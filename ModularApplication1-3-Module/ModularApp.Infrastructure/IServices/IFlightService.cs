//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: IFlightService
//命名空间名称: ModularApp.Infrastructure.IServices
//文件名: IFlightService
//当前系统时间: 2020/8/25 14:21:06
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Collections.Generic;
using ModularApp.Infrastructure.Models;

namespace ModularApp.Infrastructure.IServices
{
    /// <summary>
    /// 航班服务
    /// </summary>
    public interface IFlightService
    {
        List<Flight> GetAllFlights();

        List<Via> GetViasByFlightId(int flightId);
    }
}
