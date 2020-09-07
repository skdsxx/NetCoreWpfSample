//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: MainWindowViewModel
//命名空间名称: ModularApp.ViewModels
//文件名: MainWindowViewModel
//当前系统时间: 2020/8/25 10:34:32
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System.Windows;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;

namespace ModularApp.ViewModels
{
    /// <summary>
    /// 主窗体View Model
    /// </summary>
    public class MainWindowViewModel:BindableBase
    {
        #region Fields

        //模块管理器
        IModuleManager _moduleManager;

        #endregion

        #region Commands
        //加载机场的命令
        private DelegateCommand _loadFlightModuleCmd;
        public DelegateCommand LoadFlightModuleCmd =>
            _loadFlightModuleCmd ??= new DelegateCommand(ExecuteLoadFlightModuleCmd);

        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="moduleManager"></param>
        public MainWindowViewModel(IModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
        }
        

        /// <summary>
        /// 航班模块加载方法实现
        /// </summary>
        private void ExecuteLoadFlightModuleCmd()
        {
            _moduleManager.LoadModule("FlightModule");
        }

        /// <summary>
        /// 模块加载完成事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            MessageBox.Show($"{e.ModuleInfo.ModuleName}模块被加载了");
        }

    }
}
