//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: FlyoutService
//命名空间名称: ModularApp.Infrastructure.Services
//文件名: FlyoutService
//当前系统时间: 2020/9/1 17:26:30
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MahApps.Metro.Controls;
using ModularApp.Infrastructure.Constants;
using ModularApp.Infrastructure.IServices;
using Prism.Commands;
using Prism.Regions;

namespace ModularApp.Infrastructure.Services
{
    public class FlyoutService:IFlyoutService
    {
        IRegionManager _regionManager;
        IApplicationCommands _applicationCommands;

        /// <summary>
        /// 显示Flyout窗口命令
        /// </summary>
        public ICommand ShowFlyoutCommand { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager">注入依赖，区块管理器</param>
        /// <param name="applicationCommands">注入依赖，应用命令</param>
        public FlyoutService(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            _regionManager = regionManager;
            _applicationCommands = applicationCommands;

            ShowFlyoutCommand = new DelegateCommand<string>(ShowFlyout);
            //注册子命令给全局复合命令
            _applicationCommands.ShowCommand.RegisterCommand(ShowFlyoutCommand);

        }

        /// <summary>
        /// 显示Flyout窗口
        /// </summary>
        /// <param name="flyoutName">窗口名称</param>
        public void ShowFlyout(string flyoutName)
        {
            var region = _regionManager.Regions[RegionNames.FlyoutRegion];

            if (region != null)
            {
                var flyout = region.Views.Where(v => v is IFlyoutView && ((IFlyoutView)v).FlyoutName.Equals(flyoutName)).FirstOrDefault() as Flyout;

                if (flyout != null)
                {
                    flyout.IsOpen = !flyout.IsOpen;
                }
            }
        }
    }
}
