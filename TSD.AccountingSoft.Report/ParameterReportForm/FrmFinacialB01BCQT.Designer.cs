namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmFinacialB01BCQT
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
            this.checkBox1 = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new DevExpress.XtraEditors.CalcEdit();
            this.textBox2 = new DevExpress.XtraEditors.CalcEdit();
            this.textBox3 = new DevExpress.XtraEditors.CalcEdit();
            this.textBox4 = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.label4);
            this.groupboxMain.Controls.Add(this.label3);
            this.groupboxMain.Controls.Add(this.label2);
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Controls.Add(this.checkBox1);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.textBox1);
            this.groupboxMain.Controls.Add(this.textBox2);
            this.groupboxMain.Controls.Add(this.textBox3);
            this.groupboxMain.Controls.Add(this.textBox4);
            this.groupboxMain.Size = new System.Drawing.Size(411, 220);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(262, 237);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(343, 237);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 237);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 5);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(298, 70);
            this.dateTimeRangeV1.TabIndex = 0;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // checkBox1
            // 
            this.checkBox1.EditValue = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Properties.Caption = "Dự toán được giao trong năm lấy trong dự toán chi";
            this.checkBox1.Size = new System.Drawing.Size(270, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nguồn chi thường xuyên";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nguồn chi không Thường Xuyên, Không tự chủ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nguồn chi không thường xuyên đặc thù";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nguồn chi không thường xuyên bổ sung";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(249, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBox1.Properties.DisplayFormat.FormatString = "c";
            this.textBox1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textBox1.Properties.Mask.EditMask = "c";
            this.textBox1.Properties.NullText = "0";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(249, 132);
            this.textBox2.Name = "textBox2";
            this.textBox2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBox2.Properties.DisplayFormat.FormatString = "c";
            this.textBox2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textBox2.Properties.Mask.EditMask = "c";
            this.textBox2.Properties.NullText = "0";
            this.textBox2.Size = new System.Drawing.Size(150, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(249, 158);
            this.textBox3.Name = "textBox3";
            this.textBox3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBox3.Properties.DisplayFormat.FormatString = "c";
            this.textBox3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textBox3.Properties.Mask.EditMask = "c";
            this.textBox3.Properties.NullText = "0";
            this.textBox3.Size = new System.Drawing.Size(150, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(249, 184);
            this.textBox4.Name = "textBox4";
            this.textBox4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBox4.Properties.DisplayFormat.FormatString = "c";
            this.textBox4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textBox4.Properties.Mask.EditMask = "c";
            this.textBox4.Properties.NullText = "0";
            this.textBox4.Size = new System.Drawing.Size(150, 20);
            this.textBox4.TabIndex = 8;
            // 
            // FrmFinacialB01BCQT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 271);
            this.Name = "FrmFinacialB01BCQT";
            this.Text = "FrmFinacialB01BCQT";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.CheckEdit checkBox1;
        private DevExpress.XtraEditors.CalcEdit textBox1;
        private DevExpress.XtraEditors.CalcEdit textBox2;
        private DevExpress.XtraEditors.CalcEdit textBox3;
        private DevExpress.XtraEditors.CalcEdit textBox4;
    }
}