namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmS11H
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
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbok = new DevExpress.XtraEditors.SimpleButton();
            this.sbcancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            this.grdLookUpAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.sbhelp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Location = new System.Drawing.Point(40, 8);
            this.groupboxMain.Size = new System.Drawing.Size(16, 101);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(338, 284);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(419, 284);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 284);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(8, 25);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(304, 70);
            this.dateTimeRangeV1.TabIndex = 0;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 105);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Tài khoản";
            // 
            // sbok
            // 
            this.sbok.Location = new System.Drawing.Point(162, 170);
            this.sbok.Name = "sbok";
            this.sbok.Size = new System.Drawing.Size(72, 24);
            this.sbok.TabIndex = 2;
            this.sbok.Text = "Đồng ý";
            this.sbok.Click += new System.EventHandler(this.sbok_Click);
            // 
            // sbcancel
            // 
            this.sbcancel.Location = new System.Drawing.Point(240, 170);
            this.sbcancel.Name = "sbcancel";
            this.sbcancel.Size = new System.Drawing.Size(72, 24);
            this.sbcancel.TabIndex = 3;
            this.sbcancel.Text = "Hủy";
            this.sbcancel.Click += new System.EventHandler(this.sbcancel_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupControl1.Controls.Add(this.grdLookUpAccount);
            this.groupControl1.Controls.Add(this.sbhelp);
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Controls.Add(this.sbok);
            this.groupControl1.Controls.Add(this.sbcancel);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(8, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(329, 199);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin chung";
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(6, 138);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(232, 19);
            this.chkMoveTotalInNewPage.TabIndex = 20;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // grdLookUpAccount
            // 
            this.grdLookUpAccount.EditValue = "";
            this.grdLookUpAccount.Location = new System.Drawing.Point(111, 102);
            this.grdLookUpAccount.Name = "grdLookUpAccount";
            this.grdLookUpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpAccount.Size = new System.Drawing.Size(201, 20);
            this.grdLookUpAccount.TabIndex = 1;
            this.grdLookUpAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.FormatCombo_QueryPopUp);
            // 
            // sbhelp
            // 
            this.sbhelp.Location = new System.Drawing.Point(8, 170);
            this.sbhelp.Name = "sbhelp";
            this.sbhelp.Size = new System.Drawing.Size(72, 24);
            this.sbhelp.TabIndex = 4;
            this.sbhelp.Text = "Trợ giúp";
            // 
            // FrmS11H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(352, 236);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmS11H";
            this.Text = "Báo cáo thu,chi";
            this.Load += new System.EventHandler(this.FrmS11AH_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbok;
        private DevExpress.XtraEditors.SimpleButton sbcancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton sbhelp;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpAccount;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
    }
}