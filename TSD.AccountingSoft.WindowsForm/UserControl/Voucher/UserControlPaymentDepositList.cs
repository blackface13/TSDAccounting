/***********************************************************************
 * <copyright file="UserControlPaymentDepositList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Presenter.Deposit.PaymentDeposit;
using TSD.AccountingSoft.View.Deposit;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.Session;
using DevExpress.Data;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// Class UserControlPaymentDepositList.
    /// </summary>
    public partial class UserControlPaymentDepositList : BaseVoucherListUserControl, IPaymentDepositsView
    {
        private readonly PaymentDepositsPresenter _paymentDepositsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlPaymentDepositList"/> class.
        /// </summary>
        public UserControlPaymentDepositList()
        {
            InitializeComponent();
            _voucherTypesPresenter = new Presenter.Dictionary.VoucherType.VoucherTypesPresenter(this);
            _paymentDepositsPresenter = new PaymentDepositsPresenter(this);
        }

        #region IPaymentVouchersView Members

        /// <summary>
        /// Sets the payment estimates.
        /// </summary>
        /// <value>
        /// The payment estimates.
        /// </value>
        public IList<DepositModel> PaymentDeposits
        {
            set
            {
                var deposit = new List<DepositModel>();
                    deposit = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                bindingSource.DataSource = deposit;
                gridView.PopulateColumns(deposit);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepositDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccountCode", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center,ToolTip ="Ngày hạch toán" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near, ToolTip ="Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 300, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
            }
        }

        public IList<DepositDetailModel> PaymentDepositDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 80, ToolTip = "Định khoản tự động", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 250, AllowEdit = true, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 130, AllowEdit = true, RepositoryControl = _rpsVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 10, ColumnVisible = false, ColumnWith = 100, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 11, ColumnVisible = false, ColumnWith = 100, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", ColumnCaption = "Quỹ sát nhập", ColumnPosition = 12, ColumnVisible = false, ColumnWith = 100, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 12, ColumnVisible = false, ColumnWith = 100, AllowEdit = true });
                LoadGridLayout(gridViewDetail, ColumnsCollection);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _voucherTypesPresenter.DisplayActive();
            _paymentDepositsPresenter.Display((int)RefTypeId);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// LinhMC
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(long refId)
        {
            _paymentDepositsPresenter.DisplayVoucherDetail(refId);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new PaymentDepositPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraPaymentDepositDetail();
        }
        #endregion

    }
}
