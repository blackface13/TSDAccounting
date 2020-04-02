/***********************************************************************
 * <copyright file="UserControlBudgetCategoryList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{

    /// <summary>
    /// Class UserControlBudgetCategoryList.
    /// </summary>
    public partial class UserControlBudgetCategoryList : BaseTreeListUserControl, IBudgetCategoriesView
    {
        /// <summary>
        /// The _budget categories presenter
        /// </summary>
        private readonly BudgetCategoriesPresenter _budgetCategoriesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBudgetCategoryList" /> class.
        /// </summary>
        public UserControlBudgetCategoryList()
        {
            InitializeComponent();
            _budgetCategoriesPresenter = new BudgetCategoriesPresenter(this);
        }

        #region IBudgetCategoriesView Members
        /// <summary>
        /// Sets the budget categories.
        /// </summary>
        /// <value>The budget categories.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetCategoryModel> BudgetCategories
        {
            set
            {
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Mã loại khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 60, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryName", ColumnCaption = "Tên loại khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 340, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _budgetCategoriesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteTree()
        {
            new BudgetCategoryPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }
        #endregion

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsParent"]) ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraBudgetCategoryDetail();
        }
    }
}
