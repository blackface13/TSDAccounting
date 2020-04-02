namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmF03Bng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmF03Bng));
            this.dateTimeRange = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            this.chkDetailToUSD = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailToUSD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.dateTimeRange);
            this.groupboxMain.Size = new System.Drawing.Size(315, 76);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(166, 229);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(247, 229);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 229);
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
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(5, 198);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(216, 19);
            this.chkMoveTotalInNewPage.TabIndex = 8;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // chkDetailToUSD
            // 
            this.chkDetailToUSD.Location = new System.Drawing.Point(5, 93);
            this.chkDetailToUSD.Name = "chkDetailToUSD";
            this.chkDetailToUSD.Properties.Caption = "Xem báo cáo chi tiết chi kinh phí quy đổi";
            this.chkDetailToUSD.Size = new System.Drawing.Size(216, 19);
            this.chkDetailToUSD.TabIndex = 9;
            this.chkDetailToUSD.CheckedChanged += new System.EventHandler(this.chkDetailToUSD_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Location = new System.Drawing.Point(7, 116);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3);
            this.labelControl1.Size = new System.Drawing.Size(312, 73);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = resources.GetString("labelControl1.Text");
            // 
            // FrmF03Bng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 263);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.chkDetailToUSD);
            this.Controls.Add(this.chkMoveTotalInNewPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmF03Bng";
            this.Load += new System.EventHandler(this.FrmF03Bng_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkMoveTotalInNewPage, 0);
            this.Controls.SetChildIndex(this.chkDetailToUSD, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDetailToUSD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRange;
        private DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
        private DevExpress.XtraEditors.CheckEdit chkDetailToUSD;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}