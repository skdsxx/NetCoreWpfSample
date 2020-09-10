//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: AirportService
//命名空间名称: ModularApp.Infrastructure.Services
//文件名: AirportService
//当前系统时间: 2020/8/25 14:22:28
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Collections.Generic;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;

namespace ModularApp.Infrastructure.Services
{
    public class PassengerService:IPassengerService
    {
        public List<Passenger> GetAllPassengers()
        {
            var list = new List<Passenger>
            {
                new Passenger {Id = 1, IdNo = "367678197802241234", Name = "云上风", Sex = "男",FlightId=1},
                new Passenger {Id = 2, IdNo = "367678198902044563", Name = "细化", Sex = "男",FlightId = 2},
                new Passenger {Id = 3, IdNo = "367678199910241234", Name = "水中月", Sex = "女",FlightId=3},
                new Passenger {Id = 4, IdNo = "367678201103172345", Name = "江上水", Sex = "女",FlightId = 6},
                new Passenger {Id = 5, IdNo = "367678201805243432", Name = "山中树", Sex = "女",FlightId = 4},
                new Passenger {Id = 6, IdNo = "367678196802243213", Name = "粗糙", Sex = "男",FlightId = 5},
                new Passenger {Id = 7, IdNo = "367678196602243213", Name = "备份的", Sex = "男",FlightId = 5},
                new Passenger {Id = 8, IdNo = "367678196502243213", Name = "非官方的", Sex = "女",FlightId = 6},
                new Passenger {Id = 9, IdNo = "367678199002243213", Name = "任务", Sex = "男",FlightId = 4},
                new Passenger {Id = 10, IdNo = "367678196802243213", Name = "丰富的", Sex = "男",FlightId = 2},
            };
            return list;
        }
    }
}
