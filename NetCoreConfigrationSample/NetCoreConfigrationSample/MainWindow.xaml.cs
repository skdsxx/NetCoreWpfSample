using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetCoreConfigrationSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //加载配置项按钮事件
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LoadEnv();
        }
        /// <summary>
        /// 环境变量封层读取要注意：
        /// 环境变量的Key是以__双下划线为分层键，而不是:冒号
        /// 分层读取的时候是以冒号:来进行读取
        /// </summary>
        private void LoadEnv()
        {
            string envString = string.Empty;
            envString = $"Env__IsProduction:{App.MyConfigration.GetSection("Env")["IsProduction"]}" + "\n";
            envString += $"Env__IsDevelopment:{App.MyConfigration.GetSection("Env")["IsDevelopment"] }" + "\n";
            envString += $"Class__Team__Group:{App.MyConfigration.GetSection("Class:Team")["Group"]}" + "\n";
            //过滤前缀后
            envString += $"IsProduction:{App.MyConfigration["IsProduction"]}";

            EnvTxt.Text = envString;
        }
    }
}
