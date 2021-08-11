namespace POS_HealthyRoasters
{
    partial class pos_frmDiscount
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
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSC = new System.Windows.Forms.Button();
            this.btnPWD = new System.Windows.Forms.Button();
            this.btnCoupon = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel6.Controls.Add(this.label1);
            this.flowLayoutPanel6.Controls.Add(this.btnSC);
            this.flowLayoutPanel6.Controls.Add(this.btnPWD);
            this.flowLayoutPanel6.Controls.Add(this.btnCoupon);
            this.flowLayoutPanel6.Controls.Add(this.btnManager);
            this.flowLayoutPanel6.Controls.Add(this.btnClose);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(25, 25);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(373, 217);
            this.flowLayoutPanel6.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(141, 5, 140, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Discount";
            // 
            // btnSC
            // 
            this.btnSC.BackColor = System.Drawing.Color.Transparent;
            this.btnSC.FlatAppearance.BorderSize = 0;
            this.btnSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSC.Location = new System.Drawing.Point(8, 43);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(175, 50);
            this.btnSC.TabIndex = 0;
            this.btnSC.TabStop = false;
            this.btnSC.Text = "Senior Citizen";
            this.btnSC.UseVisualStyleBackColor = false;
            this.btnSC.Click += new System.EventHandler(this.openDiscountUI);
            // 
            // btnPWD
            // 
            this.btnPWD.BackColor = System.Drawing.Color.Transparent;
            this.btnPWD.FlatAppearance.BorderSize = 0;
            this.btnPWD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWD.Location = new System.Drawing.Point(189, 43);
            this.btnPWD.Name = "btnPWD";
            this.btnPWD.Size = new System.Drawing.Size(175, 50);
            this.btnPWD.TabIndex = 1;
            this.btnPWD.TabStop = false;
            this.btnPWD.Text = "PWD";
            this.btnPWD.UseVisualStyleBackColor = false;
            this.btnPWD.Click += new System.EventHandler(this.openDiscountUI);
            // 
            // btnCoupon
            // 
            this.btnCoupon.BackColor = System.Drawing.Color.Transparent;
            this.btnCoupon.FlatAppearance.BorderSize = 0;
            this.btnCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoupon.Location = new System.Drawing.Point(8, 99);
            this.btnCoupon.Name = "btnCoupon";
            this.btnCoupon.Size = new System.Drawing.Size(175, 50);
            this.btnCoupon.TabIndex = 2;
            this.btnCoupon.TabStop = false;
            this.btnCoupon.Text = "Coupon";
            this.btnCoupon.UseVisualStyleBackColor = false;
            this.btnCoupon.Click += new System.EventHandler(this.btnCoupon_Click);
            // 
            // btnManager
            // 
            this.btnManager.BackColor = System.Drawing.Color.Transparent;
            this.btnManager.FlatAppearance.BorderSize = 0;
            this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.Location = new System.Drawing.Point(189, 99);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(175, 50);
            this.btnManager.TabIndex = 3;
            this.btnManager.TabStop = false;
            this.btnManager.Text = "Manager\'s";
            this.btnManager.UseVisualStyleBackColor = false;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(244, 167);
            this.btnClose.Margin = new System.Windows.Forms.Padding(239, 15, 3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pos_frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 270);
            this.Controls.Add(this.flowLayoutPanel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_frmDiscount";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_frmDIscount";
            this.Load += new System.EventHandler(this.pos_frmDiscount_Load);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.Button btnPWD;
        private System.Windows.Forms.Button btnCoupon;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}