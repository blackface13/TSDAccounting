/***********************************************************************
 * <copyright file="UserControlVoucherReceiptList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Presenter.Cash.ReceiptVoucher;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using TSD.AccountingSoft.View.Cash;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using System.Linq;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// UserControlVoucherReceiptList
    /// </summary>
    public partial class UserControlVoucherReceiptList : BaseVoucherListUserControl,IReceiptVouchersView
    {
        /// <summary>
        /// The _receipt vouchers presenter
        /// </summary>
        private readonly ReceiptVouchersPresenter _receiptVouchersPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlVoucherReceiptList"/> class.
        /// </summary>
        public UserControlVoucherReceiptList()
        {
            InitializeComponent();
           _receiptVouchersPresenter = new ReceiptVouchersPresenter(this);
        }

        /// <summary>
        /// Sets the receipt vouchers.
        /// </summary>
        /// <value>
        /// The receipt vouchers.
        /// </value>
        public IList<ReceiptVoucherModel> ReceiptVouchers
        {
            set
            {
                var cash = new List<ReceiptVoucherModel>();

                cash= GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = true, ColumnCaption = "Ngày HT ", ColumnPosition = 1, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ColumnWith = 70,ToolTip = "Ngày hạch toán"});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near ,ToolTip = "Số chứng từ"});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center,ToolTip = "Ngày chứng từ"});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnPosition = 5, Alignment = HorzAlignment.Near, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader",ColumnCaption = "chứng từ đi kèm", ColumnVisible = false, ColumnPosition = 6, Alignment = HorzAlignment.Near, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Số tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 8, ColumnVisible = true,ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });


                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else gridView.Columns[column.ColumnName].Visible = false;
                }

            }

        }

        public IList<ReceiptVoucherDetailModel> ReceiptVoucherDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDetailId",
                    ColumnVisible = false,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AutoBusinessId",
                    ColumnCaption = "ĐK tự động",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 80,
                    AllowEdit = false,
                    ToolTip = "Định khoản tự động"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản nợ"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản có"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 230,
                    IsSummaryText = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOc",
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Nguồn vốn",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 80
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục/TM",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ToolTip = "Mục/Tiểu mục"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherTypeId",
                    ColumnCaption = "Nghiệp vụ",
                    ColumnVisible = false,
                    ColumnWith = 100,
                    ColumnPosition = 9
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "Dự án",
                    ColumnPosition = 10,
                    ColumnVisible = false,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnCaption = "Đối tượng khác",
                    ColumnVisible = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MergerFundId",
                    ColumnCaption = "Quỹ sát nhập",
                    ColumnVisible = false
                });
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
            _receiptVouchersPresenter.Display((int)RefTypeId);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
              new ReceiptVouchersPresenter(null).Delete(long.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Prints the data.
        /// </summary>
        protected override void PrintData()
        {
            var frmParam = new FrmXtraPrintVoucherByLot {RefType = RefType.ReceiptCash};
            frmParam.Show();
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraVoucherReceiptDetail();
        }

        protected override void LoadDataIntoGridDetail(long refId)
        {
            _receiptVouchersPresenter.DisplayVoucherDetail(refId);
        }
    }
}
