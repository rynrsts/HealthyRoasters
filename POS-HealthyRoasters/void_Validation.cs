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
    public partial class void_Validation : Form
    {
        DBConnect db = new DBConnect();
        Controller ctrl = new Controller();
        private string session;

        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        static Color redTemp = Color.FromArgb(0xE10A16);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);
        Color red = Color.FromArgb(redTemp.R, redTemp.G, redTemp.B);

        public void_Validation(string username)
        {
            InitializeComponent();
            session = username;
        }

        private void void_Validation_Load(object sender, EventArgs e)
        {
            btnVoid.BackColor = red;
            btnCancel.BackColor = orange;
            btnVoid.ForeColor = Color.White;
            btnCancel.ForeColor = Color.White;
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtUsername.Text)) || (string.IsNullOrWhiteSpace(txtPassword.Text)))
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
                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"), "Order voided, validated by: " + txtUsername.Text) == true)
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

        public void messageAction()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
