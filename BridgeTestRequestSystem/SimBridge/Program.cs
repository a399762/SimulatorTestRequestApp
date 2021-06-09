using log4net;
using log4net.Config;
using SimBridge.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimBridge
{
    static class Program
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            log.Debug("Started:" + DateTime.Now);

            //ensure database is setup
            bool dbstatus = DBHelper.InitDB();

            if (dbstatus == false)
            {
                MessageBox.Show("Database init error, view logs");
            }
            else
            {
                //any other init stuff


                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Main());
            }

        }
    }
}
