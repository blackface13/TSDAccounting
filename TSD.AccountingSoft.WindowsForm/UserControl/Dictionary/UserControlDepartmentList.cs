/***********************************************************************
 * <copyright file="UserControlDepartmentList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlDepartmentList 
    /// </summary>
    public partial class UserControlDepartmentList : BaseTreeListUserControl, IDepartmentsView
    {
        /// <summary>
        /// The _departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlDepartmentList"/> class.
        /// </summary>
        public UserControlDepartmentList()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        #region IDepartmentsView Members

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<Model.BusinessObjects.Dictionary.DepartmentModel> Departments
        {
            set
            {
                treeList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _departmentsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteTree()
        {
            new DepartmentPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraDepartmentDetail();
        }
    }
}
