//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: IFlyoutService
//命名空间名称: ModularApp.Infrastructure.IServices
//文件名: IFlyoutService
//当前系统时间: 2020/9/1 17:26:03
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace ModularApp.Infrastructure.IServices
{
    //左右显示服务接口
    public interface IFlyoutService
    {
        //显示Flyout窗口
        void ShowFlyout(string flyoutName);
    }
}
