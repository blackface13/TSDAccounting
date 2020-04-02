/***********************************************************************
 * <copyright file="FrmXtraFormFAArmortizationDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
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
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetArmortization;
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


namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// FrmXtraFormFAArmortizationDetail
    /// </summary>
    public partial class FrmXtraFormFAArmortizationDetail : FrmXtraBaseVoucherDetail, IFixedAssetArmortizationView, IFixedAssetsView, IAccountsView, IDepartmentsView,
        IVoucherTypesView, IBudgetSourcesView, IBudgetItemsView, IProjectsView
    {
        #region Presenter

        private readonly FixedAssetArmortizationPresenter _fixedAssetArmortizationPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private List<FixedAssetModel> _fixedAssetModels;

        #endregion

        #region Repository Controls

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;

        private RepositoryItemComboBox _cboCurrencyCode;
        private RepositoryItemCalcEdit _calcEditExchangeRate;

        #endregion

        #region FixedAssetArmortization Members

        public long RefId { get; set; }

        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.EditValue = value; }
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

        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType)value : BaseRefTypeId; }
        }

        public string JournalMemo
        {
            get { return memoJournalMemo.Text; }
            set
            {
                memoJournalMemo.Text = ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher ?
                    "Hao mòn tài sản cố định năm " + BasePostedDate.Year : value;
            }
        }

        public string CurrencyCode { get; set; }

        public decimal TotalAmountExchange { get; set; }

        public decimal TotalAmountOC { get; set; }

        public IList<FixedAssetArmortizationDetailModel> FixedAssetArmortizationDetails
        {
            get
            {
                var fixedAssetArmortizations = new List<FixedAssetArmortizationDetailModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            fixedAssetArmortizations.Add(new FixedAssetArmortizationDetailModel
                            {
                                FixedAssetId = (int)gridViewDetail.GetRowCellValue(i, "FixedAssetId"),
                                AccountNumber = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber"),
                                CorrespondingAccountNumber = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber"),
                                Description = (string)gridViewDetail.GetRowCellValue(i, "Description"),
                                Quantity = (int)gridViewDetail.GetRowCellValue(i, "Quantity"),
                                ExchangeRate = (double)gridViewDetail.GetRowCellValue(i, "ExchangeRate"),
                                AmountOC = (decimal)gridViewDetail.GetRowCellValue(i, "AmountOC"),
                                AmountExchange = (decimal)gridViewDetail.GetRowCellValue(i, "AmountExchange"),
                                VoucherTypeId = gridViewDetail.GetRowCellValue(i, "VoucherTypeId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "VoucherTypeId"),
                                BudgetSourceCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetSourceCode"),
                                CurrencyCode = (string)gridViewDetail.GetRowCellValue(i, "CurrencyCode"),
                                BudgetItemCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemCode"),
                                BudgetChapterCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetChapterCode"),
                                BudgetCategoryCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetCategoryCode"),
                                DepartmentId = gridViewDetail.GetRowCellValue(i, "DepartmentId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "DepartmentId"),
                                //ProjectId = gridViewDetail.GetRowCellValue(i, "ProjectId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "ProjectId"),
                                DetailBy = gridViewDetail.GetRowCellValue(i, "DetailBy") == null ? null : gridViewDetail.GetRowCellValue(i, "DetailBy").ToString()
                            });
                        }
                    }
                }
                return fixedAssetArmortizations.ToList();
            }
            set
            {
                bindingSourceDetail.DataSource = value ?? new List<FixedAssetArmortizationDetailModel>();
                gridViewDetail.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK Tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Định khoản tự động", Alignment = HorzAlignment.Center, RepositoryControl = _rpsAutoBusiness });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.Left, ToolTip = "Mã số tài sản cố định", RepositoryControl = _gridLookUpEditFixedAsset });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, ToolTip = "Tài khoản nợ", RepositoryControl = _rpsAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, ToolTip = "Tài khoản có", RepositoryControl = _rpsCorrespondingAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 170, FixedColumn = FixedStyle.Left, IsSummaryText = true });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.None, RepositoryControl = _rpsCurrency });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.None, RepositoryControl = _calcEditExchangeRate });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Quy đổi", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _rpsVoucherTypeId });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _rpsBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _rpsBudgetSource });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _rpsProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _rpsDepartment });

                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        #endregion

        #region Combobox Members

        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAsset.DataSource = value;
                    _fixedAssetModels = value.ToList();
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "FixedAssetCode", ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100,  Alignment = HorzAlignment.Near },
                            new XtraColumn {ColumnName = "FixedAssetName", ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Near },
                            new XtraColumn {ColumnName = "OrgPrice", ColumnCaption = "Nguyên giá", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far },
                            new XtraColumn {ColumnName = "LifeTime", ColumnCaption = "Thời gian SD", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Integer, Alignment = HorzAlignment.Far, ToolTip = "Thời gian sử dụng" },
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
                            new XtraColumn { ColumnName = "RemainingOrgPrice", ColumnVisible = false },
                            new XtraColumn { ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false },
                            new XtraColumn { ColumnName = "FixedAssetCurrencies", ColumnVisible = false },
                            new XtraColumn { ColumnName = "NumberOfFloor", ColumnVisible = false },
                            new XtraColumn { ColumnName = "AreaOfBuilding", ColumnVisible = false },
                            new XtraColumn { ColumnName = "AreaOfFloor", ColumnVisible = false },
                            new XtraColumn { ColumnName = "WorkingArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "AdministrationArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "HousingArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "VacancyArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "OccupiedArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "LeasingArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "GuestHouseArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "OtherArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "NumberOfSeat", ColumnVisible = false },
                            new XtraColumn { ColumnName = "ControlPlate", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsStateManagement", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsBussiness", ColumnVisible = false },
                            new XtraColumn { ColumnName = "Address", ColumnVisible = false },
                            new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ManagementCar", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsEstimateEmployee", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Brand", ColumnVisible = false}
                        };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetNumericFormatControl(_gridLookUpEditFixedAssetView, true);
            }
        }

        #endregion

        #region Override functions

        protected override void InitControls()
        {
            //RepositoryItemGridLookUpEdit FixedAsset
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

            //RepositoryItemComboBox CorrespondingAccountNumber
            _cboCurrencyCode = new RepositoryItemComboBox();

            //RepositoryItemCalcEdit ExchangeRate
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.EditFormat.FormatType = FormatType.Numeric;
            _calcEditExchangeRate.EditMask = @"c" + new GlobalVariable().ExchangeRateDecimalDigits;
            _calcEditExchangeRate.Mask.UseMaskAsDisplayFormat = true;

            if (ActionMode == ActionModeVoucherEnum.None)
            {
                btnAutoGenerateByUSD.Enabled = false;
                btnAutoGenerate.Enabled = false;
            }
            else
            {
                if (CurrencyAccounting == "USD" && CurrencyLocal == "USD")
                    btnAutoGenerate.Enabled = false;
                else if (CurrencyAccounting != "USD" && CurrencyLocal != "USD" && CurrencyAccounting == CurrencyLocal)
                    btnAutoGenerateByUSD.Enabled = false;
            }
        }

        protected override void InitData()
        {
            base.InitData();

            if (MasterBindingSource.Current != null)
            {
                var fixedAssetArmortizationId = ((FixedAssetArmortizationModel)MasterBindingSource.Current).RefId;
                KeyValue = fixedAssetArmortizationId.ToString(CultureInfo.InvariantCulture);
                _keyForSend = KeyValue;
                RefId = long.Parse(KeyValue);
            }
            else
            {
                _keyForSend = RefID.ToString();
            }

            _fixedAssetsPresenter.DisplayByActiveWithFixedAssetCurrency(false);

            _budgetItemsPrensenter.Display(3, true);

            _cboCurrencyCode.Items.Add(CurrencyLocal);
            if (CurrencyLocal != CurrencyAccounting)
                _cboCurrencyCode.Items.Add(CurrencyAccounting);

            _fixedAssetArmortizationPresenter.Display(long.Parse(KeyValue));
            CurrencyCode = CurrencyLocal;
            cboCurrency.EditValue = CurrencyLocal;
        }

        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            var endDateOfYear = DateTime.Parse("31/12/" + BasePostedDate.Year);
            if (string.IsNullOrEmpty(RefNo) || RefNo.Equals(""))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFAArmortizationRefNo"),
                           ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (!BasePostedDate.ToShortDateString().Equals(endDateOfYear.ToShortDateString()))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFAArmortizationEndDateOfYear"),
                          ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (FixedAssetArmortizationDetails == null || FixedAssetArmortizationDetails.Count <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFAArmortizationDetails"),
                             ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            //LinhMC comment
            //var sameFixedAssetId = false;
            //for (var i = 0; i < FixedAssetArmortizationDetails.Count; i++)
            //{
            //    for (var j = i + 1; j < FixedAssetArmortizationDetails.Count; j++)
            //    {
            //        if (FixedAssetArmortizationDetails[i].FixedAssetId == FixedAssetArmortizationDetails[j].FixedAssetId)
            //        {
            //            sameFixedAssetId = true;
            //            break;
            //        }
            //    }
            //    if (!sameFixedAssetId) continue;
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSameFAArmortizationDetails"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //                        MessageBoxIcon.Error);
            //    return false;
            //}

            //if (FixedAssetArmortizationDetails.GroupBy(n => n.FixedAssetId).Any(c => c.Count() > 1))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSameFAArmortizationDetails"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //                        MessageBoxIcon.Error);
            //    return false;
            //}

            int i = 0;
            var lstRowAmounts = new List<string>();
            foreach (var fixedAssetArmortizationDetail in FixedAssetArmortizationDetails)
            {
                // bắt lỗi thiếu thông tin trong tài khoản
                if (!ValidAccountDetail(fixedAssetArmortizationDetail))
                {
                    //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (fixedAssetArmortizationDetail.AmountOC == 0)
                    lstRowAmounts.Add((i + 1).ToString());
                if (fixedAssetArmortizationDetail.AccountNumber == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"),
                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    return false;
                }

                if (fixedAssetArmortizationDetail.CorrespondingAccountNumber == null)
                {
                    XtraMessageBox.Show("Tài khoản đối ứng không được để trống!",
                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    return false;
                }

                var isDetailValid = true;
                if (fixedAssetArmortizationDetail.DetailBy != null)
                {
                    var detailFieldNames = fixedAssetArmortizationDetail.DetailBy.Split(';');
                    detailFieldNames = detailFieldNames.Where(w => !w.Contains("ProjectId")).ToArray();
                    if (detailFieldNames.Any(t => fixedAssetArmortizationDetail.GetType().GetProperty(t) != null && fixedAssetArmortizationDetail.GetType().GetProperty(t).Name != "AccountingObjectId" && fixedAssetArmortizationDetail[t] != null))
                    {
                        isDetailValid = false;
                    }
                    if (!isDetailValid)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                i++;
            }
            if (lstRowAmounts.Count > 0)
                if (DialogResult.No == XtraMessageBox.Show("Số tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
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

            cboCurrency.EditValue = CurrencyCode;
            GeneratedBaseRefNo();

            return _fixedAssetArmortizationPresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            _fixedAssetArmortizationPresenter.Delete(refId);
        }

        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupObject, isEnable);
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                btnAutoGenerateByUSD.Enabled = false;
                btnAutoGenerate.Enabled = false;
            }
            else
            {
                btnAutoGenerateByUSD.Enabled = true;
                btnAutoGenerate.Enabled = true;
            }
        }

        #endregion

        #region Events

        public FrmXtraFormFAArmortizationDetail()
        {
            InitializeComponent();
            _fixedAssetArmortizationPresenter = new FixedAssetArmortizationPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
        }

        private void gridViewDetail_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridColumn exchangeRateCol;
                var amountExchangeCol = gridViewDetail.Columns["AmountExchange"];
                var amountCol = gridViewDetail.Columns["AmountOC"];
                var currencyCodeCol = gridViewDetail.Columns["CurrencyCode"];

                switch (e.Column.FieldName)
                {
                    case "FixedAssetId":
                        var descriptionCol = gridViewDetail.Columns["Description"];
                        var departmentIdCol = gridViewDetail.Columns["DepartmentId"];
                        exchangeRateCol = gridViewDetail.Columns["ExchangeRate"];

                        if ((int)e.Value > 0)
                        {
                            var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                            gridViewDetail.SetRowCellValue(e.RowHandle, descriptionCol, "Hao mòn " + fixedAsset.FixedAssetCode + ", năm " + (DateTime.Parse(PostedDate)).Year);
                            gridViewDetail.SetRowCellValue(e.RowHandle, exchangeRateCol, "1");
                            gridViewDetail.SetRowCellValue(e.RowHandle, departmentIdCol, fixedAsset.DepartmentId);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, fixedAsset.AnnualDepreciationAmountUSD);
                            gridViewDetail.SetRowCellValue(e.RowHandle, amountCol, fixedAsset.AnnualDepreciationAmount);
                            gridViewDetail.SetRowCellValue(e.RowHandle, currencyCodeCol, fixedAsset.FixedAssetCurrencies.Count > 1 ? "USD" : fixedAsset.FixedAssetCurrencies[0].CurrencyCode);
                        }
                        break;

                    case "AmountOC":
                        if ((decimal)e.Value > 0)
                        {
                            exchangeRateCol = gridViewDetail.Columns["ExchangeRate"];
                            var exchangeRate = decimal.Parse(gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString());

                            if (exchangeRate > 0)
                                gridViewDetail.SetRowCellValue(e.RowHandle, amountExchangeCol, (decimal)e.Value / exchangeRate);

                            // Gán lại giá trị dòng 2 khi thay đổi dòng 1 (cùng mã tài sản).
                            var gridView = sender as GridView;
                            if (gridView != null)
                            {
                                var fixedAssetArmortizationDetail = (FixedAssetArmortizationDetailModel)gridView.GetFocusedRow();
                                if (fixedAssetArmortizationDetail != null)
                                {
                                    for (int i = 0; i < gridViewDetail.RowCount; i++)
                                    {
                                        var objectValues = gridViewDetail.GetRowCellValue(i, "FixedAssetId");
                                        var objectAmountOc = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, amountCol));

                                        if (objectValues != null && objectValues.Equals(fixedAssetArmortizationDetail.FixedAssetId) && objectAmountOc != fixedAssetArmortizationDetail.AmountOC)
                                        {
                                            gridViewDetail.SetRowCellValue(i, amountCol, fixedAssetArmortizationDetail.AmountOC);
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case "ExchangeRate":
                        if (decimal.Parse(e.Value.ToString().Replace(".", ",")) > 0)
                        {
                            var amount = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountCol);
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
                }

                //--------LinhMC: valid detail by account in Griddetail voucher---------// 
                if (!e.Column.FieldName.Equals("DetailBy"))
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

                    accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy) ? correspondingAccountNumberDetailBy : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    //Bổ sung thêm 2 trường Quantity và ExchangeRate
                    detail = !string.IsNullOrEmpty(detail) ? detail + ";Quantity;ExchangeRate" : detail + "Quantity;ExchangeRate";
                    gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", detail);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridViewDetail_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var quantityCol = gridViewDetail.Columns["Quantity"];
                var accountNumberCol = gridViewDetail.Columns["AccountNumber"];
                var correspondingAccountNumberCol = gridViewDetail.Columns["CorrespondingAccountNumber"];
                gridViewDetail.SetRowCellValue(e.RowHandle, quantityCol, 1);
                gridViewDetail.SetRowCellValue(e.RowHandle, accountNumberCol, "466");
                gridViewDetail.SetRowCellValue(e.RowHandle, correspondingAccountNumberCol, "2141");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAutoGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var endDateOfYear = DateTime.Parse("31/12/" + BasePostedDate.Year);
                if (!BasePostedDate.ToShortDateString().Equals(endDateOfYear.ToShortDateString()))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFAArmortizationEndDateOfYear"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRefNo.Focus();
                    return;
                }

                //bat xem da co chung tu nhap bang tay hay tu dong
                var fixedAssetArmortizations = _fixedAssetArmortizationPresenter.Display(endDateOfYear.ToShortDateString(), CurrencyLocal);
                if (fixedAssetArmortizations != null && fixedAssetArmortizations.Count > 0)
                {
                    XtraMessageBox.Show("Năm " + endDateOfYear.Year + " đã tồn tại chứng từ hao mòn, hao mòn theo tiền địa phương!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtRefDate.Focus();
                    return;
                }
                if (CurrencyLocal == "USD" && CurrencyAccounting == CurrencyLocal)
                {
                    XtraMessageBox.Show("Đơn vị chưa có phát sinh tài sản theo loại tiền này!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtRefDate.Focus();
                    return;
                }
                _fixedAssetArmortizationPresenter.Display(long.Parse(KeyValue), CurrencyLocal, ((DateTime)dtPostDate.EditValue).Year);
                CurrencyCode = CurrencyLocal;
                if (FixedAssetArmortizationDetails == null || FixedAssetArmortizationDetails.Count <= 0)
                {
                    XtraMessageBox.Show("Chưa có tài sản được ghi tăng hoặc tài sản đã hao mòn hết!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SaveVoucher();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception)
            {
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnAutoGenerateByUSD_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var endDateOfYear = DateTime.Parse("31/12/" + BasePostedDate.Year);
                if (!BasePostedDate.ToShortDateString().Equals(endDateOfYear.ToShortDateString()))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFAArmortizationEndDateOfYear"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRefNo.Focus();
                    return;
                }
                var fixedAssetArmortizations = _fixedAssetArmortizationPresenter.Display(endDateOfYear.ToShortDateString(), CurrencyAccounting);
                if (fixedAssetArmortizations != null && fixedAssetArmortizations.Count > 0)
                {
                    XtraMessageBox.Show("Năm " + endDateOfYear.Year + " đã tồn tại chứng từ hao mòn, hao mòn theo tiền đô la mỹ!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtRefDate.Focus();
                    return;
                }
                if (CurrencyLocal != "USD" && CurrencyAccounting == CurrencyLocal)
                {
                    XtraMessageBox.Show("Đơn vị chưa có phát sinh tài sản theo loại tiền này!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtRefDate.Focus();
                    return;
                }

                _fixedAssetArmortizationPresenter.Display(long.Parse(KeyValue), CurrencyAccounting, ((DateTime)dtPostDate.EditValue).Year);
                CurrencyCode = CurrencyAccounting;
                if (FixedAssetArmortizationDetails == null || FixedAssetArmortizationDetails.Count <= 0)
                {
                    XtraMessageBox.Show("Chưa có tài sản được ghi tăng hoặc tài sản đã hao mòn hết!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SaveVoucher();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception)
            {
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void _gridLookUpEditVoucherTypeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            var voucherTypeId = gridViewDetail.Columns["VoucherTypeId"];
            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, voucherTypeId, 0);
            e.Handled = true;
        }

        private void FrmXtraFormFAArmortizationDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);

            this.gridViewDetail.CellValueChanged += gridViewDetail_CellValueChanged;
        }

        private void FrmXtraFormFAArmortizationDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        #endregion
    }
}