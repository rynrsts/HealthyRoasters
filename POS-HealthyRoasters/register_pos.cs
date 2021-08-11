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
    public partial class register_pos : Form
    {
        DBConnect db = new DBConnect();
        Controller ctrl = new Controller();
        Timer t = new Timer();

        private double indivPrice;
        private string session;
        private double grandTotalPrice = 0;
        private string grandPrice = "";
        private string discount = "";

        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color pastelGreenTemp = Color.FromArgb(0xD6F5D6);
        static Color lightOrangeTemp = Color.FromArgb(0xF0BD61);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);
        static Color pastelYellowTemp = Color.FromArgb(0xFEFBCD);
        static Color yellowTemp = Color.FromArgb(0xE1D205);
        static Color anotherGreenTemp = Color.FromArgb(0x75AE27);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        static Color redTemp = Color.FromArgb(0xE10A16);

        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color pastelGreen = Color.FromArgb(pastelGreenTemp.R, pastelGreenTemp.G, pastelGreenTemp.B);
        Color lightOrange = Color.FromArgb(lightOrangeTemp.R, lightOrangeTemp.G, lightOrangeTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);
        Color pastelYellow = Color.FromArgb(pastelYellowTemp.R, pastelYellowTemp.G, pastelYellowTemp.B);
        Color yellow = Color.FromArgb(yellowTemp.R, yellowTemp.G, yellowTemp.B);
        Color anotherGreen = Color.FromArgb(anotherGreenTemp.R, anotherGreenTemp.G, anotherGreenTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);
        Color red = Color.FromArgb(redTemp.R, redTemp.G, redTemp.B);

        static int thickness = 2;
        int halfThickness = thickness / 2;

        public register_pos(string username)
        {
            InitializeComponent();
            session = username;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSalad.FlatAppearance.BorderColor = green;
            btnDrinks.FlatAppearance.BorderColor = green;

            flSalad.BackColor = pastelGreen;
            flDrinks.BackColor = pastelGreen;

            btnLogout.BackColor = gray;
            btnLogout.ForeColor = Color.White;

            dgvList.BackgroundColor = gray;
            dgvList.GridColor = gray;
            dgvList.ColumnHeadersDefaultCellStyle.BackColor = green;
            dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvList.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            dgvList.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvList.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvList.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            flowLayoutPanel4.BackColor = pastelYellow;
            txtDesc.BackColor = pastelYellow;
            txtPrice.BackColor = pastelYellow;
            txtTotalPrice.BackColor = pastelYellow;

            btnTender.BackColor = anotherGreen;
            btnCancel.BackColor = orange;
            btnTender.ForeColor = Color.White;
            btnCancel.ForeColor = Color.White;

            flowLayoutPanel7.BackColor = pastelYellow;
            txtGrandTotal.BackColor = pastelYellow;
            txtChange.BackColor = pastelYellow;

            btnPayout.BackColor = green;
            btnDiscount.BackColor = yellow;
            btnVoid.BackColor = red;
            btnPayout.ForeColor = Color.White;
            btnVoid.ForeColor = Color.White;

            ctrl.setPercentage();
            txtGrandTotal.Text = String.Format("{0:0.00}", grandTotalPrice);
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

            if (db.checkSession(session) == "fail")
            {
                MessageBox.Show("Please login to continue.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                login log = new login();
                log.Show();
                this.Close();
            }
            else
            {
                lblUsername.Text = session;
            }

            ctrl.addSalad();
            ctrl.addDrinks();

            for (int i = 0; i < ctrl.getSalad().Count; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = ctrl.getSalad()[i].ToString();
                btn.Size = new Size(175, 110);
                btn.Font = new Font("Microsoft Sans Serif", 11);
                btn.BackColor = lightOrange;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.TabStop = false;

                if (db.checkStock(btn.Text) == true)
                {
                    btn.Enabled = false;
                }

                flSalad.Controls.Add(btn);
                btn.Click += new EventHandler(button_Click);
            }
            for (int i = 0; i < ctrl.getDrinks().Count; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = ctrl.getDrinks()[i].ToString();
                btn.Size = new Size(175, 110);
                btn.Font = new Font("Microsoft Sans Serif", 11);
                btn.BackColor = lightOrange;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.TabStop = false;

                if (db.checkStock(btn.Text) == true)
                {
                    btn.Enabled = false;
                }

                flDrinks.Controls.Add(btn);
                btn.Click += new EventHandler(button_Click);
            }
        }

        private void register_pos_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult message = MessageBox.Show("You are logging out. Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (message == DialogResult.Yes)
            {
                if (db.recordActivity(lblUsername.Text, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Logged out") == true)
                {
                    if (db.endSession(lblUsername.Text) == true)
                    {
                        login log = new login();
                        log.Show();
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        // FlowLayoutPanel Paint Design
        private void flSalad_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(green, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flSalad.ClientSize.Width - thickness, flSalad.ClientSize.Height - thickness));
            }
        }

        private void flDrinks_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(green, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flDrinks.ClientSize.Width - thickness, flDrinks.ClientSize.Height - thickness));
            }
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(yellow, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel4.ClientSize.Width - thickness, flowLayoutPanel4.ClientSize.Height - thickness));
            }
        }

        private void flowLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(yellow, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel7.ClientSize.Width - thickness, flowLayoutPanel7.ClientSize.Height - thickness));
            }
        }

        // Tick Time
        private void t_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy \t hh:mm:ss tt");
        }

        // Button Click
        private void btnSalad_Click(object sender, EventArgs e)
        {
            btnSalad.BackColor = green;
            btnDrinks.BackColor = Color.White;
            
            flSalad.Visible = true;
            flDrinks.Visible = false;

            btnSalad.Enabled = false;
            btnDrinks.Enabled = true;
        }

        private void btnDrinks_Click(object sender, EventArgs e)
        {
            btnDrinks.BackColor = green;
            btnSalad.BackColor = Color.White;

            flDrinks.Visible = true;
            flSalad.Visible = false;

            btnDrinks.Enabled = false;
            btnSalad.Enabled = true;
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            txtDesc.Text = button.Text;
            indivPrice = determinePrice(txtDesc.Text, button.Name);
            txtPrice.Text = String.Format("{0:0.00}", indivPrice);

            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                txtQuantity.Clear();
            }
            enableOrderFunc();
        }

        private void btnTender_Click(object sender, EventArgs e)
        {
            int totalRows, quantity;
            double totalPrice;
            int totalQuantity = 0;
            double totalTotalPrice = 0;

            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                totalRows = Convert.ToInt32(dgvList.Rows.Count.ToString());
                quantity = Convert.ToInt32(txtQuantity.Text);
                totalPrice = Convert.ToDouble(txtTotalPrice.Text);

                if (totalRows == 0)
                {
                    dgvList.Rows.Add(txtDesc.Text, txtPrice.Text, quantity, totalPrice);
                    grandTotalPrice += totalPrice;
                }
                else
                {
                    for (int i = 0; i < totalRows; i++)
                    {
                        if (dgvList.Rows[i].Cells[0].Value.ToString() == txtDesc.Text)
                        {
                            totalQuantity += Convert.ToInt32(dgvList.Rows[i].Cells[2].Value.ToString());
                            totalTotalPrice += Convert.ToInt32(dgvList.Rows[i].Cells[3].Value.ToString());
                            dgvList.Rows[i].Cells[2].Value = totalQuantity += quantity;
                            dgvList.Rows[i].Cells[3].Value = totalTotalPrice += totalPrice;
                            grandTotalPrice += totalPrice;
                            break;
                        }
                        else if (i == totalRows - 1 && dgvList.Rows[i].Cells[0].Value.ToString() != txtDesc.Text)
                        {
                            dgvList.Rows.Add(txtDesc.Text, txtPrice.Text, quantity, totalPrice);
                            grandTotalPrice += totalPrice;
                            break;
                        }
                    }
                }

                txtGrandTotal.Text = String.Format("{0:0.00}", grandTotalPrice);
                grandPrice = txtGrandTotal.Text;

                if (!string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    txtChange.Text = String.Format("{0:0.00}", (Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtGrandTotal.Text))) + "";
                }
                
                enableOrderOutFunc();
                resetControl();
            }
            else
            {
                MessageBox.Show("Please enter the item quantity.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetControl();
        }

        private void btnPayout_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                double change = Convert.ToDouble(txtChange.Text);

                if (change < 0)
                {
                    MessageBox.Show("Insufficient balance!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (db.recordSales(txtGrandTotal.Text) == true)
                    {
                        double vatPercent = Convert.ToDouble(ctrl.getVAT()) / 100;
                        double priceVat = Convert.ToDouble(txtGrandTotal.Text) * vatPercent;
                        double priceWOVAT = Convert.ToDouble(txtGrandTotal.Text) - priceVat;
                        string orderlist = "";
                        string[,] dValue = new string[dgvList.Rows.Count, dgvList.Columns.Count];

                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            foreach(DataGridViewColumn col in dgvList.Columns)
                            {
                                dValue[row.Index, col.Index] = dgvList.Rows[row.Index].Cells[col.Index].Value.ToString();
                            }
                        }

                        int i = 1;
                        string container = "";

                        foreach (string ss in dValue)
                        {
                            container += ss;

                            if (i == 1)
                            {
                                int j = 1;

                                while (ss.Length + j <= 22)
                                {
                                    container += " ";
                                    j++;
                                }
                            }
                            else if (i == 2)
                            {
                                int j = 1;

                                while (ss.Length + j <= 8)
                                {
                                    container += " ";
                                    j++;
                                }
                            }
                            else if (i == 3)
                            {
                                int j = 1;

                                while (ss.Length + j <= 4)
                                {
                                    container += " ";
                                    j++;
                                }
                            }

                            if (i == 4)
                            {
                                orderlist += container + "\n";
                                container = "";
                                i = 0;
                            }

                            i++;
                        }

                        string a = "           Healthy Roasters           " +
                            "\n\n\n" + lblDate.Text + "\n" + lblUsername.Text +
                            "\n\n" + orderlist +
                            "\nSubtotal:                  Php " + String.Format("{0:#,0.00}", Convert.ToDouble(grandPrice)) + discount +
                            "\nGrand Total Price:         Php " + String.Format("{0:#,0.00}", Convert.ToDouble(txtGrandTotal.Text)) +
                            "\nPayment:                   Php " + String.Format("{0:#,0.00}", Convert.ToDouble(txtAmount.Text)) +
                            "\nChange:                    Php " + String.Format("{0:#,0.00}", change) +
                            "\nVAT Amount:                Php " + String.Format("{0:#,0.00}", priceVat) +
                            "\nVAT Sale:                  Php " + String.Format("{0:#,0.00}", priceWOVAT);

                        Receipt rc = new Receipt(a);
                        rc.ShowDialog(this);

                        if (rc.DialogResult == DialogResult.OK)
                        {
                            rc.Dispose();
                        }
                    }

                    if (db.recordActivity(lblUsername.Text, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Sold an order") == true)
                    {
                        resetAllControl();
                    }

                    grandPrice = "";
                }
            }
            else
            {
                MessageBox.Show("Please enter an amount to payout.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            pos_frmDiscount fd = new pos_frmDiscount(session, txtGrandTotal.Text);
            fd.ShowDialog(this);

            if (fd.DialogResult == DialogResult.OK)
            {
                txtGrandTotal.Text = fd.getGrandTotal();
                discount = fd.getDiscountInfo();

                if (!string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    txtChange.Text = String.Format("{0:0.00}", (Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtGrandTotal.Text))) + "";
                }

                btnDiscount.Enabled = false;
                txtAmount.Focus();                
                fd.Dispose();
            }
            else if (fd.DialogResult == DialogResult.Cancel)
            {
                fd.Dispose();
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            void_Validation vv = new void_Validation(lblUsername.Text);
            vv.ShowDialog(this);

            if (vv.DialogResult == DialogResult.OK)
            {
                resetAllControl();
                vv.Dispose();
            }
            else if (vv.DialogResult == DialogResult.Cancel)
            {
                vv.Dispose();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("You are logging out. Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (message == DialogResult.Yes)
            {
                if (db.recordActivity(lblUsername.Text, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Logged out") == true)
                {
                    if (db.endSession(session) == true)
                    {
                        login log = new login();
                        log.Show();
                        this.Hide();
                    }
                }
            }
        }  

        // TextBox KeyPress
        private void numOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
        // Textbox TextChanged
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.StartsWith("0"))
            {
                txtQuantity.Text = txtQuantity.Text.Substring(1);
            }

            if (!string.IsNullOrWhiteSpace(txtQuantity.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                txtTotalPrice.Text = ctrl.computePrice(indivPrice.ToString(), txtQuantity.Text);
            }
            else
            {
                txtTotalPrice.Clear();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text.StartsWith("0"))
            {
                txtAmount.Text = txtAmount.Text.Substring(1);
            }

            if (!string.IsNullOrWhiteSpace(txtAmount.Text) && !string.IsNullOrWhiteSpace(txtGrandTotal.Text))
            {
                txtChange.Text = ctrl.computeChange(txtGrandTotal.Text, txtAmount.Text);
            }
            else
            {
                txtChange.Clear();
            }
        }

        // DataGridView SelectionChanged
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dgvList.ClearSelection();
        }
                      
        // Methods
        public double determinePrice(string name, string i)
        {
            double price = 0;

            if (ctrl.getSalad().Count >= ctrl.getDrinks().Count)
            {
                price = conditionSalad(name, i);
            }
            else if (ctrl.getSalad().Count <= ctrl.getDrinks().Count)
            {
                price = conditionDrinks(name, i);
            }
            return price;
        }

        public double conditionSalad(string name, string i)
        {
            double price = 0;

            if (name == ctrl.getSalad()[Convert.ToInt32(i)].ToString())
            {
                price = getSaladPrice(Convert.ToInt32(i), price);
            }
            else if (name == ctrl.getDrinks()[Convert.ToInt32(i)].ToString())
            {
                price = getDrinksPrice(Convert.ToInt32(i), price);
            }
            return price;
        }

        public double conditionDrinks(string name, string i)
        {
            double price = 0;

            if (name == ctrl.getDrinks()[Convert.ToInt32(i)].ToString())
            {
                price = getDrinksPrice(Convert.ToInt32(i), price);
            }
            else if (name == ctrl.getSalad()[Convert.ToInt32(i)].ToString())
            {
                price = getSaladPrice(Convert.ToInt32(i), price);
            }
            return price;
        }

        public double getSaladPrice(int i, double price)
        {
            price = Convert.ToDouble(ctrl.getSaladPrice()[i]);
            return price;
        }

        public double getDrinksPrice(int i, double price)
        {
            price = Convert.ToDouble(ctrl.getDrinksPrice()[i]);
            return price;
        }

        public void enableOrderFunc()
        {
            txtQuantity.Enabled = true;
            btnTender.Enabled = true;
            btnCancel.Enabled = true;
            txtQuantity.Focus();
        }

        public void enableOrderOutFunc()
        {
            txtAmount.Enabled = true;
            btnPayout.Enabled = true;
            btnDiscount.Enabled = true;
            btnVoid.Enabled = true;
        }

        public void resetControl()
        {
            btnSalad.Enabled = true;
            btnDrinks.Enabled = true;
            btnSalad.BackColor = Color.White;
            btnDrinks.BackColor = Color.White;

            flSalad.Visible = false;
            flDrinks.Visible = false;

            txtDesc.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtTotalPrice.Clear();

            txtQuantity.Enabled = false;
            btnTender.Enabled = false;
            btnCancel.Enabled = false;
        }

        public void resetAllControl()
        {
            resetControl();

            dgvList.Rows.Clear();

            grandTotalPrice = 0;
            txtGrandTotal.Text = String.Format("{0:0.00}", grandTotalPrice);

            txtAmount.Clear();
            txtChange.Clear();

            txtAmount.Enabled = false;
            btnPayout.Enabled = false;
            btnDiscount.Enabled = false;
            btnVoid.Enabled = false;
        }
    }
}
