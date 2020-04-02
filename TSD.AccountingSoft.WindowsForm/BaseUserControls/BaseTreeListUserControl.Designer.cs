namespace TSD.AccountingSoft.WindowsForm.BaseUserControls
{
    partial class BaseTreeListUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseTreeListUserControl));
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
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.imageToobarCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.barToolManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonAddNewItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEditItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDeleteItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFindItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPrintItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefeshItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHelpItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 31);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.EnableFiltering = true;
            this.treeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.treeList.OptionsFind.ShowClearButton = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowAutoFilterRow = true;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeList.Size = new System.Drawing.Size(770, 506);
            this.treeList.TabIndex = 4;
            this.treeList.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterFocusNode);
            this.treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            this.treeList.DoubleClick += new System.EventHandler(this.treeList_DoubleClick);
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
            this.imageToobarCollection.Images.SetKeyName(8, "tree-add.png");
            this.imageToobarCollection.Images.SetKeyName(9, "tree-delete.png");
            this.imageToobarCollection.Images.SetKeyName(10, "tree-search.png");
            // 
            // barToolManager
            // 
            this.barToolManager.AllowCustomization = false;
            this.barToolManager.AllowMoveBarOnToolbar = false;
            this.barToolManager.AllowQuickCustomization = false;
            this.barToolManager.AllowShowToolbarsPopup = false;
            this.barToolManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
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
            this.barButtonFindItem});
            this.barToolManager.MaxItemId = 7;
            this.barToolManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barToolManager_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarItemHorzIndent = 7;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonAddNewItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonDeleteItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonFindItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonPrintItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonRefeshItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonHelpItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barButtonAddNewItem
            // 
            this.barButtonAddNewItem.Caption = "Thêm";
            this.barButtonAddNewItem.Id = 0;
            this.barButtonAddNewItem.ImageIndex = 8;
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
            this.barButtonDeleteItem.ImageIndex = 9;
            this.barButtonDeleteItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.barButtonDeleteItem.Name = "barButtonDeleteItem";
            superToolTip3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem3.Text = "<b>Xóa dữ liệu (Delete)</b>";
            superToolTip3.Items.Add(toolTipItem3);
            this.barButtonDeleteItem.SuperTip = superToolTip3;
            // 
            // barButtonFindItem
            // 
            this.barButtonFindItem.Caption = "Tìm";
            this.barButtonFindItem.Id = 6;
            this.barButtonFindItem.ImageIndex = 10;
            this.barButtonFindItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.barButtonFindItem.Name = "barButtonFindItem";
            superToolTip4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem4.Text = "<b>Tìm kiếm dữ liệu (Ctrl + F)</b>";
            superToolTip4.Items.Add(toolTipItem4);
            this.barButtonFindItem.SuperTip = superToolTip4;
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(770, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 537);
            this.barDockControlBottom.Size = new System.Drawing.Size(770, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 506);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(770, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 506);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddNewItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonEditItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDeleteItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefeshItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonFindItem)});
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // BaseTreeListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "BaseTreeListUserControl";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Size = new System.Drawing.Size(770, 537);
            this.Load += new System.EventHandler(this.BaseTreeListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageToobarCollection;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonEditItem;
        private DevExpress.XtraBars.BarButtonItem barButtonDeleteItem;
        private DevExpress.XtraBars.BarButtonItem barButtonPrintItem;
        private DevExpress.XtraBars.BarButtonItem barButtonRefeshItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonFindItem;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        protected DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraBars.BarButtonItem barButtonHelpItem;
        protected DevExpress.XtraBars.BarManager barToolManager;
        protected DevExpress.XtraBars.BarButtonItem barButtonAddNewItem;

    }
}
