using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetIncrement;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.WindowsForm.CommonClass;
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
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetLedger;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraFormFAIncrementDetail : FrmXtraBaseVoucherDetail, IFixedAssetIncrementView, IFixedAssetIncrementsView, IFixedAssetsView, IFixedAssetLedgersView
    {
        #region Variable

        public RepositoryItemGridLookUpEdit _rpsDebitParallelAccountNumber;
        public RepositoryItemGridLookUpEdit _rpsCreditParallelAccountNumber;
        private readonly FixedAssetIncrementPresenter _fixedAssetIncrementPresenter;
        private readonly FixedAssetIncrementsPresenter _fixedAssetIncrementsPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private readonly FixedAssetLedgersPresenter _fixedAssetLedgersPresenter;
        private readonly GlobalVariable _globalVariable;
        private readonly MergerFundsPresenter _mergerFundsPresenter;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAssetCurrency;
        private GridView _gridLookUpEditFixedAssetCurrencyView;
        private GridView _gridLookUpEditFixedAssetView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditMergerFund;
        private GridView _gridLookUpEditMergerFundView;
        private RepositoryItemSpinEdit _rpsSpinEdit = new RepositoryItemSpinEdit();

        #endregion

        #region Properties

        public long RefId { get; set; }
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType)value : BaseRefTypeId; }
        }
        public string RefDate
        {
            get { return dtRefDate.EditValue == null ? null : dtRefDate.DateTime.ToShortDateString(); }
            set { dtRefDate.EditValue = DateTime.Parse(value); }
        }
        public string PostedDate
        {
            get { return dtPostDate.EditValue == null ? null : dtPostDate.DateTime.ToShortDateString(); }
            set { dtPostDate.EditValue = DateTime.Parse(value); }
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.EditValue = value; }
        }
        public string Trader
        {
            get { return txtContactName.Text; }
            set { txtContactName.EditValue = value; }
        }
        public string DocumentInclude
        {
            get { return txtDocumentInclude.Text; }
            set { txtDocumentInclude.Text = value; }
        }
        public string CurrencyCode
        {
            //get
            //{
            //    gridViewMaster.PostEditor();
            //    return gridViewMaster.GetFocusedRowCellValue("CurrencyCode").ToString();
            //}
            //set
            //{
            //    int rowHandle = gridViewMaster.FocusedRowHandle;
            //    gridViewMaster.SetRowCellValue(rowHandle, "CurrencyCode", value);
            //}

            get
            {
                return (cboCurrency.EditValue ?? "").ToString();
            }
            set
            {
                if (value == null)
                {
                    if (GlobalVariable.CurrencyType == 0)
                        value = _globalVariable.CurrencyAccounting;
                    else
                        value = _globalVariable.CurrencyLocal;
                }

                cboCurrency.EditValue = value;
                if (value == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
            }
        }
        public decimal ExchangeRate
        {
            get
            {
                return cboExchangRate.EditValue == null ? 1 : Convert.ToDecimal(cboExchangRate.EditValue);
            }
            set
            {
                //int rowHandle = gridViewMaster.FocusedRowHandle;
                //gridViewMaster.SetRowCellValue(rowHandle, "ExchangeRate", value);

                cboExchangRate.EditValue = value;
            }
        }
        public decimal TotalAmountOC { get; set; }
        public decimal TotalAmountExchange { get; set; }
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public int? BankId
        {
            get
            {
                var objBank = (BankModel)cboBank.GetSelectedDataRow();
                if (objBank != null)
                    return objBank.BankId;
                return null;
            }
            set
            {
                if (value != null)
                    cboBank.EditValue = value;
            }
        }

        public IList<FixedAssetIncrementModel> FixedAssetIncrements
        {
            set
            {
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetIncrementDetails", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ToolTip = "Ngày hạch toán",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 70,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ToolTip = "Số chứng từ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 70
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    ToolTip = "Ngày chứng từ",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 70,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Loại tiền tệ",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmountOC",
                    ColumnCaption = "Tổng tiền",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnType = UnboundColumnType.Decimal,
                    Alignment = HorzAlignment.Far
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmountExchange",
                    ColumnCaption = "Tổng tiền quy đổi",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnType = UnboundColumnType.Decimal
                });
            }
        }
        public IList<FixedAssetIncrementDetailModel> FixedAssetIncrementDetails
        {
            get
            {
                var fixedAssetIncrementDetailDetail = new List<FixedAssetIncrementDetailModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountExchange = 0;
                    for (int i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            var item = new FixedAssetIncrementDetailModel
                            {
                                FixedAssetId = (int?)gridViewDetail.GetRowCellValue(i, "FixedAssetId") == 0 ? null : (int?)gridViewDetail.GetRowCellValue(i, "FixedAssetId"),
                                AccountNumber = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber"),
                                CorrespondingAccountNumber = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber"),
                                Description = (string)gridViewDetail.GetRowCellValue(i, "Description"),
                                Quantity = (int)gridViewDetail.GetRowCellValue(i, "Quantity"),
                                UnitPriceOC = (decimal)gridViewDetail.GetRowCellValue(i, "UnitPriceOC"),
                                UnitPriceExchange = (decimal)gridViewDetail.GetRowCellValue(i, "UnitPriceExchange"),
                                AmountOC = (decimal)gridViewDetail.GetRowCellValue(i, "AmountOC"),
                                AmountExchange = (decimal)gridViewDetail.GetRowCellValue(i, "AmountExchange"),
                                VoucherTypeId = (int?)gridViewDetail.GetRowCellValue(i, "VoucherTypeId") == 0 ? null : (int?)gridViewDetail.GetRowCellValue(i, "VoucherTypeId"),
                                BudgetSourceCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetSourceCode"),
                                AccountingObjectId = (int?)gridViewDetail.GetRowCellValue(i, "AccountingObjectId") == 0 ? null : (int?)gridViewDetail.GetRowCellValue(i, "AccountingObjectId"),
                                BudgetItemCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemCode"),
                                DepartmentId = (int?)gridViewDetail.GetRowCellValue(i, "DepartmentId") == 0 ? null : (int?)gridViewDetail.GetRowCellValue(i, "DepartmentId"),
                                AutoBusinessId = (int?)gridViewDetail.GetRowCellValue(i, "AutoBusinessId") == 0 ? null : (int?)gridViewDetail.GetRowCellValue(i, "AutoBusinessId"),
                                //ProjectId = (int?)gridViewDetail.GetRowCellValue(i, "ProjectId") == 0 ? null : (int?)gridViewDetail.GetRowCellValue(i, "ProjectId"),
                                DetailBy = gridViewDetail.GetRowCellValue(i, "DetailBy") == null ? null : gridViewDetail.GetRowCellValue(i, "DetailBy").ToString()
                            };
                            totalAmount += item.AmountOC;
                            totalAmountExchange += item.AmountExchange;
                            fixedAssetIncrementDetailDetail.Add(item);
                        }
                        TotalAmountOC = totalAmount;
                        TotalAmountExchange = totalAmountExchange;
                    }
                }
                return fixedAssetIncrementDetailDetail.ToList();
            }
            set
            {
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value.OrderBy(o => o.CorrespondingAccountNumber).ToList();
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.FixedAssetIncrement)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<FixedAssetIncrementDetailModel> { new FixedAssetIncrementDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<FixedAssetIncrementDetailModel> { new FixedAssetIncrementDetailModel() };
                }

                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AutoBusinessId",
                    ColumnCaption = "ĐK tự động",
                    ColumnPosition = 0,
                    ToolTip = "Định khoản tự động",
                    ColumnVisible = true,
                    ColumnWith = 80,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    RepositoryControl = _rpsAutoBusiness
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetId",
                    ColumnCaption = "Mã TSCĐ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 70,
                    ToolTip = "Mã tài sản cố định",
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditFixedAsset
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản nợ",
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    RepositoryControl = _rpsAccountNumber
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản có",
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    RepositoryControl = _rpsCorrespondingAccountNumber
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ToolTip = "Diễn giải",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true,
                    IsSummaryText = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnCaption = "Số lượng",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Số lượng",
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Integer,
                    AllowEdit = true,
                    IsSummnary = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "UnitPriceOC",
                    ColumnCaption = "Đơn giá",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Đơn giá",
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "UnitPriceExchange",
                    ColumnCaption = "Đơn giá QĐ",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ToolTip = "Đơn giá quy đổi",
                    ColumnWith = 100,
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnCaption = "Thành tiền",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Số tiền",
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnCaption = "Thành tiền QĐ",
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Số tiền quy đổi",
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherTypeId",
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Nghiệp vụ",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true,
                    RepositoryControl = _rpsVoucherTypeId
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Nguồn vốn",
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Nguồn vốn",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true,
                    RepositoryControl = _rpsBudgetSource
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục/TM",
                    ColumnPosition = 12,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Mục/Tiểu mục",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true,
                    RepositoryControl = _rpsBudgetItem
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnPosition = 13,
                    ColumnVisible = false,
                    ColumnWith = 100,
                    ToolTip = "Chương",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetCategoryCode",
                    ColumnCaption = "Loại khoản",
                    ColumnPosition = 14,
                    ColumnVisible = false,
                    ColumnWith = 100,
                    ToolTip = "Loại khoản",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentId",
                    ColumnCaption = "Phòng ban",
                    ColumnPosition = 15,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Phòng ban",
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true
                    ,
                    RepositoryControl = _rpsDepartment
                });
                //ColumnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "ProjectId",
                //    ColumnCaption = "Dự án",
                //    ColumnPosition = 17,
                //    ColumnVisible = true,
                //    ColumnWith = 100,
                //    ToolTip = "Dự án",
                //    FixedColumn = FixedStyle.None,
                //    AllowEdit = true,
                //    RepositoryControl = _rpsProject
                //});
                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }
        public IList<FixedAssetIncrementDetailParallelModel> FixedAssetIncrementDetailParallels
        {
            get
            {
                var result = bindingSourceDetailParallel.DataSource as List<FixedAssetIncrementDetailParallelModel>;
                return result ?? new List<FixedAssetIncrementDetailParallelModel>();
            }
            set
            {
                if (value == null)
                    value = new List<FixedAssetIncrementDetailParallelModel>();
                bindingSourceDetailParallel.DataSource = value;
                gridViewAccountingPararell.PopulateColumns(value);
                var columnCollections = new List<XtraColumn>();
                //columnCollections.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ColumnPosition = 0, ToolTip = "Định khoản tự động", ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAutoBusiness });
                columnCollections.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, ToolTip = "Mã tài sản cố định", FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                columnCollections.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ", FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsDebitParallelAccountNumber });
                columnCollections.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có", FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsCreditParallelAccountNumber });
                columnCollections.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 250, ToolTip = "Diễn giải", FixedColumn = FixedStyle.None, AllowEdit = true, IsSummaryText = true });
                columnCollections.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 60, ToolTip = "Số lượng", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, AllowEdit = true, IsSummnary = true });
                columnCollections.Add(new XtraColumn { ColumnName = "Price", ColumnCaption = "Đơn giá", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ToolTip = "Đơn giá", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollections.Add(new XtraColumn { ColumnName = "PriceExchange", ColumnCaption = "Đơn giá QĐ", ColumnPosition = 7, ColumnVisible = true, ToolTip = "Đơn giá quy đổi", ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollections.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Thành tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollections.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Thành tiền QĐ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền quy đổi", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollections.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nghiệp vụ", FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsVoucherTypeId });
                columnCollections.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nguồn vốn", FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsBudgetSource });
                columnCollections.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục", FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsBudgetItem });
                columnCollections.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 100, ToolTip = "Phòng ban", FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsDepartment });
                //columnCollections.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 17, ColumnVisible = true, ColumnWith = 100, ToolTip = "Dự án", FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsProject });
                gridViewAccountingPararell = InitGridLayout(columnCollections, gridViewAccountingPararell);
                SetNumericFormatControl(gridViewAccountingPararell, true);
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
        public IList<FixedAssetCurrencyModel> FixedAssetCurrencys
        {
            set
            {
                _gridLookUpEditFixedAssetCurrency.DataSource = value;

                _gridLookUpEditFixedAssetCurrency.PopulateViewColumns();
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCurrencyId",
                    ColumnCaption = "Tiền tệ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    Alignment = HorzAlignment.Center
                });
                colColection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetId",
                    ColumnCaption = "Tên quỹ sát nhập",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 300,
                    Alignment = HorzAlignment.Center
                });
                colColection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });

                foreach (XtraColumn column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditFixedAssetCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditFixedAssetCurrencyView.Columns[column.ColumnName].SortIndex =
                            column.ColumnPosition;
                    }
                    else _gridLookUpEditFixedAssetCurrencyView.Columns[column.ColumnName].Visible = false;
                }

                _gridLookUpEditFixedAssetCurrency.DisplayMember = "FixedAssetCurrencyCode";
                _gridLookUpEditFixedAssetCurrency.ValueMember = "FixedAssetId";
                _gridLookUpEditFixedAssetCurrency.ShowFooter = false;
                _gridLookUpEditFixedAssetCurrency.View.OptionsView.ShowIndicator = false;
            }
        }
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "FixedAssetCode",
                            ColumnCaption = "Mã tài sản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            Alignment = HorzAlignment.Near
                        },
                        new XtraColumn
                        {
                            ColumnName = "FixedAssetName",
                            ColumnCaption = "Tên tài sản",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250,
                            Alignment = HorzAlignment.Near
                        },
                        new XtraColumn
                        {
                            ColumnName = "OrgPrice",
                            ColumnCaption = "Nguyên giá",
                            ColumnPosition = 3,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal,
                            Alignment = HorzAlignment.Far
                        },
                        new XtraColumn
                        {
                            ColumnName = "LifeTime",
                            ColumnCaption = "Thời gian SD",
                            ColumnPosition = 4,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Integer,
                            Alignment = HorzAlignment.Far,
                            ToolTip = "Thời gian sử dụng"
                        },
                        new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "UsedDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "State", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FixedAssetForeignName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProductionYear", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MadeIn", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FixedAssetCategoryId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PurchasedDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepreciationDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IncrementDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DisposedDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Unit", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SerialNumber", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Accessories", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Quantity", ColumnVisible = false},
                        new XtraColumn {ColumnName = "UnitPrice", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccumDepreciationAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RemainingAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExchangeRate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "UnitPriceUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgPriceUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccumDepreciationAmountUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RemainingAmountUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AnnualDepreciationAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AnnualDepreciationAmountUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepreciationRate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgPriceAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepreciationAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CapitalAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "EmployeeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RemainingOrgPrice", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FixedAssetCurrencies", ColumnVisible = false},
                        new XtraColumn {ColumnName = "NumberOfFloor", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AreaOfBuilding", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AreaOfFloor", ColumnVisible = false},
                        new XtraColumn {ColumnName = "WorkingArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AdministrationArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "HousingArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "VacancyArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OccupiedArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "LeasingArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "GuestHouseArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OtherArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "NumberOfSeat", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ControlPlate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsStateManagement", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsBussiness", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ManagementCar", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsEstimateEmployee", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Brand", ColumnVisible = false}
                    };

                    foreach (XtraColumn column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].AppearanceCell.TextOptions
                                .HAlignment = column.Alignment;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        }
                        else
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    _gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";
                    _gridLookUpEditFixedAsset.ShowFooter = false;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupResizeMode = ResizeMode.FrameResize;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(600, 250);
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetNumericFormatControl(_gridLookUpEditFixedAssetView, true);
            }
        }
        public IList<FixedAssetLedgerModel> FixedAssetLedgers { set; private get; }

        #endregion

        #region Override functions

        protected void InitGridMain()
        {
            var reciptVoucher = new List<FixedAssetIncrementModel>
            {
                new FixedAssetIncrementModel {ExchangeRate = 1, CurrencyCode = "USD"}
            };
            grdMaster.DataSource = reciptVoucher;
            gridViewMaster.PopulateColumns(reciptVoucher);
            var grdMainColumns = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false},
                new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefNo", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefDate", ColumnVisible = false},
                new XtraColumn {ColumnName = "AccountingObjectType", ColumnVisible = false},
                new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                new XtraColumn {ColumnName = "CustomerId", ColumnVisible = false},
                new XtraColumn {ColumnName = "VendorId", ColumnVisible = false},
                new XtraColumn {ColumnName = "EmployeeId", ColumnVisible = false},
                new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                new XtraColumn {ColumnName = "Trader", ColumnVisible = false},
                new XtraColumn {ColumnName = "DocumentInclude", ColumnVisible = false},
                new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Loại tiền tệ",
                    ToolTip = "Loại tiền tệ",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 20,
                    Alignment = HorzAlignment.Center
                },
                new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnVisible = true,
                    ColumnCaption = "Tỷ giá",
                    ToolTip = "Tỷ giá",
                    ColumnWith = 20,
                    ColumnPosition = 2,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn {ColumnName = "TotalAmountOC", ColumnVisible = false},
                new XtraColumn {ColumnName = "JournalMemo", ColumnVisible = false},
                new XtraColumn {ColumnName = "TotalAmountExchange", ColumnVisible = false},
                new XtraColumn {ColumnName = "FixedAssetIncrementDetails", ColumnVisible = false}
            };

            foreach (XtraColumn column in grdMainColumns)
            {
                if (column.ColumnVisible)
                {
                    gridViewMaster.Columns[column.ColumnName].Visible = true;
                    gridViewMaster.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridViewMaster.Columns[column.ColumnName].AbsoluteIndex = column.ColumnPosition;
                    gridViewMaster.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewMaster.Columns[column.ColumnName].ToolTip = column.ToolTip;
                }
                else
                {
                    gridViewMaster.Columns[column.ColumnName].Visible = false;
                }
            }
            //_rpsSpinEdit.IsFloatValue = true;
            //_rpsSpinEdit.EditMask = "#0.0000";
            //_rpsSpinEdit.MinValue = (decimal)0.0001;
            //_rpsSpinEdit.MaxValue = 100;
            //_rpsSpinEdit.ReadOnly = true;
            _rpsSpinEdit.Mask.MaskType = MaskType.Numeric;
            _rpsSpinEdit.Mask.EditMask = @"c" + _globalVariable.ExchangeRateDecimalDigits;
            _rpsSpinEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            _rpsSpinEdit.Mask.UseMaskAsDisplayFormat = true;
            _rpsSpinEdit.ReadOnly = true;
            gridViewMaster.Columns["CurrencyCode"].ColumnEdit = _rpsCurrency;
            gridViewMaster.Columns["ExchangeRate"].ColumnEdit = _rpsSpinEdit;
        }

        protected override void InitControls()
        {
            // Khởi tạo đối quỹ sát nhập
            _gridLookUpEditMergerFund = new RepositoryItemGridLookUpEdit { NullText = "" };
            _gridLookUpEditMergerFundView = new GridView();
            _gridLookUpEditMergerFund.View = _gridLookUpEditMergerFundView;
            _gridLookUpEditMergerFund.TextEditStyle = TextEditStyles.Standard;

            // Khởi tạo đối tượng TSCĐ
            _gridLookUpEditFixedAssetView = new GridView();
            _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditFixedAssetView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(700, 200),
                ShowFooter = false
            };
            _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditFixedAsset.View.BestFitColumns();

            _gridLookUpEditFixedAsset.KeyDown += _gridLookUpEditFixedAssetView_KeyDown;

            // Khởi tạo đối tượng FixedAssetCurrency
            _gridLookUpEditFixedAssetCurrency = new RepositoryItemGridLookUpEdit { NullText = "" };
            _gridLookUpEditFixedAssetCurrencyView = new GridView();
            _gridLookUpEditFixedAssetCurrency.View = _gridLookUpEditFixedAssetCurrencyView;

            //Khởi tạo _rpsCurrency
            _rpsSpinEdit = new RepositoryItemSpinEdit();
            //_rpsCurrency = new RepositoryItemGridLookUpEdit { NullText = "" };
            //_rpsCurrencyView = new GridView();
            //_rpsCurrency.View = _rpsCurrencyView;
            //_rpsCurrency.TextEditStyle = TextEditStyles.Standard;
            //khởi tạo _rpsAccountNumber 
            _rpsAccountNumber = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsAccountNumberView = new GridView();
            _rpsAccountNumber.View = _rpsAccountNumberView;
            _rpsAccountNumber.TextEditStyle = TextEditStyles.Standard;
            cboObjectCode.Properties.NullText = "";
        }

        protected override void InitData()
        {
            base.InitData();
            InitGridMain();
            _fixedAssetsPresenter.Display();

            if (GlobalVariable.IsPostToParentAccount)
                _accountsPresenter.DisplayActive();
            else
                _accountsPresenter.Display();
            if (MasterBindingSource.Current != null)
            {
                long receiptDepositId = ((FixedAssetIncrementModel)MasterBindingSource.Current).RefId;
                KeyValue = receiptDepositId.ToString(CultureInfo.InvariantCulture);
                _keyForSend = KeyValue;
            }
            else
            {
                _keyForSend = RefId.ToString();
            }
            if (int.Parse(KeyValue) != 0)
            {
                _fixedAssetIncrementPresenter.Display(long.Parse(KeyValue));
            }
            else
            {
                RefId = 0;
                KeyValue = null;
                FixedAssetIncrementDetails = new List<FixedAssetIncrementDetailModel>();
                FixedAssetIncrementDetailParallels = new List<FixedAssetIncrementDetailParallelModel>();
                cboObjectCode.EditValue = null;
            }
            if (ActionMode == ActionModeVoucherEnum.None)
                txtDocumentInclude.Properties.ReadOnly = true;

            cboObjectCategory.Focus();
            cboObjectCode.Focus();
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;
            txtDocumentInclude.Properties.ReadOnly = true;

            var resultDetailParallels = new DialogResult();
            if (FixedAssetIncrementDetailParallels.Count > 0)
            {
                resultDetailParallels = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelUpdateQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                resultDetailParallels = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            var result = resultDetailParallels == DialogResult.OK ? _fixedAssetIncrementPresenter.Save(true) : _fixedAssetIncrementPresenter.Save(false);
            if (result > 0)
                _fixedAssetIncrementPresenter.Display(result);
            return result;

            //return _fixedAssetIncrementPresenter.Save();
        }

        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            if (RefNo.Length == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }
            if (dtPostDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            if (FixedAssetIncrementDetails == null || FixedAssetIncrementDetails.Count <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFAArmortizationDetails"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (FixedAssetIncrementDetails.Count > 0)
            {
                int i = 0;
                string currencyCode = cboCurrency.EditValue == null ? "" : cboCurrency.EditValue.ToString(); /*(string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");*/
                var lstRowAmounts = new List<string>();
                foreach (FixedAssetIncrementDetailModel fixedAssetIncrementDetail in FixedAssetIncrementDetails)
                {
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(fixedAssetIncrementDetail))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (fixedAssetIncrementDetail.AmountOC == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var strCorrespondingAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber");
                    var strAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber");
                    if ((fixedAssetIncrementDetail.VoucherTypeId == 2 || fixedAssetIncrementDetail.VoucherTypeId == 3 ||
                         fixedAssetIncrementDetail.VoucherTypeId == 12) && ExchangeRate == 1 && CurrencyCode != "USD")
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckExchangeRate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (fixedAssetIncrementDetail.AccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (fixedAssetIncrementDetail.CorrespondingAccountNumber == null)
                    {
                        XtraMessageBox.Show("Tài khoản đối ứng không được để trống!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (fixedAssetIncrementDetail.AccountNumber == fixedAssetIncrementDetail.CorrespondingAccountNumber)
                    {
                        XtraMessageBox.Show("Tài khoản nợ và tài khoản có không được trùng nhau", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    var strCurrency = currencyCode;//(string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");
                    var rowValue = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(strCorrespondingAccountNumberDetail);

                    if (rowValue == null)
                    {
                        XtraMessageBox.Show("Bạn chưa chọn tài khoản có !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (rowValue.IsCurrency && rowValue.CurrencyCode != strCurrency && rowValue.CurrencyCode != null && rowValue.IsFixedAsset == false)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản có theo tiền chưa đúng, bạn phải chọn lại !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (rowValue.IsCurrency)
                    {
                        if (strCorrespondingAccountNumberDetail.Substring(0, 3) == "111")
                        {
                            if (cboObjectCategory.EditValue == null || Convert.ToInt32(cboObjectCategory.EditValue) == -1)
                            {
                                XtraMessageBox.Show("Bạn cần phải nhập loại đối tượng !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                if (cboObjectCategory.EditValue == null || Convert.ToInt32(cboObjectCategory.EditValue) == -1)
                                {
                                    XtraMessageBox.Show("Bạn cần phải chọn mã đối tượng !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                    }

                    // bẫy lỗi ,0-nhà cung cấp,1-nhân viên, 2-đối tượng khác
                    //rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(strCorrespondingAccountNumberDetail);
                    if (rowValue.IsVendor && rowValue.IsFixedAsset == false) //Nhà cung cấp
                    {
                        if (AccountingObjectType == 1 || AccountingObjectType == 2)
                        {
                            XtraMessageBox.Show("Tài khoản " + strCorrespondingAccountNumberDetail + " theo dõi theo nhà cung cấp!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    if (rowValue.IsEmployee && rowValue.IsFixedAsset == false) //Nhân viên
                    {
                        if (AccountingObjectType == 0 || AccountingObjectType == 2)
                        {
                            XtraMessageBox.Show("Tài khoản " + strCorrespondingAccountNumberDetail + " theo dõi theo nhân viên!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (rowValue.IsAccountingObject && rowValue.IsFixedAsset == false) //Đối tượng khác
                    {
                        if (AccountingObjectType == 0 || AccountingObjectType == 1)
                        {
                            XtraMessageBox.Show("Tài khoản " + strCorrespondingAccountNumberDetail + " theo dõi theo đối tượng khác!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // bẫy lỗi ,0-nhà cung cấp,1-nhân viên, 2-đối tượng khác
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(strAccountNumberDetail);

                    if (rowValue == null)
                    {
                        XtraMessageBox.Show("Bạn chưa chọn tài khoản nợ !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    else if (rowValue.IsVendor && rowValue.IsFixedAsset == false) //Nhà cung cấp
                    {
                        if (AccountingObjectType == 1 || AccountingObjectType == 2)
                        {
                            XtraMessageBox.Show("Tài khoản " + strAccountNumberDetail + " theo dõi theo nhà cung cấp!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    if (rowValue.IsEmployee && rowValue.IsFixedAsset == false) //Nhân viên
                    {
                        if (AccountingObjectType == 0 || AccountingObjectType == 2)
                        {
                            XtraMessageBox.Show("Tài khoản " + strAccountNumberDetail + " theo dõi theo nhân viên!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (rowValue.IsAccountingObject && rowValue.IsFixedAsset == false) //Đối tượng khác
                    {
                        if (AccountingObjectType == 0 || AccountingObjectType == 1)
                        {
                            XtraMessageBox.Show("Tài khoản " + strAccountNumberDetail + " theo dõi theo đối tượng khác!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    bool isDetailValid = true;
                    if (fixedAssetIncrementDetail.DetailBy != null)
                    {
                        string[] detailFieldNames = fixedAssetIncrementDetail.DetailBy.Split(';');
                        //Mã đối tượng từ phần master vào detail nên không cần kiểm tra chi tiết theo đối tượng
                        if (detailFieldNames.Any(t => fixedAssetIncrementDetail.GetType().GetProperty(t) != null && fixedAssetIncrementDetail.GetType().GetProperty(t).Name != "AccountingObjectId" && fixedAssetIncrementDetail[t] != null))
                        {
                            isDetailValid = false;
                        }
                        if (!isDetailValid)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false;
                        }
                    }

                    if (fixedAssetIncrementDetail.AccountNumber.Substring(0, 3) == "111")
                    {
                        if (cboObjectCategory.EditValue == null)
                        {
                            XtraMessageBox.Show("Bạn cần phải nhập loại đối tượng !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (cboObjectCategory.EditValue == null)
                            {
                                XtraMessageBox.Show("Bạn cần phải chọn mã đối tượng !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    if (fixedAssetIncrementDetail.AccountNumber.StartsWith("111") || fixedAssetIncrementDetail.CorrespondingAccountNumber.StartsWith("111"))
                    {
                        if (string.IsNullOrEmpty(DocumentInclude))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDocumentInclude.Focus();
                            return false;
                        }
                    }

                    #region  Kiểm tra tổng số tiền chi không vượt quá số tiền tồn quỹ
                    CurrencyCurrent = currencyCode;// Tiền hạch toán
                    var budgetSourceCode = fixedAssetIncrementDetail.BudgetSourceCode;
                    decimal totalAmount;// tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if (fixedAssetIncrementDetail.CorrespondingAccountNumber.Substring(0, 3) == "111")
                    {
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = FixedAssetIncrementDetails.Where(x => x.CorrespondingAccountNumber.Substring(0, 3) == "111").Sum(x => x.AmountOC);
                            GetCalculateCashBalance(fixedAssetIncrementDetail.CorrespondingAccountNumber, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year);// thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi số dư tiền gửi âm
                    if (fixedAssetIncrementDetail.CorrespondingAccountNumber.Substring(0, 3) == "112")
                    {
                        if (!DBOptionHelper.IsDepositeNegavtiveFund)
                        {
                            totalAmount = FixedAssetIncrementDetails.Where(x => x.CorrespondingAccountNumber.Substring(0, 3) == "112").Sum(x => x.AmountOC);
                            GetCalculateDepositBalance(fixedAssetIncrementDetail.CorrespondingAccountNumber, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi nguồn âm
                    if (fixedAssetIncrementDetail.AccountNumber.Substring(0, 3) == "461" || fixedAssetIncrementDetail.AccountNumber.Substring(0, 3) == "661")
                    {
                        if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
                        {
                            // Số dư Có TK 4612
                            GetCalculateCapitalBalance("4612", budgetSourceCode, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            var accountBalance = ClosingAmount;

                            // Số dư Nợ TK 6612
                            GetCalculateCapitalBalance("6612", budgetSourceCode, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            accountBalance = accountBalance - ClosingAmount;

                            totalAmount = FixedAssetIncrementDetails.Where(x => x.BudgetSourceCode == budgetSourceCode && (x.AccountNumber.Substring(0, 3) == "461" || x.AccountNumber.Substring(0, 3) == "661")).Sum(x => x.AmountOC);
                            if (totalAmount > accountBalance)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        protected override void DeleteVoucher()
        {
            bool a = CheckFixedAsset();
            if (a)
            {
                XtraMessageBox.Show(
                    string.Format(ResourceHelper.GetResourceValueByName("ResDeleteFixedAssetIncrement")),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                long refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
                _fixedAssetIncrementPresenter.Delete(refId);
            }
        }

        private bool CheckFixedAsset()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            var fixedAsset = _fixedAssetIncrementsPresenter.DisplayFaInDecreamnet(refId);
            return fixedAsset.Count != 0;
        }

        protected override void EditVoucher()
        {
            txtDocumentInclude.Properties.ReadOnly = false;
            base.EditVoucher();
            cboCurrency_EditValueChanged(null, null);
        }

        protected override void CancelVoucher()
        {
            txtDocumentInclude.Properties.ReadOnly = true;
            base.CancelVoucher();
        }

        protected override void DuplicateVoucher()
        {
            txtDocumentInclude.Properties.ReadOnly = false;
            base.DuplicateVoucher();
        }

        protected override void ReFreshControl()
        {
            txtDocumentInclude.Properties.ReadOnly = false;
        }

        #endregion

        #region Events

        public FrmXtraFormFAIncrementDetail()
        {
            InitializeComponent();
            _fixedAssetIncrementPresenter = new FixedAssetIncrementPresenter(this);
            _fixedAssetIncrementsPresenter = new FixedAssetIncrementsPresenter(this);
           // _mergerFundsPresenter = new MergerFundsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _fixedAssetLedgersPresenter = new FixedAssetLedgersPresenter(this);
            _globalVariable = new GlobalVariable();
        }

        private void FrmXtraFormFAIncrementDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, false);

            this.gridViewDetail.CellValueChanged += gridViewDetail_CellValueChanged;
            this.gridViewMaster.RowUpdated += gridViewMaster_RowUpdated;
            this.gridViewMaster.CellValueChanged += gridViewMaster_CellValueChanged;
            //this._rpsVoucherTypeIdView.KeyDown += _gridLookUpEditVoucherTypeView_KeyDown;
            //this._rpsBudgetSourceView.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;
            //this._rpsBudgetItemView.KeyDown += _gridLookUpEditBudgetItemView_KeyDown;
            //this._rpsProjectView.KeyDown += _gridLookUpEditProjectView_KeyDown;
            //this._rpsdepartmentView.KeyDown += _gridLookUpEditDepartmentView_KeyDown;
            //this._rpsAutoBusinessView.KeyDown += _gridLookUpEditAutoBusinessView_KeyDown;
        }

        private void FrmXtraFormFAIncrementDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, false);
        }

        private void SetObjectInfo(string objectName, string trader, string address)
        {
            cboObjectName.Text = objectName;
            txtContactName.Text = trader;
            txtAddress.Text = address;
        }

        private void gridViewDetail_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void gridViewDetail_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                //var quantityCol = gridViewDetail.Columns["Quantity"];
                ////var unitPriceCol = gridViewDetail.Columns["UnitPriceOC"];
                //var accountNumberCol = gridViewDetail.Columns["AccountNumber"];
                //var correspondingAccountNumberCol = gridViewDetail.Columns["CorrespondingAccountNumber"];
                //gridViewDetail.SetRowCellValue(e.RowHandle, quantityCol, 1);
                ////gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceCol, 0);
                //gridViewDetail.SetRowCellValue(e.RowHandle, accountNumberCol, "211");
                //gridViewDetail.SetRowCellValue(e.RowHandle, correspondingAccountNumberCol, "2141");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                string exchangeRateCol;

                switch (e.Column.FieldName)
                {
                    case "FixedAssetId":
                        GridColumn descriptionCol = gridViewDetail.Columns["Description"];
                        GridColumn dDepartmentIdCol = gridViewDetail.Columns["DepartmentId"];
                        GridColumn quantityCol = gridViewDetail.Columns["Quantity"];
                        GridColumn unitPriceColOC = gridViewDetail.Columns["UnitPriceOC"];
                        GridColumn unitPriceColExchange = gridViewDetail.Columns["UnitPriceExchange"];
                        GridColumn amountOCCol = gridViewDetail.Columns["AmountOC"];
                        GridColumn amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        GridColumn accountNumberCol = gridViewDetail.Columns["AccountNumber"];
                        GridColumn correspondingAccountNumberCol = gridViewDetail.Columns["CorrespondingAccountNumber"];
                        GridColumn budgetSourceCodeCol = gridViewDetail.Columns["BudgetSourceCode"];
                        GridColumn budgetItemCodeCol = gridViewDetail.Columns["BudgetItemCode"];

                        var currencyCodeCol = CurrencyCode; //gridViewMaster.Columns["CurrencyCode"];
                        exchangeRateCol = "ExchangeRate";//gridViewMaster.Columns["ExchangeRate"];
                        if ((int)e.Value > 0)
                        {
                            var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                            gridViewDetail.SetRowCellValue(e.RowHandle, descriptionCol, "Ghi tăng tài sản " + fixedAsset.FixedAssetCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, currencyCodeCol, fixedAsset.CurrencyCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, quantityCol, fixedAsset.Quantity);
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceColOC, fixedAsset.UnitPrice);
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceColExchange, fixedAsset.UnitPriceUSD);
                            gridViewDetail.SetRowCellValue(e.RowHandle, dDepartmentIdCol, fixedAsset.DepartmentId);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountOCCol, fixedAsset.OrgPrice);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, fixedAsset.OrgPriceUSD);
                            gridViewMaster.SetRowCellValue(e.RowHandle, currencyCodeCol, fixedAsset.CurrencyCode);
                            gridViewMaster.SetRowCellValue(e.RowHandle, exchangeRateCol, fixedAsset.ExchangeRate);
                            gridViewDetail.SetRowCellValue(e.RowHandle, accountNumberCol, fixedAsset.OrgPriceAccountCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, correspondingAccountNumberCol, fixedAsset.CapitalAccountCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, budgetSourceCodeCol, fixedAsset.BudgetSourceCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, budgetItemCodeCol, fixedAsset.BudgetItemCode);
                        }
                        break;

                    case "Quantity":
                        quantityCol = gridViewDetail.Columns["Quantity"];
                        amountExchangeCol = gridViewDetail.Columns["AmountExchange"];

                        GridColumn amountCol = gridViewDetail.Columns["AmountOC"];
                        GridColumn unitPriceOCCol = gridViewDetail.Columns["UnitPriceOC"];
                        GridColumn unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];
                        var quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        decimal exchangeRate;
                        var unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);
                        var unitPriceExchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceExchangeCol);
                        gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, quantity * unitPriceOC);
                        gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceExchange);

                        break;

                    case "UnitPriceOC":
                        if ((decimal)e.Value > 0)
                        {
                            quantityCol = gridViewDetail.Columns["Quantity"];
                            amountCol = gridViewDetail.Columns["AmountOC"];
                            amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                            unitPriceOCCol = gridViewDetail.Columns["UnitPriceOC"];
                            unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];
                            exchangeRateCol = "ExchangeRate"; //gridViewMaster.Columns["ExchangeRate"];
                            quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                            exchangeRate = ExchangeRate;//(decimal)gridViewMaster.GetFocusedRowCellValue(exchangeRateCol);
                            unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, quantity * unitPriceOC);
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, unitPriceOC / exchangeRate);
                            unitPriceExchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceExchangeCol);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceExchange);
                        }
                        break;

                    case "AmountOC":
                        if ((decimal)e.Value > 0)
                        {
                            amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                            exchangeRateCol = "ExchangeRate"; //gridViewMaster.Columns["ExchangeRate"];
                            exchangeRate = ExchangeRate; //(decimal)gridViewMaster.GetFocusedRowCellValue(exchangeRateCol);
                            if (exchangeRate > 0)
                                gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, (decimal)e.Value / exchangeRate);
                        }
                        break;

                    case "AutoBusinessId":
                        {
                            int rowHandle = gridViewDetail.FocusedRowHandle;
                            if (gridViewDetail.GetRowCellValue(rowHandle, "AutoBusinessId") != null)
                            {
                                var autoBusinessId = (int)gridViewDetail.GetRowCellValue(rowHandle, "AutoBusinessId");
                                var autoBusiness = (AutoBusinessModel)_rpsAutoBusiness.GetRowByKeyValue(autoBusinessId);
                                gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", autoBusiness.DebitAccountNumber);
                                gridViewDetail.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", autoBusiness.CreditAccountNumber);
                                gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", autoBusiness.VoucherTypeId);
                                gridViewDetail.SetRowCellValue(rowHandle, "Description", autoBusiness.Description);
                                gridViewDetail.SetRowCellValue(rowHandle, "BudgetSourceCode", autoBusiness.BudgetSourceCode);
                                gridViewDetail.SetRowCellValue(rowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                            }
                        }
                        break;

                        //case "ProjectId":
                        //    {
                        //        int rowHandle = gridViewDetail.FocusedRowHandle;
                        //        if (gridViewDetail.GetRowCellDisplayText(rowHandle, "ProjectId") == null)
                        //        {
                        //            gridViewDetail.SetRowCellValue(rowHandle, "ProjectId", null);
                        //        }
                        //    }
                        //    break;
                }
                //--------LinhMC: valid detail by account in Griddetail voucher---------// 
                if (!e.Column.FieldName.Equals("DetailBy"))
                {
                    //object accountNumber = gridViewDetail.GetFocusedRowCellValue("AccountNumber");
                    object accountNumber = gridViewDetail.GetRowCellValue(e.RowHandle, "AccountNumber");
                    string accountNumberDetailBy = "";
                    if (accountNumber != null)
                    {
                        accountNumberDetailBy = GetAccountDetailBy(accountNumber.ToString());
                    }
                    //object correspondingAccountNumber =
                    //    gridViewDetail.GetFocusedRowCellValue("CorrespondingAccountNumber");

                    object correspondingAccountNumber = gridViewDetail.GetRowCellValue(e.RowHandle, "CorrespondingAccountNumber");
                    string correspondingAccountNumberDetailBy = "";
                    if (correspondingAccountNumber != null)
                    {
                        correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber.ToString());
                    }

                    accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy) ? correspondingAccountNumberDetailBy : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                    string[] detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    detailByArray = detailByArray.Where(w => !w.Contains("ProjectId")).ToArray();
                    string detail = string.Join(";", detailByArray);
                    //Bổ sung thêm 2 trường Quantity và ExchangeRate
                    object fixedAssetModel = gridViewDetail.GetRowCellValue(e.RowHandle, "FixedAssetId");
                    if (fixedAssetModel != null)
                    {
                        if (!_fixedAssetLedgersPresenter.Display((int)fixedAssetModel).Any())
                        {
                            detail = !string.IsNullOrEmpty(detail) ? detail + ";Quantity;ExchangeRate" : detail + "Quantity;ExchangeRate";
                        }
                        else
                        {
                            detail = !string.IsNullOrEmpty(detail) ? detail + ";ExchangeRate" : detail + "ExchangeRate";
                        }
                    }
                    gridViewDetail.SetFocusedRowCellValue("DetailBy", detail);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewMaster_RowUpdated(object sender, RowObjectEventArgs e)
        {
            var currency = (string)gridViewMaster.GetFocusedRowCellValue("CurrencyCode");
            var exchangeRate = (decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
            if (currency.Equals("USD"))
            {
                gridViewMaster.SetRowCellValue(e.RowHandle, "ExchangeRate", 1);
            }
            else
            {
                if (exchangeRate != 1)
                {
                    IList<FixedAssetIncrementDetailModel> depositDetails = FixedAssetIncrementDetails;
                    var exchangRate = (decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
                    if (exchangRate > 0 && depositDetails.Count > 0)
                    {
                        for (int i = 0; i < FixedAssetIncrementDetails.Count; i++)
                        {
                            if (FixedAssetIncrementDetails[i].AmountOC > 0)
                            {
                                gridViewDetail.SetRowCellValue(i, "AmountExchange",
                                    FixedAssetIncrementDetails[i].AmountOC / exchangRate);
                                gridViewDetail.SetRowCellValue(i, "UnitPriceExchange",
                                    FixedAssetIncrementDetails[i].UnitPriceOC / exchangRate);
                            }
                        }
                    }
                }
            }
        }

        private void gridViewMaster_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridViewMaster.PostEditor();
            //var currency = (string)gridViewMaster.GetFocusedRowCellValue("CurrencyCode");
            if (e.Column.FieldName.Equals("ExchangeRate"))
            {
                IList<FixedAssetIncrementDetailModel> voucherDetails = FixedAssetIncrementDetails;
                var exchangRate = (decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
                if (exchangRate > 0 && voucherDetails.Count > 0)
                {
                    for (int i = 0; i < FixedAssetIncrementDetails.Count; i++)
                    {
                        if (FixedAssetIncrementDetails[i].AmountOC > 0)
                        {
                            gridViewDetail.SetRowCellValue(i, "AmountExchange",
                                FixedAssetIncrementDetails[i].AmountOC / exchangRate);
                            gridViewDetail.SetRowCellValue(i, "UnitPriceExchange",
                                FixedAssetIncrementDetails[i].UnitPriceOC / exchangRate);
                        }
                    }
                }
            }
            if (e.Column.FieldName.Equals("CurrencyCode"))
            {
                var strCurrent = (string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");
                if (strCurrent == "USD")
                {
                    gridViewMaster.SetRowCellValue(0, gridViewMaster.Columns["ExchangeRate"], 1);
                    _rpsSpinEdit.ReadOnly = true;
                }
                else
                {
                    _rpsSpinEdit.ReadOnly = false;
                }
            }
        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);
            if (CurrencyCode.Trim().ToUpper() == "USD")
            {
                ExchangeRate = 1;
                cboExchangRate.Enabled = false;
            }
            else
            {
                cboExchangRate.Enabled = true;
            }
        }

        #endregion

        #region Repository Keydown Event

        private void _gridLookUpEditVoucherTypeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var voucherTypeId = gridViewDetail.Columns["VoucherTypeId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, voucherTypeId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var budgetSourceCode = gridViewDetail.Columns["BudgetSourceCode"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        private void _gridLookUpEditBudgetItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var budgetItemCode = gridViewDetail.Columns["BudgetItemCode"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, budgetItemCode, null);
            e.Handled = true;
        }

        private void _gridLookUpEditProjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var projectId = gridViewDetail.Columns["ProjectId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, projectId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditDepartmentView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var departmentId = gridViewDetail.Columns["DepartmentId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, departmentId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditAutoBusinessView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var autoBusinessId = gridViewDetail.Columns["AutoBusinessId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, autoBusinessId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditFixedAssetView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var fixedAssetId = gridViewDetail.Columns["FixedAssetId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, fixedAssetId, 0);
            e.Handled = true;
        }

        #endregion
    }
}