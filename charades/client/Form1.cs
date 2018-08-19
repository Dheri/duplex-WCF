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

        TextBox[,] textBoxes;

        #region MyMethods


        void InitializeXtraComponent()
        {
            textBoxes = new TextBox[10, 10];
            lblName.Text = Program.Client.Name;
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
            int len = rtbMessages.TextLength;
            rtbMessages.AppendText(m.Sender + ": " + m.Content + Environment.NewLine);

            Console.WriteLine(rtbMessages.TextLength);
            rtbMessages.Select(len, m.Sender.Length + 1);
            rtbMessages.SelectionFont = new Font(rtbMessages.Font, FontStyle.Bold);

            //  rtbMessages.SelectionStart = rtbMessages.TextLength;
            rtbMessages.ScrollToCaret();
        }

        public void ShowUserJoin(SVC.Client c)
        {
            rtbMessages.AppendText(rtbMessages.Text + c.Name + " joined " + Environment.NewLine);
        }

        #endregion


        public Form1()
        {

            InitializeComponent();
            InitializeXtraComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wordDS.words' table. You can move, or remove it, as needed.
            this.wordsTableAdapter.Fill(this.wordDS.words);

            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    scribleGrid.Controls.Add(createTextBox(), i, j);
                }
            }
        }


        #region UI_Events

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


        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbmessageSend_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
