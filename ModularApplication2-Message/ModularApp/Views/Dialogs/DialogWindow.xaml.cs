using System;
using System.Windows;
using Prism.Services.Dialogs; //using PrismMetroSample.Infrastructure.Helpers;

namespace ModularApp.Views.Dialogs
{
    /// <summary>
    /// DialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindow : Window, IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            //WindowHelp.RemoveIcon(this);
        }

        public IDialogResult Result { get; set; }
    }
}
