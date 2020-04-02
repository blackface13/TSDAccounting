namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraEmployeeLeasingDetail
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
            this.txtEmployeeLeasingCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeLeasingName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtJobCandidate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.dtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeLeasingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeLeasingName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCandidate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(405, 252);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(481, 252);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 252);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl16);
            this.groupboxMain.Controls.Add(this.dtEndDate);
            this.groupboxMain.Controls.Add(this.labelControl18);
            this.groupboxMain.Controls.Add(this.dtStartDate);
            this.groupboxMain.Controls.Add(this.labelControl17);
            this.groupboxMain.Controls.Add(this.txtJobCandidate);
            this.groupboxMain.Controls.Add(this.labelControl9);
            this.groupboxMain.Controls.Add(this.txtEmployeeLeasingName);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtEmployeeLeasingCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(542, 212);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // txtEmployeeLeasingCode
            // 
            this.txtEmployeeLeasingCode.Location = new System.Drawing.Point(111, 24);
            this.txtEmployeeLeasingCode.Name = "txtEmployeeLeasingCode";
            this.txtEmployeeLeasingCode.Size = new System.Drawing.Size(160, 20);
            this.txtEmployeeLeasingCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã nhân viên (*)";
            // 
            // txtEmployeeLeasingName
            // 
            this.txtEmployeeLeasingName.Location = new System.Drawing.Point(111, 50);
            this.txtEmployeeLeasingName.Name = "txtEmployeeLeasingName";
            this.txtEmployeeLeasingName.Size = new System.Drawing.Size(422, 20);
            this.txtEmployeeLeasingName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên nhân viên (*)";
            // 
            // txtJobCandidate
            // 
            this.txtJobCandidate.Location = new System.Drawing.Point(111, 76);
            this.txtJobCandidate.Name = "txtJobCandidate";
            this.txtJobCandidate.Size = new System.Drawing.Size(422, 20);
            this.txtJobCandidate.TabIndex = 5;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 79);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 4;
            this.labelControl9.Text = "&Chức vụ";
            // 
            // dtEndDate
            // 
            this.dtEndDate.EditValue = new System.DateTime(2014, 2, 28, 14, 7, 10, 0);
            this.dtEndDate.Location = new System.Drawing.Point(373, 102);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndDate.Properties.Mask.BeepOnError = true;
            this.dtEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEndDate.Size = new System.Drawing.Size(160, 20);
            this.dtEndDate.TabIndex = 9;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(278, 105);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(89, 13);
            this.labelControl18.TabIndex = 8;
            this.labelControl18.Text = "Ngày hết nhiệm kỳ";
            // 
            // dtStartDate
            // 
            this.dtStartDate.EditValue = new System.DateTime(2014, 2, 28, 14, 7, 10, 0);
            this.dtStartDate.Location = new System.Drawing.Point(111, 102);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartDate.Properties.Mask.BeepOnError = true;
            this.dtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStartDate.Size = new System.Drawing.Size(160, 20);
            this.dtStartDate.TabIndex = 7;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(9, 105);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(96, 13);
            this.labelControl17.TabIndex = 6;
            this.labelControl17.Text = "Ngày nhận công tác";
            // 
            // memoDescription
            // 
            this.memoDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoDescription.Location = new System.Drawing.Point(111, 128);
            this.memoDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(422, 79);
            this.memoDescription.TabIndex = 11;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(9, 131);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(27, 13);
            this.labelControl16.TabIndex = 10;
            this.labelControl16.Text = "Mô tả";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 227);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(100, 19);
            this.chkIsActive.TabIndex = 4;
            // 
            // FrmXtraEmployeeLeasingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 286);
            this.ComponentName = "Nhân viên ";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 8, 16, 57, 29, 480);
            this.FormCaption = "nhân viên ";
            this.Name = "FrmXtraEmployeeLeasingDetail";
            this.Reference = "THÊM NHÂN VIÊN  - ID ";
            this.TableCode = "EmployeeLeasing";
            this.Text = "FrmXtraEmployeeLeasingsDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeLeasingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeLeasingName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobCandidate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtEmployeeLeasingCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEmployeeLeasingName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtJobCandidate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit dtEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.DateEdit dtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}