namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmXtraFixedAssetS26H
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
            this.cbbFixedAssetType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpDepartment = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpDepartmentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpFixedAssetCategory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpFixedAssetCategoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbFixedAssetType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDepartmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpFixedAssetCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpFixedAssetCategoryView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Controls.Add(this.gridLookUpFixedAssetCategory);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.cbbFixedAssetType);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.gridLookUpDepartment);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Size = new System.Drawing.Size(315, 159);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(166, 174);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(247, 174);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 174);
            // 
            // cbbFixedAssetType
            // 
            this.cbbFixedAssetType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbFixedAssetType.Location = new System.Drawing.Point(79, 76);
            this.cbbFixedAssetType.Name = "cbbFixedAssetType";
            this.cbbFixedAssetType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbFixedAssetType.Properties.Items.AddRange(new object[] {
            "Tài sản cố định",
            "Công cụ dụng cụ"});
            this.cbbFixedAssetType.Size = new System.Drawing.Size(225, 20);
            this.cbbFixedAssetType.TabIndex = 67;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 66;
            this.labelControl2.Text = "Loại";
            // 
            // gridLookUpDepartment
            // 
            this.gridLookUpDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpDepartment.EditValue = "";
            this.gridLookUpDepartment.Location = new System.Drawing.Point(78, 103);
            this.gridLookUpDepartment.Name = "gridLookUpDepartment";
            this.gridLookUpDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpDepartment.Properties.NullText = "";
            this.gridLookUpDepartment.Properties.View = this.gridLookUpDepartmentView;
            this.gridLookUpDepartment.Size = new System.Drawing.Size(226, 20);
            this.gridLookUpDepartment.TabIndex = 65;
            // 
            // gridLookUpDepartmentView
            // 
            this.gridLookUpDepartmentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpDepartmentView.Name = "gridLookUpDepartmentView";
            this.gridLookUpDepartmentView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpDepartmentView.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 106);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 64;
            this.labelControl1.Text = "Khoa phòng";
            // 
            // gridLookUpFixedAssetCategory
            // 
            this.gridLookUpFixedAssetCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpFixedAssetCategory.EditValue = "";
            this.gridLookUpFixedAssetCategory.Location = new System.Drawing.Point(78, 129);
            this.gridLookUpFixedAssetCategory.Name = "gridLookUpFixedAssetCategory";
            this.gridLookUpFixedAssetCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpFixedAssetCategory.Properties.NullText = "";
            this.gridLookUpFixedAssetCategory.Properties.View = this.gridLookUpFixedAssetCategoryView;
            this.gridLookUpFixedAssetCategory.Size = new System.Drawing.Size(226, 20);
            this.gridLookUpFixedAssetCategory.TabIndex = 70;
            // 
            // gridLookUpFixedAssetCategoryView
            // 
            this.gridLookUpFixedAssetCategoryView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpFixedAssetCategoryView.Name = "gridLookUpFixedAssetCategoryView";
            this.gridLookUpFixedAssetCategoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpFixedAssetCategoryView.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 132);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 69;
            this.labelControl3.Text = "Nhóm TSCĐ";
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(8, 4);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(304, 70);
            this.dateTimeRangeV1.TabIndex = 71;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // FrmXtraFixedAssetS26H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(327, 208);
            this.Name = "FrmXtraFixedAssetS26H";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbFixedAssetType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpDepartmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpFixedAssetCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpFixedAssetCategoryView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbbFixedAssetType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpDepartmentView;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpFixedAssetCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpFixedAssetCategoryView;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
    }
}