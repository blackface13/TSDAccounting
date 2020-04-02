/***********************************************************************
 * <copyright file="UserControlPaymentEstimateList.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.Presenter.Estimate.PaymentEstimate;
using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Linq;
using System;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// class UserControlPaymentEstimateList
    /// </summary>
    public partial class UserControlPaymentEstimateList : BaseVoucherListUserControl, IPaymentEstimatesView
    {
        private readonly PaymentEstimatesPresenter _paymentEstimatesPresenter;

        private readonly GlobalVariable _dbOptionHelper;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlPaymentEstimateList"/> class.
        /// </summary>
        public UserControlPaymentEstimateList()
        {
            InitializeComponent();
            _paymentEstimatesPresenter = new PaymentEstimatesPresenter(this);
            _dbOptionHelper = new GlobalVariable();

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
            barCurrency.Visible = false;
        }

        #region IPaymentVouchersView Members

        /// <summary>
        /// Sets the payment estimates.
        /// </summary>
        /// <value>
        /// The payment estimates.
        /// </value>
        public IList<EstimateModel> PaymentEstimates
        {
            set
            {
                //var estimate = new List<EstimateModel>();
                    
                //   estimate = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnVisible = true, ColumnPosition = 1, ColumnWith = 100, ToolTip = "Ngày hạch toán", ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanTemplateListId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EstimateDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 90, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "YearOfPlaning", ColumnCaption = "Năm dự toán", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 90, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalEstimateAmount", ColumnCaption = "Tổng DT được giao năm nay", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 200, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far, ToolTip = "Tổng dự toán được giao năm nay" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NextYearOfTotalEstimateAmount", ColumnCaption = "Ước thực hiện năm nay", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 200, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            if (GlobalVariable.DisplayVourcherMode == 1)
                _paymentEstimatesPresenter.Display((int)RefTypeId);
            else
            {
                var yearOfRefDate = _dbOptionHelper.PostedDate;
                _paymentEstimatesPresenter.DisplayByYear((int)RefTypeId, yearOfRefDate);
            }
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(long refId)
        {
            _paymentEstimatesPresenter.DisplayVoucherDetail(refId);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new PaymentEstimatePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraPaymentEstimateDetail();
        }


        public IList<EstimateDetailModel> PaymentEstimateDetails
        {
            set
            {
            
                bindingSourceDetail.DataSource = value;
                gridDetail.MainView = bandedGridViewDetail;
                gridDetail.ForceInitialize();
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
                bandedGridViewDetail.BestFitColumns();
                SetNumericFormatControl(bandedGridViewDetail, true);
            }
        }

        /// <summary>
        /// Copy tu form Detail
        /// Loads the band grid view.
        /// </summary>
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
            _previousYearOfEstimateBand.Caption = @"Quyết toán năm trước";
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
    }
}
