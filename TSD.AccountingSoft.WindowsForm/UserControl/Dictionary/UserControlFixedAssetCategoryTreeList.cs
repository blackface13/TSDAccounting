/***********************************************************************
 * <copyright file="UserControlFixedAssetCategoryTreeList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraTreeList;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// UserControl FixedAsset Category TreeList
    /// </summary>
    public partial class UserControlFixedAssetCategoryTreeList : BaseTreeListUserControl, IFixedAssetCategoriesView
    {
        /// <summary>
        /// The _fixed asset categorys presenter
        /// </summary>
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlFixedAssetCategoryTreeList"/> class.
        /// </summary>
        public UserControlFixedAssetCategoryTreeList()
        {
            InitializeComponent();
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);

            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();
        }

        #region IFixedAssetCategoryView Members

        /// <summary>
        /// Sets the fixed asset categorys.
        /// </summary>
        /// <value>
        /// The fixed asset categorys.
        /// </value>
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                treeList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryCode", ColumnCaption = "Mã nhóm", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên nhóm", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnCaption = "Thời gian sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 80, Alignment = HorzAlignment.Center, ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnCaption = "Tỷ lệ hao mòn", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 80, Alignment = HorzAlignment.Center, ColumnType = UnboundColumnType.Integer });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Ngừng sử dụng", ColumnVisible = true, ColumnPosition = 5, ColumnWith = 80, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
            }
        }

        #endregion

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _fixedAssetCategoriesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteTree()
        {
            new FixedAssetCategoryPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraFixedAssetCategoryTreeDetail();
        }

        /// <summary>
        /// Handles the CustomDrawNodeCell event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CustomDrawNodeCellEventArgs"/> instance containing the event data.</param>
        private void treeList_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (!(e.CellValue is decimal)) return;
            if ((decimal) e.CellValue != 0) return;
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsParent"]) ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }

    }
}
