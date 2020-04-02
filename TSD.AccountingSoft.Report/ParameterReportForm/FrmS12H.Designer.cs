namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmS12H
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
            this.grdLookUpAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            this.cboBank = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cboBankView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkBank = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.cboBank);
            this.groupboxMain.Controls.Add(this.chkBank);
            this.groupboxMain.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupboxMain.Controls.Add(this.grdLookUpAccount);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Location = new System.Drawing.Point(8, 3);
            this.groupboxMain.Size = new System.Drawing.Size(338, 175);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(190, 187);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(271, 187);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 187);
            // 
            // grdLookUpAccount
            // 
            this.grdLookUpAccount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grdLookUpAccount.EditValue = "";
            this.grdLookUpAccount.Location = new System.Drawing.Point(105, 88);
            this.grdLookUpAccount.Name = "grdLookUpAccount";
            this.grdLookUpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpAccount.Properties.PopupWidth = 500;
            this.grdLookUpAccount.Size = new System.Drawing.Size(218, 20);
            this.grdLookUpAccount.TabIndex = 11;
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(7, 9);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(318, 70);
            this.dateTimeRangeV1.TabIndex = 10;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Location = new System.Drawing.Point(7, 91);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Tài khoản";
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(5, 142);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(232, 19);
            this.chkMoveTotalInNewPage.TabIndex = 22;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // cboBank
            // 
            this.cboBank.Enabled = false;
            this.cboBank.Location = new System.Drawing.Point(105, 114);
            this.cboBank.Name = "cboBank";
            this.cboBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBank.Properties.NullText = "";
            this.cboBank.Properties.View = this.cboBankView;
            this.cboBank.Size = new System.Drawing.Size(218, 20);
            this.cboBank.TabIndex = 24;
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
            this.chkBank.Location = new System.Drawing.Point(7, 116);
            this.chkBank.Name = "chkBank";
            this.chkBank.Size = new System.Drawing.Size(92, 17);
            this.chkBank.TabIndex = 23;
            this.chkBank.Text = "TK ngân hàng";
            this.chkBank.UseVisualStyleBackColor = true;
            this.chkBank.CheckedChanged += new System.EventHandler(this.chkBank_CheckedChanged);
            // 
            // FrmS12H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(354, 221);
            this.Name = "FrmS12H";
            this.Text = "FrmS12H";
            this.Load += new System.EventHandler(this.FrmS12H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit grdLookUpAccount;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
        public DevExpress.XtraEditors.GridLookUpEdit cboBank;
        public DevExpress.XtraGrid.Views.Grid.GridView cboBankView;
        private System.Windows.Forms.CheckBox chkBank;

    }
}