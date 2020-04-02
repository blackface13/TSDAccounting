/***********************************************************************
 * <copyright file="UserControlAccountingObjectList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObjectCategory;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{

    /// <summary>
    /// UserControlAccountingObjectList class
    /// </summary>
    public partial class UserControlAccountingObjectList : BaseListUserControl, IAccountingObjectsView
    {
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        RepositoryItemGridLookUpEdit rpsAccountingObjectCategory;

        public UserControlAccountingObjectList()
        {
            InitializeComponent();

            rpsAccountingObjectCategory = new RepositoryItemGridLookUpEdit();
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>
        /// The accounting objects.
        /// </value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                value = value ?? new List<AccountingObjectModel>();
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 20 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FullName", ColumnCaption = "Tên đối tượng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnCaption = "Loại đối tượng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 80, RepositoryControl = rpsAccountingObjectCategory, ColumnType = DevExpress.Data.UnboundColumnType.String });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        public IList<ObjectGeneral> AccountingObjectCategories
        {
            set
            {
                if (rpsAccountingObjectCategory == null)
                    return;
                GridLookUpItem.ObjectGeneral(value ?? new List<ObjectGeneral>(), rpsAccountingObjectCategory, "ObjectGeneralName", "ObjectGeneralId");
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            AccountingObjectCategories = new ObjectGeneral().GetAccountingObjectCategories(true, false, true, true);
            _accountingObjectsPresenter.DisplayForList();
            gridView.OptionsView.ShowGroupedColumns = true;
            gridView.SortInfo.ClearAndAddRange(new[] {
                new GridColumnSortInfo(gridView.Columns["AccountingObjectCategoryId"], DevExpress.Data.ColumnSortOrder.Ascending)}, 1);
            gridView.Columns["AccountingObjectCategoryId"].SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            AccountingObjectModel row = gridView.GetRow(gridView.FocusedRowHandle) as AccountingObjectModel;
            if(row != null)
            {
                switch(row.AccountingObjectCategoryId)
                {
                    case 0:
                        new VendorPresenter(null).Delete(int.Parse(PrimaryKeyValue));
                        break;
                    case 2:
                        new AccountingObjectPresenter(null).Delete(int.Parse(PrimaryKeyValue));
                        break;
                    case 3:
                        new CustomerPresenter(null).Delete(int.Parse(PrimaryKeyValue));
                        break;
                }
            }
            else
            {
                throw new Exception("Xóa đối tượng không thành công!");
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            GridViewInfo info = gridView.GetViewInfo() as GridViewInfo;
            GridCellInfo cellInfo = info.GetGridCellInfo(gridView.FocusedRowHandle, gridView.Columns["AccountingObjectCode"]);
            if (cellInfo == null && ActionMode != TSD.Enum.ActionModeEnum.AddNew) return null;

            if (ActionMode == TSD.Enum.ActionModeEnum.AddNew)
            {
                var selectedObject = gridView.GetFocusedRow() as AccountingObjectModel;
                if (selectedObject == null)
                    return new FrmXtraAccountingObjectDetail();
                else
                    return new FrmXtraAccountingObjectDetail() { AccountingObjectCategoryId = selectedObject.AccountingObjectCategoryId };
            }
            else
            {
                var selectedObject = gridView.GetFocusedRow() as AccountingObjectModel;
                return new FrmXtraAccountingObjectDetail() { AccountingObjectCategoryId = selectedObject?.AccountingObjectCategoryId ?? 0 };
            }
        }
    }
}
