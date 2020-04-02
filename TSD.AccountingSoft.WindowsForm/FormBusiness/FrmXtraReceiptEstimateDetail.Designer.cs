using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraReceiptEstimateDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraReceiptEstimateDetail));
            this.btnExportData = new DevExpress.XtraEditors.SimpleButton();
            this.grdlookUpEditPlanTemplateListId = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdlookUpEditPlanTemplateListIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.spinYearOfPlaning = new DevExpress.XtraEditors.SpinEdit();
            this.memoJournalMemo = new DevExpress.XtraEditors.MemoEdit();
            this.btnUpdateTemplateListItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnExchangeRate = new DevExpress.XtraEditors.SimpleButton();
            this.txtExchangeRate = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupObject)).BeginInit();
            this.groupObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageToolbar24Collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExchangRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEditPlanTemplateListId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEditPlanTemplateListIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYearOfPlaning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoJournalMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            this.imageToobarCollection.Images.SetKeyName(0, "nav_blue_bottom.png");
            this.imageToobarCollection.Images.SetKeyName(1, "nav_blue_left.png");
            this.imageToobarCollection.Images.SetKeyName(2, "nav_blue_right.png");
            this.imageToobarCollection.Images.SetKeyName(3, "nav_blue_up.png");
            this.imageToobarCollection.Images.SetKeyName(4, "undo.png");
            this.imageToobarCollection.Images.SetKeyName(5, "order-add.png");
            this.imageToobarCollection.Images.SetKeyName(6, "order-delete.png");
            this.imageToobarCollection.Images.SetKeyName(7, "order-edit.png");
            this.imageToobarCollection.Images.SetKeyName(8, "order-print.png");
            this.imageToobarCollection.Images.SetKeyName(9, "help.png");
            this.imageToobarCollection.Images.SetKeyName(10, "stop.png");
            this.imageToobarCollection.Images.SetKeyName(11, "refresh_update.png");
            this.imageToobarCollection.Images.SetKeyName(12, "save.png");
            // 
            // groupVoucher
            // 
            this.groupVoucher.Location = new System.Drawing.Point(922, 56);
            this.groupVoucher.Size = new System.Drawing.Size(204, 103);
            // 
            // groupObject
            // 
            this.groupObject.Controls.Add(this.btnExportData);
            this.groupObject.Controls.Add(this.grdlookUpEditPlanTemplateListId);
            this.groupObject.Controls.Add(this.labelControl14);
            this.groupObject.Controls.Add(this.labelControl11);
            this.groupObject.Controls.Add(this.labelControl10);
            this.groupObject.Controls.Add(this.spinYearOfPlaning);
            this.groupObject.Controls.Add(this.memoJournalMemo);
            this.groupObject.Controls.Add(this.btnUpdateTemplateListItem);
            this.groupObject.Size = new System.Drawing.Size(910, 103);
            this.groupObject.Text = "Thông tin chung";
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl4, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl6, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.btnUpdateTemplateListItem, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.memoJournalMemo, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.spinYearOfPlaning, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl10, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl11, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl14, 0);
            this.groupObject.Controls.SetChildIndex(this.grdlookUpEditPlanTemplateListId, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.btnExportData, 0);
            // 
            // imageToolbar24Collection
            // 
            this.imageToolbar24Collection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToolbar24Collection.ImageStream")));
            this.imageToolbar24Collection.Images.SetKeyName(0, "close_window.png");
            this.imageToolbar24Collection.Images.SetKeyName(1, "help.png");
            this.imageToolbar24Collection.Images.SetKeyName(2, "nav_green_bottom.png");
            this.imageToolbar24Collection.Images.SetKeyName(3, "nav_green_left.png");
            this.imageToolbar24Collection.Images.SetKeyName(4, "nav_green_right.png");
            this.imageToolbar24Collection.Images.SetKeyName(5, "nav_green_top.png");
            this.imageToolbar24Collection.Images.SetKeyName(6, "order-add.png");
            this.imageToolbar24Collection.Images.SetKeyName(7, "order-delete.png");
            this.imageToolbar24Collection.Images.SetKeyName(8, "order-edit.png");
            this.imageToolbar24Collection.Images.SetKeyName(9, "order-print.png");
            this.imageToolbar24Collection.Images.SetKeyName(10, "refresh_update.png");
            this.imageToolbar24Collection.Images.SetKeyName(11, "save.png");
            this.imageToolbar24Collection.Images.SetKeyName(12, "undo.png");
            this.imageToolbar24Collection.Images.SetKeyName(13, "clipboard_copy.png");
            // 
            // dtRefDate
            // 
            this.dtRefDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 41, 591);
            this.dtRefDate.Location = new System.Drawing.Point(90, 76);
            this.dtRefDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Size = new System.Drawing.Size(105, 20);
            this.dtRefDate.TabIndex = 5;
            this.dtRefDate.EditValueChanged += new System.EventHandler(this.dtRefDate_EditValueChanged);
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 41, 591);
            this.dtPostDate.Location = new System.Drawing.Point(90, 50);
            this.dtPostDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Size = new System.Drawing.Size(105, 20);
            this.dtPostDate.TabIndex = 3;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(90, 24);
            this.txtRefNo.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtRefNo.Size = new System.Drawing.Size(105, 20);
            this.txtRefNo.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Ngày &CT (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ngày &HT (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Text = "&Số CT (*)";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(9, 259);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(96, 196);
            this.txtAddress.Size = new System.Drawing.Size(874, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 199);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(517, 169);
            this.cboObjectName.Size = new System.Drawing.Size(874, 20);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(439, 172);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(270, 172);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 172);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(96, 223);
            this.txtContactName.Size = new System.Drawing.Size(874, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 226);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(96, 256);
            this.txtDescription.Size = new System.Drawing.Size(874, 20);
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(96, 282);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(9, 285);
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(339, 169);
            // 
            // cboObjectCategory
            // 
            this.cboObjectCategory.Location = new System.Drawing.Point(96, 169);
            // 
            // cboCurrency
            // 
            this.cboCurrency.Visible = false;
            // 
            // lbExchangeRate
            // 
            this.lbExchangeRate.Visible = false;
            // 
            // lbCurrency
            // 
            this.lbCurrency.Visible = false;
            // 
            // cboExchangRate
            // 
            this.cboExchangRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.cboExchangRate.Visible = false;
            // 
            // btnExportData
            // 
            this.btnExportData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportData.Location = new System.Drawing.Point(752, 50);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(149, 46);
            this.btnExportData.TabIndex = 11;
            this.btnExportData.Text = "&Xuất khẩu\r\ndự toán thu";
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // grdlookUpEditPlanTemplateListId
            // 
            this.grdlookUpEditPlanTemplateListId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdlookUpEditPlanTemplateListId.EditValue = "";
            this.grdlookUpEditPlanTemplateListId.Location = new System.Drawing.Point(112, 24);
            this.grdlookUpEditPlanTemplateListId.MenuManager = this.barToolManager;
            this.grdlookUpEditPlanTemplateListId.Name = "grdlookUpEditPlanTemplateListId";
            this.grdlookUpEditPlanTemplateListId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.grdlookUpEditPlanTemplateListId.Properties.PopupFormSize = new System.Drawing.Size(600, 0);
            this.grdlookUpEditPlanTemplateListId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdlookUpEditPlanTemplateListId.Properties.View = this.grdlookUpEditPlanTemplateListIdView;
            this.grdlookUpEditPlanTemplateListId.Size = new System.Drawing.Size(633, 20);
            this.grdlookUpEditPlanTemplateListId.TabIndex = 1;
            this.grdlookUpEditPlanTemplateListId.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.grdlookUpEditPlanTemplateListId_Closed);
            this.grdlookUpEditPlanTemplateListId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grdlookUpEditPlanTemplateListId_ButtonClick);
            // 
            // grdlookUpEditPlanTemplateListIdView
            // 
            this.grdlookUpEditPlanTemplateListIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdlookUpEditPlanTemplateListIdView.Name = "grdlookUpEditPlanTemplateListIdView";
            this.grdlookUpEditPlanTemplateListIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdlookUpEditPlanTemplateListIdView.OptionsView.ShowGroupPanel = false;
            this.grdlookUpEditPlanTemplateListIdView.OptionsView.ShowIndicator = false;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(9, 53);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(35, 13);
            this.labelControl14.TabIndex = 9;
            this.labelControl14.Text = "&Ghi chú";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl11.Location = new System.Drawing.Point(752, 27);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(79, 13);
            this.labelControl11.TabIndex = 2;
            this.labelControl11.Text = "&Năm dự toán (*)";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(9, 27);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(97, 13);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "&Mẫu dự toán thu (*)";
            // 
            // spinYearOfPlaning
            // 
            this.spinYearOfPlaning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spinYearOfPlaning.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinYearOfPlaning.Location = new System.Drawing.Point(837, 24);
            this.spinYearOfPlaning.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.spinYearOfPlaning.MenuManager = this.barToolManager;
            this.spinYearOfPlaning.Name = "spinYearOfPlaning";
            this.spinYearOfPlaning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinYearOfPlaning.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinYearOfPlaning.Properties.Mask.EditMask = "n";
            this.spinYearOfPlaning.Properties.NullText = "[EditValue is null]";
            this.spinYearOfPlaning.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.spinYearOfPlaning.Size = new System.Drawing.Size(64, 20);
            this.spinYearOfPlaning.TabIndex = 3;
            // 
            // memoJournalMemo
            // 
            this.memoJournalMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoJournalMemo.EditValue = "";
            this.memoJournalMemo.Location = new System.Drawing.Point(112, 50);
            this.memoJournalMemo.MenuManager = this.barToolManager;
            this.memoJournalMemo.Name = "memoJournalMemo";
            this.memoJournalMemo.Size = new System.Drawing.Size(633, 46);
            this.memoJournalMemo.TabIndex = 10;
            // 
            // btnUpdateTemplateListItem
            // 
            this.btnUpdateTemplateListItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateTemplateListItem.Enabled = false;
            this.btnUpdateTemplateListItem.Location = new System.Drawing.Point(683, 21);
            this.btnUpdateTemplateListItem.Name = "btnUpdateTemplateListItem";
            this.btnUpdateTemplateListItem.Size = new System.Drawing.Size(66, 71);
            this.btnUpdateTemplateListItem.TabIndex = 16;
            this.btnUpdateTemplateListItem.Text = "Cập nhật \r\nchỉ tiêu \r\ndự toán \r\nbổ sung ";
            this.btnUpdateTemplateListItem.ToolTip = "Khi nhập nhấn cập nhật số liệu  toàn bộ chứng từ mới nhập từ ngày 1/1-30/6 sẽ cập" +
    " nhật vào cột Thực hiện 6 tháng đầu năm";
            this.btnUpdateTemplateListItem.Visible = false;
            this.btnUpdateTemplateListItem.Click += new System.EventHandler(this.btnUpdateTemplateListItem_Click);
            // 
            // btnExchangeRate
            // 
            this.btnExchangeRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExchangeRate.Location = new System.Drawing.Point(277, 115);
            this.btnExchangeRate.Name = "btnExchangeRate";
            this.btnExchangeRate.Size = new System.Drawing.Size(298, 20);
            this.btnExchangeRate.TabIndex = 8;
            this.btnExchangeRate.Text = "&Quy đổi tỉ giá";
            this.btnExchangeRate.Click += new System.EventHandler(this.btnExchangeRate_Click);
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtExchangeRate.Location = new System.Drawing.Point(261, 114);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtExchangeRate.Properties.Mask.EditMask = "F5";
            this.txtExchangeRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtExchangeRate.Size = new System.Drawing.Size(10, 20);
            this.txtExchangeRate.TabIndex = 7;
            this.txtExchangeRate.Visible = false;
            this.txtExchangeRate.EditValueChanged += new System.EventHandler(this.txtExchangeRate_EditValueChanged);
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl13.Location = new System.Drawing.Point(209, 116);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(46, 13);
            this.labelControl13.TabIndex = 6;
            this.labelControl13.Text = "&Tỷ giá (*)";
            // 
            // FrmXtraReceiptEstimateDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = TSD.Enum.RefType.ReceiptEstimate;
            this.ClientSize = new System.Drawing.Size(1134, 626);
            this.Controls.Add(this.txtExchangeRate);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.btnExchangeRate);
            this.EventTime = new System.DateTime(2020, 1, 14, 9, 14, 25, 433);
            this.FormCaption = "dự toán thu";
            this.Name = "FrmXtraReceiptEstimateDetail";
            this.Reference = "THÊM DỰ TOÁN THU - ID  - SỐ CT: ";
            this.Text = "FrmXtraReceiptEstimateDetail";
            this.Load += new System.EventHandler(this.FrmXtraReceiptEstimateDetail_Load);
            this.Resize += new System.EventHandler(this.FrmXtraReceiptEstimateDetail_Resize);
            this.Controls.SetChildIndex(this.btnExchangeRate, 0);
            this.Controls.SetChildIndex(this.labelControl13, 0);
            this.Controls.SetChildIndex(this.groupObject, 0);
            this.Controls.SetChildIndex(this.txtExchangeRate, 0);
            this.Controls.SetChildIndex(this.groupVoucher, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            this.groupVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupObject)).EndInit();
            this.groupObject.ResumeLayout(false);
            this.groupObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageToolbar24Collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExchangRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEditPlanTemplateListId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEditPlanTemplateListIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYearOfPlaning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoJournalMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SpinEdit spinYearOfPlaning;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.MemoEdit memoJournalMemo;
        private DevExpress.XtraEditors.SpinEdit txtExchangeRate;
        private DevExpress.XtraEditors.GridLookUpEdit grdlookUpEditPlanTemplateListId;
        private DevExpress.XtraGrid.Views.Grid.GridView grdlookUpEditPlanTemplateListIdView;
        private DevExpress.XtraEditors.SimpleButton btnExchangeRate;
        private DevExpress.XtraEditors.SimpleButton btnExportData;
        private DevExpress.XtraEditors.SimpleButton btnUpdateTemplateListItem;
    }
}