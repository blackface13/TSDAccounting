﻿namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    partial class UserControlFixedAssetCategoryTreeList
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
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            this.treeList.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.treeList.KeyFieldName = "";
            this.treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList.OptionsBehavior.AllowQuickHideColumns = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowSummaryFooter = true;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.ParentFieldName = "";
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle);
            this.treeList.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList_CustomDrawNodeCell);
            // 
            // barButtonAddNewItem
            // 
            this.barButtonAddNewItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // UserControlFixedAssetCategoryTreeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ExpandAll = true;
            this.FormCaption = "Nhóm tài sản cố định";
            this.FormDetail = "FrmXtraFixedAssetCategoryTreeDetail";
            this.Name = "UserControlFixedAssetCategoryTreeList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormDictionary";
            this.ParentFieldName = "ParentId";
            this.ReportID = "FixedAssetCategoryList";
            this.TablePrimaryKey = "FixedAssetCategoryId";
            this.VisibleButtonAddNew = true;
            this.VisibleButtonDelete = true;
            this.VisibleButtonEdit = true;
            this.VisibleButtonFind = true;
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barToolManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
