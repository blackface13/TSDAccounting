namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraSearchVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraSearchVoucher));
            this.grdlookUpFieldSearch = new DevExpress.XtraGrid.GridControl();
            this.gridViewFieldSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblValue = new DevExpress.XtraEditors.LabelControl();
            this.grdObjectValue = new DevExpress.XtraEditors.LookUpEdit();
            this.btnShowRef = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.grdlookUpExpressionSearch = new DevExpress.XtraGrid.GridControl();
            this.grdlookUpExpressionSearchView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.imgMain = new DevExpress.Utils.ImageCollection(this.components);
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblTodate = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnGoToVoucher = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblRefNo = new DevExpress.XtraEditors.LabelControl();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.lblgreater = new System.Windows.Forms.Label();
            this.lbllesser = new System.Windows.Forms.Label();
            this.txtgreater = new DevExpress.XtraEditors.TextEdit();
            this.txtlesser = new DevExpress.XtraEditors.TextEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpFieldSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFieldSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdObjectValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpExpressionSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpExpressionSearchView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgreater.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlesser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdlookUpFieldSearch
            // 
            this.grdlookUpFieldSearch.Location = new System.Drawing.Point(6, 24);
            this.grdlookUpFieldSearch.MainView = this.gridViewFieldSearch;
            this.grdlookUpFieldSearch.Name = "grdlookUpFieldSearch";
            this.grdlookUpFieldSearch.Size = new System.Drawing.Size(176, 162);
            this.grdlookUpFieldSearch.TabIndex = 3;
            this.grdlookUpFieldSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFieldSearch});
            this.grdlookUpFieldSearch.Click += new System.EventHandler(this.grdlookUpFieldSearch_Click);
            // 
            // gridViewFieldSearch
            // 
            this.gridViewFieldSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewFieldSearch.GridControl = this.grdlookUpFieldSearch;
            this.gridViewFieldSearch.Name = "gridViewFieldSearch";
            this.gridViewFieldSearch.OptionsBehavior.Editable = false;
            this.gridViewFieldSearch.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewFieldSearch.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewFieldSearch.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewFieldSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewFieldSearch.OptionsSelection.MultiSelect = true;
            this.gridViewFieldSearch.OptionsView.ShowColumnHeaders = false;
            this.gridViewFieldSearch.OptionsView.ShowGroupPanel = false;
            this.gridViewFieldSearch.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFieldSearch.OptionsView.ShowIndicator = false;
            this.gridViewFieldSearch.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.Location = new System.Drawing.Point(190, 26);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(28, 13);
            this.lblValue.TabIndex = 10;
            this.lblValue.Text = "Giá trị";
            // 
            // grdObjectValue
            // 
            this.grdObjectValue.EditValue = "";
            this.grdObjectValue.Location = new System.Drawing.Point(244, 23);
            this.grdObjectValue.Name = "grdObjectValue";
            this.grdObjectValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdObjectValue.Properties.NullText = "";
            this.grdObjectValue.Size = new System.Drawing.Size(100, 20);
            this.grdObjectValue.TabIndex = 9;
            // 
            // btnShowRef
            // 
            this.btnShowRef.Location = new System.Drawing.Point(410, 53);
            this.btnShowRef.Name = "btnShowRef";
            this.btnShowRef.Size = new System.Drawing.Size(78, 23);
            this.btnShowRef.TabIndex = 11;
            this.btnShowRef.Text = "Bỏ tất <<";
            this.btnShowRef.Click += new System.EventHandler(this.btnShowRef_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(410, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm >";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdlookUpExpressionSearch
            // 
            this.grdlookUpExpressionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdlookUpExpressionSearch.Location = new System.Drawing.Point(498, 24);
            this.grdlookUpExpressionSearch.MainView = this.grdlookUpExpressionSearchView;
            this.grdlookUpExpressionSearch.Name = "grdlookUpExpressionSearch";
            this.grdlookUpExpressionSearch.Size = new System.Drawing.Size(396, 162);
            this.grdlookUpExpressionSearch.TabIndex = 13;
            this.grdlookUpExpressionSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdlookUpExpressionSearchView});
            // 
            // grdlookUpExpressionSearchView
            // 
            this.grdlookUpExpressionSearchView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdlookUpExpressionSearchView.GridControl = this.grdlookUpExpressionSearch;
            this.grdlookUpExpressionSearchView.Name = "grdlookUpExpressionSearchView";
            this.grdlookUpExpressionSearchView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdlookUpExpressionSearchView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdlookUpExpressionSearchView.OptionsNavigation.AutoMoveRowFocus = false;
            this.grdlookUpExpressionSearchView.OptionsNavigation.EnterMoveNextColumn = true;
            this.grdlookUpExpressionSearchView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdlookUpExpressionSearchView.OptionsView.ShowGroupPanel = false;
            this.grdlookUpExpressionSearchView.OptionsView.ShowIndicator = false;
            this.grdlookUpExpressionSearchView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grdlookUpExpressionSearchView.ViewCaption = "Biểu thức tìm kiếm";
            this.grdlookUpExpressionSearchView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdlookUpExpressionSearchView_PopupMenuShowing);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageIndex = 5;
            this.btnSearch.ImageList = this.imgMain;
            this.btnSearch.Location = new System.Drawing.Point(410, 163);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // imgMain
            // 
            this.imgMain.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgMain.ImageStream")));
            this.imgMain.Images.SetKeyName(0, "LUU.png");
            this.imgMain.Images.SetKeyName(1, "THOAT.png");
            this.imgMain.Images.SetKeyName(2, "TRO-GIUP.png");
            this.imgMain.Images.SetKeyName(3, "export_excel.png");
            this.imgMain.Images.SetKeyName(4, "print16.png");
            this.imgMain.Images.SetKeyName(5, "preview.png");
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdList.Location = new System.Drawing.Point(6, 192);
            this.grdList.MainView = this.gridView;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(888, 250);
            this.grdList.TabIndex = 15;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.grdList.Click += new System.EventHandler(this.grdList_Click);
            this.grdList.DoubleClick += new System.EventHandler(this.grdList_DoubleClick);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.grdList;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(498, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Biểu thức tìm kiếm";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = new System.DateTime(2014, 3, 18, 19, 18, 2, 581);
            this.dtToDate.Location = new System.Drawing.Point(244, 50);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtToDate.Size = new System.Drawing.Size(100, 20);
            this.dtToDate.TabIndex = 20;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtFromDate.Location = new System.Drawing.Point(244, 23);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtFromDate.TabIndex = 19;
            // 
            // lblTodate
            // 
            this.lblTodate.Location = new System.Drawing.Point(190, 53);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.Size = new System.Drawing.Size(47, 13);
            this.lblTodate.TabIndex = 17;
            this.lblTodate.Text = "Đến ngày";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(190, 26);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(40, 13);
            this.lblFromDate.TabIndex = 18;
            this.lblFromDate.Text = "Từ ngày";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.ImageIndex = 2;
            this.btnHelp.ImageList = this.imgMain;
            this.btnHelp.Location = new System.Drawing.Point(6, 451);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(70, 25);
            this.btnHelp.TabIndex = 23;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ImageIndex = 1;
            this.btnExit.ImageList = this.imgMain;
            this.btnExit.Location = new System.Drawing.Point(824, 451);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Thoát";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.ImageIndex = 3;
            this.btnExportToExcel.ImageList = this.imgMain;
            this.btnExportToExcel.Location = new System.Drawing.Point(535, 451);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(86, 25);
            this.btnExportToExcel.TabIndex = 21;
            this.btnExportToExcel.Text = "Xuất Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnGoToVoucher
            // 
            this.btnGoToVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToVoucher.ImageList = this.imgMain;
            this.btnGoToVoucher.Location = new System.Drawing.Point(627, 451);
            this.btnGoToVoucher.Name = "btnGoToVoucher";
            this.btnGoToVoucher.Size = new System.Drawing.Size(99, 25);
            this.btnGoToVoucher.TabIndex = 21;
            this.btnGoToVoucher.Text = "Xem chứng từ";
            this.btnGoToVoucher.Click += new System.EventHandler(this.btnGoToVoucher_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ImageIndex = 4;
            this.btnPrint.ImageList = this.imgMain;
            this.btnPrint.Location = new System.Drawing.Point(732, 451);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 25);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "In kết quả";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Trường tìm kiếm";
            // 
            // lblRefNo
            // 
            this.lblRefNo.Location = new System.Drawing.Point(190, 88);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(59, 13);
            this.lblRefNo.TabIndex = 24;
            this.lblRefNo.Text = "Số chứng từ";
            this.lblRefNo.Visible = false;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(261, 85);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(89, 21);
            this.txtRefNo.TabIndex = 25;
            this.txtRefNo.Visible = false;
            // 
            // lblgreater
            // 
            this.lblgreater.AutoSize = true;
            this.lblgreater.Location = new System.Drawing.Point(190, 116);
            this.lblgreater.Name = "lblgreater";
            this.lblgreater.Size = new System.Drawing.Size(23, 13);
            this.lblgreater.TabIndex = 26;
            this.lblgreater.Text = ">=";
            // 
            // lbllesser
            // 
            this.lbllesser.AutoSize = true;
            this.lbllesser.Location = new System.Drawing.Point(190, 143);
            this.lbllesser.Name = "lbllesser";
            this.lbllesser.Size = new System.Drawing.Size(23, 13);
            this.lbllesser.TabIndex = 27;
            this.lbllesser.Text = "<=";
            // 
            // txtgreater
            // 
            this.txtgreater.Location = new System.Drawing.Point(235, 112);
            this.txtgreater.Name = "txtgreater";
            this.txtgreater.Properties.Mask.EditMask = "n2";
            this.txtgreater.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtgreater.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtgreater.Size = new System.Drawing.Size(120, 20);
            this.txtgreater.TabIndex = 30;
            // 
            // txtlesser
            // 
            this.txtlesser.Location = new System.Drawing.Point(235, 139);
            this.txtlesser.Name = "txtlesser";
            this.txtlesser.Properties.Mask.EditMask = "n2";
            this.txtlesser.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtlesser.Size = new System.Drawing.Size(120, 20);
            this.txtlesser.TabIndex = 31;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Xóa dòng";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(900, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 485);
            this.barDockControlBottom.Size = new System.Drawing.Size(900, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 456);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(900, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 456);
            // 
            // FrmXtraSearchVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 485);
            this.Controls.Add(this.txtlesser);
            this.Controls.Add(this.txtgreater);
            this.Controls.Add(this.lbllesser);
            this.Controls.Add(this.lblgreater);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.lblRefNo);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnGoToVoucher);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lblTodate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grdlookUpExpressionSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnShowRef);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.grdlookUpFieldSearch);
            this.Controls.Add(this.grdObjectValue);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MinimizeBox = false;
            this.Name = "FrmXtraSearchVoucher";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.FrmXtraSearchVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpFieldSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFieldSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdObjectValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpExpressionSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpExpressionSearchView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgreater.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlesser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdlookUpFieldSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFieldSearch;
        private DevExpress.XtraEditors.LabelControl lblValue;
        private DevExpress.XtraEditors.LookUpEdit grdObjectValue;
        private DevExpress.XtraEditors.SimpleButton btnShowRef;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl grdlookUpExpressionSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView grdlookUpExpressionSearchView;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        public DevExpress.XtraGrid.GridControl grdList;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        protected DevExpress.XtraEditors.DateEdit dtToDate;
        protected DevExpress.XtraEditors.DateEdit dtFromDate;
        protected DevExpress.XtraEditors.LabelControl lblTodate;
        protected DevExpress.XtraEditors.LabelControl lblFromDate;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.Utils.ImageCollection imgMain;
        public DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        public DevExpress.XtraEditors.SimpleButton btnGoToVoucher;
        public DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        protected DevExpress.XtraEditors.LabelControl lblRefNo;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label lblgreater;
        private System.Windows.Forms.Label lbllesser;
        private DevExpress.XtraEditors.TextEdit txtgreater;
        private DevExpress.XtraEditors.TextEdit txtlesser;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight; 
    }
}