//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: FlightService
//命名空间名称: ModularApp.Infrastructure.Services
//文件名: FlightService
//当前系统时间: 2020/8/25 14:21:48
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Models;

namespace ModularApp.Infrastructure.Services
{
    public class FlightService:IFlightService
    {
        /// <summary>
        /// 获取所有航班信息
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetAllFlights()
        {
            var list = new List<Flight>
            {
                new Flight
                {
                    Id = 1, 
                    FlightNo = "SC5566",
                    FlightDate = DateTime.Today.AddDays(-1),
                    AirlineNames = "北京-郑州-桂林",
                    TakeoffTime = DateTime.Now.AddHours(5),
                    Airlines= new List<Via>
                    {
                        new Via{ FlightId = 1,Number = 0,Iata = "PEK",Name="北京"},
                        new Via{ FlightId = 1,Number = 1,Iata = "CGO",Name="郑州"},
                        new Via{ FlightId = 1,Number = 2,Iata = "KWL",Name="桂林"}
                    }
                },
                new Flight
                {
                    Id = 2, FlightNo = "WE3546", AirlineNames = "北京-上海虹桥",
                    FlightDate = DateTime.Today.AddDays(-1),
                    TakeoffTime = DateTime.Now.AddHours(2),
                    Airlines= new List<Via>
                    {
                        new Via{ FlightId = 2,Number = 0,Iata = "PEK",Name="北京"},
                        new Via{ FlightId = 2,Number = 1,Iata = "SHA",Name="上海虹桥"}
                    }
                },
                new Flight
                {
                    Id = 3, FlightNo = "CA9985", AirlineNames = "北京-重庆",
                    FlightDate = DateTime.Today.AddDays(-1),
                    TakeoffTime = DateTime.Now.AddHours(3),
                    Airlines= new List<Via>
                    {
                        new Via{ FlightId = 3,Number = 0,Iata = "PEK",Name="北京"},
                        new Via{ FlightId = 3,Number = 1,Iata = "CKG",Name="重庆"}
                    }
                },
                new Flight
                {
                    Id = 4, FlightNo = "3U3456", AirlineNames = "北京-青岛-仁川",
                    FlightDate = DateTime.Today.AddDays(-1),
                    TakeoffTime = DateTime.Now.AddHours(4),
                    Airlines= new List<Via>
                    {
                        new Via{ FlightId = 4,Number = 0,Iata = "PEK",Name="北京"},
                        new Via{ FlightId = 4,Number = 1,Iata = "TAO",Name="青岛"},
                        new Via{ FlightId = 4,Number = 2,Iata = "ICN",Name="仁川"}
                    }
                },
                new Flight
                {
                    Id = 5, FlightNo = "CA3546", AirlineNames = "北京-乌鲁木齐",
                    FlightDate = DateTime.Today.AddDays(-1),
                    TakeoffTime = DateTime.Now.AddHours(5),
                    Airlines= new List<Via>
                    {
                        new Via{ FlightId = 5,Number = 0,Iata = "PEK",Name="北京"},
                        new Via{ FlightId = 5,Number = 1,Iata = "URC",Name="乌鲁木齐"}
                    }
                },
                new Flight
                {
                    Id = 6, FlightNo = "HA3546", AirlineNames = "北京-佛山",
                    TakeoffTime = DateTime.Now.AddHours(6),
                    FlightDate = DateTime.Today.AddDays(-1),
                    Airlines= new List<Via>
                    {
                        new Via{ FlightId = 6,Number = 0,Iata = "PEK",Name="北京"},
                        new Via{ FlightId = 6,Number = 1,Iata = "FUO",Name="佛山"}
                    }
                },
            };

            return list;
        }
        //获取航班的经停站信息
        public List<Via> GetViasByFlightId(int flightId)
        {
            var flights = GetAllFlights();
            return flights.FirstOrDefault(p=>p.Id==flightId)?.Airlines;
        }

        /// <summary>
        ///通过航班Id 获取航班信息
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public Flight GetFlightById(int flightId)
        {
            return GetAllFlights().FirstOrDefault(p => p.Id == flightId);
        }
    }
}
