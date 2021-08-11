using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS_HealthyRoasters
{
    public partial class login : Form
    {
        DBConnect db = new DBConnect();

        static Color greenTemp = Color.FromArgb(0x2EB82E);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            btnLogin.BackColor = green;
            btnLogin.ForeColor = Color.White;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (db.checkLogin(txtUsername.Text, txtPassword.Text) == "user")
                {
                    if (db.recordActivity(db.checkSession(txtUsername.Text), DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                            "Logged in") == true)
                    {
                        register_pos frmCashier = new register_pos(txtUsername.Text);
                        frmCashier.Show();
                        this.Hide();
                    }
                }
                else if (db.checkLogin(txtUsername.Text, txtPassword.Text) == "admin")
                {
                    if (db.recordActivity(db.checkSession(txtUsername.Text), DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                            "Logged in") == true)
                    {
                        admin_pos frmAdmin = new admin_pos(txtUsername.Text);
                        frmAdmin.Show();
                        this.Hide();
                    }
                }
                else if (db.checkLogin(txtUsername.Text, txtPassword.Text) == "error")
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
            else
            {
                MessageBox.Show("Please fill the missing field/s.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                messageAction();
            }
        }

        public void messageAction()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}