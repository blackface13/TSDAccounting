/***********************************************************************
 * <copyright file="FrmXtraOutputInventoryDetail.cs" company="BUCA JSC">
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
 * 26/8/2015 LINHMC xóa hàm override CopyAndPasteRowItem vì gây ra nhiều lỗi, đã sửa lại hàm base ok
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.Presenter.Inventory.OutputInventory;
using TSD.AccountingSoft.View.Inventory;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TSD.Enum;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using DevExpress.XtraEditors.Controls;
using TSD.AccountingSoft.WindowsForm.FormDictionary;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// FrmXtraOutputInventoryDetail
    /// </summary>
    public partial class FrmXtraOutputInventoryDetail : FrmXtraBaseVoucherDetail, IItemTransactionView
    {
        #region Variable

        public RepositoryItemGridLookUpEdit _rpsDebitParallelAccountNumber;
        public RepositoryItemGridLookUpEdit _rpsCreditParallelAccountNumber;

        #endregion

        #region Presenters 

        private readonly OutputInventoryPresenter _outputInventoryPresenter;

        #endregion

        #region Properties

        public bool IsParentAccount
        {
            get { return GlobalVariable.IsPostToParentAccount; }
        }
        public long RefId { get; set; }
        public int RefTypeId
        {
            get { return (int) BaseRefTypeId; }
            set { BaseRefTypeId = (RefType) value; }
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
                var refDate = (DateTime) dtRefDate.EditValue;
                var now = DateTime.Now;
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                return newDate;
            }
            set { dtRefDate.EditValue = value; }
        }
        public DateTime PostedDate
        {
            get
            {
                if (dtPostDate.EditValue != null)
                    return (DateTime) dtPostDate.EditValue;
                return (DateTime) dtRefDate.EditValue;
            }
            set { dtPostDate.EditValue = value; }
        }
        public string Trader
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }
        public string TaxCode { get; set; }
        public string CurrencyCode
        {
            get
            {
                return cboCurrency.EditValue?.ToString() ?? "";
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
        public decimal TotalAmount { get; set; }
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
        public decimal TotalAmountExchange { get; set; }
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string DocumentInclude
        {
            get { return txtDocummentInclude.Text; }
            set { txtDocummentInclude.Text = value; }
        }
        public int? BankId
        {
            get
            {
                if (cboBank.EditValue == null)
                    return null;
                return Convert.ToInt32(cboBank.EditValue);
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
                var result = bindingSourceDetail.DataSource as List<ItemTransactionDetailModel>;
                TotalAmount = result.Sum(s=>s.AmountOc);
                TotalAmountExchange = result.Sum(s=>s.AmountExchange);
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
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.OutwardStock)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<ItemTransactionDetailModel> { new ItemTransactionDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<ItemTransactionDetailModel> { new ItemTransactionDetailModel() };
                }

                ColumnsCollection.Clear();
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RefDetailId",ColumnVisible = false,Alignment = HorzAlignment.Center});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "AutoBusinessId",ColumnCaption = "ĐK tự động",ToolTip = "Định khoản tự động",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 80,FixedColumn = FixedStyle.Left,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "InventoryItemId",FixedColumn = FixedStyle.Left,ColumnCaption = "Vật tư",ToolTip = "Vật tư",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 60,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "Description",FixedColumn = FixedStyle.Left,ColumnCaption = "Diễn giải",ColumnPosition = 3,ColumnVisible = true,ColumnWith = 200,IsSummaryText = true,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "AccountNumber",FixedColumn = FixedStyle.Left,ColumnCaption = "TK Nợ",ToolTip = "Tài khoản nợ",ColumnPosition = 4,ColumnVisible = true,ColumnWith = 60,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "CorrespondingAccountNumber",FixedColumn = FixedStyle.Left,ColumnCaption = "TK Có",ToolTip = "Tài khoản có",ColumnPosition = 5,ColumnVisible = true,ColumnWith = 60,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CancelQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số hỏng,hủy", ColumnPosition = 6, ColumnVisible = false, ColumnWith = 80, IsSummnary = true, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FreeQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số miễn phí", ColumnPosition = 7, ColumnVisible = false, ColumnWith = 80, IsSummnary = true, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số thực dùng", ColumnPosition = 8, ColumnVisible = false, ColumnWith = 80, IsSummnary = true, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số lượng", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80, IsSummnary = true,AllowEdit=true });
                ColumnsCollection.Add(new XtraColumn{ColumnName = "AmountOc",FixedColumn = FixedStyle.None,ColumnType = UnboundColumnType.Decimal,ColumnCaption = "Thành tiền",ColumnPosition = 10,ColumnVisible = true,ColumnWith = 100, AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "AmountExchange",FixedColumn = FixedStyle.None,ColumnType = UnboundColumnType.Decimal,ColumnCaption = "Thành tiền QĐ",ToolTip = "Thành tiền quy đổi",ColumnPosition = 11,ColumnVisible = true,ColumnWith = 100,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Price", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 80, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PriceExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá QĐ", ToolTip = "Đơn giá quy đổi", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 80, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn{ColumnName = "BudgetSourceCode",FixedColumn = FixedStyle.None,ColumnCaption = "Nguồn vốn",ColumnPosition = 14,ColumnVisible = true,ColumnWith = 70,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "BudgetItemCode",FixedColumn = FixedStyle.None,ColumnCaption = "Mục/TM",ToolTip = "Mục tiểu mục",ColumnPosition = 15,ColumnVisible = true,ColumnWith = 70,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "VoucherTypeId",FixedColumn = FixedStyle.None,ColumnCaption = "Nghiệp vụ",ColumnPosition = 16,ColumnVisible = true,ColumnWith = 150,AllowEdit = true});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "AccountingObjectId",FixedColumn = FixedStyle.None,ColumnCaption = "Đối tượng khác",ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "MergerFundId",FixedColumn = FixedStyle.None,ColumnCaption = "Quỹ sát nhập",ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn{ColumnName = "DepartmentId",FixedColumn = FixedStyle.None,ColumnCaption = "Phòng ban",ColumnPosition = 16,ColumnVisible = true,ColumnWith = 75,AllowEdit = true});
                //ColumnsCollection.Add(new XtraColumn{ColumnName = "ProjectId",FixedColumn = FixedStyle.None,ColumnCaption = "Dự án",ColumnPosition = 17,ColumnVisible = true,ColumnWith = 75,AllowEdit=true});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RefId", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "DetailBy", ColumnVisible = false});
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                      //  gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;

                        switch (column.ColumnName)
                        {
                            case "AutoBusinessId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAutoBusiness;
                                break;
                            case "AccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountNumber;
                                break;
                            case "CorrespondingAccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsCorrespondingAccountNumber;
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
                            //    break;
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
                    SetNumericFormatControl(gridViewDetail, true);
                }
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
                if(value == null)
                    value = new List<ItemTransactionDetailParallelModel>();
                bindingSourceDetailParallel.DataSource = value;
                gridViewAccountingPararell.PopulateColumns(value);
                var columnCollection = new List<XtraColumn>();
                //columnCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ToolTip = "Định khoản tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAutoBusiness });
                columnCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", FixedColumn = FixedStyle.Left, ColumnCaption = "Vật tư", ToolTip = "Vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, AllowEdit = true, RepositoryControl = _rpsInventoryItem });
                columnCollection.Add(new XtraColumn { ColumnName = "Description", FixedColumn = FixedStyle.Left, ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 200, IsSummaryText = true, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "AccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Nợ", ToolTip = "Tài khoản nợ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60, AllowEdit = true, RepositoryControl = _rpsDebitParallelAccountNumber });
                columnCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Có", ToolTip = "Tài khoản có", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 60, AllowEdit = true, RepositoryControl = _rpsCreditParallelAccountNumber });
                columnCollection.Add(new XtraColumn { ColumnName = "TotalQuantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số lượng", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80, IsSummnary = true, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "Price", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 80, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "PriceExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá QĐ", ToolTip = "Đơn giá quy đổi", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 80, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "AmountOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "AmountExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền QĐ", ToolTip = "Thành tiền quy đổi", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", FixedColumn = FixedStyle.None, ColumnCaption = "Nguồn vốn", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 70, AllowEdit = true, RepositoryControl = _rpsBudgetSource });
                columnCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", FixedColumn = FixedStyle.None, ColumnCaption = "Mục/TM", ToolTip = "Mục tiểu mục", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 70, AllowEdit = true, RepositoryControl = _rpsBudgetItem });
                columnCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", FixedColumn = FixedStyle.None, ColumnCaption = "Nghiệp vụ", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 150, AllowEdit = true, RepositoryControl = _rpsVoucherTypeId });
                columnCollection.Add(new XtraColumn { ColumnName = "DepartmentId", FixedColumn = FixedStyle.None, ColumnCaption = "Phòng ban", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 75, AllowEdit = true, RepositoryControl = _rpsDepartment });
                //columnCollection.Add(new XtraColumn { ColumnName = "ProjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Dự án", ColumnPosition = 17, ColumnVisible = true, ColumnWith = 75, AllowEdit = true, RepositoryControl = _rpsProject });
                gridViewAccountingPararell = InitGridLayout(columnCollection, gridViewAccountingPararell);
                SetNumericFormatControl(gridViewAccountingPararell, true);
            }
        }
        public override IList<StockModel> Stocks
        {
            set
            {
                value = value ?? new List<StockModel>();
                GridLookUpItem.Stock(value ?? new List<StockModel>(), gridStock, gridStockView, "StockCode", "StockId");
            }
        }
        /// <summary>
        /// Chỗ này cần lấy ra được cả số lượng tồn nên cần custom riêng.
        /// </summary>
        public override IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (_rpsInventoryItem == null) _rpsInventoryItem = new RepositoryItemGridLookUpEdit();
                _rpsInventoryItem.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.InventoryItemByStock(value ?? new List<InventoryItemModel>(), _rpsInventoryItem, "InventoryItemCode", "InventoryItemId");

                if (_rpsInventoryItemParalell == null) _rpsInventoryItemParalell = new RepositoryItemGridLookUpEdit();
                _rpsInventoryItemParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.InventoryItemByStock(value ?? new List<InventoryItemModel>(), _rpsInventoryItemParalell, "InventoryItemCode", "InventoryItemId");
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

        #region Override

        protected override void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;

            foreach (GridColumn oCol in gridView.Columns)
            {
                var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit {AllowMouseWheel = false};
                var repositoryNumberCalcEdit = new RepositoryItemCalcEdit {AllowMouseWheel = false};

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
                                oCol.SummaryItem.DisplayFormat = @"{0:c" + DBOptionHelper.CurrencyDecimalDigits + @"}";
                                    //+ GlobalVariable.CurrencyDisplayString;
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
            base.InitControls();
        }

        protected override void InitData()
        {
            base.InitData();
            DBOptionHelper = new GlobalVariable();
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                if (MasterBindingSource.Current != null)
                {
                    var itemTransactionModelId = ((ItemTransactionModel)MasterBindingSource.Current).RefId;
                    KeyValue = _keyForSend = itemTransactionModelId.ToString(CultureInfo.InvariantCulture);
                }
            }
            if (!string.IsNullOrEmpty(KeyValue) &&  int.Parse(KeyValue) != 0)
                _outputInventoryPresenter.Display(long.Parse(KeyValue));
            else if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                RefId = 0;
                KeyValue = null;
                ItemTransactionDetails = new List<ItemTransactionDetailModel>();
                ItemTransactionDetailParallels = new List<ItemTransactionDetailParallelModel>();
                cboObjectCategory.EditValue = -1;
                if (ActionMode == ActionModeVoucherEnum.AddNew)
                {
                    txtDescription.Text = "";
                    txtContactName.Text = "";
                }
            }

            if (cboObjectCategory.EditValue.ToString() != "")
            {
                int objectId = (int) cboObjectCategory.EditValue;
                LoadComboObjectCode(objectId);
            }
        }

        protected override void EditVoucher()
        {
            base.EditVoucher();
            if (cboObjectCategory.EditValue.ToString() != "")
            {
                int objectId = (int) cboObjectCategory.EditValue;
                LoadComboObjectCode(objectId);

            }
        }

        protected override bool ValidData()
        {
             gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            var flag = true;
            var resourceName = string.Empty;
            switch (AccountingObjectType)
            {
                case -1:
                    {
                        resourceName = "ResObjectId";
                        flag = false;
                        break;
                    }
                case 3:
                    {
                        if (CustomerId != null) break;
                        resourceName = "ResCustomerId";
                        flag = false;
                        break;
                    }
                case 0:
                    {
                        if (VendorId != null) break;
                        resourceName = "ResVendorId";
                        flag = false;
                        break;
                    }
                case 1:
                    {
                        if (EmployeeId != null)
                        {
                            if (txtDocummentInclude.Text == "")
                            {
                                resourceName = "ResDocummentInclude";
                                flag = false;
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        if (AccountingObjectId != null) break;
                        resourceName = "ResAccountingObjectId";
                        flag = false;
                        break;
                    }
            }
            if (!flag)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName(resourceName), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboObjectCode.Focus();
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
            if (ItemTransactionDetails.Count == 0)
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
            var inventoryItemsByRefDate = _inventoryItemsPresenter.GetInventoryItemsByStock(stockId, (int) RefId, PostedDate.ToShortDateString(), CurrencyCode);
            if (stockId <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var lstItem = ItemTransactionDetails.Where(x => x.InventoryItemId <= 0).ToList();
            if (lstItem.Count > 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int i = 0;
            // Kiểm tra tài khoản chi tiết theo đối tượng nhà cung cấp và nhân viên
            var lstRowAmounts = new List<string>();
            foreach (var voucher in ItemTransactionDetails)
            {
                // bắt lỗi thiếu thông tin trong tài khoản
                if (!ValidAccountDetail(voucher))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (voucher.AmountOc == 0)
                    lstRowAmounts.Add((i + 1).ToString());
                string strCurrency = CurrencyCode;

                if (voucher.TotalQuantity == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập số lượng vật tư tại dòng: " + (i + 1).ToString(),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                if (voucher.AccountNumber == null)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tài khoản nợ tại dòng : " + (i + 1).ToString(),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                if (voucher.CorrespondingAccountNumber == null)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tài khoản có tại dòng : " + (i + 1).ToString(),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                if (voucher.AccountNumber == voucher.CorrespondingAccountNumber)
                {
                    XtraMessageBox.Show("Bạn nhập tài khoản nợ/có trùng nhau tại " + (i + 1).ToString(),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;

                }

                bool IsEmployee = false;
                bool IsVendor = false;
                bool IsAccountingOjbect = false;

                var mdAccount = (AccountModel) _rpsAccountNumber.GetRowByKeyValue(voucher.AccountNumber);

                if (mdAccount.IsCurrency == true && mdAccount.CurrencyCode != strCurrency && mdAccount.CurrencyCode != null)
                {
                    XtraMessageBox.Show("Bạn đang chọn tài khoản nợ theo tiền sai, bạn phải chọn lại !.",ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }

                bool checkInventoryItemByRefDate = false;
                foreach (var inventoryItemModel in inventoryItemsByRefDate)
                {
                    if (voucher.InventoryItemId == inventoryItemModel.InventoryItemId)
                    {
                        checkInventoryItemByRefDate = true;
                    }
                }

                if (checkInventoryItemByRefDate == false)
                {
                    XtraMessageBox.Show("Vật tư không tồn tại trong kho bạn đang chọn!",ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    XtraMessageBox.Show("Vật tư không tồn tại trong kho bạn đang chọn!",ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                var inventoryItem = (InventoryItemModel) _rpsInventoryItem.GetRowByKeyValue(voucher.InventoryItemId);
                if (inventoryItem != null)
                {
                    var quantityOfInventory = _outputInventoryPresenter.GetQuantityOfInventory(inventoryItem.InventoryItemId, StockId, PostedDate, ActionMode == ActionModeVoucherEnum.AddNew ? 0 : int.Parse(KeyValue), CurrencyCode);
                    if (quantityOfInventory < voucher.TotalQuantity)
                    {
                        if (this.DBOptionHelper.IsOutwardNegativeStock == false)
                        {
                            XtraMessageBox.Show("Bạn không được xuất quá số lượng tồn kho của vật tư " + inventoryItem.InventoryItemCode + " là " + quantityOfInventory, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                if (voucher.AccountNumber.StartsWith("111") || voucher.CorrespondingAccountNumber.StartsWith("111"))
                {
                    if (string.IsNullOrEmpty(txtDocummentInclude.Text))
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"),ResourceHelper.GetResourceValueByName("ResDetailContent"),MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDocummentInclude.Focus();
                        return false;
                    }
                }

                // gán đối tượng xuông Detail
                //Bên nợ
                int obj = int.Parse(cboObjectCategory.EditValue.ToString());

                #region  gán đối tượng nhà cung cấp xuống Detail

                if (mdAccount.IsVendor) //Nhà cung cấp
                {
                    if (obj != 0)
                    {
                        XtraMessageBox.Show(
                            "Bạn chưa chọn nhà cung cấp theo theo tài khoản:" + voucher.AccountNumber + " tại dòng: " +
                            (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"],
                                                       (int)cboObjectCode.EditValue);
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
                        XtraMessageBox.Show(
                            "Bạn chưa chọn nhân viên theo tài khoản " + voucher.AccountNumber + " tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"],
                                                       (int)cboObjectCode.EditValue);
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
                        XtraMessageBox.Show(
                            "Bạn chưa chọn đối tượng khác theo tài khoản " + voucher.AccountNumber +
                            " theo đối tượng khác tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"],
                                                       (int)cboObjectCode.EditValue);
                        IsAccountingOjbect = true;
                    }
                }
                else gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], null);



                #endregion

                //Bên có
                mdAccount = (AccountModel) _rpsAccountNumber.GetRowByKeyValue(voucher.CorrespondingAccountNumber);

                #region Gán đối tượng Nhà cung cấp xuống Detail

                if (mdAccount.IsVendor && obj != 0) //Nhà cung cấp
                {
                    if (obj != 0)
                    {
                        XtraMessageBox.Show(
                            "Bạn chưa chọn nhà cung cấp theo theo tài khoản " + voucher.CorrespondingAccountNumber +
                            " tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    else
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"],
                                                       (int)cboObjectCode.EditValue);
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
                        XtraMessageBox.Show(
                            "Bạn chưa chọn nhân viên theo tài khoản " + voucher.CorrespondingAccountNumber +
                            " tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    else
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"],
                                                       (int)cboObjectCode.EditValue);
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
                        XtraMessageBox.Show(
                            "Bạn chưa chọn đối tượng khác theo tài khoản " + voucher.CorrespondingAccountNumber +
                            " theo đối tượng khác tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    else
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"],
                                                       (int)cboObjectCode.EditValue);
                }
                else
                {
                    if (!IsAccountingOjbect)
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], null);
                }

                #endregion

                var isDetailValid = true;

                ItemTransactionDetailModel tempvoucher = (ItemTransactionDetailModel) gridViewDetail.GetRow(i);
                    //gán lại để hợp lệ lại dữ liệu vừa gán

                if (tempvoucher.DetailBy != null)
                {
                    var detailFieldNames = tempvoucher.DetailBy.Split(';');
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
                        totalAmount = ItemTransactionDetails.Where(x =>
                                                                   x.CorrespondingAccountNumber.Substring(0, 3) == "111")
                                                            .Sum(x => x.AmountOc);
                        GetCalculateCashBalance(voucher.CorrespondingAccountNumber,
                                                ((DateTime) dtPostDate.EditValue).Month + "/" +
                                                ((DateTime) dtPostDate.EditValue).Day +
                                                "/" + ((DateTime) dtPostDate.EditValue).Year);
                            // thực thi để lây tiền cho phép chi

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

                // kiểm tra chi tiền khi số dư tiền gửi âm
                if (voucher.CorrespondingAccountNumber.Substring(0, 3) == "112")
                {
                    if (!DBOptionHelper.IsDepositeNegavtiveFund)
                    {
                        totalAmount = ItemTransactionDetails.Where(x =>
                                                                   x.CorrespondingAccountNumber.Substring(0, 3) == "112")
                                                            .Sum(x => x.AmountOc);
                        GetCalculateDepositBalance(voucher.CorrespondingAccountNumber,
                                                   ((DateTime) dtPostDate.EditValue).Month + "/" +
                                                   ((DateTime) dtPostDate.EditValue).Day +
                                                   "/" + ((DateTime) dtPostDate.EditValue).Year);
                            // thực thi để lây tiền cho phép chi

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
                                                   ((DateTime) dtPostDate.EditValue).Month + "/" +
                                                   ((DateTime) dtPostDate.EditValue).Day +
                                                   "/" + ((DateTime) dtPostDate.EditValue).Year);
                            // thực thi để lây tiền cho phép chi
                        decimal accountBalance = ClosingAmount;

                        // Số dư Nợ TK 4612
                        GetCalculateCapitalBalance("6612", budgetSourceCode,
                                                   ((DateTime) dtPostDate.EditValue).Month + "/" +
                                                   ((DateTime) dtPostDate.EditValue).Day +
                                                   "/" + ((DateTime) dtPostDate.EditValue).Year);
                            // thực thi để lây tiền cho phép chi
                        accountBalance = accountBalance - ClosingAmount;

                        totalAmount = ItemTransactionDetails.Where(x =>
                                                                   x.BudgetSourceCode == budgetSourceCode &&
                                                                   (x.AccountNumber.Substring(0, 3) == "461" ||
                                                                    x.AccountNumber.Substring(0, 3) == "661"))
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

            return true;
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            if(RefTypeId == (int)RefType.OutwardStock)
            {
                return _outputInventoryPresenter.Save(false);
            }
            else
            {
                var resultAutoGenerateParallel = new DialogResult();
                resultAutoGenerateParallel = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                var result = resultAutoGenerateParallel == DialogResult.OK ? _outputInventoryPresenter.Save(true) : _outputInventoryPresenter.Save(false);
                if (result > 0)
                    _outputInventoryPresenter.Display(result);
                return result;
            }

            //var resultAutoGenerateParallel = new DialogResult();
            //if (ItemTransactionDetailParallels.Count > 0)
            //{
            //    resultAutoGenerateParallel = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelUpdateQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //}
            //else
            //{
            //    resultAutoGenerateParallel = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //}
            //var result = resultAutoGenerateParallel == DialogResult.OK ? _outputInventoryPresenter.Save(true) : _outputInventoryPresenter.Save(false);
            //if (result > 0)
            //    _outputInventoryPresenter.Display(result);
            //return result;
            //return _outputInventoryPresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            _outputInventoryPresenter.Delete(refId);
        }

        #endregion

        #region Events

        public FrmXtraOutputInventoryDetail()
        {
            InitializeComponent();
            _outputInventoryPresenter = new OutputInventoryPresenter(this);
        }

        private void cboObjectCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboObjectCategory.SelectionLength != cboObjectCategory.Text.Length || (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)) return;
            cboObjectCategory.EditValue = -1;
            e.Handled = true;
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                base.gridViewDetail_CellValueChanged(sender, e);
                var focusedRowHandle = gridViewDetail.FocusedRowHandle;
                var amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                var amountCol = gridViewDetail.Columns["AmountOc"];
                var unitPriceOcCol = gridViewDetail.Columns["Price"];
                var quantityCol = gridViewDetail.Columns["Quantity"];
                var freeQuantityCol = gridViewDetail.Columns["FreeQuantity"];
                var cancelQuantityCol = gridViewDetail.Columns["CancelQuantity"];
                var totalQuantityCol = gridViewDetail.Columns["TotalQuantity"];
                var unitPriceExCol = gridViewDetail.Columns["PriceExchange"];
                var unitPriceOc = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOcCol));
                var exchangeRate = ExchangeRate;

                var quality = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol));
                var freeQuality = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, freeQuantityCol));
                var cancelQuality = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, cancelQuantityCol));
                var totalQuantity = Convert.ToInt32(gridViewDetail.GetRowCellValue(e.RowHandle, totalQuantityCol));

                switch (e.Column.FieldName)
                {
                    case "TotalQuantity":
                        {
                            var inventoryItemId = (int)gridViewDetail.GetRowCellValue(focusedRowHandle, "InventoryItemId");
                            var inventoryItemModel = (InventoryItemModel)_rpsInventoryItem.GetRowByKeyValue(inventoryItemId);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceOc);
                            if (exchangeRate != 0)
                                gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, (totalQuantity * unitPriceOc) / exchangeRate);
                        }
                        break;
                    case "Price":
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExCol, unitPriceOc / exchangeRate);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceOc);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, (totalQuantity * unitPriceOc) / exchangeRate);
                        }
                        break;
                    case "PriceExchange":
                        gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, (totalQuantity * unitPriceOc) / exchangeRate);
                        break;
                    case "FreeQuantity":
                        gridViewDetail.SetRowCellValue(e.RowHandle, totalQuantityCol, quality + freeQuality + cancelQuality);
                        break;
                    case "CancelQuantity":
                        gridViewDetail.SetRowCellValue(e.RowHandle, totalQuantityCol, quality + freeQuality + cancelQuality);
                        break;
                    case "Quantity":
                        gridViewDetail.SetRowCellValue(e.RowHandle, totalQuantityCol, quality + freeQuality + cancelQuality);
                        break;
                    case "InventoryItemId":
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            if (gridViewDetail.GetRowCellValue(rowHandle, "InventoryItemId") != null)
                            {
                                var inventInventoryItemId =(int) gridViewDetail.GetRowCellValue(rowHandle, "InventoryItemId");
                                var inventoryItem = (InventoryItemModel) _rpsInventoryItem.GetRowByKeyValue(inventInventoryItemId);
                                if (inventoryItem != null)
                                {
                                    gridViewDetail.SetRowCellValue(rowHandle, "Description", "Xuất kho vật tư " + inventoryItem.InventoryItemName);
                                    gridViewDetail.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", inventoryItem.AccountCode);
                                    gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", inventoryItem.ExpenseAccountCode);
                                }
                            }
                        }
                        break;
                    case "AccountNumber":
                    case "CorrespondingAccountNumber":
                        {
                            var accountNumber = gridViewDetail.GetFocusedRowCellValue("AccountNumber");
                            var accountNumberDetailBy = "";
                            if (accountNumber != null)
                            {
                                accountNumberDetailBy = GetAccountDetailBy(accountNumber.ToString());
                            }
                            var correspondingAccountNumber = gridViewDetail.GetFocusedRowCellValue("CorrespondingAccountNumber");
                            var correspondingAccountNumberDetailBy = "";
                            if (correspondingAccountNumber != null)
                            {
                                correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber.ToString());
                            }
                            accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                                                        ? correspondingAccountNumberDetailBy
                                                        : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                            var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                            var detail = string.Join(";", detailByArray);
                            ////Bổ sung thêm 2 trường Quantity và ExchangeRate

                            //detail = !string.IsNullOrEmpty(detail)
                            //             ? detail + ";TotalQuantity;ExchangeRate"
                            //             : detail + "TotalQuantity;ExchangeRate";
                            //gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", detail);

                            //Bổ ThangNK sửa lại
                            detail = !string.IsNullOrEmpty(detail)
                                         ? detail + ";ExchangeRate"
                                         : detail + "ExchangeRate";
                            gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", detail);

                            if ((accountNumber != null && accountNumber.ToString().StartsWith("11")) || (correspondingAccountNumber != null && correspondingAccountNumber.ToString().StartsWith("11")))
                                lblDocummentInclude.Text = "Chứng từ đi kèm (*)";
                            else
                                lblDocummentInclude.Text = "Chứng từ đi kèm";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void gridViewAccountingPararell_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                base.gridViewAccountingPararell_CellValueChanged(sender, e);
                var exchangeRate = ExchangeRate;
                var focusedRowHandle = gridViewAccountingPararell.FocusedRowHandle;
                var amountExchangeCol = gridViewAccountingPararell.Columns["AmountExchange"];
                var amountCol = gridViewAccountingPararell.Columns["AmountOc"];
                var unitPriceOcCol = gridViewAccountingPararell.Columns["Price"];
                var quantityCol = gridViewAccountingPararell.Columns["Quantity"];
                var freeQuantityCol = gridViewAccountingPararell.Columns["FreeQuantity"];
                var cancelQuantityCol = gridViewAccountingPararell.Columns["CancelQuantity"];
                var totalQuantityCol = gridViewAccountingPararell.Columns["TotalQuantity"];
                var unitPriceExCol = gridViewAccountingPararell.Columns["PriceExchange"];
                var unitPriceOc = Convert.ToDecimal(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, unitPriceOcCol));
                var quality = Convert.ToInt32(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, quantityCol));
                var freeQuality = Convert.ToInt32(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, freeQuantityCol));
                var cancelQuality = Convert.ToInt32(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, cancelQuantityCol));
                var totalQuantity = Convert.ToInt32(gridViewAccountingPararell.GetRowCellValue(e.RowHandle, totalQuantityCol));

                switch (e.Column.FieldName)
                {
                    case "TotalQuantity":
                        {
                            var inventoryItemId = (int)gridViewAccountingPararell.GetRowCellValue(focusedRowHandle, "InventoryItemId");
                            var inventoryItemModel = (InventoryItemModel)_rpsInventoryItem.GetRowByKeyValue(inventoryItemId);
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceOc);
                            if (exchangeRate != 0)
                                gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, (totalQuantity * unitPriceOc) / exchangeRate);
                        }
                        break;
                    case "Price":
                        {
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, unitPriceExCol, unitPriceOc / exchangeRate);
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountCol, totalQuantity * unitPriceOc);
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, (totalQuantity * unitPriceOc) / exchangeRate);
                        }
                        break;
                    case "PriceExchange":
                        {
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, amountExchangeCol, (totalQuantity * unitPriceOc) / exchangeRate);
                        }
                        break;
                    case "InventoryItemId":
                        {
                            var rowHandle = gridViewAccountingPararell.FocusedRowHandle;
                            if (gridViewAccountingPararell.GetRowCellValue(rowHandle, "InventoryItemId") != null)
                            {
                                var inventInventoryItemId = (int)gridViewAccountingPararell.GetRowCellValue(rowHandle, "InventoryItemId");
                                var inventoryItem = (InventoryItemModel)_rpsInventoryItem.GetRowByKeyValue(inventInventoryItemId);
                                if (inventoryItem != null)
                                {
                                    gridViewAccountingPararell.SetRowCellValue(rowHandle, "Description", "Xuất kho vật tư " + inventoryItem.InventoryItemName);
                                    gridViewAccountingPararell.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", inventoryItem.AccountCode);
                                    gridViewAccountingPararell.SetRowCellValue(rowHandle, "AccountNumber", inventoryItem.ExpenseAccountCode);
                                }
                            }
                        }
                        break;
                    case "AccountNumber":
                    case "CorrespondingAccountNumber":
                        {
                            var accountNumber = gridViewAccountingPararell.GetFocusedRowCellValue("AccountNumber");
                            var accountNumberDetailBy = "";
                            if (accountNumber != null)
                            {
                                accountNumberDetailBy = GetAccountDetailBy(accountNumber.ToString());
                            }
                            var correspondingAccountNumber = gridViewAccountingPararell.GetFocusedRowCellValue("CorrespondingAccountNumber");
                            var correspondingAccountNumberDetailBy = "";
                            if (correspondingAccountNumber != null)
                            {
                                correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber.ToString());
                            }
                            accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                                                        ? correspondingAccountNumberDetailBy
                                                        : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                            var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                            var detail = string.Join(";", detailByArray);
                            detail = !string.IsNullOrEmpty(detail)
                                         ? detail + ";ExchangeRate"
                                         : detail + "ExchangeRate";
                            gridViewAccountingPararell.SetRowCellValue(e.RowHandle, "DetailBy", detail);

                            if ((accountNumber != null && accountNumber.ToString().StartsWith("11")) || (correspondingAccountNumber != null && correspondingAccountNumber.ToString().StartsWith("11")))
                                lblDocummentInclude.Text = "Chứng từ đi kèm (*)";
                            else
                                lblDocummentInclude.Text = "Chứng từ đi kèm";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
            if (dtPostDate.EditValue == null) return;
            var postedDate = PostedDate;
            if (StockId > 0)
            {
                _inventoryItemsPresenter.DisplayByStock(StockId, (int) RefId, postedDate.ToShortDateString(), CurrencyCode);
            }
        }

        private void FrmXtraOutputInventoryDetail_Load(object sender, EventArgs e)
        {
            bool isParallel = true;
            if (RefTypeId == (int)RefType.OutwardStock)
            {
                isParallel  = false;
            }
            AdjustControlSize(isParallel, false);
        }

        private void FrmXtraOutputInventoryDetail_Resize(object sender, EventArgs e)
        {
            bool isParallel = true;
            if (RefTypeId == (int)RefType.OutwardStock)
            {
                isParallel = false;
            }
            AdjustControlSize(isParallel, false);
        }

        private void gridStock_EditValueChanged(object sender, EventArgs e)
        {
            _inventoryItemsPresenter.DisplayByStock(Convert.ToInt32(gridStock.EditValue), RefID, PostedDate.ToShortDateString(), CurrencyCode);
        }

        private void gridStock_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        #endregion

    }
}