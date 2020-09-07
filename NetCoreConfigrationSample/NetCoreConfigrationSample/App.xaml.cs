using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace NetCoreConfigrationSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration MyConfigration => new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();


        //public static IConfiguration MyConfigration => new ConfigurationBuilder()
        //    .AddEnvironmentVariables("Env:")//添加变量读取的分层过滤
        //    .Build();
    }
}
