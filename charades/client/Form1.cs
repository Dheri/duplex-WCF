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

namespace client
{
    public partial class Form1 : Form
    {
        CommsServiceReference.CommsServiceClient serviceClient;
        InstanceContext instanceContext;
        TextBox[,] textBoxes;

        public Form1()
        {
            instanceContext = new InstanceContext(new CommsServiceDuplexCallback());
            serviceClient = new CommsServiceReference.CommsServiceClient(instanceContext);
            textBoxes = new TextBox[10, 10];

            InitializeComponent();
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

        private TextBox createTextBox()
        {
            TextBox tb = new TextBox();
            tb.MaxLength = 1;
            tb.Cursor = System.Windows.Forms.Cursors.Cross;
            tb.Anchor = AnchorStyles.Top;
            tb.Anchor = AnchorStyles.Right;
            tb.Anchor = AnchorStyles.Bottom;
            tb.Anchor = AnchorStyles.Left;
            tb.Dock = DockStyle.Fill;
            return tb;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void scribleGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
