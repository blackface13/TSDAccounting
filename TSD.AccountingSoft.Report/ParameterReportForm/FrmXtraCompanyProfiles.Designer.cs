namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmXtraCompanyProfiles
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
            this.dtReportDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.memoPartC = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoPartC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.memoPartC);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.dtReportDate);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.labelControl9);
            this.groupboxMain.Size = new System.Drawing.Size(537, 414);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(388, 431);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(469, 431);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 431);
            // 
            // dtReportDate
            // 
            this.dtReportDate.EditValue = new System.DateTime(2014, 2, 28, 14, 7, 10, 0);
            this.dtReportDate.Location = new System.Drawing.Point(416, 14);
            this.dtReportDate.Name = "dtReportDate";
            this.dtReportDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReportDate.Properties.Mask.BeepOnError = true;
            this.dtReportDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtReportDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtReportDate.Size = new System.Drawing.Size(104, 20);
            this.dtReportDate.TabIndex = 18;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(336, 16);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(66, 13);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "Ngày báo cáo";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(14, 8);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ tính giá";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(299, 72);
            this.dateTimeRangeV1.TabIndex = 19;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // memoPartC
            // 
            this.memoPartC.EditValue = "";
            this.memoPartC.Location = new System.Drawing.Point(8, 104);
            this.memoPartC.Name = "memoPartC";
            this.memoPartC.Size = new System.Drawing.Size(520, 296);
            this.memoPartC.TabIndex = 20;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Nhận xét: ";
            // 
            // FrmXtraCompanyProfiles
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 465);
            this.Name = "FrmXtraCompanyProfiles";
            this.Text = "Báo cáo hồ sơ cơ bản";
            this.Load += new System.EventHandler(this.FrmXtraCompanyProfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoPartC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtReportDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.MemoEdit memoPartC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}