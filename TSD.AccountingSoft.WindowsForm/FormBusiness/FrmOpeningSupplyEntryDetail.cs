/***********************************************************************
 * <copyright file="FrmOpeningSupplyEntryDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, July 19, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
//using TSD.AccountingSoft.WindowsForm.Code.PropertyGrid;
using TSD.AccountingSoft.View.OpeningSupplyEntry;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Opening;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Mask;
using TSD.AccountingSoft.Session;
using System.Threading;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using System.IO;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.WindowsForm.FormBase;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness.OpeningAccount
{
    public partial class FrmOpeningSupplyEntryDetail : XtraForm, IDepartmentsView, IOpeningSupplyEntriesView, IInventoryItemsView
    {
        #region Variables

        private RepositoryItemGridLookUpEdit _rpsDepartment;
        private RepositoryItemGridLookUpEdit _rpsInventoryItem;
        private RepositoryItemGridLookUpEdit _rpsCurrency;


        RepositoryItemCalcEdit _rpsCalcNumber = new RepositoryItemCalcEdit { AllowMouseWheel = false };
        

        bool _flagKey;

        GlobalVariable globalVariable = new GlobalVariable();
        string CurrencyAccounting;
        string CurrencyLocal;

        #endregion

        #region Presenter

        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly OpeningSupplyEntriesPresenter _openingSupplyEntriesPresenter;

        #endregion

        #region Properties

        public ActionModeVoucherEnum ActionMode { get; set; }

        public IList<DepartmentModel> Departments
        {
            set
            {
                if (value == null)
                    value = new List<DepartmentModel>();
                if (_rpsDepartment == null)
                {
                    _rpsDepartment = new RepositoryItemGridLookUpEdit();
                    _rpsDepartment.Popup += _rpsDepartment_Popup;
                    _rpsDepartment.KeyPress += _rpsDepartment_KeyPress;
                }
                GridLookUpItem.Department(value, _rpsDepartment, "DepartmentCode", "DepartmentId");
            }
        }

        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<InventoryItemModel>();
                    if (_rpsInventoryItem == null)
                    {
                        _rpsInventoryItem = new RepositoryItemGridLookUpEdit();
                        _rpsInventoryItem.Popup += _rpsInventoryItem_Popup;
                        _rpsInventoryItem.KeyPress += _rpsInventoryItem_KeyPress;
                    }
                    GridLookUpItem.InventoryItem(value, _rpsInventoryItem, "InventoryItemCode", "InventoryItemId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<OpeningSupplyEntryModel> OpeningSupplyEntries
        {
            get
            {
                var result = bindingSource.DataSource as List<OpeningSupplyEntryModel> ?? new List<OpeningSupplyEntryModel>();
                int i = 1;
                foreach(var item in result)
                {
                    item.RefType = (int)TSD.Enum.RefType.OpeningSupplyEntry;
                    item.PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1);
                    item.RefDate = item.RefDate == default(DateTime) ? DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1) : item.RefDate;
                    item.SortOrder = i;
                    i++;
                }
                return result;
            }
            set
            {
                if (value == null)
                    value = new List<OpeningSupplyEntryModel>();
                else
                {
                    var lstInventoryItems = _rpsInventoryItem.DataSource as List<InventoryItemModel> ?? new List<InventoryItemModel>();
                    foreach (var opening in value.ToList())
                    {
                        var itemName = lstInventoryItems.Where(w => w.InventoryItemId == opening.InventoryItemId)?.FirstOrDefault() ?? new InventoryItemModel();
                        opening.InventoryItemName = itemName.InventoryItemName;
                    }
                }

                bindingSource.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                gridViewDetail.PopulateColumns(value);

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Mã CCDC", ColumnPosition = 1, RepositoryControl = _rpsInventoryItem, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnVisible = true, ColumnWith = 240, ColumnCaption = "Tên CCDC", ColumnPosition = 2, AllowEdit = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Phòng ban", ColumnPosition = 3, RepositoryControl = _rpsDepartment, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Tiền tệ", ColumnPosition = 4, RepositoryControl = _rpsCurrency, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Tỉ giá", ColumnPosition = 5, RepositoryControl = _rpsCalcNumber, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Số lượng tồn", ColumnPosition = 6, RepositoryControl = _rpsCalcNumber, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Giá trị tồn", ColumnPosition = 7, RepositoryControl = _rpsCalcNumber, IsSummnary = true, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Giá trị tồn QĐ", ColumnPosition = 8, RepositoryControl = _rpsCalcNumber, IsSummnary = true, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOc", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Đơn giá tồn", ColumnPosition = 9, RepositoryControl = _rpsCalcNumber, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Đơn giá tồn QĐ", ColumnPosition = 10, RepositoryControl = _rpsCalcNumber, AllowEdit = true });
                

                gridViewDetail = InitGridLayout(columnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        #endregion

        #region Functions

        private void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryDateEdit = new RepositoryItemDateEdit() { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits2;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits2);
                        }
                        else if (oCol.Name.Equals("UnitPriceOC"))
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits2;
                            repositoryCurrencyCalcEdit.Precision = Convert.ToInt32(GlobalVariable.ExchangeRateDecimalDigits2);
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyUnitPriceDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyUnitPriceDigits;
                        }

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
                        repositoryDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                        repositoryDateEdit.Mask.EditMask = @"dd/MM/yyyy";
                        repositoryDateEdit.DisplayFormat.FormatType = FormatType.DateTime;
                        repositoryDateEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryDateEdit;
                        break;
                }
            }
        }

        public GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            GlobalVariable globalVariable = new GlobalVariable();
            foreach (GridColumn grdColumn in grdView.Columns)
            {
                grdColumn.Visible = false;
            }

            foreach (XtraColumn column in columnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                    grdView.Columns[column.ColumnName].Visible = true;
                    grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                    grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                    grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    grdView.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    //switch (column.ColumnType)
                    //{
                    //    case DevExpress.Data.UnboundColumnType.Integer:
                    //        {
                    //            var _rpsCalcNumber = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                    //            _rpsCalcNumber.Mask.MaskType = MaskType.Numeric;
                    //            _rpsCalcNumber.Mask.EditMask = @"n0";
                    //            _rpsCalcNumber.Mask.UseMaskAsDisplayFormat = true;
                    //            _rpsCalcNumber.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    //            grdView.Columns[column.ColumnName].ColumnEdit = _rpsCalcNumber;
                    //        }
                    //        break;
                    //    case DevExpress.Data.UnboundColumnType.Decimal:
                    //        {
                    //            var _rpsCalcNumber = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                    //            _rpsCalcNumber.Mask.MaskType = MaskType.Numeric;
                    //            _rpsCalcNumber.Mask.EditMask = @"c" + globalVariable.CurrencyDecimalDigits;
                    //            _rpsCalcNumber.Mask.UseMaskAsDisplayFormat = true;
                    //            _rpsCalcNumber.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    //            grdView.Columns[column.ColumnName].ColumnEdit = _rpsCalcNumber;
                    //        }
                    //        break;
                    //}
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }

            return grdView;
        }

        private bool ValidData(List<OpeningSupplyEntryModel> openingSupplyEntries)
        {
            int i = 1;
            foreach(var item in OpeningSupplyEntries)
            {
                if (item.ExchangeRate == 0)
                {
                    XtraMessageBox.Show("Tỷ giá tại dòng " + i + " phải khác 0 và 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
                }
                if (item.CurrencyCode == globalVariable.CurrencyLocal && item.ExchangeRate == 1)
                {
                    XtraMessageBox.Show("Tỷ giá tại dòng " + i + " phải khác 0 và 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
                }
                if (item.InventoryItemId == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập công cụ dụng cụ tại dòng " + i + ".", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (item.DepartmentId == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập phòng ban tại dòng " + i + ".", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(item.CurrencyCode))
                {
                    XtraMessageBox.Show("Bạn chưa nhập loại tiền tệ tại dòng " + i + ".", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                i++;
            }
            return true;
        }

        private void InitDefaultCurrency()
        {
            CurrencyAccounting = globalVariable.CurrencyAccounting;
            CurrencyLocal = globalVariable.CurrencyLocal;
            var value = new List<CurrencyModel>();
            if (CurrencyAccounting != CurrencyLocal)
                value = new List<CurrencyModel>
                {
                    new CurrencyModel(){ CurrencyCode = CurrencyAccounting, CurrencyName = CurrencyAccounting },
                    new CurrencyModel(){ CurrencyCode = CurrencyLocal, CurrencyName = CurrencyLocal }
                };
            else
                value = new List<CurrencyModel>
                {
                    new CurrencyModel(){ CurrencyCode = CurrencyAccounting,  CurrencyName = CurrencyAccounting }
                };
            GridLookUpItem.Currency(value, _rpsCurrency);
        }

        #endregion

        #region Events

        public FrmOpeningSupplyEntryDetail()
        {
            InitializeComponent();

            _departmentsPresenter = new DepartmentsPresenter(this);
            _openingSupplyEntriesPresenter = new OpeningSupplyEntriesPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);

            _rpsCurrency = new RepositoryItemGridLookUpEdit();

            _rpsCalcNumber.Mask.MaskType = MaskType.Numeric;
            _rpsCalcNumber.Mask.EditMask = @"c" + globalVariable.CurrencyDecimalDigits;
            _rpsCalcNumber.Mask.UseMaskAsDisplayFormat = true;
            _rpsCalcNumber.Mask.Culture = Thread.CurrentThread.CurrentCulture;
        }

        private void FrmOpeningSupplyEntryDetail_Load(object sender, EventArgs e)
        {
            InitDefaultCurrency();
            _departmentsPresenter.Display();
            _inventoryItemsPresenter.DisplayByIsStockAndIsActiveAndCategoryCode(false, true, "CCDC");
            _openingSupplyEntriesPresenter.Display();

            switch (this.ActionMode)
            {
                case ActionModeVoucherEnum.None:
                    gridViewDetail.OptionsBehavior.Editable = false;
                    gridViewDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    btnOk.Enabled = false;
                    break;
                case ActionModeVoucherEnum.AddNew:
                    this.Text = "Thêm " + ResourceHelper.GetResourceValueByName("ResOpeningSupplyEntryCaption");
                    break;
                case ActionModeVoucherEnum.Edit:
                    this.Text = "Sửa " + ResourceHelper.GetResourceValueByName("ResOpeningSupplyEntryCaption");
                    break;
            }
        }

        private void _rpsInventoryItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _flagKey;
        }

        private void _rpsInventoryItem_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit look = sender as GridLookUpEdit;
            if (look == null)
                return;

            if (bindingSource.DataSource == null)
                return;
            var openingSuppyEntries = ((IList<OpeningSupplyEntryModel>)bindingSource.DataSource).ToList();
            if (openingSuppyEntries.Count == 0)
                return;

            if (look.Properties.DataSource == null)
                return;

            string sFilter = string.Empty;

            var openingSupplyEntryModel = (OpeningSupplyEntryModel)gridViewDetail.GetFocusedRow();
            if (openingSupplyEntryModel == null)
            {
                look.Properties.View.ActiveFilterString = string.Empty;
                return;
            }

            if (gridViewDetail.FocusedRowHandle >= 0)
            {
                // Nếu sửa lại dòng cũ
                // Chưa có phòng ban => chọn tất cả vật tư
                if (openingSupplyEntryModel.DepartmentId == 0)
                {
                    sFilter = string.Empty;
                }
                // Có phòng ban rồi thì bỏ các vật tư mà phòng ban đó đã có
                else
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => m.DepartmentId == openingSupplyEntryModel.DepartmentId).ToList();

                    // Đã có vật tư rồi thì giữ lại chính nó
                    if (openingSupplyEntryModel.InventoryItemId != 0)
                    {
                        openingSuppyEntries = openingSuppyEntries.Where(m => m.InventoryItemId != openingSupplyEntryModel.InventoryItemId).ToList();
                    }

                    sFilter = "NOT [InventoryItemId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.InventoryItemId.ToString(); }).ToArray()) + "')";
                }
            }
            else
            {
                if (openingSupplyEntryModel.DepartmentId != 0)
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => m.DepartmentId == openingSupplyEntryModel.DepartmentId).ToList();
                    sFilter = "NOT [InventoryItemId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.InventoryItemId.ToString(); }).ToArray()) + "')";
                }
                else
                {
                    sFilter = string.Empty;
                }
            }

            look.Properties.View.ActiveFilterString = sFilter;
        }

        private void _rpsDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _flagKey;
        }

        private void _rpsDepartment_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit look = sender as GridLookUpEdit;
            if (look == null)
                return;

            if (bindingSource.DataSource == null)
                return;
            var openingSuppyEntries = ((IList<OpeningSupplyEntryModel>)bindingSource.DataSource).ToList();
            if (openingSuppyEntries.Count == 0)
                return;

            if (look.Properties.DataSource == null)
                return;

            string sFilter = string.Empty;

            var openingSupplyEntryModel = (OpeningSupplyEntryModel)gridViewDetail.GetFocusedRow();
            if (openingSupplyEntryModel == null)
            {
                look.Properties.View.ActiveFilterString = string.Empty;
                return;
            }

            if (gridViewDetail.FocusedRowHandle >= 0)
            {
                // Nếu sửa lại dòng cũ
                // Chưa có vật tư => chọn tất cả phòng ban
                if (openingSupplyEntryModel.InventoryItemId == 0)
                {
                    sFilter = string.Empty;
                }
                // Có vật tư rồi thì bỏ các phòng ban mà vật tư đó đã có
                else
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => m.InventoryItemId == openingSupplyEntryModel.InventoryItemId).ToList();

                    // Đã có phòng ban rồi thì giữ lại chính nó
                    if (openingSupplyEntryModel.DepartmentId != 0)
                    {
                        openingSuppyEntries = openingSuppyEntries.Where(m => m.DepartmentId != openingSupplyEntryModel.DepartmentId).ToList();
                    }

                    sFilter = "NOT [DepartmentId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.DepartmentId.ToString(); }).ToArray()) + "')";
                }
            }
            else
            {
                if (openingSupplyEntryModel.InventoryItemId != 0)
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => m.InventoryItemId == openingSupplyEntryModel.InventoryItemId).ToList();
                    sFilter = "NOT [DepartmentId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.DepartmentId.ToString(); }).ToArray()) + "')";
                }
                else
                {
                    sFilter = string.Empty;
                }
            }

            look.Properties.View.ActiveFilterString = sFilter;
        }

        private void grdOpeningSuppyEntryView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            int rowHandle = gridViewDetail.FocusedRowHandle;
            // Tỷ giá
            if (e.Column.FieldName == "CurrencyCode")
            {
                var currencyCode = (e.Value ?? "").ToString();
                if (currencyCode == globalVariable.CurrencyAccounting)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "ExchangeRate", 1);
                }
            }
            // Tỷ giá
            if (e.Column.FieldName == "ExchangeRate")
            {
                var exchangeRate = Convert.ToDecimal(e.Value ?? 0);
                if (exchangeRate == 0)
                {
                    //gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceOc", 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceExchange", 0);
                    //gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", 0);
                }
                else
                {
                    var unitPrice = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "UnitPriceOc") ?? 0);
                    var amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "AmountOc") ?? 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceExchange", unitPrice / exchangeRate);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amount / exchangeRate);
                }
            }
            // Số lượng
            if (e.Column.FieldName == "Quantity")
            {
                var quantity = Convert.ToDecimal(e.Value ?? 0);
                if(quantity == 0)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", 0);
                }
                else
                {
                    var unitPrice = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "UnitPriceOc") ?? 0);
                    var unitPriceEx = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "UnitPriceExchange") ?? 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", unitPrice * quantity);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", unitPriceEx * quantity);
                }
            }
            // Đơn giá
            if (e.Column.FieldName == "UnitPriceOc")
            {
                var unitPrice = Convert.ToDecimal(e.Value ?? 0);
                if (unitPrice == 0)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceExchange", 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", 0);
                }
                else
                {
                    var exchangeRate = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "ExchangeRate") ?? 0);
                    var quantity = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "Quantity") ?? 0);
                    if (exchangeRate != 0)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceExchange", unitPrice / exchangeRate);
                        gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", unitPrice * quantity);
                        gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", (unitPrice * quantity)/exchangeRate);
                    }
                }
            }
            if (e.Column.FieldName == "UnitPriceExchange")
            {
                var unitPriceEx = Convert.ToDecimal(e.Value ?? 0);
                if (unitPriceEx == 0)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", 0);
                }
                else
                {
                    var quantity = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "Quantity") ?? 0);
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", unitPriceEx * quantity);
                }
            }
            // Giá trị tồn
            if (e.Column.FieldName == "AmountOc")
            {
                var amount = Convert.ToDecimal(e.Value ?? 0);
                var unitPrice = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "UnitPriceOc") ?? 0);
                var quantity = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "Quantity") ?? 0);
                if (amount == 0)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", 0);

                    if (unitPrice != 0)
                        gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceOc", 0);
                }
                else
                {
                    var exchangeRate = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandle, "ExchangeRate") ?? 0);
                    if (exchangeRate != 0)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amount / exchangeRate);
                    }
                    if (quantity != 0 && unitPrice != amount / quantity)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceOc", amount / quantity);
                    }
                }
            }
            // CCDC
            if (e.Column.FieldName.Equals("InventoryItemId"))
            {
                var lstInventoryItems = _rpsInventoryItem.DataSource as List<InventoryItemModel> ?? new List<InventoryItemModel>();
                if (lstInventoryItems == null)
                    return;

                InventoryItemModel iventory = lstInventoryItems.FirstOrDefault(m => m.InventoryItemId.Equals(e.Value));
                if (iventory != null)
                {
                    gridViewDetail.SetRowCellValue(e.RowHandle, "InventoryItemName", iventory.InventoryItemName);
                    gridViewDetail.SetRowCellValue(e.RowHandle, "DepartmentId", iventory.DepartmentId);
                    gridViewDetail.SetRowCellValue(e.RowHandle, "InventoryItemCode", iventory.InventoryItemCode);
                }
                else
                {
                    gridViewDetail.SetRowCellValue(e.RowHandle, "InventoryItemName", string.Empty);
                    gridViewDetail.SetRowCellValue(e.RowHandle, "DepartmentId", string.Empty);
                    gridViewDetail.SetRowCellValue(e.RowHandle, "InventoryItemCode", string.Empty);
                }
            }
        }

        private void grdOpeningSuppyEntryView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenuDetail.ShowPopup(gridDetail.PointToScreen(e.Point));
                }
            }
        }

        private void grdOpeningSuppyEntry_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.Equals(Keys.Control) && e.KeyCode.Equals(Keys.V))
                _flagKey = true;
            else
                _flagKey = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(117));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            gridViewDetail.CloseEditor();
            var openingSupplyEntries = this.OpeningSupplyEntries;
            if (!ValidData(openingSupplyEntries.ToList()))
                return;
            _openingSupplyEntriesPresenter.Save(openingSupplyEntries);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barItemDelete":
                    gridViewDetail.DeleteSelectedRows();
                    break;
            }
        }

        private void gridViewDetail_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "ExchangeRate")
            {
                GridView gridView = sender as GridView;
                int rowHandle = gridView.FocusedRowHandle;

                var currencyCode = (gridViewDetail.GetRowCellValue(rowHandle, "CurrencyCode") ?? "").ToString();
                if (currencyCode.Equals(globalVariable.CurrencyAccounting))
                {
                    gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                }
            }
            else
            {
                gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
            }
        }

        private void gridViewDetail_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var currencyCode = (gridViewDetail.GetRowCellValue(e.FocusedRowHandle, "CurrencyCode") ?? "").ToString();
            if (currencyCode.Equals(globalVariable.CurrencyAccounting))
            {
                gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
            }
        }

        #endregion
    }
}
