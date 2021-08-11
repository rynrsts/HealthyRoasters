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
    public partial class view_products : Form
    {
        DBConnect db = new DBConnect();
        Controller ctrl = new Controller();
        DataGridViewRow selectRow;
        static string session;

        static Color anotherGreenTemp = Color.FromArgb(0x75AE27);
        static Color pastelGreenTemp = Color.FromArgb(0xD6F5D6);
        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color yellowTemp = Color.FromArgb(0xE1D205);
        static Color redTemp = Color.FromArgb(0xE10A16);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        static Color pastelYellowTemp = Color.FromArgb(0xFEFBCD);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);

        Color anotherGreen = Color.FromArgb(anotherGreenTemp.R, anotherGreenTemp.G, anotherGreenTemp.B);
        Color pastelGreen = Color.FromArgb(pastelGreenTemp.R, pastelGreenTemp.G, pastelGreenTemp.B);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color yellow = Color.FromArgb(yellowTemp.R, yellowTemp.G, yellowTemp.B);
        Color red = Color.FromArgb(redTemp.R, redTemp.G, redTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);
        Color pastelYellow = Color.FromArgb(pastelYellowTemp.R, pastelYellowTemp.G, pastelYellowTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);

        static int thickness = 2;
        int halfThickness = thickness / 2;

        public view_products(string username)
        {
            InitializeComponent();
            session = username;
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
        }

        private void view_products_Load(object sender, EventArgs e)
        {
            btnSearch.BackColor = anotherGreen;
            btnSearch.ForeColor = Color.White;

            flowLayoutPanel1.BackColor = pastelGreen;

            btnCreateProduct.BackColor = green;
            btnEditProduct.BackColor = yellow;
            btnDeleteProduct.BackColor = red;
            btnClear.BackColor = orange;
            btnCreateProduct.ForeColor = Color.White;
            btnDeleteProduct.ForeColor = Color.White;
            btnClear.ForeColor = Color.White;

            flowLayoutPanel6.BackColor = pastelYellow;
            
            btnCoupon.BackColor = yellow;
            btnPercentage.BackColor = green;
            btnClearPercentage.BackColor = orange;
            btnPercentage.ForeColor = Color.White;
            btnClearPercentage.ForeColor = Color.White;

            dgvProductList.BackgroundColor = gray;
            dgvProductList.GridColor = gray;
            dgvProductList.ColumnHeadersDefaultCellStyle.BackColor = green;
            dgvProductList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductList.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            dgvProductList.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvProductList.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvProductList.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            getPercentage();
            dgvProductList.DataSource = db.viewProducts();
        }

        // FlowLayoutPanel Paint Design
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(green, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel1.ClientSize.Width - thickness, flowLayoutPanel1.ClientSize.Height - thickness));
            }
        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(yellow, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel6.ClientSize.Width - thickness, flowLayoutPanel6.ClientSize.Height - thickness));
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
                for (int i = 0; i < db.getProductCount(); i++)
                {
                    selectRow = dgvProductList.Rows[i];

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

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            if (txtProductID.Enabled == false)
            {
                MessageBox.Show("You selected an existing item. Please click the Clear Info Fields first, then create a new one.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((string.IsNullOrWhiteSpace(txtProductID.Text)) || (string.IsNullOrWhiteSpace(txtProductName.Text)) || (string.IsNullOrWhiteSpace(txtProductPrice.Text)) ||
                    (cboItemType.Text == "Choose one") || (cboStatus.Text == "Choose one"))
                {
                    MessageBox.Show("Please fill the missing field/s to create product.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textFocus();
                }
                else
                {
                    StringBuilder strProdID = new StringBuilder("");

                    if (cboItemType.Text == "drinks")
                    {
                        strProdID.Append("D" + txtProductID.Text);
                    }
                    else if (cboItemType.Text == "salad")
                    {
                        strProdID.Append("S" + txtProductID.Text);
                    }

                    if (db.checkProduct(strProdID.ToString(), txtProductName.Text) == true)
                    {
                        MessageBox.Show("Product ID or Product Name is already existing.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtProductID.Clear();
                        txtProductName.Clear();
                        txtProductID.Focus();
                    }
                    else
                    {
                        if (db.createProduct(strProdID.ToString(), txtProductName.Text, productPrice(), cboItemType.Text, cboStatus.Text) == true)
                        {
                            if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                            "Created " + txtProductName.Text + " product item") == true)
                            {
                                MessageBox.Show("New product has been successfully added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvProductList.DataSource = db.viewProducts();
                                clear();
                            }
                        }
                    }
                }
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (txtProductID.Enabled == true)
            {
                MessageBox.Show("Nothing to update. Please select a row in the table.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((string.IsNullOrWhiteSpace(txtProductID.Text)) || (string.IsNullOrWhiteSpace(txtProductName.Text)) || (string.IsNullOrWhiteSpace(txtProductPrice.Text)) ||
                    (cboItemType.Text == "Choose one") || (cboStatus.Text == "Choose one"))
                {
                    MessageBox.Show("Please fill the missing information.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textFocus();
                }
                else
                {
                    if (db.editProduct(txtProductID.Text, txtProductName.Text, productPrice(), cboItemType.Text, cboStatus.Text) == true)
                    {
                        if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                                "Information of " + txtProductName.Text + " has been modified") == true)
                        {
                            MessageBox.Show("Product's information have been successfully modified.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvProductList.DataSource = db.viewProducts();
                            clear();
                        }
                    }
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (txtProductID.Enabled == true)
            {
                MessageBox.Show("Nothing to delete. Please select a row in the table.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (db.deleteProduct(txtProductID.Text) == true)
                {
                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Deleted " + txtProductName.Text + " product item") == true)
                    {
                        DialogResult message = MessageBox.Show("This action cannot be undo. Are you sure you want to delete the product?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (message == DialogResult.Yes)
                        {
                            MessageBox.Show("Product has been successfully deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvProductList.DataSource = db.viewProducts();
                            clear();
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fields have been cleared.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
        }

        private void btnCoupon_Click(object sender, EventArgs e)
        {
            Coupons c = new Coupons(session);
            c.ShowDialog(this);

            if (c.DialogResult == DialogResult.OK)
            {
                c.Dispose();
            }
        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtSC.Text)) || (string.IsNullOrWhiteSpace(txtPWD.Text)) || (string.IsNullOrWhiteSpace(txtVAT.Text)))
            {
                MessageBox.Show("Please fill the missing field/s.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(txtSC.Text))
                {
                    txtSC.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtPWD.Text))
                {
                    txtPWD.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtVAT.Text))
                {
                    txtVAT.Focus();
                }
            }
            else
            {
                if (db.setPercentage(txtSC.Text, txtPWD.Text, txtVAT.Text) == true)
                {
                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Optimized discount and tax percentage") == true)
                    {
                        MessageBox.Show("Percentages have been successfully set.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getPercentage();
                    }
                }
            }
        }

        private void btnClearPercentage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Percentages have been reset back to previous declaration.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getPercentage();
        }

        // KeyPress
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) & !char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = txtProductPrice.Text;

            if (!char.IsNumber(e.KeyChar) & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back | (text.Contains('.') & e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void noType(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back | (txtSC.Text.Length > 1 & char.IsNumber(e.KeyChar) & !(txtSC.Text + e.KeyChar).Equals("100")))
            {
                e.Handled = true;
            }
        }

        private void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back | (txtPWD.Text.Length > 1 & char.IsNumber(e.KeyChar) & !(txtPWD.Text + e.KeyChar).Equals("100")))
            {
                e.Handled = true;
            }
        }

        private void txtVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back | (txtVAT.Text.Length > 1 & char.IsNumber(e.KeyChar) & !(txtVAT.Text + e.KeyChar).Equals("100")))
            {
                e.Handled = true;
            }
        }

        // TextBox TextChanged
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text.StartsWith(" "))
            {
                txtProductName.Text = txtProductName.Text.Substring(1);
            }
        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtProductPrice.Text.StartsWith("0") | txtProductPrice.Text.StartsWith("."))
            {
                txtProductPrice.Text = txtProductPrice.Text.Substring(1);
            }
        }

        private void txtSC_TextChanged(object sender, EventArgs e)
        {
            if (txtSC.Text.StartsWith("0"))
            {
                txtSC.Text = txtSC.Text.Substring(1);
            }
        }

        private void txtPWD_TextChanged(object sender, EventArgs e)
        {
            if (txtPWD.Text.StartsWith("0"))
            {
                txtPWD.Text = txtPWD.Text.Substring(1);
            }
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            if (txtVAT.Text.StartsWith("0"))
            {
                txtVAT.Text = txtVAT.Text.Substring(1);
            }
        }

        // DataGridView CellClick
        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0)
            {
                selectRow = dgvProductList.Rows[index];
                infoView();
            }
        }

        // DataGridView SelectionChanged
        private void dgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            dgvProductList.ClearSelection();
        }

        // Methods
        public void getPercentage()
        {
            ctrl.setPercentage();
            txtSC.Text = ctrl.getSC();
            txtPWD.Text = ctrl.getPWD();
            txtVAT.Text = ctrl.getVAT();
        }

        public void infoView()
        {
            txtProductID.Text = selectRow.Cells[0].Value.ToString();
            txtProductName.Text = selectRow.Cells[1].Value.ToString();
            txtProductPrice.Text = selectRow.Cells[2].Value.ToString();
            cboItemType.Text = selectRow.Cells[3].Value.ToString();
            cboStatus.Text = selectRow.Cells[4].Value.ToString();
            txtProductID.Enabled = false;
        }

        public void textFocus()
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                txtProductID.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                txtProductName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                txtProductPrice.Focus();
            }
            else if (cboItemType.Text == "Choose one")
            {
                cboItemType.Focus();
            }
            else if (cboStatus.Text == "Choose one")
            {
                cboStatus.Focus();
            }
        }

        public string productPrice()
        {
            double price = Convert.ToDouble(txtProductPrice.Text);
            return String.Format("{0:#,0.00}", price);
        }

        public void clear()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            cboItemType.Text = "Choose one";
            cboStatus.Text = "Choose one";
            txtProductID.Enabled = true;
        }
    }
}
