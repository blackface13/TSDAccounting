namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraActivityDetail
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
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtActivityCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtActivityName = new DevExpress.XtraEditors.TextEdit();
            this.gridParentID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridParentIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivityCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivityName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridParentIDView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 143);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 143);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 143);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.gridParentID);
            this.groupboxMain.Controls.Add(this.txtActivityName);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtActivityCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Size = new System.Drawing.Size(466, 103);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActive.Location = new System.Drawing.Point(7, 118);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Được sử dụng";
            this.chkActive.Size = new System.Drawing.Size(120, 19);
            this.chkActive.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(99, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã hoạt động SN (*)";
            // 
            // txtActivityCode
            // 
            this.txtActivityCode.Location = new System.Drawing.Point(118, 24);
            this.txtActivityCode.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtActivityCode.Name = "txtActivityCode";
            this.txtActivityCode.Size = new System.Drawing.Size(154, 20);
            this.txtActivityCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tên hoạt động SN (*)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(97, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Thuộc hoạt động SN";
            // 
            // txtActivityName
            // 
            this.txtActivityName.Location = new System.Drawing.Point(118, 50);
            this.txtActivityName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.Size = new System.Drawing.Size(339, 20);
            this.txtActivityName.TabIndex = 4;
            // 
            // gridParentID
            // 
            this.gridParentID.Location = new System.Drawing.Point(118, 76);
            this.gridParentID.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.gridParentID.Name = "gridParentID";
            this.gridParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridParentID.Properties.NullText = "";
            this.gridParentID.Properties.View = this.gridParentIDView;
            this.gridParentID.Size = new System.Drawing.Size(339, 20);
            this.gridParentID.TabIndex = 5;
            // 
            // gridParentIDView
            // 
            this.gridParentIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridParentIDView.Name = "gridParentIDView";
            this.gridParentIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridParentIDView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraActivityDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 177);
            this.Controls.Add(this.chkActive);
            this.EventTime = new System.DateTime(2019, 11, 25, 11, 43, 54, 547);
            this.Name = "FrmXtraActivityDetail";
            this.Text = "FrmXtraActivityDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivityCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActivityName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridParentIDView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit gridParentID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridParentIDView;
        private DevExpress.XtraEditors.TextEdit txtActivityName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtActivityCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkActive;
    }
}