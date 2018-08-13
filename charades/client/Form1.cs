using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.SVC;

namespace client
{
    public partial class Form1 : Form
    {
        //SVC.CommsServiceClient serviceClient;
        //SVC.Client client;
        //SVC.Message message = new SVC.Message();

        InstanceContext instanceContext;
        TextBox[,] textBoxes;

        #region MyMethods


        void InitializeXtraComponent()
        {
            textBoxes = new TextBox[10, 10];
        }

        private TextBox createTextBox()
        {
            TextBox tb = new TextBox
            {
                MaxLength = 1,
                Cursor = System.Windows.Forms.Cursors.Cross,
                Anchor = AnchorStyles.Top,
                Dock = DockStyle.Fill,
            };
            tb.Anchor = AnchorStyles.Right;
            tb.Anchor = AnchorStyles.Bottom;
            tb.Anchor = AnchorStyles.Left;

            return tb;
        }

        public void sendMessage()
        {
            SVC.Message m = new SVC.Message();
            m.Sender = Program.Client.Name;
            m.Content = tbmessageSend.Text;
            Program.serviceClient.Send(m);
        }

        public void UpdateMesageList(SVC.Message m)
        {
            rtbMessages.Text = rtbMessages.Text + Environment.NewLine + " a";
            rtbMessages.Text = rtbMessages.Text + Environment.NewLine + m.Sender + ": " + m.Content;
        }

        #endregion


        public Form1()
        {

            InitializeComponent();
            InitializeXtraComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    scribleGrid.Controls.Add(createTextBox(), i, j);
                }
            }
        }


        #region UI_Events
        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void scribleGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            sendMessage();
            tbmessageSend.Clear();
        }


        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
