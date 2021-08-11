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
    public partial class activity_log : Form
    {
        DBConnect db = new DBConnect();
        Controller ctrl = new Controller();
        string fileName = "Overall Activity Log";

        static Color pastelGreenTemp = Color.FromArgb(0xD6F5D6);
        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color anotherGreenTemp = Color.FromArgb(0x75AE27);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);

        Color pastelGreen = Color.FromArgb(pastelGreenTemp.R, pastelGreenTemp.G, pastelGreenTemp.B);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color anotherGreen = Color.FromArgb(anotherGreenTemp.R, anotherGreenTemp.G, anotherGreenTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);

        static int thickness = 2;
        int halfThickness = thickness / 2;

        public activity_log()
        {
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
        }

        private void activity_log_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = pastelGreen;

            btnSearch.BackColor = anotherGreen;
            btnSearch.ForeColor = Color.White;

            btnFilterDate.BackColor = anotherGreen;
            btnFilterDate.ForeColor = Color.White;

            btnClear.BackColor = orange;
            btnClear.ForeColor = Color.White;

            btnSaveDocument.BackColor = green;
            btnSaveDocument.ForeColor = Color.White;

            dgvActivityLog.BackgroundColor = gray;
            dgvActivityLog.GridColor = gray;
            dgvActivityLog.ColumnHeadersDefaultCellStyle.BackColor = green;
            dgvActivityLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvActivityLog.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            dgvActivityLog.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvActivityLog.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvActivityLog.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            dgvActivityLog.DataSource = db.viewActivity();
            dgvActivityLog.DefaultCellStyle.SelectionBackColor = dgvActivityLog.DefaultCellStyle.BackColor;
            dgvActivityLog.DefaultCellStyle.SelectionForeColor = dgvActivityLog.DefaultCellStyle.ForeColor;

            dgvActivityLog.DataSource = db.viewActivity();

            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                cboYear.Items.Add(i);
            }
            foreach (string month in ctrl.dates)
            {
                cboMonth.Items.Add(month);
            }
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
            int month = 0;

            for (int i = 0; i < ctrl.dates.Length; i++)
            {
                if (ctrl.dates[i] == cboMonth.Text)
                {
                    month = i + 1;
                }
            }

            string date = cboDay.Text + "/" + month + "/" + cboYear.Text;

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Nothing to search.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                if ((cboDay.Text == " Day") || (cboMonth.Text == " Mon") || (cboYear.Text == " Year"))
                {
                    fileName = txtSearch.Text + "'s Overall Activity Log";
                    dgvActivityLog.DataSource = db.searchUserActivity(txtSearch.Text);
                    lblFilter.Text = "Filter:    " + txtSearch.Text;
                    checkActivity();
                }
                else
                {
                    fileName = txtSearch.Text + "'s Activity Log " + cboMonth.Text + " " + cboDay.Text + ", " + cboYear.Text;
                    dgvActivityLog.DataSource = db.viewUserActivity(txtSearch.Text, Convert.ToDateTime(date).ToString("MM/dd/yyyy"));
                    lblFilter.Text = "Filter:    " + txtSearch.Text + " - " + cboMonth.Text + " " + cboDay.Text + ", " + cboYear.Text;
                    checkActivity();
                }
            }
        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            int month = 0;

            for (int i = 0; i < ctrl.dates.Length; i++)
            {
                if (ctrl.dates[i] == cboMonth.Text)
                {
                    month = i + 1;
                }
            }

            string date = cboDay.Text + "/" + month + "/" + cboYear.Text;

            if ((cboDay.Text == " Day") || (cboMonth.Text == " Mon") || (cboYear.Text == " Year"))
            {
                MessageBox.Show("Please choose a date to filter.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    fileName = "Activity Log " + cboMonth.Text + " " + cboDay.Text + ", " + cboYear.Text;
                    dgvActivityLog.DataSource = db.viewDateLog(Convert.ToDateTime(date).ToString("MM/dd/yyyy"));
                    lblFilter.Text = "Filter:    " + cboMonth.Text + " " + cboDay.Text + ", " + cboYear.Text;
                    checkActivity();
                }
                else
                {
                    fileName = txtSearch.Text + "'s Activity Log " + cboMonth.Text + " " + cboDay.Text + ", " + cboYear.Text;
                    dgvActivityLog.DataSource = db.viewUserActivity(txtSearch.Text, Convert.ToDateTime(date).ToString("MM/dd/yyyy"));
                    lblFilter.Text = "Filter:    " + txtSearch.Text + " - " + cboMonth.Text + " " + cboDay.Text + ", " + cboYear.Text;
                    checkActivity();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The filter has been cleared.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSearch.Clear();
            cboDay.Text = " Day";
            cboMonth.Text = " Mon";
            cboYear.Text = " Year";
            fileName = "Overall Activity Log";
            dgvActivityLog.DataSource = db.viewActivity();
            lblFilter.Text = "Filter:";
        }

        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            if (dgvActivityLog.Rows.Count == 0)
            {
                MessageBox.Show("No data to store in excel.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Excel excel = new Excel();
                excel.CreateNewFile("Activity_Log");

                for (int i = 1; i <= dgvActivityLog.Columns.Count; i++)
                {
                    excel.WriteToCellHeader(i, dgvActivityLog.Columns[i - 1].HeaderText);
                }

                for (int i = 0; i < dgvActivityLog.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvActivityLog.Columns.Count; j++)
                    {
                        excel.WriteToCell(i, j, dgvActivityLog.Rows[i].Cells[j].Value.ToString());
                    }
                }

                MessageBox.Show("Record has been successfully saved in the Documents.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                excel.SaveAs(fileName);
                excel.Close();
            }
        }

        // TextBox KeyPress
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        // ComboBox KeyPress
        private void noType(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
                for (int i = 31; i >= 1; i--)
                {
                    cboDay.Items.Add(i);
                }
            }
        }

        // DataGridView SelectionChanged
        private void dgvActivityLog_SelectionChanged(object sender, EventArgs e)
        {
            dgvActivityLog.ClearSelection();
        }

        // Methods
        public void checkActivity()
        {
            if (dgvActivityLog.Rows.Count == 0)
            {
                fileName = "Overall Activity Log";
                MessageBox.Show("No records were found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
