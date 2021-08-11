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
    public partial class view_employee : Form
    {
        DBConnect db = new DBConnect();
        Controller ctrl = new Controller();
        DataGridViewRow selectRow;
        static string session;
        int index;

        static Color anotherGreenTemp = Color.FromArgb(0x75AE27);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);
        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color yellowTemp = Color.FromArgb(0xE1D205);
        static Color redTemp = Color.FromArgb(0xE10A16);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        static Color pastelGreenTemp = Color.FromArgb(0xD6F5D6);

        Color anotherGreen = Color.FromArgb(anotherGreenTemp.R, anotherGreenTemp.G, anotherGreenTemp.B);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);
        Color yellow = Color.FromArgb(yellowTemp.R, yellowTemp.G, yellowTemp.B);
        Color red = Color.FromArgb(redTemp.R, redTemp.G, redTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);
        Color pastelGreen = Color.FromArgb(pastelGreenTemp.R, pastelGreenTemp.G, pastelGreenTemp.B);

        static int thickness = 2;
        int halfThickness = thickness / 2;

        public view_employee(string username)
        {
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            session = username;
        }

        private void view_employee_Load(object sender, EventArgs e)
        {
            btnSearch.BackColor = anotherGreen;
            btnSearch.ForeColor = Color.White;

            dgvEmployees.BackgroundColor = gray;
            dgvEmployees.GridColor = gray;
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = green;
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvEmployees.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvEmployees.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            btnRegEmployee.BackColor = green;
            btnUpdateEmploy.BackColor = yellow;
            btnDeleteEmploy.BackColor = red;
            btnClear.BackColor = orange;

            btnRegEmployee.ForeColor = Color.White;
            btnDeleteEmploy.ForeColor = Color.White;
            btnClear.ForeColor = Color.White;

            flowLayoutPanel4.BackColor = pastelGreen;

            dgvEmployees.DataSource = db.viewEmployees();

            for (int i = DateTime.Now.Year; i >= 1940; i--)
            {
                cboYear.Items.Add(i);
            }
            foreach (string month in ctrl.dates)
            {
                cboMonth.Items.Add(month);
            }

            //dgvEmployees.DefaultCellStyle.SelectionBackColor = dgvEmployees.DefaultCellStyle.BackColor;
            //dgvEmployees.DefaultCellStyle.SelectionForeColor = dgvEmployees.DefaultCellStyle.ForeColor;
            //disableFields();
        }

        // FlowLayoutPanel Paint Design
        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(green, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel4.ClientSize.Width - thickness, flowLayoutPanel4.ClientSize.Height - thickness));
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
                for (int i = 0; i < db.getCount(); i++)
                {
                    selectRow = dgvEmployees.Rows[i];

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

        private void btnRegEmployee_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("You selected an existing item. Please click the Clear Info Fields first, then create a new one.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ((string.IsNullOrWhiteSpace(txtFirstname.Text)) || (string.IsNullOrWhiteSpace(txtMiddlename.Text)) || (string.IsNullOrWhiteSpace(txtLastname.Text)) ||
                    (string.IsNullOrWhiteSpace(txtAddress.Text)) || (string.IsNullOrWhiteSpace(txtTelephone.Text)) || (string.IsNullOrWhiteSpace(txtMobile.Text)) ||
                    (string.IsNullOrWhiteSpace(txtEmail.Text)) || (cboMonth.Text == "Mon") || (cboDay.Text == "Day") || (cboYear.Text == "Year") ||
                    (string.IsNullOrWhiteSpace(txtUsername.Text)) || (string.IsNullOrWhiteSpace(txtPassword.Text)) || (cboGender.Text == ""))
                {
                    MessageBox.Show("Please fill the missing field/s to create product.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textFocus();
                }
                else
                {
                    if (db.checkUsername(txtUsername.Text) == "existed")
                    {
                        MessageBox.Show("Username is already existing.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Clear();
                        txtUsername.Focus();
                    }
                    else if (db.checkUsername(txtUsername.Text) == "error")
                    {
                        MessageBox.Show("No connection! Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (db.checkEmail(txtEmail.Text) == "existed")
                    {
                        MessageBox.Show("Email is already existing.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Clear();
                        txtEmail.Focus();
                    }
                    else
                    {
                        int month = 0;

                        for (int i = 0; i < ctrl.dates.Length; i++)
                        {
                            if (ctrl.dates[i] == cboMonth.Text)
                            {
                                month = i + 1;
                            }
                        }

                        string birthday = cboDay.Text + "/" + month + "/" + cboYear.Text;

                        if (db.registerEmployee(txtUsername.Text, txtPassword.Text, cboUserType.Text, txtFirstname.Text, txtMiddlename.Text, txtLastname.Text, cboGender.Text,
                            txtMobile.Text, txtTelephone.Text, txtEmail.Text, txtAddress.Text, Convert.ToDateTime(birthday).ToString("dd/MM/yyyy")) == true)
                        {
                            if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                                "Registered " + txtFirstname.Text + " " + txtLastname.Text + " to the system.") == true)
                            {
                                MessageBox.Show("New personnel has been successfully registered.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvEmployees.DataSource = db.viewEmployees();
                                clearFields();
                            }
                        }
                    }
                }
            }
        }

        private void btnUpdateEmploy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Nothing to update. Please select a row in the table.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int month = 0;

                for (int i = 0; i < ctrl.dates.Length; i++)
                {
                    if (ctrl.dates[i] == cboMonth.Text)
                    {
                        month = i + 1;
                    }
                }

                string birthday = cboDay.Text + "/" + month + "/" + cboYear.Text;

                if ((string.IsNullOrWhiteSpace(txtFirstname.Text)) || (string.IsNullOrWhiteSpace(txtMiddlename.Text)) || (string.IsNullOrWhiteSpace(txtLastname.Text)) ||
                    (string.IsNullOrWhiteSpace(txtAddress.Text)) || (string.IsNullOrWhiteSpace(txtTelephone.Text)) || (string.IsNullOrWhiteSpace(txtMobile.Text)) ||
                    (string.IsNullOrWhiteSpace(txtEmail.Text)) || (cboMonth.Text == "Mon") || (cboDay.Text == "Day") || (cboYear.Text == "Year") ||
                    (string.IsNullOrWhiteSpace(txtUsername.Text)) || (string.IsNullOrWhiteSpace(txtPassword.Text)) || (cboGender.Text == ""))
                {
                    MessageBox.Show("Please fill the missing information.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //infoView();
                    textFocus();
                }
                else
                {
                    if (db.editEmployee(txtUserID.Text, txtUsername.Text, txtPassword.Text, cboUserType.Text, txtFirstname.Text, txtMiddlename.Text, txtLastname.Text,
                        cboGender.Text, txtMobile.Text, txtTelephone.Text, txtEmail.Text, txtAddress.Text, Convert.ToDateTime(birthday).ToString("dd/MM/yyyy")) == true)
                    {
                        if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                                "Information of " + txtFirstname.Text + " " + txtLastname.Text + " has been modified") == true)
                        {
                            MessageBox.Show("Personnel's information have been successfully modified.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvEmployees.DataSource = db.viewEmployees();
                            clearFields();
                        }
                    }
                }
            }
        }

        private void btnDeleteEmploy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Nothing to delete. Please select a row in the table.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (db.deleteEmployee(txtUserID.Text) == true)
                {
                    if (db.recordActivity(session, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"),
                       "Deleted " + txtFirstname.Text + " " + txtLastname.Text + " from the system") == true)
                    {
                        DialogResult message = MessageBox.Show("This action cannot be undo. Are you sure you want to delete the product?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (message == DialogResult.Yes)
                        {
                            MessageBox.Show("Personnel's account has been successfully deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvEmployees.DataSource = db.viewEmployees();
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

        // KeyPress
        private void numOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void lettersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) & !char.IsWhiteSpace(e.KeyChar) & e.KeyChar != (char)Keys.Back | (Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void noEnter(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void noType(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // TextBox TextChanged
        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstname.Text.StartsWith(" "))
            {
                txtFirstname.Text = txtFirstname.Text.Substring(1);
            }
        }

        private void txtMiddlename_TextChanged(object sender, EventArgs e)
        {
            if (txtMiddlename.Text.StartsWith(" "))
            {
                txtMiddlename.Text = txtMiddlename.Text.Substring(1);
            }
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            if (txtLastname.Text.StartsWith(" "))
            {
                txtLastname.Text = txtLastname.Text.Substring(1);
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text.StartsWith(" "))
            {
                txtAddress.Text = txtAddress.Text.Substring(1);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.StartsWith(" "))
            {
                txtEmail.Text = txtEmail.Text.Substring(1);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.StartsWith(" "))
            {
                txtUsername.Text = txtUsername.Text.Substring(1);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.StartsWith(" "))
            {
                txtPassword.Text = txtPassword.Text.Substring(1);
            }
        }

        // DataGridView CellClick
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            if (index >= 0)
            {
                selectRow = dgvEmployees.Rows[index];
                infoView();
            }
        }

        // DataGridView SelectionChanged
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            dgvEmployees.ClearSelection();
        }

        // ComboBox DropDown
        private void cboDay_DropDown(object sender, EventArgs e)
        {
            cboDay.Items.Clear();

            if (cboMonth.Text == "Feb")
            {
                if (DateTime.Now.Year % 4 == 0)
                {
                    for (int i = 29; i >= 1; i--)
                    {
                        cboDay.Items.Add(i);
                    }
                }
                else
                {
                    for (int i = 28; i >= 1; i--)
                    {
                        cboDay.Items.Add(i);
                    }
                }
            }
            else
            {
                defaultDay();
            }
        }

        //Methods
        public void infoView()
        {
            container.Text = Convert.ToDateTime(selectRow.Cells[12].Value).ToString("MM");
            int month = Convert.ToInt32(container.Text);
            cboYear.Text = Convert.ToDateTime(selectRow.Cells[12].Value).ToString("yyyy");
            cboMonth.Text = ctrl.dates[month - 1];
            cboDay.Text = Convert.ToDateTime(selectRow.Cells[12].Value).ToString("dd");
            txtUserID.Text = selectRow.Cells[0].Value.ToString();
            txtUsername.Text = selectRow.Cells[1].Value.ToString();
            txtPassword.Text = selectRow.Cells[2].Value.ToString();
            cboUserType.Text = selectRow.Cells[3].Value.ToString();
            txtFirstname.Text = selectRow.Cells[4].Value.ToString();
            txtMiddlename.Text = selectRow.Cells[5].Value.ToString();
            txtLastname.Text = selectRow.Cells[6].Value.ToString();
            cboGender.Text = selectRow.Cells[7].Value.ToString();
            txtMobile.Text = selectRow.Cells[8].Value.ToString();
            txtTelephone.Text = selectRow.Cells[9].Value.ToString();
            txtEmail.Text = selectRow.Cells[10].Value.ToString();
            txtAddress.Text = selectRow.Cells[11].Value.ToString();
        }

        public void textFocus()
        {
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                txtFirstname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtMiddlename.Text))
            {
                txtMiddlename.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                txtLastname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                txtTelephone.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                txtMobile.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Focus();
            }
            else if (cboMonth.Text == "Mon")
            {
                cboMonth.Focus();
            }
            else if (cboDay.Text == "Day")
            {
                cboDay.Focus();
            }
            else if (cboYear.Text == "Year")
            {
                cboYear.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Focus();
            }
            else if (cboGender.Text == "")
            {
                cboGender.Focus();
            }
        }

        public void clearFields()
        {
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            cboMonth.Text = "Mon";
            cboDay.Text = "Day";
            cboYear.Text = "Year";
            txtUserID.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cboUserType.Text = "user";
            cboGender.Text = "";
            //disableFields();
        }

        private void defaultDay()
        {
            for (int i = 31; i >= 1; i--)
            {
                cboDay.Items.Add(i);
            }
        }
    }
}
