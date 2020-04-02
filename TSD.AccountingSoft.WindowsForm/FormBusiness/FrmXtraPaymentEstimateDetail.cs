/***********************************************************************
 * <copyright file="FrmXtraPaymentEstimateDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
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
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Presenter.Estimate.PaymentEstimate;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateList;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSourceCategory;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.Session;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using DevExpress.XtraGrid.Views.BandedGrid;


namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// class FrmXtraPaymentEstimateDetail
    /// </summary>
    public partial class FrmXtraPaymentEstimateDetail : FrmXtraBaseVoucherDetail, IPaymentEstimateView, IPlanTemplateListsView, IPlanTemplateItemsView, IPaymentEstimatesView, IBudgetSourceCategoriesView
    {
        #region Presenters

        private readonly PaymentEstimatePresenter _paymentEstimatePresenter;
        private readonly PaymentEstimatesPresenter _paymentEstimatesPresenter;
        private readonly PlanTemplateListsPresenter _planTemplateListsPresenter;
        private readonly PlanTemplateItemsPresenter _planTemplateItemsPresenter;
        private readonly BudgetSourceCategoriesPresenter _budgetSourceCategoriesPresenter;
        private GridBand _budgetItemCodeBand;
        private GridBand _budgetItemNameBand;
        private GridBand _descriptionBand;
        private GridBand _previousYearOfEstimateBand;
        private GridBand _thisYearOfEstimateBand;
        private GridBand _nextYearOfEstimateBand;
        private GridBand _invisibleBand;
        private GridBand _thisYearOfReceiptEstimate;
        private GridBand _sixMonthBegining;
        private GridBand _sixMonthEnding;
        private GridBand _previousYearBalance;
        private GridBand _totalAmountThisYear;

        //LinhMC add
        private IList<PlanTemplateItemModel> _planTemplateItemsTemp;

        #endregion

        #region Payment estimate members

        public long RefId { get; set; }

        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType)value : BaseRefTypeId; }
        }

        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.EditValue = value; }
        }

        public string RefDate
        {
            get { return dtRefDate.EditValue == null ? null : dtRefDate.EditValue.ToString(); }
            set { dtRefDate.EditValue = DateTime.Parse(value); }
        }

        public string PostedDate
        {
            get { return dtPostDate.EditValue == null ? null : dtPostDate.EditValue.ToString(); }
            set { dtPostDate.EditValue = DateTime.Parse(value); }
        }

        public int PlanTemplateListId
        {
            get
            {
                if (grdlookUpEditPlanTemplateListId.EditValue == null) return 0;
                return (int)grdlookUpEditPlanTemplateListId.EditValue;
            }
            set
            {
                grdlookUpEditPlanTemplateListId.EditValue = value;
            }
        }

        public short YearOfPlaning
        {
            get
            {
                if (spnYearOfPlan.Value == 0) return 0;
                return (short)spnYearOfPlan.Value;
            }
            set
            {
                spnYearOfPlan.Value = value;
            }
        }

        public string CurrencyCode
        {
            get { return CurrencyAccounting; }
            set { }
        }

        public float ExchangeRate
        {
            get { return float.Parse(spnExchangeRate.Text); }
            set { spnExchangeRate.EditValue = ActionMode == ActionModeVoucherEnum.Edit ? value : 1; }
        }

        public decimal TotalEstimateAmount
        {
            get { return (PaymentEstimateDetails != null && PaymentEstimateDetails.Count > 0) ? PaymentEstimateDetails.Sum(s => s.YearOfEstimateAmount) : 0; }
            set { }
        }

        public decimal NextYearOfTotalEstimateAmount
        {
            get { return (PaymentEstimateDetails != null && PaymentEstimateDetails.Count > 0) ? PaymentEstimateDetails.Sum(s => s.TotalAmountThisYear):0; }
            set { }
        }

        public string JournalMemo
        {
            get { return memoJournalMemo.Text; }
            set { memoJournalMemo.Text = value; }
        }

        public int? BudgetSourceCategoryId
        {
            get
            {
                if (grdBudgetSourceCategoryID.EditValue == null || grdBudgetSourceCategoryID.EditValue.ToString().Trim() == string.Empty) return 0;
                return (int?)grdBudgetSourceCategoryID.EditValue;
            }
            set
            {
                grdBudgetSourceCategoryID.EditValue = value;
            }
        }

        public decimal ExchangeRateLastYear
        {
            get { return spinExchangeRateLastYear.EditValue == null ? 0 : Convert.ToDecimal(spinExchangeRateLastYear.EditValue); }
            set { spinExchangeRateLastYear.EditValue = value; }
        }

        public decimal ExchangeRateThisYear
        {
            get { return spinExchangeRateThisYear.EditValue == null ? 0 : Convert.ToDecimal(spinExchangeRateThisYear.EditValue); }
            set { spinExchangeRateThisYear.EditValue = value; }
        }

        public IList<PlanTemplateListModel> PlanTemplateLists
        {
            set
            {
                try
                {
                    grdlookUpEditPlanTemplateListId.Properties.DataSource = value.Where(x => x.PlanYear == DateTime.Parse(DBOptionHelper.PostedDate).Year + 1).ToList();
                    grdlookUpEditPlanTemplateListIdView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "PlanTemplateListId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "PlanTemplateListCode", ColumnCaption = "Mã mẫu dự toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130},
                            new XtraColumn {ColumnName = "PlanTemplateListName", ColumnCaption = "Tên mẫu dự toán", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 370},
                            new XtraColumn {ColumnName = "PlanType", ColumnVisible = false},
                            new XtraColumn {ColumnName = "PlanYear", ColumnCaption = "Năm dự toán", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center},
                            new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "PlanTemplateItems", ColumnVisible = false}
                        };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdlookUpEditPlanTemplateListIdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdlookUpEditPlanTemplateListIdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdlookUpEditPlanTemplateListIdView.Columns[column.ColumnName].Width = column.ColumnWith;
                            grdlookUpEditPlanTemplateListIdView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        }
                        else
                            grdlookUpEditPlanTemplateListIdView.Columns[column.ColumnName].Visible = false;
                    }
                    grdlookUpEditPlanTemplateListId.Properties.DisplayMember = "PlanTemplateListName";
                    grdlookUpEditPlanTemplateListId.Properties.ValueMember = "PlanTemplateListId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<EstimateDetailModel> PaymentEstimateDetails
        {
            get
            {
                return bindingSourceDetail.DataSource == null ? new List<EstimateDetailModel>() : (List<EstimateDetailModel>)bindingSourceDetail.DataSource;

                #region
                //var paymentEstimateDetail = new List<EstimateDetailModel>();
                //if (bandedGridViewDetail.DataSource != null && bandedGridViewDetail.RowCount > 0)
                //{
                //    for (var i = 0; i < bandedGridViewDetail.RowCount; i++)
                //    {
                //        if (bandedGridViewDetail.GetRow(i) != null)
                //        {
                //            paymentEstimateDetail.Add(new EstimateDetailModel
                //            {
                //                BudgetItemCode = (string)bandedGridViewDetail.GetRowCellValue(i, "BudgetItemCode"),
                //                BudgetItemName = (string)bandedGridViewDetail.GetRowCellValue(i, "BudgetItemName"),
                //                PreviousYearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(i, "PreviousYearOfEstimateAmount"),
                //                PreviousYearOfEstimateAmountUSD = (decimal)bandedGridViewDetail.GetRowCellValue(i, "PreviousYearOfEstimateAmountUSD"),
                //                TotalEstimateAmountUSD = (decimal)bandedGridViewDetail.GetRowCellValue(i, "TotalEstimateAmountUSD"),
                //                YearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(i, "YearOfEstimateAmount"),
                //                NextYearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(i, "NextYearOfEstimateAmount"),
                //                AutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "AutonomyBudget"),
                //                NonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "NonAutonomyBudget"),
                //                TotalNextYearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(i, "TotalNextYearOfEstimateAmount"),
                //                Description = (string)bandedGridViewDetail.GetRowCellValue(i, "Description"),
                //                PreviousYearOfAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "PreviousYearOfAutonomyBudget"),
                //                PreviousYearOfNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "PreviousYearOfNonAutonomyBudget"),
                //                YearOfAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "YearOfAutonomyBudget"),
                //                YearOfNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "YearOfNonAutonomyBudget"),
                //                SixMonthBeginingAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "SixMonthBeginingAutonomyBudget"),
                //                SixMonthBeginingNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "SixMonthBeginingNonAutonomyBudget"),
                //                TotalAmountSixMonthBegining = (decimal)bandedGridViewDetail.GetRowCellValue(i, "TotalAmountSixMonthBegining"),
                //                SixMonthEndingAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "SixMonthEndingAutonomyBudget"),
                //                SixMonthEndingNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "SixMonthEndingNonAutonomyBudget"),
                //                TotalAmountSixMonthEnding = (decimal)bandedGridViewDetail.GetRowCellValue(i, "TotalAmountSixMonthEnding"),
                //                PreviousYeaOfAutonomyBudgetBalance = (decimal)bandedGridViewDetail.GetRowCellValue(i, "PreviousYeaOfAutonomyBudgetBalance"),
                //                PreviousYeaOfNonAutonomyBudgetBalance = (decimal)bandedGridViewDetail.GetRowCellValue(i, "PreviousYeaOfNonAutonomyBudgetBalance"),
                //                TotalPreviousYearBalance = (decimal)bandedGridViewDetail.GetRowCellValue(i, "TotalPreviousYearBalance"),
                //                ThisYearOfAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "ThisYearOfAutonomyBudget"),
                //                ThisYearOfNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(i, "ThisYearOfNonAutonomyBudget"),
                //                TotalAmountThisYear = (decimal)bandedGridViewDetail.GetRowCellValue(i, "TotalAmountThisYear"),
                //                RefDetailId = (long)bandedGridViewDetail.GetRowCellValue(i, "RefDetailId"),
                //                IsInserted = (bool)bandedGridViewDetail.GetRowCellValue(i, "IsInserted"),
                //                ItemCodeList = (string)bandedGridViewDetail.GetRowCellValue(i, "ItemCodeList"),
                //                NumberOrder = (string)bandedGridViewDetail.GetRowCellValue(i, "NumberOrder"),
                //                FontStyle = (string)bandedGridViewDetail.GetRowCellValue(i, "FontStyle"),
                //            });
                //        }
                //    }
                //}
                //return paymentEstimateDetail.ToList();
                #endregion
            }

            set
            {
                bindingSourceDetail.DataSource = value ?? new List<EstimateDetailModel>();
                grdDetail.MainView = bandedGridViewDetail;
                grdDetail.ForceInitialize();
                bandedGridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsInserted", ColumnVisible = false }); //LINHMC ADD
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Mã mục lục ngân sách" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Tên mục lục ngân sách", IsSummaryText = true });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PreviousYearOfAutonomyBudget", ColumnCaption = "Tự chủ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí tự chủ quyết toán năm trước" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PreviousYearOfNonAutonomyBudget", ColumnCaption = "Không tự chủ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí không tự chủ quyết toán năm trước" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalEstimateAmountUSD", ColumnCaption = "Tổng cộng", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng cộng quyết toán năm trước" });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "YearOfAutonomyBudget", ColumnCaption = "Tự chủ", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí tự chủ được giao năm nay" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "YearOfNonAutonomyBudget", ColumnCaption = "Không tự chủ", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí không tự chủ được giao năm nay" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "YearOfEstimateAmount", ColumnCaption = "Tổng cộng", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng cộng dự toán được giao năm nay" });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PreviousYeaOfAutonomyBudgetBalance", ColumnCaption = "Tự chủ", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Số dư dự toán năm trước kinh phí tự chủ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PreviousYeaOfNonAutonomyBudgetBalance", ColumnCaption = "Không tự chủ", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Số dư dự toán năm trước kinh phí không tự chủ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalPreviousYearBalance", ColumnCaption = "Tổng cộng", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng cộng số dư dự toán năm trước" });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "SixMonthBeginingAutonomyBudget", ColumnCaption = "Tự chủ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí tự chủ ước thực hiện 6 tháng đầu năm" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SixMonthBeginingNonAutonomyBudget", ColumnCaption = "Không tự chủ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí không tự chủ ước thực hiện 6 tháng đầu năm" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountSixMonthBegining", ColumnCaption = "Tổng cộng", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng cộng ước thực hiện năm 6 tháng đầu năm" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SixMonthEndingAutonomyBudget", ColumnCaption = "Tự chủ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí tự chủ ước thực hiện 6 tháng cuối năm" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SixMonthEndingNonAutonomyBudget", ColumnCaption = "Không tự chủ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí không tự chủ ước thực hiện 6 tháng cuối năm" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountSixMonthEnding", ColumnCaption = "Tổng cộng", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng cộng ước thực hiện 6 tháng cuối năm" });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ThisYearOfAutonomyBudget", ColumnCaption = "Tự chủ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí tự chủ thực hiện năm nay" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ThisYearOfNonAutonomyBudget", ColumnCaption = "Không tự chủ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí không tự chủ thực hiện năm nay" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountThisYear", ColumnCaption = "Tổng cộng", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng kinh phí thực hiện năm nay" });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutonomyBudget", ColumnCaption = "KP tự chủ", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí tự chủ dự toán năm sau" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NonAutonomyBudget", ColumnCaption = "Không tự chủ", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 90, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, ToolTip = "Kinh phí không tự chủ dự toán năm sau" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalNextYearOfEstimateAmount", ColumnCaption = "Tổng cộng", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, ToolTip = "Tổng cộng dự toán năm sau" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Ghi chú", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 300, FixedColumn = FixedStyle.None, ToolTip = "Ghi chú", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PreviousYearOfEstimateAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PreviousYearOfEstimateAmountUSD", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NextYearOfEstimateAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ItemCodeList", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NumberOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FontStyle", ColumnVisible = false });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        bandedGridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        bandedGridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        bandedGridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        bandedGridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        bandedGridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        bandedGridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        bandedGridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        bandedGridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        if ((column.ColumnName == "BudgetItemCode") || (column.ColumnName == "BudgetItemName"))
                            bandedGridViewDetail.Columns[column.ColumnName].Fixed = FixedStyle.Left;
                        else
                            bandedGridViewDetail.Columns[column.ColumnName].Fixed = FixedStyle.None;
                        if (column.IsSummaryText)
                        {
                            bandedGridViewDetail.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            bandedGridViewDetail.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                    }
                    else
                        bandedGridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                LoadBandGridView();
                SetNumericFormatControl(bandedGridViewDetail, true);
                if (value != null && (ActionMode == ActionModeVoucherEnum.AddNew && value.Count > 0))
                {
                    btnUpdateData.Enabled = true;
                }
            }
        }

        public IList<PlanTemplateItemModel> PlanTemplateItems
        {
            get { return _planTemplateItemsTemp; } //LinhMC add
            set
            {
                _planTemplateItemsTemp = value;
                if (value == null) return;
                if (ActionMode != ActionModeVoucherEnum.AddNew) return;
                var paymentEstimateDetails = value.Select(planTemplateItemModel => new EstimateDetailModel
                {
                    BudgetItemCode = planTemplateItemModel.BudgetItemCode,
                    BudgetItemName = planTemplateItemModel.BudgetItemName,
                    PreviousYearOfEstimateAmount = CurrencyLocal == CurrencyAccounting ? 0 : planTemplateItemModel.PreviousYearOfEstimateAmount,
                    PreviousYearOfEstimateAmountUSD = planTemplateItemModel.PreviousYearOfEstimateAmountUSD,
                    TotalEstimateAmountUSD = planTemplateItemModel.PreviousYearOfEstimateAmountUSD,

                    PreviousYearOfAutonomyBudget = planTemplateItemModel.PreviousYearOfAutonomyBudget,
                    PreviousYearOfNonAutonomyBudget = planTemplateItemModel.PreviousYearOfNonAutonomyBudget,

                    SixMonthBeginingAutonomyBudget = planTemplateItemModel.SixMonthBeginingAutonomyBudget,
                    SixMonthBeginingNonAutonomyBudget = planTemplateItemModel.SixMonthBeginingNonAutonomyBudget,
                    TotalAmountSixMonthBegining = planTemplateItemModel.TotalAmountSixMonthBegining,

                    SixMonthEndingAutonomyBudget = planTemplateItemModel.SixMonthBeginingAutonomyBudget,
                    SixMonthEndingNonAutonomyBudget = 0,
                    TotalAmountSixMonthEnding = planTemplateItemModel.SixMonthBeginingAutonomyBudget,

                    ThisYearOfNonAutonomyBudget = planTemplateItemModel.SixMonthBeginingNonAutonomyBudget,
                    ThisYearOfAutonomyBudget = 2 * planTemplateItemModel.SixMonthBeginingAutonomyBudget,
                    TotalAmountThisYear = 2 * planTemplateItemModel.SixMonthBeginingAutonomyBudget + planTemplateItemModel.SixMonthBeginingNonAutonomyBudget

                }).ToList();
                PaymentEstimateDetails = paymentEstimateDetails;
            }
        }

        public IList<EstimateModel> PaymentEstimates { set; private get; }

        public IList<BudgetSourceCategoryModel> BudgetSourceCategories
        {
            set
            {
                GridLookUpItem.BudgetSourceCategory(value ?? new List<BudgetSourceCategoryModel>(), grdBudgetSourceCategoryID, grdBudgetSourceCategoryIDView, "BudgetSourceCategoryName", "BudgetSourceCategoryId");
                // không hiển thị dòng tìm kiếm dữ liệu
                grdBudgetSourceCategoryID.Properties.View.OptionsView.ShowAutoFilterRow = false;
                //try
                //{


                //    grdBudgetSourceCategoryID.Properties.DataSource = value;
                //    grdBudgetSourceCategoryIDView.PopulateColumns(value);
                //    var gridColumnsCollection = new List<XtraColumn>
                //        {
                //            new XtraColumn {ColumnName = "BudgetSourceCategoryId", ColumnVisible = false},
                //            new XtraColumn {ColumnName = "BudgetSourceCategoryCode", ColumnCaption = "Mã loại nguồn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130},
                //            new XtraColumn {ColumnName = "BudgetSourceCategoryName", ColumnCaption = "Tên loại nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 370},
                //            new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                //            new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                //            new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                //            new XtraColumn {ColumnName = "IsSummaryEstimateReport", ColumnVisible = false}
                //        };
                //    foreach (var column in gridColumnsCollection)
                //    {
                //        if (column.ColumnVisible)
                //        {
                //            grdBudgetSourceCategoryIDView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //            grdBudgetSourceCategoryIDView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                //            grdBudgetSourceCategoryIDView.Columns[column.ColumnName].Width = column.ColumnWith;
                //            grdBudgetSourceCategoryIDView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                //        }
                //        else
                //            grdBudgetSourceCategoryIDView.Columns[column.ColumnName].Visible = false;
                //    }
                //    grdBudgetSourceCategoryID.Properties.DisplayMember = "BudgetSourceCategoryName";
                //    grdBudgetSourceCategoryID.Properties.ValueMember = "BudgetSourceCategoryId";
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        #endregion

        #region Override function

        protected override void InitData()
        {
            base.InitData();
            var receiptEstimateId = ((EstimateModel)MasterBindingSource.Current).RefId;
            KeyValue = receiptEstimateId.ToString(CultureInfo.InvariantCulture);
            _planTemplateListsPresenter.DisplayByPayment();
            _budgetSourceCategoriesPresenter.DisplayActive();
            if (KeyValue != "0")
            {
                _paymentEstimatePresenter.Display(long.Parse(KeyValue));
                btnUpdateData.Enabled = ActionMode != ActionModeVoucherEnum.None;
                grdlookUpEditPlanTemplateListId.Enabled = false;
            }
            else
            {
                PaymentEstimateDetails = new List<EstimateDetailModel>();
                btnUpdateData.Enabled = false;
                btnUpdateTemplateListItem.Enabled = false;
                //if (string.IsNullOrEmpty(grdBudgetSourceCategoryID.Text))
                //{
                //    grdlookUpEditPlanTemplateListId.Enabled = false;
                //}
            }
        }

        protected override void EditVoucher()
        {
            btnUpdateData.Enabled = true;
            _paymentEstimatePresenter.Display(long.Parse(KeyValue));
            base.EditVoucher();
        }

        protected override void InitControls()
        {
            grdlookUpEditPlanTemplateListId.ForceInitialize();
            grdlookUpEditPlanTemplateListId.Focus();
            grdBudgetSourceCategoryID.ForceInitialize();
            grdBudgetSourceCategoryID.Focus();

            if (CurrencyLocal == CurrencyAccounting)
            {
                spnExchangeRate.Enabled = false;
                spnExchangeRate.Enabled = false;
            }
            else
            {
                spnExchangeRate.Enabled = true;
                spnExchangeRate.Enabled = true;
            }
            gridViewDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            if (ActionMode != ActionModeVoucherEnum.None)
            {
                btnUpdateData.Enabled = true;
                btnUpdateTemplateListItem.Enabled = true;
                chkLastYear.Enabled = true;
                chkSixMonth.Enabled = true;
                chkFiveMonth.Enabled = true;
            }
            else
            {
                btnUpdateData.Enabled = false;
                btnUpdateTemplateListItem.Enabled = false;
                chkLastYear.Enabled = false;
                chkSixMonth.Enabled = false;
                chkFiveMonth.Enabled = false;
                chkLastYear.Checked = false;
                chkSixMonth.Checked = false;
                chkFiveMonth.Checked = false;
            }
            if (ActionMode == ActionModeVoucherEnum.Edit)
                grdBudgetSourceCategoryID.Enabled = false;
            bandedGridViewDetail.OptionsBehavior.ReadOnly = ActionMode == ActionModeVoucherEnum.None;
            bandedGridViewDetail.OptionsView.ShowFooter = true;

            btnExportData.Enabled = ActionMode == ActionModeVoucherEnum.None;
        }

        protected override bool ValidData()
        {
            bandedGridViewDetail.CloseEditor();
            if (PlanTemplateListId == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPlanTemplateListId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdlookUpEditPlanTemplateListId.Focus();
                return false;
            }
            if (CurrencyLocal != CurrencyAccounting && Math.Abs(ExchangeRate - 0F) <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEstimateExchangeRate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                spnExchangeRate.Focus();
                return false;
            }
            //if (BudgetSourceCategoryId <= 0)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyBudgetSourceCategoryID"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    grdlookUpEditPlanTemplateListId.Focus();
            //    return false;
            //}
            _paymentEstimatesPresenter.Display(RefTypeId, (short)spnYearOfPlan.Value);

            if (PaymentEstimates.Count > 0 && (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher))
            {
                XtraMessageBox.Show(@"Chứng từ dự toán năm " + spnYearOfPlan.Value + @" đã tồn tại !", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bandedGridViewDetail.OptionsBehavior.ReadOnly = true;
            bandedGridViewDetail.CloseEditor();
            return _paymentEstimatePresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            _paymentEstimatePresenter.Delete(_keyForSend == null ? RefId : long.Parse(_keyForSend));
        }

        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupObject, isEnable);
            InitControls();
        }

        #endregion

        #region Events

        public FrmXtraPaymentEstimateDetail()
        {
            InitializeComponent();
            _paymentEstimatePresenter = new PaymentEstimatePresenter(this);
            _planTemplateListsPresenter = new PlanTemplateListsPresenter(this);
            _planTemplateItemsPresenter = new PlanTemplateItemsPresenter(this);
            _paymentEstimatesPresenter = new PaymentEstimatesPresenter(this);
            _budgetSourceCategoriesPresenter = new BudgetSourceCategoriesPresenter(this);
            _budgetItemCodeBand = new GridBand();
            _budgetItemNameBand = new GridBand();
            _descriptionBand = new GridBand();
            _previousYearOfEstimateBand = new GridBand();
            _thisYearOfEstimateBand = new GridBand();
            _nextYearOfEstimateBand = new GridBand();
            _invisibleBand = new GridBand();
            _thisYearOfReceiptEstimate = new GridBand();
            _sixMonthBegining = new GridBand();
            _sixMonthEnding = new GridBand();
            _previousYearBalance = new GridBand();
            _totalAmountThisYear = new GridBand();
            //     _receiptEstimatesPresenter = new ReceiptEstimatesPresenter(this); 
        }

        private void grdlookUpEditPlanTemplateListId_Closed(object sender, ClosedEventArgs e)
        {
            spnYearOfPlan.Value = grdlookUpEditPlanTemplateListIdView.GetFocusedRowCellValue("PlanYear") != null ? (short)grdlookUpEditPlanTemplateListIdView.GetFocusedRowCellValue("PlanYear") : 0;

            if (!ReferenceEquals(grdlookUpEditPlanTemplateListId.EditValue, ""))
            {
                var item = Convert.ToInt32(grdlookUpEditPlanTemplateListId.EditValue);
                _paymentEstimatePresenter.DisplayOption(item, (int)spnYearOfPlan.Value);
            }
            SetNumericFormatControl(bandedGridViewDetail, true);
        }

        private void spnExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrencyLocal == CurrencyAccounting || !(Math.Abs(ExchangeRate - 0F) <= 0)) return;
            ExchangeRate = 1;
        }

        private void btnExchange_Click(object sender, EventArgs e) 
        {
            try
            {
                //Cursor = Cursors.WaitCursor;
                //if (bandedGridViewDetail.RowCount > 0)
                //{
                //    var paymentEstimateDetails = PaymentEstimateDetails;
                //    foreach (var receiptEstimateDetail in paymentEstimateDetails)
                //    {
                //        if (CurrencyLocal == CurrencyAccounting)
                //            receiptEstimateDetail.TotalEstimateAmountUSD = receiptEstimateDetail.PreviousYearOfEstimateAmount +
                //                receiptEstimateDetail.PreviousYearOfEstimateAmountUSD;
                //        else
                //            receiptEstimateDetail.TotalEstimateAmountUSD = receiptEstimateDetail.PreviousYearOfEstimateAmount / decimal.Parse(spnExchangeRate.Text) +
                //                receiptEstimateDetail.PreviousYearOfEstimateAmountUSD;
                //    }
                //    PaymentEstimateDetails = paymentEstimateDetails;
                //}
                //Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                string tempFolderPath = System.Windows.Forms.Application.StartupPath + @"\Export";
                var yearOfPlan = (int)spnYearOfPlan.Value;
                _paymentEstimatesPresenter.CreateXmlReceiptEstimatesData(yearOfPlan, RefTypeId, tempFolderPath, "DTC_" + GlobalVariable.CompanyCode, GlobalVariable.CompanyCode);
            }
        }

        #endregion

        #region GridBand

        private void FrmXtraPaymentEstimateDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        private void FrmXtraPaymentEstimateDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        protected override void LoadGridDetailLayout()
        {
            //hàm này phải có để hiển thị bandGridViewDetail
        }

        private void LoadBandGridView()
        {
            #region Grid multi header row
            // creating the bands layout
            _thisYearOfEstimateBand.Name = @"ThisYearOfEstimateBand";
            _thisYearOfReceiptEstimate.Name = @"ThisYearOfReceiptEstimate";
            _sixMonthBegining.Name = @"SixMonthAutonomyBudget";
            _sixMonthEnding.Name = @"SixMonthNonAutonomyBudget";
            _previousYearBalance.Name = @"PreviousYearBalance";
            _totalAmountThisYear.Name = @"TotalAmountThisYear";

            if (bandedGridViewDetail.Bands.Count <= 0)
            {
                _budgetItemCodeBand = bandedGridViewDetail.Bands.AddBand("BudgetItemCode");
                _budgetItemNameBand = bandedGridViewDetail.Bands.AddBand("BudgetItemName");
                _previousYearOfEstimateBand = bandedGridViewDetail.Bands.AddBand("PreviousYearOfEstimate");
                _previousYearBalance = bandedGridViewDetail.Bands.AddBand("PreviousYearBalance");
                _thisYearOfEstimateBand = bandedGridViewDetail.Bands.AddBand("ThisYearOfReceiptEstimate");
                _thisYearOfReceiptEstimate = bandedGridViewDetail.Bands.AddBand("ThisYearOfReceiptEstimate");
                _sixMonthBegining = bandedGridViewDetail.Bands.AddBand("SixMonthAutonomyBudget");
                _sixMonthEnding = bandedGridViewDetail.Bands.AddBand("SixMonthNonAutonomyBudget");
                _totalAmountThisYear = bandedGridViewDetail.Bands.AddBand("TotalAmountThisYear");
                _thisYearOfEstimateBand.Children.Add(_thisYearOfReceiptEstimate);
                _thisYearOfEstimateBand.Children.Add(_sixMonthBegining);
                _thisYearOfEstimateBand.Children.Add(_sixMonthEnding);
                _thisYearOfEstimateBand.Children.Add(_totalAmountThisYear);

                _nextYearOfEstimateBand = bandedGridViewDetail.Bands.AddBand("NextYearOfEstimate");
                _invisibleBand = bandedGridViewDetail.Bands.AddBand("InvisibleBand");
                _descriptionBand = bandedGridViewDetail.Bands.AddBand("Description");
            }

            #region MLNS
            //MLNS và Diễn giải
            bandedGridViewDetail.Columns["BudgetItemCode"].OwnerBand = _budgetItemCodeBand;
            bandedGridViewDetail.Columns["BudgetItemCode"].Visible = true;
            bandedGridViewDetail.Columns["BudgetItemCode"].VisibleIndex = 1;
            bandedGridViewDetail.Columns["BudgetItemCode"].SortOrder = ColumnSortOrder.Ascending;
            bandedGridViewDetail.Columns["BudgetItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;
            _budgetItemCodeBand.Caption = @"Mã MLNS";
            _budgetItemCodeBand.Fixed = FixedStyle.Left;
            #endregion

            #region BudgetItemName
            bandedGridViewDetail.Columns["BudgetItemName"].OwnerBand = _budgetItemNameBand;
            bandedGridViewDetail.Columns["BudgetItemName"].Visible = true;
            bandedGridViewDetail.Columns["BudgetItemName"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["BudgetItemName"].OptionsColumn.AllowSort = DefaultBoolean.False;
            _budgetItemNameBand.Caption = @"Ghi chú";
            _budgetItemNameBand.Fixed = FixedStyle.Left;
            bandedGridViewDetail.Columns["BudgetItemName"].VisibleIndex = 2;
            #endregion

            #region Quyết toán năm trước
            bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"].OwnerBand = _previousYearOfEstimateBand;
            bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"].VisibleIndex = 3;
            bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"].OwnerBand = _previousYearOfEstimateBand;
            bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"].VisibleIndex = 4;
            bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["TotalEstimateAmountUSD"].OwnerBand = _previousYearOfEstimateBand;
            bandedGridViewDetail.Columns["TotalEstimateAmountUSD"].Visible = true;
            bandedGridViewDetail.Columns["TotalEstimateAmountUSD"].VisibleIndex = 5;
            bandedGridViewDetail.Columns["TotalEstimateAmountUSD"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["TotalEstimateAmountUSD"].OptionsColumn.AllowSort = DefaultBoolean.False;
            _previousYearOfEstimateBand.Caption = @"Đề nghị quyết toán năm trước";
            _previousYearOfEstimateBand.AppearanceHeader.Options.UseTextOptions = true;
            _previousYearOfEstimateBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            #endregion

            #region Số dư dự toán năm trước
            bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"].OwnerBand = _previousYearBalance;
            bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"].Visible = true;
            bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"].VisibleIndex = 6;
            bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"].OwnerBand = _previousYearBalance;
            bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"].Visible = true;
            bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"].VisibleIndex = 7;
            bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["TotalPreviousYearBalance"].OwnerBand = _previousYearBalance;
            bandedGridViewDetail.Columns["TotalPreviousYearBalance"].Visible = true;
            bandedGridViewDetail.Columns["TotalPreviousYearBalance"].VisibleIndex = 8;
            bandedGridViewDetail.Columns["TotalPreviousYearBalance"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["TotalPreviousYearBalance"].OptionsColumn.AllowSort = DefaultBoolean.False;
            _previousYearBalance.Caption = @"Số dư năm trước";
            _previousYearBalance.AppearanceHeader.Options.UseTextOptions = true;
            _previousYearBalance.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            #endregion

            #region Quyết toán năm nay

            #region Dự toán năm nay
            _thisYearOfEstimateBand.Caption = @"Dự toán năm nay";
            _thisYearOfEstimateBand.AppearanceHeader.Options.UseTextOptions = true;
            _thisYearOfEstimateBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            #region Dự toán được giao
            bandedGridViewDetail.Columns["YearOfAutonomyBudget"].OwnerBand = _thisYearOfReceiptEstimate;
            bandedGridViewDetail.Columns["YearOfAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["YearOfAutonomyBudget"].VisibleIndex = 9;
            bandedGridViewDetail.Columns["YearOfAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["YearOfAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"].OwnerBand = _thisYearOfReceiptEstimate;
            bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"].VisibleIndex = 10;
            bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["YearOfEstimateAmount"].OwnerBand = _thisYearOfReceiptEstimate;
            bandedGridViewDetail.Columns["YearOfEstimateAmount"].Visible = true;
            bandedGridViewDetail.Columns["YearOfEstimateAmount"].VisibleIndex = 11;
            bandedGridViewDetail.Columns["YearOfEstimateAmount"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["YearOfEstimateAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;

            _thisYearOfReceiptEstimate.Caption = @"Dự toán được giao";
            _thisYearOfReceiptEstimate.AppearanceHeader.Options.UseTextOptions = true;
            _thisYearOfReceiptEstimate.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            #endregion

            #region Ước thực hiện
            bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"].OwnerBand = _sixMonthBegining;
            bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"].VisibleIndex = 12;
            bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"].OwnerBand = _sixMonthBegining;
            bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"].VisibleIndex = 13;
            bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"].OwnerBand = _sixMonthBegining;
            bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"].Visible = true;
            bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"].VisibleIndex = 14;
            bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"].OptionsColumn.AllowSort = DefaultBoolean.False;

            _sixMonthBegining.Caption = @"Thực hiện DT được giao 6 tháng đầu năm";
            _sixMonthBegining.AppearanceHeader.Options.UseTextOptions = true;
            _sixMonthBegining.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;


            bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"].OwnerBand = _sixMonthEnding;
            bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"].VisibleIndex = 15;
            bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"].OwnerBand = _sixMonthEnding;
            bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"].VisibleIndex = 16;
            bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"].OwnerBand = _sixMonthEnding;
            bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"].Visible = true;
            bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"].VisibleIndex = 17;
            bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"].OptionsColumn.AllowSort = DefaultBoolean.False;

            _sixMonthEnding.Caption = @"Ước thực hiện 6 tháng cuối năm";
            _sixMonthEnding.AppearanceHeader.Options.UseTextOptions = true;
            _sixMonthEnding.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            #region Thực hiện năm nay
            bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"].OwnerBand = _totalAmountThisYear;
            bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"].VisibleIndex = 18;
            bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"].OwnerBand = _totalAmountThisYear;
            bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"].VisibleIndex = 19;
            bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["TotalAmountThisYear"].OwnerBand = _totalAmountThisYear;
            bandedGridViewDetail.Columns["TotalAmountThisYear"].Visible = true;
            bandedGridViewDetail.Columns["TotalAmountThisYear"].VisibleIndex = 20;
            bandedGridViewDetail.Columns["TotalAmountThisYear"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["TotalAmountThisYear"].OptionsColumn.AllowSort = DefaultBoolean.False;

            _totalAmountThisYear.Caption = @"Ước thực hiện dự toán được giao năm nay";
            _totalAmountThisYear.AppearanceHeader.Options.UseTextOptions = true;
            _totalAmountThisYear.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            #endregion
            #endregion

            #region Quyết toán năm sau
            bandedGridViewDetail.Columns["AutonomyBudget"].OwnerBand = _nextYearOfEstimateBand;
            bandedGridViewDetail.Columns["AutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["AutonomyBudget"].VisibleIndex = 21;
            bandedGridViewDetail.Columns["AutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["AutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["NonAutonomyBudget"].OwnerBand = _nextYearOfEstimateBand;
            bandedGridViewDetail.Columns["NonAutonomyBudget"].Visible = true;
            bandedGridViewDetail.Columns["NonAutonomyBudget"].VisibleIndex = 22;
            bandedGridViewDetail.Columns["NonAutonomyBudget"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["NonAutonomyBudget"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridViewDetail.Columns["TotalNextYearOfEstimateAmount"].OwnerBand = _nextYearOfEstimateBand;
            bandedGridViewDetail.Columns["TotalNextYearOfEstimateAmount"].Visible = true;
            bandedGridViewDetail.Columns["TotalNextYearOfEstimateAmount"].VisibleIndex = 23;
            bandedGridViewDetail.Columns["TotalNextYearOfEstimateAmount"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["TotalNextYearOfEstimateAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;

            _nextYearOfEstimateBand.Caption = @"Dự toán năm sau";
            _nextYearOfEstimateBand.AppearanceHeader.Options.UseTextOptions = true;
            _nextYearOfEstimateBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            #endregion
            #endregion
            #endregion

            #region Description
            bandedGridViewDetail.Columns["Description"].OwnerBand = _descriptionBand;
            bandedGridViewDetail.Columns["Description"].Visible = true;
            bandedGridViewDetail.Columns["Description"].VisibleIndex = 24;
            bandedGridViewDetail.Columns["Description"].SortOrder = ColumnSortOrder.None;
            bandedGridViewDetail.Columns["Description"].OptionsColumn.AllowSort = DefaultBoolean.False;
            _descriptionBand.Caption = @"Tên MLNS";
            #endregion

            #region Hide column
            //Cột ẩn
            bandedGridViewDetail.Columns["RefDetailId"].OwnerBand = _invisibleBand;
            bandedGridViewDetail.Columns["RefDetailId"].Visible = false;
            bandedGridViewDetail.Columns["RefId"].OwnerBand = _invisibleBand;
            bandedGridViewDetail.Columns["RefId"].Visible = false;
            bandedGridViewDetail.Columns["PreviousYearOfEstimateAmount"].OwnerBand = _invisibleBand;
            bandedGridViewDetail.Columns["PreviousYearOfEstimateAmount"].Visible = false;
            bandedGridViewDetail.Columns["PreviousYearOfEstimateAmountUSD"].OwnerBand = _invisibleBand;
            bandedGridViewDetail.Columns["PreviousYearOfEstimateAmountUSD"].Visible = false;
            bandedGridViewDetail.Columns["PreviousYearOfEstimateAmountUSD"].OptionsColumn.AllowSort = DefaultBoolean.False;
            _invisibleBand.Visible = false;
            #endregion

            bandedGridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            bandedGridViewDetail.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
            bandedGridViewDetail.OptionsView.AllowHtmlDrawHeaders = true;

            new GridBandPaintHelper(bandedGridViewDetail, new[] { _budgetItemCodeBand, _budgetItemNameBand, _descriptionBand });

            #endregion
        }

        private void bandedGridViewDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                var previousYearOfEstimateAmountCol = bandedGridViewDetail.Columns["PreviousYearOfEstimateAmount"];
                var previousYearOfEstimateAmountUSDCol = bandedGridViewDetail.Columns["PreviousYearOfEstimateAmountUSD"];
                var previousYearOfAutonomyBudgetCol = bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"];
                var previousYearOfNonAutonomyBudgetCol = bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"];
                var yearOfEstimateAmountCol = bandedGridViewDetail.Columns["YearOfEstimateAmount"];
                var yearOfAutonomyBudgetCol = bandedGridViewDetail.Columns["YearOfAutonomyBudget"];
                var yearOfNonAutonomyBudgetCol = bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"];
                var sixMonthBeginingAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"];
                var sixMonthBeginingNonAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"];
                var totalAmountSixMonthBeginingCol = bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"];
                var sixMonthEndingNonAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"];
                var sixMonthEndingAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"];
                var totalAmountSixMonthEndingCol = bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"];
                var nextYearOfEstimateAmountCol = bandedGridViewDetail.Columns["NextYearOfEstimateAmount"];
                var autonomyBudgetCol = bandedGridViewDetail.Columns["AutonomyBudget"];
                var nonAutonomyBudgetCol = bandedGridViewDetail.Columns["NonAutonomyBudget"];
                var previousYeaOfAutonomyBudgetBalanceCol = bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"];
                var previousYeaOfNonAutonomyBudgetBalanceCol = bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"];
                var totalPreviousYearBalanceCol = bandedGridViewDetail.Columns["TotalPreviousYearBalance"];
                var thisYearOfAutonomyBudgetCol = bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"];
                var thisYearOfNonAutonomyBudgetCol = bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"];

                var previousYearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYearOfEstimateAmountCol);
                var previousYearOfEstimateAmountUSD = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYearOfEstimateAmountUSDCol);
                var yearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, yearOfEstimateAmountCol);
                var nextYearOfEstimateAmount = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, nextYearOfEstimateAmountCol);
                var yearOfAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, yearOfAutonomyBudgetCol);
                var yearOfNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, yearOfNonAutonomyBudgetCol);
                var sixMonthBeginingAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingAutonomyBudgetCol);
                var sixMonthBeginingNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingNonAutonomyBudgetCol);
                var totalAmountSixMonthBegining = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, totalAmountSixMonthBeginingCol);
                var sixMonthEndingNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingNonAutonomyBudgetCol);
                var sixMonthEndingAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingAutonomyBudgetCol);
                var totalAmountSixMonthEnding = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, totalAmountSixMonthEndingCol);
                var previousYearOfAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYearOfAutonomyBudgetCol);
                var previousYearOfNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYearOfNonAutonomyBudgetCol);
                var previousYeaOfAutonomyBudgetBalance = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYeaOfAutonomyBudgetBalanceCol);
                var previousYeaOfNonAutonomyBudgetBalance = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYeaOfNonAutonomyBudgetBalanceCol);
                var totalPreviousYearBalance = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, totalPreviousYearBalanceCol);
                var thisYearOfAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, thisYearOfAutonomyBudgetCol);
                var thisYearOfNonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, thisYearOfNonAutonomyBudgetCol);

                var autonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, autonomyBudgetCol);
                var nonAutonomyBudget = (decimal)bandedGridViewDetail.GetRowCellValue(e.RowHandle, nonAutonomyBudgetCol);

                if (previousYearOfEstimateAmount < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfEstimateAmountCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (previousYearOfEstimateAmountUSD < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfEstimateAmountUSDCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (previousYearOfAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (previousYearOfNonAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfNonAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
                if (yearOfEstimateAmount < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(yearOfEstimateAmountCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (nextYearOfEstimateAmount < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(nextYearOfEstimateAmountCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (yearOfAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(yearOfAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (yearOfNonAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(yearOfNonAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
                if (sixMonthBeginingAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(sixMonthBeginingAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (sixMonthBeginingNonAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(sixMonthBeginingNonAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
                if (totalAmountSixMonthBegining < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(totalAmountSixMonthBeginingCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (sixMonthEndingAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(sixMonthEndingAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (sixMonthEndingNonAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(sixMonthEndingNonAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
                if (totalAmountSixMonthEnding < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(totalAmountSixMonthEndingCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (autonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(autonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (nonAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(nonAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
                if (previousYeaOfAutonomyBudgetBalance < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfEstimateAmountCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (previousYeaOfNonAutonomyBudgetBalance < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfEstimateAmountCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
                if (totalPreviousYearBalance < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(previousYearOfEstimateAmountCol, ResourceHelper.GetResourceValueByName("ResPreviousYearOfEstimateAmount"));
                }
                if (thisYearOfAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(thisYearOfAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResAutonomyBudgetAmoun"));
                }
                if (thisYearOfNonAutonomyBudget < 0)
                {
                    e.Valid = false;
                    bandedGridViewDetail.SetColumnError(thisYearOfNonAutonomyBudgetCol, ResourceHelper.GetResourceValueByName("ResNonAutonomyBudgetAmoun"));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridViewDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                var previousYearOfAutonomyBudgetCol = bandedGridViewDetail.Columns["PreviousYearOfAutonomyBudget"];
                var previousYearOfNonAutonomyBudgetCol = bandedGridViewDetail.Columns["PreviousYearOfNonAutonomyBudget"];

                var yearOfAutonomyBudgetCol = bandedGridViewDetail.Columns["YearOfAutonomyBudget"];
                var yearOfNonAutonomyBudgetCol = bandedGridViewDetail.Columns["YearOfNonAutonomyBudget"];

                var sixMonthBeginingAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthBeginingAutonomyBudget"];
                var sixMonthBeginingNonAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthBeginingNonAutonomyBudget"];
                var totalAmountSixMonthBeginingCol = bandedGridViewDetail.Columns["TotalAmountSixMonthBegining"];
                var sixMonthEndingNonAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthEndingNonAutonomyBudget"];
                var sixMonthEndingAutonomyBudgetCol = bandedGridViewDetail.Columns["SixMonthEndingAutonomyBudget"];
                var totalAmountSixMonthEndingCol = bandedGridViewDetail.Columns["TotalAmountSixMonthEnding"];
                var previousYeaOfAutonomyBudgetBalanceCol = bandedGridViewDetail.Columns["PreviousYeaOfAutonomyBudgetBalance"];
                var previousYeaOfNonAutonomyBudgetBalanceCol = bandedGridViewDetail.Columns["PreviousYeaOfNonAutonomyBudgetBalance"];
                var totalPreviousYearBalanceCol = bandedGridViewDetail.Columns["TotalPreviousYearBalance"];

                var autonomyBudgetCol = bandedGridViewDetail.Columns["AutonomyBudget"];
                var nonAutonomyBudgetCol = bandedGridViewDetail.Columns["NonAutonomyBudget"];

                var totalEstimateAmountUSDCol = bandedGridViewDetail.Columns["TotalEstimateAmountUSD"];
                var yearOfEstimateAmountCol = bandedGridViewDetail.Columns["YearOfEstimateAmount"];
                var totalNextYearOfEstimateAmountCol = bandedGridViewDetail.Columns["TotalNextYearOfEstimateAmount"];
                var thisYearOfAutonomyBudgetCol = bandedGridViewDetail.Columns["ThisYearOfAutonomyBudget"];
                var thisYearOfNonAutonomyBudgetCol = bandedGridViewDetail.Columns["ThisYearOfNonAutonomyBudget"];
                var totalAmountThisYearCol = bandedGridViewDetail.Columns["TotalAmountThisYear"];
                decimal sixMonthBeginingAutonomyBudget;
                decimal sixMonthBeginingNonAutonomyBudget;
                decimal sixMonthEndingAutonomyBudget = 0;
                decimal sixMonthEndingNonAutonomyBudget;

                switch (e.Column.FieldName)
                {
                    case "PreviousYeaOfAutonomyBudgetBalance":
                        var previousYeaOfNonAutonomyBudgetBalance = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYeaOfNonAutonomyBudgetBalanceCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalPreviousYearBalanceCol, (decimal)e.Value + previousYeaOfNonAutonomyBudgetBalance);
                        break;
                    case "PreviousYeaOfNonAutonomyBudgetBalance":
                        var previousYeaOfAutonomyBudgetBalance = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYeaOfAutonomyBudgetBalanceCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalPreviousYearBalanceCol, (decimal)e.Value + previousYeaOfAutonomyBudgetBalance);
                        break;
                    case "AutonomyBudget":
                        var nonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, nonAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalNextYearOfEstimateAmountCol, (decimal)e.Value + nonAutonomyBudget);
                        break;
                    case "NonAutonomyBudget":
                        var autonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, autonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalNextYearOfEstimateAmountCol, (decimal)e.Value + autonomyBudget);
                        break;
                    case "PreviousYearOfAutonomyBudget":
                        var previousYearOfNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYearOfNonAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalEstimateAmountUSDCol, (decimal)e.Value + previousYearOfNonAutonomyBudget);
                        break;
                    case "PreviousYearOfNonAutonomyBudget":
                        var previousYearOfAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, previousYearOfAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalEstimateAmountUSDCol, (decimal)e.Value + previousYearOfAutonomyBudget);
                        break;
                    case "YearOfAutonomyBudget":
                        var yearOfNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, yearOfNonAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, yearOfEstimateAmountCol, (decimal)e.Value + yearOfNonAutonomyBudget);
                        break;
                    case "YearOfNonAutonomyBudget":
                        var yearOfAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, yearOfAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, yearOfEstimateAmountCol, (decimal)e.Value + yearOfAutonomyBudget);
                        break;
                    case "SixMonthBeginingAutonomyBudget":
                        sixMonthBeginingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingNonAutonomyBudgetCol).ToString());
                        sixMonthBeginingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingAutonomyBudgetCol).ToString());
                        sixMonthEndingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingNonAutonomyBudgetCol).ToString());

                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, sixMonthEndingAutonomyBudgetCol, (decimal)e.Value + sixMonthEndingAutonomyBudget);
                        sixMonthEndingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingAutonomyBudgetCol).ToString());

                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountSixMonthBeginingCol, (decimal)e.Value + sixMonthBeginingNonAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, thisYearOfAutonomyBudgetCol, sixMonthBeginingAutonomyBudget + sixMonthEndingAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountThisYearCol, sixMonthBeginingNonAutonomyBudget + sixMonthEndingNonAutonomyBudget + sixMonthEndingAutonomyBudget + sixMonthBeginingAutonomyBudget);
                        break;
                    case "SixMonthBeginingNonAutonomyBudget":
                        sixMonthBeginingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingAutonomyBudgetCol).ToString());
                        sixMonthBeginingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingNonAutonomyBudgetCol).ToString());
                        sixMonthEndingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingNonAutonomyBudgetCol).ToString());
                        sixMonthEndingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingAutonomyBudgetCol).ToString());

                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountSixMonthBeginingCol, (decimal)e.Value + sixMonthBeginingAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, thisYearOfNonAutonomyBudgetCol, sixMonthBeginingNonAutonomyBudget + sixMonthEndingNonAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountThisYearCol, sixMonthBeginingNonAutonomyBudget + sixMonthEndingNonAutonomyBudget + sixMonthEndingAutonomyBudget + sixMonthBeginingAutonomyBudget);
                        break;
                    case "SixMonthEndingAutonomyBudget":
                        sixMonthEndingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingNonAutonomyBudgetCol).ToString());
                        sixMonthEndingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingAutonomyBudgetCol).ToString());

                        sixMonthBeginingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingAutonomyBudgetCol).ToString());
                        sixMonthBeginingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingNonAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountSixMonthEndingCol, (decimal)e.Value + sixMonthEndingNonAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, thisYearOfAutonomyBudgetCol, sixMonthEndingAutonomyBudget + sixMonthBeginingAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountThisYearCol, sixMonthBeginingNonAutonomyBudget + sixMonthEndingNonAutonomyBudget + sixMonthEndingAutonomyBudget + sixMonthBeginingAutonomyBudget);
                        break;
                    case "SixMonthEndingNonAutonomyBudget":
                        sixMonthEndingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingAutonomyBudgetCol).ToString());
                        sixMonthEndingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthEndingNonAutonomyBudgetCol).ToString());
                        sixMonthBeginingAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingAutonomyBudgetCol).ToString());
                        sixMonthBeginingNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, sixMonthBeginingNonAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountSixMonthEndingCol, (decimal)e.Value + sixMonthEndingAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, thisYearOfNonAutonomyBudgetCol, sixMonthEndingNonAutonomyBudget + sixMonthBeginingNonAutonomyBudget);
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountThisYearCol, sixMonthBeginingNonAutonomyBudget + sixMonthEndingNonAutonomyBudget + sixMonthEndingAutonomyBudget + sixMonthBeginingAutonomyBudget);
                        break;

                    case "ThisYearOfAutonomyBudget":
                        var thisYearOfNonAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, thisYearOfNonAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountThisYearCol, (decimal)e.Value + thisYearOfNonAutonomyBudget);
                        break;
                    case "ThisYearOfNonAutonomyBudget":
                        var thisYearOfAutonomyBudget = decimal.Parse(bandedGridViewDetail.GetRowCellValue(e.RowHandle, thisYearOfAutonomyBudgetCol).ToString());
                        bandedGridViewDetail.SetRowCellValue(e.RowHandle, totalAmountThisYearCol, (decimal)e.Value + thisYearOfAutonomyBudget);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridViewDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bandedGridViewDetail_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "PreviousYearOfAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "PreviousYearOfNonAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "TotalEstimateAmountUSD":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "YearOfAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "YearOfNonAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "YearOfEstimateAmount":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "SixMonthBeginingAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "SixMonthBeginingNonAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "TotalAmountSixMonthBegining":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "SixMonthEndingAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "SixMonthEndingNonAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "TotalAmountSixMonthEnding":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "AutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "NonAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "TotalNextYearOfEstimateAmount":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "PreviousYearOfEstimateAmount":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "PreviousYearOfEstimateAmountUSD":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "NextYearOfEstimateAmount":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "PreviousYeaOfAutonomyBudgetBalance":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "PreviousYeaOfNonAutonomyBudgetBalance":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "TotalPreviousYearBalance":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "TotalAmountThisYear":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "ThisYearOfAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
                case "ThisYearOfNonAutonomyBudget":
                    if (Convert.ToDecimal(e.Value) == 0)
                        e.DisplayText = "";
                    break;
            }
        }

        private void SetNumericFormatControl(BandedGridView bandedGridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in bandedGridView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.CurrencyDecimalDigits);
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
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

        #endregion

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            try
            {
                #region
                //var globaleVariable = new GlobalVariable();
                //if (chkLastYear.Checked == false && chkSixMonth.Checked == false && chkFiveMonth.Checked == false)
                //{
                //    XtraMessageBox.Show("Bạn chưa chọn khung thời gian cập nhật số liệu, vui lòng chọn lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

                //var paymentEstimateDetails = new List<EstimateDetailModel>();

                //IList<F03BNGModel> f03BNGEstimateData = null;

                //IList<F03BNGModel> f03BNGEstimateSixMonthData = null;

                //IList<F03BNGModel> f03BNGEstimateFiveMonthData = null;

                //if (chkLastYear.Checked)
                //{
                //    //Xác định thời gian năm trước
                //    var lastYearFromDate = new DateTime(YearOfPlaning - 2, 1, 1);
                //    var lastYearToDate = new DateTime(YearOfPlaning - 2, 12, 31);
                //    f03BNGEstimateData = _paymentEstimatesPresenter.GetF03BNG_ForEstimate(lastYearFromDate, lastYearToDate);
                //}

                //if (chkFiveMonth.Checked)
                //{
                //    //Xác định thời gian 5 tháng đầu năm hiện tại:
                //    var fiveMonthFromDate = new DateTime(YearOfPlaning - 1, 1, 1);
                //    var fiveMonthToDate = new DateTime(YearOfPlaning - 1, 5, 31);

                //    f03BNGEstimateFiveMonthData = _paymentEstimatesPresenter.GetF03BNG_ForEstimate(fiveMonthFromDate, fiveMonthToDate);
                //}

                //if (chkSixMonth.Checked)
                //{
                //    //Xác định thời gian 6 tháng đầu năm hiện tại:
                //    var sixMonthFromDate = new DateTime(YearOfPlaning - 1, 1, 1);
                //    var sixMonthToDate = new DateTime(YearOfPlaning - 1, 6, 30);

                //    f03BNGEstimateSixMonthData = _paymentEstimatesPresenter.GetF03BNG_ForEstimate(sixMonthFromDate, sixMonthToDate);
                //}

                //foreach (var paymentEstimateDetail in PaymentEstimateDetails)
                //{
                //    EstimateDetailModel detail = paymentEstimateDetail;
                //    if (chkLastYear.Checked || chkSixMonth.Checked || chkFiveMonth.Checked)
                //    {
                //        if (f03BNGEstimateData != null)
                //        {
                //            var f03BNGEstimateDataModel = f03BNGEstimateData.FirstOrDefault(c => c.BudgetItemCode == detail.BudgetItemCode);
                //            if (f03BNGEstimateDataModel != null)
                //            {
                //                if (BudgetSourceCategoryId == 2) //NSNN
                //                {
                //                    detail.PreviousYearOfAutonomyBudget =
                //                        f03BNGEstimateDataModel.ThisMonthAutonomyBudgetAmount;
                //                    detail.PreviousYearOfNonAutonomyBudget =
                //                        f03BNGEstimateDataModel.ThisMonthNonAutonomyBudgetAmount;
                //                    detail.TotalEstimateAmountUSD = f03BNGEstimateDataModel.ThisMonthAutonomyBudgetAmount +
                //                                                    f03BNGEstimateDataModel.ThisMonthNonAutonomyBudgetAmount;
                //                }

                //                else if (BudgetSourceCategoryId == 3) //NSNN BS
                //                {
                //                    detail.PreviousYearOfAutonomyBudget = 0;
                //                    detail.PreviousYearOfNonAutonomyBudget = f03BNGEstimateDataModel.ThisMonthRegulateOtherAmount;
                //                    detail.TotalEstimateAmountUSD = f03BNGEstimateDataModel.ThisMonthRegulateOtherAmount;
                //                }
                //                //else //TTB
                //                //{
                //                //    detail.PreviousYearOfAutonomyBudget =
                //                //        f03BNGEstimateDataModel.ThisMonthAutonomyOtherAmount;
                //                //    detail.PreviousYearOfNonAutonomyBudget =
                //                //        f03BNGEstimateDataModel.ThisMonthNonAutonomyOtherAmount;
                //                //    detail.TotalEstimateAmountUSD = f03BNGEstimateDataModel.ThisMonthAutonomyOtherAmount +
                //                //                                    f03BNGEstimateDataModel.ThisMonthNonAutonomyOtherAmount;
                //                //}
                //            }
                //        }

                //        if (chkFiveMonth.Checked)
                //        {
                //            //theo yêu cầu tính số tiền theo công thức Amount/5*6
                //            var f03BNGEstimateFiveMonthDataModel = f03BNGEstimateFiveMonthData.FirstOrDefault(c => c.BudgetItemCode == detail.BudgetItemCode);
                //            if (f03BNGEstimateFiveMonthDataModel != null)
                //            {
                //                if (BudgetSourceCategoryId == 2) //NSNN
                //                {
                //                    detail.SixMonthBeginingAutonomyBudget = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthAutonomyBudgetAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                    detail.SixMonthBeginingNonAutonomyBudget = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthNonAutonomyBudgetAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                    detail.TotalAmountSixMonthBegining = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthAutonomyBudgetAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits)) +
                //                                                    Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthNonAutonomyBudgetAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                }

                //                else if (BudgetSourceCategoryId == 3) //NSNN BS
                //                {
                //                    detail.SixMonthBeginingAutonomyBudget = 0;
                //                    detail.SixMonthBeginingNonAutonomyBudget = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthRegulateOtherAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                    detail.TotalAmountSixMonthBegining = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthRegulateOtherAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                }
                //                //else //TTB
                //                //{
                //                //    detail.SixMonthBeginingAutonomyBudget = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthAutonomyOtherAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                //    detail.SixMonthBeginingNonAutonomyBudget = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthNonAutonomyOtherAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                //    detail.TotalAmountSixMonthBegining = Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthAutonomyOtherAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits)) +
                //                //                                    Math.Round((f03BNGEstimateFiveMonthDataModel.ThisMonthNonAutonomyOtherAmount / 5) * 6, Convert.ToUInt16(globaleVariable.CurrencyDecimalDigits));
                //                //}
                //            }
                //            else
                //            {
                //                if (BudgetSourceCategoryId == 2) //NSNN
                //                {
                //                    detail.SixMonthBeginingAutonomyBudget = 0;
                //                    detail.SixMonthBeginingNonAutonomyBudget = 0;
                //                    detail.TotalAmountSixMonthBegining = 0;
                //                }
                //                else if (BudgetSourceCategoryId == 3) //NSNN BS
                //                {
                //                    detail.SixMonthBeginingAutonomyBudget = 0;
                //                    detail.SixMonthBeginingNonAutonomyBudget = 0;
                //                    detail.TotalAmountSixMonthBegining = 0;
                //                }
                //                //else //TTB
                //                //{
                //                //    detail.SixMonthBeginingAutonomyBudget = 0;
                //                //    detail.SixMonthBeginingNonAutonomyBudget = 0;
                //                //    detail.TotalAmountSixMonthBegining = 0;
                //                //}
                //            }
                //        }

                //        if (chkSixMonth.Checked)
                //        {
                //            var f03BNGEstimateSixMonthDataModel = f03BNGEstimateSixMonthData.FirstOrDefault(c => c.BudgetItemCode == detail.BudgetItemCode);
                //            if (f03BNGEstimateSixMonthDataModel != null)
                //            {
                //                if (BudgetSourceCategoryId == 2) //NSNN
                //                {
                //                    detail.SixMonthBeginingAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyBudgetAmount;
                //                    detail.SixMonthBeginingNonAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyBudgetAmount;
                //                    detail.TotalAmountSixMonthBegining = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyBudgetAmount +
                //                                                    f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyBudgetAmount;
                //                }

                //                else if (BudgetSourceCategoryId == 3) //NSNN BS
                //                {
                //                    detail.SixMonthBeginingAutonomyBudget = 0;
                //                    detail.SixMonthBeginingNonAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthRegulateOtherAmount;
                //                    detail.TotalAmountSixMonthBegining = f03BNGEstimateSixMonthDataModel.ThisMonthRegulateOtherAmount;
                //                }
                //                //else //TTB
                //                //{
                //                //    detail.SixMonthBeginingAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyOtherAmount;
                //                //    detail.SixMonthBeginingNonAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyOtherAmount;
                //                //    detail.TotalAmountSixMonthBegining = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyOtherAmount +
                //                //                                    f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyOtherAmount;
                //                //}
                //            }
                //        }
                //        /*LinhMC-4/1/2016: cột tự chủ 6 tháng cuối năm = số liệu của cột 6 tháng đầu năm*/
                //        detail.SixMonthEndingAutonomyBudget = detail.SixMonthBeginingAutonomyBudget;
                //        detail.TotalAmountSixMonthEnding = detail.SixMonthEndingAutonomyBudget +
                //                                           detail.SixMonthEndingNonAutonomyBudget;

                //        /*Cả năm = 6 tháng đầu năm + 6 tháng cuối năm*/
                //        detail.ThisYearOfAutonomyBudget = detail.SixMonthBeginingAutonomyBudget +
                //                                          detail.SixMonthEndingAutonomyBudget;
                //        detail.ThisYearOfNonAutonomyBudget = detail.SixMonthBeginingNonAutonomyBudget +
                //                                             detail.SixMonthEndingNonAutonomyBudget;
                //        detail.TotalAmountThisYear = detail.ThisYearOfAutonomyBudget +
                //                                     detail.ThisYearOfNonAutonomyBudget;

                //        paymentEstimateDetails.Add(detail);
                //    }
                //}
                #endregion

                var item = Convert.ToInt32(grdlookUpEditPlanTemplateListId.EditValue);
                _paymentEstimatePresenter.DisplayOption(item, (int)spnYearOfPlan.Value);

                XtraMessageBox.Show(@"Cập nhật số liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.StackTrace);
            }
        }

        private void AutoUpdateData()
        {
            try
            {
                var paymentEstimateDetails = new List<EstimateDetailModel>();

                //Xác định thời gian năm trước
                var lastYearFromDate = new DateTime(YearOfPlaning - 2, 1, 1);
                var lastYearToDate = new DateTime(YearOfPlaning - 2, 12, 31);
                IList<F03BNGModel> f03BNGEstimateData = _paymentEstimatesPresenter.GetF03BNG_ForEstimate(lastYearFromDate, lastYearToDate);

                //Xác định thời gian 6 tháng đầu năm hiện tại:
                var sixMonthFromDate = new DateTime(YearOfPlaning - 1, 1, 1);
                var sixMonthToDate = new DateTime(YearOfPlaning - 1, 6, 30);

                IList<F03BNGModel> f03BNGEstimateSixMonthData = _paymentEstimatesPresenter.GetF03BNG_ForEstimate(sixMonthFromDate, sixMonthToDate);

                foreach (var paymentEstimateDetail in PaymentEstimateDetails)
                {
                    EstimateDetailModel detail = paymentEstimateDetail;
                    var f03BNGEstimateDataModel = f03BNGEstimateData.FirstOrDefault(c => c.BudgetItemCode == detail.BudgetItemCode);
                    if (f03BNGEstimateDataModel != null)
                    {
                        if (BudgetSourceCategoryId == 2) //NSNN
                        {
                            detail.PreviousYearOfAutonomyBudget =
                                f03BNGEstimateDataModel.ThisMonthAutonomyBudgetAmount;
                            detail.PreviousYearOfNonAutonomyBudget =
                                f03BNGEstimateDataModel.ThisMonthNonAutonomyBudgetAmount;
                            detail.TotalEstimateAmountUSD = f03BNGEstimateDataModel.ThisMonthAutonomyBudgetAmount +
                                                            f03BNGEstimateDataModel.ThisMonthNonAutonomyBudgetAmount;
                        }

                        else if (BudgetSourceCategoryId == 3) //NSNN BS
                        {
                            detail.PreviousYearOfAutonomyBudget = 0;
                            detail.PreviousYearOfNonAutonomyBudget = f03BNGEstimateDataModel.ThisMonthRegulateOtherAmount;
                            detail.TotalEstimateAmountUSD = f03BNGEstimateDataModel.ThisMonthRegulateOtherAmount;
                        }
                        //else //TTB
                        //{
                        //    detail.PreviousYearOfAutonomyBudget =
                        //        f03BNGEstimateDataModel.ThisMonthAutonomyOtherAmount;
                        //    detail.PreviousYearOfNonAutonomyBudget =
                        //        f03BNGEstimateDataModel.ThisMonthNonAutonomyOtherAmount;
                        //    detail.TotalEstimateAmountUSD = f03BNGEstimateDataModel.ThisMonthAutonomyOtherAmount +
                        //                                    f03BNGEstimateDataModel.ThisMonthNonAutonomyOtherAmount;
                        //}
                    }

                    var f03BNGEstimateSixMonthDataModel = f03BNGEstimateSixMonthData.FirstOrDefault(c => c.BudgetItemCode == detail.BudgetItemCode);
                    if (f03BNGEstimateSixMonthDataModel != null)
                    {
                        if (BudgetSourceCategoryId == 2) //NSNN
                        {
                            detail.SixMonthBeginingAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyBudgetAmount;
                            detail.SixMonthBeginingNonAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyBudgetAmount;
                            detail.TotalAmountSixMonthBegining = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyBudgetAmount +
                                                            f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyBudgetAmount;
                        }

                        else if (BudgetSourceCategoryId == 3) //NSNN BS
                        {
                            detail.SixMonthBeginingAutonomyBudget = 0;
                            detail.SixMonthBeginingNonAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthRegulateOtherAmount;
                            detail.TotalAmountSixMonthBegining = f03BNGEstimateSixMonthDataModel.ThisMonthRegulateOtherAmount;
                        }
                        //else //TTB
                        //{
                        //    detail.SixMonthBeginingAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyOtherAmount;
                        //    detail.SixMonthBeginingNonAutonomyBudget = f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyOtherAmount;
                        //    detail.TotalAmountSixMonthBegining = f03BNGEstimateSixMonthDataModel.ThisMonthAutonomyOtherAmount +
                        //                                    f03BNGEstimateSixMonthDataModel.ThisMonthNonAutonomyOtherAmount;
                        //}
                    }
                    /*LinhMC-4/1/2016: cột tự chủ 6 tháng cuối năm = số liệu của cột 6 tháng đầu năm*/
                    detail.SixMonthEndingAutonomyBudget = detail.SixMonthBeginingAutonomyBudget;
                    detail.TotalAmountSixMonthEnding = detail.SixMonthEndingAutonomyBudget +
                                                       detail.SixMonthEndingNonAutonomyBudget;
                    /*Cả năm = 6 tháng đầu năm + 6 tháng cuối năm*/
                    detail.ThisYearOfAutonomyBudget = detail.SixMonthBeginingAutonomyBudget +
                                                          detail.SixMonthEndingAutonomyBudget;
                    detail.ThisYearOfNonAutonomyBudget = detail.SixMonthBeginingNonAutonomyBudget +
                                                         detail.SixMonthEndingNonAutonomyBudget;
                    detail.TotalAmountThisYear = detail.ThisYearOfAutonomyBudget +
                                                 detail.ThisYearOfNonAutonomyBudget;

                    paymentEstimateDetails.Add(detail);
                }
                PaymentEstimateDetails = paymentEstimateDetails;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.StackTrace);
            }
        }

        private void UpdatePlanTemplateItemsToEstimateVoucher()
        {
            #region
            //var item = grdlookUpEditPlanTemplateListId.EditValue.ToString();
            //var budgetSourceCategoryId = (int)grdBudgetSourceCategoryID.EditValue;
            //_planTemplateItemsPresenter.DisplayForEstimate(int.Parse(item), (short)spnYearOfPlan.Value, budgetSourceCategoryId);

            //var excelNames = new HashSet<string>(PaymentEstimateDetails.Select(x => x.BudgetItemCode));
            //var textRecordsNotInExcel = _planTemplateItemsTemp.Where(t => !excelNames.Contains(t.BudgetItemCode)).ToList();

            //var paymentEstimateDetails = PaymentEstimateDetails;

            //foreach (var planTemplateItemModel in textRecordsNotInExcel)
            //{
            //    paymentEstimateDetails.Add(new EstimateDetailModel
            //    {
            //        BudgetItemCode = planTemplateItemModel.BudgetItemCode,
            //        BudgetItemName = planTemplateItemModel.BudgetItemName,
            //        AutonomyBudget = 0,
            //        Description = "",
            //        NextYearOfEstimateAmount = 0,
            //        NonAutonomyBudget = 0,
            //        PreviousYeaOfAutonomyBudgetBalance = 0,
            //        PreviousYeaOfNonAutonomyBudgetBalance = 0,
            //        PreviousYearOfAutonomyBudget = 0,
            //        PreviousYearOfEstimateAmount = 0,
            //        PreviousYearOfEstimateAmountUSD = 0,
            //        PreviousYearOfNonAutonomyBudget = 0,
            //        RefId = PaymentEstimateDetails[1].RefId,
            //        SixMonthBeginingAutonomyBudget = 0,
            //        SixMonthBeginingNonAutonomyBudget = 0,
            //        SixMonthEndingAutonomyBudget = 0,
            //        SixMonthEndingNonAutonomyBudget = 0,
            //        ThisYearOfAutonomyBudget = 0,
            //        ThisYearOfNonAutonomyBudget = 0,
            //        TotalAmountSixMonthBegining = 0,
            //        TotalAmountSixMonthEnding = 0,
            //        TotalAmountThisYear = 0,
            //        TotalEstimateAmountUSD = 0,
            //        TotalNextYearOfEstimateAmount = 0,
            //        TotalPreviousYearBalance = 0,
            //        YearOfAutonomyBudget = 0,
            //        YearOfEstimateAmount = 0,
            //        YearOfNonAutonomyBudget = 0,
            //        IsInserted = true
            //    });


            //}

            //PaymentEstimateDetails = paymentEstimateDetails;
            #endregion

            var item = Convert.ToInt32(grdlookUpEditPlanTemplateListId.EditValue);
            _paymentEstimatePresenter.DisplayOption(item, (int)spnYearOfPlan.Value);
        }

        private void grdBudgetSourceCategoryID_EditValueChanged(object sender, EventArgs e)
        {
            //grdlookUpEditPlanTemplateListId.Enabled = grdBudgetSourceCategoryID.EditValue != null && ActionMode == ActionModeVoucherEnum.AddNew;
        }

        private void btnUpdateTemplateListItem_Click(object sender, EventArgs e)
        {
            UpdatePlanTemplateItemsToEstimateVoucher();
        }

        private void chkFiveMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiveMonth.Checked)
            {
                chkSixMonth.Checked = false;
                chkSixMonth.Enabled = false;
            }
            else if (ActionMode != ActionModeVoucherEnum.None)
            {
                chkSixMonth.Enabled = true;
            }
        }

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grdBudgetSourceCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            //var gridddd = sender as GridLookUpEdit;
            //if (gridddd.SelectionLength == gridddd.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            //{
            //    gridddd.EditValue = null;
            //    e.Handled = true;
            //}
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void dtRefDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }

        private void spinExchangeRateLastYear_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl17_Click(object sender, EventArgs e)
        {

        }
    }
}