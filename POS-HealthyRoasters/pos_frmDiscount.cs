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
    public partial class pos_frmDiscount : Form
    {
        private string grandtotal;
        private string session;
        private string discountInfo;

        static Color yellowTemp = Color.FromArgb(0xE1D205);
        static Color redTemp = Color.FromArgb(0xE10A16);
        Color yellow = Color.FromArgb(yellowTemp.R, yellowTemp.G, yellowTemp.B);
        Color red = Color.FromArgb(redTemp.R, redTemp.G, redTemp.B);

        public pos_frmDiscount(string username, string grandtotal)
        {
            InitializeComponent();
            session = username;
            this.grandtotal = grandtotal;
        }

        public pos_frmDiscount()
        {
            InitializeComponent();
        }

        private void pos_frmDiscount_Load(object sender, EventArgs e)
        {
            btnSC.BackColor = yellow;
            btnPWD.BackColor = yellow;
            btnCoupon.BackColor = yellow;
            btnManager.BackColor = yellow;

            btnClose.BackColor = red;
            btnClose.ForeColor = Color.White;
        }

        private void openDiscountUI(object sender, EventArgs e)
        {
            Button button = sender as Button;
            StringBuilder type = new StringBuilder("");

            if (button.Text == "Senior Citizen")
            {
                type.Append("Senior ID:");
            }
            else if (button.Text == "PWD")
            {
                type.Append("PWD ID:");
            }

            pos_Discount pd = new pos_Discount(type.ToString(), grandtotal, session);
            this.Hide();
            pd.ShowDialog(this);

            if (pd.DialogResult == DialogResult.OK)
            {
                grandtotal = pd.getGrandTotal();
                discountInfo = pd.getDiscountInfo();
                pd.Dispose();
                this.DialogResult = DialogResult.OK;
            }
            else if (pd.DialogResult == DialogResult.Cancel)
            {
                pd.Dispose();
                this.Show();
            }
        }

        private void btnCoupon_Click(object sender, EventArgs e)
        {
            pos_CouponDiscount cd = new pos_CouponDiscount(grandtotal, session);
            this.Hide();
            cd.ShowDialog(this);

            if (cd.DialogResult == DialogResult.OK)
            {
                grandtotal = cd.getGrandTotal();
                discountInfo = cd.getDiscountInfo();
                cd.Dispose();
                this.DialogResult = DialogResult.OK;
            }
            else if (cd.DialogResult == DialogResult.Cancel)
            {
                cd.Dispose();
                this.Show();
            }
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            pos_ManagerDiscount md = new pos_ManagerDiscount(grandtotal, session);
            this.Hide();
            md.ShowDialog(this);

            if (md.DialogResult == DialogResult.OK)
            {
                grandtotal = md.getGrandTotal();
                discountInfo = md.getDiscountInfo();
                md.Dispose();
                this.DialogResult = DialogResult.OK;
            }
            else if (md.DialogResult == DialogResult.Cancel)
            {
                md.Dispose();
                this.Show();
            }
        }

        public string getDiscountInfo()
        {
            return discountInfo;
        }

        public string getGrandTotal()
        {
            return grandtotal;
        }
    }
}
