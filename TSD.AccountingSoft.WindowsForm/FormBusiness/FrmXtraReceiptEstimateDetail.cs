/***********************************************************************
 * <copyright file="FrmXtraReceiptEstimateDetail.cs" company="BUCA JSC">
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateItem;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateList;
using TSD.AccountingSoft.Presenter.Estimate.ReceiptEstimate;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using TSD.AccountingSoft.WindowsForm.FormDictionary;


namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    ///  class FrmXtraReceiptEstimateDetail
    /// </summary>
    public partial class FrmXtraReceiptEstimateDetail : FrmXtraBaseVoucherDetail, IReceiptEstimateView, IPlanTemplateListsView, IPlanTemplateItemsView, IReceiptEstimatesView
    {
        private readonly ReceiptEstimatePresenter _receiptEstimatePresenter;
        private readonly PlanTemplateListsPresenter _planTemplateListsPresenter;
        private readonly PlanTemplateItemsPresenter _planTemplateItemsPresenter;
        private readonly ReceiptEstimatesPresenter _receiptEstimatesPresenter;

        //LinhMC add
        private IList<PlanTemplateItemModel> _planTemplateItemsTemp;

        #region ReceiptEstimate Members

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType)value : BaseRefTypeId; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string RefDate
        {
            get { return dtRefDate.EditValue == null ? null : dtRefDate.EditValue.ToString(); }
            set { dtRefDate.EditValue = DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate
        {
            get { return dtPostDate.EditValue == null ? null : dtPostDate.EditValue.ToString(); }
            set { dtPostDate.EditValue = DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the plan template list identifier.
        /// </summary>
        /// <value>
        /// The plan template list identifier.
        /// </value>
        public int PlanTemplateListId
        {
            get
            {
                if (ReferenceEquals(grdlookUpEditPlanTemplateListId.EditValue, "")) return 0;
                return (int)grdlookUpEditPlanTemplateListId.EditValue;
            }
            set
            {
                grdlookUpEditPlanTemplateListId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the year of planing.
        /// </summary>
        /// <value>
        /// The year of planing.
        /// </value>
        public short YearOfPlaning
        {
            get { return (short)spinYearOfPlaning.Value; }
            set { spinYearOfPlaning.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get { return CurrencyAccounting; }
            set { }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public float ExchangeRate
        {
            get { return float.Parse(txtExchangeRate.Text); }
            set { txtExchangeRate.EditValue = ActionMode == ActionModeVoucherEnum.Edit ? value : 1; }
        }

        /// <summary>
        /// Gets or sets the total estimate amount.
        /// </summary>
        /// <value>
        /// The total estimate amount.
        /// </value>
        public decimal TotalEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>
        /// The next year of total estimate amount.
        /// </value>
        public decimal NextYearOfTotalEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return memoJournalMemo.Text; }
            set { memoJournalMemo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the receipt estimate details.
        /// </summary>
        /// <value>
        /// The receipt estimate details.
        /// </value>
        public IList<EstimateDetailModel> ReceiptEstimateDetails
        {
            get
            {
                var paymentEstimateDetail = new List<EstimateDetailModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            paymentEstimateDetail.Add(new EstimateDetailModel
                            {
                                BudgetItemCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemCode"),
                                BudgetItemName = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemName"),
                                PreviousYearOfEstimateAmount = (decimal)gridViewDetail.GetRowCellValue(i, "PreviousYearOfEstimateAmount"),
                                PreviousYearOfEstimateAmountUSD = (decimal)gridViewDetail.GetRowCellValue(i, "PreviousYearOfEstimateAmountUSD"),
                                TotalEstimateAmountUSD = (decimal)gridViewDetail.GetRowCellValue(i, "TotalEstimateAmountUSD"),
                                YearOfEstimateAmount = (decimal)gridViewDetail.GetRowCellValue(i, "YearOfEstimateAmount"),
                                NextYearOfEstimateAmount = (decimal)gridViewDetail.GetRowCellValue(i, "NextYearOfEstimateAmount"),
                                Description = (string)gridViewDetail.GetRowCellValue(i, "Description"),
                                RefDetailId = (long)(gridViewDetail.GetRowCellValue(i, "RefDetailId")),
                                IsInserted = (bool)gridViewDetail.GetRowCellValue(i, "IsInserted"),
                                ItemCodeList = (string)gridViewDetail.GetRowCellValue(i, "ItemCodeList"),
                                NumberOrder = (string)gridViewDetail.GetRowCellValue(i, "NumberOrder"),
                                FontStyle = (string)gridViewDetail.GetRowCellValue(i, "FontStyle")
                            });
                        }
                    }
                }
                return paymentEstimateDetail.ToList();
            }
            set
            {
                if(value == null)
                    value = new List<EstimateDetailModel>();
                int i = 1;
                foreach(var ed in value)
                {
                    ed.NumberOrder = i.ToString();
                    i++;
                }
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
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
                                ColumnWith = 60,
                                FixedColumn = FixedStyle.Left,
                                AllowEdit = false,
                                ToolTip = "Số thứ tự"
                            },
                        new XtraColumn
                            {
                                ColumnName = "ItemCodeList",
                                ColumnCaption = "M/TM",
                                ColumnVisible = false
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetItemName",
                                ColumnCaption = "Tên MLNS",
                                ColumnPosition = 2,
                                ColumnVisible = true,
                                ColumnWith = 250,
                                FixedColumn = FixedStyle.Left,
                                AllowEdit = false,
                                ToolTip = "Tên mục lục ngân sách",
                                IsSummaryText = true
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetItemCode",
                                ColumnCaption = "Mục/TM",
                                ColumnPosition = 3,
                                ColumnVisible = true,
                                ColumnWith = 100,
                                FixedColumn = FixedStyle.None,
                                AllowEdit = true,
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
                                FixedColumn = FixedStyle.None,
                                ToolTip = "Ghi chú",
                                AllowEdit = true,
                                ColumnWith = 400,
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
                        new XtraColumn { ColumnName = "PreviousYeaOfAutonomyBudgetBalance", ColumnVisible = false},
                        new XtraColumn { ColumnName = "PreviousYeaOfNonAutonomyBudgetBalance", ColumnVisible = false},
                        new XtraColumn { ColumnName = "TotalPreviousYearBalance", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ThisYearOfAutonomyBudget", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ThisYearOfNonAutonomyBudget", ColumnVisible = false},
                        new XtraColumn { ColumnName = "TotalAmountThisYear", ColumnVisible = false},
                        new XtraColumn { ColumnName = "FontStyle", ColumnVisible = false}
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
                        if (column.ColumnPosition == 1 | column.ColumnPosition == 3)
                        {
                            gridViewDetail.Columns[column.ColumnName].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                            gridViewDetail.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        }
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
                gridViewDetail.OptionsView.ShowFooter = false;
            }
        }

        /// <summary>
        /// Sets the receipt estimates.
        /// </summary>
        /// <value>
        /// The receipt estimates.
        /// </value>
        public IList<EstimateModel> ReceiptEstimates { set; private get; }

        #endregion

        #region Combobox Members

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>
        /// The BudgetItems.
        /// </value>
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

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>
        /// The BudgetItems.
        /// </value>
        public IList<PlanTemplateItemModel> PlanTemplateItems
        {
            get { return _planTemplateItemsTemp; } //LinhMC add
            set
            {
                try
                {
                    if (value == null) return;
                    _planTemplateItemsTemp = value;
                    if (ActionMode != ActionModeVoucherEnum.AddNew) return;
                    var receiptEstimateDetails = value.Select(planTemplateItemModel => new EstimateDetailModel
                    {
                        BudgetItemCode = planTemplateItemModel.BudgetItemCode,
                        BudgetItemName = planTemplateItemModel.BudgetItemName,
                        TotalEstimateAmountUSD = planTemplateItemModel.PreviousYearOfEstimateAmountUSD,
                        YearOfEstimateAmount = planTemplateItemModel.TotalAmountThisYear,
                        ItemCodeList = planTemplateItemModel.ItemCodeList,
                        NumberOrder = planTemplateItemModel.NumberOrder,
                        FontStyle = planTemplateItemModel.FontStyle
                    }).ToList();
                    ReceiptEstimateDetails = receiptEstimateDetails;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraReceiptEstimateDetail"/> class.
        /// </summary>
        public FrmXtraReceiptEstimateDetail()
        {
            InitializeComponent();
            _planTemplateListsPresenter = new PlanTemplateListsPresenter(this);
            _planTemplateItemsPresenter = new PlanTemplateItemsPresenter(this);
            _receiptEstimatePresenter = new ReceiptEstimatePresenter(this);
            _receiptEstimatesPresenter = new ReceiptEstimatesPresenter(this);
        }

        /// <summary>
        /// Handles the Closed event of the grdlookUpEditPlanTemplateListId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ClosedEventArgs" /> instance containing the event data.</param>
        private void grdlookUpEditPlanTemplateListId_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                var systemDate = GlobalVariable.SystemDate;
                spinYearOfPlaning.Value = grdlookUpEditPlanTemplateListIdView.GetFocusedRowCellValue("PlanYear") != null ? (short)grdlookUpEditPlanTemplateListIdView.GetFocusedRowCellValue("PlanYear") : 0;
                if (!ReferenceEquals(grdlookUpEditPlanTemplateListId.EditValue, ""))
                {
                    var item = grdlookUpEditPlanTemplateListId.EditValue.ToString();
                    if (DateTime.Parse(systemDate).Year == spinYearOfPlaning.Value)
                        _planTemplateItemsPresenter.DisplayByPlanTemplateListId(int.Parse(item));
                    else
                        _planTemplateItemsPresenter.DisplayForEstimate(int.Parse(item), (short)spinYearOfPlaning.Value, 0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExchangeRate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnExchangeRate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gridViewDetail.RowCount > 0)
                {
                    var receiptEstimateDetails = ReceiptEstimateDetails;
                    foreach (var receiptEstimateDetail in receiptEstimateDetails)
                    {
                        if (CurrencyLocal == CurrencyAccounting)
                            receiptEstimateDetail.TotalEstimateAmountUSD = receiptEstimateDetail.PreviousYearOfEstimateAmount +
                                receiptEstimateDetail.PreviousYearOfEstimateAmountUSD;
                        else
                            receiptEstimateDetail.TotalEstimateAmountUSD = receiptEstimateDetail.PreviousYearOfEstimateAmount / decimal.Parse(txtExchangeRate.Text) +
                                receiptEstimateDetail.PreviousYearOfEstimateAmountUSD;
                    }
                    ReceiptEstimateDetails = receiptEstimateDetails;
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtExchangeRate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyLocal == CurrencyAccounting || !(Math.Abs(ExchangeRate - 0F) <= 0)) return;
                ExchangeRate = 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExportData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExportData_Click(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                string tempFolderPath = System.Windows.Forms.Application.StartupPath + @"\Export";
                var yearOfPlan = (int)spinYearOfPlaning.Value;
                _receiptEstimatesPresenter.CreateXmlReceiptEstimatesData(yearOfPlan, RefTypeId, tempFolderPath, "DTT_" + GlobalVariable.CompanyCode, GlobalVariable.CompanyCode);
                XtraMessageBox.Show("Xuất khẩu dữ liệu thành công!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Override function

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            gridViewDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            btnExportData.Enabled = ActionMode == ActionModeVoucherEnum.None;
            if (ActionMode == ActionModeVoucherEnum.None) return;
            if (CurrencyLocal == CurrencyAccounting)
            {
                txtExchangeRate.Enabled = false;
                btnExchangeRate.Enabled = false;
            }
            else
            {
                txtExchangeRate.Enabled = true;
                btnExchangeRate.Enabled = true;
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {

                btnUpdateTemplateListItem.Enabled = false;
            }

        }

        /// <summary>
        /// Initializes the data.
        /// </summary>

        protected override void InitData()
        {
            base.InitData();
            var receiptEstimateId = ((EstimateModel)MasterBindingSource.Current).RefId;
            KeyValue = receiptEstimateId.ToString(CultureInfo.InvariantCulture);
            _planTemplateListsPresenter.DisplayByReceipt();
            _receiptEstimatePresenter.Display(long.Parse(KeyValue));
        }

        protected override void EditVoucher()
        {
            _receiptEstimatePresenter.Display(long.Parse(KeyValue));
            base.EditVoucher();
        }


        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (PlanTemplateListId == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPlanTemplateListId"),
                           ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                grdlookUpEditPlanTemplateListId.Focus();
                return false;
            }
            if (CurrencyLocal != CurrencyAccounting && Math.Abs(ExchangeRate - 0F) <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEstimateExchangeRate"),
                           ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                txtExchangeRate.Focus();
                return false;
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
            {
                _receiptEstimatesPresenter.Display(RefTypeId, (short)spinYearOfPlaning.Value);
                if (ReceiptEstimates.Count > 0)
                {
                    XtraMessageBox.Show(@"Chứng từ dự toán năm " + spinYearOfPlaning.Value + @" đã tồn tại !",
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;
            return _receiptEstimatePresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            _receiptEstimatePresenter.Delete(refId);
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupObject, isEnable);
            InitControls();
        }

        #endregion

        /// <summary>
        /// LINHMC: add
        /// 21/8/2015: Cập nhật chỉ tiêu dự toán
        /// Updates the plan template items to estimate voucher.
        /// </summary>
        /// <returns></returns>
        private void UpdatePlanTemplateItemsToEstimateVoucher()
        {
            var item = grdlookUpEditPlanTemplateListId.EditValue.ToString();
            _planTemplateItemsPresenter.DisplayByPlanTemplateListId(int.Parse(item));

            var excelNames = new HashSet<string>(ReceiptEstimateDetails.Select(x => x.BudgetItemCode));
            var textRecordsNotInExcel = _planTemplateItemsTemp.Where(t => !excelNames.Contains(t.BudgetItemCode)).ToList();

            var receiptEstimateDetails = ReceiptEstimateDetails;

            foreach (var planTemplateItemModel in textRecordsNotInExcel)
            {
                receiptEstimateDetails.Add(new EstimateDetailModel
                {
                    BudgetItemCode = planTemplateItemModel.BudgetItemCode,
                    BudgetItemName = planTemplateItemModel.BudgetItemName,
                    AutonomyBudget = 0,
                    Description = "",
                    NextYearOfEstimateAmount = 0,
                    NonAutonomyBudget = 0,
                    PreviousYeaOfAutonomyBudgetBalance = 0,
                    PreviousYeaOfNonAutonomyBudgetBalance = 0,
                    PreviousYearOfAutonomyBudget = 0,
                    PreviousYearOfEstimateAmount = 0,
                    PreviousYearOfEstimateAmountUSD = 0,
                    PreviousYearOfNonAutonomyBudget = 0,
                    RefId = ReceiptEstimateDetails[1].RefId,
                    SixMonthBeginingAutonomyBudget = 0,
                    SixMonthBeginingNonAutonomyBudget = 0,
                    SixMonthEndingAutonomyBudget = 0,
                    SixMonthEndingNonAutonomyBudget = 0,
                    ThisYearOfAutonomyBudget = 0,
                    ThisYearOfNonAutonomyBudget = 0,
                    TotalAmountSixMonthBegining = 0,
                    TotalAmountSixMonthEnding = 0,
                    TotalAmountThisYear = 0,
                    TotalEstimateAmountUSD = 0,
                    TotalNextYearOfEstimateAmount = 0,
                    TotalPreviousYearBalance = 0,
                    YearOfAutonomyBudget = 0,
                    YearOfEstimateAmount = 0,
                    YearOfNonAutonomyBudget = 0,
                    IsInserted = true
                });


            }

            ReceiptEstimateDetails = receiptEstimateDetails;
        }

        private void btnUpdateTemplateListItem_Click(object sender, EventArgs e)
        {
            UpdatePlanTemplateItemsToEstimateVoucher();
        }

        private void gridViewDetail_RowStyle(object sender, RowStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string fontStyle = view.GetRowCellDisplayText(e.RowHandle, view.Columns["FontStyle"]);
                if (fontStyle == "B")
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

        private void gridViewDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridViewDetail_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var view = sender as GridView;
            string budgetItemCode = view.GetRowCellDisplayText(view.FocusedRowHandle, view.Columns["BudgetItemCode"]);
            if (budgetItemCode == "000100" || budgetItemCode == "000101" || budgetItemCode == "000107" || budgetItemCode == "000115")
            {
                e.Cancel = true;
            }
        }

        private void FrmXtraReceiptEstimateDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        private void FrmXtraReceiptEstimateDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        private void dtRefDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Thêm danh mục mẫu dự toán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdlookUpEditPlanTemplateListId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frm = new FrmXtraPlanTemplateItem();
                frm.ShowDialog();
                if (frm.CloseBox)
                {
                    _planTemplateListsPresenter.DisplayByReceipt();
                    if (frm.IdResult != -1)
                    {
                        grdlookUpEditPlanTemplateListId.EditValue = frm.IdResult;
                        _planTemplateItemsPresenter.DisplayByPlanTemplateListId(frm.IdResult);
                    }
                }
            }
        }
    }
}