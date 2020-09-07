//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: FlightModule
//命名空间名称: ModularApp.FlightModule
//文件名: FlightModule
//当前系统时间: 2020/8/24 14:24:32
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using ModularApp.FlightModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModularApp.FlightModule
{
    public class FlightModule : IModule
    {
        /// <summary>
        /// 模块加载时需要依赖注入的类型
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
        /// <summary>
        /// 模块初始化
        /// 通常会注册模块试图，或者订阅应用程序级别的事件和服务
        /// </summary>
        /// <param name="containerProvider"></param>       
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //FlightContent
            regionManager.RegisterViewWithRegion("FlightMainContentRegion", typeof(FlightContentView));
        }
    }
}
