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
    public partial class pos_ManagerDiscount : Form
    {
        DBConnect db = new DBConnect();
        private string totalPrice;
        private string session;
        private double grandTotal = 0;
        private double discountPrice = 0;

        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);

        public pos_ManagerDiscount(string totalPrice, string username)
        {
            InitializeComponent();
            this.totalPrice = totalPrice;
            session = username;
        }

        private void pos_ManagerDiscount_Load(object sender, EventArgs e)
        {
            btnManagerDiscount.BackColor = green;
            btnCancel.BackColor = orange;
            btnManagerDiscount.ForeColor = Color.White;
            btnCancel.ForeColor = Color.White;
        }

        private void btnManagerDiscount_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtDiscountPercent.Text)) || (string.IsNullOrWhiteSpace(txtUsername.Text))
                || (string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                MessageBox.Show("Please fill the missing field/s.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                messageAction();
            }
            else
            {
                if (db.validateUser(txtUsername.Text, txtPassword.Text) == "user")
                {
                    MessageBox.Show("Only authorized personel can perform this action.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    messageAction();
                }
                else if (db.validateUser(txtUsername.Text, txtPassword.Text) == "admin")
                {
                    double discountPercent = Convert.ToDouble(txtDiscountPercent.Text) / 100;
                    double price = Convert.ToDouble(totalPrice);
                    discountPrice = price * discountPercent;
                    grandTotal = price - discountPrice;

                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                        txtDiscountPercent.Text + "% Manager Discount by: " + db.validateManager(txtUsername.Text)) == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (db.validateUser(txtUsername.Text, txtPassword.Text) == "error")
                {
                    MessageBox.Show("No connection! Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    messageAction();
                }
                else
                {
                    MessageBox.Show("Incorrect username and/or password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    messageAction();
                }
            }
        }

        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back |
                (txtDiscountPercent.Text.Length > 1 & char.IsNumber(e.KeyChar) & !(txtDiscountPercent.Text + e.KeyChar).Equals("100")))
            {
                e.Handled = true;
            }
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountPercent.Text.StartsWith("0"))
            {
                txtDiscountPercent.Text = txtDiscountPercent.Text.Substring(1);
            }
        }

        public void messageAction()
        {
            txtDiscountPercent.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtDiscountPercent.Focus();
        }

        public string getGrandTotal()
        {
            return String.Format("{0:0.00}", grandTotal);
        }

        public string getDiscountInfo()
        {
            return "\nManager's discount Amount: Php " + String.Format("{0:#,0.00}", discountPrice);
        }
    }
}
