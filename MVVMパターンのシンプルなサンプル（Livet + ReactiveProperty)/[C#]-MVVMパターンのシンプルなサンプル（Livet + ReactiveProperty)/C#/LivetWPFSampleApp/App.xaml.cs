using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Livet;
using Reactive.Bindings;

namespace LivetWPFSampleApp
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DispatcherHelper.UIDispatcher = Dispatcher;
            UIDispatcherScheduler.Initialize();
        }
    }
}
