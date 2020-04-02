namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraShowVoucherForSalary
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
            this.btnGiayBaoNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnPhieuChi = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnGiayBaoNo
            // 
            this.btnGiayBaoNo.Location = new System.Drawing.Point(8, 9);
            this.btnGiayBaoNo.Name = "btnGiayBaoNo";
            this.btnGiayBaoNo.Size = new System.Drawing.Size(176, 23);
            this.btnGiayBaoNo.TabIndex = 0;
            this.btnGiayBaoNo.Text = "Giấy báo nợ";
            this.btnGiayBaoNo.Click += new System.EventHandler(this.btnGiayBaoNo_Click);
            // 
            // btnPhieuChi
            // 
            this.btnPhieuChi.Location = new System.Drawing.Point(192, 9);
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.Size = new System.Drawing.Size(160, 23);
            this.btnPhieuChi.TabIndex = 1;
            this.btnPhieuChi.Text = "Phiếu chi";
            this.btnPhieuChi.Click += new System.EventHandler(this.btnPhieuChi_Click);
            // 
            // FrmXtraShowVoucherForSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 35);
            this.Controls.Add(this.btnPhieuChi);
            this.Controls.Add(this.btnGiayBaoNo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXtraShowVoucherForSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn chứng từ";
            this.Load += new System.EventHandler(this.FrmXtraShowVoucherForSalary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGiayBaoNo;
        private DevExpress.XtraEditors.SimpleButton btnPhieuChi;

    }
}