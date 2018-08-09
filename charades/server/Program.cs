using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    static class Program
    {
        static ServiceHost serviceHost;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             serviceHost = new ServiceHost(typeof(CommsService));
            try
            {

                serviceHost.Open();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                //lol, you screwed 
            }
        }
    }
}
