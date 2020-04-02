/***********************************************************************
 * <copyright file="BaseListUserControl.cs" company="BUCA JSC">
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
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Report;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Linq;
using DevExpress.XtraBars;

namespace TSD.AccountingSoft.WindowsForm.BaseUserControls
{
    /// <summary>
    /// Class BaseListUserControl.
    /// </summary>
    public partial class BaseListUserControl : XtraUserControl, IReportView, IAudittingLogView
    {
        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// The _report list
        /// </summary>
        private List<ReportListModel> _reportList;

        #region Variables

        /// <summary>
        /// The database option helper
        /// </summary>
        public GlobalVariable _dbOptionHelper;

        /// <summary>
        /// The e action mode
        /// </summary>
        public ActionModeEnum ActionMode;
        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// The primary key value
        /// </summary>
        public string PrimaryKeyValue;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the form detail.
        /// </summary>
        /// <value>The form detail.</value>
        [Category("BaseProperty")]
        public string FormDetail { get; set; }

        /// <summary>
        /// Gets or sets the namespace form.
        /// </summary>
        /// <value>The namespace form.</value>
        [Category("BaseProperty")]
        public string NamespaceForm { get; set; }

        /// <summary>
        /// Gets or sets the table primary key.
        /// </summary>
        /// <value>The table primary key.</value>
        [Category("BaseProperty")]
        public string TablePrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>The form caption.</value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the row selected.
        /// </summary>
        /// <value>The row selected.</value>
        [Category("BaseProperty")]
        public int RowSelected { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>The report identifier.</value>
        [Category("BaseProperty")]
        public string ReportID { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonAddNew { get; set; }

        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonEdit { get; set; }

        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonDelete { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            if (!DesignMode)
                _dbOptionHelper = new GlobalVariable();
            Text = FormCaption;
            ActionMode = ActionModeEnum.None;
            grdList.Focus();

            barButtonAddNewItem.Visibility = VisibleButtonAddNew == false ? BarItemVisibility.Never : BarItemVisibility.Always;
            barButtonEditItem.Visibility = VisibleButtonEdit == false ? BarItemVisibility.Never : BarItemVisibility.Always;
            barButtonDeleteItem.Visibility = VisibleButtonDelete == false ? BarItemVisibility.Never : BarItemVisibility.Always;
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
                ActionMode = ActionModeEnum.None;
            }
        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        public void LoadGridLayout()
        {
            if (ColumnsCollection != null)
            {
                foreach (GridColumn gridColumn in gridView.Columns)
                {
                    gridColumn.Visible = false;
                }
                foreach (XtraColumn column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        GridColumn gridColumn = gridView.Columns[column.ColumnName] ?? null;
                        if (gridColumn != null)
                        {
                            gridColumn.Visible = true;
                            gridColumn.Caption = column.ColumnCaption;
                            gridColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridColumn.VisibleIndex = column.ColumnPosition;
                            gridColumn.Width = column.ColumnWith;
                            gridColumn.AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridColumn.UnboundType = column.ColumnType;
                            gridColumn.ColumnEdit = column.RepositoryControl;
                            gridColumn.ToolTip = column.ToolTip;
                            gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        }
                    }
                }


                //    foreach (GridColumn gridColumn in gridView.Columns)
                //{
                //    XtraColumn xtraColumn = ColumnsCollection.Where(w => w.ColumnName == gridColumn.FieldName && w.ColumnVisible == true)?.FirstOrDefault() ?? null;
                //    if (xtraColumn != null)
                //    {
                //        gridColumn.Caption = xtraColumn.ColumnCaption;
                //        gridColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                //        gridColumn.VisibleIndex = xtraColumn.ColumnPosition;
                //        gridColumn.Width = xtraColumn.ColumnWith;
                //        gridColumn.AppearanceCell.TextOptions.HAlignment = xtraColumn.Alignment;
                //        gridColumn.UnboundType = xtraColumn.ColumnType;
                //        gridColumn.ColumnEdit = xtraColumn.RepositoryControl;
                //        gridColumn.ToolTip = xtraColumn.ToolTip;
                //        gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                //    }
                //    else
                //        gridColumn.Visible = false;
                //}
                //gridView.RefreshData();
                //gridView.BestFitColumns();
            }
        }

        /// <summary>
        /// Sets the row selected.
        /// </summary>
        /// <param name="rowHandler">The row handler.</param>
        protected virtual void SetRowSelected(int rowHandler = 0)
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (gridView.RowCount > 0)
            {
                gridView.FocusedRowHandle = rowHandler;
                gridView.MakeRowVisible(rowHandler);
            }
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
        public void GetRowValueSelected()
        {
            try
            {
                if (gridView.DataSource != null)
                {
                    var rowHandle = gridView.FocusedRowHandle;
                    if (!DesignMode)
                    {
                        if (ActionMode == ActionModeEnum.None || ActionMode == ActionModeEnum.Delete)
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
        private void ShowFormDetail()
        {
            try
            {
                using (var frmDetail = GetFormDetail())
                {
                    if (frmDetail == null)
                    {
                        return;
                    }
                    frmDetail.ActionMode = ActionMode;
                    frmDetail.HelpTopicId = HelpTopicId;

                    frmDetail.KeyValue = frmDetail.ActionMode == ActionModeEnum.AddNew ? null : PrimaryKeyValue;
                    frmDetail.PostKeyValue += FrmDetail_PostKey;

                    if (ActionMode == ActionModeEnum.AddNew)
                    {
                        ListBindingSource.AddNew();
                        ListBindingSource.MoveLast();
                    }
                    frmDetail.BindingSourceDetail = ListBindingSource;
                    if (frmDetail.ShowDialog() == DialogResult.OK) { }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở đây: " + ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// LinhMC comment method này lại.
        /// </summary>
        /// <returns>FrmXtraBaseCategoryDetail.</returns>
        protected virtual FrmXtraBaseCategoryDetail GetFormDetail()
        {
            try
            {
                return new FrmXtraBaseCategoryDetail();
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
                    var currentValue = (gridView.GetRowCellValue(i, xtraColumn) ?? "").ToString();
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
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void FrmDetail_PostKey(object sender, string data)
        {
            PrimaryKeyValue = data;
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected virtual void RefreshToolbar()
        {
            barButtonEditItem.Enabled = gridView.RowCount > 0;
            barButtonDeleteItem.Enabled = gridView.RowCount > 0;
            barButtonPrintItem.Enabled = gridView.RowCount > 0;
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
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + _dbOptionHelper.CurrencyDecimalDigits;
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

        #region Functions overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected virtual void LoadDataIntoGrid()
        {
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
            ActionMode = ActionModeEnum.AddNew;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Edits the data.
        /// </summary>
        protected virtual void EditData()
        {
            ActionMode = ActionModeEnum.Edit;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Prints the data.
        /// </summary>
        protected virtual void PrintData()
        {
            try
            {
                ActionMode = ActionModeEnum.None;
                Cursor.Current = Cursors.WaitCursor;
                var reportHelper = new ReportHelper();
                _reportList = _reportListPresenter.GetAllReportList();
                reportHelper.ReportLists = _reportList;
                reportHelper.PrintPreviewReport(null, ReportID, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Using form name to get help topic id in database
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

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseListUserControl" /> class.
        /// </summary>
        public BaseListUserControl()
        {
            InitializeComponent();
            _reportListPresenter = new ReportListPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

            VisibleButtonAddNew = true;
            VisibleButtonEdit = true;
            VisibleButtonDelete = true;
        }

        /// <summary>
        /// Handles the Load event of the BaseListUserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void BaseListUserControl_Load(object sender, EventArgs e)
        {
            InitializeLayout();
            LoadData();
            SetRowSelected(RowSelected);
            GetRowValueSelected();
            RefreshToolbar();
        }

        /// <summary>
        /// Handles the FocusedRowChanged event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs" /> instance containing the event data.</param>
        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetRowValueSelected();
        }

        /// <summary>
        /// Handles the DoubleClick event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0) return;
            EditData();
            SetRowAfterUpdate();
            GetRowValueSelected();
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs" /> instance containing the event data.</param>
        private void barToolManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonAddNewItem":
                    AddData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonEditItem":

                    if (PrimaryKeyValue == null)
                    {
                        XtraMessageBox.Show("Bạn chưa chọn danh mục cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    EditData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonDeleteItem":
                    try
                    {
                        if (PrimaryKeyValue == null)
                        {
                            XtraMessageBox.Show("Bạn chưa chọn danh mục cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ActionMode = ActionModeEnum.Delete;
                        var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"), ResourceHelper.GetResourceValueByName("ResDeleteCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            DeleteGrid();
                            _audittingLogPresenter.Save();
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") ? "Không thể xóa đối tượng, vì đã được sử dụng trong danh mục hoặc chứng từ" : ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                    }
                    finally
                    {
                        LoadData();
                        SetRowSelected();
                        GetRowValueSelected();
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
                    ActionMode = ActionModeEnum.None;
                    ShowHelp();
                    break;
            }
            RefreshToolbar();
        }

        /// <summary>
        /// Handles the RowStyle event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowStyleEventArgs"/> instance containing the event data.</param>
        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                e.Appearance.BackColor = Color.Moccasin;
            }
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

        #region IReportView Members

        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>The report lists.</value>
        public List<ReportListModel> ReportLists
        {
            get
            {
                return _reportList;
            }
            set
            {
                _reportList = value;
            }
        }

        #endregion

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return GlobalVariable.LoginName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName
        {
            get { return (string.IsNullOrEmpty(FormCaption) ? "" : CommonFunction.FirstCharToUpper(FormCaption)); }
            set { }
        }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        /// <value>
        /// The event action.
        /// </value>
        public int EventAction
        {
            get
            {
                switch (ActionMode)
                {
                    case ActionModeEnum.AddNew:
                        return 1;
                    case ActionModeEnum.Edit:
                        return 2;
                    case ActionModeEnum.Delete:
                        return 3;
                    default:
                        return 4;
                }
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference
        {
            get
            {
                switch (ActionMode)
                {
                    case ActionModeEnum.AddNew:
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                    case ActionModeEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                    case ActionModeEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                    default:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                }
            }
            set { }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        #endregion

        // In thẻ tài sản cố định
        protected virtual void PrintFixedAssetData()
        {
            try
            {
                ActionMode = ActionModeEnum.None;
                Cursor.Current = Cursors.WaitCursor;
                var reportHelper = new ReportHelper();
                _reportList = _reportListPresenter.GetAllReportList();
                reportHelper.ReportLists = _reportList;

                using (var frmXtraPrintVoucherByLot = new FrmXtraPrintVoucherByLot())
                {
                    frmXtraPrintVoucherByLot.RefType = RefType.FixedAssetDictionary;
                    IList<ReportListModel> reportLists = _reportList.FindAll(item => item.ReportID.Contains("ReportFixedAsset"));
                    frmXtraPrintVoucherByLot.InitComboData(reportLists);
                    frmXtraPrintVoucherByLot.RefID = int.Parse(PrimaryKeyValue);
                    if (frmXtraPrintVoucherByLot.ShowDialog() == DialogResult.OK)
                    {
                        var refIds = frmXtraPrintVoucherByLot.SelectedFa;
                        var reportVoucherId = frmXtraPrintVoucherByLot.ReportID;
                        reportHelper.CommonVariable = new GlobalVariable
                        {
                            RefIdList = refIds
                        };

                        if (reportVoucherId != null)
                        {
                            reportHelper.PrintPreviewReport(null, reportVoucherId, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void barButtonPrintFixedAssetItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintFixedAssetData();
        }
        
        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            barManager2.ActiveEditItemLink.PostEditor(); //KienNt-dòng này bắt buộc có để cập nhật lại value của checkbox sau khi changed
            GlobalVariable.CurrencyType = int.Parse(barEditItem2.EditValue.ToString());
            LoadData();
            SetRowSelected();
            GetRowValueSelected();
            RefreshToolbar();
        }
    }
}