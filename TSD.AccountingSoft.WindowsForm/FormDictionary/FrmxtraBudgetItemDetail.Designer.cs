namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmxtraBudgetItemDetail
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
            this.cboBudgetItemType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkIsFixedItem = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsNoAllocate = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsOrganItem = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsExpandItem = new DevExpress.XtraEditors.CheckEdit();
            this.radIsReceipt = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtForeignName = new DevExpress.XtraEditors.TextEdit();
            this.txtBudgetItemName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBudgetItemCode = new DevExpress.XtraEditors.TextEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.grdLookUpParentID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLookUpParentIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLookUpBudgetGroupID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdLookUpBudgetGroupIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkIsShowOnVoucher = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsFixedItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsNoAllocate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsOrganItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsExpandItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radIsReceipt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForeignName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpParentIDView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetGroupIDView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowOnVoucher.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.txtRate);
            this.groupboxMain.Controls.Add(this.cboBudgetItemType);
            this.groupboxMain.Controls.Add(this.chkIsFixedItem);
            this.groupboxMain.Controls.Add(this.chkIsNoAllocate);
            this.groupboxMain.Controls.Add(this.chkIsOrganItem);
            this.groupboxMain.Controls.Add(this.chkIsExpandItem);
            this.groupboxMain.Controls.Add(this.radIsReceipt);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtForeignName);
            this.groupboxMain.Controls.Add(this.txtBudgetItemName);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtBudgetItemCode);
            this.groupboxMain.Controls.Add(this.grdLookUpParentID);
            this.groupboxMain.Controls.Add(this.grdLookUpBudgetGroupID);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 344);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 384);
            this.btnSave.TabIndex = 15;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 384);
            this.btnExit.TabIndex = 16;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 384);
            this.btnHelp.TabIndex = 17;
            // 
            // cboBudgetItemType
            // 
            this.cboBudgetItemType.Location = new System.Drawing.Point(89, 102);
            this.cboBudgetItemType.Name = "cboBudgetItemType";
            this.cboBudgetItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetItemType.Properties.Items.AddRange(new object[] {
            "Nhóm",
            "Tiểu nhóm",
            "Mục",
            "Tiểu Mục"});
            this.cboBudgetItemType.Size = new System.Drawing.Size(368, 20);
            this.cboBudgetItemType.TabIndex = 4;
            this.cboBudgetItemType.SelectedIndexChanged += new System.EventHandler(this.cboBudgetItemType_SelectedIndexChanged);
            // 
            // chkIsFixedItem
            // 
            this.chkIsFixedItem.Location = new System.Drawing.Point(86, 294);
            this.chkIsFixedItem.Name = "chkIsFixedItem";
            this.chkIsFixedItem.Properties.Caption = "Là mục k&hoán chi";
            this.chkIsFixedItem.Size = new System.Drawing.Size(115, 19);
            this.chkIsFixedItem.TabIndex = 11;
            // 
            // chkIsNoAllocate
            // 
            this.chkIsNoAllocate.Location = new System.Drawing.Point(86, 319);
            this.chkIsNoAllocate.Name = "chkIsNoAllocate";
            this.chkIsNoAllocate.Properties.Caption = "Là chi phí không tính vào giá trị phân &bổ";
            this.chkIsNoAllocate.Size = new System.Drawing.Size(219, 19);
            this.chkIsNoAllocate.TabIndex = 12;
            // 
            // chkIsOrganItem
            // 
            this.chkIsOrganItem.Location = new System.Drawing.Point(86, 269);
            this.chkIsOrganItem.Name = "chkIsOrganItem";
            this.chkIsOrganItem.Properties.Caption = "Là mục thu &phân phối cho quỹ cơ quan";
            this.chkIsOrganItem.Size = new System.Drawing.Size(211, 19);
            this.chkIsOrganItem.TabIndex = 10;
            // 
            // chkIsExpandItem
            // 
            this.chkIsExpandItem.Location = new System.Drawing.Point(86, 244);
            this.chkIsExpandItem.Name = "chkIsExpandItem";
            this.chkIsExpandItem.Properties.Caption = "Là mục mở rộng &không thuộc MLNS  do Bộ tài chính ban hành";
            this.chkIsExpandItem.Size = new System.Drawing.Size(315, 19);
            this.chkIsExpandItem.TabIndex = 9;
            // 
            // radIsReceipt
            // 
            this.radIsReceipt.Location = new System.Drawing.Point(89, 180);
            this.radIsReceipt.Name = "radIsReceipt";
            this.radIsReceipt.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Thuộc mục thu"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Thuộc mục chi")});
            this.radIsReceipt.Size = new System.Drawing.Size(368, 32);
            this.radIsReceipt.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 157);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 48;
            this.labelControl5.Text = "Nhó&m MLNS";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 131);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 13);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Là mục &con của";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 13);
            this.labelControl3.TabIndex = 50;
            this.labelControl3.Text = "&Loại MLNS (*)";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 79);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 13);
            this.labelControl7.TabIndex = 46;
            this.labelControl7.Text = "Tên &nước ngoài";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 47;
            this.labelControl2.Text = "&Tên MLNS (*)";
            // 
            // txtForeignName
            // 
            this.txtForeignName.Location = new System.Drawing.Point(89, 76);
            this.txtForeignName.Name = "txtForeignName";
            this.txtForeignName.Size = new System.Drawing.Size(368, 20);
            this.txtForeignName.TabIndex = 3;
            // 
            // txtBudgetItemName
            // 
            this.txtBudgetItemName.EditValue = "";
            this.txtBudgetItemName.Location = new System.Drawing.Point(89, 50);
            this.txtBudgetItemName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtBudgetItemName.Name = "txtBudgetItemName";
            this.txtBudgetItemName.Size = new System.Drawing.Size(368, 20);
            this.txtBudgetItemName.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 44;
            this.labelControl1.Text = "&Mã MLNS (*)";
            // 
            // txtBudgetItemCode
            // 
            this.txtBudgetItemCode.EditValue = "";
            this.txtBudgetItemCode.Location = new System.Drawing.Point(89, 24);
            this.txtBudgetItemCode.Name = "txtBudgetItemCode";
            this.txtBudgetItemCode.Size = new System.Drawing.Size(160, 20);
            this.txtBudgetItemCode.TabIndex = 1;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 359);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được &sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 13;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 221);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(74, 13);
            this.labelControl6.TabIndex = 52;
            this.labelControl6.Text = "Tỷ lệ nộp NSNN";
            // 
            // txtRate
            // 
            this.txtRate.EditValue = ((short)(0));
            this.txtRate.Location = new System.Drawing.Point(89, 218);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Mask.EditMask = "f2";
            this.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRate.Size = new System.Drawing.Size(80, 20);
            this.txtRate.TabIndex = 8;
            // 
            // grdLookUpParentID
            // 
            this.grdLookUpParentID.Location = new System.Drawing.Point(89, 128);
            this.grdLookUpParentID.Name = "grdLookUpParentID";
            this.grdLookUpParentID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLookUpParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLookUpParentID.Properties.NullText = "";
            this.grdLookUpParentID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpParentID.Properties.View = this.grdLookUpParentIDView;
            this.grdLookUpParentID.Size = new System.Drawing.Size(368, 20);
            this.grdLookUpParentID.TabIndex = 5;
            this.grdLookUpParentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpParentID_KeyDown);
            // 
            // grdLookUpParentIDView
            // 
            this.grdLookUpParentIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLookUpParentIDView.Name = "grdLookUpParentIDView";
            this.grdLookUpParentIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLookUpParentIDView.OptionsView.ShowGroupPanel = false;
            // 
            // grdLookUpBudgetGroupID
            // 
            this.grdLookUpBudgetGroupID.Location = new System.Drawing.Point(89, 154);
            this.grdLookUpBudgetGroupID.Name = "grdLookUpBudgetGroupID";
            this.grdLookUpBudgetGroupID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLookUpBudgetGroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLookUpBudgetGroupID.Properties.NullText = "";
            this.grdLookUpBudgetGroupID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpBudgetGroupID.Properties.View = this.grdLookUpBudgetGroupIDView;
            this.grdLookUpBudgetGroupID.Size = new System.Drawing.Size(368, 20);
            this.grdLookUpBudgetGroupID.TabIndex = 6;
            this.grdLookUpBudgetGroupID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpBudgetGroupID_KeyDown);
            // 
            // grdLookUpBudgetGroupIDView
            // 
            this.grdLookUpBudgetGroupIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdLookUpBudgetGroupIDView.Name = "grdLookUpBudgetGroupIDView";
            this.grdLookUpBudgetGroupIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLookUpBudgetGroupIDView.OptionsView.ShowGroupPanel = false;
            // 
            // chkIsShowOnVoucher
            // 
            this.chkIsShowOnVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsShowOnVoucher.EditValue = true;
            this.chkIsShowOnVoucher.Location = new System.Drawing.Point(109, 359);
            this.chkIsShowOnVoucher.Name = "chkIsShowOnVoucher";
            this.chkIsShowOnVoucher.Properties.Caption = "Được hiển thị trên chứng từ";
            this.chkIsShowOnVoucher.Size = new System.Drawing.Size(161, 19);
            this.chkIsShowOnVoucher.TabIndex = 14;
            // 
            // FrmxtraBudgetItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 418);
            this.ComponentName = "Danh mục Mục - Tiểu Mục";
            this.Controls.Add(this.chkIsShowOnVoucher);
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 12, 3, 11, 13, 28, 203);
            this.FormCaption = "Danh mục Mục - Tiểu Mục";
            this.KeyFieldName = "BudgetItemId";
            this.Name = "FrmxtraBudgetItemDetail";
            this.ParentName = "ParentId";
            this.Reference = "THÊM DANH MỤC MỤC - TIỂU MỤC - ID ";
            this.Text = "FrmExtraBudgetItemDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.chkIsShowOnVoucher, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsFixedItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsNoAllocate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsOrganItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsExpandItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radIsReceipt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForeignName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpParentIDView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetGroupIDView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowOnVoucher.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboBudgetItemType;
        private DevExpress.XtraEditors.CheckEdit chkIsFixedItem;
        private DevExpress.XtraEditors.CheckEdit chkIsNoAllocate;
        private DevExpress.XtraEditors.CheckEdit chkIsOrganItem;
        private DevExpress.XtraEditors.CheckEdit chkIsExpandItem;
        private DevExpress.XtraEditors.RadioGroup radIsReceipt;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtForeignName;
        private DevExpress.XtraEditors.TextEdit txtBudgetItemName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBudgetItemCode;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookUpParentID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLookUpParentIDView;
        private DevExpress.XtraEditors.GridLookUpEdit grdLookUpBudgetGroupID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLookUpBudgetGroupIDView;
        private DevExpress.XtraEditors.CheckEdit chkIsShowOnVoucher;
    }
}