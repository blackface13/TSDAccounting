namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    partial class UserControlOpeningAccountEntryList
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
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeList.KeyFieldName = "";
            this.treeList.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.treeList.OptionsFind.ShowClearButton = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowSummaryFooter = true;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.ParentFieldName = "";
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle);
            // 
            // barButtonAddNewItem
            // 
            this.barButtonAddNewItem.Caption = "Nhập số dư đầu kỳ";
            this.barButtonAddNewItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // UserControlOpeningAccountEntryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ComponentName = "Số dư đầu kỳ tài khoản";
            this.EventAction = 4;
            this.EventTime = new System.DateTime(2015, 10, 16, 11, 20, 15, 260);
            this.ExpandAll = true;
            this.FormCaption = "số dư đầu kỳ tài khoản";
            this.FormDetail = "FrmXtraOpeningAccountEntryDetail";
            this.Name = "UserControlOpeningAccountEntryList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormBusiness";
            this.ParentFieldName = "ParentId";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddNewItem)});
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "XEM SỐ DƯ ĐẦU KỲ TÀI KHOẢN - ID ";
            this.TablePrimaryKey = "AccountId";
            this.VisibleButtonEdit = true;
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}
