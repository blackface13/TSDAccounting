/***********************************************************************
 * <copyright file="FrmXtraSalary.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  TuanHM ,ThangNK modified 20/09/2014
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Saturday, September 20, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.PayItem;
using TSD.AccountingSoft.Presenter.Salary;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Salary;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.WindowsForm.UserControl.Voucher;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraSalary : XtraForm, ISalaryView, IDepartmentsView, IEmployeesView, IEmployeeView, IPayItemsView, ICurrenciesView,ILockView
    {
        #region Declare

        internal GridCheckMarksSelection Selection { get; private set; }
        private string _keyForSend = "";
        public string ExchangeRateForSend { get; set; }
        public string RefdateForSend = "";
        /// <summary>
        /// 1- Nhân viên đã tính lương.
        /// 2- Nhân viên chưa tính lương, chọn để tính tiếp.
        /// </summary>
        public int SalaryOptionType = 1; 
        /// <summary>
        /// 1- Tròn tháng.
        /// 2- Lẻ tháng.
        /// 3- Cả hai.
        /// </summary>
        public int SalaryCalcType = 1; 

        public delegate void EventPostKeyHandler(object sender, string keyValue);

        public event EventPostKeyHandler PostKeyValue;
        private DepartmentsPresenter _departmentsPresenter;
        private CurrenciesPresenter _currenciesPresenter;
        private EmployeesPresenter _employeesPresenter;
        private EmployeePresenter _employeePresenter;
        private PayItemsPresenter _payItemsPresenter;
        private SalaryPresenter _salaryPresenter;
        private LockPresenter _lockPresenter;

        private GlobalVariable _dbOptionHelper;

        private bool _checkCurrencyCodeOfSalary = true;
        private string _currencyCodeFirst;
        private string _refNoFirst;

        #endregion

        #region Repository Controls

        private RepositoryItemLookUpEdit RepositoryPayItemId { get; set; }

        #endregion

        #region Events

        public FrmXtraSalary()
        {
            InitializeComponent();
            _currenciesPresenter = new CurrenciesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _employeePresenter = new EmployeePresenter(this);
            _payItemsPresenter = new PayItemsPresenter(this);
            _salaryPresenter = new SalaryPresenter(this);
            _lockPresenter= new LockPresenter(this);
            _dbOptionHelper = new GlobalVariable();
            RepositoryPayItemId = new RepositoryItemLookUpEdit();
        }

        private void FrmXtraSalary_Load(object sender, EventArgs e)
        {
            _currenciesPresenter.Display();
            _departmentsPresenter.DisplayActive();
            txtRateCurrency.Properties.EditMask = @"c" + _dbOptionHelper.ExchangeRateDecimalDigits;
            RepositoryPayItemId.PopupWidth = 520;
            RepositoryPayItemId.NullText = ResourceHelper.GetResourceValueByName("ResRepositoryControlPayItemID");
            _payItemsPresenter.DisplayActive();
            // GetDataToCombo(); MVVP sẽ là call method + gán dữ liệu trả về vào property IVIEW của nó ><        
            LoadGridEmployeesLayout();
            picDaTinh.Visible = false;
            if (RefdateForSend == "")
            {
                dtRefDate.DateTime = new DateTime(DateTime.Parse(_dbOptionHelper.PostedDate).Year, DateTime.Parse(_dbOptionHelper.PostedDate).Month, 1);

            }
            else
            {
                dtRefDate.DateTime = DateTime.Parse(RefdateForSend);
            }


            //btnShowRef.Enabled = false;
            btnShowVoucher.Enabled = true;
            // btnPosted.Enabled = false;
            _refNoFirst = txtRefNo.Text;
            gridViewSalary.OptionsView.ShowFooter = true;
            gridViewEmploy.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewEmploy.OptionsSelection.EnableAppearanceFocusedCell = false;

            grdLookUpDepartment.CheckAll();
            grdLookUpDepartment.SelectedText = "Chọn tất";
            Selection = new GridCheckMarksSelection(gridViewEmploy);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 30;
            if (gridViewEmploy.RowCount > 0)
            {
                gridViewEmploy.FocusedRowHandle = gridViewEmploy.RowCount - 1;
                grdlookUpEmployee_Click(sender, e);
            }


            for (var i = 0; i < gridViewEmploy.RowCount; i++)
            {
                gridViewEmploy.FocusedRowHandle = i;
                var employeeId = gridViewEmploy.Columns["EmployeeId"];
                string empValue = gridViewEmploy.GetRowCellValue(i, employeeId).ToString();
                CheckCaculateStateCheckBox(int.Parse(empValue));
            }

            FormatControl(groupControl1);
            txtRateCurrency.EditValue = 1;
            _dbOptionHelper = new GlobalVariable();
            grdLookUpCurrency.Enabled = false;
            if (grdLookUpCurrency.Text == GlobalVariable.CurrencyMain)
            {
                txtRateCurrency.Value = 1;
                txtRateCurrency.Enabled = false;
            }
            else
            {
                txtRateCurrency.Enabled = true;
                if (ExchangeRateForSend != null) txtRateCurrency.Value = decimal.Parse(ExchangeRateForSend);
            }
            groupBox2.Visible = false;
            chkSelectAll.Visible = false;
        }

        private void grdlookUpEmployee_Click(object sender, EventArgs e)
        {
            //if (gridViewEmploy.FocusedRowHandle > -1)
            //{
            //    ResetBtnState();
            //    chkSelectAll.Checked = false;
            //    //Hiển thị grid salary
            //    var employeeName = gridViewEmploy.Columns["EmployeeName"];
            //    lblHoTen.Text = gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, employeeName).ToString();

            //    var typeOfSalary = gridViewEmploy.Columns["TypeOfSalary"];
            //    int a = (int)gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, typeOfSalary);
            //    lblLoai.Text = a == 0 ? @"Lương hệ số" : @"Lương cố định";
            //    //Phòng
            //    var employeeId = gridViewEmploy.Columns["EmployeeId"];
            //    string empValue = gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, employeeId).ToString();
            //    _employeePresenter.Display(empValue, DateTime.Parse(RefDate));
            //    LoadGridLayoutSalary();
            //    SetNumericFormatControl(gridViewSalary, true);
            //    CheckCaculateState(int.Parse(empValue));

            //    var flag = Selection.IsRowSelected(gridViewEmploy.FocusedRowHandle);
            //    if (flag)
            //    {
            //        Selection.SelectRow(gridViewEmploy.FocusedRowHandle, false);
            //    }
            //    else
            //    {
            //        Selection.SelectRow(gridViewEmploy.FocusedRowHandle, true);
            //    }
            //}
        }

        private void gridViewEmploy_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewEmploy.CalcHitInfo(((MouseEventArgs)e).Location);
            if (!hi.InColumn && hi.InRowCell)
                if (gridViewEmploy.FocusedRowHandle > -1)
                {
                    ResetBtnState();
                    chkSelectAll.Checked = false;
                    //Hiển thị grid salary
                    var employeeName = gridViewEmploy.Columns["EmployeeName"];
                    lblHoTen.Text = gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, employeeName).ToString();

                    var typeOfSalary = gridViewEmploy.Columns["TypeOfSalary"];
                    int a = (int)gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, typeOfSalary);
                    lblLoai.Text = a == 0 ? @"Lương hệ số" : @"Lương cố định";
                    //Phòng
                    var employeeId = gridViewEmploy.Columns["EmployeeId"];
                    string empValue = gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, employeeId).ToString();
                    _employeePresenter.Display(empValue, DateTime.Parse(RefDate), ExchangeRate);
                    LoadGridLayoutSalary();
                    SetNumericFormatControl(gridViewSalary, true);
                    CheckCaculateState(int.Parse(empValue));

                    RowForcus = gridViewEmploy.FocusedRowHandle;
                    StateCheck = false;
                    bool flag = Selection.IsRowSelected(gridViewEmploy.FocusedRowHandle);
                    Selection.SelectRow(gridViewEmploy.FocusedRowHandle, !flag);
                }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                //ResetBtnState();
                //for (int i = 0; i < gridViewEmploy.RowCount; i++)
                //{
                //    gridViewEmploy.FocusedRowHandle = i;
                //    var employeeId = gridViewEmploy.Columns["EmployeeId"];
                //    //bool flag = RefDate != null && _salaryPresenter.CheckCalSalaryState(DateTime.Parse(RefDate), (int)gridViewEmploy.GetRowCellValue(i, employeeId));
                //    //if (flag)
                //    //{

                //    //    btnPosted.Enabled = true;
                //    //    // picDaTinh.Visible = true;
                //    //    btnCalSalary.Enabled = false;
                //    //    break;
                //    //}

                //    btnPosted.Enabled = false;
                //}
                gridViewEmploy.SelectAll();
                Selection.SelectAll();
            }
            else
            {

                gridViewEmploy.OptionsSelection.EnableAppearanceFocusedRow = true;
                gridViewEmploy.OptionsSelection.EnableAppearanceFocusedCell = false;

                if (gridViewEmploy.RowCount > 0)
                {
                    Selection.ClearSelection();
                    gridViewEmploy.FocusedRowHandle = 0;
                    gridViewEmploy.SelectRow(0); //= 0;
                    grdlookUpEmployee_Click(sender, e);
                    //   Selection.SelectRow(gridViewEmploy.FocusedRowHandle,true);
                }
            }


            //if (grdlookUpEmployee.DataSource != null && gridViewEmploy.RowCount > 0)
            //{
            //   //// Selection.ClearSelection();
            //   // //gridViewEmploy.FocusedRowHandle = 0;
            //   // //gridViewEmploy.SelectRow(0);
            //   // //grdlookUpEmployee_Click(sender, e);
            //   // if (chkSelectAll.Checked)
            //   // {
            //   //     gridViewEmploy.SelectAll();  
            //   // }


            //    for (int i = 0; i < gridViewEmploy.RowCount; i++)
            //        gridViewEmploy.SetRowCellValue(i, "EmployeeId", true);

            //}
            //if (chkSelectAll.Checked)
            //{
            //    ResetBtnState();
            //    for (int i = 0; i < gridViewEmploy.RowCount; i++)
            //    {
            //        gridViewEmploy.FocusedRowHandle = i;
            //        var employeeId = gridViewEmploy.Columns["EmployeeId"];
            //        bool flag = RefDate != null && _salaryPresenter.CheckCalSalaryState(DateTime.Parse(RefDate), (int)gridViewEmploy.GetRowCellValue(i, employeeId));
            //        if (flag)
            //        {
            //            btnShowRef.Enabled = true;
            //            btnCancel.Enabled = true;
            //            btnPosted.Enabled = true;
            //            btnCalSalary.Enabled = false;
            //            break;
            //        }
            //        btnShowRef.Enabled = false;
            //        btnCancel.Enabled = false;
            //        btnPosted.Enabled = false;
            //    }
            //    gridViewEmploy.SelectAll();
            //    Selection.SelectAll();
            //}
            //else
            //{

            //    gridViewEmploy.OptionsSelection.EnableAppearanceFocusedRow = true;
            //    gridViewEmploy.OptionsSelection.EnableAppearanceFocusedCell = false;

            //    if (gridViewEmploy.RowCount > 0)
            //    {
            //        Selection.ClearSelection();
            //        gridViewEmploy.FocusedRowHandle = 0;
            //        gridViewEmploy.SelectRow(0); //= 0;
            //        grdlookUpEmployee_Click(sender, e);
            //    }
            //}
        }

        private void btnCalSalary_Click(object sender, EventArgs e)
        {
            if (ExchangeRate == 1 && CurrencyCodeSalary == _dbOptionHelper.CurrencyLocal)
            {
                XtraMessageBox.Show("Tỷ giá phải khác 0 và 1", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (_lockPresenter.CheckLockDate(-1, 600,dtRefDate.DateTime))
            //{
            //    XtraMessageBox.Show("Bạn không được tính lương khi đã khóa sổ. Bạn phải bỏ khóa sổ!.", "Thông báo",
            //          MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Kiểm tra đã có tính lương lần nào trong tháng chưa với ngay tính lương
            //bool kt = _salaryPresenter.SararyExistRefNoInDay(dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, txtRefNo.Text);
            bool kt = _salaryPresenter.SararyExistRefNoInDay(dtRefDate.DateTime.ToShortDateString(), txtRefNo.Text);
            if (!kt)
            {
                int rowCount = 0;
                // Kiểm tra số dòng được check

                if (grdlookUpEmployee.DataSource != null && gridViewEmploy.RowCount > 0)
                {
                    for (var i = 0; i < gridViewEmploy.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            rowCount = rowCount + 1;
                        }
                    }
                }
                if (rowCount == 0)
                {
                    XtraMessageBox.Show("Không có nhân viên nào được chọn để tính lương", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int error = _salaryPresenter.SaveCalSalary();
                if (error == -1)
                {
                    XtraMessageBox.Show("Tồn tại số chưng từ lương", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                XtraMessageBox.Show("Hoàn thành", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                picDaTinh.Visible = true;
            }
            else
            {
                XtraMessageBox.Show("Đã tồn tại chứng từ trong ngày bạn phải chọn số chứng từ khác ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                picDaTinh.Visible = false;
                return;
            }
            radioDidEmployee.Checked = true;

            //txtRefNo.Text = _salaryPresenter.GetRefNoSalary(dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, grdLookUpCurrency.Text) + "-" + grdLookUpCurrency.Text;
            txtRefNo.Text = _salaryPresenter.GetRefNoSalary(dtRefDate.DateTime.ToShortDateString(), grdLookUpCurrency.Text) + "-" + grdLookUpCurrency.Text;

            // ThangNK comment lai
            //try
            //{          
            //ResetBtnState();
            //if (CheckValidateCalSalary())
            //{
            //    _salaryPresenter.SaveCalSalary();
            //    XtraMessageBox.Show("Hoàn thành", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    picDaTinh.Visible = true;
            //}
            //else
            //{
            //    btnShowRef.Enabled = false;
            //    btnCancel.Enabled = false;
            //    btnPosted.Enabled = false;
            //    picDaTinh.Visible = false;
            //}
            //  }
            //  catch (Exception ex)
            //  {

            //      XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            //  }
            ////  }

        }

        private void grdLookUpCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLookUpCurrency.Text == GlobalVariable.CurrencyMain)
            {
                txtRateCurrency.Value = 1;
                txtRateCurrency.Enabled = false;
            }
        }

        private void btnShowVoucherIsPostedDate_Click(object sender, EventArgs e)
        {
            var frmDetail = new FrmXtraSalaryVoucher();
            frmDetail.PostedDate = dtRefDate.DateTime; //dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year;
            frmDetail.ShowDialog();

        }

        private void btnPosted_Click(object sender, EventArgs e)
        {
            var frmDetail = new FrmXtraSalaryPostedVoucher();
            frmDetail.PostedDate = dtRefDate.DateTime; //dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year;
            frmDetail.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            _keyForSend = "1";
            using (new UserControlSalaryList())
            {
                if (PostKeyValue != null) PostKeyValue(this, _keyForSend);
                Close();
            }

        }

        private void grdLookUpDepartment_EditValueChanged(object sender, EventArgs e)
        {
            chkSelectAll.Checked = false;
            lblLoaiLuong.Text = "";
            lblHoTen.Text = "";
            if (picDaTinh != null && picDaTinh.Visible)
                picDaTinh.Visible = false;
            gridSalary.DataSource = null;
            var list = grdLookUpDepartment.Properties.GetItems().GetCheckedValues();//.GetItems.GetCheckedValues()            
            string listKey = "";// list.ToString();
            foreach (var key in list)
            {
                listKey = listKey + Convert.ToString(key) + ",";
            }
            if (listKey.Length > 1)
            {
                listKey = listKey.Remove(listKey.Length - 1, 1);
                _employeesPresenter.DisplayByDepartmentFollowMonth(true, listKey, dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, SalaryOptionType, SalaryCalcType);
            }
            else
            {
                grdlookUpEmployee.DataSource = null;
            }
            LoadGridEmployeesLayout();

        }

        private void btnShowRef_Click(object sender, EventArgs e)
        {
            // var keyCash = _salaryPresenter.GetCashRefIdByefNo(txtRefNo.Text);
            var keyCash = _salaryPresenter.GetCashForSalary(dtRefDate.DateTime);
            var keyDeposit = _salaryPresenter.GetDepositForSalary(dtRefDate.DateTime);
            if (keyCash != "0" && keyDeposit != "0")
            {
                FrmXtraShowVoucherForSalary frm = new FrmXtraShowVoucherForSalary();
                frm.KeyCash = keyCash;
                frm.KeyDeposit = keyDeposit;
                frm.ShowDialog();
            }
            if (keyCash == "0" && keyDeposit != "0")
            {
                var frmDetail = new FrmXtraPaymentDepositDetail();
                frmDetail.ActionMode = ActionModeVoucherEnum.None;
                frmDetail.KeyValue = keyDeposit;
                frmDetail.MasterBindingSource = new BindingSource();
                frmDetail.CurrentPosition = 1;
                frmDetail.ShowDialog();
            }

            if (keyCash != "0" && keyDeposit == "0")
            {
                var frmDetail = new FrmXtraFormPaymentVoucherDetail();
                frmDetail.ActionMode = ActionModeVoucherEnum.None;
                frmDetail.KeyValue = keyCash;
                frmDetail.MasterBindingSource = new BindingSource();
                frmDetail.CurrentPosition = 1;
                frmDetail.ShowDialog();
            }
            if (keyCash == "0" && keyDeposit == "0")
            {
                XtraMessageBox.Show("Chưa có chứng từ lương có mã là " + txtRefNo.Text, ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dtRefDate_EditValueChanged(object sender, EventArgs e)
        {
            //var list = grdLookUpDepartment.Properties.GetItems().GetCheckedValues();
            //txtRefNo.Text = _salaryPresenter.GetRefNoSalary(dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year);
            //string listKey = "";// list.ToString();
            //foreach (var key in list)
            //{
            //    listKey = listKey + Convert.ToString(key) + ",";
            //}
            //if (listKey.Length > 1)
            //{
            //    listKey = listKey.Remove(listKey.Length - 1, 1);
            //    _employeesPresenter.DisplayByDepartment(true, listKey); //And Active
            //}
            //for (var i = 0; i < gridViewEmploy.RowCount; i++)
            //{
            //    gridViewEmploy.FocusedRowHandle = i;
            //    var employeeId = gridViewEmploy.Columns["EmployeeId"];
            //    string empValue = gridViewEmploy.GetRowCellValue(i, employeeId).ToString();
            //    CheckCaculateStateCheckBox(int.Parse(empValue));
            //    CheckCaculateState(int.Parse(empValue));
            //}


        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDidEmployee.Checked)
            {
                SalaryOptionType = 1;
                chkSelectAll.Checked = true;
                btnCalSalary.Enabled = false;
                groupBox2.Visible = false;
                chkSelectAll.Visible = false;
                //chkSelectAll.Checked = false;
                chkSelectAll.Checked = true;
                //gridViewEmploy.SelectAll();
                //Selection.SelectAll();
                picDaTinh.Visible = true;
            }

            if (radioDidNotEmloyee.Checked)
            {
                SalaryOptionType = 2;
                chkSelectAll.Checked = false;
                btnCalSalary.Enabled = true;
                groupBox2.Visible = true;
                chkSelectAll.Visible = true;
                picDaTinh.Visible = false;
            }


            var list = grdLookUpDepartment.Properties.GetItems().GetCheckedValues();
            string listKey = string.Join(",", (list.ConvertAll(i=>i.ToString())).ToArray());
            //foreach (var key in list)
            //{
            //    listKey = listKey + Convert.ToString(key) + ",";
            //}
            //listKey = listKey.Remove(listKey.Length - 1, 1);
            _employeesPresenter.DisplayByDepartmentFollowMonth(true, listKey, dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, SalaryOptionType, SalaryCalcType);

            if (grdlookUpEmployee.DataSource != null && gridViewEmploy.RowCount > 0)
            {
                var employeeName = gridViewEmploy.Columns["EmployeeName"];
                lblHoTen.Text = gridViewEmploy.GetRowCellValue(0, employeeName).ToString();

                var typeOfSalary = gridViewEmploy.Columns["TypeOfSalary"];
                int a = (int)gridViewEmploy.GetRowCellValue(0, typeOfSalary);
                lblLoai.Text = a == 0 ? @"Lương hệ số" : @"Lương cố định";

                var employeeId = gridViewEmploy.Columns["EmployeeId"];
                string empValue = gridViewEmploy.GetRowCellValue(0, employeeId).ToString();
                _employeePresenter.Display(empValue, DateTime.Parse(RefDate), ExchangeRate);
            }
            else
            {
                lblHoTen.Text = "";
                lblLoai.Text = "";

            }
            LoadGridLayoutSalary();

        }

        private void radioCalcType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRoundTypeMonth.Checked)
            {
                SalaryCalcType = 1;
            }

            if (radioRetaiTypelMonth.Checked)
            {
                SalaryCalcType = 2;
            }

            if (radioBothTypeMonth.Checked)
            {
                SalaryCalcType = 3;
            }

            var list = grdLookUpDepartment.Properties.GetItems().GetCheckedValues();
            string listKey = string.Join(",", (list.ConvertAll(i => i.ToString())).ToArray());
            //foreach (var key in list)
            //{
            //    listKey = listKey + Convert.ToString(key) + ",";
            //}
            //listKey = listKey.Remove(listKey.Length - 1, 1);
            _employeesPresenter.DisplayByDepartmentFollowMonth(true, listKey, dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, SalaryOptionType, SalaryCalcType);

            if (grdlookUpEmployee.DataSource != null && gridViewEmploy.RowCount > 0)
            {
                var employeeName = gridViewEmploy.Columns["EmployeeName"];
                lblHoTen.Text = gridViewEmploy.GetRowCellValue(0, employeeName).ToString();

                var typeOfSalary = gridViewEmploy.Columns["TypeOfSalary"];
                int a = (int)gridViewEmploy.GetRowCellValue(0, typeOfSalary);
                lblLoai.Text = a == 0 ? @"Lương hệ số" : @"Lương cố định";

                var employeeId = gridViewEmploy.Columns["EmployeeId"];
                string empValue = gridViewEmploy.GetRowCellValue(0, employeeId).ToString();
                _employeePresenter.Display(empValue, DateTime.Parse(RefDate), ExchangeRate);
            }
            else
            {
                lblHoTen.Text = "";
                lblLoai.Text = "";

            }
            LoadGridLayoutSalary();
        }

        private void dtRefDate_Enter(object sender, EventArgs e)
        {
            var list = grdLookUpDepartment.Properties.GetItems().GetCheckedValues();
            txtRefNo.Text = _salaryPresenter.GetRefNoSalary(dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, grdLookUpCurrency.Text) + "-" + grdLookUpCurrency.Text;
            string listKey = "";// list.ToString();
            foreach (var key in list)
            {
                listKey = listKey + Convert.ToString(key) + ",";
            }
            if (listKey.Length > 1)
            {
                listKey = listKey.Remove(listKey.Length - 1, 1);
                // _employeesPresenter.DisplayByDepartment(true, listKey); //And Active
                _employeesPresenter.DisplayByDepartmentFollowMonth(true, listKey, dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year, SalaryOptionType, SalaryCalcType);
            }
            for (var i = 0; i < gridViewEmploy.RowCount; i++)
            {
                gridViewEmploy.FocusedRowHandle = i;
                var employeeId = gridViewEmploy.Columns["EmployeeId"];
                string empValue = gridViewEmploy.GetRowCellValue(i, employeeId).ToString();
                CheckCaculateStateCheckBox(int.Parse(empValue));
                CheckCaculateState(int.Parse(empValue));
            }
        }

        private void dtRefDate_Leave(object sender, EventArgs e)
        {
            //var list = grdLookUpDepartment.Properties.GetItems().GetCheckedValues();
            //txtRefNo.Text = _salaryPresenter.GetRefNoSalary(dtRefDate.DateTime.Month + "/" + dtRefDate.DateTime.Day + "/" + dtRefDate.DateTime.Year);
            //string listKey = "";// list.ToString();
            //foreach (var key in list)
            //{
            //    listKey = listKey + Convert.ToString(key) + ",";
            //}
            //if (listKey.Length > 1)
            //{
            //    listKey = listKey.Remove(listKey.Length - 1, 1);
            //    _employeesPresenter.DisplayByDepartment(true, listKey); //And Active
            //}
            //for (var i = 0; i < gridViewEmploy.RowCount; i++)
            //{
            //    gridViewEmploy.FocusedRowHandle = i;
            //    var employeeId = gridViewEmploy.Columns["EmployeeId"];
            //    string empValue = gridViewEmploy.GetRowCellValue(i, employeeId).ToString();
            //    CheckCaculateStateCheckBox(int.Parse(empValue));
            //    CheckCaculateState(int.Parse(empValue));
            //}
        }

        #endregion

        #region Combobox

        public IList<DepartmentModel> Departments
        {
            set
            {
                if (value == null) return;
                grdLookUpDepartment.Properties.DataSource = value;
                grdLookUpDepartment.Properties.DisplayMember = "DepartmentName";
                grdLookUpDepartment.Properties.ValueMember = "DepartmentId";
            }
        }

        public IList<CurrencyModel> Currencies
        {
            set
            {
                if (value == null) return;

                grdLookUpCurrency.Properties.DataSource = value;

                grdLookUpCurrency.Properties.PopulateColumns();
                var gridColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  180 },
                                                new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 220 },
                                                new XtraColumn { ColumnName = "Prefix", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Suffix", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsMain", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                                            };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpCurrency.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpCurrency.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpCurrency.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else { grdLookUpCurrency.Properties.Columns[column.ColumnName].Visible = false; }
                }
                grdLookUpCurrency.Properties.DisplayMember = "CurrencyCode";
                grdLookUpCurrency.Properties.ValueMember = "CurrencyCode";
            }
        }

        #endregion

        #region Function

        private void ResetBtnState()
        {
            btnCalSalary.Enabled = true;
            btnShowVoucher.Enabled = true;
        }

        private void CheckCaculateState(int employeeId ) 
        {
            //try
            //{
            //bool flag = RefDate != null && _salaryPresenter.CheckCalSalaryState(DateTime.Parse(RefDate), employeeId);
            //if (flag)
            //{
            //    _employeesPresenter.DisplayForSalary(DateTime.Parse(RefDate));
            //    picDaTinh.Visible = true;
            //    btnCalSalary.Enabled = false;
            //  var obj=  _salaryPresenter.GetCalSalaryState(DateTime.Parse(RefDate), EmployeeId);
            //    txtRefNo.Text = obj.RefNo;
            //    grdLookUpCurrency.EditValue = obj.CurrencyCode;
            //    txtRateCurrency.Text = Convert.ToString(obj.ExchangeRate);
            //    Selection.SelectAll();

            //}

            //else
            //{
            //    txtRefNo.Text = _refNoFirst;
            //    grdLookUpCurrency.EditValue = _currencyCodeFirst;
            //    picDaTinh.Visible = false;
            //    btnShowRef.Enabled = false;
            //    btnCancel.Enabled = false;
            //    btnPosted.Enabled = false;
            //}
            //}
            //catch (Exception e)
            //{
            //    XtraMessageBox.Show(e.Message, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error); 
            //}
        }

        private void CheckCaculateStateCheckBox(int employeeId) 
        {
            //bool flag = RefDate != null && _salaryPresenter.CheckCalSalaryState(DateTime.Parse(RefDate), employeeId);
            //if (flag)
            //    Selection.SelectRow(gridViewEmploy.FocusedRowHandle, true);
            //else
            //    Selection.SelectRow(gridViewEmploy.FocusedRowHandle, false);
        }

        private bool CheckValidateCalSalary()
        {
            if (_checkCurrencyCodeOfSalary == false)
            {
                XtraMessageBox.Show("Loại tiền trả lương trong các khoản lương chưa chính xác!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Selection.SelectedCount == 0)
            {
                XtraMessageBox.Show("Chưa chọn nhân viên!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (gridViewEmploy.RowCount == 0)
            {
                XtraMessageBox.Show("Không có nhân viên nào để tính lương!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpDepartment.Focus();
                return false;
            }
            if (gridViewSalary.RowCount == 0)
            {
                XtraMessageBox.Show("Tồn tại nhân viên chưa có khoản lương!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpDepartment.Focus();
                return false;
            }
            if (CurrencyCodeSalary == null)
            {
                XtraMessageBox.Show("Chưa chọn loại tiền", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRateCurrency.Focus();

                return false;
            }
            if (grdLookUpCurrency.EditValue.ToString() != CurrencyCodeSalary)
            {
                XtraMessageBox.Show("Loại tiền chưa đúng!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ExchangeRate == 0)
            {
                XtraMessageBox.Show("Chưa nhập tỷ giá", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRateCurrency.Focus();

                return false;
            }
            if (RefDate == "")
            {
                XtraMessageBox.Show("Chưa nhập ngày chứng từ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();

                return false;
            }
            if (RefNo == "")
            {
                XtraMessageBox.Show("Chưa nhập mã chứng từ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();

                return false;
            }
            return true;
        }

        protected void FormatControl(Control oContainer)
        {
            foreach (Control control in oContainer.Controls)
            {
                if (control.GetType() == typeof(DateEdit))
                {

                    ((DateEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((DateEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(SpinEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "n0";
                    }
                    if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((SpinEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "c4";
                    }
                    if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "P2";
                    }
                    if ((string)control.Tag == ControlValueType.Money.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "c2";
                    }
                    ((SpinEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((SpinEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(CalcEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "n0";
                    }
                    if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((CalcEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((CalcEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "c4";
                    }
                    if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "P2";
                    }
                    if ((string)control.Tag == ControlValueType.Money.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "c2";
                    }
                    ((CalcEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((CalcEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.Controls.Count > 0)
                {
                    FormatControl(control);
                }
            }
        }

        protected void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + _dbOptionHelper.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryCurrencyCalcEdit.Precision = int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        private void LoadGridLayoutSalary()
        {
            if (gridViewSalary.Columns.Count > 0)
            {
                gridViewSalary.Columns["Amount"].Caption = @"Số tiền";
                gridViewSalary.Columns["Amount"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridViewSalary.Columns["Amount"].UnboundType = UnboundColumnType.Decimal;
                gridViewSalary.Columns["PayItemId"].Caption = @"Khoản lương";
                gridViewSalary.Columns["PayItemId"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridViewSalary.Columns["PayItemId"].ColumnEdit = RepositoryPayItemId;
                gridViewSalary.Columns["EmployeePayItemId"].Visible = false;
                gridViewSalary.Columns["EmployeeId"].Visible = false;
                gridViewSalary.Columns["SalaryRatio"].Visible = false;
            }
            SetNumericFormatControl(gridViewSalary, true);

        }

        private void LoadGridEmployeesLayout()
        {

            if (gridViewEmploy.Columns.Count > 0)
            {
                gridViewEmploy.Columns["EmployeeName"].Caption = @"Danh sách nhân viên";
                gridViewEmploy.Columns["EmployeeId"].Visible = false;
                gridViewEmploy.Columns["EmployeeId"].Width = 120;
                gridViewEmploy.Columns["EmployeeCode"].Visible = false;
                gridViewEmploy.Columns["SortOrder"].Visible = false;
                gridViewEmploy.Columns["BirthDate"].Visible = false;
                gridViewEmploy.Columns["TypeOfSalary"].Visible = false;
                gridViewEmploy.Columns["JobCandidateName"].Visible = false;
                gridViewEmploy.Columns["Sex"].Visible = false;
                gridViewEmploy.Columns["LevelOfSalary"].Visible = false;
                gridViewEmploy.Columns["DepartmentId"].Visible = false;
                gridViewEmploy.Columns["CurrencyCode"].Visible = false;
                gridViewEmploy.Columns["IdentityNo"].Visible = false;
                gridViewEmploy.Columns["IssueDate"].Visible = false;
                gridViewEmploy.Columns["IssueBy"].Visible = false;
                gridViewEmploy.Columns["IsActive"].Visible = false;
                gridViewEmploy.Columns["Description"].Visible = false;
                gridViewEmploy.Columns["Address"].Visible = false;
                gridViewEmploy.Columns["PhoneNumber"].Visible = false;
                gridViewEmploy.Columns["EmployeePayItems"].Visible = false;
                gridViewEmploy.Columns["RetiredDate"].Visible = false;
                gridViewEmploy.Columns["StartingDate"].Visible = false;
                gridViewEmploy.Columns["IsOffice"].Visible = false;
                
            }
        }



        #endregion

        #region Property

        public bool StateCheck { get; set; } //Khi người dùng thao tác chọn trên Lưới IsActive = false, IsNotAcctive =false
        public int RowForcus { get; set; } // Dòng đang trỏ đến

        public long EmployeePayrollId
        {
            get;
            set;
        }
        public decimal TotalAmountOc
        {
            get
            {
                decimal amount = 0;
                if (gridSalary.DataSource != null && gridViewSalary.RowCount > 0)
                {
                    for (var i = 0; i < gridViewSalary.RowCount; i++)
                    {
                        if (gridViewSalary.GetRow(i) != null)
                        {
                            amount = amount + (decimal)gridViewSalary.GetRowCellValue(i, "Amount");

                        }
                    }
                }
                return amount;
            }
        }
        public decimal TotalAmountExchange
        {
            get;
            set;
        }
        public int RefTypeId
        {
            get { return 600; //(int)FrmXtraBaseVoucherDetail.RefType.Salary;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }
        public string RefDate
        {
            get { return dtRefDate.Text; }
            set { dtRefDate.Text = value; }
        }
        public string PostedDate
        {
            get { return dtRefDate.Text; }
            set { dtRefDate.Text = value; }
        }
        public string CurrencyCodeSalary
        {
            get
            {
                if (grdLookUpCurrency.EditValue == null) return null;
                return (string)grdLookUpCurrency.GetColumnValue("CurrencyCode");
            }
            set
            {
                grdLookUpCurrency.EditValue = value;
            }
        }
        public string JournalMemo
        {
            get;
            set;
        }
        public decimal ExchangeRate
        {
            get { return txtRateCurrency.Value; }
            set { txtRateCurrency.Value = value; }
        }
        public IList<EmployeeModel> Employees //use IEmployeesView for set fill grid 
        {
            set
            {
                if (value == null) 
                    value = new List<EmployeeModel>();
                grdlookUpEmployee.DataSource = value;
            }
        }
        IList<EmployeeModel> ISalaryView.Employees // get for IView
        {
            get
            {
                //  decimal amount = 0;
                var employeeModel = new List<EmployeeModel>();
                if (grdlookUpEmployee.DataSource != null && gridViewEmploy.RowCount > 0)
                {
                    for (var i = 0; i < gridViewEmploy.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i)) 
                        {
                            var row = (EmployeeModel)gridViewEmploy.GetRow(i);
                            employeeModel.Add(row);
                        }
                    }
                }
                return employeeModel;
            }
        }

        public int EmployeeId
        {
            get
            {
                var employeeId = gridViewEmploy.Columns["EmployeeId"];
                if (gridViewEmploy.FocusedRowHandle > -1)
                    return (int)gridViewEmploy.GetRowCellValue(gridViewEmploy.FocusedRowHandle, employeeId);
                return 0;
            }
        }
        int IEmployeeView.EmployeeId { get; set; }
        public string EmployeeCode
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public int SortOrder
        {
            get;
            set;
        }
        public string BirthDate
        {
            get;
            set;
        }
        public int TypeOfSalary
        {
            get;
            set;
        }
        public bool Sex
        {
            get;
            set;
        }
        public string LevelOfSalary
        {
            get;
            set;
        }
        public int? DepartmentId
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public string IdentityNo
        {
            get;
            set;
        }
        public string IssueDate
        {
            get;
            set;
        }
        public string IssueBy
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string RetiredDate { get; set; }
        public string StartingDate { get; set; }

        public IList<EmployeePayItemModel> EmployeePayItems
        {
            get
            {
                var employeePayItemModel = new List<EmployeePayItemModel>();
                if (grdlookUpEmployee.DataSource != null && gridViewEmploy.RowCount > 0)
                {
                    for (var i = 0; i < gridViewSalary.RowCount; i++)
                    {
                        if (gridViewSalary.IsRowSelected(i))
                        {
                            var row = (EmployeePayItemModel)gridViewSalary.GetRow(i);
                            employeePayItemModel.Add(row);
                        }
                    }
                }
                return employeePayItemModel;
            }//Ko làm gì
            set
            {

                gridSalary.DataSource = value ?? new List<EmployeePayItemModel>();
            }

        }

        //Only for Fill data to RepositoryItemLookUpEdit RepositoryPayItemId -> add show for grid column
        public IList<PayItemModel> PayItems
        {
            set
            {
                if (value == null) return;
                RepositoryPayItemId.DataSource = value;
                IList<PayItemModel> list = value;
                for (int i = 0; i < list.Count()-1; i++)
                {
                    if (list[i].CreditAccountCode!=list[i+1].CreditAccountCode) 
                    {
                        _checkCurrencyCodeOfSalary = false;
                    }
                }
                if (list.Count > 0 &&(list[0].CreditAccountCode == "11122" || list[0].CreditAccountCode == "11222"))
                {
                    grdLookUpCurrency.EditValue = _dbOptionHelper.CurrencyLocal;
                    _currencyCodeFirst = grdLookUpCurrency.EditValue.ToString();
                }
                else
                {
                    grdLookUpCurrency.EditValue = _dbOptionHelper.CurrencyAccounting;
                    _currencyCodeFirst = grdLookUpCurrency.EditValue.ToString();
                }
             
                RepositoryPayItemId.PopulateColumns();
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "PayItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PayItemCode", ColumnCaption = "Mã khoản lương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120},
                        new XtraColumn {ColumnName = "PayItemName", ColumnCaption = "Tên khoản lương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250 },
                        new XtraColumn {ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150 },
                        new XtraColumn {ColumnName = "Type", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsCalculateRatio", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSocialInsurance", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsCareInsurance", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsTradeUnionFee", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DebitAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CreditAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsDefault", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetCategoryCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetGroupCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false}
                    };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        RepositoryPayItemId.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        RepositoryPayItemId.SortColumnIndex = column.ColumnPosition;
                        RepositoryPayItemId.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else { RepositoryPayItemId.Columns[column.ColumnName].Visible = false; }
                }
                RepositoryPayItemId.DisplayMember = "PayItemName";
                RepositoryPayItemId.ValueMember = "PayItemId";
            }
        }

        public string JobCandidateName
        {
            get;
            set;
         
        }
        public bool IsOffice
        {
            get;
            set;
        }
        public string Content { get; set; }
        public DateTime LockDate { get; set; }
        public bool IsLock { get; set; }

        #endregion

    }
}