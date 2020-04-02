using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Opening;
using TSD.AccountingSoft.View.OpeningSupplyEntry;
//using TSD.AccountingSoft.WindowsForm.Code.PropertyGrid;
//using TSD.AccountingSoft.WindowsForm.FormBase.FormList;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.View.Dictionary;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using DevExpress.XtraGrid;
using System.Linq;
using TSD.AccountingSoft.Session;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness.OpeningAccount
{
    /// <summary>
    /// Số sư đầu kì CCDC không qua kho
    /// </summary>
    public partial class FrmOpeningSupplyEntries : BaseListUserControl, IOpeningSupplyEntriesView, IDepartmentsView, IInventoryItemsView, ICurrenciesView
    {
        #region Presenters

        private readonly OpeningSupplyEntriesPresenter _openingSupplyEntriesPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly CurrenciesPresenter _currenciesPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;

        #endregion

        #region ReponsitoryControl

        private RepositoryItemGridLookUpEdit _rpsDepartment;
        private RepositoryItemGridLookUpEdit _rpsInventoryItem;
        private RepositoryItemGridLookUpEdit _rpsCurrency;

        #endregion

        public FrmOpeningSupplyEntries()
        {
            InitializeComponent();

            _openingSupplyEntriesPresenter = new OpeningSupplyEntriesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _currenciesPresenter = new CurrenciesPresenter(this);
        }

        #region Properties

        public IList<DepartmentModel> Departments
        {
            set
            {
                try
                {
                    if (value == null)
                        return;
                    if (_rpsDepartment == null)
                        _rpsDepartment = new RepositoryItemGridLookUpEdit();
                    GridLookUpItem.Department(value, _rpsDepartment, "DepartmentName", "DepartmentId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<InventoryItemModel> InventoryItems 
        {
            set
            {
                try
                {
                    if (value == null)
                        return;
                    if (_rpsInventoryItem == null)
                        _rpsInventoryItem = new RepositoryItemGridLookUpEdit();
                    GridLookUpItem.InventoryItem(value, _rpsInventoryItem, "InventoryItemCode", "InventoryItemId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<CurrencyModel> Currencies
        {
            set
            {
                if (_rpsCurrency == null)
                    _rpsCurrency = new RepositoryItemGridLookUpEdit();

                GridLookUpItem.Currency(value, _rpsCurrency, "CurrencyCode", "CurrencyCode");
            }
        }

        public IList<OpeningSupplyEntryModel> OpeningSupplyEntries
        {
            get
            {
                return ListBindingSource.DataSource as List<OpeningSupplyEntryModel> ?? new List<OpeningSupplyEntryModel>();
            }
            set
            {
                if (value == null)
                    value = new List<OpeningSupplyEntryModel>();
                else
                {
                    var lstInventoryItems = _rpsInventoryItem.DataSource as List<InventoryItemModel> ?? new List<InventoryItemModel>();
                    foreach(var opening in value.ToList())
                    {
                        var itemName = lstInventoryItems.Where(w => w.InventoryItemId == opening.InventoryItemId)?.FirstOrDefault() ?? new InventoryItemModel();
                        opening.InventoryItemName = itemName.InventoryItemName;
                    }
                }
                //var openningSupply = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() =="USD") : value.Where(x => x.CurrencyCode.Trim() != "USD");
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Mã CCDC", ColumnPosition = 1, RepositoryControl = _rpsInventoryItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnVisible = true, ColumnWith = 250, ColumnCaption = "Tên CCDC", ColumnPosition = 2 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Phòng ban", ColumnPosition = 3, RepositoryControl = _rpsDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Tiền tệ", ColumnPosition = 4, RepositoryControl = _rpsCurrency });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Tỉ giá", ColumnPosition = 5 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Số lượng tồn", ColumnPosition = 6, ColumnType = UnboundColumnType.Decimal, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOc", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Đơn giá tồn", ColumnPosition = 7, ColumnType = UnboundColumnType.Decimal, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Đơn giá tồn QĐ", ColumnPosition = 8, ColumnType = UnboundColumnType.Decimal, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Giá trị tồn", ColumnPosition = 9, ColumnType = UnboundColumnType.Decimal, IsSummnary = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Giá trị tồn QĐ", ColumnPosition = 10, ColumnType = UnboundColumnType.Decimal, IsSummnary = true });

            }
        }

        #endregion

        #region Override functions

        protected override void LoadDataIntoGrid()
        {
            _departmentsPresenter.Display();
            _inventoryItemsPresenter.Display();
            _currenciesPresenter.Display();
            _openingSupplyEntriesPresenter.Display();
        }

        protected override void AddData()
        {
            ShowFormDetail(TSD.Enum.ActionModeVoucherEnum.AddNew);
        }

        protected override void EditData()
        {
            ShowFormDetail(TSD.Enum.ActionModeVoucherEnum.Edit);
        }

        protected override void DeleteGrid()
        {
            new OpeningSupplyEntriesPresenter(null).Delete(long.Parse(PrimaryKeyValue));
        }

        #endregion

        #region Functions

        void ShowFormDetail(TSD.Enum.ActionModeVoucherEnum actionMode)
        {
            try
            {
                var frmDetail = new FrmOpeningSupplyEntryDetail() { ActionMode = actionMode };
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        #endregion
    }
}
