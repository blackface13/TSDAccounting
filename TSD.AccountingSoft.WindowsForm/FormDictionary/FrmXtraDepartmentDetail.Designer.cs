namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraDepartmentDetail
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
            this.txtDepartmentCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.grdLockUpParentId = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpParentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtDepartmentName);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtDepartmentCode);
            this.groupboxMain.Controls.Add(this.grdLockUpParentId);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 183);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 223);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 223);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 223);
            this.btnHelp.TabIndex = 4;
            // 
            // txtDepartmentCode
            // 
            this.txtDepartmentCode.Location = new System.Drawing.Point(104, 24);
            this.txtDepartmentCode.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtDepartmentCode.Name = "txtDepartmentCode";
            this.txtDepartmentCode.Size = new System.Drawing.Size(160, 20);
            this.txtDepartmentCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã phòng ban (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên phòng ban (*)";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(104, 50);
            this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(353, 20);
            this.txtDepartmentName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Trực t&huộc";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 105);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "&Diễn giải";
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(104, 102);
            this.memoDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(353, 76);
            this.memoDescription.TabIndex = 7;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 198);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(463, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // grdLockUpParentId
            // 
            this.grdLockUpParentId.Location = new System.Drawing.Point(104, 76);
            this.grdLockUpParentId.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.grdLockUpParentId.Name = "grdLockUpParentId";
            this.grdLockUpParentId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLockUpParentId.Properties.NullText = "";
            this.grdLockUpParentId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpParentId.Properties.View = this.grdLockUpParentView;
            this.grdLockUpParentId.Size = new System.Drawing.Size(353, 20);
            this.grdLockUpParentId.TabIndex = 5;
            this.grdLockUpParentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpParentId_KeyDown);
            // 
            // grdLockUpParentView
            // 
            this.grdLockUpParentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpParentView.Name = "grdLockUpParentView";
            this.grdLockUpParentView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpParentView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraDepartmentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 257);
            this.ComponentName = "Danh mục phòng ban";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 12, 19, 16, 35, 43, 459);
            this.FormCaption = "danh mục phòng ban";
            this.KeyFieldName = "DepartmentId";
            this.Name = "FrmXtraDepartmentDetail";
            this.ParentName = "ParentId";
            this.Reference = "THÊM DANH MỤC PHÒNG BAN - ID ";
            this.TableCode = "Department";
            this.Text = "FrmXtraDepartmentDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDepartmentCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpParentId;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpParentView;
    }
}