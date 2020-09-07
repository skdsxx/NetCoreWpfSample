//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: Via
//命名空间名称: ModularApp.Infrastructure.Models
//文件名: Via
//当前系统时间: 2020/8/25 14:12:20
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

namespace ModularApp.Infrastructure.Models
{
    /// <summary>
    /// 经停站
    /// </summary>
    public class Via
    {

        //航班Id
        public int FlightId { get; set; }

        //序号
        public int Number { get; set; }

        /// <summary>
        /// 机场三字码
        /// </summary>
        public string Iata { get; set; }

        public string Name { get; set; }
    }
}
