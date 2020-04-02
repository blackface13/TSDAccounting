namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraReCalOutputInventory
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuyBo = new DevExpress.XtraEditors.SimpleButton();
            this.cboStock = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.grdCurrencyType = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            this.cboCurrency = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencyType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "&Loại tiền";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(146, 153);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Thực hiện";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyBo.Location = new System.Drawing.Point(224, 153);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(72, 23);
            this.btnHuyBo.TabIndex = 10;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // cboStock
            // 
            this.cboStock.EditValue = "";
            this.cboStock.Location = new System.Drawing.Point(68, 127);
            this.cboStock.Name = "cboStock";
            this.cboStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStock.Size = new System.Drawing.Size(224, 20);
            this.cboStock.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "&Kho";
            // 
            // grdCurrencyType
            // 
            this.grdCurrencyType.EditValue = "";
            this.grdCurrencyType.Location = new System.Drawing.Point(111, 184);
            this.grdCurrencyType.Name = "grdCurrencyType";
            this.grdCurrencyType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdCurrencyType.Properties.NullText = "";
            this.grdCurrencyType.Properties.View = this.gridLookUpEdit1View;
            this.grdCurrencyType.Size = new System.Drawing.Size(10, 20);
            this.grdCurrencyType.TabIndex = 0;
            this.grdCurrencyType.Visible = false;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(4, 32);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ tính giá";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(296, 72);
            this.dateTimeRangeV1.TabIndex = 2;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(8, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(284, 32);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chức năng này chỉ áp dụng đối với phương pháp tính giá bình quân cuối kỳ và chỉ t" +
    "hực hiện 1 lần vào cuối mỗi kỳ\r\n";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(8, 155);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.progressBarControl1.Size = new System.Drawing.Size(284, 18);
            this.progressBarControl1.TabIndex = 7;
            this.progressBarControl1.EditValueChanged += new System.EventHandler(this.progressBarControl1_EditValueChanged);
            // 
            // lblProcess
            // 
            this.lblProcess.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblProcess.Location = new System.Drawing.Point(120, 158);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(0, 13);
            this.lblProcess.TabIndex = 8;
            // 
            // cboCurrency
            // 
            this.cboCurrency.EditValue = "";
            this.cboCurrency.Location = new System.Drawing.Point(68, 101);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCurrency.Size = new System.Drawing.Size(224, 20);
            this.cboCurrency.TabIndex = 4;
            // 
            // FrmXtraReCalOutputInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 182);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.grdCurrencyType);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateTimeRangeV1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXtraReCalOutputInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật giá xuất kho trong kỳ";
            this.Load += new System.EventHandler(this.FrmXtraReCalOutputInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencyType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnHuyBo;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboStock;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GridLookUpEdit grdCurrencyType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.LabelControl lblProcess;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboCurrency;
     
    }
}