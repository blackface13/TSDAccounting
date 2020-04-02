namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraProjectDetail
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
            this.txtProjectCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtForeignName = new DevExpress.XtraEditors.TextEdit();
            this.grdLockUpParentId = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpParentIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForeignName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentIdView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.txtForeignName);
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtProjectName);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtProjectCode);
            this.groupboxMain.Controls.Add(this.grdLockUpParentId);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 207);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 247);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 247);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 247);
            this.btnHelp.TabIndex = 4;
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(89, 24);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(160, 20);
            this.txtProjectCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã dự án (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên dự án (*)";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(89, 50);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(368, 20);
            this.txtProjectName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 105);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Thuộc dự án";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 131);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "&Diễn giải";
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(89, 128);
            this.memoDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(368, 74);
            this.memoDescription.TabIndex = 9;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 222);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(212, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 79);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Tên nước ngoài";
            // 
            // txtForeignName
            // 
            this.txtForeignName.Location = new System.Drawing.Point(89, 76);
            this.txtForeignName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtForeignName.Name = "txtForeignName";
            this.txtForeignName.Size = new System.Drawing.Size(368, 20);
            this.txtForeignName.TabIndex = 5;
            // 
            // grdLockUpParentId
            // 
            this.grdLockUpParentId.Location = new System.Drawing.Point(89, 102);
            this.grdLockUpParentId.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.grdLockUpParentId.Name = "grdLockUpParentId";
            this.grdLockUpParentId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLockUpParentId.Properties.NullText = "";
            this.grdLockUpParentId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpParentId.Properties.View = this.grdLockUpParentIdView;
            this.grdLockUpParentId.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLockUpParentId_Properties_ButtonClick);
            this.grdLockUpParentId.Size = new System.Drawing.Size(368, 20);
            this.grdLockUpParentId.TabIndex = 7;
            this.grdLockUpParentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpParentId_KeyDown);
            // 
            // grdLockUpParentIdView
            // 
            this.grdLockUpParentIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpParentIdView.Name = "grdLockUpParentIdView";
            this.grdLockUpParentIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpParentIdView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraProjectDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 281);
            this.ComponentName = "Danh mục dự án";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 8, 13, 41, 13, 597);
            this.FormCaption = "danh mục dự án";
            this.KeyFieldName = "ProjectId";
            this.Name = "FrmXtraProjectDetail";
            this.ParentName = "ParentId";
            this.Reference = "THÊM DANH MỤC DỰ ÁN - ID ";
            this.TableCode = "Project";
            this.Text = "FrmXtraProjectDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForeignName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentIdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtProjectCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtForeignName;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpParentId;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpParentIdView;
    }
}