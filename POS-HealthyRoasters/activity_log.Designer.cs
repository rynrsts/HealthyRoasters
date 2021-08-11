namespace POS_HealthyRoasters
{
    partial class activity_log
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvActivityLog = new System.Windows.Forms.DataGridView();
            this.activity_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activity_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.btnFilterDate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnSaveDocument = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvActivityLog
            // 
            this.dgvActivityLog.AllowUserToAddRows = false;
            this.dgvActivityLog.AllowUserToDeleteRows = false;
            this.dgvActivityLog.AllowUserToResizeRows = false;
            this.dgvActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActivityLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActivityLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvActivityLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.activity_id,
            this.username,
            this.activity_description,
            this.date,
            this.time});
            this.dgvActivityLog.EnableHeadersVisualStyles = false;
            this.dgvActivityLog.Location = new System.Drawing.Point(58, 109);
            this.dgvActivityLog.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dgvActivityLog.Name = "dgvActivityLog";
            this.dgvActivityLog.ReadOnly = true;
            this.dgvActivityLog.Size = new System.Drawing.Size(1200, 405);
            this.dgvActivityLog.TabIndex = 8;
            this.dgvActivityLog.SelectionChanged += new System.EventHandler(this.dgvActivityLog_SelectionChanged);
            // 
            // activity_id
            // 
            this.activity_id.DataPropertyName = "activity_id";
            this.activity_id.HeaderText = "Activity ID";
            this.activity_id.Name = "activity_id";
            this.activity_id.ReadOnly = true;
            this.activity_id.Width = 130;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 260;
            // 
            // activity_description
            // 
            this.activity_description.DataPropertyName = "activity_description";
            this.activity_description.HeaderText = "Activity Description";
            this.activity_description.Name = "activity_description";
            this.activity_description.ReadOnly = true;
            this.activity_description.Width = 420;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 160;
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 172;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(328, 55);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(155, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search Username";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(119, 55);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.txtSearch.MaxLength = 30;
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 35);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(25, 3, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Search ID:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.cboYear);
            this.flowLayoutPanel1.Controls.Add(this.cboMonth);
            this.flowLayoutPanel1.Controls.Add(this.cboDay);
            this.flowLayoutPanel1.Controls.Add(this.btnFilterDate);
            this.flowLayoutPanel1.Controls.Add(this.btnClear);
            this.flowLayoutPanel1.Controls.Add(this.dgvActivityLog);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveDocument);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(55, 55, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1313, 615);
            this.flowLayoutPanel1.TabIndex = 37;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "Search:";
            // 
            // cboYear
            // 
            this.cboYear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(533, 59);
            this.cboYear.Margin = new System.Windows.Forms.Padding(50, 4, 3, 3);
            this.cboYear.MaxLength = 4;
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(80, 26);
            this.cboYear.TabIndex = 2;
            this.cboYear.TabStop = false;
            this.cboYear.Text = " Year";
            this.cboYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noType);
            // 
            // cboMonth
            // 
            this.cboMonth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(618, 59);
            this.cboMonth.Margin = new System.Windows.Forms.Padding(2, 4, 3, 3);
            this.cboMonth.MaxLength = 3;
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(80, 26);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.TabStop = false;
            this.cboMonth.Text = " Mon";
            this.cboMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noType);
            // 
            // cboDay
            // 
            this.cboDay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Location = new System.Drawing.Point(703, 59);
            this.cboDay.Margin = new System.Windows.Forms.Padding(2, 4, 3, 3);
            this.cboDay.MaxLength = 2;
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(80, 26);
            this.cboDay.TabIndex = 4;
            this.cboDay.TabStop = false;
            this.cboDay.Text = " Day";
            this.cboDay.DropDown += new System.EventHandler(this.cboDay_DropDown);
            this.cboDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noType);
            // 
            // btnFilterDate
            // 
            this.btnFilterDate.FlatAppearance.BorderSize = 0;
            this.btnFilterDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterDate.Location = new System.Drawing.Point(789, 55);
            this.btnFilterDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnFilterDate.Name = "btnFilterDate";
            this.btnFilterDate.Size = new System.Drawing.Size(155, 35);
            this.btnFilterDate.TabIndex = 5;
            this.btnFilterDate.TabStop = false;
            this.btnFilterDate.Text = "Search Date";
            this.btnFilterDate.UseVisualStyleBackColor = true;
            this.btnFilterDate.Click += new System.EventHandler(this.btnFilterDate_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1037, 55);
            this.btnClear.Margin = new System.Windows.Forms.Padding(90, 0, 0, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear Search Filter";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblFilter);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(55, 527);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 10, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(600, 40);
            this.flowLayoutPanel2.TabIndex = 49;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(0, 10);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 18);
            this.lblFilter.TabIndex = 48;
            this.lblFilter.Text = "Filter:";
            // 
            // btnSaveDocument
            // 
            this.btnSaveDocument.FlatAppearance.BorderSize = 0;
            this.btnSaveDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDocument.Location = new System.Drawing.Point(1103, 527);
            this.btnSaveDocument.Margin = new System.Windows.Forms.Padding(445, 10, 3, 3);
            this.btnSaveDocument.Name = "btnSaveDocument";
            this.btnSaveDocument.Size = new System.Drawing.Size(155, 35);
            this.btnSaveDocument.TabIndex = 7;
            this.btnSaveDocument.TabStop = false;
            this.btnSaveDocument.Text = "Save as Excel";
            this.btnSaveDocument.UseVisualStyleBackColor = true;
            this.btnSaveDocument.Click += new System.EventHandler(this.btnSaveDocument_Click);
            // 
            // activity_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1316, 615);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(16, 72);
            this.Name = "activity_log";
            this.Padding = new System.Windows.Forms.Padding(100);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "activity_log";
            this.Load += new System.EventHandler(this.activity_log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLog)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActivityLog;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn activity_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn activity_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboDay;
        private System.Windows.Forms.Button btnFilterDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveDocument;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}