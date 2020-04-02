namespace TSD.AccountingSoft.WindowsForm.BaseUserControls
{
    partial class BaseVoucherListDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseVoucherListDetail));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            this.imageToobarCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.barToolManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.barButtonAddNewItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEditItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDeleteItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDuplicate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPrintItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefeshItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHelpItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonCalculatePriceItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            this.imageToobarCollection.Images.SetKeyName(0, "list-add.png");
            this.imageToobarCollection.Images.SetKeyName(1, "list-delete.png");
            this.imageToobarCollection.Images.SetKeyName(2, "list-edit.png");
            this.imageToobarCollection.Images.SetKeyName(3, "list-search.png");
            this.imageToobarCollection.Images.SetKeyName(4, "document-update.png");
            this.imageToobarCollection.Images.SetKeyName(5, "help2.png");
            this.imageToobarCollection.Images.SetKeyName(6, "print.png");
            this.imageToobarCollection.Images.SetKeyName(7, "document_refresh.png");
            this.imageToobarCollection.Images.SetKeyName(8, "NHAN-BAN.png");
            this.imageToobarCollection.Images.SetKeyName(9, "calculator.png");
            // 
            // barToolManager
            // 
            this.barToolManager.AllowCustomization = false;
            this.barToolManager.AllowMoveBarOnToolbar = false;
            this.barToolManager.AllowQuickCustomization = false;
            this.barToolManager.AllowShowToolbarsPopup = false;
            this.barToolManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools});
            this.barToolManager.DockControls.Add(this.barDockControlTop);
            this.barToolManager.DockControls.Add(this.barDockControlBottom);
            this.barToolManager.DockControls.Add(this.barDockControlLeft);
            this.barToolManager.DockControls.Add(this.barDockControlRight);
            this.barToolManager.Form = this;
            this.barToolManager.Images = this.imageToobarCollection;
            this.barToolManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonAddNewItem,
            this.barButtonEditItem,
            this.barButtonDeleteItem,
            this.barButtonPrintItem,
            this.barButtonHelpItem,
            this.barButtonRefeshItem,
            this.barButtonDuplicate,
            this.barButtonCalculatePriceItem});
            this.barToolManager.MaxItemId = 8;
            this.barToolManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barToolManager_ItemClick);
            // 
            // barTools
            // 
            this.barTools.BarItemHorzIndent = 7;
            this.barTools.BarName = "Tools";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonAddNewItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonDeleteItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonDuplicate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonPrintItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonRefeshItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonHelpItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonCalculatePriceItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barTools.OptionsBar.DrawBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            this.barTools.Text = "Tools";
            // 
            // barButtonAddNewItem
            // 
            this.barButtonAddNewItem.Caption = "Thêm";
            this.barButtonAddNewItem.Id = 0;
            this.barButtonAddNewItem.ImageIndex = 0;
            this.barButtonAddNewItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.barButtonAddNewItem.Name = "barButtonAddNewItem";
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem1.Text = "<b>Thêm mới dữ liệu (Ctrl + N)</b>";
            superToolTip1.Items.Add(toolTipItem1);
            this.barButtonAddNewItem.SuperTip = superToolTip1;
            // 
            // barButtonEditItem
            // 
            this.barButtonEditItem.Caption = "Sửa";
            this.barButtonEditItem.Id = 1;
            this.barButtonEditItem.ImageIndex = 2;
            this.barButtonEditItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.barButtonEditItem.Name = "barButtonEditItem";
            superToolTip2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem2.Text = "<b>Sửa dữ liệu (Ctrl + E)</b>";
            superToolTip2.Items.Add(toolTipItem2);
            this.barButtonEditItem.SuperTip = superToolTip2;
            // 
            // barButtonDeleteItem
            // 
            this.barButtonDeleteItem.Caption = "Xóa";
            this.barButtonDeleteItem.Id = 2;
            this.barButtonDeleteItem.ImageIndex = 1;
            this.barButtonDeleteItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.barButtonDeleteItem.Name = "barButtonDeleteItem";
            superToolTip3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem3.Text = "<b>Xóa dữ liệu (Delete)</b>";
            superToolTip3.Items.Add(toolTipItem3);
            this.barButtonDeleteItem.SuperTip = superToolTip3;
            // 
            // barButtonDuplicate
            // 
            this.barButtonDuplicate.Caption = "Nhân bản";
            this.barButtonDuplicate.Id = 6;
            this.barButtonDuplicate.ImageIndex = 8;
            this.barButtonDuplicate.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.barButtonDuplicate.Name = "barButtonDuplicate";
            superToolTip4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem4.Text = "<b> Nhân bản chứng từ (Ctrl + D) </b>";
            superToolTip4.Items.Add(toolTipItem4);
            this.barButtonDuplicate.SuperTip = superToolTip4;
            // 
            // barButtonPrintItem
            // 
            this.barButtonPrintItem.Caption = "In";
            this.barButtonPrintItem.Id = 3;
            this.barButtonPrintItem.ImageIndex = 6;
            this.barButtonPrintItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.barButtonPrintItem.Name = "barButtonPrintItem";
            superToolTip5.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem5.Text = "<b>In danh sách (Ctrl + P)</b>";
            superToolTip5.Items.Add(toolTipItem5);
            this.barButtonPrintItem.SuperTip = superToolTip5;
            // 
            // barButtonRefeshItem
            // 
            this.barButtonRefeshItem.Caption = "Nạp";
            this.barButtonRefeshItem.Id = 5;
            this.barButtonRefeshItem.ImageIndex = 7;
            this.barButtonRefeshItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barButtonRefeshItem.Name = "barButtonRefeshItem";
            superToolTip6.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem6.Text = "<b>Làm mới dữ liệu (F5)</b>";
            superToolTip6.Items.Add(toolTipItem6);
            this.barButtonRefeshItem.SuperTip = superToolTip6;
            // 
            // barButtonHelpItem
            // 
            this.barButtonHelpItem.Caption = "Giúp";
            this.barButtonHelpItem.Id = 4;
            this.barButtonHelpItem.ImageIndex = 5;
            this.barButtonHelpItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.barButtonHelpItem.Name = "barButtonHelpItem";
            superToolTip7.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem7.Text = "<b>Tài liệu trợ giúp (F1)</b>";
            superToolTip7.Items.Add(toolTipItem7);
            this.barButtonHelpItem.SuperTip = superToolTip7;
            // 
            // barButtonCalculatePriceItem
            // 
            this.barButtonCalculatePriceItem.Caption = "Tính giá";
            this.barButtonCalculatePriceItem.Id = 7;
            this.barButtonCalculatePriceItem.ImageIndex = 9;
            this.barButtonCalculatePriceItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T));
            this.barButtonCalculatePriceItem.Name = "barButtonCalculatePriceItem";
            superToolTip8.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem8.Text = "<b>Tính giá xuất kho (Ctrl+T)</b>";
            superToolTip8.Items.Add(toolTipItem8);
            this.barButtonCalculatePriceItem.SuperTip = superToolTip8;
            this.barButtonCalculatePriceItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(835, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 545);
            this.barDockControlBottom.Size = new System.Drawing.Size(835, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 514);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(835, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 514);
            // 
            // grdList
            // 
            this.grdList.DataSource = this.bindingSource;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.gridView;
            this.grdList.MenuManager = this.barToolManager;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(835, 207);
            this.grdList.TabIndex = 6;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
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
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView.Click += new System.EventHandler(this.gridView_Click);
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // grdDetail
            // 
            this.grdDetail.DataSource = this.bindingSourceDetail;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdDetail.MainView = this.gridViewDetail;
            this.grdDetail.MenuManager = this.barToolManager;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(835, 295);
            this.grdDetail.TabIndex = 7;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewDetail.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.gridViewDetail.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridViewDetail.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDetail.GridControl = this.grdDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsBehavior.Editable = false;
            this.gridViewDetail.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDetail.OptionsView.ColumnAutoWidth = false;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewDetail.OptionsView.ShowIndicator = false;
            this.gridViewDetail.OptionsView.ShowViewCaption = true;
            this.gridViewDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridViewDetail.ViewCaption = "Chi tiết chứng từ";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl.Horizontal = false;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.grdList);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.grdDetail);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(835, 514);
            this.splitContainerControl.SplitterPosition = 207;
            this.splitContainerControl.TabIndex = 9;
            this.splitContainerControl.Text = "splitContainerControl";
            // 
            // BaseVoucherListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "BaseVoucherListDetail";
            this.Size = new System.Drawing.Size(835, 545);
            this.Load += new System.EventHandler(this.BaseVoucherListDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageToobarCollection;
        protected DevExpress.XtraBars.BarManager barToolManager;
        protected DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarButtonItem barButtonAddNewItem;
        private DevExpress.XtraBars.BarButtonItem barButtonEditItem;
        private DevExpress.XtraBars.BarButtonItem barButtonDeleteItem;
        private DevExpress.XtraBars.BarButtonItem barButtonDuplicate;
        private DevExpress.XtraBars.BarButtonItem barButtonPrintItem;
        private DevExpress.XtraBars.BarButtonItem barButtonRefeshItem;
        private DevExpress.XtraBars.BarButtonItem barButtonHelpItem;
        protected DevExpress.XtraBars.BarButtonItem barButtonCalculatePriceItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected System.Windows.Forms.BindingSource bindingSource;
        public DevExpress.XtraGrid.GridControl grdList;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        protected System.Windows.Forms.BindingSource bindingSourceDetail;
        public DevExpress.XtraGrid.GridControl grdDetail;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
    }
}
