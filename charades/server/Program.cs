using ServiceAssembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    static class Program
    {
        public static ServiceHost serviceHost;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            serviceHost = new ServiceHost(typeof(CommsService));
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Startup());
            }
            catch (Exception ex)
            {
                //lol, you screwed 
            }
        }
    }

    
    public class Game
    {
        private List<Client> clientList = new List<Client>();
        public void addClient(Client client)
        {
            clientList.Add(client);
        }
        public List<Client> ClientList { get { return clientList; } }

    }
}
