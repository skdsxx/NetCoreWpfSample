//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: IFlyoutView
//命名空间名称: ModularApp.Infrastructure.IServices
//文件名: IFlyoutView
//当前系统时间: 2020/9/4 13:10:17
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace ModularApp.Infrastructure.IServices
{
    /// <summary>
    /// Flyout窗口接口
    /// </summary>
    public interface IFlyoutView
    {
        public string FlyoutName { get; }
    }
}
