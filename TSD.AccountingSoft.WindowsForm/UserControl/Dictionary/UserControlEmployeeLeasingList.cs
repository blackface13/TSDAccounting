/***********************************************************************
 * <copyright file="UserControlEmployeeLeasingList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.EmployeeLeasing;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// UserControlEmployeeLeasingList
    /// </summary>
    public partial class UserControlEmployeeLeasingList : BaseListUserControl, IEmployeeLeasingsView
    {
        private readonly EmployeeLeasingsPresenter _employeeLeasingsPresenter;
        private const bool IsLeasing = false;

        #region EmployeeLeasing Members

        /// <summary>
        /// Sets the employee leasings.
        /// </summary>
        /// <value>
        /// The employee leasings.
        /// </value>
        public IList<EmployeeLeasingModel> EmployeeLeasings
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeLeasingId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrderNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsLeasing", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InsurancePrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UniformPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeLeasingCode", ColumnCaption = "Mã nhân viên", ColumnPosition = 1, ColumnVisible = true, 
                    ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeLeasingName", ColumnCaption = "Họ nhân viên", ColumnPosition = 2, ColumnVisible = true, 
                    ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JobCandidate", ColumnCaption = "Chức vụ", ColumnPosition = 3, ColumnVisible = true, 
                    ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnCaption = "Ngày nhân công tác", ColumnPosition = 4, ColumnVisible = true, 
                    ColumnWith = 100, Alignment = HorzAlignment.Center});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndDate", ColumnCaption = "Ngày hết nhiệm kỳ", ColumnPosition = 5, ColumnVisible = true, 
                    ColumnWith = 100, Alignment = HorzAlignment.Center});
            }
        }

        #endregion

        #region Function Overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _employeeLeasingsPresenter.Display(IsLeasing);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new EmployeeLeasingPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraEmployeeLeasingDetail();
        }
        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlEmployeeLeasingList" /> class.
        /// </summary>
        public UserControlEmployeeLeasingList()
        {
            InitializeComponent();
            _employeeLeasingsPresenter = new EmployeeLeasingsPresenter(this);
        }

        #endregion
    }
}
