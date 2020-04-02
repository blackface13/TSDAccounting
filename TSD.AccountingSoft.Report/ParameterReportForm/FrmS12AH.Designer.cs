namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmS12AH
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.sbhelp = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.sbok = new DevExpress.XtraEditors.SimpleButton();
            this.sbcancel = new DevExpress.XtraEditors.SimpleButton();
            this.grdLookUpCorrespondingAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.cboBank = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cboBankView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkBank = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpCorrespondingAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Location = new System.Drawing.Point(384, 12);
            this.groupboxMain.Size = new System.Drawing.Size(13, 0);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(419, 279);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(500, 279);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 279);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboBank);
            this.groupControl1.Controls.Add(this.chkBank);
            this.groupControl1.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.grdLookUpAccount);
            this.groupControl1.Controls.Add(this.sbhelp);
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Controls.Add(this.sbok);
            this.groupControl1.Controls.Add(this.sbcancel);
            this.groupControl1.Controls.Add(this.grdLookUpCorrespondingAccount);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(395, 258);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin chung";
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(3, 194);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(232, 19);
            this.chkMoveTotalInNewPage.TabIndex = 21;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Tk đối ứng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 116);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Tài khoản";
            // 
            // grdLookUpAccount
            // 
            this.grdLookUpAccount.EditValue = "";
            this.grdLookUpAccount.Location = new System.Drawing.Point(103, 113);
            this.grdLookUpAccount.Name = "grdLookUpAccount";
            this.grdLookUpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpAccount.Size = new System.Drawing.Size(274, 20);
            this.grdLookUpAccount.TabIndex = 1;
            this.grdLookUpAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.FormatCombo_QueryPopUp);
            // 
            // sbhelp
            // 
            this.sbhelp.Location = new System.Drawing.Point(7, 221);
            this.sbhelp.Name = "sbhelp";
            this.sbhelp.Size = new System.Drawing.Size(72, 24);
            this.sbhelp.TabIndex = 5;
            this.sbhelp.Text = "Trợ giúp";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(8, 26);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(369, 81);
            this.dateTimeRangeV1.TabIndex = 0;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // sbok
            // 
            this.sbok.Location = new System.Drawing.Point(206, 221);
            this.sbok.Name = "sbok";
            this.sbok.Size = new System.Drawing.Size(72, 24);
            this.sbok.TabIndex = 3;
            this.sbok.Text = "Đồng ý";
            this.sbok.Click += new System.EventHandler(this.sbok_Click);
            // 
            // sbcancel
            // 
            this.sbcancel.Location = new System.Drawing.Point(284, 221);
            this.sbcancel.Name = "sbcancel";
            this.sbcancel.Size = new System.Drawing.Size(72, 24);
            this.sbcancel.TabIndex = 4;
            this.sbcancel.Text = "Hủy";
            this.sbcancel.Click += new System.EventHandler(this.sbcancel_Click);
            // 
            // grdLookUpCorrespondingAccount
            // 
            this.grdLookUpCorrespondingAccount.EditValue = "";
            this.grdLookUpCorrespondingAccount.Location = new System.Drawing.Point(103, 141);
            this.grdLookUpCorrespondingAccount.Name = "grdLookUpCorrespondingAccount";
            this.grdLookUpCorrespondingAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpCorrespondingAccount.Size = new System.Drawing.Size(274, 20);
            this.grdLookUpCorrespondingAccount.TabIndex = 2;
            this.grdLookUpCorrespondingAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.FormatCombo_QueryPopUp);
            // 
            // cboBank
            // 
            this.cboBank.Enabled = false;
            this.cboBank.Location = new System.Drawing.Point(103, 166);
            this.cboBank.Name = "cboBank";
            this.cboBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBank.Properties.NullText = "";
            this.cboBank.Properties.View = this.cboBankView;
            this.cboBank.Size = new System.Drawing.Size(274, 20);
            this.cboBank.TabIndex = 26;
            // 
            // cboBankView
            // 
            this.cboBankView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cboBankView.Name = "cboBankView";
            this.cboBankView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cboBankView.OptionsView.ShowGroupPanel = false;
            // 
            // chkBank
            // 
            this.chkBank.AutoSize = true;
            this.chkBank.Location = new System.Drawing.Point(5, 169);
            this.chkBank.Name = "chkBank";
            this.chkBank.Size = new System.Drawing.Size(92, 17);
            this.chkBank.TabIndex = 25;
            this.chkBank.Text = "TK ngân hàng";
            this.chkBank.UseVisualStyleBackColor = true;
            this.chkBank.CheckedChanged += new System.EventHandler(this.chkBank_CheckedChanged);
            // 
            // FrmS12AH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(409, 272);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmS12AH";
            this.Text = "FrmS12AH";
            this.Load += new System.EventHandler(this.FrmS12AH_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpCorrespondingAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpAccount;
        private DevExpress.XtraEditors.SimpleButton sbhelp;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.SimpleButton sbok;
        private DevExpress.XtraEditors.SimpleButton sbcancel;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpCorrespondingAccount;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
        public DevExpress.XtraEditors.GridLookUpEdit cboBank;
        public DevExpress.XtraGrid.Views.Grid.GridView cboBankView;
        private System.Windows.Forms.CheckBox chkBank;
    }
}