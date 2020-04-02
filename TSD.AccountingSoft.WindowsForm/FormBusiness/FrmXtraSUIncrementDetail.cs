using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using TSD.AccountingSoft.Presenter.Tool;
using TSD.AccountingSoft.View.Tool;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.Session;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraSUIncrementDetail : FrmXtraBaseVoucherDetail, ISUIncrementDecrementView
    {
        #region Presenters

        private readonly SUIncrementDecrementPresenter _sUIncrementDecrementPresenter;

        #endregion

        #region Properties

        public long RefId { get; set; }
        public int RefType
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType)value : BaseRefTypeId; }
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }
        public DateTime RefDate
        {
            get
            {
                return Convert.ToDateTime(dtRefDate.DateTime.ToShortDateString());
            }
            set
            {
                dtRefDate.EditValue = value;
            }
        }
        public DateTime PostedDate
        {
            get
            {
                return Convert.ToDateTime(dtPostDate.DateTime.ToShortDateString());
            }
            set
            {
                dtPostDate.EditValue = value;
            }
        }
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string CurrencyCode
        {
            get
            {
                return (cboCurrency.EditValue ?? "").ToString();
            }
            set
            {
                cboCurrency.EditValue = value;
                if (value == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
            }
        }
        public decimal ExchangeRate
        {
            get
            {
                return Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
            }
            set
            {
                cboExchangRate.EditValue = value;
            }
        }
        public decimal TotalAmountOc
        {
            get
            {
                var depositDetail = (List<SUIncrementDecrementDetailModel>)bindingSourceDetail.DataSource;
                var depositDetailParallel = (List<SUIncrementDecrementDetailModel>)bindingSourceDetailParallel.DataSource;

                return ((depositDetail != null && depositDetail.Count > 0) ? depositDetail.Sum(s => s.AmountOc) : 0) + ((depositDetailParallel != null && depositDetailParallel.Count > 0) ? depositDetailParallel.Sum(s => s.AmountOc) : 0);
            }
            set { }
        }
        public decimal TotalAmountExchange
        {
            get
            {
                var depositDetail = (List<SUIncrementDecrementDetailModel>)bindingSourceDetail.DataSource;
                var depositDetailParallel = (List<SUIncrementDecrementDetailModel>)bindingSourceDetailParallel.DataSource;

                return ((depositDetail != null && depositDetail.Count > 0) ? depositDetail.Sum(s => s.AmountExchange) : 0) + ((depositDetailParallel != null && depositDetailParallel.Count > 0) ? depositDetailParallel.Sum(s => s.AmountExchange) : 0);
            }
            set { }
        }
        public IList<SUIncrementDecrementDetailModel> SUIncrementDecrementDetails
        {
            get
            {
                var result = bindingSourceDetail.DataSource as List<SUIncrementDecrementDetailModel> ?? new List<SUIncrementDecrementDetailModel>();
                TotalAmountOc = result.Sum(s => s.AmountOc);
                TotalAmountExchange = result.Sum(s => s.AmountExchange);
                return result;
            }
            set
            {
                if (value == null)
                    value = new List<SUIncrementDecrementDetailModel>() { new SUIncrementDecrementDetailModel() { DetailBy = ";InventoryItemId;DepartmentId;" } };

                bindingSourceDetail.DataSource = value;

                ColumnsCollection.Clear();
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", FixedColumn = FixedStyle.Left, ColumnCaption = "CCDC", ToolTip = "CCDC", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 120, AllowEdit = true, RepositoryControl = _rpsInventoryItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", FixedColumn = FixedStyle.Left, ColumnCaption = "Diễn giải", ToolTip = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 275, IsSummaryText = true, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", FixedColumn = FixedStyle.None, ColumnCaption = "Phòng ban", ToolTip = "Phòng ban", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 120, AllowEdit = true, RepositoryControl = _rpsDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Số lượng", ToolTip = "Số lượng", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, IsSummnary = true, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền", ToolTip = "Thành tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 125, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Thành tiền QĐ", ToolTip = "Thành tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 125, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, ColumnCaption = "Đơn giá", ToolTip = "Đơn giá", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 125, IsSummnary = true, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Đơn giá QĐ", ToolTip = "Đơn giá quy đổi", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 125, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Đối tượng khác", ToolTip = "Đối tượng khác", ColumnPosition = 10, ColumnVisible = false, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsAccountingObject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", FixedColumn = FixedStyle.None, ColumnCaption = "Khách hàng", ToolTip = "Khách hàng", ColumnPosition = 11, ColumnVisible = false, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsCustomer });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", FixedColumn = FixedStyle.None, ColumnCaption = "Nhà cung cấp", ToolTip = "Nhà cung cấp", ColumnPosition = 12, ColumnVisible = false, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsVendor });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", FixedColumn = FixedStyle.None, ColumnCaption = "Cán bộ", ToolTip = "Cán bộ", ColumnPosition = 13, ColumnVisible = false, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsEmployees });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", FixedColumn = FixedStyle.None, ColumnCaption = "Nguồn vốn", ToolTip = "Nguồn vốn", ColumnPosition = 14, ColumnVisible = false, ColumnWith = 100, AllowEdit = true, RepositoryControl = _rpsBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", FixedColumn = FixedStyle.None, ColumnCaption = "Thứ tự", ToolTip = "Thứ tự", ColumnPosition = 15, ColumnVisible = false, ColumnWith = 70, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        #endregion

        #region Events

        public FrmXtraSUIncrementDetail()
        {
            InitializeComponent();

            _sUIncrementDecrementPresenter = new SUIncrementDecrementPresenter(this);
            this.Load += FrmXtraSUDecrementDetail_Load;
            this.Resize += FrmXtraSUDecrementDetail_Resize;
        }

        private void FrmXtraSUDecrementDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(false, true);
        }

        private void FrmXtraSUDecrementDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(false, true);
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.gridViewDetail_CellValueChanged(sender, e);
            var rowHandle = gridViewDetail.FocusedRowHandle;
            if (e.Column.FieldName == "Description")
            {
                var description = (string)gridViewDetail.GetFocusedRowCellValue("Description");
                txtDescription.Text = description;
            }

            gridViewDetail.PostEditor();
            var exchange = ExchangeRate;
            var quantity = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "Quantity"));
            var amountOc = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc"));
            var amountEx = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange"));
            var unitPriceOc = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "UnitPriceOc"));
            var unitPriceExchange = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "UnitPriceExchange"));
            if (e.Column.FieldName.Equals("AmountOc"))
            {
                if (exchange > 0)
                {
                    if (amountEx * exchange != amountOc)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", Math.Round(amountOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                    }
                }
                if (quantity != 0)
                {
                    if (amountOc / quantity != unitPriceOc)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceOc", Math.Round(amountOc / quantity, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                    }
                }
            }

            if (e.Column.FieldName.Equals("UnitPriceOc"))
            {
                if (exchange > 0)
                {
                    if (unitPriceExchange * exchange != unitPriceOc)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceExchange", Math.Round(unitPriceOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                    }
                    if (unitPriceOc * quantity != amountOc)
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", Math.Round(unitPriceOc * quantity, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                    }
                }
            }

            if (!e.Column.FieldName.Equals("DetailBy"))
            {
                gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", ";InventoryItemId;DepartmentId;");
            }

            if (e.Column.FieldName.Equals("Quantity"))
            {
                if (quantity == 0)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "UnitPriceOc", 0);
                }
                if (unitPriceOc != 0)
                {
                    gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", Math.Round(unitPriceOc * quantity, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
            }

            if (e.Column.FieldName.Equals("InventoryItemId"))
            {
                var inventoryItems = (List<InventoryItemModel>)_rpsInventoryItem.DataSource;
                var inventoryItemId = gridViewDetail.GetRowCellValue(rowHandle, "InventoryItemId");

                if (inventoryItems != null && inventoryItems.Count > 0 && inventoryItemId != null)
                {
                    var inventoryItem = inventoryItems.Where(w => w.InventoryItemId == Convert.ToInt32(inventoryItemId)).FirstOrDefault();
                    if (inventoryItem != null)
                        gridViewDetail.SetRowCellValue(rowHandle, "Description", inventoryItem.InventoryItemName);
                }
            }
        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);
            CurrencyCurrent = CurrencyCode;
        }

        protected override void cboExchangRate_EditValueChanged(object sender, EventArgs e)
        {
            if (gridViewDetail.Columns["AmountOc"] != null && gridViewDetail.Columns["AmountExchange"] != null)
                for (var i = 0; i < gridViewDetail.RowCount; i++)
                {
                    decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "AmountOc") ?? 0);
                    if (ExchangeRate != 0)
                        gridViewDetail.SetRowCellValue(i, "AmountExchange", Math.Round(amount / ExchangeRate, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
            if (gridViewDetail.Columns["UnitPriceOc"] != null && gridViewDetail.Columns["UnitPriceExchange"] != null)
                for (var i = 0; i < gridViewDetail.RowCount; i++)
                {
                    decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "UnitPriceOc") ?? 0);
                    if (ExchangeRate != 0)
                        gridViewDetail.SetRowCellValue(i, "UnitPriceExchange", Math.Round(amount / ExchangeRate, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
        }

        #endregion

        #region Override functions

        protected override void InitControls()
        {
            gridViewDetail.CellValueChanged += gridViewDetail_CellValueChanged;
        }
        protected override void InitData()
        {
            base.InitData();

            //_budgetItemsPrensenter.DisplayIsReceipt();

            if (MasterBindingSource.Current != null)
            {
                var receiptDepositId = ((SUIncrementDecrementModel)MasterBindingSource.Current).RefId;
                KeyValue = receiptDepositId.ToString(CultureInfo.InvariantCulture);
                _keyForSend = KeyValue;
                RefId = long.Parse(KeyValue);
            }

            if (int.Parse(KeyValue) != 0)
            {
                _sUIncrementDecrementPresenter.Display(long.Parse(KeyValue), true);
            }
            else
            {
                RefId = 0;
                KeyValue = null;
                SUIncrementDecrementDetails = new List<SUIncrementDecrementDetailModel>();
                cboObjectCode.EditValue = null;
                CurrencyCode = GlobalVariable.CurrencyType == 0 ? CurrencyAccounting:CurrencyLocal;
                ExchangeRate = 1;
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                AccountingObjectType = null;
                cboObjectCode.Enabled = false;
            }

            grdDetail.DataSource = bindingSourceDetail;
        }
        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            return _sUIncrementDecrementPresenter.Save();
        }
        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            if (ExchangeRate == 0)
            {
                XtraMessageBox.Show("Tỷ giá phải khác 0 và 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            if (CurrencyCode == DBOptionHelper.CurrencyLocal && ExchangeRate == 1)
            {
                XtraMessageBox.Show("Tỷ giá phải khác 0 và 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }

            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }

            if (dtPostDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            if (SUIncrementDecrementDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTotalAmount"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (var suDetail in SUIncrementDecrementDetails)
                {
                    if (suDetail.AmountOc == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    if (suDetail.InventoryItemId == 0)
                    {
                        XtraMessageBox.Show("Bạn chưa nhập CCDC tại dòng " + (i + 1) + ". Vui lòng bổ sung thông tin.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (suDetail.DepartmentId == 0)
                    {
                        XtraMessageBox.Show("Bạn chưa nhập phòng ban tại dòng " + (i + 1) + ". Vui lòng bổ sung thông tin.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (suDetail.Quantity == 0)
                    {
                        XtraMessageBox.Show("Bạn chưa nhập số lượng tại dòng " + (i + 1) + ". Vui lòng bổ sung thông tin.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    i++;
                }
                if (lstRowAmounts.Count > 0)
                    if (DialogResult.No == XtraMessageBox.Show("Số tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return false;
                    }
            }

            return true;
        }
        protected override void DeleteVoucher()
        {
            long refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            _sUIncrementDecrementPresenter.Delete(refId);
        }
        protected override void EditVoucher()
        {
            base.EditVoucher();
            InitData();
            //cboCurrency_EditValueChanged(null, null);
            CurrencyCurrent = CurrencyCode;
        }

        #endregion
    }
}
