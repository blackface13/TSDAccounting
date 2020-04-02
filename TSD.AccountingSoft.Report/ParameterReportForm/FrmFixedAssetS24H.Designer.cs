namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmFixedAssetS24H
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
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboDepartment = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cboDepartmentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.popupContainerEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListFixedAssetCategory = new DevExpress.XtraTreeList.TreeList();
            this.gridFixedAsset = new DevExpress.XtraGrid.GridControl();
            this.gridViewFixedAsset = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFixedAssetCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFixedAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.popupContainerControl1);
            this.groupboxMain.Controls.Add(this.gridFixedAsset);
            this.groupboxMain.Controls.Add(this.groupControl2);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Size = new System.Drawing.Size(607, 451);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(458, 468);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(539, 468);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 468);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 24);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(298, 70);
            this.dateTimeRangeV1.TabIndex = 0;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateTimeRangeV1);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(308, 101);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Tùy chọn kỳ báo cáo";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboDepartment);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.popupContainerEdit);
            this.groupControl2.Location = new System.Drawing.Point(319, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(283, 100);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Tùy chọn lọc tài sản";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Location = new System.Drawing.Point(72, 36);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartment.Properties.NullText = "";
            this.cboDepartment.Properties.View = this.cboDepartmentView;
            this.cboDepartment.Size = new System.Drawing.Size(198, 20);
            this.cboDepartment.TabIndex = 2;
            // 
            // cboDepartmentView
            // 
            this.cboDepartmentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cboDepartmentView.Name = "cboDepartmentView";
            this.cboDepartmentView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cboDepartmentView.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Loại TSCĐ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Phòng ban";
            // 
            // popupContainerEdit
            // 
            this.popupContainerEdit.Location = new System.Drawing.Point(72, 62);
            this.popupContainerEdit.Name = "popupContainerEdit";
            this.popupContainerEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit.Size = new System.Drawing.Size(198, 20);
            this.popupContainerEdit.TabIndex = 3;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.treeListFixedAssetCategory);
            this.popupContainerControl1.Location = new System.Drawing.Point(5, 112);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(595, 334);
            this.popupContainerControl1.TabIndex = 8;
            // 
            // treeListFixedAssetCategory
            // 
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
            this.treeListFixedAssetCategory.Size = new System.Drawing.Size(595, 334);
            this.treeListFixedAssetCategory.TabIndex = 0;
            // 
            // gridFixedAsset
            // 
            this.gridFixedAsset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFixedAsset.Location = new System.Drawing.Point(5, 112);
            this.gridFixedAsset.MainView = this.gridViewFixedAsset;
            this.gridFixedAsset.Name = "gridFixedAsset";
            this.gridFixedAsset.Size = new System.Drawing.Size(597, 334);
            this.gridFixedAsset.TabIndex = 3;
            this.gridFixedAsset.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFixedAsset});
            // 
            // gridViewFixedAsset
            // 
            this.gridViewFixedAsset.GridControl = this.gridFixedAsset;
            this.gridViewFixedAsset.Name = "gridViewFixedAsset";
            this.gridViewFixedAsset.OptionsView.ShowGroupPanel = false;
            this.gridViewFixedAsset.OptionsView.ShowIndicator = false;
            this.gridViewFixedAsset.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewFixedAsset_RowClick);
            // 
            // FrmFixedAssetS24H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 502);
            this.Name = "FrmFixedAssetS24H";
            this.Text = "Sổ tài sản cố định";
            this.Load += new System.EventHandler(this.FrmFixedAssetS24H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFixedAssetCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFixedAsset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridFixedAsset;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFixedAsset;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GridLookUpEdit cboDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView cboDepartmentView;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListFixedAssetCategory;
    }
}