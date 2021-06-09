using SimBridge.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimTestRequestBridge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //  var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            // XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            //    log.Debug("Started:" + DateTime.Now);

            //ensure database is setup
            bool dbstatus = DBHelper.InitDB();

            if (dbstatus == false)
            {
                MessageBox.Show("Database init error, view logs");
            }
        }
    }
}
