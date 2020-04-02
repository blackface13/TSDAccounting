namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraBudgetSourceDetail
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
            this.txtBudgetSourceName = new DevExpress.XtraEditors.TextEdit();
            this.txtBudgetSourceCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsExpense = new DevExpress.XtraEditors.CheckEdit();
            this.rndIsFund = new DevExpress.XtraEditors.RadioGroup();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboAllocation = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboAutonomyBudgetType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.grdLockUpParentID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpParentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLockUpAccountID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpAccountView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLockUpBudgetItemID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLockUpBudgetItemView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbbBudgetCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetSourceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetSourceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsExpense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndIsFund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAllocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAutonomyBudgetType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpAccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpAccountView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpBudgetItemID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpBudgetItemView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbBudgetCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.cbbBudgetCode);
            this.groupboxMain.Controls.Add(this.labelControl10);
            this.groupboxMain.Controls.Add(this.cboAutonomyBudgetType);
            this.groupboxMain.Controls.Add(this.labelControl9);
            this.groupboxMain.Controls.Add(this.cboAllocation);
            this.groupboxMain.Controls.Add(this.chkIsExpense);
            this.groupboxMain.Controls.Add(this.cboType);
            this.groupboxMain.Controls.Add(this.rndIsFund);
            this.groupboxMain.Controls.Add(this.txtBudgetSourceName);
            this.groupboxMain.Controls.Add(this.txtBudgetSourceCode);
            this.groupboxMain.Controls.Add(this.labelControl8);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.grdLockUpParentID);
            this.groupboxMain.Controls.Add(this.grdLockUpAccountID);
            this.groupboxMain.Controls.Add(this.grdLockUpBudgetItemID);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(515, 230);
            this.groupboxMain.TabIndex = 1;
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(368, 271);
            this.btnSave.TabIndex = 12;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(450, 271);
            this.btnExit.TabIndex = 13;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 271);
            this.btnHelp.TabIndex = 14;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(6, 245);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(508, 19);
            this.chkIsActive.TabIndex = 11;
            // 
            // txtBudgetSourceName
            // 
            this.txtBudgetSourceName.Location = new System.Drawing.Point(104, 48);
            this.txtBudgetSourceName.Name = "txtBudgetSourceName";
            this.txtBudgetSourceName.Size = new System.Drawing.Size(402, 20);
            this.txtBudgetSourceName.TabIndex = 2;
            // 
            // txtBudgetSourceCode
            // 
            this.txtBudgetSourceCode.Location = new System.Drawing.Point(104, 24);
            this.txtBudgetSourceCode.Name = "txtBudgetSourceCode";
            this.txtBudgetSourceCode.Size = new System.Drawing.Size(152, 20);
            this.txtBudgetSourceCode.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "&Nguồn vốn cha";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên nguồn vốn (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã nguồn vốn (*)";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Loại nguồn vốn";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(264, 101);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "N&hóm";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 180);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(61, 13);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "&Loại phân bổ";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(8, 371);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(75, 13);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "&Phân bổ từ mục";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(8, 153);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(33, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "T&K quỹ";
            // 
            // chkIsExpense
            // 
            this.chkIsExpense.Location = new System.Drawing.Point(6, 202);
            this.chkIsExpense.Name = "chkIsExpense";
            this.chkIsExpense.Properties.Caption = "Là nguồn tiết kiệm chi khi NSD có nhu cầu";
            this.chkIsExpense.Size = new System.Drawing.Size(500, 19);
            this.chkIsExpense.TabIndex = 10;
            // 
            // rndIsFund
            // 
            this.rndIsFund.EditValue = true;
            this.rndIsFund.Location = new System.Drawing.Point(104, 98);
            this.rndIsFund.Name = "rndIsFund";
            this.rndIsFund.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Ngân sách "),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Quỹ")});
            this.rndIsFund.Size = new System.Drawing.Size(152, 23);
            this.rndIsFund.TabIndex = 4;
            this.rndIsFund.SelectedIndexChanged += new System.EventHandler(this.rndIsFund_SelectedIndexChanged);
            // 
            // cboType
            // 
            this.cboType.EditValue = "Vốn trong nước";
            this.cboType.Location = new System.Drawing.Point(359, 98);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.Items.AddRange(new object[] {
            "Vốn trong nước",
            "Vốn ngoài nước"});
            this.cboType.Size = new System.Drawing.Size(147, 20);
            this.cboType.TabIndex = 5;
            // 
            // cboAllocation
            // 
            this.cboAllocation.EditValue = "Phân bổ đầy đủ";
            this.cboAllocation.Location = new System.Drawing.Point(104, 176);
            this.cboAllocation.Name = "cboAllocation";
            this.cboAllocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAllocation.Properties.Items.AddRange(new object[] {
            "Phân bổ đầy đủ",
            "Phân bổ sau khi trừ chi phí không tính vào giá trị phân bổ"});
            this.cboAllocation.Size = new System.Drawing.Size(402, 20);
            this.cboAllocation.TabIndex = 9;
            // 
            // cboAutonomyBudgetType
            // 
            this.cboAutonomyBudgetType.EditValue = "";
            this.cboAutonomyBudgetType.Location = new System.Drawing.Point(104, 124);
            this.cboAutonomyBudgetType.Name = "cboAutonomyBudgetType";
            this.cboAutonomyBudgetType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAutonomyBudgetType.Properties.Items.AddRange(new object[] {
            "Tự chủ",
            "Không tự chủ"});
            this.cboAutonomyBudgetType.Size = new System.Drawing.Size(152, 20);
            this.cboAutonomyBudgetType.TabIndex = 6;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(8, 127);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(65, 13);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Tính chất &vốn";
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
            this.grdLockUpParentID.Size = new System.Drawing.Size(402, 20);
            this.grdLockUpParentID.TabIndex = 3;
            this.grdLockUpParentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpParentID_KeyDown);
            // 
            // grdLockUpParentView
            // 
            this.grdLockUpParentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpParentView.Name = "grdLockUpParentView";
            this.grdLockUpParentView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpParentView.OptionsView.ShowGroupPanel = false;
            // 
            // grdLockUpAccountID
            // 
            this.grdLockUpAccountID.Location = new System.Drawing.Point(104, 150);
            this.grdLockUpAccountID.Name = "grdLockUpAccountID";
            this.grdLockUpAccountID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpAccountID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLockUpAccountID.Properties.NullText = "";
            this.grdLockUpAccountID.Properties.PopupFormSize = new System.Drawing.Size(400, 0);
            this.grdLockUpAccountID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpAccountID.Properties.View = this.grdLockUpAccountView;
            this.grdLockUpAccountID.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLockUpAccountID_Properties_ButtonClick);
            this.grdLockUpAccountID.Size = new System.Drawing.Size(152, 20);
            this.grdLockUpAccountID.TabIndex = 8;
            this.grdLockUpAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpAccountID_KeyDown);
            // 
            // grdLockUpAccountView
            // 
            this.grdLockUpAccountView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpAccountView.Name = "grdLockUpAccountView";
            this.grdLockUpAccountView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpAccountView.OptionsView.ShowGroupPanel = false;
            // 
            // grdLockUpBudgetItemID
            // 
            this.grdLockUpBudgetItemID.Location = new System.Drawing.Point(104, 371);
            this.grdLockUpBudgetItemID.Name = "grdLockUpBudgetItemID";
            this.grdLockUpBudgetItemID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLockUpBudgetItemID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdLockUpBudgetItemID.Properties.NullText = "";
            this.grdLockUpBudgetItemID.Properties.PopupFormSize = new System.Drawing.Size(400, 0);
            this.grdLockUpBudgetItemID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLockUpBudgetItemID.Properties.View = this.grdLockUpBudgetItemView;
            this.grdLockUpBudgetItemID.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLockUpBudgetItemID_Properties_ButtonClick);
            this.grdLockUpBudgetItemID.Size = new System.Drawing.Size(152, 20);
            this.grdLockUpBudgetItemID.TabIndex = 11;
            this.grdLockUpBudgetItemID.EditValueChanged += new System.EventHandler(this.grdLockUpBudgetItemID_EditValueChanged);
            this.grdLockUpBudgetItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLockUpBudgetItemID_KeyDown);
            // 
            // grdLockUpBudgetItemView
            // 
            this.grdLockUpBudgetItemView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLockUpBudgetItemView.Name = "grdLockUpBudgetItemView";
            this.grdLockUpBudgetItemView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLockUpBudgetItemView.OptionsView.ShowGroupPanel = false;
            // 
            // cbbBudgetCode
            // 
            this.cbbBudgetCode.EditValue = "Cấp 3";
            this.cbbBudgetCode.Location = new System.Drawing.Point(359, 124);
            this.cbbBudgetCode.Name = "cbbBudgetCode";
            this.cbbBudgetCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbBudgetCode.Properties.Items.AddRange(new object[] {
            "Cấp 1",
            "Cấp 2",
            "Cấp 3"});
            this.cbbBudgetCode.Size = new System.Drawing.Size(147, 20);
            this.cbbBudgetCode.TabIndex = 7;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(264, 127);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(86, 13);
            this.labelControl10.TabIndex = 12;
            this.labelControl10.Text = "Mã cấp ngân sách";
            // 
            // FrmXtraBudgetSourceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 302);
            this.ComponentName = "Danh mục nguồn vốn";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 21, 9, 5, 8, 993);
            this.FormCaption = "Danh mục nguồn vốn";
            this.Name = "FrmXtraBudgetSourceDetail";
            this.Reference = "THÊM DANH MỤC NGUỒN VỐN - ID ";
            this.Text = "FrmXtraBudgetSourceDetail";
            this.Load += new System.EventHandler(this.FrmXtraBudgetSourceDetail_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetSourceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetSourceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsExpense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rndIsFund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAllocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAutonomyBudgetType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpParentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpAccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpAccountView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpBudgetItemID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLockUpBudgetItemView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbBudgetCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.TextEdit txtBudgetSourceName;
        private DevExpress.XtraEditors.TextEdit txtBudgetSourceCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckEdit chkIsExpense;
        private DevExpress.XtraEditors.RadioGroup rndIsFund;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.ComboBoxEdit cboAllocation;
        private DevExpress.XtraEditors.ComboBoxEdit cboAutonomyBudgetType;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpParentID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpParentView;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpAccountID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpAccountView;
        private DevExpress.XtraEditors.GridLookUpEdit grdLockUpBudgetItemID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLockUpBudgetItemView;
        private DevExpress.XtraEditors.ComboBoxEdit cbbBudgetCode;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}