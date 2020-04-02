namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    partial class UserControlBudgetSourceList
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
            this.treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList.OptionsBehavior.AllowIncrementalSearch = true;
            this.treeList.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.EnableFiltering = true;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.ParentFieldName = "";
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.TreeListNodeCellStyle);
            // 
            // barButtonAddNewItem
            // 
            this.barButtonAddNewItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // UserControlBudgetSourceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ExpandAll = true;
            this.FormCaption = "Nguồn vốn";
            this.FormDetail = "FrmXtraBudgetSourceDetail";
            this.Name = "UserControlBudgetSourceList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormDictionary";
            this.ParentFieldName = "ParentId";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAddNewItem)});
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.TablePrimaryKey = "BudgetSourceId";
            this.VisibleButtonAddNew = true;
            this.VisibleButtonDelete = true;
            this.VisibleButtonEdit = true;
            this.VisibleButtonFind = true;
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}
