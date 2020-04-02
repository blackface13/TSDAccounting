namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    internal partial class FrmXtraVoucherListDetail
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
            this.lbVoucherNo = new DevExpress.XtraEditors.LabelControl();
            this.txtVoucherNo = new DevExpress.XtraEditors.TextEdit();
            this.lbVoucherDate = new DevExpress.XtraEditors.LabelControl();
            this.dEVoucherDate = new DevExpress.XtraEditors.DateEdit();
            this.dEPostDate = new DevExpress.XtraEditors.DateEdit();
            this.lbPostDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.moDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtDocAttach = new DevExpress.XtraEditors.TextEdit();
            this.lbDocAttach = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEVoucherDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEVoucherDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPostDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPostDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocAttach.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 214);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(459, 214);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 214);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.txtDocAttach);
            this.groupboxMain.Controls.Add(this.lbDocAttach);
            this.groupboxMain.Controls.Add(this.moDescription);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.dEPostDate);
            this.groupboxMain.Controls.Add(this.lbPostDate);
            this.groupboxMain.Controls.Add(this.dEVoucherDate);
            this.groupboxMain.Controls.Add(this.lbVoucherDate);
            this.groupboxMain.Controls.Add(this.txtVoucherNo);
            this.groupboxMain.Controls.Add(this.lbVoucherNo);
            this.groupboxMain.Size = new System.Drawing.Size(520, 199);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // lbVoucherNo
            // 
            this.lbVoucherNo.Location = new System.Drawing.Point(9, 27);
            this.lbVoucherNo.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.lbVoucherNo.Name = "lbVoucherNo";
            this.lbVoucherNo.Size = new System.Drawing.Size(78, 13);
            this.lbVoucherNo.TabIndex = 0;
            this.lbVoucherNo.Text = "Mã CT ghi sổ (*)";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(108, 24);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(160, 20);
            this.txtVoucherNo.TabIndex = 1;
            // 
            // lbVoucherDate
            // 
            this.lbVoucherDate.Location = new System.Drawing.Point(275, 53);
            this.lbVoucherDate.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.lbVoucherDate.Name = "lbVoucherDate";
            this.lbVoucherDate.Size = new System.Drawing.Size(71, 13);
            this.lbVoucherDate.TabIndex = 4;
            this.lbVoucherDate.Text = "Ngày CTGS (*)";
            // 
            // dEVoucherDate
            // 
            this.dEVoucherDate.EditValue = new System.DateTime(2014, 3, 21, 10, 36, 33, 97);
            this.dEVoucherDate.Location = new System.Drawing.Point(352, 50);
            this.dEVoucherDate.Name = "dEVoucherDate";
            this.dEVoucherDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dEVoucherDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dEVoucherDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dEVoucherDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dEVoucherDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dEVoucherDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dEVoucherDate.Size = new System.Drawing.Size(160, 20);
            this.dEVoucherDate.TabIndex = 5;
            // 
            // dEPostDate
            // 
            this.dEPostDate.EditValue = null;
            this.dEPostDate.Location = new System.Drawing.Point(108, 50);
            this.dEPostDate.Name = "dEPostDate";
            this.dEPostDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dEPostDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dEPostDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dEPostDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dEPostDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dEPostDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dEPostDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dEPostDate.Size = new System.Drawing.Size(160, 20);
            this.dEPostDate.TabIndex = 3;
            // 
            // lbPostDate
            // 
            this.lbPostDate.Location = new System.Drawing.Point(9, 53);
            this.lbPostDate.Name = "lbPostDate";
            this.lbPostDate.Size = new System.Drawing.Size(93, 13);
            this.lbPostDate.TabIndex = 2;
            this.lbPostDate.Text = "Ngày hạch toán (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 105);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Mô tả";
            // 
            // moDescription
            // 
            this.moDescription.Location = new System.Drawing.Point(108, 102);
            this.moDescription.Name = "moDescription";
            this.moDescription.Size = new System.Drawing.Size(404, 92);
            this.moDescription.TabIndex = 9;
            // 
            // txtDocAttach
            // 
            this.txtDocAttach.Location = new System.Drawing.Point(108, 76);
            this.txtDocAttach.Name = "txtDocAttach";
            this.txtDocAttach.Size = new System.Drawing.Size(404, 20);
            this.txtDocAttach.TabIndex = 7;
            // 
            // lbDocAttach
            // 
            this.lbDocAttach.Location = new System.Drawing.Point(9, 79);
            this.lbDocAttach.Name = "lbDocAttach";
            this.lbDocAttach.Size = new System.Drawing.Size(93, 13);
            this.lbDocAttach.TabIndex = 6;
            this.lbDocAttach.Text = "Chứng từ kèm theo";
            // 
            // FrmXtraVoucherListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 248);
            this.ComponentName = "Chứng từ ghi sổ";
            this.EventTime = new System.DateTime(2019, 11, 14, 8, 24, 7, 573);
            this.FormCaption = "chứng từ ghi sổ";
            this.Name = "FrmXtraVoucherListDetail";
            this.Reference = "THÊM CHỨNG TỪ GHI SỔ - ID ";
            this.Text = "FrmXtraVoucherListDetail";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEVoucherDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEVoucherDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPostDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPostDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocAttach.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtVoucherNo;
        private DevExpress.XtraEditors.LabelControl lbVoucherNo;
        private DevExpress.XtraEditors.LabelControl lbVoucherDate;
        private DevExpress.XtraEditors.DateEdit dEPostDate;
        private DevExpress.XtraEditors.LabelControl lbPostDate;
        private DevExpress.XtraEditors.DateEdit dEVoucherDate;
        private DevExpress.XtraEditors.TextEdit txtDocAttach;
        private DevExpress.XtraEditors.LabelControl lbDocAttach;
        private DevExpress.XtraEditors.MemoEdit moDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}