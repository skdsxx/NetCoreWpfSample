//=====================================================
//CLR版本: 4.0.30319.42000
//作     者：Sun Xian
//新建项输入的名称: ApplicationCommands
//命名空间名称: ModularApp.Infrastructure
//文件名: ApplicationCommands
//当前系统时间: 2020/9/4 11:31:30
//创建年份: 2020
//=====================================================
//Copyright： @青岛凯亚研发部@
//======================================================

using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;

namespace ModularApp.Infrastructure
{
    public interface IApplicationCommands
    {
        public CompositeCommand ShowCommand { get; }
    }

    public class ApplicationCommands: IApplicationCommands
    {
        public CompositeCommand ShowCommand { get; } = new CompositeCommand();
    }
}
