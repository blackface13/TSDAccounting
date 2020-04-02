/***********************************************************************
 * <copyright file="FrmXtraCompanyProfileDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, September 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.CompanyProfile;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.EmployeeLeasing;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// FrmXtraCompanyProfileDetail
    /// </summary>
    public partial class FrmXtraCompanyProfileDetail : FrmXtraBaseCategoryDetail, ICompanyProfileView, IEmployeesView,IEmployeeLeasingsView
    {
        public BindingSource employeesBindingSource;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        /// <summary>
        /// The _company profile presenter
        /// </summary>
        private readonly CompanyProfilePresenter _companyProfilePresenter;
        private readonly EmployeesPresenter _employeesPresenter;
        private readonly EmployeeLeasingsPresenter _employeeLeasingsPresenter;

        public GlobalVariable CommonVariable { get; set; }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraCompanyProfileDetail"/> class.
        /// </summary>
        public FrmXtraCompanyProfileDetail()
        {
            InitializeComponent();
            employeesBindingSource = new BindingSource();
            CommonVariable = new GlobalVariable();
            _companyProfilePresenter = new CompanyProfilePresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _employeeLeasingsPresenter = new EmployeeLeasingsPresenter(this);
        }

        #region ICompanyProfileView member
        /// <summary>
        /// Gets or sets the line identifier.
        /// </summary>
        /// <value>
        /// The line identifier.
        /// </value>
        public int LineId { get; set; }

        /// <summary>
        /// Gets or sets the asset own area.
        /// </summary>
        /// <value>
        /// The asset own area.
        /// </value>
        public float AssetOwnArea
        {
            get { return Convert.ToSingle(txtAssetOwnArea.EditValue); }
            set { txtAssetOwnArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset own room.
        /// </summary>
        /// <value>
        /// The asset own room.
        /// </value>
        public int AssetOwnRoom
        {
            get { return Convert.ToInt16(txtAssetOwnRoom.EditValue); }
            set { txtAssetOwnRoom.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset buy date.
        /// </summary>
        /// <value>
        /// The asset buy date.
        /// </value>
        public DateTime AssetBuyDate
        {
            get { return dtAssetBuyDate.DateTime; }
            set { dtAssetBuyDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset own description.
        /// </summary>
        /// <value>
        /// The asset own description.
        /// </value>
        public string AssetOwnDescription
        {
            get { return txtAssetOwnDescription.Text; }
            set { txtAssetOwnDescription.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset mutual area.
        /// </summary>
        /// <value>
        /// The asset mutual area.
        /// </value>
        public float AssetMutualArea
        {
            get { return Convert.ToSingle(txtAssetMutualArea.EditValue); }
            set { txtAssetMutualArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset mutual room.
        /// </summary>
        /// <value>
        /// The asset mutual room.
        /// </value>
        public int AssetMutualRoom
        {
            get { return Convert.ToInt16(txtAssetMutualRoom.EditValue); }
            set { txtAssetMutualRoom.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset mutual method.
        /// </summary>
        /// <value>
        /// The asset mutual method.
        /// </value>
        public string AssetMutualMethod
        {
            get { return txtAssetMutualMethod.Text; }
            set { txtAssetMutualMethod.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset mutual description.
        /// </summary>
        /// <value>
        /// The asset mutual description.
        /// </value>
        public string AssetMutualDescription
        {
            get { return txtAssetMutualDescription.Text; }
            set { txtAssetMutualDescription.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the length of the asset rent contract.
        /// </summary>
        /// <value>
        /// The length of the asset rent contract.
        /// </value>
        public int AssetRentContractLen
        {
            get { return Convert.ToInt16(txtAssetRentContractLen.EditValue); }
            set { txtAssetRentContractLen.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset rent price.
        /// </summary>
        /// <value>
        /// The asset rent price.
        /// </value>
        public decimal AssetRentPrice
        {
            get { return Convert.ToDecimal(txtAssetRentPrice.EditValue); }
            set { txtAssetRentPrice.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset rent room.
        /// </summary>
        /// <value>
        /// The asset rent room.
        /// </value>
        public int AssetRentRoom
        {
            get { return Convert.ToInt16(txtAssetRentRoom.EditValue); }
            set { txtAssetRentRoom.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset rent area.
        /// </summary>
        /// <value>
        /// The asset rent area.
        /// </value>
        public float AssetRentArea
        {
            get { return Convert.ToSingle(txtAssetRentArea.EditValue); }
            set { txtAssetRentArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset rent description.
        /// </summary>
        /// <value>
        /// The asset rent description.
        /// </value>
        public string AssetRentDescription
        {
            get { return txtAssetRentDescription.Text; }
            set { txtAssetRentDescription.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset number of cars.
        /// </summary>
        /// <value>
        /// The asset number of cars.
        /// </value>
        public int AssetNumberOfCars
        {
            get { return Convert.ToInt16(txtAssetNumberOfCars.EditValue); }
            set { txtAssetNumberOfCars.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the asset car detail.
        /// </summary>
        /// <value>
        /// The asset car detail.
        /// </value>
        public string AssetCarDetail
        {
            get { return txtAssetCarDetail.Text; }
            set { txtAssetCarDetail.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the employee payrolls total.
        /// </summary>
        /// <value>
        /// The employee payrolls total.
        /// </value>
        public int EmployeePayrollsTotal
        {
            get { return int.Parse(txtEmployeePayrollsTotal.Text); }
            set
            {
                txtEmployeePayrollsTotal.EditValue = value;
                //List<EmployeeModel> employees = _employeesPresenter.GetEmployees();
                //int employeePayrollsTotal = employees.Where(x => x.StartingDate != null && x.RetiredDate != null && DateTime.Parse(x.StartingDate) <= DateTime.Parse(CommonVariable.PostedDate)&& DateTime.Parse(x.RetiredDate) >= DateTime.Parse(CommonVariable.PostedDate) &&  x.IsOffice == false).ToList().Count()
                //    + employees.Where(x =>x.StartingDate != null && x.RetiredDate != null&& DateTime.Parse(x.StartingDate) <= DateTime.Parse(CommonVariable.PostedDate)
                //    && DateTime.Parse(x.RetiredDate) >= DateTime.Parse(CommonVariable.PostedDate) && x.IsOffice).ToList().Count();
                //txtEmployeePayrollsTotal.EditValue = employeePayrollsTotal;
            }
        }

        /// <summary>
        /// Gets or sets the employee number of wife or husband.
        /// </summary>
        /// <value>
        /// The employee number of wife or husband.
        /// </value>
        public int EmployeeNumberOfWifeOrHusband
        {
            get { return Convert.ToInt16(txtEmployeeNumberOfWifeOrHusband.EditValue); }
            set
            {
                //List<EmployeeModel> employeeNumberOfWifeOrHusband = _employeesPresenter.GetEmployees();
                //txtEmployeeNumberOfWifeOrHusband.EditValue =
                //    employeeNumberOfWifeOrHusband.Where(
                //        x => x.StartingDate != null && x.RetiredDate != null && DateTime.Parse(x.StartingDate) <= DateTime.Parse(CommonVariable.PostedDate)
                //             && DateTime.Parse(x.RetiredDate) >= DateTime.Parse(CommonVariable.PostedDate) &&
                //             x.IsOffice == false).ToList().Count();
                txtEmployeeNumberOfWifeOrHusband.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the employee number of officers.
        /// </summary>
        /// <value>
        /// The employee number of officers.
        /// </value>
        public int EmployeeNumberOfOfficers
        {
            get
            {
                return Convert.ToInt16(txtEmployeeNumberOfOfficers.EditValue);
            }
            set
            {
                //List<EmployeeModel> employeeNumberOfOfficers = _employeesPresenter.GetEmployees();
                //txtEmployeeNumberOfOfficers.EditValue = employeeNumberOfOfficers.Where(x => x.StartingDate != null && x.RetiredDate != null && DateTime.Parse(x.StartingDate) <= DateTime.Parse(CommonVariable.PostedDate)
                //   && DateTime.Parse(x.RetiredDate) >= DateTime.Parse(CommonVariable.PostedDate) && x.IsOffice).ToList().Count().ToString();
                txtEmployeeNumberOfOfficers.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the employee number of staff.
        /// </summary>
        /// <value>
        /// The employee number of staff.
        /// </value>
        public int EmployeeNumberOfStaff
        {
            get { return Convert.ToInt16(txtEmployeeNumberOfStaff.EditValue); }
            set{txtEmployeeNumberOfStaff.EditValue = value;}
        }

        /// <summary>
        /// Gets or sets the employee other company.
        /// </summary>
        /// <value>
        /// The employee other company.
        /// </value>
        public int EmployeeOtherCompany
        {
            get { return Convert.ToInt16(txtEmployeeOtherCompany.EditValue); }
            set
            {
                List<EmployeeLeasingModel> employeeLeasing = _employeeLeasingsPresenter.GetEmployeeLeasings();
                txtEmployeeOtherCompany.EditValue = employeeLeasing.Where(x => x.StartDate <= DateTime.Parse(CommonVariable.PostedDate)
                    && x.EndDate >= DateTime.Parse(CommonVariable.PostedDate)).ToList().Count().ToString();
                //txtEmployeeOtherCompany.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the employee number of seconding officers.
        /// </summary>
        /// <value>
        /// The employee number of seconding officers.
        /// </value>
        public int EmployeeNumberOfSecondingOfficers
        {
            get { return Convert.ToInt16(txtEmployeeNumberOfSecondingOfficers.EditValue); }
            set { txtEmployeeNumberOfSecondingOfficers.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the employee detail.
        /// </summary>
        /// <value>
        /// The employee detail.
        /// </value>
        public string EmployeeDetail
        {
            get { return txtEmployeeDetail.Text; }
            set { txtEmployeeDetail.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the employee number of rent local.
        /// </summary>
        /// <value>
        /// The employee number of rent local.
        /// </value>
        public int EmployeeNumberOfRentLocal
        {
            get { return Convert.ToInt16(txtEmployeeNumberOfRentLocal.EditValue); }
            set
            {
                List<EmployeeLeasingModel> employeeLeasing = _employeeLeasingsPresenter.GetEmployeeLeasings(true);
                txtEmployeeNumberOfRentLocal.EditValue = employeeLeasing.Where(x => x.StartDate <= DateTime.Parse(CommonVariable.PostedDate)
                    && x.EndDate >= DateTime.Parse(CommonVariable.PostedDate)).ToList().Count().ToString();
            }
        }

        /// <summary>
        /// Gets or sets the profile address.
        /// </summary>
        /// <value>
        /// The profile address.
        /// </value>
        public string ProfileAddress
        {
            get { return txtProfileAddress.Text; }
            set { txtProfileAddress.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile found date.
        /// </summary>
        /// <value>
        /// The profile found date.
        /// </value>
        public DateTime ProfileFoundDate
        {
            get{return dtProfileFoundDate.DateTime;}
            set { dtProfileFoundDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile head phone.
        /// </summary>
        /// <value>
        /// The profile head phone.
        /// </value>
        public string ProfileHeadPhone
        {
            get { return txtProfileHeadPhone.Text; }
            set { txtProfileHeadPhone.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the profile ambassador.
        /// </summary>
        /// <value>
        /// The name of the profile ambassador.
        /// </value>
        public string ProfileAmbassadorName
        {
            get { return txtProfileAmbassadorName.Text; }
            set { txtProfileAmbassadorName.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile ambassador phone.
        /// </summary>
        /// <value>
        /// The profile ambassador phone.
        /// </value>
        public string ProfileAmbassadorPhone
        {
            get { return txtProfileAmbassadorPhone.Text; }
            set { txtProfileAmbassadorPhone.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile ambassador start date.
        /// </summary>
        /// <value>
        /// The profile ambassador start date.
        /// </value>
        public DateTime ProfileAmbassadorStartDate
        {
            get { return dtProfileAmbassadorStartDate.DateTime; }
            set { dtProfileAmbassadorStartDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile ambassador finish date.
        /// </summary>
        /// <value>
        /// The profile ambassador finish date.
        /// </value>
        public DateTime ProfileAmbassadorFinishDate
        {
            get { return dtProfileAmbassadorFinishDate.DateTime; }
            set { dtProfileAmbassadorFinishDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the profile accounting manager.
        /// </summary>
        /// <value>
        /// The name of the profile accounting manager.
        /// </value>
        public string ProfileAccountingManagerName
        {
            get { return txtProfileAccountingManagerName.Text; }
            set { txtProfileAccountingManagerName.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile accounting manager phone.
        /// </summary>
        /// <value>
        /// The profile accounting manager phone.
        /// </value>
        public string ProfileAccountingManagerPhone
        {
            get { return txtProfileAccountingManagerPhone.Text; }
            set { txtProfileAccountingManagerPhone.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile accounting manager start date.
        /// </summary>
        /// <value>
        /// The profile accounting manager start date.
        /// </value>
        public DateTime ProfileAccountingManagerStartDate
        {
            get { return dtProfileAccountingManagerStartDate.DateTime; }
            set { dtProfileAccountingManagerStartDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile accounting manager finish date.
        /// </summary>
        /// <value>
        /// The profile accounting manager finish date.
        /// </value>
        public DateTime ProfileAccountingManagerFinishDate
        {
            get { return dtProfileAccountingManagerFinishDate.DateTime; }
            set { dtProfileAccountingManagerFinishDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the profile accountant.
        /// </summary>
        /// <value>
        /// The name of the profile accountant.
        /// </value>
        public string ProfileAccountantName
        {
            get { return txtProfileAccountantName.Text; }
            set { txtProfileAccountantName.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile accountant phone.
        /// </summary>
        /// <value>
        /// The profile accountant phone.
        /// </value>
        public string ProfileAccountantPhone
        {
            get { return txtProfileAccountantPhone.Text; }
            set { txtProfileAccountantPhone.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile accountant start date.
        /// </summary>
        /// <value>
        /// The profile accountant start date.
        /// </value>
        public DateTime ProfileAccountantStartDate
        {
            get { return dtProfileAccountantStartDate.DateTime; }
            set { dtProfileAccountantStartDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile accountant finish date.
        /// </summary>
        /// <value>
        /// The profile accountant finish date.
        /// </value>
        public DateTime ProfileAccountantFinishDate
        {
            get { return dtProfileAccountantFinishDate.DateTime; }
            set { dtProfileAccountantFinishDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile minimum salary.
        /// </summary>
        /// <value>
        /// The profile minimum salary.
        /// </value>
        public decimal ProfileMinimumSalary
        {
            get { return Convert.ToDecimal(txtProfileMinimumSalary.EditValue); }
            set { txtProfileMinimumSalary.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile salary group.
        /// </summary>
        /// <value>
        /// The profile salary group.
        /// </value>
        public string ProfileSalaryGroup
        {
            get { return txtProfileSalaryGroup.Text; }
            set { txtProfileSalaryGroup.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile working area.
        /// </summary>
        /// <value>
        /// The profile working area.
        /// </value>
        public string ProfileWorkingArea
        {
            get { return txtProfileWorkingArea.Text; }
            set { txtProfileWorkingArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile currency code finalization.
        /// </summary>
        /// <value>
        /// The profile currency code finalization.
        /// </value>
        public string ProfileCurrencyCodeFinalization
        {
            get { return cboProfileCurrencyCodeFinalization.Text; }
            set { cboProfileCurrencyCodeFinalization.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile services.
        /// </summary>
        /// <value>
        /// The profile services.
        /// </value>
        public string ProfileServices
        {
            get { return txtProfileServices.Text; }
            set { txtProfileServices.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile report header.
        /// </summary>
        /// <value>
        /// The profile report header.
        /// </value>
        public string ProfileReportHeader { get; set; }

        /// <summary>
        /// Gets or sets the name of the profile bank.
        /// </summary>
        /// <value>
        /// The name of the profile bank.
        /// </value>
        public string ProfileBankName
        {
            get { return txtProfileBankName.Text; }
            set { txtProfileBankName.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile bank address.
        /// </summary>
        /// <value>
        /// The profile bank address.
        /// </value>
        public string ProfileBankAddress
        {
            get { return txtProfileBankAddress.Text; }
            set { txtProfileBankAddress.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile bank account.
        /// </summary>
        /// <value>
        /// The profile bank account.
        /// </value>
        public string ProfileBankAccount
        {
            get { return txtProfileBankAccount.Text; }
            set { txtProfileBankAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the profile bank cif.
        /// </summary>
        /// <value>
        /// The profile bank cif.
        /// </value>
        public string ProfileBankCIF
        {
            get { return txtProfileBankCIF.Text; }
            set { txtProfileBankCIF.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the other note.
        /// </summary>
        /// <value>
        /// The other note.
        /// </value>
        public string OtherNote
        {
            get { return ""; }
            set {  }
        }

        public int NativeCategory
        {
            get { return cboNativeCategory.SelectedIndex; }
            set { cboNativeCategory.SelectedIndex = value; }
        }

        public int ManagementArea
        {
            get { return cboManagementArea.SelectedIndex; }
            set { cboManagementArea.SelectedIndex = value;}
        }

        #endregion



        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            
            Text = ResourceHelper.GetResourceValueByName("ResCompanyProfileFormCaption");
            KeyValue = "1";
            txtCompanyCode.Text = GlobalVariable.CompanyCode;
            txtProfileAddress.Text = GlobalVariable.CompanyAddress;
            
            if (KeyValue != null) { _companyProfilePresenter.Display(KeyValue); }

            
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            dtProfileFoundDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate);
            dtProfileAmbassadorStartDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate);
            dtProfileAmbassadorFinishDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate).AddYears(3);
            dtProfileAccountingManagerStartDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate);
            dtProfileAccountingManagerFinishDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate).AddYears(3);
            dtProfileAccountantStartDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate);
            dtProfileAccountantFinishDate.DateTime = DateTime.Parse(GlobalVariable.StartedDate).AddYears(3);
            dtAssetBuyDate.DateTime = DateTime.Now;
        }


        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            LineId = 1;
            
            int res = _companyProfilePresenter.Save();
            if (res > 0)
            {
                XtraMessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            return res;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            try
            {
                cboProfileCurrencyCodeFinalization.Properties.Items.Add(CommonVariable.CurrencyLocal);
                if (CommonVariable.CurrencyLocal != CommonVariable.CurrencyAccounting)
                {
                    cboProfileCurrencyCodeFinalization.Properties.Items.Add(CommonVariable.CurrencyAccounting);
                    cboProfileCurrencyCodeFinalization.EditValue = cboProfileCurrencyCodeFinalization.Properties.Items[1];
                }
                else
                    cboProfileCurrencyCodeFinalization.EditValue = cboProfileCurrencyCodeFinalization.Properties.Items[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void FrmXtraCompanyProfileDetail_Load(object sender, EventArgs e)
        {
            LoadData();
            
           
        }

        public IList<EmployeeModel> Employees
        { set; private get; }

        public IList<EmployeeLeasingModel> EmployeeLeasings { set; private get; }

        protected override void ShowHelp()
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(2010));
        }
    }
}