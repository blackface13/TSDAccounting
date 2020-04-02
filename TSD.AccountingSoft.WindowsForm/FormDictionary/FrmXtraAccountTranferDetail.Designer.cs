namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraAccountTranferDetail
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountTranferCode = new DevExpress.XtraEditors.TextEdit();
            this.spinSortOrder = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboSideOfTranfer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.grdLookUpEditAccountSourceCode = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLookUpEditAccountSourceCodeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLookUpEditAccountDestinationCode = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLookUpEditAccountDestinationCodeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpReferentAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLookUpReferentAccountView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLookUpBudgetSource = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLookUpBudgetSourceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTranferCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSortOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSideOfTranfer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountSourceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountSourceCodeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountDestinationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountDestinationCodeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpReferentAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpReferentAccountView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetSourceView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(393, 282);
            this.btnSave.TabIndex = 11;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(469, 282);
            this.btnExit.TabIndex = 12;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 282);
            this.btnHelp.TabIndex = 13;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.grdLookUpBudgetSource);
            this.groupboxMain.Controls.Add(this.labelControl8);
            this.groupboxMain.Controls.Add(this.grdLookUpReferentAccount);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl16);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.cboType);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.spinSortOrder);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.txtAccountTranferCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.cboSideOfTranfer);
            this.groupboxMain.Controls.Add(this.grdLookUpEditAccountSourceCode);
            this.groupboxMain.Controls.Add(this.grdLookUpEditAccountDestinationCode);
            this.groupboxMain.Size = new System.Drawing.Size(530, 241);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã kết chuyển (*)";
            // 
            // txtAccountTranferCode
            // 
            this.txtAccountTranferCode.Location = new System.Drawing.Point(106, 24);
            this.txtAccountTranferCode.Name = "txtAccountTranferCode";
            this.txtAccountTranferCode.Size = new System.Drawing.Size(160, 20);
            this.txtAccountTranferCode.TabIndex = 1;
            // 
            // spinSortOrder
            // 
            this.spinSortOrder.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSortOrder.Location = new System.Drawing.Point(363, 24);
            this.spinSortOrder.Name = "spinSortOrder";
            this.spinSortOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinSortOrder.Properties.IsFloatValue = false;
            this.spinSortOrder.Properties.Mask.EditMask = "N00";
            this.spinSortOrder.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinSortOrder.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSortOrder.Size = new System.Drawing.Size(80, 20);
            this.spinSortOrder.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(273, 27);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "&Số thứ tự";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(273, 53);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(84, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Đế&n tài khoản (*)";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 53);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "&Từ tài khoản (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "&Bên kết chuyển";
            // 
            // cboSideOfTranfer
            // 
            this.cboSideOfTranfer.EditValue = "Cả hai bên";
            this.cboSideOfTranfer.Location = new System.Drawing.Point(106, 128);
            this.cboSideOfTranfer.Name = "cboSideOfTranfer";
            this.cboSideOfTranfer.Properties.AutoHeight = false;
            this.cboSideOfTranfer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSideOfTranfer.Properties.Items.AddRange(new object[] {
            "Cả hai bên",
            "Bên nợ",
            "Bên có"});
            this.cboSideOfTranfer.Properties.PopupSizeable = true;
            this.cboSideOfTranfer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSideOfTranfer.Size = new System.Drawing.Size(417, 20);
            this.cboSideOfTranfer.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 105);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "&Loại kết chuyển";
            // 
            // cboType
            // 
            this.cboType.EditValue = "Xác định kết quả hoạt động";
            this.cboType.Location = new System.Drawing.Point(106, 102);
            this.cboType.Name = "cboType";
            this.cboType.Properties.AutoHeight = false;
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.Items.AddRange(new object[] {
            "Xác định kết quả hoạt động",
            "Kết chuyển cuối năm"});
            this.cboType.Properties.PopupSizeable = true;
            this.cboType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboType.Size = new System.Drawing.Size(417, 20);
            this.cboType.TabIndex = 7;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(106, 154);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(417, 77);
            this.memoDescription.TabIndex = 9;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(9, 157);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(40, 13);
            this.labelControl16.TabIndex = 12;
            this.labelControl16.Text = "&Diễn giải";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 257);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 10;
            // 
            // grdLookUpEditAccountSourceCode
            // 
            this.grdLookUpEditAccountSourceCode.Location = new System.Drawing.Point(106, 50);
            this.grdLookUpEditAccountSourceCode.Name = "grdLookUpEditAccountSourceCode";
            this.grdLookUpEditAccountSourceCode.Properties.AutoHeight = false;
            this.grdLookUpEditAccountSourceCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditAccountSourceCode.Properties.NullText = "";
            this.grdLookUpEditAccountSourceCode.Properties.PopupFormSize = new System.Drawing.Size(450, 0);
            this.grdLookUpEditAccountSourceCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditAccountSourceCode.Properties.View = this.grdLookUpEditAccountSourceCodeView;
            this.grdLookUpEditAccountSourceCode.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditAccountSourceCode_Properties_ButtonClick);
            this.grdLookUpEditAccountSourceCode.Size = new System.Drawing.Size(160, 20);
            this.grdLookUpEditAccountSourceCode.TabIndex = 3;
            this.grdLookUpEditAccountSourceCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditAccountSourceCode_KeyDown);
            // 
            // grdLookUpEditAccountSourceCodeView
            // 
            this.grdLookUpEditAccountSourceCodeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLookUpEditAccountSourceCodeView.Name = "grdLookUpEditAccountSourceCodeView";
            this.grdLookUpEditAccountSourceCodeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLookUpEditAccountSourceCodeView.OptionsView.ShowGroupPanel = false;
            // 
            // grdLookUpEditAccountDestinationCode
            // 
            this.grdLookUpEditAccountDestinationCode.Location = new System.Drawing.Point(363, 50);
            this.grdLookUpEditAccountDestinationCode.Name = "grdLookUpEditAccountDestinationCode";
            this.grdLookUpEditAccountDestinationCode.Properties.AutoHeight = false;
            this.grdLookUpEditAccountDestinationCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditAccountDestinationCode.Properties.NullText = "";
            this.grdLookUpEditAccountDestinationCode.Properties.PopupFormSize = new System.Drawing.Size(450, 0);
            this.grdLookUpEditAccountDestinationCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditAccountDestinationCode.Properties.View = this.grdLookUpEditAccountDestinationCodeView;
            this.grdLookUpEditAccountDestinationCode.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditAccountDestinationCode_Properties_ButtonClick);
            this.grdLookUpEditAccountDestinationCode.Size = new System.Drawing.Size(160, 20);
            this.grdLookUpEditAccountDestinationCode.TabIndex = 4;
            this.grdLookUpEditAccountDestinationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditAccountDestinationCode_KeyDown);
            // 
            // grdLookUpEditAccountDestinationCodeView
            // 
            this.grdLookUpEditAccountDestinationCodeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLookUpEditAccountDestinationCodeView.Name = "grdLookUpEditAccountDestinationCodeView";
            this.grdLookUpEditAccountDestinationCodeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLookUpEditAccountDestinationCodeView.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 79);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "TK tham chiếu";
            // 
            // grdLookUpReferentAccount
            // 
            this.grdLookUpReferentAccount.Location = new System.Drawing.Point(106, 76);
            this.grdLookUpReferentAccount.Name = "grdLookUpReferentAccount";
            this.grdLookUpReferentAccount.Properties.AutoHeight = false;
            this.grdLookUpReferentAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpReferentAccount.Properties.NullText = "";
            this.grdLookUpReferentAccount.Properties.PopupFormSize = new System.Drawing.Size(450, 0);
            this.grdLookUpReferentAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpReferentAccount.Properties.View = this.grdLookUpReferentAccountView;
            this.grdLookUpReferentAccount.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpEditAccountSourceCode_Properties_ButtonClick);
            this.grdLookUpReferentAccount.Size = new System.Drawing.Size(160, 20);
            this.grdLookUpReferentAccount.TabIndex = 5;
            // 
            // grdLookUpReferentAccountView
            // 
            this.grdLookUpReferentAccountView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLookUpReferentAccountView.Name = "grdLookUpReferentAccountView";
            this.grdLookUpReferentAccountView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLookUpReferentAccountView.OptionsView.ShowGroupPanel = false;
            // 
            // grdLookUpBudgetSource
            // 
            this.grdLookUpBudgetSource.Location = new System.Drawing.Point(363, 76);
            this.grdLookUpBudgetSource.Name = "grdLookUpBudgetSource";
            this.grdLookUpBudgetSource.Properties.AutoHeight = false;
            this.grdLookUpBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Thêm mới", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.grdLookUpBudgetSource.Properties.NullText = "";
            this.grdLookUpBudgetSource.Properties.PopupFormSize = new System.Drawing.Size(450, 0);
            this.grdLookUpBudgetSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpBudgetSource.Properties.View = this.grdLookUpBudgetSourceView;
            this.grdLookUpBudgetSource.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdLookUpBudgetSource_Properties_ButtonClick);
            this.grdLookUpBudgetSource.Size = new System.Drawing.Size(160, 20);
            this.grdLookUpBudgetSource.TabIndex = 6;
            // 
            // grdLookUpBudgetSourceView
            // 
            this.grdLookUpBudgetSourceView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLookUpBudgetSourceView.Name = "grdLookUpBudgetSourceView";
            this.grdLookUpBudgetSourceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLookUpBudgetSourceView.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(273, 79);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Nguồn vốn";
            // 
            // FrmXtraAccountTranferDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 316);
            this.ComponentName = "Tài khoản kết chuyển";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2020, 3, 12, 8, 43, 11, 956);
            this.FormCaption = "tài khoản kết chuyển";
            this.Name = "FrmXtraAccountTranferDetail";
            this.Reference = "THÊM TÀI KHOẢN KẾT CHUYỂN - ID ";
            this.Text = "FrmXtraAccountTranfer";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTranferCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSortOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSideOfTranfer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountSourceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountSourceCodeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountDestinationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditAccountDestinationCodeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpReferentAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpReferentAccountView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetSourceView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtAccountTranferCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinSortOrder;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cboSideOfTranfer;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookUpEditAccountSourceCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLookUpEditAccountSourceCodeView;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookUpEditAccountDestinationCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLookUpEditAccountDestinationCodeView;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookUpReferentAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLookUpReferentAccountView;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookUpBudgetSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLookUpBudgetSourceView;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}