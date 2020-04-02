/***********************************************************************
 * <copyright file="FrmXtraPrintVoucherByLot.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn, Thangnk modifiled <15/09/2014>
 * Website:
 * Create Date: Wednesday, June 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Cash.PaymentVoucher;
using TSD.AccountingSoft.Presenter.Cash.ReceiptVoucher;
using TSD.AccountingSoft.Presenter.Deposit.PaymentDeposit;
using TSD.AccountingSoft.Presenter.Deposit.ReceiptDeposit;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetArmortization;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetDecrement;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetIncrement;
using TSD.AccountingSoft.Presenter.Inventory.InputInventory;
using TSD.AccountingSoft.Presenter.Inventory.OutputInventory;
using TSD.AccountingSoft.Presenter.General;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Cash;
using TSD.AccountingSoft.View.Deposit;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.View.Inventory;
using TSD.AccountingSoft.View.Report;
using TSD.AccountingSoft.View.General;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// Print voucher by lot
    /// </summary>
    public partial class FrmXtraPrintVoucherByLot : XtraForm, IReceiptVouchersView, IPaymentVouchersView, IFixedAssetsView,
        IReceiptDepositsView, IPaymentDepositsView, IItemTransactionsView, IFixedAssetIncrementsView, IFixedAssetDecrementsView, IFixedAssetArmortizationsView,
        IGeneralVouchersView, IReportView
    {
        /// <summary>
        /// The _receipt deposits presenter
        /// </summary>
        private readonly ReceiptDepositsPresenter _receiptDepositsPresenter;

        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;
        /// <summary>
        /// The _receipt vouchers presenter
        /// </summary>
        private readonly ReceiptVouchersPresenter _receiptVouchersPresenter;

        /// <summary>
        /// The _genveral vouchers presenter
        /// </summary>
        private readonly GenveralVouchersPresenter _genveralVouchersPresenter;

        /// <summary>
        /// The _payment deposits presenter
        /// </summary>
        private readonly PaymentDepositsPresenter _paymentDepositsPresenter;
        /// <summary>
        /// The _payment vouchers presenter
        /// </summary>
        private readonly PaymentVouchersPresenter _paymentVouchersPresenter;
        /// <summary>
        /// The _input inventories presenter
        /// </summary>
        private readonly InputInventoriesPresenter _inputInventoriesPresenter;
        /// <summary>
        /// The _output inventories presenter
        /// </summary>
        private readonly OutputInventoriesPresenter _outputInventoriesPresenter;
        /// <summary>
        /// The _fixed asset increments presenter
        /// </summary>
        private readonly FixedAssetIncrementsPresenter _fixedAssetIncrementsPresenter;
        /// <summary>
        /// The _fixed asset decrements presenter
        /// </summary>
        private readonly FixedAssetDecrementsPresenter _fixedAssetDecrementsPresenter;
        /// <summary>
        /// The _fixed asset armortizations presenter
        /// </summary>
        private readonly FixedAssetArmortizationsPresenter _fixedAssetArmortizationsPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;

        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        /// <summary>
        /// Gets or sets the selected voucher.
        /// </summary>
        /// <value>The selected voucher.</value>
        public string SelectedVoucher { get; set; }

        public string SelectedFa { get; set; }
        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>The report identifier.</value>
        public string ReportID { get; set; }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public RefType RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public int RefID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraPrintVoucherByLot" /> class.
        /// </summary>
        public FrmXtraPrintVoucherByLot()
        {
            InitializeComponent();
            _receiptDepositsPresenter = new ReceiptDepositsPresenter(this);
            _receiptVouchersPresenter = new ReceiptVouchersPresenter(this);
            _paymentDepositsPresenter = new PaymentDepositsPresenter(this);
            _paymentVouchersPresenter = new PaymentVouchersPresenter(this);
            _inputInventoriesPresenter = new InputInventoriesPresenter(this);
            _outputInventoriesPresenter = new OutputInventoriesPresenter(this);
            _fixedAssetIncrementsPresenter = new FixedAssetIncrementsPresenter(this);
            _fixedAssetDecrementsPresenter = new FixedAssetDecrementsPresenter(this);
            _fixedAssetArmortizationsPresenter = new FixedAssetArmortizationsPresenter(this);
            _genveralVouchersPresenter = new GenveralVouchersPresenter(this);
            _reportListPresenter = new ReportListPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);

        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        private void LoadGridLayout()
        {
            if (ColumnsCollection == null) return;
            foreach (var column in ColumnsCollection)
            {
                if (column.ColumnVisible)
                {

                    gridVoucherView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridVoucherView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    gridVoucherView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridVoucherView.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridVoucherView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                    gridVoucherView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    gridVoucherView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    gridVoucherView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    gridVoucherView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                    SetGridNumericFormat();
                }
                else
                    gridVoucherView.Columns[column.ColumnName].Visible = false;
            }
        }


        /// <summary>
        /// Initializes the combo data.
        /// </summary>
        /// <param name="reportLists">The report lists.</param>
        public void InitComboData(IList<ReportListModel> reportLists)
        {

            cboReportList.Properties.DataSource = reportLists;
            cboReportList.Properties.DisplayMember = "ReportName";
            cboReportList.Properties.ValueMember = "ReportID";
            cboReportList.Properties.ForceInitialize();
            cboReportList.Properties.PopulateColumns();

            for (var i = 0; i < cboReportList.Properties.Columns.Count; i++)
            {
                if (cboReportList.Properties.Columns[i].FieldName != "ReportName")
                    cboReportList.Properties.Columns[i].Visible = false;
            }

            foreach (var reportListModel in reportLists)
            {
                if (reportListModel.PrintVoucherDefault)
                {
                    cboReportList.EditValue = reportListModel.ReportID;
                }
            }
        }

        /// <summary>
        /// Sets the grid numeric format.
        /// </summary>
        protected virtual void SetGridNumericFormat()
        {
            foreach (var oCol in gridVoucherView.Columns.Cast<GridColumn>().Where(oCol => oCol.Visible))
            {
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        oCol.DisplayFormat.FormatString = GlobalVariable.CurrencyDisplayString;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                        oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                        oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.Integer:
                        oCol.DisplayFormat.FormatString = GlobalVariable.NumericDisplayString;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the checked current row.
        /// </summary>
        public void SetCheckedCurrentRow()
        {
            if (RefType != RefType.FixedAssetDictionary)
            {
                var rowHandle = FindRowHandle(RefID);
                Selection.SelectRow(rowHandle, true);
                gridVoucherView.MakeRowVisible(rowHandle);
            }

            else
            {
                var rowHandle = FindRowHandleFixedAsset(RefID);
                Selection.SelectRow(rowHandle, true);
                gridVoucherView.MakeRowVisible(rowHandle);
            }

        }

        /// <summary>
        /// Finds the row handle.
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <returns>System.Int32.</returns>
        private int FindRowHandle(int keyValue)
        {
            var retval = -1;
            if (keyValue == 0)
            {
                return retval;
            }

            for (var count = 0; count < gridVoucherView.RowCount; count++)
            {
                if (Convert.ToInt32(gridVoucherView.GetRowCellValue(count, "RefId")) != keyValue) continue;
                retval = count;
                break;
            }

            return retval;
        }

        private int FindRowHandleFixedAsset(int keyValue)
        {
            var retval = -1;
            if (keyValue == 0)
            {
                return retval;
            }

            for (var count = 0; count < gridVoucherView.RowCount; count++)
            {
                if (Convert.ToInt32(gridVoucherView.GetRowCellValue(count, "FixedAssetId")) != keyValue) continue;
                retval = count;
                break;
            }

            return retval;
        }
        /// <summary>
        /// Gets the voucher data.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private void GetVoucherData()
        {
            switch (RefType)
            {
                case RefType.ReceiptEstimate:
                    break;
                case RefType.PaymentEstimate:
                    break;
                case RefType.ReceiptCash:
                    _receiptVouchersPresenter.Display((int)RefType.ReceiptCash);
                    LoadGridLayout();
                    break;
                case RefType.PaymentCash:
                    _paymentVouchersPresenter.Display((int)RefType.PaymentCash);
                    LoadGridLayout();
                    break;
                case RefType.ReceiptDeposite:
                    _receiptDepositsPresenter.Display((int)RefType.ReceiptDeposite);
                    LoadGridLayout();
                    break;
                case RefType.PaymentDeposite:
                    _paymentDepositsPresenter.Display((int)RefType.PaymentDeposite);
                    LoadGridLayout();
                    break;
                case RefType.InwardStock:
                    _inputInventoriesPresenter.Display((int)RefType.InwardStock);
                    LoadGridLayout();
                    break;
                case RefType.OutwardStock:
                    _outputInventoriesPresenter.Display((int)RefType.OutwardStock);
                    LoadGridLayout();
                    break;
                case RefType.FixedAssetIncrement:
                    _fixedAssetIncrementsPresenter.Display();
                    LoadGridLayout();
                    break;
                case RefType.FixedAssetDecrement:
                    _fixedAssetDecrementsPresenter.Display();
                    LoadGridLayout();
                    break;
                case RefType.FixedAssetArmortization:
                    _fixedAssetArmortizationsPresenter.Display();
                    LoadGridLayout();
                    break;
                case RefType.OpeningAccountEntry:
                    break;
                case RefType.GeneralVoucher:
                    _genveralVouchersPresenter.Display((int)RefType.GeneralVoucher);
                    LoadGridLayout();
                    break;
                case RefType.CaptitalAllocateVoucher:
                    _genveralVouchersPresenter.Display((int)RefType.CaptitalAllocateVoucher);
                    LoadGridLayout();
                    break;
                case RefType.AccountTranferVourcher:
                    _genveralVouchersPresenter.Display((int)RefType.AccountTranferVourcher);
                    LoadGridLayout();
                    break;
                case RefType.Salary:
                    _paymentVouchersPresenter.Display((int)RefType.PaymentCash);
                    LoadGridLayout();
                    break;
                case RefType.FixedAssetDictionary:
                    _fixedAssetsPresenter.Display();
                    LoadGridLayout();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        /// <summary>
        /// Sets the receipt deposits.
        /// </summary>
        /// <value>The receipt deposits.</value>
        public IList<Model.BusinessObjects.Deposit.DepositModel> ReceiptDeposits
        {
            set
            {
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepositDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccountCode", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ToolTip = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ToolTip = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 300, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ToolTip = "Số tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ToolTip = "Số tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
            }
        }

        /// <summary>
        /// Sets the receipt vouchers.
        /// </summary>
        /// <value>The receipt vouchers.</value>
        public IList<Model.BusinessObjects.Cash.ReceiptVoucherModel> ReceiptVouchers
        {
            set
            {
                ColumnsCollection.Clear();
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentInclude", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false, ColumnCaption = "Ngày HT ", ColumnPosition = 1, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ColumnWith = 70, ToolTip = "Ngày hạch toán" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnPosition = 5, Alignment = HorzAlignment.Near, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnCaption = "chứng từ đi kèm", ColumnVisible = false, ColumnPosition = 6, Alignment = HorzAlignment.Near, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Số tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });

            }
        }

        /// <summary>
        /// Sets the receipt deposits.
        /// </summary>
        /// <value>The receipt deposits.</value>
        public IList<Model.BusinessObjects.Deposit.DepositModel> PaymentDeposits
        {
            set
            {
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepositDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccountCode", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày hạch toán" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 300, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
            }
        }

        /// <summary>
        /// Sets the payment vouchers.
        /// </summary>
        /// <value>The payment vouchers.</value>
        public IList<Model.BusinessObjects.Cash.CashModel> PaymentVouchers
        {
            set
            {
                ColumnsCollection.Clear();
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentInclude", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });

            }
        }

        /// <summary>
        /// Sets the ItemTransaction vouchers.
        /// </summary>
        /// <value>The ItemTransaction vouchers.</value>
        public IList<Model.BusinessObjects.Inventory.ItemTransactionModel> ItemTransactions
        {
            set
            {
                ColumnsCollection.Clear();
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ItemTransactionDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxCode", ColumnVisible = false });
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

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCalculatePrice", ColumnVisible = false });

            }
        }

        /// <summary>
        /// Sets the fixed asset increment.
        /// </summary>
        /// <value>The fixed asset increment.</value>
        public IList<Model.BusinessObjects.FixedAsset.FixedAssetIncrementModel> FixedAssetIncrements
        {
            set
            {
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetIncrementDetails", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
            }
        }

        /// <summary>
        /// Sets the fixed asset decrement.
        /// </summary>
        /// <value>The fixed asset decrement.</value>
        public IList<Model.BusinessObjects.FixedAsset.FixedAssetDecrementModel> FixedAssetDecrements
        {
            set
            {
                ColumnsCollection.Clear();
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetDecrementDetails", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });

            }
        }

        /// <summary>
        /// Sets the fixed asset armortizations.
        /// </summary>
        /// <value>The fixed asset armortizations.</value>
        public IList<Model.BusinessObjects.FixedAsset.FixedAssetArmortizationModel> FixedAssetArmortizations
        {
            set
            {
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnVisible = false, ColumnPosition = 1, ColumnWith = 100, ToolTip = "Ngày hạch toán", ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetArmortizationDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraPrintVoucherByLot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void FrmXtraPrintVoucherByLot_Load(object sender, EventArgs e)
        {
            GetVoucherData();
            Selection = new GridCheckMarksSelection(gridVoucherView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 30;

            SetCheckedCurrentRow();
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            SelectedVoucher = "";
            SelectedFa = "";
            if (Selection.SelectedCount > 0)
            {
                for (int i = 0; i < gridVoucherView.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        SelectedVoucher += (SelectedVoucher != "") ? ";" + gridVoucherView.GetRowCellValue(i, "RefId") : "" + gridVoucherView.GetRowCellValue(i, "RefId");
                    }
                }

                for (int i = 0; i < gridVoucherView.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        SelectedFa += (SelectedFa != "") ? ";" + gridVoucherView.GetRowCellValue(i, "FixedAssetId") : "" + gridVoucherView.GetRowCellValue(i, "FixedAssetId");
                    }
                }

            }
            if (cboReportList.GetColumnValue("ReportID") != null)
            {
                ReportID = cboReportList.GetColumnValue("ReportID").ToString();
            }

            if ((string.IsNullOrEmpty(SelectedVoucher) && string.IsNullOrEmpty(SelectedFa)) || string.IsNullOrEmpty(ReportID))
            {
                XtraMessageBox.Show("Bạn chưa chọn chứng từ hoặc mẫu báo cáo cần in, vui lòng kiểm tra lại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = DialogResult.OK;
        }



        /// <summary>
        /// Handles the Click event of the btnSetDefaultReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetDefaultReport_Click(object sender, EventArgs e)
        {
            List<ReportListModel> lstReportList = (List<ReportListModel>)cboReportList.Properties.DataSource;
            string voucherlistDefault = cboReportList.EditValue.ToString();
            foreach (var item in lstReportList)
            {
                if (voucherlistDefault == item.ReportID)
                    item.PrintVoucherDefault = true;
                else
                    item.PrintVoucherDefault = false;
                _reportListPresenter.UpdateReportList(item);
            }

        }
        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>The report lists.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<ReportListModel> ReportLists
        {
            set { throw new NotImplementedException(); }
        }

        public IList<Model.BusinessObjects.General.GeneralVocherModel> GeneralVouchers
        {
            set
            {
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = true, ColumnCaption = "Ngày HT ", ColumnPosition = 1, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ColumnWith = 100, ToolTip = "Ngày hạch toán" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnPosition = 4, Alignment = HorzAlignment.Near, ColumnWith = 500 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền ", ColumnVisible = true, ColumnPosition = 5, Alignment = HorzAlignment.Far, ColumnWith = 200, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnVisible = true, ColumnPosition = 6, Alignment = HorzAlignment.Far, ColumnWith = 200, ToolTip = "Số tiền quy đổi", ColumnType = UnboundColumnType.Decimal });
            }

        }


        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                bindingSource.DataSource = value;
                gridVoucherView.PopulateColumns(value);
                gridVoucherControl.ForceInitialize();
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCode",
                    ColumnCaption = "Mã tài sản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    Alignment = HorzAlignment.Near
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetName",
                    ColumnCaption = "Tên tài sản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    Alignment = HorzAlignment.Near
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgPrice",
                    ColumnCaption = "Nguyên giá",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnType = UnboundColumnType.Decimal,
                    Alignment = HorzAlignment.Far
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "LifeTime",
                    ColumnCaption = "Thời gian SD",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Integer,
                    Alignment = HorzAlignment.Far,
                    ToolTip = "Thời gian sử dụng"
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "State", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmountUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmountUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AnnualDepreciationAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AnnualDepreciationAmountUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingOrgPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCurrencies", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NumberOfFloor", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AreaOfBuilding", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AreaOfFloor", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "WorkingArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AdministrationArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "HousingArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VacancyArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OccupiedArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "LeasingArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "GuestHouseArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OtherArea", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NumberOfSeat", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ControlPlate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsStateManagement", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBussiness", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ManagementCar", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsEstimateEmployee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Brand", ColumnVisible = false });

                foreach(GridColumn col in gridVoucherView.Columns)
                {
                    col.Visible = false;
                }

                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridVoucherView.Columns[column.ColumnName].Visible = true;
                        gridVoucherView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridVoucherView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridVoucherView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridVoucherView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridVoucherView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                    }
                    else
                        gridVoucherView.Columns[column.ColumnName].Visible = false;
                }
            }
        }


        public IList<Model.BusinessObjects.Cash.ReceiptVoucherDetailModel> ReceiptVoucherDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.Cash.CashDetailModel> PaymentVoucherDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.Deposit.DepositDetailModel> ReceiptDepositDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.Deposit.DepositDetailModel> PaymentDepositDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.General.GeneralDetailModel> GeneralVoucherDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.FixedAsset.FixedAssetIncrementDetailModel> FixedAssetIncrementDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.Inventory.ItemTransactionDetailModel> ItemTransactionDetails
        {
            set { }
        }


        public IList<Model.BusinessObjects.FixedAsset.FixedAssetDecrementDetailModel> FixedAssetDecrementDetails
        {
            set { }
        }
    }
}