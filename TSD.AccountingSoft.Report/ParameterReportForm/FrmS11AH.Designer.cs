namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmS11AH
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.grdLookUpCorrespondingAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpCorrespondingAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.grdLookUpAccount);
            this.groupboxMain.Controls.Add(this.grdLookUpCorrespondingAccount);
            this.groupboxMain.Location = new System.Drawing.Point(8, 12);
            this.groupboxMain.Size = new System.Drawing.Size(343, 178);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(199, 203);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(280, 203);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 203);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Tk đối ứng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Tài khoản";
            // 
            // grdLookUpAccount
            // 
            this.grdLookUpAccount.EditValue = "";
            this.grdLookUpAccount.Location = new System.Drawing.Point(117, 95);
            this.grdLookUpAccount.Name = "grdLookUpAccount";
            this.grdLookUpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpAccount.Size = new System.Drawing.Size(206, 20);
            this.grdLookUpAccount.TabIndex = 5;
            this.grdLookUpAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.FormatCombo_QueryPopUp);
            // 
            // grdLookUpCorrespondingAccount
            // 
            this.grdLookUpCorrespondingAccount.EditValue = "";
            this.grdLookUpCorrespondingAccount.Location = new System.Drawing.Point(117, 121);
            this.grdLookUpCorrespondingAccount.Name = "grdLookUpCorrespondingAccount";
            this.grdLookUpCorrespondingAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpCorrespondingAccount.Size = new System.Drawing.Size(206, 20);
            this.grdLookUpCorrespondingAccount.TabIndex = 7;
            this.grdLookUpCorrespondingAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.FormatCombo_QueryPopUp);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(19, 14);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(304, 70);
            this.dateTimeRangeV1.TabIndex = 8;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(12, 147);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(232, 19);
            this.chkMoveTotalInNewPage.TabIndex = 19;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // FrmS11AH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(363, 234);
            this.Name = "FrmS11AH";
            this.Text = "Báo cáo thu, chi";
            this.Load += new System.EventHandler(this.FrmS11H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpCorrespondingAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpAccount;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpCorrespondingAccount;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;

    }
}