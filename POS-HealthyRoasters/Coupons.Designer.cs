namespace POS_HealthyRoasters
{
    partial class Coupons
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
            this.dgvCoupon = new System.Windows.Forms.DataGridView();
            this.coupon_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coupon_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coupon_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtCouponID = new System.Windows.Forms.TextBox();
            this.txtCouponDesc = new System.Windows.Forms.TextBox();
            this.txtCouponPercent = new System.Windows.Forms.TextBox();
            this.btnEditCoupon = new System.Windows.Forms.Button();
            this.btnDeleteCoupon = new System.Windows.Forms.Button();
            this.btnCreateCoupon = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoupon)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCoupon
            // 
            this.dgvCoupon.AllowUserToAddRows = false;
            this.dgvCoupon.AllowUserToDeleteRows = false;
            this.dgvCoupon.AllowUserToResizeRows = false;
            this.dgvCoupon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCoupon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCoupon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCoupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoupon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coupon_ID,
            this.coupon_desc,
            this.coupon_percent});
            this.dgvCoupon.EnableHeadersVisualStyles = false;
            this.dgvCoupon.Location = new System.Drawing.Point(400, 71);
            this.dgvCoupon.Name = "dgvCoupon";
            this.dgvCoupon.ReadOnly = true;
            this.dgvCoupon.Size = new System.Drawing.Size(485, 377);
            this.dgvCoupon.TabIndex = 9;
            this.dgvCoupon.TabStop = false;
            this.dgvCoupon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoupon_CellClick);
            this.dgvCoupon.SelectionChanged += new System.EventHandler(this.dgvCoupon_SelectionChanged);
            // 
            // coupon_ID
            // 
            this.coupon_ID.DataPropertyName = "coupon_ID";
            this.coupon_ID.HeaderText = "Coupon ID";
            this.coupon_ID.Name = "coupon_ID";
            this.coupon_ID.ReadOnly = true;
            this.coupon_ID.Width = 107;
            // 
            // coupon_desc
            // 
            this.coupon_desc.DataPropertyName = "coupon_desc";
            this.coupon_desc.HeaderText = "Coupon Description";
            this.coupon_desc.Name = "coupon_desc";
            this.coupon_desc.ReadOnly = true;
            this.coupon_desc.Width = 167;
            // 
            // coupon_percent
            // 
            this.coupon_percent.DataPropertyName = "coupon_percent";
            this.coupon_percent.HeaderText = "Coupon Percentage";
            this.coupon_percent.Name = "coupon_percent";
            this.coupon_percent.ReadOnly = true;
            this.coupon_percent.Width = 170;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(122, 71);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.txtSearch.MaxLength = 10;
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 30);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TabStop = false;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // txtCouponID
            // 
            this.txtCouponID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCouponID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponID.Location = new System.Drawing.Point(190, 25);
            this.txtCouponID.Margin = new System.Windows.Forms.Padding(0, 15, 10, 3);
            this.txtCouponID.MaxLength = 10;
            this.txtCouponID.Multiline = true;
            this.txtCouponID.Name = "txtCouponID";
            this.txtCouponID.Size = new System.Drawing.Size(150, 27);
            this.txtCouponID.TabIndex = 2;
            this.txtCouponID.TabStop = false;
            this.txtCouponID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // txtCouponDesc
            // 
            this.txtCouponDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCouponDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponDesc.Location = new System.Drawing.Point(190, 70);
            this.txtCouponDesc.Margin = new System.Windows.Forms.Padding(0, 15, 10, 3);
            this.txtCouponDesc.MaxLength = 30;
            this.txtCouponDesc.Multiline = true;
            this.txtCouponDesc.Name = "txtCouponDesc";
            this.txtCouponDesc.Size = new System.Drawing.Size(150, 27);
            this.txtCouponDesc.TabIndex = 3;
            this.txtCouponDesc.TabStop = false;
            this.txtCouponDesc.TextChanged += new System.EventHandler(this.txtCouponDesc_TextChanged);
            this.txtCouponDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCouponDesc_KeyPress);
            // 
            // txtCouponPercent
            // 
            this.txtCouponPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCouponPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponPercent.Location = new System.Drawing.Point(190, 115);
            this.txtCouponPercent.Margin = new System.Windows.Forms.Padding(0, 15, 10, 3);
            this.txtCouponPercent.MaxLength = 3;
            this.txtCouponPercent.Multiline = true;
            this.txtCouponPercent.Name = "txtCouponPercent";
            this.txtCouponPercent.Size = new System.Drawing.Size(150, 27);
            this.txtCouponPercent.TabIndex = 4;
            this.txtCouponPercent.TabStop = false;
            this.txtCouponPercent.TextChanged += new System.EventHandler(this.txtCouponPercent_TextChanged);
            this.txtCouponPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCouponPercent_KeyPress);
            // 
            // btnEditCoupon
            // 
            this.btnEditCoupon.FlatAppearance.BorderSize = 0;
            this.btnEditCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCoupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCoupon.Location = new System.Drawing.Point(185, 175);
            this.btnEditCoupon.Margin = new System.Windows.Forms.Padding(0, 30, 10, 3);
            this.btnEditCoupon.Name = "btnEditCoupon";
            this.btnEditCoupon.Size = new System.Drawing.Size(155, 60);
            this.btnEditCoupon.TabIndex = 6;
            this.btnEditCoupon.TabStop = false;
            this.btnEditCoupon.Text = "Update Existing Coupon";
            this.btnEditCoupon.UseVisualStyleBackColor = true;
            this.btnEditCoupon.Click += new System.EventHandler(this.btnEditCoupon_Click);
            // 
            // btnDeleteCoupon
            // 
            this.btnDeleteCoupon.FlatAppearance.BorderSize = 0;
            this.btnDeleteCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCoupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCoupon.Location = new System.Drawing.Point(20, 248);
            this.btnDeleteCoupon.Margin = new System.Windows.Forms.Padding(0, 10, 10, 3);
            this.btnDeleteCoupon.Name = "btnDeleteCoupon";
            this.btnDeleteCoupon.Size = new System.Drawing.Size(155, 60);
            this.btnDeleteCoupon.TabIndex = 8;
            this.btnDeleteCoupon.TabStop = false;
            this.btnDeleteCoupon.Text = "Delete Existing Coupon";
            this.btnDeleteCoupon.UseVisualStyleBackColor = true;
            this.btnDeleteCoupon.Click += new System.EventHandler(this.btnDeleteCoupon_Click);
            // 
            // btnCreateCoupon
            // 
            this.btnCreateCoupon.FlatAppearance.BorderSize = 0;
            this.btnCreateCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCoupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCoupon.Location = new System.Drawing.Point(20, 175);
            this.btnCreateCoupon.Margin = new System.Windows.Forms.Padding(0, 30, 10, 3);
            this.btnCreateCoupon.Name = "btnCreateCoupon";
            this.btnCreateCoupon.Size = new System.Drawing.Size(155, 60);
            this.btnCreateCoupon.TabIndex = 5;
            this.btnCreateCoupon.TabStop = false;
            this.btnCreateCoupon.Text = "Create New Coupon";
            this.btnCreateCoupon.UseVisualStyleBackColor = true;
            this.btnCreateCoupon.Click += new System.EventHandler(this.btnCreateCoupon_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(185, 248);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0, 10, 10, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 60);
            this.btnClear.TabIndex = 7;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear Fields";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search ID:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtCouponID);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtCouponDesc);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtCouponPercent);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.btnEditCoupon);
            this.flowLayoutPanel1.Controls.Add(this.btnCreateCoupon);
            this.flowLayoutPanel1.Controls.Add(this.btnClear);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteCoupon);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 118);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 330);
            this.flowLayoutPanel1.TabIndex = 19;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 18, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Coupon ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 18, 10, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Coupon Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 18, 10, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Coupon Discount (%):";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(277, 71);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(766, 17);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close Tab";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Coupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 466);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvCoupon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Coupons";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coupons";
            this.Load += new System.EventHandler(this.Coupons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoupon)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCoupon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtCouponID;
        private System.Windows.Forms.TextBox txtCouponDesc;
        private System.Windows.Forms.TextBox txtCouponPercent;
        private System.Windows.Forms.Button btnEditCoupon;
        private System.Windows.Forms.Button btnDeleteCoupon;
        private System.Windows.Forms.Button btnCreateCoupon;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn coupon_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn coupon_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn coupon_percent;
    }
}