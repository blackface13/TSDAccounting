/***********************************************************************
 * <copyright file="UserControlInventoryItemList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlInventoryItemList
    /// </summary>
    public partial class UserControlInventoryItemList : BaseListUserControl, IInventoryItemsView
    {
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlInventoryItemList"/> class.
        /// </summary>
        public UserControlInventoryItemList()
        {
            InitializeComponent();
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
        }

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value> 
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Tài khoản kho", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnCaption = "Phướng pháp tính giá", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnCaption = "Đơn vị tính", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Theo dõi", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnCaption = "Mã kho", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExpenseAccountCode", ColumnCaption = "Tài khoản chi phí", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _inventoryItemsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new InventoryItemPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraInventoryItemDetail();
        }
    }
}
