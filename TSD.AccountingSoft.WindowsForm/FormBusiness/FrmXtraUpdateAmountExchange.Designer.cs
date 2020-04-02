namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraUpdateAmountExchange
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dateTimeRangeV = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtExchangeRate = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(154, 124);
            this.btnSave.Size = new System.Drawing.Size(77, 25);
            this.btnSave.Text = "Cập nhật";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(238, 124);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 124);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.txtExchangeRate);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV);
            this.groupboxMain.Size = new System.Drawing.Size(302, 107);
            // 
            // dateTimeRangeV
            // 
            this.dateTimeRangeV.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRangeV.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV.InitSelectedIndex = 0;
            this.dateTimeRangeV.Location = new System.Drawing.Point(2, 3);
            this.dateTimeRangeV.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV.Name = "dateTimeRangeV";
            this.dateTimeRangeV.PeriodLabelText = "Kỳ cập nhật";
            this.dateTimeRangeV.Size = new System.Drawing.Size(301, 70);
            this.dateTimeRangeV.TabIndex = 1;
            this.dateTimeRangeV.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV.ToDateLabelText = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tỷ giá";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(70, 79);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtExchangeRate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.txtExchangeRate.Properties.Tag = "ExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(224, 20);
            this.txtExchangeRate.TabIndex = 3;
            this.txtExchangeRate.Tag = "ExchangeRate";
            // 
            // FrmXtraUpdateAmountExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 156);
            this.FormCaption = "Cập nhật tỷ giá";
            this.Name = "FrmXtraUpdateAmountExchange";
            this.Text = "Cập nhật tỷ giá";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV;
        private DevExpress.XtraEditors.CalcEdit txtExchangeRate;
    }
}