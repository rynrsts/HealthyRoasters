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
    public partial class pos_Discount : Form
    {
        Controller ctrl = new Controller();
        DBConnect db = new DBConnect();

        private string type;
        private string totalPrice;
        private double grandTotal = 0;
        private string session;
        private double discountPrice;
        private string discountType;

        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);

        public pos_Discount(string type, string totalPrice, string username)
        {
            InitializeComponent();
            this.type = type;
            this.totalPrice = totalPrice;
            session = username;
        }

        private void pos_Discount_Load(object sender, EventArgs e)
        {
            btnApplyDiscount.BackColor = green;
            btnCancel.BackColor = orange;
            btnApplyDiscount.ForeColor = Color.White;
            btnCancel.ForeColor = Color.White;

            lblID.Text = type;
            ctrl.setPercentage();
        }

        private void discountTotalPrice(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(txtID.Text)) && (!string.IsNullOrWhiteSpace(txtFirst.Text)) && (!string.IsNullOrWhiteSpace(txtMiddle.Text))
                && (!string.IsNullOrWhiteSpace(txtLast.Text)) && (!string.IsNullOrWhiteSpace(txtAddress.Text)))
            {
                discountType = "";
                double discountPercent = 0;

                if (lblID.Text == "Senior ID:")
                {
                    discountPercent = Convert.ToDouble(ctrl.getSC()) / 100;
                    discountType = "SC ";
                }
                else if (lblID.Text == "PWD ID:")
                {
                    discountPercent = Convert.ToDouble(ctrl.getPWD()) / 100;
                    discountType = "PWD";
                }

                double price = Convert.ToDouble(totalPrice);
                discountPrice = price * discountPercent;
                grandTotal = price - discountPrice;

                if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Discounted a " + discountType + " patron") == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Please fill the empty field/s.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    txtID.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtFirst.Text))
                {
                    txtFirst.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtMiddle.Text))
                {
                    txtMiddle.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtLast.Text))
                {
                    txtLast.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    txtAddress.Focus();
                }
            }
        }  

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
        
        private void lettersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) & !char.IsWhiteSpace(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        public string getDiscountInfo()
        {
            return "\n" + discountType + " discount Amount:       Php " + String.Format("{0:#,0.00}", discountPrice);
        }

        public string getGrandTotal()
        {
            return String.Format("{0:0.00}", grandTotal);
        }
    }
}
