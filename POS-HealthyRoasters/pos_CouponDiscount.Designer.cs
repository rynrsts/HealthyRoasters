namespace POS_HealthyRoasters
{
    partial class pos_CouponDiscount
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
            this.txtCouponID = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCouponDiscount = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCouponID
            // 
            this.txtCouponID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCouponID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCouponID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponID.Location = new System.Drawing.Point(126, 26);
            this.txtCouponID.Margin = new System.Windows.Forms.Padding(19, 6, 0, 3);
            this.txtCouponID.MaxLength = 10;
            this.txtCouponID.Multiline = true;
            this.txtCouponID.Name = "txtCouponID";
            this.txtCouponID.Size = new System.Drawing.Size(200, 28);
            this.txtCouponID.TabIndex = 0;
            this.txtCouponID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCouponID_KeyPress);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.lblID);
            this.flowLayoutPanel2.Controls.Add(this.txtCouponID);
            this.flowLayoutPanel2.Controls.Add(this.btnCouponDiscount);
            this.flowLayoutPanel2.Controls.Add(this.btnCancel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 28);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(355, 154);
            this.flowLayoutPanel2.TabIndex = 31;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(24, 29);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 9, 0, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(83, 18);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "Coupon ID:";
            // 
            // btnCouponDiscount
            // 
            this.btnCouponDiscount.FlatAppearance.BorderSize = 0;
            this.btnCouponDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCouponDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCouponDiscount.Location = new System.Drawing.Point(28, 82);
            this.btnCouponDiscount.Margin = new System.Windows.Forms.Padding(8, 25, 0, 0);
            this.btnCouponDiscount.Name = "btnCouponDiscount";
            this.btnCouponDiscount.Size = new System.Drawing.Size(140, 45);
            this.btnCouponDiscount.TabIndex = 1;
            this.btnCouponDiscount.TabStop = false;
            this.btnCouponDiscount.Text = "Apply Discount";
            this.btnCouponDiscount.UseVisualStyleBackColor = true;
            this.btnCouponDiscount.Click += new System.EventHandler(this.btnCouponDiscount_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(186, 82);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(18, 25, 0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pos_CouponDiscount
            // 
            this.AcceptButton = this.btnCouponDiscount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(379, 210);
            this.Controls.Add(this.flowLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_CouponDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_CouponDiscount";
            this.Load += new System.EventHandler(this.pos_CouponDiscount_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCouponID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnCouponDiscount;
        private System.Windows.Forms.Button btnCancel;
    }
}