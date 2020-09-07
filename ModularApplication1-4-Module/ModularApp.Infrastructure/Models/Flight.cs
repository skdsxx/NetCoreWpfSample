//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: Flight
//命名空间名称: ModularApp.Infrastructure.Models
//文件名: Flight
//当前系统时间: 2020/8/25 14:09:28
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;

namespace ModularApp.Infrastructure.Models
{
    /// <summary>
    /// 航班
    /// </summary>
    public class Flight
    {
        //主键Id
        public int Id { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }

        /// <summary>
        /// 航班日期
        /// </summary>
        public DateTime FlightDate { get; set; }

        /// <summary>
        /// 航线名称
        /// </summary>
        public string AirlineNames { get; set; }

        /// <summary>
        /// 航线
        /// </summary>
        public List<Via> Airlines { get; set; }
    }
}
