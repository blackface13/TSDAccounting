/***********************************************************************
 * <copyright file="UserControlReceiptEstimateList.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Presenter.Estimate.ReceiptEstimate;
using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using System;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// class UserControlReceiptEstimateList
    /// </summary>
    public partial class UserControlReceiptEstimateList : BaseVoucherListUserControl, IReceiptEstimatesView
    {
        private readonly ReceiptEstimatesPresenter _receiptEstimatesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlReceiptEstimateList"/> class.
        /// </summary>
        public UserControlReceiptEstimateList()
        {
            InitializeComponent();
            _receiptEstimatesPresenter = new ReceiptEstimatesPresenter(this);
            barCurrency.Visible = false;
            
        }

        #region IReceiptVouchersView Members

        /// <summary>
        /// Sets the receipt estimates.
        /// </summary>
        /// <value>
        /// The receipt estimates.
        /// </value>
        public IList<EstimateModel> ReceiptEstimates
        {
            set
            {

                //var estimate = new List<EstimateModel>();
                //estimate = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "YearOfPlaning", ColumnCaption = "Năm dự toán", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalEstimateAmount", ColumnCaption = "Tổng DT năm nay", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 200, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far, ToolTip = "Tổng dự toán năm nay" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NextYearOfTotalEstimateAmount", ColumnCaption = "Tổng DT năm sau", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 200, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far, ToolTip = "Tổng dự toán năm sau" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
            }
        }

        #endregion

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            if (GlobalVariable.DisplayVourcherMode == 1)
                _receiptEstimatesPresenter.Display((int)RefTypeId);
            else
                _receiptEstimatesPresenter.DisplayByYear((int)RefTypeId, PostedDate);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(long refId)
        {
            _receiptEstimatesPresenter.DisplayVoucherDetail(refId);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new ReceiptEstimatePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraReceiptEstimateDetail();
        }


        public IList<EstimateDetailModel> ReceiptEstimateDetails
        {
            set
            {
                var dataSource = new List<EstimateDetailModel>();
                if (value != null)
                {
                    int i = 1;
                    foreach(var ds in value)
                    {
                        ds.NumberOrder = i.ToString();
                        dataSource.Add(ds);
                        i++;
                    }
                }
                bindingSourceDetail.DataSource = dataSource;
                gridViewDetail.PopulateColumns(dataSource);
                ColumnsCollection.Clear();
                ColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsInserted", ColumnVisible = false }, //LINHMC ADD
                        new XtraColumn {ColumnName = "AutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "NonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalNextYearOfEstimateAmount", ColumnVisible = false},
                        new XtraColumn
                            {
                                ColumnName = "NumberOrder",
                                ColumnCaption = "STT",
                                ColumnPosition = 1,
                                ColumnVisible = true,
                                ColumnWith = 30,
                                FixedColumn = FixedStyle.Left,
                                AllowEdit = false
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetItemName",
                                ColumnCaption = "Tên MLNS",
                                ColumnPosition = 1,
                                ColumnVisible = true,
                                ColumnWith = 250,
                                FixedColumn = FixedStyle.Left,
                                AllowEdit = false,
                                ColumnType = UnboundColumnType.String,
                                ToolTip = "Tên mục lục ngân sách"
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetItemCode",
                                ColumnCaption = "Mục/TM",
                                ColumnPosition = 2,
                                ColumnVisible = true,
                                ColumnWith = 70,
                                FixedColumn = FixedStyle.Left,
                                AllowEdit = false,
                                ToolTip = "Mục/ Tiểu Mục"
                            },
                        new XtraColumn
                            {
                                ColumnName = "ItemCodeList",
                                ColumnCaption = "Mục/TM",
                                ColumnPosition = 3,
                                ColumnVisible = false,
                                ColumnWith = 60,
                                FixedColumn = FixedStyle.Left,
                                AllowEdit = false,
                                ToolTip = "Mục/ Tiểu Mục"
                            },
                        new XtraColumn
                            {
                                ColumnName = "TotalEstimateAmountUSD",
                                ColumnCaption = "Thực hiện năm trước",
                                ColumnPosition = 4,
                                ColumnVisible = true,
                                ColumnWith = 130,
                                FixedColumn = FixedStyle.None,
                                ColumnType = UnboundColumnType.Decimal,
                                AllowEdit = true,
                                ToolTip = "Tổng Thực hiện năm trước"
                            },
                        new XtraColumn
                            {
                                ColumnName = "YearOfEstimateAmount",
                                ColumnCaption = "Ước thực hiện năm nay",
                                ColumnPosition = 5,
                                ColumnVisible = true,
                                ColumnWith = 150,
                                FixedColumn = FixedStyle.None,
                                ColumnType = UnboundColumnType.Decimal,
                                AllowEdit = true,
                                ToolTip = "Dự toán được giao năm nay"
                            },
                        new XtraColumn
                            {
                                ColumnName = "NextYearOfEstimateAmount",
                                ColumnCaption = "Dự toán năm sau",
                                ColumnPosition = 6,
                                ColumnVisible = true,
                                ColumnWith = 130,
                                FixedColumn = FixedStyle.None,
                                ColumnType = UnboundColumnType.Decimal,
                                AllowEdit = true,
                                ToolTip = "Ước thực hiện năm nay"
                            },
                        new XtraColumn
                            {
                                ColumnName = "Description",
                                ColumnCaption = "Ghi chú",
                                ColumnPosition = 7,
                                ColumnVisible = true,
                                ColumnWith = 250,
                                FixedColumn = FixedStyle.None,
                                ToolTip = "Ghi chú",
                                AllowEdit = true
                            },
                        new XtraColumn {ColumnName = "PreviousYearOfEstimateAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PreviousYearOfEstimateAmountUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SixMonthBeginingAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SixMonthBeginingNonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalAmountSixMonthBegining", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SixMonthEndingAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SixMonthEndingNonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalAmountSixMonthEnding", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PreviousYearOfAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PreviousYearOfNonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "YearOfAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "YearOfNonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PreviousYeaOfAutonomyBudgetBalance", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PreviousYeaOfNonAutonomyBudgetBalance", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalPreviousYearBalance", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ThisYearOfAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ThisYearOfNonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalAmountThisYear", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FontStyle",ColumnVisible = false }
                    };
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        if (column.IsSummaryText)
                        {
                            gridViewDetail.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            gridViewDetail.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                        if (column.ColumnPosition == 2 | column.ColumnPosition == 3)
                        {
                            gridViewDetail.Columns[column.ColumnName].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                            gridViewDetail.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        }
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }
    }
}
