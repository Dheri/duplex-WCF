using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void btnStartSrvr_Click(object sender, EventArgs e)
        {
            Program.serviceHost.Open();//open service
            Console.WriteLine("Service started");

            Console.WriteLine("Server started");
            Console.WriteLine("\n");
            Console.WriteLine(" Configuration Name: " + Program.serviceHost.Description.ConfigurationName);
            Console.WriteLine(" End point address: " + Program.serviceHost.Description.Endpoints[0].Address);
            Console.WriteLine(" End point MEX address: " + Program.serviceHost.Description.Endpoints[1].Address);
            Console.WriteLine(" End point binding: " + Program.serviceHost.Description.Endpoints[0].Binding.Name);
            Console.WriteLine(" End point contract: " + Program.serviceHost.Description.Endpoints[0].Contract.ConfigurationName);
            Console.WriteLine(" End point name: " + Program.serviceHost.Description.Endpoints[0].Name);
            Console.WriteLine(" End point lisent uri: " + Program.serviceHost.Description.Endpoints[0].ListenUri);
            Console.WriteLine(" \nName:" + Program.serviceHost.Description.Name);
            Console.WriteLine(" Namespace: " + Program.serviceHost.Description.Namespace);
            Console.WriteLine(" Service Type: " + Program.serviceHost.Description.ServiceType);



            ServerUI form1 = new ServerUI();
            this.Hide();
            form1.Show();
        }
    }
}
