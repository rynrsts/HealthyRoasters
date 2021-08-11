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
    public partial class admin_pos : Form
    {
        Controller ctrl = new Controller();
        DBConnect db = new DBConnect();
        Timer t = new Timer();
        string session;

        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);

        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);

        public admin_pos(string username)
        {
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(panel.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            session = username;
        }

        private void admin_pos_Load(object sender, EventArgs e)
        {
            btnLogout.BackColor = gray;
            btnLogout.ForeColor = Color.White;

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
                lblUsername.Text = db.checkSession(session);
            }

            for (int i = 0; i < ctrl.adminBtn.Length; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = ctrl.adminBtn[i].ToString();
                btn.Size = new Size(200, 54);
                btn.Font = new Font("Microsoft Sans Serif", 11);
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = green;
                btn.TabStop = false;
                flBtnAdmin.Controls.Add(btn);
                btn.Click += new EventHandler(button_Click);
            }
        }

        private void admin_pos_FormClosing(object sender, FormClosingEventArgs e)
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
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            for (int i = 0; i < ctrl.adminBtn.Length; i++)
            {
                openChild(button.Text);
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

        private void t_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy \t hh:mm:ss tt");
        }

        private void openChild(string type)
        {
            view_products viewProduct = new view_products(lblUsername.Text) { Dock = DockStyle.Fill, TopLevel = false };
            view_employee viewEmp = new view_employee(lblUsername.Text) { Dock = DockStyle.Fill, TopLevel = false };
            sales_report sales = new sales_report() { Dock = DockStyle.Fill, TopLevel = false };
            activity_log actLog = new activity_log() { Dock = DockStyle.Fill, TopLevel = false };
            panel.Controls.Clear();

            if (type == "Products")
            {
                this.panel.Controls.Add(viewProduct);
                viewProduct.Show();
            }
            else if (type == "Employees")
            {
                this.panel.Controls.Add(viewEmp);
                viewEmp.Show();
            }
            else if (type == "Sales Report")
            {
                this.panel.Controls.Add(sales);
                sales.Show();
            }
            else if (type == "Activity Log")
            {
                this.panel.Controls.Add(actLog);
                actLog.Show();
            }
        }
    }
}
