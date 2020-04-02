namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmF09Bng
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
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.dateTimeRange);
            this.groupboxMain.Size = new System.Drawing.Size(312, 76);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(163, 96);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(244, 96);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 96);
            // 
            // dateTimeRange
            // 
            this.dateTimeRange.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRange.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRange.FromDateLabelText = "Từ ngày";
            this.dateTimeRange.InitSelectedIndex = 0;
            this.dateTimeRange.Location = new System.Drawing.Point(4, 5);
            this.dateTimeRange.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRange.Name = "dateTimeRange";
            this.dateTimeRange.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRange.Size = new System.Drawing.Size(304, 70);
            this.dateTimeRange.TabIndex = 6;
            this.dateTimeRange.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRange.ToDateLabelText = "Đến ngày";
            // 
            // FrmF09Bng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 130);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmF09Bng";
            this.Load += new System.EventHandler(this.FrmF03Bng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRange;

    }
}