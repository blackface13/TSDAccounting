using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusinessParallel;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.XtraEditors.Repository;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using DevExpress.XtraBars;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    public partial class UserControlAutoBusinessParallelList : BaseListUserControl, IAutoBusinessParallelsView, IBudgetItemsView, IBudgetSourcesView, IVoucherTypesView
    {
        private readonly AutoBusinessParallelsPresenter _autoBusinessParallelsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly VoucherTypesPresenter _voucherTypesPresenter;

        private readonly RepositoryItemGridLookUpEdit _rpsBudgetSource;
        private readonly RepositoryItemGridLookUpEdit _rpsBudgetItem;
        private readonly RepositoryItemGridLookUpEdit _rpsVoucherType;

        public UserControlAutoBusinessParallelList()
        {
            InitializeComponent();
            _autoBusinessParallelsPresenter = new AutoBusinessParallelsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);

            _rpsBudgetSource = new RepositoryItemGridLookUpEdit();
            _rpsBudgetItem = new RepositoryItemGridLookUpEdit();
            _rpsVoucherType = new RepositoryItemGridLookUpEdit();

            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();
        }

        #region Properties

        public IList<AutoBusinessParallelModel> AutoBusinessParallels
        {
            set
            {
                gridView.OptionsView.AllowHtmlDrawHeaders = true;
                gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grdList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessParallelId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessCode", ColumnVisible = true, ColumnCaption = "Mã định khoản", ColumnPosition = 1, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessName", ColumnVisible = true, ColumnCaption = "Tên định khoản", ColumnPosition = 2, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "Tài khoản nợ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "Tài khoản có", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = true, ColumnCaption = "Nguồn vốn", ColumnPosition = 6, ColumnWith = 70, RepositoryControl = _rpsBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = true, ColumnCaption = "Mục - tiểu mục", ColumnPosition = 7, ColumnWith = 70, RepositoryControl = _rpsBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnVisible = true, ColumnCaption = "Nghiệp vụ", ColumnPosition = 8, ColumnWith = 200, RepositoryControl = _rpsVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccountParallel", ColumnCaption = "Tài khoản nợ\nđồng thời", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccountParallel", ColumnCaption = "Tài khoản có\nđồng thời", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                GridLookUpItem.BudgetItem(value, _rpsBudgetItem, "BudgetItemCode", "BudgetItemId");
            }
        }
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                GridLookUpItem.BudgetSource(value, _rpsBudgetSource, "BudgetSourceCode", "BudgetSourceId");
            }
        }
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                GridLookUpItem.VoucherType(value, _rpsVoucherType, "VoucherTypeName", "VoucherTypeId");
            }
        }

        #endregion

        #region Form event

        protected override void LoadDataIntoGrid()
        {
            _budgetItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _voucherTypesPresenter.DisplayActive();
            _autoBusinessParallelsPresenter.Display();
        }

        protected override void DeleteGrid()
        {
            new AutoBusinessParallelPresenter(null).Delete(Convert.ToInt32(PrimaryKeyValue));
        }

        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraAutoBusinessParallelDetail();
        }

        #endregion
    }
}
