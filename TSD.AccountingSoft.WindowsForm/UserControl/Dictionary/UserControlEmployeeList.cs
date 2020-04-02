/***********************************************************************
 * <copyright file="UserControlEmployeeList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@boca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlEmployeeList
    /// </summary>
    public partial class UserControlEmployeeList : BaseListUserControl, IEmployeesView
    {
        private readonly EmployeesPresenter _employeesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlEmployeeList"/> class.
        /// </summary>
        public UserControlEmployeeList()
        {
            InitializeComponent();
            _employeesPresenter = new EmployeesPresenter(this);
        }

        #region IEmployeesView Members

        /// <summary>
        /// Sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public IList<EmployeeModel> Employees
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnCaption = "STT", ColumnVisible = true, ColumnPosition = 1, ColumnWith = 20, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeCode", ColumnCaption = "Mã cán bộ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeName", ColumnCaption = "Tên cán bộ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JobCandidateName", ColumnCaption = "Chức vụ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BirthDate", ColumnCaption = "Ngày sinh", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartingDate", ColumnCaption = "Ngày bắt đầu", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RetiredDate", ColumnCaption = "Ngày kết thúc", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PhoneNumber", ColumnCaption = "Số điện thoại", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 9, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TypeOfSalary", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Sex", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "LevelOfSalary", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IdentityNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được theo dõi", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsOffice", ColumnCaption = "Là cán bộ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeePayItems", ColumnVisible = false });
                

            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _employeesPresenter.Display();
            _employeesPresenter.SaveCompanyProfile();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new EmployeePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraEmployeeDetail();
        }
    }
}