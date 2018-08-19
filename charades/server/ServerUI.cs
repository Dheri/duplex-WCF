using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceAssembly;
namespace server
{
    public partial class ServerUI : Form
    {
        int gameid;
        DSTableAdapters.clientsTableAdapter taClient;
        DSTableAdapters.gamesTableAdapter taGame;
        DSTableAdapters.gamelogsTableAdapter tagameLog;
        DSTableAdapters.gameresultsTableAdapter tagameresults;
        public ServerUI()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            taClient = new DSTableAdapters.clientsTableAdapter();
            tagameLog = new DSTableAdapters.gamelogsTableAdapter();
            tagameresults = new DSTableAdapters.gameresultsTableAdapter();


            foreach (Client c in Program.Service.Clients.Keys)
            {
                taClient.Insert(c.Name.ToUpper().Trim());
                tagameresults.InsertGameResultsQuery(gameid, c.Name.ToUpper(), c.Score);
                foreach (string word in c.PlayedWords)
                {
                    tagameLog.InsertWordLogQuery(gameid, word.ToUpper(), c.Name.ToUpper());
                }
            }

            Console.WriteLine("Server Closed");
        }

        private void ServerUI_Load(object sender, EventArgs e)
        {

            taGame = new DSTableAdapters.gamesTableAdapter();

            // insert game record on start
            gameid = (int)taGame.InsertNewGameQuery(DateTime.Now, "STUB");
            Console.WriteLine("gid " + gameid);
            lblGameId.Text = "Game ID:   " + gameid;

        }
    }
}
