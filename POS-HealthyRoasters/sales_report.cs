using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_HealthyRoasters
{
    public partial class sales_report : Form
    {
        Controller ctrl = new Controller();
        DBConnect db = new DBConnect();
        string fileName = "Overall Sales";

        static Color pastelGreenTemp = Color.FromArgb(0xD6F5D6);
        static Color greenTemp = Color.FromArgb(0x2EB82E);
        static Color grayTemp = Color.FromArgb(0xA2A2A3);
        static Color orangeTemp = Color.FromArgb(0xEA7D1C);
        static Color anotherGreenTemp = Color.FromArgb(0x75AE27);

        Color pastelGreen = Color.FromArgb(pastelGreenTemp.R, pastelGreenTemp.G, pastelGreenTemp.B);
        Color green = Color.FromArgb(greenTemp.R, greenTemp.G, greenTemp.B);
        Color gray = Color.FromArgb(grayTemp.R, grayTemp.G, grayTemp.B);
        Color orange = Color.FromArgb(orangeTemp.R, orangeTemp.G, orangeTemp.B);
        Color anotherGreen = Color.FromArgb(anotherGreenTemp.R, anotherGreenTemp.G, anotherGreenTemp.B);

        static int thickness = 2;
        int halfThickness = thickness / 2;

        public sales_report()
        {
            InitializeComponent();
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
        }

        private void sales_report_Load(object sender, EventArgs e)
        {
            flowLayoutPanel2.BackColor = pastelGreen;

            dgvSalesReport.BackgroundColor = gray;
            dgvSalesReport.GridColor = gray;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.BackColor = green;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSalesReport.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            dgvSalesReport.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvSalesReport.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvSalesReport.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            btnFilter.BackColor = green;
            btnFilter.ForeColor = Color.White;

            btnClearFilter.BackColor = orange;
            btnClearFilter.ForeColor = Color.White;

            btnExcel.BackColor = anotherGreen;
            btnExcel.ForeColor = Color.White;

            dgvSalesReport.DataSource = db.viewSales();
            loadSales();

            for (int i = DateTime.Now.Year; i >= 1940; i--)
            {
                cboYear.Items.Add(i);
            }
            foreach (string month in ctrl.dates)
            {
                cboMonth.Items.Add(month);
            }
        }

        // FlowLayoutPanel Paint Design
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(green, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness, halfThickness, flowLayoutPanel2.ClientSize.Width - thickness, flowLayoutPanel2.ClientSize.Height - thickness));
            }
        }

        // Buton Click
        private void btnFilter_Click(object sender, EventArgs e)
        {
            int month = 0;
            bool fltr = true;

            for (int i = 0; i < ctrl.dates.Length; i++)
            {
                if (ctrl.dates[i] == cboMonth.Text)
                {
                    month = i;
                }
            }

            if (cboDay.Text == " Day" && cboMonth.Text == " Mon" && cboYear.Text == " Year")
            {
                MessageBox.Show("Please choose a date to filter.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvSalesReport.DataSource = db.viewSales();
                lblSale.Text = db.getSales() + "";
            }
            else
            {
                if (cboDay.Text != " Day" && cboMonth.Text == " Mon")
                {
                    MessageBox.Show("Please choose a year and a month to filter with the day.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvSalesReport.DataSource = db.viewSales();
                    lblSale.Text = db.getSales() + "";
                }
                else if (cboDay.Text == " Day" && cboMonth.Text == " Mon" && cboYear.Text != " Year")
                {
                    dgvSalesReport.DataSource = db.viewSpecificSale(cboDay.Text, ctrl.months[month], cboYear.Text, "year");

                    if (db.getSpecificSalesCount(cboDay.Text, ctrl.months[month], cboYear.Text, "year") == 0)
                    {
                        lblSale.Text = "0.00";
                    }
                    else
                    {
                        lblSale.Text = db.getSpecificSales(cboDay.Text, ctrl.months[month], cboYear.Text, "year");
                    }

                    fileName = "Sales Report " + cboYear.Text;

                }
                else if (cboDay.Text == " Day" && cboMonth.Text != " Mon" && cboYear.Text != " Year")
                {
                    dgvSalesReport.DataSource = db.viewSpecificSale(cboDay.Text, ctrl.months[month], cboYear.Text, "year and month");

                    if (db.getSpecificSalesCount(cboDay.Text, ctrl.months[month], cboYear.Text, "year and month") == 0)
                    {
                        lblSale.Text = "0.00";
                    }
                    else
                    {
                        lblSale.Text = db.getSpecificSales(cboDay.Text, ctrl.months[month], cboYear.Text, "year and month");
                    }

                    fileName = "Sales Report for the month of " + ctrl.months[month] + ", " + cboYear.Text;

                }
                else if (cboDay.Text != " Day" && cboMonth.Text != " Mon" && cboYear.Text != " Year")
                {
                    dgvSalesReport.DataSource = db.viewSpecificSale(cboDay.Text, ctrl.months[month], cboYear.Text, "day, month, and year");

                    if (db.getSpecificSalesCount(cboDay.Text, ctrl.months[month], cboYear.Text, "day, month, and year") == 0)
                    {
                        lblSale.Text = "0.00";
                    }
                    else
                    {
                        lblSale.Text = db.getSpecificSales(cboDay.Text, ctrl.months[month], cboYear.Text, "day, month, and year");
                    }

                    fileName = "Daily Sales Report " + ctrl.months[month] + " " + cboDay.Text + ", " + cboYear.Text;
                }
                else
                {
                    MessageBox.Show("Please choose a year to filter with the month and day.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvSalesReport.DataSource = db.viewSales();
                    lblSale.Text = db.getSales() + "";
                    fltr = false;
                }
            }

            if (fltr == true)
            {
                filter();
            }
            fltr = true;

            if (dgvSalesReport.Rows.Count == 0)
            {
                MessageBox.Show("No records were found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The filter has been cleared.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cboDay.Text = " Day";
            cboMonth.Text = " Mon";
            cboYear.Text = " Year";
            fileName = "Overall Sales";
            dgvSalesReport.DataSource = db.viewSales();
            loadSales();
            filter();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvSalesReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to store in excel.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Excel excel = new Excel();
                excel.CreateNewFile("Sales");

                for (int i = 1; i <= dgvSalesReport.Columns.Count; i++)
                {
                    excel.WriteToCellHeader(i, dgvSalesReport.Columns[i - 1].HeaderText);
                }

                for (int i = 0; i < dgvSalesReport.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvSalesReport.Columns.Count; j++)
                    {
                        excel.WriteToCell(i, j, dgvSalesReport.Rows[i].Cells[j].Value.ToString());
                    }
                }

                MessageBox.Show("Record has been successfully saved in the Documents.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                excel.SaveAs(fileName);
                excel.Close();
            }
        }

        // KeyPress
        private void noType(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // DataGridView SelectionChanged
        private void dgvSalesReport_SelectionChanged(object sender, EventArgs e)
        {
            dgvSalesReport.ClearSelection();
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

        // Methods
        public void loadSales()
        {
            if (db.getSalesCount() == 0)
            {
                lblSale.Text = "0.00";
                btnFilter.Enabled = false;
            }
            else
            {
                lblSale.Text = db.getSales() + "";
                btnFilter.Enabled = true;
            }
        }

        public void filter()
        {
            lblYear.Text = "None";
            lblMonth.Text = "None";
            lblDay.Text = "None";

            if (cboYear.Text != " Year")
            {
                lblYear.Text = cboYear.Text;
            }
            if (cboMonth.Text != " Mon")
            {
                lblMonth.Text = cboMonth.Text;
            }
            if (cboDay.Text != " Day")
            {
                lblDay.Text = cboDay.Text;
            }
        }
    }
}
