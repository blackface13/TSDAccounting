using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.View.Tool;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using DevExpress.XtraEditors.Repository;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using DevExpress.Data;
using DevExpress.Utils;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.Presenter.Tool;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.WindowsForm.Resources;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    public partial class UserControlSUIncrementList : BaseVoucherListUserControl, ISUIncrementDecrementsView, IInventoryItemsView, IDepartmentsView
    {
        private RepositoryItemGridLookUpEdit _rpsInventoryItems;
        private RepositoryItemGridLookUpEdit _rpsDepartment;

        private readonly SUIncrementDecrementsPresenter _sUIncrementDecrementsPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;

        public UserControlSUIncrementList()
        {
            InitializeComponent();

            _sUIncrementDecrementsPresenter = new SUIncrementDecrementsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);

            _inventoryItemsPresenter.Display();
            _departmentsPresenter.Display();
        }

        public IList<SUIncrementDecrementModel> SUIncrementDecrementModels
        {
            set
            {
                var suIncre = new List<SUIncrementDecrementModel>();
                suIncre = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                bindingSource.DataSource = suIncre;
                gridView.PopulateColumns(suIncre);
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "RefType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "RefDate", ColumnCaption = "Ngày CT", Alignment = HorzAlignment.Center, ColumnType = UnboundColumnType.DateTime, ColumnPosition = 3, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnType = UnboundColumnType.DateTime, ColumnPosition = 1, ColumnVisible = true, Alignment = HorzAlignment.Center, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnType = UnboundColumnType.Decimal, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn() { ColumnName = "SUIncrementDecrementDetails", ColumnVisible = false });
            }
        }
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (_rpsInventoryItems == null)
                    _rpsInventoryItems = new RepositoryItemGridLookUpEdit();
                GridLookUpItem.InventoryItem(value, _rpsInventoryItems, "InventoryItemCode", "InventoryItemId");
            }
        }
        public IList<DepartmentModel> Departments
        {
            set
            {
                if (_rpsDepartment == null)
                    _rpsDepartment = new RepositoryItemGridLookUpEdit();
                GridLookUpItem.Department(value, _rpsDepartment, "DepartmentCode", "DepartmentId");
            }
        }

        public SUIncrementDecrementModel SUIncrementDecrement
        {
            set
            {
                var suIncrementDecrementDetail = value?.SUIncrementDecrementDetails ?? new List<SUIncrementDecrementDetailModel>();

                bindingSourceDetail.DataSource = suIncrementDecrementDetail;
                gridViewDetail.PopulateColumns(suIncrementDecrementDetail);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "CCDC", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, ToolTip = "Công cụ dụng cụ", AllowEdit = false, RepositoryControl = _rpsInventoryItems });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, ToolTip = "Diễn giải", AllowEdit = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ToolTip = "Phòng ban", AllowEdit = false, RepositoryControl = _rpsDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOc", ColumnCaption = "Đơn giá", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", ColumnCaption = "Đơn giá QĐ", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Thành tiền", ColumnPosition = 7, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Thành tiền QĐ", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = false, IsSummaryText = true });
                LoadGridLayout(gridViewDetail, ColumnsCollection);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        protected override void LoadDataIntoGrid()
        {
            if (GlobalVariable.DisplayVourcherMode == 1 || GlobalVariable.DisplayVourcherMode == -1)
                _sUIncrementDecrementsPresenter.Display((int)RefTypeId);
            else
                _sUIncrementDecrementsPresenter.Display((int)RefTypeId, Convert.ToDateTime(PostedDate));
        }

        protected override void LoadDataIntoGridDetail(long refId)
        {
            _sUIncrementDecrementsPresenter.DisplayVoucherDetail(refId);
        }

        protected override void DeleteGrid()
        {
            new SUIncrementDecrementPresenter(null).Delete(long.Parse(PrimaryKeyValue));
        }

        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraSUIncrementDetail() { FormCaption = ResourceHelper.GetResourceValueByName("ResSUIncrementCaption") };
        }
    }
}
