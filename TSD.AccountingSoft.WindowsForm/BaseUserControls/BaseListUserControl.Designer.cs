namespace TSD.AccountingSoft.WindowsForm.BaseUserControls
{
    partial class BaseListUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseListUserControl));
            this.barToolManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.barButtonAddNewItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEditItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDeleteItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPrintItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefeshItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHelpItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPrintFixedAssetItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageToobarCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.ListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.chkCurrency = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl7 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCurrency)).BeginInit();
            this.SuspendLayout();
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
            this.barButtonItem1,
            this.barButtonPrintFixedAssetItem});
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
            this.barTools.FloatLocation = new System.Drawing.Point(46, 122);
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonAddNewItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonDeleteItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonPrintItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonRefeshItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonHelpItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPrintFixedAssetItem)});
            this.barTools.OptionsBar.DrawDragBorder = false;
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
            // barButtonPrintItem
            // 
            this.barButtonPrintItem.Caption = "In";
            this.barButtonPrintItem.Id = 3;
            this.barButtonPrintItem.ImageIndex = 6;
            this.barButtonPrintItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.barButtonPrintItem.Name = "barButtonPrintItem";
            superToolTip4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem4.Text = "<b>In danh sách (Ctrl + P)</b>";
            superToolTip4.Items.Add(toolTipItem4);
            this.barButtonPrintItem.SuperTip = superToolTip4;
            // 
            // barButtonRefeshItem
            // 
            this.barButtonRefeshItem.Caption = "Nạp";
            this.barButtonRefeshItem.Id = 5;
            this.barButtonRefeshItem.ImageIndex = 7;
            this.barButtonRefeshItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barButtonRefeshItem.Name = "barButtonRefeshItem";
            superToolTip5.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem5.Text = "<b>Làm mới dữ liệu (F5)</b>";
            superToolTip5.Items.Add(toolTipItem5);
            this.barButtonRefeshItem.SuperTip = superToolTip5;
            // 
            // barButtonHelpItem
            // 
            this.barButtonHelpItem.Caption = "Giúp";
            this.barButtonHelpItem.Id = 4;
            this.barButtonHelpItem.ImageIndex = 5;
            this.barButtonHelpItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.barButtonHelpItem.Name = "barButtonHelpItem";
            superToolTip6.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem6.Text = "<b>Tài liệu trợ giúp (F1)</b>";
            superToolTip6.Items.Add(toolTipItem6);
            this.barButtonHelpItem.SuperTip = superToolTip6;
            // 
            // barButtonPrintFixedAssetItem
            // 
            this.barButtonPrintFixedAssetItem.Caption = "In thẻ TSCĐ";
            this.barButtonPrintFixedAssetItem.Id = 7;
            this.barButtonPrintFixedAssetItem.Name = "barButtonPrintFixedAssetItem";
            this.barButtonPrintFixedAssetItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonPrintFixedAssetItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonPrintFixedAssetItem_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 22);
            this.barDockControlTop.Size = new System.Drawing.Size(789, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 537);
            this.barDockControlBottom.Size = new System.Drawing.Size(789, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 53);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 484);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(789, 53);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 484);
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
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddNewItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonEditItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDeleteItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefeshItem, true)});
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // grdList
            // 
            this.grdList.DataSource = this.ListBindingSource;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 53);
            this.grdList.MainView = this.gridView;
            this.grdList.MenuManager = this.barToolManager;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(789, 484);
            this.grdList.TabIndex = 4;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.grdList.DoubleClick += new System.EventHandler(this.grdList_DoubleClick);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.grdList;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar4});
            this.barManager2.DockControls.Add(this.barDockControl5);
            this.barManager2.DockControls.Add(this.barDockControl6);
            this.barManager2.DockControls.Add(this.barDockControl7);
            this.barManager2.DockControls.Add(this.barDockControl8);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem2});
            this.barManager2.MainMenu = this.bar2;
            this.barManager2.MaxItemId = 1;
            this.barManager2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkCurrency});
            this.barManager2.StatusBar = this.bar4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItem2)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.chkCurrency;
            this.barEditItem2.EditHeight = 1;
            this.barEditItem2.EditValue = ((short)(0));
            this.barEditItem2.Id = 0;
            this.barEditItem2.Name = "barEditItem2";
            this.barEditItem2.Width = 218;
            // 
            // chkCurrency
            // 
            this.chkCurrency.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.chkCurrency.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "USD"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Tiền địa phương ")});
            this.chkCurrency.Name = "chkCurrency";
            this.chkCurrency.EditValueChanged += new System.EventHandler(this.barEditItem2_EditValueChanged);
            // 
            // bar4
            // 
            this.bar4.BarName = "Status bar";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Status bar";
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl5.Location = new System.Drawing.Point(0, 0);
            this.barDockControl5.Size = new System.Drawing.Size(789, 22);
            // 
            // barDockControl6
            // 
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl6.Location = new System.Drawing.Point(0, 537);
            this.barDockControl6.Size = new System.Drawing.Size(789, 23);
            // 
            // barDockControl7
            // 
            this.barDockControl7.CausesValidation = false;
            this.barDockControl7.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl7.Location = new System.Drawing.Point(0, 22);
            this.barDockControl7.Size = new System.Drawing.Size(0, 515);
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl8.Location = new System.Drawing.Point(789, 22);
            this.barDockControl8.Size = new System.Drawing.Size(0, 515);
            // 
            // BaseListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl7);
            this.Controls.Add(this.barDockControl8);
            this.Controls.Add(this.barDockControl6);
            this.Controls.Add(this.barDockControl5);
            this.Name = "BaseListUserControl";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Size = new System.Drawing.Size(789, 560);
            this.Load += new System.EventHandler(this.BaseListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar barTools;
        public DevExpress.XtraBars.BarButtonItem barButtonAddNewItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonHelpItem;
        private DevExpress.XtraBars.BarButtonItem barButtonRefeshItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        public System.Windows.Forms.BindingSource ListBindingSource;
        public DevExpress.XtraGrid.GridControl grdList;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        protected DevExpress.XtraBars.BarManager barToolManager;
        protected DevExpress.Utils.ImageCollection imageToobarCollection;
        protected DevExpress.XtraBars.PopupMenu popupMenu;
        protected DevExpress.XtraBars.BarButtonItem barButtonEditItem;
        protected DevExpress.XtraBars.BarButtonItem barButtonPrintItem;
        public DevExpress.XtraBars.BarButtonItem barButtonPrintFixedAssetItem;
        public DevExpress.XtraBars.BarButtonItem barButtonDeleteItem;
        private DevExpress.XtraBars.BarDockControl barDockControl7;
        private DevExpress.XtraBars.BarDockControl barDockControl8;
        private DevExpress.XtraBars.BarDockControl barDockControl6;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup chkCurrency;
        private DevExpress.XtraBars.Bar bar4;
    }
}
