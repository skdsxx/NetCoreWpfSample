using System;
using ModularApp.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Services;
using ModularApp.Views;
using Prism.Mvvm;

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
        /// 配置文件注册，发现模块
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            //加载配置文件模块目录
            return ModuleCatalog.CreateFromXaml(new Uri("/ModularApp;component/ModuleCatalog.xaml", UriKind.Relative));
        }
    }
}
