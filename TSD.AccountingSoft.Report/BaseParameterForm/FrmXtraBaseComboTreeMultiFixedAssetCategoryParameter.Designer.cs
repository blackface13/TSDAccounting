namespace TSD.AccountingSoft.Report.BaseParameterForm
{
    partial class FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkMoveTotalInNewPage = new DevExpress.XtraEditors.CheckEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListFixedAssetCategory = new DevExpress.XtraTreeList.TreeList();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeH();
            this.popupContainerEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFixedAssetCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.chkMoveTotalInNewPage);
            this.panelControl1.Controls.Add(this.popupContainerControl1);
            this.panelControl1.Controls.Add(this.dateTimeRangeV1);
            this.panelControl1.Controls.Add(this.popupContainerEdit);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Location = new System.Drawing.Point(9, 10);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(526, 266);
            this.panelControl1.TabIndex = 0;
            // 
            // chkMoveTotalInNewPage
            // 
            this.chkMoveTotalInNewPage.Location = new System.Drawing.Point(68, 235);
            this.chkMoveTotalInNewPage.Name = "chkMoveTotalInNewPage";
            this.chkMoveTotalInNewPage.Properties.Caption = "Chuyển dòng tổng cộng qua trang mới";
            this.chkMoveTotalInNewPage.Size = new System.Drawing.Size(288, 19);
            this.chkMoveTotalInNewPage.TabIndex = 59;
            this.chkMoveTotalInNewPage.ToolTip = "Chỉ dùng trong trường hợp khi in báo cáo mà phần chữ ký ở trang mới và trước phần" +
    " chữ ký không có số liệu.";
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.treeListFixedAssetCategory);
            this.popupContainerControl1.Location = new System.Drawing.Point(70, 75);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(446, 151);
            this.popupContainerControl1.TabIndex = 58;
            // 
            // treeListFixedAssetCategory
            // 
            this.treeListFixedAssetCategory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeListFixedAssetCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFixedAssetCategory.KeyFieldName = "FixedAssetCategoryId";
            this.treeListFixedAssetCategory.Location = new System.Drawing.Point(0, 0);
            this.treeListFixedAssetCategory.Name = "treeListFixedAssetCategory";
            this.treeListFixedAssetCategory.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeListFixedAssetCategory.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeListFixedAssetCategory.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeListFixedAssetCategory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListFixedAssetCategory.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeListFixedAssetCategory.OptionsView.ShowCheckBoxes = true;
            this.treeListFixedAssetCategory.OptionsView.ShowColumns = false;
            this.treeListFixedAssetCategory.OptionsView.ShowFocusedFrame = false;
            this.treeListFixedAssetCategory.OptionsView.ShowIndicator = false;
            this.treeListFixedAssetCategory.OptionsView.ShowVertLines = false;
            this.treeListFixedAssetCategory.ParentFieldName = "ParentId";
            this.treeListFixedAssetCategory.Size = new System.Drawing.Size(446, 151);
            this.treeListFixedAssetCategory.TabIndex = 55;
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRangeV1.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.DateTimeRangeMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(4, 2);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(517, 36);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(517, 36);
            this.dateTimeRangeV1.TabIndex = 57;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // popupContainerEdit
            // 
            this.popupContainerEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.popupContainerEdit.Location = new System.Drawing.Point(70, 49);
            this.popupContainerEdit.Name = "popupContainerEdit";
            this.popupContainerEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit.Properties.ShowPopupCloseButton = false;
            this.popupContainerEdit.Size = new System.Drawing.Size(446, 20);
            this.popupContainerEdit.TabIndex = 55;
            this.popupContainerEdit.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.popupContainerEdit_Closed);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Loại TSCĐ";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Location = new System.Drawing.Point(9, 286);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 25);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(373, 286);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(454, 286);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Hủy bỏ";
            // 
            // FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 323);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter";
            this.Load += new System.EventHandler(this.FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMoveTotalInNewPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFixedAssetCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit;
        protected System.Windows.Forms.Label label2;
        private DateTimeRangeBlockDev.DateTimeRangeH dateTimeRangeV1;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        public DevExpress.XtraTreeList.TreeList treeListFixedAssetCategory;
        public DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        public DevExpress.XtraEditors.CheckEdit chkMoveTotalInNewPage;
    }
}