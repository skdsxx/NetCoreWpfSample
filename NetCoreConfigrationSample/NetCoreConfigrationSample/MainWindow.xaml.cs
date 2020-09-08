using System.Windows;
using Microsoft.Extensions.Configuration;

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
            LoadJson();
            LoadXml();
            LoadIni();
            LoadBind();
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
        /// <summary>
        /// 加载Json文件
        /// </summary>
        private void LoadJson()
        {
            var jsonString = string.Empty;
            foreach (var item in App.MyConfigration.GetSection("Human").GetChildren())
            {
                if (item.Key.Contains("Body"))
                {
                    foreach (var body in item.GetChildren())
                    {
                        jsonString += $"{body.Key}:{body.Value} \n";
                    }
                }
                else
                {
                    jsonString += $"{item.Key}:{item.Value} \n";
                }

            }
            JsonTxt.Text = jsonString;
        }

        /// <summary>
        /// 加载Xml文件
        /// </summary>
        private void LoadXml()
        {
            var xmlString = string.Empty;
            foreach (var item in App.MyConfigration.GetSection("DbServers").GetChildren())
            {
                xmlString += $"{item.Key}:{item.Value} \n";
            }
            XmlTxt.Text = xmlString;
        }

        private void LoadIni()
        {
            var iniString = string.Empty;
            foreach (var item in App.MyConfigration.GetSection("Ini").GetChildren())
            {
                iniString += $"{item.Key}:{item.Value} \n";
            }
            foreach (var item in App.MyConfigration.GetSection("Test").GetChildren())
            {
                iniString += $"{item.Key}:{item.Value} \n";
            }
            IniTxt.Text = iniString;
        }
        /// <summary>
        /// 强类型绑定
        /// </summary>
        private void LoadBind()
        {
            var bindString = string.Empty;
            HumanConfig config = new HumanConfig();//声明变量

            App.MyConfigration.GetSection("Human").Bind(config);//绑定变量

            foreach (var configProperty in config.GetType().GetProperties())
            {
                if (configProperty.PropertyType == typeof(Body))
                {
                    var body = configProperty.GetValue(config) as Body;
                    foreach (var bodyProperty in body.GetType().GetProperties())
                    {
                        bindString += $"{bodyProperty.Name}:{bodyProperty.GetValue(body)} \n";
                    }
                }
                else
                {
                    bindString += $"{configProperty.Name}:{configProperty.GetValue(config)} \n";
                }

            }
            TypeTxt.Text = bindString+"\n";
            TypeTxt.Text = TypeTxt.Text+ config.Name + " >" + config.Age + " >" + config.Sex + " >" + config.Body.Height + ":" +
                           config.Body.Weight;

        }
    }
}
