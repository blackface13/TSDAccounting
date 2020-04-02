/***********************************************************************
 * <copyright file="FrmXtraOpeningInventoryEntryDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   thangNK
 * Email:    ThangNK@buca.vn
 * Website:
 * Create Date: Tuesday, December 30, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Opening;
using TSD.AccountingSoft.Presenter.OpeningInventory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.OpeningInventoryEntry;
using TSD.AccountingSoft.View.OpeningInventoryEntry;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;


namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// FrmXtraOpeningInventoryEntryDetail
    /// </summary>
    public partial class FrmXtraOpeningInventoryEntryDetail : FrmXtraBaseTreeDetail, IAccountsView, IOpeningInventoryEntriesView, IStocksView, IInventoryItemsView //(Source Grid)

    {
        #region Presenter
        protected GlobalVariable DBOptionHelper;
        private readonly OpeningInventoryEntriesPresenter _openingInventoryEntriesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly OpeningInventoryEntryPresenter _openingInventoryEntryPresenter;
        private IList<AccountModel> _accounts;
        private AccountModel _account;
        /// <summary>

        /// </summary>
        private readonly StocksPresenter _stocksPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        #endregion

        #region Repository Controls



        /// <summary>
        /// The _cbo currency code
        /// </summary>
        private RepositoryItemComboBox _cboCurrencyCode;
        /// <summary>
        /// The _calc edit exchange rate
        /// </summary>
        private RepositoryItemCalcEdit _calcEditExchangeRate;

        /// <summary>
        /// The _RPS account number
        /// </summary>
        private RepositoryItemGridLookUpEdit _rpsStock;
        /// <summary>
        /// The _RPS account number view
        /// </summary>
        private GridView _rpsStockView;
        /// <summary>
        /// The _RPS corresponding account number
        /// </summary>
        private RepositoryItemGridLookUpEdit _rpsInventoryItem;
        /// <summary>
        /// The _RPS corresponding account number view
        /// </summary>
        private GridView _rpsInventoryItemView;
        #endregion

        #region Combobox Members



        #endregion


        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraOpeningInventoryEntryDetail" /> class.
        /// </summary>
        public FrmXtraOpeningInventoryEntryDetail()
        {
            InitializeComponent();
            //  _openingInventoryEntryPresenter = new OpeningInventoryEntryPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _openingInventoryEntriesPresenter = new OpeningInventoryEntriesPresenter(this);

        }

        /// <summary>
        /// Handles the ValidateRow event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ValidateRowEventArgs" /> instance containing the event data.</param>
        private void gridViewDetail_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                var CurrencyCodeCol = gridViewDetail.Columns["CurrencyCode"];
                var ExchangeRateCol = gridViewDetail.Columns["ExchangeRate"];
                var CurrencyCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, CurrencyCodeCol);
                var ExchangeRate = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, ExchangeRateCol);

                var budgetSourceCodeCol = gridViewDetail.Columns["BudgetSourceCode"];
                var budgetChapterCodeCol = gridViewDetail.Columns["BudgetChapterCode"];
                var budgetCategoryCodeCol = gridViewDetail.Columns["BudgetCategoryCode"];
                var budgetGroupItemCodeCol = gridViewDetail.Columns["BudgetGroupItemCode"];
                var budgetItemCodeCol = gridViewDetail.Columns["BudgetItemCode"];
                var mergerFundIdCol = gridViewDetail.Columns["MergerFundId"];
                var employeeIdCol = gridViewDetail.Columns["EmployeeId"];
                var customerIdCol = gridViewDetail.Columns["CustomerId"];
                var vendorIdCol = gridViewDetail.Columns["VendorId"];
                var accountingObjectIdCol = gridViewDetail.Columns["AccountingObjectId"];

                var budgetSourceCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetSourceCodeCol);
                var budgetChapterCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetChapterCodeCol);
                var budgetCategoryCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetCategoryCodeCol);
                var budgetGroupItemCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetGroupItemCodeCol);
                var budgetItemCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetItemCodeCol);
                var mergerFundId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, mergerFundIdCol);
                var employeeId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, employeeIdCol);
                var customerId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, customerIdCol);
                var vendorId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, vendorIdCol);
                var accountingObjectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, accountingObjectIdCol);

                bool flag = true;
                var stockCol = gridViewDetail.Columns["StockId"];
                var stockId = (int)gridViewDetail.GetFocusedRowCellValue(stockCol);
                var inventoryItemIdCol = gridViewDetail.Columns["InventoryItemId"];
                var inventoryItemId = (int)gridViewDetail.GetFocusedRowCellValue(stockCol);
                if (inventoryItemId <= 0)
                {
                    gridViewDetail.SetColumnError(stockCol, "Vật tư không được để trống");
                    e.Valid = false;
                }
                if (stockId <= 0)
                {
                    flag = false;
                    // XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridViewDetail.SetColumnError(stockCol, "Kho không được để trống");
                    e.Valid = false;
                }
                if (CurrencyCode == null)
                {
                    flag = false;
                    gridViewDetail.SetColumnError(CurrencyCodeCol, "Mã tiền không được để trống");
                    e.Valid = false;
                }
                if (ExchangeRate == 0)
                {
                    flag = false;
                    gridViewDetail.SetColumnError(ExchangeRateCol, "Tỷ giá  phải > 0");
                    e.Valid = false;
                }
                if (flag == true)
                {
                    e.Valid = true;
                }
                //if (_account.IsBudgetSource)
                //{
                //    if (string.IsNullOrEmpty(budgetSourceCode))
                //    {

                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(budgetSourceCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailBudgetSourceCode"));
                //    }
                //}

                //if (_account.IsChapter)
                //{
                //    if (string.IsNullOrEmpty(budgetChapterCode))
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(budgetChapterCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailBudgetChapterCode"));
                //    }
                //}

                //if (_account.IsBudgetCategory)
                //{
                //    if (string.IsNullOrEmpty(budgetCategoryCode))
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(budgetCategoryCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailBudgetCategoryCode"));
                //    }
                //}

                //if (_account.IsBudgetGroup)
                //{
                //    if (string.IsNullOrEmpty(budgetGroupItemCode))
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(budgetGroupItemCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailBudgetGroupItemCode"));
                //    }
                //}

                //if (_account.IsBudgetItem)
                //{
                //    if (string.IsNullOrEmpty(budgetItemCode))
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(budgetItemCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailBudgetItemCode"));
                //    }
                //}

                //if (_account.IsCapitalAllocate)
                //{
                //    if (mergerFundId == null)
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(mergerFundIdCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailMergerFundId"));
                //    }
                //}

                //if (_account.IsEmployee)
                //{
                //    if (employeeId == null)
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(employeeIdCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailEmployeeId"));
                //    }
                //}

                //if (_account.IsCustomer)
                //{
                //    if (customerId == null)
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(customerIdCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailCustomerId"));
                //    }
                //}

                //if (_account.IsVendor)
                //{
                //    if (vendorId == null)
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(vendorIdCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailVendorId"));
                //    }
                //}

                //if (_account.IsAccountingObject)
                //{
                //    if (accountingObjectId == null)
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(accountingObjectIdCol, ResourceHelper.GetResourceValueByName("ResOpeningInventoryEntryDetailAccountingObjectId"));
                //    }
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the InvalidRowException event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InvalidRowExceptionEventArgs" /> instance containing the event data.</param>
        private void gridViewDetail_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void gridViewDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdDetail.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the barButtonDeleteRowItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        private void barButtonDeleteRowItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewDetail.DeleteSelectedRows();
        }

        #endregion

        #region Function Overrides

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            DBOptionHelper = new GlobalVariable();

            _accountsPresenter.Display();

            _account = (from accountModel in _accounts where accountModel.AccountId == int.Parse(KeyValue) select accountModel).FirstOrDefault();

            _cboCurrencyCode.Items.Add(CurrencyAccounting);

            if (CurrencyLocal != CurrencyAccounting)
            {
                _cboCurrencyCode.Items.Add(CurrencyLocal);
            }

            _inventoryItemsPresenter.Display(); //Display
            //_stocksPresenter.DisplayActive(true)
            _stocksPresenter.Display();
            if (_account == null) return;
            // _openingInventoryEntryPresenter.Display(_account.AccountCode);

            _openingInventoryEntriesPresenter.Display(_account.AccountCode);
            Text = @"Nhập số dư ban đầu cho tài khoản " + _account.AccountCode;
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {

            _cboCurrencyCode = new RepositoryItemComboBox();
            _cboCurrencyCode.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridViewDetail.OptionsView.ShowFooter = true;
            //RepositoryItemCalcEdit ExchangeRate
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.EditFormat.FormatType = FormatType.Numeric;
            _calcEditExchangeRate.EditMask = @"F" + ExchangeRateDecimalDigits;

            _rpsStock = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsStockView = new GridView();
            _rpsStock.View = _rpsStockView;
            _rpsStock.TextEditStyle = TextEditStyles.Standard;
            _rpsStock.ShowFooter = false;

            _rpsInventoryItem = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsInventoryItemView = new GridView();
            _rpsInventoryItem.View = _rpsInventoryItemView;
            _rpsInventoryItem.TextEditStyle = TextEditStyles.Standard;
            _rpsInventoryItem.ShowFooter = false;


            ////RepositoryItemGridLookUpEdit AccountingObject
            //_gridLookUpEditAccountingObjectView = new GridView();
            //_gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
            //_gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
            //{
            //    NullText = "",
            //    View = _gridLookUpEditAccountingObjectView,
            //    TextEditStyle = TextEditStyles.Standard,
            //    PopupResizeMode = ResizeMode.FrameResize,
            //    PopupFormSize = new Size(500, 200),
            //    ShowFooter = false
            //};
            //_gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            //_gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
            //_gridLookUpEditAccountingObject.View.BestFitColumns();
        }

        /// <summary>
        /// Sets the numeric format control.
        /// LINHMC add repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.UnitPriceDecimalDigits);
        /// quy định số chữ số thập phân đằng sau dấu phẩy khi dropdown RepositoryItemCalcEdit
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected override void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;

            foreach (GridColumn oCol in gridView.Columns)
            {
                var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        //   repositoryCurrencyCalcEdit.EditMask.Re
                        if (oCol.FieldName == "UnitPriceOc" || oCol.FieldName == "UnitPriceExchange")
                        {
                            repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.UnitPriceDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.UnitPriceDecimalDigits);
                            repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                            repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                            oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                            if (isSummary)
                            {
                                oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                                oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                                oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;

                            }
                            break;
                        }
                        if (oCol.FieldName == "AmountOc")
                        {
                            repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.CurrencyDecimalDigits);
                            repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                            repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                            oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                            if (isSummary)
                            {
                                oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                                oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                                oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;

                            }
                            break;
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.CurrencyDecimalDigits);
                            repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                            repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                            oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                            if (isSummary)
                            {
                                oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                                oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                                oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;

                            }
                            break;
                        }

                    //   repositoryCurrencyCalcEdit.Mask.EditMask = @"c3";

                    //  break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            //if (AccountNumber == null)
            //    AccountNumber = _account.AccountCode;
            //if (RefTypeId == 0)
            //    RefTypeId = 700;
            if (PostedDate.Year.Equals(1))
                PostedDate = (DateTime.Parse(GlobalVariable.SystemDate)).AddDays(-1);
            gridViewDetail.CloseEditor();
            if (gridViewDetail.UpdateCurrentRow())
                return (int)_openingInventoryEntriesPresenter.Save();
            return 0;
        }

        #endregion

        /// <summary>
        /// Handles the CellValueChanged event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                var currencyCodeCol = gridViewDetail.Columns["CurrencyCode"];
                var exchangeRateCol = gridViewDetail.Columns["ExchangeRate"];

                var debitAmountOCCol = gridViewDetail.Columns["DebitAmountOC"];
                var creditAmountOCCol = gridViewDetail.Columns["CreditAmountOC"];
                var debitAmountExchangeCol = gridViewDetail.Columns["DebitAmountExchange"];
                var creditAmountExchangeCol = gridViewDetail.Columns["CreditAmountExchange"];
                //     decimal exchangeRate;

                switch (e.Column.FieldName)
                {

                    case "StockId":
                        var stockId = (int)gridViewDetail.GetRowCellValue(e.RowHandle, "StockId");
                        //  var postedDate = PostedDate;
                        //   var currencyCode = (string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");
                        if (stockId > 0)
                        {
                            _inventoryItemsPresenter.DisplayByStock(stockId);
                        }

                        break;
                    case "CurrencyCode":
                        var currencyCode = gridViewDetail.GetRowCellValue(e.RowHandle, currencyCodeCol) == null ? null :
                            gridViewDetail.GetRowCellValue(e.RowHandle, currencyCodeCol).ToString();
                        if (currencyCode == CurrencyAccounting)
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, exchangeRateCol, "1");
                            gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                        }
                        else
                        {
                            gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                        }
                        break;
                    case "Quantity":
                        //var quantityCol = gridViewDetail.Columns["Quantity"];
                        //var amountOcCol = gridViewDetail.Columns["AmountOc"]; 
                        //var amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        //var unitPriceOCCol = gridViewDetail.Columns["UnitPriceOc"];
                        //var unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];                     

                        //var quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        //var amountOc = (decimal)gridViewDetail.GetFocusedRowCellValue(amountOcCol); 
                        //var exchangeRate = (decimal)gridViewDetail.GetFocusedRowCellValue(exchangeRateCol);
                        //var unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);                     
                        //gridViewDetail.SetRowCellValue(e.RowHandle, amountOcCol, quantity * unitPriceOC);
                        //if (quantity>0) 
                        //{
                        ////    gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceOCCol, amountOc / quantity);
                        //}                       
                        //if (exchangeRate >0)
                        //{
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceOC / exchangeRate);
                        ////    gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, unitPriceOC / exchangeRate);
                        //}                     
                        break;

                    case "UnitPriceOc":
                        var quantityCol = gridViewDetail.Columns["Quantity"];
                        var amountOcCol = gridViewDetail.Columns["AmountOc"];
                        var amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        var unitPriceOCCol = gridViewDetail.Columns["UnitPriceOc"];
                        var unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];

                        var quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        var amountOc = (decimal)gridViewDetail.GetFocusedRowCellValue(amountOcCol);
                        var exchangeRate = (decimal)gridViewDetail.GetFocusedRowCellValue(exchangeRateCol);
                        var unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);
                        //gridViewDetail.SetRowCellValue(e.RowHandle, amountOcCol, quantity * unitPriceOC);
                        //if (quantity>0) 
                        //{
                        ////    gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceOCCol, amountOc / quantity);
                        //}                       
                        //if (exchangeRate >0)
                        //{
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceOC / exchangeRate);
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, unitPriceOC / exchangeRate);
                        //}                     
                        break;
                    case "AmountOc":
                        quantityCol = gridViewDetail.Columns["Quantity"];
                        amountOcCol = gridViewDetail.Columns["AmountOc"];
                        amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        unitPriceOCCol = gridViewDetail.Columns["UnitPriceOc"];
                        unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];

                        quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        amountOc = (decimal)gridViewDetail.GetFocusedRowCellValue(amountOcCol);
                        exchangeRate = (decimal)gridViewDetail.GetFocusedRowCellValue(exchangeRateCol);
                        unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, amountOcCol, quantity * unitPriceOC);
                        if (quantity > 0)
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceOCCol, amountOc / quantity);
                        }
                        if (exchangeRate > 0)
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, Math.Round(amountOc / exchangeRate, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, amountOc / (exchangeRate * quantity));
                        }
                        break;

                        //    case "AmountExchange":
                        //quantityCol = gridViewDetail.Columns["Quantity"];
                        // amountOcCol = gridViewDetail.Columns["AmountOc"]; 
                        // amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        // unitPriceOCCol = gridViewDetail.Columns["UnitPriceOc"];
                        // unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];                     

                        // quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        // amountOc = (decimal)gridViewDetail.GetFocusedRowCellValue(amountOcCol); 
                        // exchangeRate = (decimal)gridViewDetail.GetFocusedRowCellValue(exchangeRateCol);
                        // unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);                     
                        //gridViewDetail.SetRowCellValue(e.RowHandle, amountOcCol, quantity * unitPriceOC);
                        //if (quantity>0) 
                        //{
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceOCCol, amountOc / quantity);
                        //}                       
                        //if (exchangeRate >0)
                        //{
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceOC / exchangeRate);
                        //    gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, unitPriceOC / exchangeRate);
                        //}                     
                        //     break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region OpeningInventory Members



        public IList<OpeningInventoryEntryModel> OpeningInventoryEntries
        {
            get
            {
                var openingInventoryEntryDetails = new List<OpeningInventoryEntryModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            openingInventoryEntryDetails.Add(new OpeningInventoryEntryModel
                            {
                                RefTypeId = 701,
                                PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                                AccountNumber = _account.AccountCode,
                                UnitPriceOc = (decimal)gridViewDetail.GetRowCellValue(i, "UnitPriceOc"),
                                UnitPriceExchange = (decimal)gridViewDetail.GetRowCellValue(i, "UnitPriceExchange"),
                                AmountOc = (decimal)gridViewDetail.GetRowCellValue(i, "AmountOc"),
                                AmountExchange = (decimal)gridViewDetail.GetRowCellValue(i, "AmountExchange"),
                                Quantity = (int)gridViewDetail.GetRowCellValue(i, "Quantity"),
                                InventoryItemId = (int)gridViewDetail.GetRowCellValue(i, "InventoryItemId"),
                                StockId = (int)gridViewDetail.GetRowCellValue(i, "StockId"),
                                CurrencyCode = (string)gridViewDetail.GetRowCellValue(i, "CurrencyCode"),
                                ExchangeRate = (decimal)gridViewDetail.GetRowCellValue(i, "ExchangeRate"),
                            });
                        }

                    }
                    if (gridViewDetail.RowCount == 1 && gridViewDetail.GetRow(0) == null)
                    {
                        openingInventoryEntryDetails.Add(new OpeningInventoryEntryModel
                        {
                            RefTypeId = 8888,//Truong hop detail rong 
                            PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                            AccountNumber = _account.AccountCode,
                            UnitPriceOc = 0,
                            UnitPriceExchange = 0,
                            AmountOc = 0,
                            AmountExchange = 0,
                            Quantity = 0,
                            InventoryItemId = 0,
                            //(int)gridViewDetail.GetRowCellValue(i, "InventoryItemId"),
                            StockId = 0,
                            //(int)gridViewDetail.GetRowCellValue(i, "StockId"),
                            CurrencyCode = "",
                            ExchangeRate = 0,
                        });
                    }
                }
                else
                {

                }
                return openingInventoryEntryDetails.ToList();
            }
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                    {
                          new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},

                        new XtraColumn {ColumnName = "AccountNumber", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                          new XtraColumn {ColumnName = "RefNo", ColumnVisible = false},

                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountName", ColumnVisible = false},

                        new XtraColumn{ ColumnName = "CurrencyCode",
                        ColumnCaption = "Loại tiền tệ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        RepositoryControl = _cboCurrencyCode},
                     new XtraColumn{ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        RepositoryControl = _calcEditExchangeRate
                     },

                     new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnCaption = "Kho",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 130,
                        RepositoryControl = _rpsStock
                    },
                         new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnCaption = "Vật tư",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 130,
                        RepositoryControl = _rpsInventoryItem
                    },
                      new XtraColumn{ColumnName = "Quantity",
                        ColumnCaption = "Số lượng",
                        ColumnPosition =5,
                        ColumnVisible = true,
                        ColumnWith = 100,
                           ColumnType = UnboundColumnType.Integer
                     },
                      new XtraColumn{ColumnName = "AmountOc",
                        ColumnCaption = "Thành tiền",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnWith = 100,
                           ColumnType = UnboundColumnType.Decimal
                     },
                       new XtraColumn{ColumnName = "AmountExchange",
                        ColumnCaption = "Thành tiền qđ",
                        ToolTip ="Thành tiền quy đổi",
                        ColumnPosition = 7,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal
                     },
                      new XtraColumn{ColumnName = "UnitPriceOc",
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 8,
                        ColumnVisible = true,
                        ColumnWith = 100,
                           ColumnType = UnboundColumnType.Decimal
                     },
                      new XtraColumn{ColumnName = "UnitPriceExchange",
                        ColumnCaption = "Đơn giá quy đổi",
                        ColumnPosition = 9,
                        ColumnVisible = true,
                        ColumnWith = 100,
                           ColumnType = UnboundColumnType.Decimal
                     }

                    };
                foreach (var column in gridColumnsCollection)
                {
                    //gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else
                        gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }
        #endregion
        public IList<AccountModel> Accounts
        {
            set { _accounts = value; }
        }



        public IList<StockModel> Stocks
        {
            set
            {
                var resultList = value.Where(x => x.IsActive == true).ToList();
                _rpsStock.DataSource = resultList;// value;

                _rpsStock.PopulateViewColumns();
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ToolTip = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 200, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ToolTip = "Tên kho", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "StockId", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "", ColumnVisible = false });
                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        _rpsStockView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        _rpsStockView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _rpsStockView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        _rpsStockView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else _rpsStockView.Columns[column.ColumnName].Visible = false;
                }
                _rpsStock.BestFitMode = BestFitMode.BestFitResizePopup;
                _rpsStock.View.OptionsView.ShowIndicator = false;
                _rpsStock.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _rpsStock.DisplayMember = "StockCode";
                _rpsStock.ValueMember = "StockId";
            }
        }

        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                var resultList = value.Where(x => x.IsActive == true).ToList();
                _rpsInventoryItem.DataSource = resultList;// value;
                _rpsInventoryItem.PopulateViewColumns();
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ToolTip = "Mã vật tư", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ToolTip = "Tên vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Unit", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "StockId", ColumnCaption = "", ColumnVisible = false });
                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        _rpsInventoryItemView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        _rpsInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _rpsInventoryItemView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        _rpsInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else _rpsInventoryItemView.Columns[column.ColumnName].Visible = false;
                }
                _rpsInventoryItem.BestFitMode = BestFitMode.BestFitResizePopup;
                _rpsInventoryItem.View.OptionsView.ShowIndicator = false;
                //    _rpsInventoryItem.View.ActiveFilterString = "[BudgetItemType] >=3";
                _rpsInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _rpsInventoryItem.DisplayMember = "InventoryItemCode";
                _rpsInventoryItem.ValueMember = "InventoryItemId";
            }
        }
    }
}