//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: PassengerSentEvent
//命名空间名称: ModularApp.Infrastructure.Events
//文件名: PassengerSentEvent
//当前系统时间: 2020/9/1 16:56:43
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;
using System.Text;
using ModularApp.Infrastructure.Models;
using Prism.Events;

namespace ModularApp.Infrastructure.Events
{
    /// <summary>
    /// 创建旅客详情查询事件
    /// </summary>
    public class PassengerSentEvent:PubSubEvent<Passenger>
    {
    }
}
