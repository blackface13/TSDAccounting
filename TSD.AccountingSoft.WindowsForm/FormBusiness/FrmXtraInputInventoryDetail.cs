/***********************************************************************
 * <copyright file="FrmXtraInputInventoryDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM, ThangNK modified
 * Email:    tuanhm@buca.vn
 * Website:
 * Create Date: 22 August 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;

using TSD.AccountingSoft.Presenter.Inventory.InputInventory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Inventory;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using DevExpress.XtraEditors.Mask;
using TSD.AccountingSoft.WindowsForm.FormDictionary;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// Class FrmXtraInputInventoryDetail.
    /// </summary>
    public partial class FrmXtraInputInventoryDetail : FrmXtraBaseVoucherDetail, IItemTransactionView
    {
        #region Presenters

        private bool _check;
        private RepositoryItemCalcEdit _rpsSpinEdit;
        private readonly InputInventoryPresenter _inputInventoryPresenter;

        public RepositoryItemGridLookUpEdit _rpsDebitParallelAccountNumber;
        public RepositoryItemGridLookUpEdit _rpsCreditParallelAccountNumber;

        #endregion

        public FrmXtraInputInventoryDetail()
        {
            InitializeComponent();
            _check = false;
            _rpsSpinEdit = new RepositoryItemCalcEdit();
            _inputInventoryPresenter = new InputInventoryPresenter(this);
        }

        #region Property

        public bool IsParentAccount
        {
            get { return GlobalVariable.IsPostToParentAccount; }
        }
        public long RefId
        {
            get;
            set;
        }
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }
        public DateTime RefDate
        {
            get
            {
                var refDate = (DateTime)dtRefDate.EditValue;
                var now = DateTime.Now;
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                return newDate;
            }
            set
            {
                dtRefDate.EditValue = value;
            }
        }
        public DateTime PostedDate
        {
            get
            {
                var refDate = (DateTime)dtPostDate.EditValue;
                var now = DateTime.Now;
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                return newDate;
            }
            set
            {
                dtPostDate.EditValue = value;
            }
        }
        public string Trader
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }
        public string TaxCode
        {
            get { return txtTaxCode.Text; }
            set { txtTaxCode.Text = value; }
        }
        public string CurrencyCode
        {
            get
            {
                return cboCurrency.EditValue.ToString();
            }
            set
            {
                cboCurrency.EditValue = value;
                if (value == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
            }
        }
        public int StockId
        {
            get
            {
                return Convert.ToInt32(gridStock.EditValue ?? 0);
            }
            set
            {
                gridStock.EditValue = value;
            }
        }
        public decimal TotalAmount
        {
            get;
            set;
        }
        public decimal ExchangeRate
        {
            get
            {
                return Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
            }
            set
            {
                cboExchangRate.EditValue = value;
            }
        }
        public decimal TotalAmountExchange
        {
            get;
            set;
        }
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string DocumentInclude
        {
            get { return txtDocumentInclude.Text; }
            set { txtDocumentInclude.Text = value; }
        }
        public int? BankId
        {
            get
            {
                if (cboBank.EditValue == null)
                    return null;
                return Convert.ToInt32(cboBank.EditValue ?? 0);
            }
            set
            {
                if (value != null)
                    cboBank.EditValue = value;
            }
        }
        public IList<ItemTransactionDetailModel> ItemTransactionDetails
        {
            get
            {
                var result = bindingSourceDetail.DataSource as List<ItemTransactionDetailModel> ?? new List<ItemTransactionDetailModel>();
                TotalAmount = result.Sum(s => s.AmountOc);
                TotalAmountExchange = result.Sum(s => s.AmountExchange);
                return result;
            }
            set
            {
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value;
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.InwardStock)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<ItemTransactionDetailModel> { new ItemTransactionDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<ItemTransactionDetailModel> { new ItemTransactionDetailModel() };
                }

                ColumnsCollection.Clear();
                //bindingSourceDetail.DataSource = value.Count == 0 ? new List<ItemTransactionDetailModel> { new ItemTransactionDetailModel { CorrespondingAccountNumber = "" } } : value;//11121
                gridViewDetail.PopulateColumns(value);
                IList<ItemTransactionDetailModel> list = value;
                foreach (var itemTransactionDetailModel in list.ToList())
                {
                    if (itemTransactionDetailModel.AmountOc > 0 && itemTransactionDetailModel.AmountExchange > 0)
                    {
                        itemTransactionDetailModel.PriceExchange = itemTransactionDetailModel.Price * (itemTransactionDetailModel.AmountOc / itemTransactionDetailModel.AmountExchange);
                    }
                }
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", FixedColumn = FixedStyle.Left, ColumnCaption = "Vật tư", ToolTip = "Vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60 });
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", FixedColumn = FixedStyle.None, ColumnCaption = "Nghiệp vụ", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", FixedColumn = FixedStyle.None, ColumnCaption = "Phòng ban", ColumnPosition = 17, ColumnVisible = true, ColumnWith = 150 });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Dự án", ColumnPosition = 18, ColumnVisible = true, ColumnWith = 150 });
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
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        switch (column.ColumnName)
                        {
                            case "AutoBusinessId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAutoBusiness;
                                break;
                            case "CorrespondingAccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsCorrespondingAccountNumber;
                                break;
                            case "AccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountNumber;
                                break;
                            case "BudgetSourceCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsBudgetSource;
                                break;
                            case "BudgetItemCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsBudgetItem;
                                break;
                            case "AccountingObjectId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountingObject;
                                break;
                            case "MergerFundId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsMergerFund;
                                break;
                            //case "ProjectId":
                            //    gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsProject;
                            //break;
                            case "VoucherTypeId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsVoucherTypeId;
                                break;
                            case "InventoryItemId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsInventoryItem;
                                break;
                            case "DepartmentId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsDepartment;
                                break;
                        }
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }
        public IList<ItemTransactionDetailParallelModel> ItemTransactionDetailParallels
        {
            get
            {
                var result = bindingSourceDetailParallel.DataSource as List<ItemTransactionDetailParallelModel>;
                return result ?? new List<ItemTransactionDetailParallelModel>();
            }
            set
            {
                bindingSourceDetailParallel.DataSource = value ?? new List<ItemTransactionDetailParallelModel>();
                gridViewAccountingPararell.PopulateColumns(value);
                var columnCollections = new List<XtraColumn>();
                //columnCollections.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ToolTip = "Định khoản tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAutoBusiness });
                columnCollections.Add(new XtraColumn { ColumnName = "InventoryItemId", FixedColumn = FixedStyle.Left, ColumnCaption = "Vật tư", ToolTip = "Vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, RepositoryControl = _rpsInventoryItem });
                columnCollections.Add(new XtraColumn { ColumnName = "AccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Nợ", ToolTip = "Tài khoản nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, RepositoryControl = _rpsDebitParallelAccountNumber });
                columnCollections.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Có", ToolTip = "Tài khoản có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60, RepositoryControl = _rpsCreditParallelAccountNumber });
                columnCollections.Add(new XtraColumn { ColumnName = "Description", FixedColumn = FixedStyle.None, ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200, IsSummaryText = true });
                columnCollections.Add(new XtraColumn { ColumnName = "TotalQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số lượng ", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 80, IsSummnary = true });
                columnCollections.Add(new XtraColumn { ColumnName = "AmountOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100 });
                columnCollections.Add(new XtraColumn { ColumnName = "AmountExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền QĐ", ToolTip = "Thành tiền quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100 });
                columnCollections.Add(new XtraColumn { ColumnName = "Price", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80 });
                columnCollections.Add(new XtraColumn { ColumnName = "PriceExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá QĐ", ToolTip = "Đơn giá quy đổi", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 80 });
                columnCollections.Add(new XtraColumn { ColumnName = "BudgetSourceCode", FixedColumn = FixedStyle.None, ColumnCaption = "Nguồn vốn", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rpsBudgetSource });
                columnCollections.Add(new XtraColumn { ColumnName = "BudgetItemCode", FixedColumn = FixedStyle.None, ColumnCaption = "Mục/TM", ToolTip = "Mục tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rpsBudgetItem });
                columnCollections.Add(new XtraColumn { ColumnName = "VoucherTypeId", FixedColumn = FixedStyle.None, ColumnCaption = "Nghiệp vụ", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _rpsVoucherTypeId });
                columnCollections.Add(new XtraColumn { ColumnName = "DepartmentId", FixedColumn = FixedStyle.None, ColumnCaption = "Phòng ban", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 150, RepositoryControl = _rpsDepartment });
                //columnCollections.Add(new XtraColumn { ColumnName = "ProjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Dự án", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 150, RepositoryControl = _rpsProject });
                gridViewAccountingPararell = InitGridLayout(columnCollections, gridViewAccountingPararell);
                SetNumericFormatControl(gridViewAccountingPararell, true);
            }
        }

        public override IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (_rpsInventoryItem == null) _rpsInventoryItem = new RepositoryItemGridLookUpEdit();
                _rpsInventoryItem.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                GridLookUpItem.InventoryItem(value, _rpsInventoryItem, "InventoryItemCode", "InventoryItemId");
            }
        }
        public override IList<StockModel> Stocks
        {
            set
            {
                GridLookUpItem.Stock(value ?? new List<StockModel>(), gridStock, gridStockView, "StockCode", "StockId");
            }
        }
        public override IList<AccountModel> Accounts
        {
            set
            {
                if (value == null)
                    value = new List<AccountModel>();
                base.Accounts = value;

                if (_rpsDebitParallelAccountNumber == null)
                    _rpsDebitParallelAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsDebitParallelAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Account(value, _rpsDebitParallelAccountNumber, "AccountCode", "AccountCode");

                if (_rpsCreditParallelAccountNumber == null)
                    _rpsCreditParallelAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsCreditParallelAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Account(value, _rpsCreditParallelAccountNumber, "AccountCode", "AccountCode");
            }
        }

        #endregion

        #region Override functions

        protected override void EditVoucher()
        {
            base.EditVoucher();
        }
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
                        if (oCol.FieldName == "Price" || oCol.FieldName == "PriceExchange")
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
                                oCol.SummaryItem.DisplayFormat = @"{0:c" + DBOptionHelper.UnitPriceDecimalDigits + @"}";
                                oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;

                            }
                            // break;
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
                                oCol.SummaryItem.DisplayFormat = @"{0:c" + DBOptionHelper.CurrencyDecimalDigits + @"}";//+ GlobalVariable.CurrencyDisplayString;
                                oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;

                            }
                            // break;
                        }

                        //   repositoryCurrencyCalcEdit.Mask.EditMask = @"c3";

                        break;

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
        protected override void InitControls()
        {
            cboObjectCode.ForceInitialize();
            cboObjectCode.Focus();
            _rpsSpinEdit = new RepositoryItemCalcEdit();
        }
        protected override void InitData()
        {
            base.InitData();
            DBOptionHelper = new GlobalVariable();

            if (ActionMode == ActionModeVoucherEnum.None)
            {
                if (MasterBindingSource.Current != null)
                {
                    var paymentVoucherId = ((ItemTransactionModel)MasterBindingSource.Current).RefId;
                    KeyValue = _keyForSend = paymentVoucherId.ToString(CultureInfo.InvariantCulture);
                }
            }
            else if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                KeyValue = null;
                RefId = 0;
                AccountingObjectType = -1;
                cboObjectCode.Text = @"";
                txtDescription.Text = "";
                txtContactName.Text = "";
                txtDocumentInclude.Text = "";
                cboObjectCode.Enabled = false;
                cboCurrency.EditValue = GlobalVariable.CurrencyType == 0 ? CurrencyAccounting : CurrencyLocal;
                ExchangeRate = 1;
                ItemTransactionDetails = new List<ItemTransactionDetailModel>();
                ItemTransactionDetailParallels = new List<ItemTransactionDetailParallelModel>();
            }
            if (KeyValue != null)
            {
                _inputInventoryPresenter.Display(long.Parse(KeyValue));
            }

        }
        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            _check = true;
            var resourceName = string.Empty;
            switch (AccountingObjectType)
            {
                case -1:
                    {
                        resourceName = "ResObjectId";
                        _check = false;
                        break;
                    }
                case 3:
                    {
                        if (CustomerId != null) break;
                        resourceName = "ResCustomerId";
                        _check = false;
                        break;

                    }
                case 0:
                    {
                        if (VendorId != null) break;
                        resourceName = "ResVendorId";
                        _check = false;
                        break;
                    }
                case 1:
                    {
                        if (EmployeeId != null) break;
                        resourceName = "ResEmployeeId";
                        _check = false;
                        break;
                    }
                case 2:
                    {
                        if (AccountingObjectId != null) break;
                        resourceName = "ResAccountingObjectId";
                        _check = false;
                        break;
                    }
            }
            if (!_check)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName(resourceName), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboObjectCategory.Focus();
                return false;
            }
            if (RefNo.Length == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }
            if (dtPostDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            var itemTransactionDetails = ItemTransactionDetails;
            if (itemTransactionDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTotalAmount"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var stockId = StockId;
            var inventoryItems = _inventoryItemsPresenter.GetInventoryItemsByStock(stockId);
            foreach (var inventoryItemModel in inventoryItems.ToList())
            {
                if (inventoryItemModel.InventoryItemCode == null)
                {
                    inventoryItems.Remove(inventoryItemModel);
                }
            }

            if (stockId <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (itemTransactionDetails.Count > 0)
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (var voucher in itemTransactionDetails)
                {
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(voucher))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (voucher.AmountOc == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var strCorrespondingAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber");
                    var strAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber");

                    bool IsEmployee = false;
                    bool IsVendor = false;
                    bool IsAccountingOjbect = false;

                    string strCurrency = CurrencyCode;
                    var mdAccount = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(strCorrespondingAccountNumberDetail);

                    if (mdAccount.IsCurrency == true && mdAccount.CurrencyCode != strCurrency && mdAccount.CurrencyCode != null)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản có theo tiền tệ sai, bạn phải chọn lại !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    bool checkInventoryItem = false;
                    foreach (var inventoryItemModel in inventoryItems)
                    {
                        if (voucher.InventoryItemId == inventoryItemModel.InventoryItemId)
                        {
                            checkInventoryItem = true;
                        }
                    }
                    if (checkInventoryItem == false)
                    {
                        XtraMessageBox.Show("Vật tư không tồn tại trong kho bạn đang chọn!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (voucher.AccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"),
                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return false;
                    }

                    if (voucher.CorrespondingAccountNumber == null)
                    {
                        XtraMessageBox.Show("Tài khoản đối ứng không được để trống!",
                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return false;
                    }

                    if (voucher.AccountNumber.StartsWith("111") || voucher.CorrespondingAccountNumber.StartsWith("111"))
                    {
                        if (string.IsNullOrEmpty(DocumentInclude))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDocumentInclude.Focus();
                            return false;
                        }
                    }

                    // Bắt lỗi theo các đối tượng  TK bên có
                    if (strCorrespondingAccountNumberDetail != null)
                    {
                        mdAccount = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(strCorrespondingAccountNumberDetail);
                        int obj = int.Parse(cboObjectCategory.EditValue.ToString());

                        #region  gán đối tượng nhà cung cấp xuống Detail
                        if (mdAccount.IsVendor) //Nhà cung cấp
                        {
                            if (obj != 0)
                            {
                                XtraMessageBox.Show("Bạn chưa chọn nhà cung cấp theo theo tài khoản:" + strCorrespondingAccountNumberDetail + " tại dòng: " + (i + 1),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], (int)cboObjectCode.EditValue);
                                IsVendor = true; // xác định dòng này đã có gán đối tượng NHÀ CUNG CẤP rồi.
                            }
                        }
                        else
                            gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], null);

                        #endregion

                        #region Gán đối tượng nhan viên xuống Detail
                        if (mdAccount.IsEmployee) //Nhân viên
                        {
                            if (obj != 1)
                            {
                                XtraMessageBox.Show("Bạn chưa chọn nhân viên theo tài khoản " + strCorrespondingAccountNumberDetail + " tại dòng: " + (i + 1),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], (int)cboObjectCode.EditValue);
                                IsEmployee = true;
                            }
                        }
                        else
                            gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], null);


                        #endregion

                        #region Gán đối tượng Đối tượng khác xuống Detail

                        if (mdAccount.IsAccountingObject) //Đối tượng khác
                        {
                            if (obj != 2)
                            {
                                XtraMessageBox.Show("Bạn chưa chọn đối tượng khác theo tài khoản " + strCorrespondingAccountNumberDetail + " theo đối tượng khác tại dòng: " + (i + 1),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], (int)cboObjectCode.EditValue);
                                IsAccountingOjbect = true;
                            }
                        }
                        else gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], (int)cboObjectCode.EditValue);



                        #endregion

                        if (strCorrespondingAccountNumberDetail.StartsWith("111"))//Kiểm tra Chi tài khoản tiền
                        {
                            //TUDT comment ngày 28.12.2014
                            //#region kiểm tra số tiền chi âm

                            //Kiểm tra tổng số tiền chi không vượt quá lượng tiền tồn
                            //this.CurrencyCurrent = strCurrency;// Tiền hạch toán
                            //string strBudgetSourceCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetSourceCode");
                            //decimal dcTotalAmount = 0;// tổng tiền chi tiền mặt( tiền quỹ)
                            //if (strBudgetSourceCode == null)
                            //    dcTotalAmount = ItemTransactionDetails.Where(x => x.BudgetSourceCode == strBudgetSourceCode).Sum(x => x.AmountOc);
                            //else
                            //    dcTotalAmount = ItemTransactionDetails.Sum(x => x.AmountOc);

                            //this.GetCalculateAmountPayment(strAccountNumberDetail, strBudgetSourceCode, ((DateTime)dtPostDate.EditValue).Month.ToString() + "/" + ((DateTime)dtPostDate.EditValue).Day.ToString() + "/" + ((DateTime)dtPostDate.EditValue).Year.ToString());// thực thi để lây tiền cho phép chi
                            //if (dcTotalAmount > this.ClosingAmount)
                            //{
                            //    if (strBudgetSourceCode != null && strBudgetSourceCode != "")
                            //    {
                            //        XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại. Tổng tiền có thể chi: " + this.ClosingAmount.ToString() + strCurrency + " theo nguồn " + strBudgetSourceCode,
                            //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        return false;
                            //    }
                            //    else
                            //    {
                            //        XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại. Tổng tiền có thể chi: " + this.ClosingAmount.ToString() + strCurrency,
                            //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        return false;
                            //    }
                            //}

                            //#endregion

                            #region Kiểm tra chứng từ kèm theo

                            if (string.IsNullOrEmpty(txtDocumentInclude.Text))
                            {
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDocumentInclude.Focus();
                                return false;
                            }

                            #endregion
                        }
                    }

                    // Bắt lỗi theo các đối tượng  TK bên nợ
                    if (strAccountNumberDetail != null)
                    {
                        mdAccount = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(strAccountNumberDetail);
                        int obj = int.Parse(cboObjectCategory.EditValue.ToString());

                        #region Gán đối tượng Nhà cung cấp xuống Detail
                        if (mdAccount.IsVendor && obj != 0) //Nhà cung cấp
                        {
                            if (obj != 0)
                            {
                                XtraMessageBox.Show("Bạn chưa chọn nhà cung cấp theo theo tài khoản " + strAccountNumberDetail + " tại dòng: " + (i + 1),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], (int)cboObjectCode.EditValue);
                        }
                        else
                        {
                            if (!IsVendor) // xử lí trường hợp tài khoản Nợ đã ăn theo đối tượng nhà cung cấp
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], null);
                        }


                        #endregion

                        #region Gán đối tượng Nhân viên xuống Detail
                        if (mdAccount.IsEmployee) //Nhân viên
                        {
                            if (obj != 1)
                            {
                                XtraMessageBox.Show("Bạn chưa chọn nhân viên theo tài khoản " + strAccountNumberDetail + " tại dòng: " + (i + 1),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], (int)cboObjectCode.EditValue);
                        }
                        else
                        {
                            if (!IsEmployee)
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], null);
                        }
                        #endregion

                        #region Gán đối tượng Đối tượng khác xuống Detail
                        if (mdAccount.IsAccountingObject) //Đối tượng khác
                        {
                            if (obj != 2)
                            {
                                XtraMessageBox.Show("Bạn chưa chọn đối tượng khác theo tài khoản " + strAccountNumberDetail + " theo đối tượng khác tại dòng: " + (i + 1),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], (int)cboObjectCode.EditValue);
                        }
                        else
                        {
                            if (!IsAccountingOjbect)
                                gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], null);
                        }

                        #endregion

                    }
                    //gridViewDetail.;
                    var isDetailValid = true;
                    ItemTransactionDetailModel tempvoucher = (ItemTransactionDetailModel)gridViewDetail.GetRow(i);//gán lại để hợp lệ lại dữ liệu vừa gán
                    if (tempvoucher.DetailBy != null)
                    {
                        var detailFieldNames = tempvoucher.DetailBy.Split(';');
                        detailFieldNames = detailFieldNames.Where(w => !w.Contains("ProjectId")).ToArray();
                        if (detailFieldNames.Any(t => tempvoucher.GetType().GetProperty(t) != null && tempvoucher[t] != null))
                        {
                            isDetailValid = false;
                        }
                        if (!isDetailValid)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"),
                                "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }

                    #region  TUDT:Kiểm tra tổng số tiền chi không vượt quá số tiền tồn quỹ

                    CurrencyCurrent = strCurrency; // Tiền hạch toán
                    string budgetSourceCode = voucher.BudgetSourceCode;
                    decimal totalAmount; // tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if (voucher.CorrespondingAccountNumber.Substring(0, 3) == "111")
                    {
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = ItemTransactionDetails.Where(x => x.CorrespondingAccountNumber.Substring(0, 3) == "111").Sum(x => x.AmountOc);
                            GetCalculateCashBalance(voucher.CorrespondingAccountNumber, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại. Số tồn quỹ hiện tại là: " + ClosingAmount + ' ' + strCurrency, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi số dư tiền gửi âm
                    if (voucher.CorrespondingAccountNumber.Substring(0, 3) == "112")
                    {
                        if (!DBOptionHelper.IsDepositeNegavtiveFund)
                        {
                            totalAmount = ItemTransactionDetails.Where(x =>
                                x.CorrespondingAccountNumber.Substring(0, 3) == "112")
                                .Sum(x => x.AmountOc);
                            GetCalculateDepositBalance(voucher.CorrespondingAccountNumber,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại. Số tồn quỹ hiện tại là: " +
                                    ClosingAmount + ' ' + strCurrency,
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi nguồn âm
                    if (voucher.AccountNumber.Substring(0, 3) == "461" ||
                        voucher.AccountNumber.Substring(0, 3) == "661")
                    {
                        if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
                        {
                            // Số dư Có TK 4612
                            GetCalculateCapitalBalance("4612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            decimal accountBalance = ClosingAmount;

                            // Số dư Nợ TK 4612
                            GetCalculateCapitalBalance("6612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            accountBalance = accountBalance - ClosingAmount;

                            totalAmount = ItemTransactionDetails.Where(x =>
                                x.BudgetSourceCode == budgetSourceCode &&
                                (x.AccountNumber.Substring(0, 3) == "461" || x.AccountNumber.Substring(0, 3) == "661"))
                                .Sum(x => x.AmountOc);
                            if (totalAmount > accountBalance)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại. Số tồn hiện tại là: " +
                                    accountBalance + ' ' + strCurrency + " theo nguồn " + budgetSourceCode,
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    #endregion

                    i = i + 1;

                }
                if (lstRowAmounts.Count > 0)
                    if (DialogResult.No == XtraMessageBox.Show("Thành tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return false;
                    }
            }

            return true;
        }
        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;
            var resultAutoGenerateParallel = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            var result = resultAutoGenerateParallel == DialogResult.OK ? _inputInventoryPresenter.Save(true) : _inputInventoryPresenter.Save(false);
            if (result > 0)
                _inputInventoryPresenter.Display(result);
            return result;
        }
        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            _inputInventoryPresenter.Delete(refId);
        }

        #endregion

        #region Events

        private void FrmXtraInputInventoryDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, false);
        }

        private void FrmXtraInputInventoryDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, false);
        }

        private void dtPostDate_Closed(object sender, ClosedEventArgs e)
        {
            dtRefDate.DateTime = dtPostDate.DateTime;

        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                base.gridViewDetail_CellValueChanged(sender, e);
                var exchangeRate = ExchangeRate;
                var quantityCol = gridViewDetail.Columns["Quantity"];
                var amountCol = gridViewDetail.Columns["AmountOc"];
                var amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                var unitPriceoCCol = gridViewDetail.Columns["Price"];
                var unitPriceExchangeCol = gridViewDetail.Columns["PriceExchange"];
                var freeQuantityCol = gridViewDetail.Columns["FreeQuantity"];
                var cancelQuantityCol = gridViewDetail.Columns["CancelQuantity"];
                var totalQuantityCol = gridViewDetail.Columns["TotalQuantity"];
                var quantity = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol) ?? 0);
                var freeQuantity = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, freeQuantityCol) ?? 0);
                var cancelQuantity = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, cancelQuantityCol) ?? 0);
                var totalQuantity = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, totalQuantityCol) ?? 0);
                var unitPriceoC = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceoCCol) ?? 0);

                switch (e.Column.FieldName)
                {
                    case "TotalQuantity":
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceoC);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceoC / exchangeRate);
                        }
                        break;
                    case "Price":
                        if (_check == false)
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceoC);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, totalQuantity * unitPriceoC * exchangeRate);
                        }
                        break;
                    case "AmountOc":
                        if ((decimal)e.Value > 0)
                        {
                            _check = true;
                            var amount = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountCol);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, Math.Round(amount / exchangeRate, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                            if (totalQuantity > 0)
                            {
                                gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceoCCol, amount / totalQuantity);
                            }
                        }
                        break;
                    case "AmountExchange":
                        if (Convert.ToDecimal(e.Value) > 0)
                        {
                            _check = true;
                            var amountExchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountExchangeCol);
                            quantity = 0;
                            if (gridViewDetail.GetFocusedRowCellValue(quantityCol) != null)
                            {
                                totalQuantity = (int)gridViewDetail.GetFocusedRowCellValue(totalQuantityCol);
                            }
                            if (totalQuantity > 0)
                            {
                                gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, amountExchange / totalQuantity);
                            }
                        }
                        break;
                    case "ExchangeRate":
                        if (decimal.Parse(e.Value.ToString().Replace(".", ",")) > 0)
                        {
                            var amount = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountCol);
                            if (amount > 0)
                                gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, Math.Round(amount / decimal.Parse(e.Value.ToString().Replace(".", ",")), int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                        }
                        break;
                    case "InventoryItemId":
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            if (gridViewDetail.GetRowCellValue(rowHandle, "InventoryItemId") != null)
                            {
                                if ((int)e.Value > 0)
                                {
                                    var inventInventoryItemId = (int)gridViewDetail.GetRowCellValue(rowHandle, "InventoryItemId");
                                    var inventoryItem = (InventoryItemModel)_rpsInventoryItem.GetRowByKeyValue(inventInventoryItemId);
                                    if (inventoryItem != null)
                                    {
                                        gridViewDetail.SetRowCellValue(rowHandle, "Description", "Nhập kho vật tư " + inventoryItem.InventoryItemName);
                                        gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", inventoryItem.AccountCode);
                                    }
                                }
                            }
                        }
                        break;
                    case "AccountNumber":
                    case "CorrespondingAccountNumber":
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void gridViewAccountingPararell_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.gridViewAccountingPararell_CellValueChanged(sender, e);
            var exchangeRate = ExchangeRate;
            var quantityCol = gridViewAccountingPararell.Columns["Quantity"];
            var amountCol = gridViewAccountingPararell.Columns["AmountOc"];
            var amountExchangeCol = gridViewAccountingPararell.Columns["AmountExchange"];
            var unitPriceoCCol = gridViewAccountingPararell.Columns["Price"];
            var unitPriceExchangeCol = gridViewAccountingPararell.Columns["PriceExchange"];
            var totalQuantityCol = gridViewAccountingPararell.Columns["TotalQuantity"];
            var totalQuantity = Convert.ToInt32(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, totalQuantityCol) ?? 0);
            var unitPriceoC = Convert.ToDecimal(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, unitPriceoCCol) ?? 0);

            switch (e.Column.FieldName)
            {
                case "TotalQuantity":
                    {
                        gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceoC);
                        gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, totalQuantity * unitPriceoC / exchangeRate);
                    }
                    break;
                case "Price":
                    if (_check == false)
                    {
                        gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceoC);
                        gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, totalQuantity * unitPriceoC * exchangeRate);
                    }
                    break;
                case "AmountOc":
                    if ((decimal)e.Value > 0)
                    {
                        _check = true;
                        var amount = Convert.ToDecimal(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, amountCol));
                        totalQuantity = Convert.ToInt32(gridViewAccountingPararell.GetFocusedRowCellValue(totalQuantityCol));
                        gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, Math.Round(amount / exchangeRate, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                        if (totalQuantity > 0)
                        {
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, unitPriceoCCol, amount / totalQuantity);
                        }
                    }
                    break;
                case "AmountExchange":
                    if (Convert.ToDecimal(e.Value) > 0)
                    {
                        _check = true;
                        var amountExchange = Convert.ToDecimal(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, amountExchangeCol));
                        if (gridViewAccountingPararell.GetFocusedRowCellValue(quantityCol) != null)
                        {
                            totalQuantity = (int)gridViewAccountingPararell.GetFocusedRowCellValue(totalQuantityCol);
                        }
                        if (totalQuantity > 0)
                        {
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, amountExchange / totalQuantity);
                        }
                    }
                    break;
                case "ExchangeRate":
                    if (decimal.Parse(e.Value.ToString().Replace(".", ",")) > 0)
                    {
                        var amount = (decimal)gridViewAccountingPararell.GetRowCellValue(e.RowHandle, amountCol);
                        if (amount > 0)
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, Math.Round(amount / decimal.Parse(e.Value.ToString().Replace(".", ",")), int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                    }
                    break;
                case "InventoryItemId":
                    {
                        var rowHandle = gridViewAccountingPararell.FocusedRowHandle;

                        if (gridViewAccountingPararell.GetRowCellValue(rowHandle, "InventoryItemId") != null)
                        {
                            if ((int)e.Value > 0)
                            {
                                var inventInventoryItemId = (int)gridViewAccountingPararell.GetRowCellValue(rowHandle, "InventoryItemId");
                                var inventoryItem = (InventoryItemModel)_rpsInventoryItem.GetRowByKeyValue(inventInventoryItemId);
                                if (inventoryItem != null)
                                {
                                    gridViewAccountingPararell.SetRowCellValue(rowHandle, "Description", "Nhập kho vật tư " + inventoryItem.InventoryItemName);
                                    gridViewAccountingPararell.SetRowCellValue(rowHandle, "AccountNumber", inventoryItem.AccountCode);
                                }
                            }
                        }
                    }
                    break;
                case "AccountNumber":
                case "CorrespondingAccountNumber":
                    break;
            }
        }

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtRefDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridStock_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraStockDetail())
                {
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _stocksPresenter.DisplayActive(true);

                        var lstDetails = _rpsStock.DataSource as List<StockModel>;
                        if (lstDetails != null)
                            gridStock.EditValue = lstDetails.OrderByDescending(o => o.StockId).FirstOrDefault().StockId;
                    }
                }
            }
        }

        private void gridStock_EditValueChanged(object sender, EventArgs e)
        {
            _inventoryItemsPresenter.DisplayByStock(Convert.ToInt32(gridStock.EditValue));
        }

        #endregion

    }
}