using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.SVC;

namespace client
{
    static class Program
    {
       // public static string clientName;
        public static Login login;
        public static Form1 form1;
        public static object game;


        public static SVC.CommsServiceClient serviceClient;
        public static SVC.Client Client;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login = new Login();
            Application.Run(login);
        }

    }
    public class CallBackImlementation : SVC.ICommsServiceCallback
    {

        public void Receive(SVC.Message msg)
        {
            Program.form1.UpdateMesageList(msg);
        }

        public void RefreshClients(List<Client> clientList)
        {
            throw new NotImplementedException();
        }

        public void UserJoin(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
