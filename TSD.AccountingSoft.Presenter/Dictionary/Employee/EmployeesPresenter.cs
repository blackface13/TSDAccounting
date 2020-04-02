/***********************************************************************
 * <copyright file="EmployeesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Employee
{
    /// <summary>
    /// EmployeesPresenter
    /// </summary>
    public class EmployeesPresenter : Presenter<IEmployeesView>
    {
        private CompanyProfileModel _companyProfile;
        private IList<DBOptionModel> _dbOptions;
        private DBOptionModel dbOptionModel;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public EmployeesPresenter(IEmployeesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Employees = Model.GetEmployees();
        }

        public List<EmployeeModel> GetEmployees()
        {
            var employee = Model.GetEmployees().ToList();
            return employee;
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void DisplayActive()
        {
            View.Employees = Model.GetEmployeesActive();
        }

        /// <summary>
        /// Displays the by department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        public void DisplayByDepartment(int departmentId)
        {
            View.Employees = Model.GetEmployeesByDepartmentId(departmentId);
        }

        /// <summary>
        /// Displays the active by department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        public void DisplayActiveByDepartment(int departmentId)
        {
            View.Employees = Model.GetActiveEmployeesByDepartmentId(departmentId);
        }

        /// <summary>
        /// Displays the by department.
        /// </summary>
        /// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        /// <param name="departmentId">The department identifier.</param>
        public void DisplayByDepartment(bool isListDepartment, string departmentId)
        {
            View.Employees = Model.GetEmployeesByDepartmentId(isListDepartment, departmentId);
        }


        public void DisplayByDepartmentFollowMonth(bool isListDepartment, string departmentId, string strDate,int salaryOptionType,int salaryCalcType)
        {
            View.Employees = Model.GetEmployeesByDepartmentIdAndMonth(isListDepartment, departmentId, strDate, salaryOptionType, salaryCalcType);
        }


        public void DisplayByMonthDateAndRefNo(string strDate,string refNo)
        {
            View.Employees = Model.GetEmployeesByMonthDateAndRefNo(strDate, refNo);
        }


        public void DisplayIsRetail(string monthDate,bool isRetail)
        {
            View.Employees = Model.GetEmployeesIsRetail(monthDate, isRetail);
        }


        /// <summary>
        /// Displays the by department.
        /// </summary>
        /// <param name="refdate">The refdate.</param>
        public void DisplayForSalary(DateTime refdate)    
        {
            View.Employees = Model.GetEmployeesByRefdateSalary(refdate);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCompanyProfile()
        {
            _companyProfile = Model.GetCompanyProfile(1);
            _dbOptions  = Model.GetDBOptions();
           // List<EmployeeModel> employeeNumberOfOfficers = _employeesPresenter.GetEmployees();
              //  txtEmployeeNumberOfOfficers.EditValue = employeeNumberOfOfficers.Where(x => DateTime.Parse(x.StartingDate) <= DateTime.Parse(CommonVariable.PostedDate)
               //     && DateTime.Parse(x.RetiredDate) >= DateTime.Parse(CommonVariable.PostedDate) && x.IsOffice).ToList().Count().ToString();
            int employeeNumberOfOfficerCount = 0;
            int employeeNumberOfWifeOrHusbandCount = 0;
            int employeeNumberCount = 0;
            DateTime postedDate;
            foreach (var optionModel in _dbOptions)
            {
                if (optionModel.OptionId == "PostedDate")
                {
                    postedDate = DateTime.Parse(optionModel.OptionValue);
                    var employeeNumberOfOfficers =
                        Model.GetEmployees()
                            .Where(x => x.RetiredDate != null && DateTime.Parse(x.RetiredDate) >= postedDate && x.IsOffice && x.IsActive);
                    int Count = employeeNumberOfOfficers.Count();
                    employeeNumberOfOfficerCount = employeeNumberOfOfficerCount + Count;

                    var employeeNumberOfWifeOrHusband =
                        Model.GetEmployees()
                            .Where(x => x.RetiredDate != null && DateTime.Parse(x.RetiredDate) >= postedDate && x.IsOffice == false && x.IsActive);
                    int CountEmployeeNumberOfWifeOrHusband = employeeNumberOfWifeOrHusband.Count();
                    employeeNumberOfWifeOrHusbandCount = employeeNumberOfWifeOrHusbandCount + CountEmployeeNumberOfWifeOrHusband;

                    employeeNumberCount = employeeNumberOfWifeOrHusbandCount + employeeNumberOfOfficerCount;

                }
            }
            int a = 0;
  
            var companyProfile = new CompanyProfileModel
            {
                LineId = _companyProfile.LineId,
                AssetOwnArea = _companyProfile.AssetOwnArea,
                AssetOwnRoom = _companyProfile.AssetOwnRoom,
                AssetBuyDate = _companyProfile.AssetBuyDate,
                AssetOwnDescription = _companyProfile.AssetOwnDescription,
                AssetMutualArea = _companyProfile.AssetMutualArea,
                AssetMutualRoom = _companyProfile.AssetMutualRoom,
                AssetMutualMethod = _companyProfile.AssetMutualMethod,
                AssetMutualDescription = _companyProfile.AssetMutualDescription,
                AssetRentContractLen = _companyProfile.AssetRentContractLen,
                AssetRentPrice = _companyProfile.AssetRentPrice,
                AssetRentRoom = _companyProfile.AssetRentRoom,
                AssetRentArea = _companyProfile.AssetRentArea,
                AssetRentDescription = _companyProfile.AssetRentDescription,
                AssetNumberOfCars = _companyProfile.AssetNumberOfCars,
                AssetCarDetail = _companyProfile.AssetCarDetail,
                EmployeePayrollsTotal = employeeNumberCount,
                EmployeeNumberOfWifeOrHusband = employeeNumberOfWifeOrHusbandCount,
                EmployeeNumberOfOfficers = employeeNumberOfOfficerCount,
                EmployeeNumberOfStaff = _companyProfile.EmployeeNumberOfStaff,
                EmployeeOtherCompany = _companyProfile.EmployeeOtherCompany,
                EmployeeNumberOfSecondingOfficers = _companyProfile.EmployeeNumberOfSecondingOfficers,
                EmployeeDetail = _companyProfile.EmployeeDetail,
                EmployeeNumberOfRentLocal = _companyProfile.EmployeeNumberOfRentLocal,
                ProfileAddress = _companyProfile.ProfileAddress,
                ProfileFoundDate = _companyProfile.ProfileFoundDate,
                ProfileHeadPhone = _companyProfile.ProfileHeadPhone,
                ProfileAmbassadorName = _companyProfile.ProfileAmbassadorName,
                ProfileAmbassadorPhone = _companyProfile.ProfileAmbassadorPhone,
                ProfileAmbassadorStartDate = _companyProfile.ProfileAmbassadorStartDate,
                ProfileAmbassadorFinishDate = _companyProfile.ProfileAmbassadorFinishDate,
                ProfileAccountingManagerName = _companyProfile.ProfileAccountingManagerName,
                ProfileAccountingManagerPhone = _companyProfile.ProfileAccountingManagerPhone,
                ProfileAccountingManagerStartDate = _companyProfile.ProfileAccountingManagerStartDate,
                ProfileAccountingManagerFinishDate = _companyProfile.ProfileAccountingManagerFinishDate,
                ProfileAccountantName = _companyProfile.ProfileAccountantName,
                ProfileAccountantPhone = _companyProfile.ProfileAccountantPhone,
                ProfileAccountantStartDate = _companyProfile.ProfileAccountantStartDate,
                ProfileAccountantFinishDate = _companyProfile.ProfileAccountantFinishDate,
                ProfileMinimumSalary = _companyProfile.ProfileMinimumSalary,
                ProfileSalaryGroup = _companyProfile.ProfileSalaryGroup,
                ProfileWorkingArea = _companyProfile.ProfileWorkingArea,
                ProfileCurrencyCodeFinalization = _companyProfile.ProfileCurrencyCodeFinalization,
                ProfileServices = _companyProfile.ProfileServices,
                ProfileReportHeader = _companyProfile.ProfileReportHeader,
                ProfileBankName = _companyProfile.ProfileBankName,
                ProfileBankAddress = _companyProfile.ProfileBankAddress,
                ProfileBankAccount = _companyProfile.ProfileBankAccount,
                ProfileBankCIF = _companyProfile.ProfileBankCIF,
                OtherNote = _companyProfile.OtherNote
            };
            return Model.GetCompanyProfile(1) != null ? Model.UpdateCompanyProfile(companyProfile) : Model.AddCompanyProfile(companyProfile);
        }
    }
}
