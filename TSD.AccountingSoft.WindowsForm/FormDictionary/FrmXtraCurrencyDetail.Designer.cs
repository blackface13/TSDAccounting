namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraCurrencyDetail
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
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtCurrencyName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrencyCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkMain = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSuffix = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrefix = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuffix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrefix.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(235, 223);
            this.btnSave.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(317, 223);
            this.btnExit.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 223);
            this.btnHelp.TabIndex = 5;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.chkMain);
            this.groupboxMain.Controls.Add(this.txtCurrencyName);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtCurrencyCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Location = new System.Drawing.Point(8, 8);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(384, 96);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.Location = new System.Drawing.Point(5, 195);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 2;
            this.chkIsActive.Tag = "IsActive";
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrencyName.EditValue = "";
            this.txtCurrencyName.Location = new System.Drawing.Point(96, 48);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(280, 20);
            this.txtCurrencyName.TabIndex = 3;
            this.txtCurrencyName.Tag = "BudgetSourcePropertyName";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên loại tiền (*)";
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.Location = new System.Drawing.Point(96, 24);
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.Size = new System.Drawing.Size(176, 20);
            this.txtCurrencyCode.TabIndex = 1;
            this.txtCurrencyCode.Tag = "BudgetSourcePropertyCode";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã tiền tệ (*)";
            // 
            // chkMain
            // 
            this.chkMain.Location = new System.Drawing.Point(93, 72);
            this.chkMain.Name = "chkMain";
            this.chkMain.Properties.Caption = "Là đồng tiền hạch toán";
            this.chkMain.Size = new System.Drawing.Size(280, 19);
            this.chkMain.TabIndex = 4;
            this.chkMain.Tag = "Main";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtSuffix);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtPrefix);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(8, 110);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(384, 75);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Cách đọc bằng chữ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "&Trước dấu phẩy";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(90, 48);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(286, 20);
            this.txtSuffix.TabIndex = 4;
            this.txtSuffix.Tag = "BudgetSourcePropertyCode";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 52);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(66, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "&Sau dấu phẩy";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(90, 24);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(286, 20);
            this.txtPrefix.TabIndex = 2;
            this.txtPrefix.Tag = "BudgetSourcePropertyCode";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, -13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Trước dấu phẩy";
            // 
            // FrmXtraCurrencyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 254);
            this.ComponentName = "Tiền tệ";
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 7, 15, 2, 26, 67);
            this.FormCaption = "tiền tệ";
            this.Name = "FrmXtraCurrencyDetail";
            this.Reference = "THÊM TIỀN TỆ - ID ";
            this.Text = "FrmXtraCurrencyDetail";
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuffix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrefix.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.TextEdit txtCurrencyName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCurrencyCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkMain;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtSuffix;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPrefix;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}