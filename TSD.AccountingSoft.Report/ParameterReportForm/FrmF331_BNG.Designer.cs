namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmF331BNG
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
            this.dateTimeRange = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboAccount = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupboxMain.Controls.Add(this.cboAccount);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.dateTimeRange);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Size = new System.Drawing.Size(309, 156);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(160, 173);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(241, 173);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 173);
            // 
            // dateTimeRange
            // 
            this.dateTimeRange.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRange.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRange.FromDateLabelText = "Từ ngày";
            this.dateTimeRange.InitSelectedIndex = 0;
            this.dateTimeRange.Location = new System.Drawing.Point(1, 3);
            this.dateTimeRange.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRange.Name = "dateTimeRange";
            this.dateTimeRange.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRange.Size = new System.Drawing.Size(304, 70);
            this.dateTimeRange.TabIndex = 7;
            this.dateTimeRange.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRange.ToDateLabelText = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 91);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Tài khoản";
            // 
            // cboAccount
            // 
            this.cboAccount.EditValue = "";
            this.cboAccount.Location = new System.Drawing.Point(70, 88);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAccount.Size = new System.Drawing.Size(225, 20);
            this.cboAccount.TabIndex = 19;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(296, 27);
            this.labelControl2.TabIndex = 20;
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(68, 121);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(216, 19);
            this.chkMoveTotalInNewPage.TabIndex = 21;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // FrmF331BNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 207);
            this.Name = "FrmF331BNG";
            this.Load += new System.EventHandler(this.FrmF331BNG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRange;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboAccount;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
    }
}