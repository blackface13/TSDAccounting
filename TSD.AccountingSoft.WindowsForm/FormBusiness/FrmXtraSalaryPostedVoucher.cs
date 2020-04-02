using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Salary;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Salary;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using TSD.AccountingSoft.Session;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraSalaryPostedVoucher : XtraForm, ISalaryVouchersView, IEmployeesView,ILockView
    {
        private readonly SalaryVouchersPresenter salaryVouchersPresenter;
        private readonly EmployeesPresenter employeesPresenter;
        private readonly LockPresenter _lockPresenter;
        private GlobalVariable _dbOptionHelper;
        public DateTime PostedDate
        {
            get;
            set;
        }
        public string RefNo
        {
            get;
            set;
        }

        public int RefTypeId = 600;

        public FrmXtraSalaryPostedVoucher()
        {
            InitializeComponent();
             salaryVouchersPresenter=new SalaryVouchersPresenter(this);
            employeesPresenter = new EmployeesPresenter(this);
            _lockPresenter=new LockPresenter(this);
            _dbOptionHelper = new GlobalVariable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public IList<SalaryVoucherModel> SalaryVouchers
        {
            set
            {
                gridSalaryVoucher.DataSource = value.Count > 0 ? value : new List<SalaryVoucherModel>();
                gridViewSalaryVoucher.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnCaption = "Loại chứng từ lương", ColumnVisible = false, ColumnPosition = 1, ColumnWith = 600, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày tính lương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 200 });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewSalaryVoucher.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewSalaryVoucher.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewSalaryVoucher.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewSalaryVoucher.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewSalaryVoucher.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else gridViewSalaryVoucher.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        public IList<EmployeeModel> Employees
        {
            set
            {
                grdlookUpEmployee.DataSource = value.Count>0? value: new List<EmployeeModel>();
                gridViewEmployee.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnCaption = "STT", ColumnVisible = false, ColumnPosition = 1, ColumnWith = 20, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "EmployeeCode", ColumnCaption = "Mã nhân viên", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                columnsCollection.Add(new XtraColumn { ColumnName = "EmployeeName", ColumnCaption = "Tên nhân viên", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                columnsCollection.Add(new XtraColumn { ColumnName = "JobCandidateName", ColumnCaption = "Chức vụ", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100 });
                columnsCollection.Add(new XtraColumn { ColumnName = "BirthDate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn { ColumnName = "StartingDate", ColumnCaption = "Ngày bắt đầu", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "RetiredDate", ColumnCaption = "Ngày kết thúc", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "PhoneNumber",ColumnVisible = false});
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn { ColumnName = "TypeOfSalary", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Sex", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "LevelOfSalary", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IdentityNo", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive",  ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsOffice",  ColumnVisible = false});
                columnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "EmployeePayItems", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewEmployee.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewEmployee.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewEmployee.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewEmployee.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewEmployee.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else gridViewEmployee.Columns[column.ColumnName].Visible = false;
                }

            }
        }

        private void FrmXtraSalaryPostedVoucher_Load(object sender, EventArgs e)
        {
            salaryVouchersPresenter.Display(PostedDate.ToShortDateString());
            if (gridViewSalaryVoucher.RowCount > 0)
            {
                RefNo = gridViewSalaryVoucher.GetRowCellValue(0, "RefNo").ToString();
                employeesPresenter.DisplayByMonthDateAndRefNo(PostedDate.ToShortDateString(), RefNo); 
            }

            if (RefNo == "" || RefNo == null)
            {
                btnPostedVoucher.Enabled = false;
                btnCancelCalc.Enabled = false;

            }

        }

        private void gridViewSalaryVoucher_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            RefNo = gridViewSalaryVoucher.GetRowCellValue(gridViewSalaryVoucher.FocusedRowHandle, "RefNo").ToString();
            employeesPresenter.DisplayByMonthDateAndRefNo(PostedDate.ToShortDateString(), RefNo);

        }

        private void btnPostedVoucher_Click(object sender, EventArgs e)
        {

            if (RefNo == "" || RefNo == null)
            {
                XtraMessageBox.Show("Không tồn tại chứng từ để ghi sổ",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_lockPresenter.CheckLockDate(-1, 600, DateTime.Parse(_dbOptionHelper.PostedDate)))
            {
                XtraMessageBox.Show("Bạn đang ghi sổ trong ngày đã khóa. Bạn phải bỏ khóa sổ!.","Thông báo",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            salaryVouchersPresenter.Save(PostedDate.ToShortDateString(), RefNo, RefTypeId);
            //Reload lai  cac grid
            RefNo = "";
            salaryVouchersPresenter.Display(PostedDate.ToShortDateString());
            if (gridViewSalaryVoucher.RowCount > 0)
            {
                RefNo = gridViewSalaryVoucher.GetRowCellValue(0, "RefNo").ToString();
                employeesPresenter.DisplayByMonthDateAndRefNo(PostedDate.ToShortDateString(), RefNo);
            } 
            employeesPresenter.DisplayByMonthDateAndRefNo(PostedDate.ToShortDateString(), RefNo);

            if (RefNo == "" || RefNo == null)
            {
                btnPostedVoucher.Enabled = false;
                btnCancelCalc.Enabled = false;
            }
        }

        private void btnCancelCalc_Click(object sender, EventArgs e)
        {
            //if (_lockPresenter.CheckLockDate(-1, 600, DateTime.Parse(PostedDate)))
            //{
            //    XtraMessageBox.Show("Bạn không được hủy tính lương khi đã khóa sổ. Bạn phải bỏ khóa sổ!.", "Thông báo",
            //          MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            salaryVouchersPresenter.CancelCalc(PostedDate.ToShortDateString(), RefNo, RefTypeId);

            RefNo = "";
            salaryVouchersPresenter.Display(PostedDate.ToShortDateString());
            if (gridViewSalaryVoucher.RowCount > 0)
            {
                RefNo = gridViewSalaryVoucher.GetRowCellValue(0, "RefNo").ToString();
                employeesPresenter.DisplayByMonthDateAndRefNo(PostedDate.ToShortDateString(), RefNo);
            }
            employeesPresenter.DisplayByMonthDateAndRefNo(PostedDate.ToShortDateString(), RefNo);

            if (RefNo == "" || RefNo == null)
            {
                btnPostedVoucher.Enabled = false;
                btnCancelCalc.Enabled = false;
            }

        }

        #region LockDate

        public string Content { get; set; }

        public DateTime LockDate { get; set; }

        public bool IsLock { get; set; }

        #endregion

    }
}
