using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_HealthyRoasters
{
    public partial class pos_CouponDiscount : Form
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

        public pos_CouponDiscount(string totalPrice, string username)
        {
            InitializeComponent();
            this.totalPrice = totalPrice;
            session = username;
        }          

        private void pos_CouponDiscount_Load(object sender, EventArgs e)
        {
            btnCouponDiscount.BackColor = green;
            btnCancel.BackColor = orange;
            btnCouponDiscount.ForeColor = Color.White;
            btnCancel.ForeColor = Color.White;
        }

        private void btnCouponDiscount_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(txtCouponID.Text)))
            {
                double price = Convert.ToDouble(totalPrice);
                double discountPercent = 0;

                if (db.validateCoupon(txtCouponID.Text) == true) {
                    db.connection.Open();
                    MySqlDataReader cursor = db.getCouponDiscount(txtCouponID.Text).ExecuteReader();

                    while (cursor.Read())
                    {
                       discountPercent = Convert.ToDouble(cursor[0].ToString()) / 100;
                    }

                    discountPrice = price * discountPercent;
                    grandTotal = price - discountPrice;
                    db.connection.Close();

                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                        "Discounted using Coupon with " + discountPercent * 100 + " % discount") == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect coupon code.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCouponID.Focus();
                }
            }  
            else
            {
                MessageBox.Show("Please enter a coupon code.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCouponID.Focus();
            }
        }

        private void txtCouponID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        public string getGrandTotal()
        {
            return String.Format("{0:0.00}", grandTotal);
        }

        public string getDiscountInfo()
        {
            return "\nCoupon discount Amount:    Php " + String.Format("{0:#,0.00}", discountPrice);
        }
    }
}
