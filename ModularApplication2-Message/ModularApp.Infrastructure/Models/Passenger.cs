//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: Airport
//命名空间名称: ModularApp.Infrastructure.Models
//文件名: Airport
//当前系统时间: 2020/8/25 14:11:41
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

namespace ModularApp.Infrastructure.Models
{
    /// <summary>
    /// 旅客
    /// </summary>
    public class Passenger
    {
        //主键Id
        public int Id { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 所属航班号
        /// </summary>
        public int FlightId { get; set; }
    }
}
