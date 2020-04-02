/***********************************************************************
 * <copyright file="UserControlBudgetChapterList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlBudgetChapterList.
    /// </summary>
    public partial class UserControlBudgetChapterList : BaseListUserControl, IBudgetChaptersView
    {
        /// <summary>
        /// The _budget chapter presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChapterPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBudgetChapterList"/> class.
        /// </summary>
        public UserControlBudgetChapterList()
        {
            InitializeComponent();
            _budgetChapterPresenter = new BudgetChaptersPresenter(this);
        }

        #region IBudgetChaptersView Members
        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetChapterModel> BudgetChapters
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 250 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _budgetChapterPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BudgetChapterPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraBudgetChapterDetail();
        }
        #endregion
    }
}
