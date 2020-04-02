/***********************************************************************
 * <copyright file="FrmXtraFormFADecrementDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 11 April 2014
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
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetDecrement;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Model.History;
using TSD.AccountingSoft.WindowsForm.CommonClass;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    ///     class FrmXtraFormFADecrementDetail
    /// </summary>
    public partial class FrmXtraFormFADecrementDetail : FrmXtraBaseVoucherDetail, IFixedAssetDecrementView, IFixedAssetsView
    {
        #region Variables

        private readonly FixedAssetDecrementPresenter _fixedAssetDecrementPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        public RepositoryItemGridLookUpEdit _rpsDebitParallelAccountNumber;
        public RepositoryItemGridLookUpEdit _rpsCreditParallelAccountNumber;

        private RepositoryItemCalcEdit _calcEditExchangeRate;
        private RepositoryItemComboBox _cboCurrencyCode;
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditMergerFund;
        private GridView _gridLookUpEditMergerFundView;

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
        public string CurrencyCode
        {
            get
            {
                return cboCurrency.EditValue.ToString();
            }
            set
            {
                if (value == null)
                {
                    value = GlobalVariable.CurrencyType == 0 ? CurrencyAccounting : CurrencyLocal;
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
        public decimal TotalAmountOc { get; set; }
        public decimal TotalAmountExchange { get; set; }
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
        public string Trader
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
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

        public IList<FixedAssetDecrementDetailModel> FixedAssetDecrementDetails
        {
            get
            {
                var faDecrementDetail = new List<FixedAssetDecrementDetailModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountExchange = 0;
                    for (int i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            var item = new FixedAssetDecrementDetailModel
                            {
                                FixedAssetId = (int)gridViewDetail.GetRowCellValue(i, "FixedAssetId"),
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
                                //ProjectId =
                                //    (int?)gridViewDetail.GetRowCellValue(i, "ProjectId") == 0
                                //        ? null
                                //        : (int?)gridViewDetail.GetRowCellValue(i, "ProjectId"),
                                DetailBy = gridViewDetail.GetRowCellValue(i, "DetailBy") == null ? null : gridViewDetail.GetRowCellValue(i, "DetailBy").ToString()
                            };
                            totalAmount += item.AmountOC;
                            totalAmountExchange += item.AmountExchange;
                            faDecrementDetail.Add(item);
                        }
                        TotalAmountOc = totalAmount;
                        TotalAmountExchange = totalAmountExchange;
                    }
                }
                return faDecrementDetail.ToList();
            }

            set
            {
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value.OrderBy(o => o.AccountNumber).ToList();
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.FixedAssetDecrement)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<FixedAssetDecrementDetailModel> { new FixedAssetDecrementDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<FixedAssetDecrementDetailModel> { new FixedAssetDecrementDetailModel() };
                }

                gridViewDetail.PopulateColumns(value);
                gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK Tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Định khoản tự động", Alignment = HorzAlignment.Center, RepositoryControl = _rpsAutoBusiness });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mã tài sản cố định", Alignment = HorzAlignment.Center, RepositoryControl = _gridLookUpEditFixedAsset });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tài khoản nợ", Alignment = HorzAlignment.Center, RepositoryControl = _rpsAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, ToolTip = "Tài khoản có", AllowEdit = true, RepositoryControl = _rpsCorrespondingAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 250, FixedColumn = FixedStyle.None, AllowEdit = true, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, IsSummnary = false, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOC", ColumnCaption = "Đơn giá", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", ColumnCaption = "Đơn giá quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Thành tiền", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Thành tiền QĐ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsVoucherTypeId });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ToolTip = "Mục/Tiểu mục", AllowEdit = true, RepositoryControl = _rpsBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnVisible = true, ColumnPosition = 14, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsDepartment });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnVisible = true, ColumnPosition = 15, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "ĐT Khác", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Loại khoản", ColumnVisible = false });

                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }
        public IList<FixedAssetDecrementDetailParallelModel> FixedAssetDecrementDetailParallels
        {
            get
            {
                var result = bindingSourceDetailParallel.DataSource as List<FixedAssetDecrementDetailParallelModel> ?? new List<FixedAssetDecrementDetailParallelModel>();
                return result;
            }
            set
            {
                if (value == null)
                    value = new List<FixedAssetDecrementDetailParallelModel>();
                bindingSourceDetailParallel.DataSource = value;
                gridViewAccountingPararell.PopulateColumns(value);
                var columnCollection = new List<XtraColumn>();
                //columnCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK Tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Định khoản tự động", Alignment = HorzAlignment.Center, RepositoryControl = _rpsAutoBusiness });
                columnCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mã tài sản cố định", Alignment = HorzAlignment.Center, RepositoryControl = _gridLookUpEditFixedAsset });
                columnCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tài khoản nợ", Alignment = HorzAlignment.Center, RepositoryControl = _rpsDebitParallelAccountNumber });
                columnCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, ToolTip = "Tài khoản có", AllowEdit = true, RepositoryControl = _rpsCreditParallelAccountNumber });
                columnCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 250, FixedColumn = FixedStyle.None, AllowEdit = true, IsSummaryText = true });
                columnCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, IsSummnary = false, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "Price", ColumnCaption = "Đơn giá", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "PriceExchange", ColumnCaption = "Đơn giá quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Thành tiền", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Thành tiền QĐ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsVoucherTypeId });
                columnCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsBudgetSource });
                columnCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ToolTip = "Mục/Tiểu mục", AllowEdit = true, RepositoryControl = _rpsBudgetItem });
                columnCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnVisible = true, ColumnPosition = 14, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsDepartment });
                //columnCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnVisible = true, ColumnPosition = 15, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsProject });
                gridViewAccountingPararell = InitGridLayout(columnCollection, gridViewAccountingPararell);
                SetNumericFormatControl(gridViewAccountingPararell, true);
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
                            ColumnWith = 300,
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
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Integer,
                            Alignment = HorzAlignment.Far,
                            ToolTip = "Thời gian sử dụng"
                        },
                        new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "UsedDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "State", ColumnVisible = false},
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
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetNumericFormatControl(_gridLookUpEditFixedAssetView, true);
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

        protected void InitGridMain()
        {
            var paymentDeposit = new List<FixedAssetDecrementModel>
            {
                new FixedAssetDecrementModel {CurrencyCode = "USD", ExchangeRate = 1}
            };
            grdMaster.DataSource = paymentDeposit;
            gridViewMaster.PopulateColumns(new List<FixedAssetDecrementModel>());
            gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
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
                new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Loại tiền tệ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 20,
                    Alignment = HorzAlignment.Center,
                    RepositoryControl = _cboCurrencyCode
                },
                new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnCaption = "Tỷ giá",
                    ColumnWith = 20,
                    ColumnPosition = 3,
                    RepositoryControl = _calcEditExchangeRate
                },
                new XtraColumn
                {
                    ColumnName = "FixedAssetDecrementDetails",
                    ColumnVisible = false,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnCaption = "Tỉ giá",
                    ColumnWith = 20
                },
                new XtraColumn {ColumnName = "TotalAmountOC", ColumnVisible = false},
                new XtraColumn {ColumnName = "JournalMemo", ColumnVisible = false},
                new XtraColumn {ColumnName = "TotalAmountExchange", ColumnVisible = false},
                new XtraColumn {ColumnName = "DocumentInclude", ColumnVisible = false},
                new XtraColumn {ColumnName = "Trader", ColumnVisible = false},
                new XtraColumn {ColumnName = "BankId", ColumnVisible = false}
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
                    gridViewMaster.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                }
                else
                {
                    gridViewMaster.Columns[column.ColumnName].Visible = false;
                }
            }
            _calcEditExchangeRate.ReadOnly = true;
        }

        protected override void InitData()
        {
            base.InitData();

            if (CurrencyLocal == CurrencyAccounting)
                _cboCurrencyCode.Items.Add(CurrencyLocal);
            else
            {
                _cboCurrencyCode.Items.Add(CurrencyLocal);
                _cboCurrencyCode.Items.Add(CurrencyAccounting);
            }

            InitGridMain();
            if (GlobalVariable.IsPostToParentAccount)
                _accountsPresenter.DisplayActive();
            else
                _accountsPresenter.Display(true);

            _fixedAssetsPresenter.Display();

            if (MasterBindingSource.Current != null)
            {
                long refId = ((FixedAssetDecrementModel)MasterBindingSource.Current).RefId;
                KeyValue = refId.ToString(CultureInfo.InvariantCulture); _keyForSend = KeyValue;
            }
            else
            {
                _keyForSend = RefId.ToString();
            }

            if (int.Parse(KeyValue) != 0)
            {
                _fixedAssetDecrementPresenter.Display(long.Parse(KeyValue));
                if (AccountingObjectType != null)
                    LoadComboObjectCode(AccountingObjectType == null ? -1 : (int)AccountingObjectType);
            }
            else
            {
                RefId = 0;
                KeyValue = null;
                FixedAssetDecrementDetails = new List<FixedAssetDecrementDetailModel>();
                FixedAssetDecrementDetailParallels = new List<FixedAssetDecrementDetailParallelModel>();
                cboObjectCode.EditValue = null;
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                AccountingObjectType = -1;
                //cboObjectCode.Enabled = false;
                cboObjectCode.Properties.ReadOnly = true;
                txtDocumentInclude.Properties.ReadOnly = false;
                //ExchangeRate = 1;
                //CurrencyCode = "USD";
            }
            if (ActionMode == ActionModeVoucherEnum.None)
                txtDocumentInclude.Properties.ReadOnly = true;
        }

        protected override void InitControls()
        {
            cboObjectCode.ForceInitialize();
            cboObjectCode.Focus();

            #region MergerFund

            _gridLookUpEditMergerFundView = new GridView();
            _gridLookUpEditMergerFundView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditMergerFund = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditMergerFundView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(700, 200),
                ShowFooter = false
            };
            _gridLookUpEditMergerFund.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditMergerFund.View.BestFitColumns();
            _gridLookUpEditMergerFund.View.OptionsView.ShowIndicator = false;

            #endregion

            //#region VoucherType

            //_gridLookUpEditVoucherTypeView = new GridView();
            //_gridLookUpEditVoucherType = new RepositoryItemGridLookUpEdit
            //{
            //    NullText = "",
            //    View = _gridLookUpEditVoucherTypeView,
            //    TextEditStyle = TextEditStyles.Standard,
            //    PopupResizeMode = ResizeMode.FrameResize,
            //    PopupFormSize = new Size(150, 200),
            //    ShowFooter = false
            //};
            //_gridLookUpEditVoucherType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            //_gridLookUpEditVoucherType.View.BestFitColumns();
            //_gridLookUpEditVoucherType.View.OptionsView.ShowColumnHeaders = false;
            //_gridLookUpEditVoucherType.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
            //_gridLookUpEditVoucherType.View.OptionsView.ShowIndicator = false;

            //_gridLookUpEditVoucherType.KeyDown += _gridLookUpEditVoucherTypeView_KeyDown;

            //#endregion

            #region CurrencyCode

            _cboCurrencyCode = new RepositoryItemComboBox();

            #endregion

            #region FixedAsset

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

            #endregion

            #region Exchange rate

            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.EditFormat.FormatType = FormatType.Numeric;
            _calcEditExchangeRate.EditMask = @"c" + new GlobalVariable().ExchangeRateDecimalDigits;
            _calcEditExchangeRate.Mask.UseMaskAsDisplayFormat = true;

            #endregion
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
            {
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
                cboCurrency_EditValueChanged(null, null);
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;
            txtDocumentInclude.Properties.ReadOnly = true;
            //return _fixedAssetDecrementPresenter.Save();
            var resultDetailParallels = new DialogResult();
            if (FixedAssetDecrementDetailParallels.Count > 0)
            {
                resultDetailParallels = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelUpdateQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                resultDetailParallels = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            var result = resultDetailParallels == DialogResult.OK ? _fixedAssetDecrementPresenter.Save(true) : _fixedAssetDecrementPresenter.Save(false);
            if (result > 0)
                _fixedAssetDecrementPresenter.Display(result);
            return result;
        }

        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new FixedAssetDecrementPresenter(null).Delete(refId);
        }

        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            var currencyCode = CurrencyCode; //(string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");

            // Object
            //bool flag = true;
            //switch (AccountingObjectType)
            //{
            //    case 0: // nhà cung cấp
            //        if (VendorId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVendorId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    case 1: // Nhân viên
            //        if (EmployeeId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    case 2: // Ðối tượng khác
            //        if (AccountingObjectId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    case 3: //Khác hàng
            //        if (CustomerId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCustomerId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    default:
            //        if (AccountingObjectType == null)
            //        {
            //            XtraMessageBox.Show("Bạn chưa chọn loại đối tượng!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCategory.Focus();
            //            flag = false;
            //        }
            //        break;
            //}
            //if (!flag)
            //{
            //    return false;
            //}

            if (FixedAssetDecrementDetails == null || FixedAssetDecrementDetails.Count <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyFADecrementDetail"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
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
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPResEmptyVoucherBudgetSourceCodeostDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }
            if (AccountingObjectType != null && cboObjectCode.EditValue == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("RestObjectCode"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (FixedAssetDecrementDetails.Count > 0)
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (FixedAssetDecrementDetailModel fixedAssetDecrementDetail in FixedAssetDecrementDetails)
                {
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(fixedAssetDecrementDetail))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (fixedAssetDecrementDetail.AmountOC == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var accountNumber = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(fixedAssetDecrementDetail.AccountNumber);
                    var correspondingAccountNumber = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(fixedAssetDecrementDetail.CorrespondingAccountNumber);

                    if ((fixedAssetDecrementDetail.VoucherTypeId == 2 || fixedAssetDecrementDetail.VoucherTypeId == 3 || fixedAssetDecrementDetail.VoucherTypeId == 12) && ExchangeRate == 1 && CurrencyCode != "USD")
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckExchangeRate"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (fixedAssetDecrementDetail.AccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (fixedAssetDecrementDetail.CorrespondingAccountNumber == null)
                    {
                        XtraMessageBox.Show("Tài khoản đối ứng không được để trống!",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (accountNumber.IsCurrency && accountNumber.CurrencyCode != currencyCode &&
                        accountNumber.CurrencyCode != null)
                    {
                        XtraMessageBox.Show(
                            string.Format(ResourceHelper.GetResourceValueByName("ResDiffereneCurrencyCode"),
                                fixedAssetDecrementDetail.AccountNumber, accountNumber.CurrencyCode, currencyCode),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (correspondingAccountNumber.IsCurrency && correspondingAccountNumber.CurrencyCode != currencyCode &&
                        correspondingAccountNumber.CurrencyCode != null)
                    {
                        XtraMessageBox.Show(
                            string.Format(ResourceHelper.GetResourceValueByName("ResDiffereneCurrencyCode"),
                                fixedAssetDecrementDetail.CorrespondingAccountNumber,
                                correspondingAccountNumber.CurrencyCode, currencyCode),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    bool isDetailValid = true;
                    if (fixedAssetDecrementDetail.DetailBy != null)
                    {
                        string[] detailFieldNames = fixedAssetDecrementDetail.DetailBy.Split(';');
                        //Mã đối tượng từ phần master vào detail nên không cần kiểm tra chi tiết theo đối tượng
                        if (
                            detailFieldNames.Any(
                                t =>
                                    fixedAssetDecrementDetail.GetType().GetProperty(t) != null &&
                                    fixedAssetDecrementDetail.GetType().GetProperty(t).Name != "AccountingObjectId" &&
                                    fixedAssetDecrementDetail[t] != null))
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

                    if (fixedAssetDecrementDetail.AccountNumber.StartsWith("111") || fixedAssetDecrementDetail.CorrespondingAccountNumber.StartsWith("111"))
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
                    var budgetSourceCode = fixedAssetDecrementDetail.BudgetSourceCode;
                    decimal totalAmount;// tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if (fixedAssetDecrementDetail.CorrespondingAccountNumber.Substring(0, 3) == "111")
                    {
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = FixedAssetDecrementDetails.Where(x => x.CorrespondingAccountNumber.Substring(0, 3) == "111").Sum(x => x.AmountOC);
                            GetCalculateCashBalance(fixedAssetDecrementDetail.CorrespondingAccountNumber, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year);// thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi số dư tiền gửi âm
                    if (fixedAssetDecrementDetail.CorrespondingAccountNumber.Substring(0, 3) == "112")
                    {
                        if (!DBOptionHelper.IsDepositeNegavtiveFund)
                        {
                            totalAmount = FixedAssetDecrementDetails.Where(x =>
                                x.CorrespondingAccountNumber.Substring(0, 3) == "112")
                                .Sum(x => x.AmountOC);
                            GetCalculateDepositBalance(fixedAssetDecrementDetail.CorrespondingAccountNumber,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi nguồn âm
                    if (fixedAssetDecrementDetail.AccountNumber.Substring(0, 3) == "461" ||
                        fixedAssetDecrementDetail.AccountNumber.Substring(0, 3) == "661")
                    {
                        if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
                        {
                            // Số dư Có TK 4612
                            GetCalculateCapitalBalance("4612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            var accountBalance = ClosingAmount;

                            // Số dư Nợ TK 4612
                            GetCalculateCapitalBalance("6612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            accountBalance = accountBalance - ClosingAmount;

                            totalAmount = FixedAssetDecrementDetails.Where(x =>
                                x.BudgetSourceCode == budgetSourceCode &&
                                (x.AccountNumber.Substring(0, 3) == "461" || x.AccountNumber.Substring(0, 3) == "661"))
                                .Sum(x => x.AmountOC);
                            if (totalAmount > accountBalance)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    #endregion

                    i++;
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

        public FrmXtraFormFADecrementDetail()
        {
            InitializeComponent(); ;

            _fixedAssetDecrementPresenter = new FixedAssetDecrementPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
        }

        private void FrmXtraFormFADecrementDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, false);

            this.gridViewDetail.InitNewRow += gridViewDetail_InitNewRow;
            this.gridViewDetail.CellValueChanged += gridViewDetail_CellValueChanged;
            this.gridViewMaster.RowUpdated += gridViewMaster_RowUpdated;
            this.gridViewMaster.CellValueChanged += gridViewMaster_CellValueChanged;
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

        private void FrmXtraFormFADecrementDetail_Resize(object sender, EventArgs e)
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
                //var quantityCol = gridViewDetail.Columns["Quantity"];
                //var quantity = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);

                //if (quantity < 0)
                //{
                //    e.Valid = false;
                //    gridViewDetail.SetColumnError(quantityCol,
                //                                  ResourceHelper.GetResourceValueByName("ResFADecrementDetailQuantity"));
                //}
                //if (quantity > _maxQuantity)
                //{
                //    e.Valid = false;
                //    gridViewDetail.SetColumnError(quantityCol, "Ghi giảm quá số lượng còn lại");
                //}
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
                GridColumn quantityCol = gridViewDetail.Columns["Quantity"];
                GridColumn accountNumberCol = gridViewDetail.Columns["AccountNumber"];
                GridColumn correspondingAccountNumberCol = gridViewDetail.Columns["CorrespondingAccountNumber"];

                gridViewDetail.SetRowCellValue(e.RowHandle, quantityCol, 1);
                gridViewDetail.SetRowCellValue(e.RowHandle, accountNumberCol, "2141");
                gridViewDetail.SetRowCellValue(e.RowHandle, correspondingAccountNumberCol, "211");
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
                        GridColumn budgetSourceCodeCol = gridViewDetail.Columns["BudgetSourceCode"];
                        GridColumn budgetItemCodeCol = gridViewDetail.Columns["BudgetItemCode"];

                        var currencyCodeCol = CurrencyCode;
                        if ((int)e.Value > 0)
                        {
                            var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                            gridViewDetail.SetRowCellValue(e.RowHandle, descriptionCol, "Ghi giảm tài sản " + fixedAsset.FixedAssetCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, currencyCodeCol, fixedAsset.CurrencyCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, quantityCol, fixedAsset.Quantity);
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceColOC, fixedAsset.UnitPrice);
                            gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceColExchange, fixedAsset.UnitPriceUSD);
                            gridViewDetail.SetRowCellValue(e.RowHandle, dDepartmentIdCol, fixedAsset.DepartmentId);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountOCCol, fixedAsset.OrgPrice);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, fixedAsset.OrgPriceUSD);
                            gridViewDetail.SetRowCellValue(e.RowHandle, budgetSourceCodeCol, fixedAsset.BudgetSourceCode);
                            gridViewDetail.SetRowCellValue(e.RowHandle, budgetItemCodeCol, fixedAsset.BudgetItemCode);
                        }
                        break;

                    case "Quantity":
                        quantityCol = gridViewDetail.Columns["Quantity"];
                        amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        amountOCCol = gridViewDetail.Columns["AmountOC"];
                        GridColumn unitPriceOCCol = gridViewDetail.Columns["UnitPriceOC"];
                        GridColumn unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];
                        var quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        var unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);
                        var unitPriceExchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceExchangeCol);

                        gridViewDetail.SetRowCellValue(e.RowHandle, amountOCCol, quantity * unitPriceOC);
                        gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceExchange);

                        break;

                    case "UnitPriceOC":
                        quantityCol = gridViewDetail.Columns["Quantity"];
                        amountOCCol = gridViewDetail.Columns["AmountOC"];
                        amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                        unitPriceOCCol = gridViewDetail.Columns["UnitPriceOC"];
                        unitPriceExchangeCol = gridViewDetail.Columns["UnitPriceExchange"];
                        //exchangeRateCol = gridViewMaster.Columns["ExchangeRate"];

                        quantity = (int)gridViewDetail.GetRowCellValue(e.RowHandle, quantityCol);
                        var exchangeRate = ExchangeRate; //(decimal)gridViewMaster.GetFocusedRowCellValue(exchangeRateCol);
                        unitPriceOC = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceOCCol);

                        gridViewDetail.SetRowCellValue(e.RowHandle, amountOCCol, quantity * unitPriceOC);
                        gridViewDetail.SetRowCellValue(e.RowHandle, unitPriceExchangeCol, unitPriceOC / exchangeRate);

                        unitPriceExchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, unitPriceExchangeCol);
                        gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, quantity * unitPriceExchange);

                        break;

                    case "AmountOC":
                        if ((decimal)e.Value > 0)
                        {
                            amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                            //exchangeRateCol = gridViewMaster.Columns["ExchangeRate"];
                            exchangeRate = ExchangeRate; //(decimal)gridViewMaster.GetFocusedRowCellValue(exchangeRateCol);
                            if (exchangeRate > 0)
                                gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, (decimal)e.Value / exchangeRate);
                        }
                        break;

                    case "ExchangeRate":
                        if (decimal.Parse(e.Value.ToString().Replace(".", ",")) > 0)
                        {
                            amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                            amountOCCol = gridViewDetail.Columns["AmountOC"];
                            var amount = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountOCCol);

                            if (amount > 0)
                                gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, amount / decimal.Parse(e.Value.ToString().Replace(".", ",")));
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
                    object accountNumber = gridViewDetail.GetFocusedRowCellValue("AccountNumber");
                    string accountNumberDetailBy = "";
                    if (accountNumber != null)
                    {
                        accountNumberDetailBy = GetAccountDetailBy(accountNumber.ToString());
                    }
                    object correspondingAccountNumber = gridViewDetail.GetFocusedRowCellValue("CorrespondingAccountNumber");
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
                    detail = !string.IsNullOrEmpty(detail) ? detail + ";ExchangeRate" : detail + "ExchangeRate";
                    gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", detail);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void gridViewMaster_RowUpdated(object sender, RowObjectEventArgs e)
        {
            //var currency = (string)gridViewMaster.GetFocusedRowCellValue("CurrencyCode");
            //var exchangeRate = (decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
            //if (currency.Equals("USD"))
            //{
            //    gridViewMaster.SetRowCellValue(e.RowHandle, "ExchangeRate", 1);
            //}
            //else
            //{
            //    if (exchangeRate != 1)
            //    {
            //        IList<FixedAssetDecrementDetailModel> fixedAssetDecrementDetails = FixedAssetDecrementDetails;
            //        var exchangRate = (decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
            //        if (exchangRate > 0 && fixedAssetDecrementDetails.Count > 0)
            //        {
            //            for (int i = 0; i < FixedAssetDecrementDetails.Count; i++)
            //            {
            //                if (FixedAssetDecrementDetails[i].AmountOC > 0)
            //                {
            //                    gridViewDetail.SetRowCellValue(i, "AmountExchange",
            //                        FixedAssetDecrementDetails[i].AmountOC / exchangRate);
            //                    gridViewDetail.SetRowCellValue(i, "UnitPriceExchange",
            //                        FixedAssetDecrementDetails[i].UnitPriceOC / exchangRate);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void gridViewMaster_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            gridViewMaster.PostEditor();
            if (e.Column.FieldName.Equals("ExchangeRate"))
            {
                IList<FixedAssetDecrementDetailModel> fixedAssetDecrementDetails = FixedAssetDecrementDetails;
                var exchangRate = (decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
                if (exchangRate > 0 && fixedAssetDecrementDetails.Count > 0)
                {
                    for (int i = 0; i < FixedAssetDecrementDetails.Count; i++)
                    {
                        if (FixedAssetDecrementDetails[i].AmountOC > 0)
                        {
                            gridViewDetail.SetRowCellValue(i, "AmountExchange",
                                FixedAssetDecrementDetails[i].AmountOC / exchangRate);
                            gridViewDetail.SetRowCellValue(i, "UnitPriceExchange",
                                FixedAssetDecrementDetails[i].UnitPriceOC / exchangRate);
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
                    _calcEditExchangeRate.ReadOnly = true;
                }
                else
                {
                    _calcEditExchangeRate.ReadOnly = false;
                }
            }
        }

        #endregion

        #region Repository Keydown Event

        private void _gridLookUpEditVoucherTypeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn voucherTypeId = gridViewDetail.Columns["VoucherTypeId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, voucherTypeId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn budgetSourceCode = gridViewDetail.Columns["BudgetSourceCode"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        private void _gridLookUpEditBudgetItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn budgetItemCode = gridViewDetail.Columns["BudgetItemCode"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, budgetItemCode, null);
            e.Handled = true;
        }

        private void _gridLookUpEditProjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn projectId = gridViewDetail.Columns["ProjectId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, projectId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditDepartmentView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn departmentId = gridViewDetail.Columns["DepartmentId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, departmentId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditAutoBusinessView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn autoBusinessId = gridViewDetail.Columns["AutoBusinessId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, autoBusinessId, 0);
            e.Handled = true;
        }

        private void _gridLookUpEditFixedAssetView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            GridColumn fixedAssetId = gridViewDetail.Columns["FixedAssetId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, fixedAssetId, 0);
            e.Handled = true;
        }

        #endregion
    }
}