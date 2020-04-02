/***********************************************************************
 * <copyright file="UserControlReceiptDepositList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Presenter.Deposit.ReceiptDeposit;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
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
    /// class UserControlReceiptDepositList
    /// </summary>
    public partial class UserControlReceiptDepositList : BaseVoucherListUserControl, IReceiptDepositsView
    {
        private readonly ReceiptDepositsPresenter _receiptDepositsPresenter;

        public UserControlReceiptDepositList()
        {
            InitializeComponent();
            _receiptDepositsPresenter = new ReceiptDepositsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
        }

        #region Properties

        public IList<DepositModel> ReceiptDeposits
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccountCode", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ToolTip = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ToolTip = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 300, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ToolTip = "Số tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ToolTip = "Số tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                foreach (var column in ColumnsCollection)
                {
                    gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                }
            }
        }

        public IList<DepositDetailModel> ReceiptDepositDetails
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FeeAmount", ColumnCaption = "Lệ phí", ColumnPosition = 7, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FeeAmountExchange", ColumnCaption = "Lệ phí quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 80, ToolTip = "Mục/Tiểu mục", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 12, ColumnVisible = false, ColumnWith = 80, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 80, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", ColumnVisible = false });
                LoadGridLayout(gridViewDetail, ColumnsCollection);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        protected override void LoadDataIntoGrid()
        {
            _voucherTypesPresenter.DisplayActive();
            _receiptDepositsPresenter.Display((int)RefTypeId);
        }

        protected override void LoadDataIntoGridDetail(long refId)
        {
            _receiptDepositsPresenter.DisplayVoucherDetail(refId);
        }

        protected override void DeleteGrid()
        {
            new ReceiptDepositPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraReceiptDepositDetail();
        }

        #endregion
    }
}
