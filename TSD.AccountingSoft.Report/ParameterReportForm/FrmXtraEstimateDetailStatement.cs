/***********************************************************************
 * <copyright file="FrmXtraEstimateDetailStatement.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 11 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;
using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.Presenter.Estimate.EstimateDetailStatement;
using TSD.AccountingSoft.Presenter.Estimate.EstimateDetailStatementPartB;
using System;
using TSD.AccountingSoft.Presenter.Estimate.EstimateDetailStatementFixedAsset;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;


namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// FrmXtraEstimateDetailStatement
    /// </summary>
    public partial class FrmXtraEstimateDetailStatement : FrmXtraBaseParameter, IEstimateDetailStatementView, IEstimateDetailStatementPartBView, IEstimateDetailStatementFixedAssetView
    {
        private readonly EstimateDetailStatementPresenter _estimateDetailStatementPresenter;
        private readonly EstimateDetailStatementPartBsPresenter _estimateDetailStatementPartBsPresenter;
        private readonly EstimateDetailStatementFixedAssetsPresenter _estimateDetailStatementFixedAssetsPresenter;
        private readonly GlobalVariable _dbOptionHelper;
        private readonly RepositoryItemCalcEdit _repositoryCurrencyCalcEdit;
        private readonly RepositoryItemCalcEdit _repositoryNumberCalcEdit;

        #region Old Properties
        ///// <summary>
        ///// Gets the year of estimate.
        ///// </summary>
        ///// <value>
        ///// The year of estimate.
        ///// </value>
        //public short YearOfEstimate
        //{
        //    get { return short.Parse(spinYearOfPlaning.Text); }
        //}

        ///// <summary>
        ///// Gets the general description.
        ///// </summary>
        ///// <value>
        ///// The general description.
        ///// </value>
        //public string GeneralDescription
        //{
        //    get { return memoGeneralDescription.Text; }
        //}

        ///// <summary>
        ///// Gets the employee leasing description.
        ///// </summary>
        ///// <value>
        ///// The employee leasing description.
        ///// </value>
        //public string EmployeeLeasingDescription
        //{
        //    get { return memoEmployeeLeasingDescription.Text; }
        //}

        ///// <summary>
        ///// Gets the employee leasing description.
        ///// </summary>
        ///// <value>
        ///// The employee leasing description.
        ///// </value>
        //public string EmployeeContractDescription
        //{
        //    get { return memoEmployeeContractDescription.Text; }
        //}

        ///// <summary>
        ///// Gets the building of fixed asset description.
        ///// </summary>
        ///// <value>
        ///// The building of fixed asset description.
        ///// </value>
        //public string BuildingOfFixedAssetDescription
        //{
        //    get { return memoBuildingOfFixedAssetDescription.Text; }
        //}

        ///// <summary>
        ///// Gets the description for building.
        ///// </summary>
        ///// <value>
        ///// The description for building.
        ///// </value>
        //public string DescriptionForBuilding
        //{
        //    get { return memoDescriptionForBuilding.Text; }  
        //}

        ///// <summary>
        ///// Gets the car description.
        ///// </summary>
        ///// <value>
        ///// The car description.
        ///// </value>
        //public string CarDescription
        //{
        //    get { return memoCarDescription.Text; }
        //}

        ///// <summary>
        ///// Gets the inventory description.
        ///// </summary>
        ///// <value>
        ///// The inventory description.
        ///// </value>
        //public string InventoryDescription
        //{
        //    get { return memoInventoryDescription.Text; }
        //}

        ///// <summary>
        ///// Gets the part c.
        ///// </summary>
        ///// <value>
        ///// The part c.
        ///// </value>
        //public string PartC
        //{
        //    get { return memoPartC.Text; }
        //}
        #endregion

        #region Properties

        public bool Type { get { return true; } set { } }
        /// 
        public int EstimateDetailStatementId { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate.
        /// </summary>
        /// <value>
        /// The year of estimate.
        /// </value>
        public short YearOfEstimate
        {
            get { return short.Parse(spinYearOfPlaning.Text); }
            set { spinYearOfPlaning.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the general description.
        /// </summary>
        /// <value>
        /// The general description.
        /// </value>
        public string GeneralDescription
        {
            get { return memoGeneralDescription.Text; }
            set { memoGeneralDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the employee leasing description.
        /// </summary>
        /// <value>
        /// The employee leasing description.
        /// </value>
        public string EmployeeLeasingDescription
        {
            get { return memoEmployeeLeasingDescription.Text; }
            set { memoEmployeeLeasingDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the employee contract description.
        /// </summary>
        /// <value>
        /// The employee contract description.
        /// </value>
        public string EmployeeContractDescription
        {
            get { return memoEmployeeContractDescription.Text; }
            set { memoEmployeeContractDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the building of fixed asset description.
        /// </summary>
        /// <value>
        /// The building of fixed asset description.
        /// </value>
        public string BuildingOfFixedAssetDescription
        {
            get { return memoBuildingOfFixedAssetDescription.Text; }
            set { memoBuildingOfFixedAssetDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the description for building.
        /// </summary>
        /// <value>
        /// The description for building.
        /// </value>
        public string DescriptionForBuilding
        {
            get { return memoDescriptionForBuilding.Text; }
            set { memoDescriptionForBuilding.Text = value; }
        }

        /// <summary>
        /// Gets or sets the car description.
        /// </summary>
        /// <value>
        /// The car description.
        /// </value>
        public string CarDescription
        {
            get { return memoCarDescription.Text; }
            set { memoCarDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the inventory description.
        /// </summary>
        /// <value>
        /// The inventory description.
        /// </value>
        public string InventoryDescription
        {
            get { return memoInventoryDescription.Text; }
            set { memoInventoryDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the part c.
        /// </summary>
        /// <value>
        /// The part c.
        /// </value>
        public string PartC
        {
            get { return memoPartC.Text; }
            set { memoPartC.Text = value; }
        }

        public string PartC1
        {
            get { return memoPartC1.Text; }
            set { memoPartC1.Text = value; }
        }

        public bool IsActive { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate
        {
            get { return ((DateTime)dtReportDate.EditValue).ToShortDateString(); }
            set { dtReportDate.EditValue = DateTime.Parse(value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraEstimateDetailStatement"/> class.
        /// </summary>
        public FrmXtraEstimateDetailStatement()
        {
            InitializeComponent();
            _estimateDetailStatementPresenter = new EstimateDetailStatementPresenter(this);
            _estimateDetailStatementPartBsPresenter = new EstimateDetailStatementPartBsPresenter(this);
            _estimateDetailStatementFixedAssetsPresenter = new EstimateDetailStatementFixedAssetsPresenter(this);
            _repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
            _repositoryNumberCalcEdit = new RepositoryItemCalcEdit();
            _dbOptionHelper = new GlobalVariable();
            _repositoryCurrencyCalcEdit.EditFormat.FormatType = FormatType.Numeric;
            _repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
            _repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + _dbOptionHelper.CurrencyDecimalDigits;
            _repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
            _repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;

            _repositoryNumberCalcEdit.EditFormat.FormatType = FormatType.Numeric;
            _repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
            _repositoryNumberCalcEdit.Mask.EditMask = @"n0";
            _repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            _repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraEstimateDetailStatement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraEstimateDetailStatement_Load(object sender, EventArgs e)
        {
            memoDescriptionForBuilding.Text = "4.2 - Nhà thuê: Báo cáo chi tiết địa chỉ, diện tích, số phòng, giá tiền thuê (USD), thời hạn hợp đồng từng căn hộ (Ngày ký, ngày hết hạn hợp đồng). CQĐD kiến nghị gia hạn hoặc thuê đổi trong năm " + DateTime.Parse(_dbOptionHelper.PostedDate).Year + ", " + (DateTime.Parse(_dbOptionHelper.PostedDate).Year +1) + " nếu hết hạn hợp đồng thuê.";
            memoEmployeeContractDescription.Text = " - Chi tiết công việc người địa phương hoặc lao động hợp đồng đang đảm nhiệm, mức lương đang hưởng/1 tháng (quy USD), thời điểm bắt đầu thuê, thời hạn của hợp đồng. Bảo hiểm và trang phục/1 năm (nếu có).";
            memoEmployeeContractDescription.Text = memoEmployeeContractDescription.Text + "\r\n- CQĐD có kiến nghị ra hạn hoặc thuê mới người địa phương trong năm " + DateTime.Parse(_dbOptionHelper.PostedDate).Year + ", đề nghị kê chi tiết.";
            memoGeneralDescription.Text = "1. Biên chế CBNV: Danh sách cán bộ nhân viên và phu nhân, phu quân (kể cả phu nhân/phu quân theo Nghị định số 48/2012/NĐ-CP ngày 04/6/2012) trong bảng nhận SHP của CQĐD đến thời điểm tháng 6 năm " + DateTime.Parse(_dbOptionHelper.PostedDate).Year + " (ghi chi tiết chức danh, chỉ số SHP, phụ cấp nữ, kiêm nhiệm, ngày đến nhận công tác, ngày hết nhiệm kỳ công tác (dd/MM/yyyy),….)" + Environment.NewLine + "SHP tối thiểu :" + _dbOptionHelper.BaseOfSalary + _dbOptionHelper.CurrencyAccounting;
            spinYearOfPlaning.EditValue = DateTime.Parse(_dbOptionHelper.PostedDate).Year;
            memoInventoryDescription.Text = @"Có liệt kê trong Biên bản kiểm kê tài sản cố định";
            _estimateDetailStatementPresenter.Display(true);
            _estimateDetailStatementPartBsPresenter.Display();
            _estimateDetailStatementFixedAssetsPresenter.Display();
            grdPartB.ForceInitialize();
            gridFixedAsset.ForceInitialize();


        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            _estimateDetailStatementPresenter.Save();
            _estimateDetailStatementPartBsPresenter.Save(EstimateDetailStatementPartB);
            _estimateDetailStatementFixedAssetsPresenter.Save(EstimateDetailStatementFixedAsset);
        }

        /// <summary>
        /// Sets the payment estimates.
        /// </summary>
        /// <value>
        /// The payment estimates.
        /// </value>
        public IList<EstimateDetailStatementPartBModel> EstimateDetailStatementPartB
        {
            get
            {
                var estimateDetailStatementPartB = new List<EstimateDetailStatementPartBModel>();
                if (gridView1.DataSource != null && gridView1.RowCount > 0)
                {
                    for (var i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRow(i) != null)
                        {
                            var item = new EstimateDetailStatementPartBModel
                                {
                                    EstimateDetailStatementPartBId =
                                        (int)gridView1.GetRowCellValue(i, "EstimateDetailStatementPartBId"),
                                    OrderNumber = (short)gridView1.GetRowCellValue(i, "OrderNumber"),
                                    Description = (string)gridView1.GetRowCellValue(i, "Description"),
                                    Amount = (decimal)gridView1.GetRowCellValue(i, "Amount"),
                                    Note = (string)gridView1.GetRowCellValue(i, "Note"),
                                    IsActive = (bool)gridView1.GetRowCellValue(i, "IsActive"),
                                };
                            estimateDetailStatementPartB.Add(item);
                        }
                    }
                }
                return estimateDetailStatementPartB.ToList();
            }
            set
            {
                bindingSourceDetail.DataSource = value.Count == 0
                                                     ? new List<EstimateDetailStatementPartBModel>()
                                                     : value;
                gridView1.PopulateColumns(value);
                //var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                //var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                var columnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "EstimateDetailStatementPartBId", ColumnVisible = false},
                        new XtraColumn
                            {
                                ColumnName = "OrderNumber",
                                ColumnCaption = "Số TT",
                                ColumnPosition = 1,
                                ColumnWith = 50,
                                ColumnVisible = true,
                                AllowEdit = true,
                                Alignment = HorzAlignment.Center,
                                ColumnType = UnboundColumnType.Integer,
                                RepositoryControl = _repositoryNumberCalcEdit
                            },
                        new XtraColumn
                            {
                                ColumnName = "Description",
                                ColumnCaption = "Diễn giải",
                                ColumnPosition = 2,
                                ColumnVisible = true,
                                ColumnWith = 300,
                                AllowEdit = true
                            },
                        new XtraColumn
                            {
                                ColumnName = "Amount",
                                ColumnCaption = "Số tiền tăng (giảm)",
                                ColumnPosition = 3,
                                ColumnVisible = true,
                                ColumnWith = 150,
                                AllowEdit = true,
                                Alignment = HorzAlignment.Far,
                                DisplayFormat = "F2",
                                ColumnType = UnboundColumnType.Decimal,
                                RepositoryControl = _repositoryCurrencyCalcEdit
                            },
                        new XtraColumn
                            {
                                ColumnName = "Note",
                                ColumnCaption = "Ghi chú",
                                ColumnPosition = 4,
                                ColumnVisible = true,
                                ColumnWith = 200,
                                AllowEdit = true
                            },
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridView1.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView1.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView1.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridView1.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridView1.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridView1.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridView1.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridView1.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridView1.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else gridView1.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        public IList<EstimateDetailStatementFixedAssetModel> EstimateDetailStatementFixedAsset
        {
            get
            {
                var estimateDetailStatementFixedAsset = new List<EstimateDetailStatementFixedAssetModel>();
                if (gridFixedAssetView.DataSource != null && gridFixedAssetView.RowCount > 0)
                {
                    for (var i = 0; i < gridFixedAssetView.RowCount; i++)
                    {
                        if (gridFixedAssetView.GetRow(i) != null)
                        {
                            var item = new EstimateDetailStatementFixedAssetModel
                            {
                                EstimateDetailStatementFixedAssetId = (int)gridFixedAssetView.GetRowCellValue(i, "EstimateDetailStatementFixedAssetId"),
                                OrderNumber = (int)gridFixedAssetView.GetRowCellValue(i, "OrderNumber"),
                                PurchasedYear = (int)gridFixedAssetView.GetRowCellValue(i, "PurchasedYear"),
                                OrgPriceUsd = (decimal)gridFixedAssetView.GetRowCellValue(i, "OrgPriceUsd"),
                                PurchasedOrgPriceUsd = (decimal)gridFixedAssetView.GetRowCellValue(i, "PurchasedOrgPriceUsd"),
                                Department = (string)gridFixedAssetView.GetRowCellValue(i, "Department"),
                                ReplacementReason = (string)gridFixedAssetView.GetRowCellValue(i, "ReplacementReason"),
                                PostedYear = (int)gridFixedAssetView.GetRowCellValue(i, "PostedYear"),
                                IsActive = (bool)gridFixedAssetView.GetRowCellValue(i, "IsActive"),
                            };
                            estimateDetailStatementFixedAsset.Add(item);
                        }
                    }
                }
                return estimateDetailStatementFixedAsset.ToList();
            }
            set
            {
                bindingSourceFixedAsset.DataSource = value.Count == 0
                                                     ? new List<EstimateDetailStatementFixedAssetModel>()
                                                     : value;
                gridFixedAssetView.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "EstimateDetailStatementFixedAssetId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrderNumber",ColumnCaption = "Số TT",ColumnPosition = 1,ColumnWith = 50,ColumnVisible = true,
                            AllowEdit = true,Alignment = HorzAlignment.Center,ColumnType = UnboundColumnType.Integer},
                        new XtraColumn {ColumnName = "PurchasedYear",ColumnCaption = "Năm mua tt/bs",ColumnPosition = 3,ColumnVisible = true,ColumnWith = 60,AllowEdit = true,
                            Alignment = HorzAlignment.Far,DisplayFormat = "F2",ColumnType = UnboundColumnType.Integer},
                        new XtraColumn {ColumnName = "OrgPriceUsd",ColumnCaption = "Nguyên giá (quy USD) tt/bs",ColumnPosition = 3,ColumnVisible = true,ColumnWith = 150,AllowEdit = true,
                            Alignment = HorzAlignment.Far,DisplayFormat = "F2",ColumnType = UnboundColumnType.Decimal,RepositoryControl = _repositoryCurrencyCalcEdit},
                        new XtraColumn {ColumnName = "PurchasedOrgPriceUsd",ColumnCaption = "Nguyên giá TTB dự kiến ",ColumnPosition = 3,ColumnVisible = true,ColumnWith = 150,AllowEdit = true,
                            Alignment = HorzAlignment.Far,DisplayFormat = "F2",ColumnType = UnboundColumnType.Decimal,RepositoryControl = _repositoryCurrencyCalcEdit},
                        new XtraColumn {ColumnName = "Department",ColumnCaption = "Bộ phận",ColumnPosition = 4,ColumnVisible = true,ColumnWith = 200,AllowEdit = true},
                        new XtraColumn {ColumnName = "ReplacementReason",ColumnCaption = "Lý do thay thế",ColumnPosition = 5,ColumnVisible = true,ColumnWith = 200,AllowEdit = true},
                        new XtraColumn {ColumnName = "PostedYear", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridFixedAssetView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridFixedAssetView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridFixedAssetView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridFixedAssetView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridFixedAssetView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridFixedAssetView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else gridFixedAssetView.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        #region Delete row PartB
        /// <summary>
        /// Handles the PopupMenuShowing event of the gridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu.ShowPopup(grdPartB.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Deletes the row item.
        /// </summary>
        protected virtual void DeleteRowItem()
        {
            gridView1.DeleteSelectedRows();
        }

        /// <summary>
        /// Handles the 1 event of the barButtonDeleteRowItem_ItemClick control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void barButtonDeleteRowItem_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            DeleteRowItem();
        }

        #endregion

        #region menu Delete row PartB
        private void gridFixedAssetView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenuPartC.ShowPopup(gridFixedAsset.PointToScreen(e.Point));
                }
            }
        }

        protected virtual void DeleteRowItemPartC()
        {
            gridFixedAssetView.DeleteSelectedRows();
        }

        private void barButtonItemDeletePartC_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRowItemPartC();
        }


        #endregion

        
    }
}