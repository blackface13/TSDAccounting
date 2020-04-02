/***********************************************************************
 * <copyright file="BaseVoucherListDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 August 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using TSD.AccountingSoft.WindowsForm.FormBusiness;

namespace TSD.AccountingSoft.WindowsForm.BaseUserControls
{
    /// <summary>
    /// BaseVoucherListDetail      
    /// </summary>
    public partial class BaseVoucherListDetail : XtraUserControl, IAudittingLogView, IRefTypesView
    {
        #region RefTypes Member

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes { get; set; }

        #endregion

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        private string RefNo { get; set; }

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
            get
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

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        #endregion

        #region Variables

        protected int SelectedRowIndex;

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// The _ref types presenter
        /// </summary>
        private readonly RefTypesPresenter _refTypesPresenter;

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

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the form detail.
        /// </summary>
        /// <value>
        /// The form detail.
        /// </value>
        [Category("BaseProperty")]
        public string FormDetail { get; set; }

        /// <summary>
        /// Gets or sets the namespace form.
        /// </summary>
        /// <value>
        /// The namespace form.
        /// </value>
        [Category("BaseProperty")]
        public string NamespaceForm { get; set; }

        /// <summary>
        /// Gets or sets the table primary key.
        /// </summary>
        /// <value>
        /// The table primary key.
        /// </value>
        [Category("BaseProperty")]
        public string TablePrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>
        /// The form caption.
        /// </value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the row selected.
        /// </summary>
        /// <value>
        /// The row selected.
        /// </value>
        [Category("BaseProperty")]
        public int RowSelected { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        [Category("BaseProperty")]
        public RefType RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
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
            if (ColumnsCollection != null)
            {
                foreach (var column in ColumnsCollection)
                {
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
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The FRM base category detail
        /// LinhMC comment
        /// </summary>
        //private FrmXtraBaseVoucherDetail GetFormDetail()
        //{
        //    try
        //    {
        //        Type typeOfForm = Assembly.GetExecutingAssembly().GetType(NamespaceForm + "." + FormDetail);
        //        return typeOfForm != null ? (FrmXtraBaseVoucherDetail)Activator.CreateInstance(typeOfForm) : null;
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

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

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        protected virtual void LoadDataIntoGridDetail()
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


        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseVoucherListDetail"/> class.
        /// </summary>
        public BaseVoucherListDetail()
        {
            InitializeComponent();
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the BaseVoucherListDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BaseVoucherListDetail_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            InitializeLayout();
            InitVariables();
            _refTypesPresenter.Display();
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
            try
            {
                GetRowValueSelected();
                var column = gridView.Columns.ColumnByFieldName("RefNo");
                if (column != null)
                {
                    RefNo = gridView.GetRowCellValue(e.FocusedRowHandle, column).ToString();
                }

                if (!string.IsNullOrEmpty(PrimaryKeyValue))
                    LoadDataIntoGridDetail();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            //if (gridView.RowCount == 0) return;
            //ShowData();
            //SetRowAfterUpdate();
            //GetRowValueSelected();
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
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
                    try
                    {
                        if (PrimaryKeyValue == null)
                        {
                            XtraMessageBox.Show("Bạn chưa chọn chứng từ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// Handles the Click event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridView_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(PrimaryKeyValue))
            //    LoadDataIntoGridDetail();
        }

        #endregion

        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0) return;
            ShowData();
            SetRowAfterUpdate();
            GetRowValueSelected();
        }
    }
}
