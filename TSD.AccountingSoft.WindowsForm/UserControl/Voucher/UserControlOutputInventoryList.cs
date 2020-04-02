/***********************************************************************
 * <copyright file="UserControlOutputInventoryList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Inventory;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.Presenter.Inventory.OutputInventory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// UserControlOutputInventoryList
    /// </summary>
    public partial class UserControlOutputInventoryList : BaseVoucherListUserControl, IItemTransactionsView, IInventoryItemsView
    {
        /// <summary>
        /// The _output inventories presenter
        /// </summary>
        private readonly OutputInventoriesPresenter  _outputInventoriesPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly RepositoryItemGridLookUpEdit _rpsInventoryItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlOutputInventoryList"/> class.
        /// </summary>
        public UserControlOutputInventoryList()
        {
            InitializeComponent();
            _rpsInventoryItem = new RepositoryItemGridLookUpEdit();
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _outputInventoriesPresenter = new OutputInventoriesPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
        }

        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                var resultList = new List<InventoryItemModel>();

                resultList = value.Where(x => x.IsActive).ToList();
               // var inventory = GlobalVariable.CurrencyType == 0 ? resultList.Where(x => x.CurrencyCode.Trim() == "USD") : resultList.Where(x => x.CurrencyCode.Trim() != "USD");

                _rpsInventoryItem.DataSource = resultList;// value;
                _rpsInventoryItem.PopulateViewColumns();
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ToolTip = "Mã vật tư", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ToolTip = "Tên vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "StockId", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Unit", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "ExpenseAccountCode", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "", ColumnVisible = false });

                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        _rpsInventoryItem.View.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        _rpsInventoryItem.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _rpsInventoryItem.View.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _rpsInventoryItem.View.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else _rpsInventoryItem.View.Columns[column.ColumnName].Visible = false;
                }
                _rpsInventoryItem.View.OptionsView.ShowIndicator = false;
                _rpsInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _rpsInventoryItem.DisplayMember = "InventoryItemCode";
                _rpsInventoryItem.ValueMember = "InventoryItemId";
            }
        }

        /// <summary>
        /// Sets the ItemTransaction vouchers.
        /// </summary>
        /// <value>
        /// The ItemTransaction vouchers.
        /// </value>
        public IList<Model.BusinessObjects.Inventory.ItemTransactionModel> ItemTransactions
        {
            set
            {
             
                var inventory = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD") : value.Where(x => x.CurrencyCode.Trim() != "USD");
                bindingSource.DataSource = inventory;
                gridView.PopulateColumns(inventory);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentInclude", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ItemTransactionDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCalculatePrice", ColumnVisible = false });
               }
        }

        public IList<Model.BusinessObjects.Inventory.ItemTransactionDetailModel> ItemTransactionDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AutoBusinessId",
                    ColumnCaption = "ĐK tự động",
                    ToolTip = "Định khoản tự động",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", FixedColumn = FixedStyle.Left, ColumnCaption = "Vật tư", ToolTip = "Vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, RepositoryControl = _rpsInventoryItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Nợ", ToolTip = "Tài khoản nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Có", ToolTip = "Tài khoản có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", FixedColumn = FixedStyle.None, ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CancelQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số hỏng,hủy", ColumnPosition = 6, ColumnVisible = false, ColumnWith = 80, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FreeQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số miễn phí", ColumnPosition = 7, ColumnVisible = false, ColumnWith = 80, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "số thực dùng", ColumnPosition = 8, ColumnVisible = false, ColumnWith = 80, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số lượng ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền QĐ", ToolTip = "Thành tiền quy đổi", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Price", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PriceExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá QĐ", ToolTip = "Đơn giá quy đổi", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", FixedColumn = FixedStyle.None, ColumnCaption = "Nguồn vốn", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", FixedColumn = FixedStyle.None, ColumnCaption = "Mục/TM", ToolTip = "Mục tiểu mục", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", FixedColumn = FixedStyle.None, ColumnCaption = "Nghiệp vụ", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _rpsVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", FixedColumn = FixedStyle.None, ColumnCaption = "Phòng ban", ColumnPosition = 17, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Dự án", ColumnPosition = 18, ColumnVisible = false, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Đối tượng khác", ColumnVisible = false, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", FixedColumn = FixedStyle.None, ColumnCaption = "Quỹ sát nhập", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _outputInventoriesPresenter.Display((int)RefTypeId);
            _voucherTypesPresenter.Display();
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(long refId)
        {
            _inventoryItemsPresenter.Display();
            _outputInventoriesPresenter.DisplayVoucherDetail(refId);
        }
 
        public void RefreshFrm()
        {
            LoadDataIntoGrid();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new OutputInventoryPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Sets the grid numeric format.
        /// </summary>
        //protected override void SetGridNumericFormat()
        //{
        //    foreach (GridColumn oCol in gridView.Columns)
        //    {
        //        if (!oCol.Visible) continue;
        //        switch (oCol.UnboundType)
        //        {
        //            case UnboundColumnType.Decimal:
        //                oCol.DisplayFormat.FormatString = GlobalVariable.CurrencyDisplayString;
        //                Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalDigits =3 ;
        //                oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
        //                // oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalDigits;
        //                oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
        //                oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
        //                oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
        //                break;
        //            case UnboundColumnType.Integer:
        //                oCol.DisplayFormat.FormatString = GlobalVariable.NumericDisplayString;
        //                oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
        //                break;
        //            case UnboundColumnType.DateTime:
        //                oCol.DisplayFormat.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
        //                oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraOutputInventoryDetail();
        }

    }
}
