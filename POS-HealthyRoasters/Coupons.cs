using MySqlX.XDevAPI;
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
    public partial class Coupons : Form
    {
        DataGridViewRow selectRow;
        DBConnect db = new DBConnect();
        Controller ctrl = new Controller();
        string session = "";

        static Color anotherGreenTemp = Color.FromArgb(0x75AE27);
        static Color pastelGreenTemp = Color.FromArgb(0xD6F5D6);
        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color yellowTemp = Color.FromArgb(0xE1D205);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        static Color redTemp = Color.FromArgb(0xE10A16);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);

        Color anotherGreen = Color.FromArgb(anotherGreenTemp.R, anotherGreenTemp.G, anotherGreenTemp.B);
        Color pastelGreen = Color.FromArgb(pastelGreenTemp.R, pastelGreenTemp.G, pastelGreenTemp.B);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color yellow = Color.FromArgb(yellowTemp.R, yellowTemp.G, yellowTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);
        Color red = Color.FromArgb(redTemp.R, redTemp.G, redTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);

        static int thickness = 2;
        int halfThickness = thickness / 2;

        public Coupons(string username)
        {
            InitializeComponent();
            session = username;
        }

        private void Coupons_Load(object sender, EventArgs e)
        {
            btnSearch.BackColor = anotherGreen;
            btnSearch.ForeColor = Color.White;

            flowLayoutPanel1.BackColor = pastelGreen;

            btnCreateCoupon.BackColor = green;
            btnEditCoupon.BackColor = yellow;
            btnClear.BackColor = orange;
            btnDeleteCoupon.BackColor = red;
            btnCreateCoupon.ForeColor = Color.White;
            btnClear.ForeColor = Color.White;
            btnDeleteCoupon.ForeColor = Color.White;

            btnClose.BackColor = red;
            btnClose.ForeColor = Color.White;

            dgvCoupon.BackgroundColor = gray;
            dgvCoupon.GridColor = gray;
            dgvCoupon.ColumnHeadersDefaultCellStyle.BackColor = green;
            dgvCoupon.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCoupon.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            dgvCoupon.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvCoupon.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            dgvCoupon.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            dgvCoupon.DataSource = db.viewCoupons();
        }

        // FlowLayoutPanel Paint Design
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(green, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel1.ClientSize.Width - thickness, flowLayoutPanel1.ClientSize.Height - thickness));
            }
        }

        // Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool message = false;

            if ((string.IsNullOrWhiteSpace(txtSearch.Text)))
            {
                MessageBox.Show("Nothing to search. Please input the id.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                for (int i = 0; i < db.getCouponCount(); i++)
                {
                    selectRow = dgvCoupon.Rows[i];

                    if (txtSearch.Text == selectRow.Cells[0].Value.ToString())
                    {
                        infoView();
                        message = false;
                        break;
                    }
                    else
                    {
                        message = true;
                    }
                }
                if (message == true)
                {
                    MessageBox.Show("No data found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearch.Focus();
                }

                txtSearch.Clear();
            }
        }

        private void btnCreateCoupon_Click(object sender, EventArgs e)
        {
            if (txtCouponID.Enabled == false)
            {
                MessageBox.Show("You selected an existing coupon. Please click the Clear Fields first, then create a new one.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((string.IsNullOrWhiteSpace(txtCouponID.Text)) || (string.IsNullOrWhiteSpace(txtCouponDesc.Text)) || (string.IsNullOrWhiteSpace(txtCouponPercent.Text)))
                {
                    MessageBox.Show("Please fill the missing field/s to create coupon.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textFocus();
                }
                else
                {
                    if (txtCouponID.Text[0] == ' ' || txtCouponDesc.Text[0] == ' ')
                    {
                        MessageBox.Show("Coupon Description should not start with whitespace/s", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCouponDesc.Clear();
                        txtCouponDesc.Focus();
                    }
                    else
                    {
                        if (db.checkCoupon(txtCouponID.Text, txtCouponDesc.Text) == true)
                        {
                            MessageBox.Show("Coupon ID or Coupon Description is already existing.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCouponID.Clear();
                            txtCouponDesc.Clear();
                            txtCouponID.Focus();
                        }
                        else
                        {
                            if (db.createCoupon(txtCouponID.Text, txtCouponDesc.Text, txtCouponPercent.Text) == true)
                            {
                                if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Created a new discount coupon") == true)
                                {
                                    MessageBox.Show("New coupon has been successfully added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvCoupon.DataSource = db.viewCoupons();
                                    clearFields();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnEditCoupon_Click(object sender, EventArgs e)
        {
            if (txtCouponID.Enabled == true)
            {
                MessageBox.Show("Nothing to update. Please select a row in the table.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((string.IsNullOrWhiteSpace(txtCouponID.Text)) || (string.IsNullOrWhiteSpace(txtCouponDesc.Text)) || (string.IsNullOrWhiteSpace(txtCouponPercent.Text)))
                {
                    MessageBox.Show("Please fill the missing information.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textFocus();
                }
                else
                {
                    if (db.editCoupon(txtCouponID.Text, txtCouponDesc.Text, txtCouponPercent.Text) == true)
                    {
                        if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "The information of coupon has been modified") == true)
                        {
                            MessageBox.Show("Coupon's information have been successfully modified.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCoupon.DataSource = db.viewCoupons();
                            clearFields();
                        }
                    }
                }
            }
        }

        private void btnDeleteCoupon_Click(object sender, EventArgs e)
        {
            if (txtCouponID.Enabled == true)
            {
                MessageBox.Show("Nothing to delete. Please select a row in the table.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (db.deleteCoupon(txtCouponID.Text) == true)
                {
                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Deleted a coupon") == true)
                    {
                        DialogResult message = MessageBox.Show("This action cannot be undo. Are you sure you want to delete the coupon?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (message == DialogResult.Yes)
                        {
                            MessageBox.Show("Coupon has been successfully deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCoupon.DataSource = db.viewCoupons();
                            clearFields();
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fields have been cleared.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearFields();
        }

        // TextBox KeyPress
        private void numOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCouponDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void txtCouponPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back |
                (txtCouponPercent.Text.Length > 1 & char.IsNumber(e.KeyChar) & !(txtCouponPercent.Text + e.KeyChar).Equals("100")))
            {
                e.Handled = true;
            }
        }

        // TextBox TextChanged
        private void txtCouponDesc_TextChanged(object sender, EventArgs e)
        {
            if (txtCouponDesc.Text.StartsWith(" "))
            {
                txtCouponDesc.Text = txtCouponDesc.Text.Substring(1);
            }
        }

        private void txtCouponPercent_TextChanged(object sender, EventArgs e)
        {
            if (txtCouponPercent.Text.StartsWith("0"))
            {
                txtCouponPercent.Text = txtCouponPercent.Text.Substring(1);
            }
        }

        // DataGridView CellClick
        private void dgvCoupon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0)
            {
                selectRow = dgvCoupon.Rows[index];
                infoView();
            }
        }

        // DataGridView SelectionChanged
        private void dgvCoupon_SelectionChanged(object sender, EventArgs e)
        {
            dgvCoupon.ClearSelection();
        }

        // Methods
        public void infoView()
        {
            txtCouponID.Text = selectRow.Cells[0].Value.ToString();
            txtCouponDesc.Text = selectRow.Cells[1].Value.ToString();
            txtCouponPercent.Text = selectRow.Cells[2].Value.ToString();
            txtCouponID.Enabled = false;
        }

        public void textFocus()
        {
            if (string.IsNullOrWhiteSpace(txtCouponID.Text))
            {
                txtCouponID.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtCouponDesc.Text))
            {
                txtCouponDesc.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtCouponPercent.Text))
            {
                txtCouponPercent.Focus();
            }
        }

        public void clearFields()
        {
            txtCouponID.Clear();
            txtCouponDesc.Clear();
            txtCouponPercent.Clear();
            txtCouponID.Enabled = true;
        }
    }
}
