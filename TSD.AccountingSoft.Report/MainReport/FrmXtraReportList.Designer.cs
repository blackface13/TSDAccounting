namespace TSD.AccountingSoft.Report.MainReport
{
    partial class FrmXtraReportList
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
            this.components = new System.ComponentModel.Container();
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters3 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraReportList));
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters4 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            this.gifExportFilter1 = new PerpetuumSoft.Reporting.Export.Graph.GifExportFilter(this.components);
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gifExportFilter2 = new PerpetuumSoft.Reporting.Export.Graph.GifExportFilter(this.components);
            this.gridReportGroupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdReportGroup = new DevExpress.XtraGrid.GridControl();
            this.gridReportDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdReportDetail = new DevExpress.XtraGrid.GridControl();
            this.cboCurrencyCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateTimeRangeV = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboAmountType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportGroupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrencyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAmountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gifExportFilter1
            // 
            this.gifExportFilter1.ExtraParameters = extraParameters3;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "export_excel.png");
            this.imageCollection.Images.SetKeyName(1, "design_report.png");
            this.imageCollection.Images.SetKeyName(2, "preview.png");
            this.imageCollection.Images.SetKeyName(3, "help.png");
            this.imageCollection.Images.SetKeyName(4, "Abort.png");
            this.imageCollection.Images.SetKeyName(5, "Print-16.png");
            this.imageCollection.Images.SetKeyName(6, "print16.png");
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ImageIndex = 6;
            this.btnPrint.ImageList = this.imageCollection;
            this.btnPrint.Location = new System.Drawing.Point(557, 39);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 25);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "&In báo cáo";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gifExportFilter2
            // 
            this.gifExportFilter2.ExtraParameters = extraParameters4;
            // 
            // gridReportGroupView
            // 
            this.gridReportGroupView.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridReportGroupView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridReportGroupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridReportGroupView.GridControl = this.grdReportGroup;
            this.gridReportGroupView.Name = "gridReportGroupView";
            this.gridReportGroupView.OptionsBehavior.Editable = false;
            this.gridReportGroupView.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.gridReportGroupView.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gridReportGroupView.OptionsBehavior.ReadOnly = true;
            this.gridReportGroupView.OptionsDetail.EnableMasterViewMode = false;
            this.gridReportGroupView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridReportGroupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridReportGroupView.OptionsView.ShowColumnHeaders = false;
            this.gridReportGroupView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridReportGroupView.OptionsView.ShowGroupPanel = false;
            this.gridReportGroupView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridReportGroupView.OptionsView.ShowIndicator = false;
            this.gridReportGroupView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridReportGroupView.OptionsView.ShowViewCaption = true;
            this.gridReportGroupView.ViewCaption = "Nhóm báo cáo";
            this.gridReportGroupView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridReportGroupView_FocusedRowChanged);
            // 
            // grdReportGroup
            // 
            this.grdReportGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdReportGroup.Location = new System.Drawing.Point(6, 9);
            this.grdReportGroup.MainView = this.gridReportGroupView;
            this.grdReportGroup.Name = "grdReportGroup";
            this.grdReportGroup.Size = new System.Drawing.Size(210, 342);
            this.grdReportGroup.TabIndex = 8;
            this.grdReportGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridReportGroupView});
            // 
            // gridReportDetailView
            // 
            this.gridReportDetailView.Appearance.VertLine.BorderColor = System.Drawing.Color.Transparent;
            this.gridReportDetailView.Appearance.VertLine.Options.UseBorderColor = true;
            this.gridReportDetailView.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridReportDetailView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridReportDetailView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridReportDetailView.GridControl = this.grdReportDetail;
            this.gridReportDetailView.Name = "gridReportDetailView";
            this.gridReportDetailView.OptionsBehavior.Editable = false;
            this.gridReportDetailView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridReportDetailView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridReportDetailView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridReportDetailView.OptionsView.ShowColumnHeaders = false;
            this.gridReportDetailView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridReportDetailView.OptionsView.ShowGroupPanel = false;
            this.gridReportDetailView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridReportDetailView.OptionsView.ShowIndicator = false;
            this.gridReportDetailView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridReportDetailView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridReportDetailView.OptionsView.ShowViewCaption = true;
            this.gridReportDetailView.ViewCaption = "Danh sách báo cáo";
            this.gridReportDetailView.DoubleClick += new System.EventHandler(this.gridReportDetailView_DoubleClick);
            // 
            // grdReportDetail
            // 
            this.grdReportDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReportDetail.Location = new System.Drawing.Point(222, 9);
            this.grdReportDetail.LookAndFeel.SkinName = "Office 2013";
            this.grdReportDetail.MainView = this.gridReportDetailView;
            this.grdReportDetail.Name = "grdReportDetail";
            this.grdReportDetail.Size = new System.Drawing.Size(329, 342);
            this.grdReportDetail.TabIndex = 9;
            this.grdReportDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridReportDetailView});
            // 
            // cboCurrencyCode
            // 
            this.cboCurrencyCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrencyCode.Location = new System.Drawing.Point(409, 32);
            this.cboCurrencyCode.Name = "cboCurrencyCode";
            this.cboCurrencyCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCurrencyCode.Properties.PopupSizeable = true;
            this.cboCurrencyCode.Size = new System.Drawing.Size(128, 20);
            this.cboCurrencyCode.TabIndex = 1;
            // 
            // dateTimeRangeV
            // 
            this.dateTimeRangeV.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRangeV.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV.InitSelectedIndex = 0;
            this.dateTimeRangeV.Location = new System.Drawing.Point(9, -8);
            this.dateTimeRangeV.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV.Name = "dateTimeRangeV";
            this.dateTimeRangeV.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV.Size = new System.Drawing.Size(295, 78);
            this.dateTimeRangeV.TabIndex = 0;
            this.dateTimeRangeV.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV.ToDateLabelText = "Đến ngày";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(336, 36);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Loại tiền";
            // 
            // cboAmountType
            // 
            this.cboAmountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAmountType.EditValue = "Tiền nguyên tệ";
            this.cboAmountType.Location = new System.Drawing.Point(409, 9);
            this.cboAmountType.Name = "cboAmountType";
            this.cboAmountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAmountType.Properties.Items.AddRange(new object[] {
            "Tiền quy đổi",
            "Tiền nguyên tệ"});
            this.cboAmountType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAmountType.Size = new System.Drawing.Size(128, 20);
            this.cboAmountType.TabIndex = 0;
            this.cboAmountType.SelectedIndexChanged += new System.EventHandler(this.cboAmountType_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(336, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Loại hạch toán";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.cboCurrencyCode);
            this.groupControl2.Controls.Add(this.dateTimeRangeV);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cboAmountType);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(6, 357);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(545, 66);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Tùy chọn";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ImageIndex = 4;
            this.btnExit.ImageList = this.imageCollection;
            this.btnExit.Location = new System.Drawing.Point(557, 129);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 25);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "&Hủy xem";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ImageIndex = 3;
            this.btnHelp.ImageList = this.imageCollection;
            this.btnHelp.Location = new System.Drawing.Point(557, 99);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(81, 25);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "&Trợ giúp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.ImageIndex = 0;
            this.btnExportToExcel.ImageList = this.imageCollection;
            this.btnExportToExcel.Location = new System.Drawing.Point(557, 159);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(81, 25);
            this.btnExportToExcel.TabIndex = 16;
            this.btnExportToExcel.Text = "Xuất &Excel";
            this.btnExportToExcel.Visible = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.ImageIndex = 1;
            this.btnEdit.ImageList = this.imageCollection;
            this.btnEdit.Location = new System.Drawing.Point(557, 69);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 25);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "&Sửa mẫu";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.ImageIndex = 2;
            this.btnPreview.ImageList = this.imageCollection;
            this.btnPreview.Location = new System.Drawing.Point(557, 9);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(81, 25);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "&Xem trước";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // FrmXtraReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 431);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdReportGroup);
            this.Controls.Add(this.grdReportDetail);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPreview);
            this.Name = "FrmXtraReportList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.FrmXtraReportList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportGroupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrencyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAmountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PerpetuumSoft.Reporting.Export.Graph.GifExportFilter gifExportFilter1;
        private DevExpress.Utils.ImageCollection imageCollection;
        public DevExpress.XtraEditors.SimpleButton btnPrint;
        private PerpetuumSoft.Reporting.Export.Graph.GifExportFilter gifExportFilter2;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridReportGroupView;
        public DevExpress.XtraGrid.GridControl grdReportGroup;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridReportDetailView;
        public DevExpress.XtraGrid.GridControl grdReportDetail;
        private DevExpress.XtraEditors.ComboBoxEdit cboCurrencyCode;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboAmountType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        public DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        public DevExpress.XtraEditors.SimpleButton btnEdit;
        public DevExpress.XtraEditors.SimpleButton btnPreview;
    }
}