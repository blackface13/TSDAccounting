namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmB03BNG
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
            this.dateTimeRanger = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupboxMain.Controls.Add(this.dateTimeRanger);
            this.groupboxMain.Location = new System.Drawing.Point(8, 8);
            this.groupboxMain.Size = new System.Drawing.Size(301, 95);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(154, 109);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(234, 109);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHelp.Location = new System.Drawing.Point(-1, 109);
            // 
            // dateTimeRanger
            // 
            this.dateTimeRanger.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRanger.Appearance.Options.UseBackColor = true;
            this.dateTimeRanger.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRanger.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRanger.FromDateLabelText = "Từ ngày";
            this.dateTimeRanger.InitSelectedIndex = 0;
            this.dateTimeRanger.Location = new System.Drawing.Point(4, -4);
            this.dateTimeRanger.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRanger.Name = "dateTimeRanger";
            this.dateTimeRanger.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRanger.Size = new System.Drawing.Size(296, 80);
            this.dateTimeRanger.TabIndex = 9;
            this.dateTimeRanger.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRanger.ToDateLabelText = "Đến ngày";
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(65, 68);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(208, 19);
            this.chkMoveTotalInNewPage.TabIndex = 15;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // FrmB03BNG
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(315, 139);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmB03BNG";
            this.Text = "Báo cáo tạm ứng";
            this.Load += new System.EventHandler(this.FrmB03BNG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRanger;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;

    }
}