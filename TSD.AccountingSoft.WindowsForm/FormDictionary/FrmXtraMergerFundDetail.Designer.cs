namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraMergerFundDetail
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
            this.txtMergerFundName = new DevExpress.XtraEditors.TextEdit();
            this.txtMergerFundCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdLockUpParentID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpParentIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMergerFundName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMergerFundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentIDView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.txtMergerFundName);
            this.groupboxMain.Controls.Add(this.txtMergerFundCode);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.grdLockUpParentID);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 186);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 226);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 226);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 226);
            this.btnHelp.TabIndex = 4;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.Location = new System.Drawing.Point(7, 201);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được &sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(131, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(116, 102);
            this.memoDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(341, 79);
            this.memoDescription.TabIndex = 7;
            // 
            // txtMergerFundName
            // 
            this.txtMergerFundName.Location = new System.Drawing.Point(116, 50);
            this.txtMergerFundName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtMergerFundName.Name = "txtMergerFundName";
            this.txtMergerFundName.Size = new System.Drawing.Size(341, 20);
            this.txtMergerFundName.TabIndex = 3;
            // 
            // txtMergerFundCode
            // 
            this.txtMergerFundCode.Location = new System.Drawing.Point(116, 24);
            this.txtMergerFundCode.Name = "txtMergerFundCode";
            this.txtMergerFundCode.Size = new System.Drawing.Size(160, 20);
            this.txtMergerFundCode.TabIndex = 1;
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
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "&Là mục con của";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên quỹ sát nhập (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã quỹ sát nhập (*)";
            // 
            // grdLockUpParentID
            // 
            this.grdLockUpParentID.Location = new System.Drawing.Point(116, 76);
            this.grdLockUpParentID.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.grdLockUpParentID.Name = "grdLockUpParentID";
            this.grdLockUpParentID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLockUpParentID.Properties.NullText = "";
            this.grdLockUpParentID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpParentID.Properties.View = this.grdLockUpParentIDView;
            this.grdLockUpParentID.Size = new System.Drawing.Size(341, 20);
            this.grdLockUpParentID.TabIndex = 5;
            // 
            // grdLockUpParentIDView
            // 
            this.grdLockUpParentIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpParentIDView.Name = "grdLockUpParentIDView";
            this.grdLockUpParentIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpParentIDView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraMergerFundDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 260);
            this.ComponentName = "Danh mục quỹ sát nhập";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2020, 3, 25, 20, 33, 35, 701);
            this.FormCaption = "Danh mục quỹ sát nhập";
            this.Name = "FrmXtraMergerFundDetail";
            this.Reference = "THÊM DANH MỤC QUỸ SÁT NHẬP - ID ";
            this.Text = "FrmXtraMergerFundDetail";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtMergerFundName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMergerFundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentIDView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.TextEdit txtMergerFundName;
        private DevExpress.XtraEditors.TextEdit txtMergerFundCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpParentID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpParentIDView;
    }
}