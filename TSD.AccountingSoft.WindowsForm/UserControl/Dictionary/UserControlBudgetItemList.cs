/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlBudgetItemList.
    /// </summary>
    public partial class UserControlBudgetItemList : BaseTreeListUserControl, IBudgetItemsView
    {
        /// <summary>
        /// The _budget item presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBudgetItemList"/> class.
        /// </summary>
        public UserControlBudgetItemList()
        {
            InitializeComponent();
            _budgetItemPresenter = new BudgetItemsPresenter(this);

            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (var item in value)
                    {
                        if (item.BudgetItemType == 1)
                            item.BudgetItemTypeName = "Nhóm";
                        else if(item.BudgetItemType == 2)
                            item.BudgetItemTypeName = "Tiểu nhóm";
                        else if (item.BudgetItemType == 3)
                            item.BudgetItemTypeName = "Mục";
                        else if (item.BudgetItemType == 4)
                            item.BudgetItemTypeName = "Tiểu mục";
                    }
                }
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 60, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnVisible = true, ColumnPosition = 3, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsExpandItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsNoAllocate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsOrganItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false, ColumnCaption = "Loại MLNS", ColumnPosition = 4, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemTypeName", ColumnVisible = true, ColumnCaption = "Loại MLNS", ColumnPosition = 4, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsReceipt", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsChoose", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Rate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NumberOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsShowOnVoucher", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _budgetItemPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteTree()
        {
            new BudgetItemPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmxtraBudgetItemDetail();
        }

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsParent"]) || Convert.ToInt32(e.Node["BudgetItemType"]) < 3 ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }
    }
}

