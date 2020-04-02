/***********************************************************************
 * <copyright file="BaseVoucherListUserControl.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, February 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace TSD.AccountingSoft.WindowsForm.BaseUserControls
{
    /// <summary>
    /// BaseVoucherListUserControl
    /// </summary>
    public partial class BaseVoucherListUserControl : XtraUserControl, IAudittingLogView, IRefTypesView, ILockView
        , IVoucherTypesView
    {
        #region Reponsitory

        protected RepositoryItemGridLookUpEdit _rpsVoucherType;

        #endregion

        #region Presenters

        protected VoucherTypesPresenter _voucherTypesPresenter;
        private readonly LockPresenter _lockPresenter;
        private readonly AudittingLogPresenter _audittingLogPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;


        #endregion

        #region Variables



        protected int SelectedRowIndex;

        /// <summary>
        /// The e action mode
        /// </summary>
        public ActionModeVoucherEnum ActionMode;

        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        /// <summary>
        /// The primary key value
        /// </summary>
        public string PrimaryKeyValue;

        /// <summary>
        /// The _global variable
        /// </summary>
        private GlobalVariable _globalVariable;


        /// <summary>
        /// The posted date
        /// </summary>
        protected string PostedDate;


        /// <summary>
        /// The database option helper
        /// </summary>
        //   protected GlobalVariable DBOptionHelper;

        #endregion

        #region Properties

        #region LockDate Properties

        public string Content
        {
            get;
            set;
        }
        public DateTime LockDate
        {
            get;
            set;
        }
        public bool IsLock
        {
            get;
            set;
        }

        #endregion

        #region AuditingLog Properties

        private string RefNo { get; set; }
        public int EventId { get; set; }
        public string LoginName
        {
            get { return GlobalVariable.LoginName; }
            set { }
        }
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }
        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }
        public string ComponentName
        {
            get
            {
                if (!DesignMode)
                {
                    var formCaption = "";
                    var firstOrDefault = RefTypes.FirstOrDefault(r => r.RefTypeId == (int)RefTypeId);
                    if (firstOrDefault != null)
                    {
                        var refTypeName = firstOrDefault.RefTypeName;
                        formCaption = refTypeName;
                    }
                    return (string.IsNullOrEmpty(formCaption) ? "" : formCaption);
                }
                return "";
            }
            set { }
        }
        public int EventAction
        {
            get
            {
                switch (ActionMode)
                {
                    case ActionModeVoucherEnum.AddNew:
                        return 1;
                    case ActionModeVoucherEnum.Edit:
                        return 2;
                    case ActionModeVoucherEnum.Delete:
                        return 3;
                    case ActionModeVoucherEnum.None:
                        return 4;
                    default:
                        return 5;//Nhân bản
                }
            }
            set { }
        }
        public string Reference
        {
            get
            {
                switch (ActionMode)
                {
                    case ActionModeVoucherEnum.AddNew:
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    case ActionModeVoucherEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    case ActionModeVoucherEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    case ActionModeVoucherEnum.None:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    default:
                        return "NHÂN BẢN " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                }
            }
            set { }
        }
        public decimal Amount { get; set; }

        #endregion

        [Category("BaseProperty")]
        public string FormDetail { get; set; }
        [Category("BaseProperty")]
        public string NamespaceForm { get; set; }
        [Category("BaseProperty")]
        public string TablePrimaryKey { get; set; }
        [Category("BaseProperty")]
        public string FormCaption { get; set; }
        [Category("BaseProperty")]
        public int RowSelected { get; set; }
        [Category("BaseProperty")]
        public RefType RefTypeId { get; set; }
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        public IList<RefTypeModel> RefTypes { get; set; }

        public virtual IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                if (_rpsVoucherType == null) _rpsVoucherType = new RepositoryItemGridLookUpEdit();
                GridLookUpItem.VoucherType(value ?? new List<VoucherTypeModel>(), _rpsVoucherType, "VoucherTypeName", "VoucherTypeId");
            }
        }


        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            // DBOptionHelper = new GlobalVariable();
            Text = FormCaption;
            grdList.Focus();
            InitControls();
        }
        protected virtual void InitControls()
        {

        }
        /// <summary>
        /// Initializes the variables.
        /// </summary>
        private void InitVariables()
        {
            ActionMode = ActionModeVoucherEnum.None;
            _globalVariable = new GlobalVariable();
            PostedDate = _globalVariable.PostedDate;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        protected void LoadData()
        {
            try
            {
                gridView.BeginUpdate();
                LoadDataIntoGrid();
                LoadGridLayout();
                SetGridNumericFormat();
                grdList.ForceInitialize();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                gridView.EndUpdate();
            }
            finally
            {
                gridView.EndUpdate();
                ActionMode = ActionModeVoucherEnum.None;
            }
        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        private void LoadGridLayout()
        {
            gridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            if (ColumnsCollection != null)
            {
                foreach (GridColumn gridColumn in gridView.Columns)
                {
                    gridColumn.Visible = false;
                }

                foreach (var column in ColumnsCollection)
                {
                    if (gridView.Columns[column.ColumnName] != null)
                        if (column.ColumnVisible)
                        {
                            gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridView.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        }
                        else
                            gridView.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        protected void LoadGridLayout(GridView grdView, List<XtraColumn> columnCollections)
        {
            grdView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            if (columnCollections != null)
            {
                foreach (GridColumn grdColumn in grdView.Columns)
                {
                    var column = columnCollections.Where(w => w.ColumnName == grdColumn.FieldName && w.ColumnVisible == true)?.FirstOrDefault() ?? null;
                    if (column != null)
                    {
                        grdColumn.Caption = column.ColumnCaption;
                        grdColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        grdColumn.VisibleIndex = column.ColumnPosition;
                        grdColumn.Width = column.ColumnWith;
                        grdColumn.AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        grdColumn.UnboundType = column.ColumnType;
                        grdColumn.ColumnEdit = column.RepositoryControl;
                        grdColumn.ToolTip = column.ToolTip;
                        grdColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    }
                    else
                        grdColumn.Visible = false;
                }
            }
        }

        /// <summary>
        /// Sets the row selected.
        /// </summary>
        private void SetRowSelected(int rowHandler = 0)
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (gridView.RowCount > 0)
            {
                gridView.MakeRowVisible(rowHandler);
                gridView.FocusedRowHandle = rowHandler;
            }
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
        /// <returns></returns>
        public void GetRowValueSelected()
        {
            try
            {
                if (gridView.DataSource != null)
                {
                    var rowHandle = gridView.FocusedRowHandle;
                    if (!DesignMode)
                    {
                        if (ActionMode == ActionModeVoucherEnum.None || ActionMode == ActionModeVoucherEnum.Delete)
                            PrimaryKeyValue = gridView.GetRowCellValue(rowHandle, TablePrimaryKey) != null
                                                  ? gridView.GetRowCellValue(rowHandle, TablePrimaryKey).ToString()
                                                  : null;
                    }
                    gridView.MakeRowVisible(rowHandle);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        protected void ShowFormDetail()
        {
            try
            {
                using (var frmDetail = GetFormDetail())
                {
                    frmDetail.ActionMode = ActionMode;
                    frmDetail.KeyValue = frmDetail.ActionMode == ActionModeVoucherEnum.AddNew
                                             ? null
                                             : PrimaryKeyValue;
                    frmDetail.PostKeyValue += FrmDetail_PostKey;
                    frmDetail.MasterBindingSource = bindingSource;
                    SelectedRowIndex = bindingSource.Position;
                    frmDetail.CurrentPosition = SelectedRowIndex;
                    frmDetail.HelpTopicId = HelpTopicId;

                    if (ActionMode == ActionModeVoucherEnum.AddNew)
                    {
                        bindingSource.AddNew();
                        bindingSource.MoveLast();
                    }
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected virtual FrmXtraBaseVoucherDetail GetFormDetail()
        {
            try
            {
                return new FrmXtraBaseVoucherDetail();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Sets the row after update.
        /// </summary>
        protected void SetRowAfterUpdate()
        {
            try
            {
                if (gridView.RowCount <= 0) return;
                var xtraColumn = gridView.Columns[TablePrimaryKey];
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    var currentValue = gridView.GetRowCellValue(i, xtraColumn).ToString();
                    if (PrimaryKeyValue != currentValue) continue;
                    RowSelected = i; break;
                }
                SetRowSelected(RowSelected);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// FRMs the detail_ post key.
        /// LinhMC bổ sung thêm 1 số lệnh để điều kiển lại việc nạp dữ liệu trên list
        /// nếu không có các lệnh này, thì khi lưu lần thứ nhất, nhấn thêm chứng từ, 
        /// rồi nhấn hoãn sẽ bị trường hợp dữ liệu bị rỗng
        /// LoadDataIntoGrid();
        /// LoadGridLayout();
        /// SetGridNumericFormat();
        /// bindingSource.MoveFirst(); ---LinhMC bỏ dòng này để focus vào dòng được thêm hoặc sửa
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void FrmDetail_PostKey(object sender, string data)
        {
            PrimaryKeyValue = data;
            LoadDataIntoGrid();
            LoadGridLayout();
            SetGridNumericFormat();
            SetRowAfterUpdate();
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected virtual void RefreshToolbar()
        {
            barButtonEditItem.Enabled = gridView.RowCount > 0;
            barButtonDuplicate.Enabled = gridView.RowCount > 0;
            barButtonDeleteItem.Enabled = gridView.RowCount > 0;
            barButtonPrintItem.Enabled = gridView.RowCount > 0;
            barButtonCalculatePriceItem.Enabled = gridView.RowCount > 0;
            if (RefTypeId == RefType.OutwardStock)
            {
                barButtonCalculatePriceItem.Visibility = BarItemVisibility.Always;
            }

        }

        /// <summary>
        /// Sets the grid numeric format.
        /// </summary>
        protected virtual void SetGridNumericFormat()
        {
            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        oCol.DisplayFormat.FormatString = GlobalVariable.CurrencyDisplayString;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                        oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                        oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.Integer:
                        oCol.DisplayFormat.FormatString = GlobalVariable.NumericDisplayString;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        #endregion

        #region Functions overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected virtual void LoadDataIntoGrid()
        {
        }

        protected virtual void LoadDataIntoGridDetail(long refId)
        {
            switch (RefTypeId)
            {
                case RefType.ReceiptEstimate:
                    break;
                case RefType.PaymentEstimate:
                    break;
                case RefType.ReceiptCash:
                    break;
                case RefType.PaymentCash:
                    var ds = gridView.DataSource as IList<CashModel>;
                    if (ds != null)
                    {
                        bindingSourceDetail.DataSource = ds.First(c => c.RefId == refId);
                    }
                    break;
                case RefType.ReceiptDeposite:
                    break;
                case RefType.PaymentDeposite:
                    break;
                case RefType.InwardStock:
                    break;
                case RefType.OutwardStock:
                    break;
                case RefType.FixedAssetIncrement:
                    break;
                case RefType.FixedAssetDecrement:
                    break;
                case RefType.FixedAssetArmortization:
                    break;
                case RefType.OpeningAccountEntry:
                    break;
                case RefType.GeneralVoucher:
                    break;
                case RefType.CaptitalAllocateVoucher:
                    break;
                case RefType.AccountTranferVourcher:
                    break;
                case RefType.Salary:
                    break;
                case RefType.FixedAssetDictionary:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected virtual void DeleteGrid()
        {
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        protected virtual void AddData()
        {
            ActionMode = ActionModeVoucherEnum.AddNew;
            ShowFormDetail();
            LoadData();
        }

        protected virtual void DuplicateData()
        {
            ActionMode = ActionModeVoucherEnum.DuplicateVoucher;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Shows the data.
        /// </summary>
        protected virtual void ShowData()
        {
            ActionMode = ActionModeVoucherEnum.None;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Edits the data.
        /// </summary>
        protected virtual void EditData()
        {
            if (PrimaryKeyValue == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn chứng từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lockPresenter.CheckLockDate(int.Parse(PrimaryKeyValue ?? "0"), (int)RefTypeId))
            {
                XtraMessageBox.Show("Chứng từ hiện tại đang khóa sổ. Bạn phải mở sổ để sửa chứng từ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActionMode = ActionModeVoucherEnum.Edit;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Prints the data.
        /// </summary>
        protected virtual void PrintData()
        {
        }

        /// <summary>
        /// Helps this instance.
        /// </summary>
        protected virtual void ShowHelp()
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(HelpTopicId));
        }

        /// <summary>
        /// Calculates the price outward stock.
        /// </summary>
        protected virtual void CalculatePriceOutwardStock()
        {
            var frm = new FrmXtraReCalOutputInventory();
            frm.ShowDialog();
        }

        // ThangNK bổ sung
        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + _globalVariable.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
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

        #region Events

        public BaseVoucherListUserControl()
        {
            InitializeComponent();
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _lockPresenter = new LockPresenter(this);
            GlobalVariable.CurrencyType = 0;
           
            
           

        }

        /// <summary>
        /// Handles the Load event of the BaseVoucherListUserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BaseVoucherListUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            InitializeLayout();
            InitVariables();
            _refTypesPresenter.Display();
            _lockPresenter.Display();
            LoadData();
            SetRowSelected(RowSelected);
            GetRowValueSelected();
            RefreshToolbar();
           
        }

        /// <summary>
        /// Handles the FocusedRowChanged event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs"/> instance containing the event data.</param>
        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetRowValueSelected();
            var column = gridView.Columns.ColumnByFieldName("RefNo");

            if (column != null)
            {
                var refNo = gridView.GetRowCellValue(e.FocusedRowHandle, column);
                RefNo = (refNo != null) ? refNo.ToString() : "";
            }
            var columnRefId = gridView.Columns.ColumnByFieldName("RefId");

            if (columnRefId != null)
            {
                var refId = gridView.GetRowCellValue(e.FocusedRowHandle, columnRefId);

                if (refId != null)
                {
                    LoadDataIntoGridDetail((long)refId);
                }
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void grdList_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0) return;
            ShowData();
            SetRowAfterUpdate();
            GetRowValueSelected();
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        private void barToolManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonAddNewItem":
                    AddData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonDuplicate":
                    DuplicateData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonEditItem":
                    if (PrimaryKeyValue == null)
                    {
                        XtraMessageBox.Show("Bạn chưa chọn chứng từ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    EditData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonDeleteItem":
                    var deleteSuccess = false;
                    try
                    {
                        if (PrimaryKeyValue == null)
                        {
                            XtraMessageBox.Show("Bạn chưa chọn chứng từ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (_lockPresenter.CheckLockDate(Int32.Parse(PrimaryKeyValue), (int)RefTypeId))
                        {
                            var result1 = XtraMessageBox.Show("Chứng từ đang khóa sổ. Bạn phải mở sổ để xóa", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        ActionMode = ActionModeVoucherEnum.Delete;
                        var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"),
                                                         ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            DeleteGrid();
                            _audittingLogPresenter.Save();
                            deleteSuccess = true; //LinhMC chạy đến đây là ok rồi
                            if (((IList)bindingSource.DataSource).Count == 0)
                                bindingSourceDetail = null;
                            if (RefTypeId != RefType.InwardStock)
                            {
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                                    ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                    }
                    finally
                    {
                        if (deleteSuccess)
                        {
                            LoadData();
                            SetRowSelected();
                            GetRowValueSelected();
                        }
                    }
                    break;
                case "barButtonRefeshItem":
                    LoadData();
                    SetRowSelected();
                    GetRowValueSelected();
                    break;
                case "barButtonPrintItem":
                    PrintData();
                    break;
                case "barButtonHelpItem":
                    ActionMode = ActionModeVoucherEnum.None;
                    ShowHelp();
                    break;
                case "barButtonCalculatePriceItem":
                    CalculatePriceOutwardStock();
                    break;
            }
            RefreshToolbar();
        }

        /// <summary>
        /// Handles the BeforePopup event of the popupMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            Point p = grdList.PointToClient(MousePosition);
            GridHitInfo hitInfo = gridView.CalcHitInfo(p);

            if (hitInfo.HitTest != GridHitTest.RowCell)
            {
                e.Cancel = true;
            }
        }
        #endregion

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            barManager2.ActiveEditItemLink.PostEditor(); //KienNt-dòng này bắt buộc có để cập nhật lại value của checkbox sau khi changed
            GlobalVariable.CurrencyType = int.Parse(barEditItem1.EditValue.ToString());
            LoadData();
            SetRowSelected();
            GetRowValueSelected();
            RefreshToolbar();
        }

        private void barEditItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
