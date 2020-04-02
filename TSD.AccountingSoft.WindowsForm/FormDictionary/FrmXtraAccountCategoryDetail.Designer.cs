namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraAccountCategoryDetail
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
            this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
            this.txtAccountCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdLockUpParentID = new DevExpress.XtraEditors.LookUpEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.txtAccountName);
            this.groupboxMain.Controls.Add(this.txtAccountCode);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.grdLockUpParentID);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 104);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 144);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 144);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 144);
            this.btnHelp.TabIndex = 4;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(90, 50);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(367, 20);
            this.txtAccountName.TabIndex = 3;
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Location = new System.Drawing.Point(90, 24);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(160, 20);
            this.txtAccountCode.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "&Nhóm cha";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên nhóm (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã nhóm TK (*)";
            // 
            // grdLockUpParentID
            // 
            this.grdLockUpParentID.Location = new System.Drawing.Point(90, 76);
            this.grdLockUpParentID.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.grdLockUpParentID.Name = "grdLockUpParentID";
            this.grdLockUpParentID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLockUpParentID.Properties.NullText = "";
            this.grdLockUpParentID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpParentID.Size = new System.Drawing.Size(367, 20);
            this.grdLockUpParentID.TabIndex = 5;
            this.grdLockUpParentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpParentID_KeyDown);
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.Location = new System.Drawing.Point(7, 119);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // FrmXtraAccountCategoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 178);
            this.ComponentName = "Nhóm tài khoản";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 5, 16, 39, 8, 427);
            this.FormCaption = "Nhóm tài khoản";
            this.KeyFieldName = "AccountCategoryID";
            this.Name = "FrmXtraAccountCategoryDetail";
            this.ParentName = "ParentID";
            this.Reference = "THÊM NHÓM TÀI KHOẢN - ID ";
            this.Text = "FrmXtraAccountCategoryDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtAccountName;
        private DevExpress.XtraEditors.TextEdit txtAccountCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit grdLockUpParentID;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}