namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraPlanTemplateItem
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlanTemplateItemCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlanTemplateItemName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spnPlanYear = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkCheck = new DevExpress.XtraEditors.CheckEdit();
            this.grdPlanTemplateList = new DevExpress.XtraEditors.GridLookUpEdit();
            this.grdPlanTemplateListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdPlanTemplateItem = new DevExpress.XtraGrid.GridControl();
            this.contextmnuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BudgetItembindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnGetBudgetItemList = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonDeleteRowItem = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.cboPlanType = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cboPlanTypeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanTemplateItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanTemplateItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPlanYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanTemplateList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanTemplateListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanTemplateItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudgetItembindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanTypeView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(463, 433);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(539, 433);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 433);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.btnGetBudgetItemList);
            this.groupboxMain.Controls.Add(this.grdPlanTemplateItem);
            this.groupboxMain.Controls.Add(this.groupControl1);
            this.groupboxMain.Controls.Add(this.spnPlanYear);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.txtPlanTemplateItemName);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtPlanTemplateItemCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.cboPlanType);
            this.groupboxMain.Size = new System.Drawing.Size(600, 418);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã mẫu dự toán (*)";
            // 
            // txtPlanTemplateItemCode
            // 
            this.txtPlanTemplateItemCode.Location = new System.Drawing.Point(114, 24);
            this.txtPlanTemplateItemCode.Name = "txtPlanTemplateItemCode";
            this.txtPlanTemplateItemCode.Size = new System.Drawing.Size(160, 20);
            this.txtPlanTemplateItemCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên mẫu dự toán (*)";
            // 
            // txtPlanTemplateItemName
            // 
            this.txtPlanTemplateItemName.Location = new System.Drawing.Point(114, 50);
            this.txtPlanTemplateItemName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtPlanTemplateItemName.Name = "txtPlanTemplateItemName";
            this.txtPlanTemplateItemName.Size = new System.Drawing.Size(477, 20);
            this.txtPlanTemplateItemName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(100, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "&Loại mẫu dự toán (*)";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(429, 79);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "&Năm dự toán(*)";
            // 
            // spnPlanYear
            // 
            this.spnPlanYear.EditValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnPlanYear.Location = new System.Drawing.Point(511, 76);
            this.spnPlanYear.Name = "spnPlanYear";
            this.spnPlanYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnPlanYear.Properties.Mask.EditMask = "d";
            this.spnPlanYear.Properties.MaxValue = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.spnPlanYear.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnPlanYear.Size = new System.Drawing.Size(80, 20);
            this.spnPlanYear.TabIndex = 7;
            this.spnPlanYear.EditValueChanged += new System.EventHandler(this.spnPlanYear_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkCheck);
            this.groupControl1.Controls.Add(this.grdPlanTemplateList);
            this.groupControl1.Location = new System.Drawing.Point(9, 102);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(582, 51);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "                                                                         ";
            // 
            // chkCheck
            // 
            this.chkCheck.Location = new System.Drawing.Point(13, 0);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkCheck.Properties.Appearance.Options.UseBackColor = true;
            this.chkCheck.Properties.Caption = "Tạo mẫu dự toán mới &dựa vào mẫu đã có";
            this.chkCheck.Size = new System.Drawing.Size(217, 19);
            this.chkCheck.TabIndex = 0;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            // 
            // grdPlanTemplateList
            // 
            this.grdPlanTemplateList.Location = new System.Drawing.Point(9, 23);
            this.grdPlanTemplateList.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.grdPlanTemplateList.Name = "grdPlanTemplateList";
            this.grdPlanTemplateList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdPlanTemplateList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdPlanTemplateList.Properties.NullText = "";
            this.grdPlanTemplateList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdPlanTemplateList.Properties.View = this.grdPlanTemplateListView;
            this.grdPlanTemplateList.Size = new System.Drawing.Size(564, 20);
            this.grdPlanTemplateList.TabIndex = 1;
            this.grdPlanTemplateList.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.grdPlanTemplateList_Closed);
            this.grdPlanTemplateList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPlanTemplateList_KeyDown);
            // 
            // grdPlanTemplateListView
            // 
            this.grdPlanTemplateListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdPlanTemplateListView.Name = "grdPlanTemplateListView";
            this.grdPlanTemplateListView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdPlanTemplateListView.OptionsView.ShowGroupPanel = false;
            // 
            // grdPlanTemplateItem
            // 
            this.grdPlanTemplateItem.ContextMenuStrip = this.contextmnuDelete;
            this.grdPlanTemplateItem.DataSource = this.BudgetItembindingSource;
            this.grdPlanTemplateItem.Location = new System.Drawing.Point(9, 189);
            this.grdPlanTemplateItem.MainView = this.gridViewDetail;
            this.grdPlanTemplateItem.Name = "grdPlanTemplateItem";
            this.grdPlanTemplateItem.Size = new System.Drawing.Size(582, 224);
            this.grdPlanTemplateItem.TabIndex = 10;
            this.grdPlanTemplateItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // contextmnuDelete
            // 
            this.contextmnuDelete.Name = "contextMenuStrip1";
            this.contextmnuDelete.Size = new System.Drawing.Size(61, 4);
            this.contextmnuDelete.Text = "Xóa dòng";
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.gridViewDetail.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDetail.GridControl = this.grdPlanTemplateItem;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.NewItemRowText = "Thêm dòng mới";
            this.gridViewDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewDetail.OptionsView.ShowIndicator = false;
            this.gridViewDetail.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewDetail_PopupMenuShowing);
            this.gridViewDetail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewDetail_InvalidRowException);
            // 
            // btnGetBudgetItemList
            // 
            this.btnGetBudgetItemList.Location = new System.Drawing.Point(450, 159);
            this.btnGetBudgetItemList.Name = "btnGetBudgetItemList";
            this.btnGetBudgetItemList.Size = new System.Drawing.Size(141, 24);
            this.btnGetBudgetItemList.TabIndex = 9;
            this.btnGetBudgetItemList.Text = "&Chọn chỉ tiêu từ danh sách";
            this.btnGetBudgetItemList.Click += new System.EventHandler(this.btnGetBudgetItemList_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDeleteRowItem)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonDeleteRowItem
            // 
            this.barButtonDeleteRowItem.Caption = "Xóa dòng";
            this.barButtonDeleteRowItem.Id = 1;
            this.barButtonDeleteRowItem.Name = "barButtonDeleteRowItem";
            this.barButtonDeleteRowItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDeleteRowItem_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barButtonDeleteRowItem});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(618, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 467);
            this.barDockControlBottom.Size = new System.Drawing.Size(618, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 467);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(618, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 467);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Xóa dòng";
            this.barSubItem1.Id = 0;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // cboPlanType
            // 
            this.cboPlanType.EditValue = ((short)(0));
            this.cboPlanType.Location = new System.Drawing.Point(114, 76);
            this.cboPlanType.Name = "cboPlanType";
            this.cboPlanType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPlanType.Properties.NullText = "";
            this.cboPlanType.Properties.PopupSizeable = false;
            this.cboPlanType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboPlanType.Properties.View = this.cboPlanTypeView;
            this.cboPlanType.Size = new System.Drawing.Size(308, 20);
            this.cboPlanType.TabIndex = 5;
            this.cboPlanType.EditValueChanged += new System.EventHandler(this.cboPlanType_EditValueChanged);
            // 
            // cboPlanTypeView
            // 
            this.cboPlanTypeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cboPlanTypeView.Name = "cboPlanTypeView";
            this.cboPlanTypeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cboPlanTypeView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraPlanTemplateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 467);
            this.ComponentName = "Mẫu dự toán";
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.EventTime = new System.DateTime(2020, 3, 16, 21, 23, 47, 890);
            this.FormCaption = "Mẫu dự toán";
            this.Name = "FrmXtraPlanTemplateItem";
            this.Reference = "THÊM MẪU DỰ TOÁN - ID ";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FrmXtraPlanTemplateItem";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanTemplateItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanTemplateItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPlanYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanTemplateList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanTemplateListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanTemplateItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudgetItembindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanTypeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtPlanTemplateItemName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPlanTemplateItemCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit spnPlanYear;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnGetBudgetItemList;
        private DevExpress.XtraGrid.GridControl grdPlanTemplateItem;
        protected System.Windows.Forms.BindingSource BudgetItembindingSource;
        protected System.Windows.Forms.ContextMenuStrip contextmnuDelete;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonDeleteRowItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        protected DevExpress.XtraEditors.CheckEdit chkCheck;
        private DevExpress.XtraEditors.GridLookUpEdit grdPlanTemplateList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPlanTemplateListView;
        private DevExpress.XtraEditors.GridLookUpEdit cboPlanType;
        private DevExpress.XtraGrid.Views.Grid.GridView cboPlanTypeView;
    }
}