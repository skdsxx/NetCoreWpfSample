//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: AirportModule
//命名空间名称: ModularApp.AirportModule
//文件名: AirportModule
//当前系统时间: 2020/8/24 14:30:29
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using ModularApp.PassengerModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModularApp.PassengerModule
{
    /// <summary>
    /// 实现IModel接口，进行模块化注册
    /// </summary>
    public class PassengerModule : IModule
    {
        /// <summary>
        /// 模块需要依赖注入的类型
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
            regionManager.RegisterViewWithRegion("PassengerListRegion", typeof(PassengerListView));
        }

        
    }
}
