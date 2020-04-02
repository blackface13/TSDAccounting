﻿namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmXtraGeneralPaymentEstimate
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtReportDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spinYearOfPlaning = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboCurrencyCode = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYearOfPlaning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrencyCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.dtReportDate);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.spinYearOfPlaning);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.cboCurrencyCode);
            this.groupboxMain.Location = new System.Drawing.Point(8, 8);
            this.groupboxMain.Size = new System.Drawing.Size(197, 74);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(212, -6);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(212, 26);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(224, 58);
            this.btnHelp.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(100, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Loại tiền làm dự toán";
            // 
            // dtReportDate
            // 
            this.dtReportDate.EditValue = new System.DateTime(2014, 2, 28, 14, 7, 10, 0);
            this.dtReportDate.Location = new System.Drawing.Point(112, 56);
            this.dtReportDate.Name = "dtReportDate";
            this.dtReportDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReportDate.Properties.Mask.BeepOnError = true;
            this.dtReportDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtReportDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtReportDate.Size = new System.Drawing.Size(88, 20);
            this.dtReportDate.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Ngày xem báo cáo";
            // 
            // spinYearOfPlaning
            // 
            this.spinYearOfPlaning.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.spinYearOfPlaning.Location = new System.Drawing.Point(112, 8);
            this.spinYearOfPlaning.Name = "spinYearOfPlaning";
            this.spinYearOfPlaning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinYearOfPlaning.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinYearOfPlaning.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            this.spinYearOfPlaning.Properties.IsFloatValue = false;
            this.spinYearOfPlaning.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinYearOfPlaning.Properties.NullText = "[EditValue is null]";
            this.spinYearOfPlaning.Size = new System.Drawing.Size(88, 20);
            this.spinYearOfPlaning.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Năm dự toán";
            // 
            // cboCurrencyCode
            // 
            this.cboCurrencyCode.EditValue = "USD";
            this.cboCurrencyCode.Location = new System.Drawing.Point(112, 32);
            this.cboCurrencyCode.Name = "cboCurrencyCode";
            this.cboCurrencyCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCurrencyCode.Properties.Items.AddRange(new object[] {
            "USD"});
            this.cboCurrencyCode.Properties.NullText = "[EditValue is null]";
            this.cboCurrencyCode.Size = new System.Drawing.Size(88, 20);
            this.cboCurrencyCode.TabIndex = 9;
            // 
            // FrmXtraGeneralPaymentEstimate
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(295, 89);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmXtraGeneralPaymentEstimate";
            this.Text = "Tổng hợp dự toán chi NSNN";
            this.Load += new System.EventHandler(this.FrmXtraGeneralPaymentEstimate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYearOfPlaning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrencyCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtReportDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spinYearOfPlaning;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboCurrencyCode;
    }
}