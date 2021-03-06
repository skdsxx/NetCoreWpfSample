﻿using ModularApp.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using ModularApp.Infrastructure;
using ModularApp.Infrastructure.IServices;
using ModularApp.Infrastructure.Services;
using ModularApp.ViewModels.Dialogs;
using ModularApp.Views;
using ModularApp.Views.Dialogs;
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

            //注册全局命令
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());

            //注册对话框窗体
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialogWindow<DialogWindow>();
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
