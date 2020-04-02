
/***********************************************************************
 * <copyright file="UserControlPaymentVoucherList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn, ThangNK Modify
 * Email:    sonhb@buca.vn
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
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Presenter.Cash.PaymentVoucher;
using TSD.AccountingSoft.View.Cash;
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
    /// UserControlPaymentVoucherList class
    /// </summary>
    public partial class UserControlPaymentVoucherList : BaseVoucherListUserControl, IPaymentVouchersView
    {
        /// <summary>
        /// The _payment vouchers presenter
        /// </summary>
        private readonly PaymentVouchersPresenter _paymentVouchersPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlPaymentVoucherList"/> class.
        /// </summary>
        public UserControlPaymentVoucherList()
        {
            InitializeComponent();
            _paymentVouchersPresenter = new PaymentVouchersPresenter(this);
            _voucherTypesPresenter = new Presenter.Dictionary.VoucherType.VoucherTypesPresenter(this);
        }

        /// <summary>
        /// Sets the payment vouchers.
        /// </summary>
        /// <value>
        /// The payment vouchers.
        /// </value>
        public IList<CashModel> PaymentVouchers
        {
            set
            {

                var cash = new List<CashModel>();
                    
                   cash = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                bindingSource.DataSource = cash;
                gridView.PopulateColumns(cash);
                ColumnsCollection.Clear();
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ",ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });

            }
        }

        public IList<CashDetailModel> PaymentVoucherDetails
        {
            set 
            {
               
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ToolTip = "Định khoản tự động", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 80, AllowEdit = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ToolTip = "Tài khoản nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ToolTip = "Tài khoản có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 210, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ToolTip = "Mục tiểu mục", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _rpsVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnVisible = false, ColumnPosition = 10, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", ColumnCaption = "Quỹ sát nhập", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                LoadGridLayout(gridViewDetail, ColumnsCollection);
                SetNumericFormatControl(gridViewDetail, true);
            } 
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {            
            _paymentVouchersPresenter.Display((int)RefTypeId);
            _voucherTypesPresenter.Display();
        }

        protected override void LoadDataIntoGridDetail(long refId)
        {
            _paymentVouchersPresenter.DisplayVoucherDetail(refId);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new PaymentVoucherPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraFormPaymentVoucherDetail();
        }

    }
}
