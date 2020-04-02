/***********************************************************************
 * <copyright file="FrmS11H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, July 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Salary;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Salary;
using DateTimeRangeBlockDev.Helper;
using TSD.AccountingSoft.Report.CommonClass;
using DevExpress.Utils;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmA02LDTLRETAIL : FrmXtraBaseParameter, ISalaryVouchersView, IEmployeesView
    {
        private readonly SalaryVouchersPresenter _salaryVouchersPresenter;
        private readonly EmployeesPresenter _employeesPresenter;
        internal GridCheckMarksSelection Selection1 { get; private set; }
        internal GridCheckMarksSelection Selection2 { get; private set; }

        public FrmA02LDTLRETAIL()
        {
            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Month;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            _salaryVouchersPresenter = new SalaryVouchersPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
        }

        /// <summary>
        /// Gets or sets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + dateTimeRangeV1.FromDate.Year;
            }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.Month + "/" + dateTimeRangeV1.ToDate.Day + "/" + dateTimeRangeV1.ToDate.Year;
            }
        }

        public string WhereClauseListEmployee
        {
            get;
            set;
        }

        public string WhereClauseListRefNo
        {
            get;
            set;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            WhereClauseListEmployee = "";
            WhereClauseListRefNo = "";

            if (radioVoucher.Checked)
            {
                if (grdVoucher.DataSource != null && grdViewVoucher.RowCount > 0)
                {
                    for (var i = 0; i < grdViewVoucher.RowCount; i++)
                    {
                        if (Selection2.IsRowSelected(i))
                        {
                            var row = (SalaryVoucherModel)grdViewVoucher.GetRow(i);
                            WhereClauseListRefNo = WhereClauseListRefNo + "'" + row.RefNo + "',";
                        }
                    }
                }

            }
            else
            {
                if (grdEmployee.DataSource != null && gridViewEmployee.RowCount > 0)
                {
                    for (var i = 0; i < gridViewEmployee.RowCount; i++)
                    {

                        if (Selection1.IsRowSelected(i))
                        {
                            var row = (EmployeeModel)gridViewEmployee.GetRow(i);
                            WhereClauseListEmployee = WhereClauseListEmployee + row.EmployeeId + ",";
                        }

                    }
                }
            }

            if (WhereClauseListEmployee != "")
                WhereClauseListEmployee = WhereClauseListEmployee.Substring(0, WhereClauseListEmployee.Length - 1);

            if (WhereClauseListRefNo != "")
            {
                WhereClauseListRefNo = WhereClauseListRefNo.Substring(0, WhereClauseListRefNo.Length - 1);
                //  WhereClauseListRefNo = WhereClauseListRefNo
            }

        }

        public bool IsTotalBandInNewPage
        {
            get
            {
                return chkMoveTotalInNewPage.Checked;
            }
        }


        private void LoadGridEmployeesLayout()
        {
            if (gridViewEmployee.Columns.Count > 0)
            {

                gridViewEmployee.Columns["EmployeeName"].Caption = @"Danh sách nhân viên";
                gridViewEmployee.Columns["EmployeeName"].Visible = true;
                gridViewEmployee.Columns["EmployeeName"].Width = 120;
                gridViewEmployee.Columns["EmployeeId"].Visible = false;
                gridViewEmployee.Columns["EmployeeCode"].Visible = false;
                gridViewEmployee.Columns["SortOrder"].Visible = false;
                gridViewEmployee.Columns["BirthDate"].Visible = false;
                gridViewEmployee.Columns["TypeOfSalary"].Visible = false;
                gridViewEmployee.Columns["JobCandidateName"].Visible = false;
                gridViewEmployee.Columns["Sex"].Visible = false;
                gridViewEmployee.Columns["LevelOfSalary"].Visible = false;
                gridViewEmployee.Columns["DepartmentId"].Visible = false;
                gridViewEmployee.Columns["CurrencyCode"].Visible = false;
                gridViewEmployee.Columns["IdentityNo"].Visible = false;
                gridViewEmployee.Columns["IssueDate"].Visible = false;
                gridViewEmployee.Columns["IssueBy"].Visible = false;
                gridViewEmployee.Columns["IsActive"].Visible = false;
                gridViewEmployee.Columns["Description"].Visible = false;
                gridViewEmployee.Columns["Address"].Visible = false;
                gridViewEmployee.Columns["PhoneNumber"].Visible = false;
                gridViewEmployee.Columns["EmployeePayItems"].Visible = false;
                gridViewEmployee.Columns["RetiredDate"].Visible = false;
                gridViewEmployee.Columns["StartingDate"].Visible = false;
                gridViewEmployee.Columns["IsOffice"].Visible = false;

            }
        }

        private void LoadGridSalaryVoucherLayout()
        {
            if (grdViewVoucher.Columns.Count > 0)
            {
                grdViewVoucher.Columns["RefTypeId"].Visible = false;
                grdViewVoucher.Columns["RefNo"].Visible = true;
                grdViewVoucher.Columns["RefNo"].Width = 60;
                grdViewVoucher.Columns["RefNo"].Caption = @"Số chứng từ";
                grdViewVoucher.Columns["PostedDate"].Visible = false;
                grdViewVoucher.Columns["PostedDate"].Width = 60;
                grdViewVoucher.Columns["PostedDate"].Caption = @"Ngày ghi sổ";
            }
        }

        public IList<SalaryVoucherModel> SalaryVouchers
        {
            set
            {
                grdVoucher.DataSource = value.Count > 0 ? value : new List<SalaryVoucherModel>();
            }
        }

        public IList<EmployeeModel> Employees
        {
            set
            {
                grdEmployee.DataSource = value.Count > 0 ? value : new List<EmployeeModel>();
            }
        }

        private void FrmA02LDTLRETAIL_Load(object sender, System.EventArgs e)
        {
            dateTimeRangeV1.DateTimeRangeSelectedIndexEvent += cboDropDown_SelectedIndexChanged;
            _salaryVouchersPresenter.DisplayAllIsRetail(dateTimeRangeV1.FromDate.ToString("MM/dd/yyyy"), true, 600);
            _employeesPresenter.DisplayIsRetail(dateTimeRangeV1.FromDate.ToString("MM/dd/1975"), true);
            //_salaryVouchersPresenter.DisplayAllIsRetail(dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + dateTimeRangeV1.FromDate.Year, true, 600);
            //_employeesPresenter.DisplayIsRetail(dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + 1975, true);
            grdEmployee.Visible = false;

            Selection1 = new GridCheckMarksSelection(gridViewEmployee);
            Selection1.CheckMarkColumn.VisibleIndex = 0;
            Selection1.CheckMarkColumn.Width = 30;

            Selection2 = new GridCheckMarksSelection(grdViewVoucher);
            Selection2.CheckMarkColumn.VisibleIndex = 0;
            Selection2.CheckMarkColumn.Width = 30;

            LoadGridEmployeesLayout();
            LoadGridSalaryVoucherLayout();
        } 

        private void cboDropDown_SelectedIndexChanged()
        {
            if(radioVoucher.Checked)
            {
                _salaryVouchersPresenter.DisplayAllIsRetail(dateTimeRangeV1.FromDate.ToString("MM/dd/yyyy"), true, 600);
                _employeesPresenter.DisplayIsRetail(dateTimeRangeV1.FromDate.ToString("MM/dd/1975"), true);
                //_salaryVouchersPresenter.DisplayAllIsRetail(dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + dateTimeRangeV1.FromDate.Year, true, 600);
                //_employeesPresenter.DisplayIsRetail(dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + 1975, true);
                grdEmployee.Visible = false;
                grdVoucher.Visible = true;
            }  
            else
            {
                _salaryVouchersPresenter.DisplayAllIsRetail(dateTimeRangeV1.FromDate.ToString("MM/dd/1975"), true, 600);
                _employeesPresenter.DisplayIsRetail(dateTimeRangeV1.FromDate.ToString("MM/dd/yyyy"), true);
                //_salaryVouchersPresenter.DisplayAllIsRetail(dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + 1975, true, 600);
                //_employeesPresenter.DisplayIsRetail(dateTimeRangeV1.FromDate.Month + "/" + dateTimeRangeV1.FromDate.Day + "/" + dateTimeRangeV1.FromDate.Year, true);
                grdEmployee.Visible = true;
                grdVoucher.Visible = false;
            }
               
        }

        private void radio_CheckedChanged(object sender, System.EventArgs e)
        {
            cboDropDown_SelectedIndexChanged();
        }

        private void grdViewVoucher_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (grdViewVoucher.FocusedRowHandle > -1)
            {
                var flag = Selection2.IsRowSelected(grdViewVoucher.FocusedRowHandle);
                Selection2.SelectRow(grdViewVoucher.FocusedRowHandle, !flag);
            }
        }

        private void gridViewEmployee_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridViewEmployee.FocusedRowHandle > -1)
            {
                bool flag = Selection1.IsRowSelected(gridViewEmployee.FocusedRowHandle);
                Selection1.SelectRow(gridViewEmployee.FocusedRowHandle, !flag);
            }

        }

    }
}
