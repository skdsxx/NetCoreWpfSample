using System.Windows;
using Microsoft.Extensions.Configuration;

namespace NetCoreConfigrationSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static IConfiguration MyConfigration => new ConfigurationBuilder()
        //    .AddEnvironmentVariables()
        //    .Build();


        //public static IConfiguration MyConfigration => new ConfigurationBuilder()
        //    .AddEnvironmentVariables("Env:")//添加变量读取的分层过滤
        //    .Build();

        //注入配置文件进行读取
        public static IConfiguration MyConfigration => new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile(@"Configurations\appsetting.json", false, true)
            .AddXmlFile(@"Configurations\appsetting.xml", false, true)
            .AddIniFile(@"Configurations\appsetting.Ini")
            .Build();
    }
}
