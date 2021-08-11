using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_HealthyRoasters
{
    public partial class Receipt : Form
    {
        private string resibo;

        static Color greenTemp = Color.FromArgb(0x2EB82E);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);

        public Receipt(string rInfo)
        {
            InitializeComponent();
            resibo = rInfo;
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            button1.BackColor = green;
            button1.ForeColor = Color.White;

            lblReceipt.Text = resibo;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
