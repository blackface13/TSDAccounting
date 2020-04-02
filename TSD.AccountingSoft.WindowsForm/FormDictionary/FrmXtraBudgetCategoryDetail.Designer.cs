namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraBudgetCategoryDetail
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
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtBudgetCategoryName = new DevExpress.XtraEditors.TextEdit();
            this.txtBudgetCategoryCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdLockUpParentID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpParentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetCategoryCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.txtBudgetCategoryName);
            this.groupboxMain.Controls.Add(this.txtBudgetCategoryCode);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.grdLockUpParentID);
            this.groupboxMain.Location = new System.Drawing.Point(8, 8);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(384, 193);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(236, 232);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(317, 232);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 232);
            this.btnHelp.TabIndex = 4;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(5, 208);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(131, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(104, 96);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(272, 88);
            this.memoDescription.TabIndex = 7;
            // 
            // txtBudgetCategoryName
            // 
            this.txtBudgetCategoryName.Location = new System.Drawing.Point(104, 48);
            this.txtBudgetCategoryName.Name = "txtBudgetCategoryName";
            this.txtBudgetCategoryName.Size = new System.Drawing.Size(272, 20);
            this.txtBudgetCategoryName.TabIndex = 3;
            // 
            // txtBudgetCategoryCode
            // 
            this.txtBudgetCategoryCode.Location = new System.Drawing.Point(104, 24);
            this.txtBudgetCategoryCode.Name = "txtBudgetCategoryCode";
            this.txtBudgetCategoryCode.Size = new System.Drawing.Size(128, 20);
            this.txtBudgetCategoryCode.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 99);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "&Diễn giải";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "&Là mục con của";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên loại khoản (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã loại khoản (*)";
            // 
            // grdLockUpParentID
            // 
            this.grdLockUpParentID.Location = new System.Drawing.Point(104, 72);
            this.grdLockUpParentID.Name = "grdLockUpParentID";
            this.grdLockUpParentID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLockUpParentID.Properties.NullText = "";
            this.grdLockUpParentID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpParentID.Properties.View = this.grdLockUpParentView;
            this.grdLockUpParentID.Size = new System.Drawing.Size(272, 20);
            this.grdLockUpParentID.TabIndex = 5;
            this.grdLockUpParentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpParentID_KeyDown);
            // 
            // grdLockUpParentView
            // 
            this.grdLockUpParentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpParentView.Name = "grdLockUpParentView";
            this.grdLockUpParentView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpParentView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraBudgetCategoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 263);
            this.ComponentName = "Danh mục loại khoản";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 7, 9, 2, 7, 225);
            this.FormCaption = "danh mục loại khoản";
            this.Name = "FrmXtraBudgetCategoryDetail";
            this.Reference = "THÊM DANH MỤC LOẠI KHOẢN - ID ";
            this.Text = "FrmXtraBudgetCategoryDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetCategoryCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.TextEdit txtBudgetCategoryName;
        private DevExpress.XtraEditors.TextEdit txtBudgetCategoryCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpParentID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpParentView;
    }
}