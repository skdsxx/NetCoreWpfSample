using ModularApp.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using System.Windows.Controls.Primitives;
using ModularApp.Infrastructure;
using ModularApp.Infrastructure.CustomerRegionAdapter;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Services;
using ModularApp.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace ModularApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 重写ViewModel绑定，
        /// Prism在Xaml文件中设置ViewModelLocator.AutoWireViewModel="True"
        /// 即可自动将窗体或者用户空间与对应的ViewModel后缀类进行绑定
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            //这段代码可以更改绑定的ViewModel后缀
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //{
            //    var viewName = viewType.FullName;
            //    var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //    var viewModelName = $"{viewName}VM, {viewAssemblyName}";
            //    return Type.GetType(viewModelName);
            //});

            //这段代码可以随意更改窗体的DataContext的绑定
            //比如把MainWindowViewModel,更改为MainWindowVM
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }

        //程序启动时需要注入的类型
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册服务
            containerRegistry.Register<IFlightService, FlightService>();
            containerRegistry.Register<IPassengerService, PassengerService>();

            //注册全局命令
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());
        }

        /// <summary>
        /// 程序启动时，需要启动的主窗体   重载应用程序的主窗体应用（Shell）
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// RegionAdapter配置
        /// </summary>
        /// <param name="regionAdapterMappings"></param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            //为UniformGrid控件注册适配器映射
            regionAdapterMappings.RegisterMapping(typeof(UniformGrid), Container.Resolve<UniformGridRegionAdapter>());
        }

        /// <summary>
        /// 注册需要的模块
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //注册Passenger模块
            moduleCatalog.AddModule<PassengerModule.PassengerModule> ();

            //将FlightModule模块设置为按需加载
            var flightModuleType = typeof(FlightModule.FlightModule);
            moduleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = flightModuleType.Name,
                ModuleType = flightModuleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }
    }
}
