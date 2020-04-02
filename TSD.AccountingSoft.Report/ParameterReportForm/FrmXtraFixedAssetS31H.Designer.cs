namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmXtraFixedAssetS31H
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
            this.cboFixedAssetCategory = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFixedAssetCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupboxMain.Controls.Add(this.cboFixedAssetCategory);
            this.groupboxMain.Controls.Add(this.label5);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Size = new System.Drawing.Size(312, 132);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(163, 149);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(244, 149);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 150);
            // 
            // cboFixedAssetCategory
            // 
            this.cboFixedAssetCategory.EditValue = "";
            this.cboFixedAssetCategory.Location = new System.Drawing.Point(69, 83);
            this.cboFixedAssetCategory.Name = "cboFixedAssetCategory";
            this.cboFixedAssetCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFixedAssetCategory.Size = new System.Drawing.Size(233, 20);
            this.cboFixedAssetCategory.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "&Loại TSCĐ";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(6, 4);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(296, 72);
            this.dateTimeRangeV1.TabIndex = 16;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            this.dateTimeRangeV1.Load += new System.EventHandler(this.dateTimeRangeV1_Load);
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(16, 108);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(288, 19);
            this.chkMoveTotalInNewPage.TabIndex = 19;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // FrmXtraFixedAssetS31H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 183);
            this.Name = "FrmXtraFixedAssetS31H";
            this.Text = "Sổ tài sản cố định";
            this.Load += new System.EventHandler(this.FrmXtraFixedAssetS31H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFixedAssetCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedComboBoxEdit cboFixedAssetCategory;
        private System.Windows.Forms.Label label5;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
    }
}