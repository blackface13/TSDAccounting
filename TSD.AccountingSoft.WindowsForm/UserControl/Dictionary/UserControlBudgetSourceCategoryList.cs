using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSourceCategory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    public partial class UserControlBudgetSourceCategoryList : BaseListUserControl, IBudgetSourceCategoriesView
    {
        /// <summary>
        /// The _budget source categories presenter
        /// </summary>
        private readonly BudgetSourceCategoriesPresenter _budgetSourceCategoriesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBudgetSourceCategoryList"/> class.
        /// </summary>
        public UserControlBudgetSourceCategoryList()
        {
            InitializeComponent();
            _budgetSourceCategoriesPresenter = new BudgetSourceCategoriesPresenter(this);
        }

        /// <summary>
        /// Sets the budget source categories.
        /// </summary>
        /// <value>
        /// The budget source categories.
        /// </value>
        public IList<BudgetSourceCategoryModel> BudgetSourceCategories
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryCode", ColumnCaption = "Mã loại nguồn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryName", ColumnCaption = "Tên loại nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 180 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSummaryEstimateReport", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _budgetSourceCategoriesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BudgetSourceCategoryPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraBudgetSourceCategoryDetail();
        }
    }
}
