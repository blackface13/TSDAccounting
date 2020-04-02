namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmXtraFixedAssetFAInventoryHouse
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.memoOther = new DevExpress.XtraEditors.MemoEdit();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            this.spnAccountingValue = new DevExpress.XtraEditors.SpinEdit();
            this.spnWorkingArea = new DevExpress.XtraEditors.SpinEdit();
            this.spnTotalArea = new DevExpress.XtraEditors.SpinEdit();
            this.spnGuestHouseArea = new DevExpress.XtraEditors.SpinEdit();
            this.spnHousingArea = new DevExpress.XtraEditors.SpinEdit();
            this.spnVacancyArea = new DevExpress.XtraEditors.SpinEdit();
            this.spnOtherArea = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoOther.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAccountingValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnWorkingArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTotalArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGuestHouseArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnHousingArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnVacancyArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnOtherArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.spnHousingArea);
            this.groupboxMain.Controls.Add(this.spnOtherArea);
            this.groupboxMain.Controls.Add(this.spnVacancyArea);
            this.groupboxMain.Controls.Add(this.spnGuestHouseArea);
            this.groupboxMain.Controls.Add(this.spnTotalArea);
            this.groupboxMain.Controls.Add(this.spnWorkingArea);
            this.groupboxMain.Controls.Add(this.spnAccountingValue);
            this.groupboxMain.Controls.Add(this.chkMoveTotalInNewPage);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.memoOther);
            this.groupboxMain.Controls.Add(this.labelControl8);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Size = new System.Drawing.Size(672, 180);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(523, 197);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(604, 197);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 197);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(12, 90);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ tính giá";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(290, 80);
            this.dateTimeRangeV1.TabIndex = 11;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(119, 13);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "Diện tích khuôn viên đất:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Làm trụ sở làm việc";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(264, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Làm nhà ở";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(264, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 13);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "Làm nhà khách";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(488, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Bỏ trống";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(488, 40);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(23, 13);
            this.labelControl7.TabIndex = 23;
            this.labelControl7.Text = "Khác";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 70);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(110, 13);
            this.labelControl8.TabIndex = 24;
            this.labelControl8.Text = "Giá trị theo sổ kế toán:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(320, 88);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(125, 13);
            this.labelControl6.TabIndex = 25;
            this.labelControl6.Text = "Các hồ sơ giấy tờ khác";
            // 
            // memoOther
            // 
            this.memoOther.EditValue = "";
            this.memoOther.Location = new System.Drawing.Point(320, 104);
            this.memoOther.Name = "memoOther";
            this.memoOther.Size = new System.Drawing.Size(344, 72);
            this.memoOther.TabIndex = 26;
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(376, 65);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(288, 19);
            this.chkMoveTotalInNewPage.TabIndex = 30;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // spnAccountingValue
            // 
            this.spnAccountingValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnAccountingValue.Location = new System.Drawing.Point(136, 68);
            this.spnAccountingValue.Name = "spnAccountingValue";
            this.spnAccountingValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnAccountingValue.Size = new System.Drawing.Size(112, 20);
            this.spnAccountingValue.TabIndex = 31;
            this.spnAccountingValue.Tag = "Percent";
            // 
            // spnWorkingArea
            // 
            this.spnWorkingArea.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnWorkingArea.Location = new System.Drawing.Point(136, 38);
            this.spnWorkingArea.Name = "spnWorkingArea";
            this.spnWorkingArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnWorkingArea.Size = new System.Drawing.Size(112, 20);
            this.spnWorkingArea.TabIndex = 32;
            this.spnWorkingArea.Tag = "Percent";
            // 
            // spnTotalArea
            // 
            this.spnTotalArea.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnTotalArea.Location = new System.Drawing.Point(136, 13);
            this.spnTotalArea.Name = "spnTotalArea";
            this.spnTotalArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnTotalArea.Size = new System.Drawing.Size(112, 20);
            this.spnTotalArea.TabIndex = 32;
            this.spnTotalArea.Tag = "Percent";
            // 
            // spnGuestHouseArea
            // 
            this.spnGuestHouseArea.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnGuestHouseArea.Location = new System.Drawing.Point(344, 5);
            this.spnGuestHouseArea.Name = "spnGuestHouseArea";
            this.spnGuestHouseArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnGuestHouseArea.Size = new System.Drawing.Size(120, 20);
            this.spnGuestHouseArea.TabIndex = 32;
            this.spnGuestHouseArea.Tag = "Percent";
            // 
            // spnHousingArea
            // 
            this.spnHousingArea.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnHousingArea.Location = new System.Drawing.Point(344, 31);
            this.spnHousingArea.Name = "spnHousingArea";
            this.spnHousingArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnHousingArea.Size = new System.Drawing.Size(120, 20);
            this.spnHousingArea.TabIndex = 32;
            this.spnHousingArea.Tag = "Percent";
            // 
            // spnVacancyArea
            // 
            this.spnVacancyArea.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnVacancyArea.Location = new System.Drawing.Point(536, 5);
            this.spnVacancyArea.Name = "spnVacancyArea";
            this.spnVacancyArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnVacancyArea.Size = new System.Drawing.Size(128, 20);
            this.spnVacancyArea.TabIndex = 32;
            this.spnVacancyArea.Tag = "Percent";
            // 
            // spnOtherArea
            // 
            this.spnOtherArea.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnOtherArea.Location = new System.Drawing.Point(536, 31);
            this.spnOtherArea.Name = "spnOtherArea";
            this.spnOtherArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnOtherArea.Size = new System.Drawing.Size(128, 20);
            this.spnOtherArea.TabIndex = 32;
            this.spnOtherArea.Tag = "Percent";
            // 
            // FrmXtraFixedAssetFAInventoryHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 231);
            this.Name = "FrmXtraFixedAssetFAInventoryHouse";
            this.Text = "Báo cáo kê khai nhà cửa, trụ sở làm việc";
            this.Load += new System.EventHandler(this.FrmXtraFixedAssetFAInventoryHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoOther.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAccountingValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnWorkingArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTotalArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGuestHouseArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnHousingArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnVacancyArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnOtherArea.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit memoOther;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
        private DevExpress.XtraEditors.SpinEdit spnAccountingValue;
        private DevExpress.XtraEditors.SpinEdit spnHousingArea;
        private DevExpress.XtraEditors.SpinEdit spnOtherArea;
        private DevExpress.XtraEditors.SpinEdit spnVacancyArea;
        private DevExpress.XtraEditors.SpinEdit spnGuestHouseArea;
        private DevExpress.XtraEditors.SpinEdit spnTotalArea;
        private DevExpress.XtraEditors.SpinEdit spnWorkingArea;
    }
}