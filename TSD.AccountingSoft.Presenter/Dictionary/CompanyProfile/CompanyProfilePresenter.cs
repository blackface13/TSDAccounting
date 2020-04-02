/***********************************************************************
 * <copyright file="CompanyProfilePresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, September 4, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using DevExpress.XtraSplashScreen;

namespace TSD.AccountingSoft.Presenter.Dictionary.CompanyProfile
{
    /// <summary>
    /// CompanyProfilePresenter
    /// </summary>
    public class CompanyProfilePresenter : Presenter<ICompanyProfileView>
    {
        private CompanyProfileModel _companyProfile;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyProfilePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CompanyProfilePresenter(ICompanyProfileView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified companyProfile identifier.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        public void Display(string companyProfileId)
        {
            if (companyProfileId == null) { View.LineId = 0; return; }

            _companyProfile = Model.GetCompanyProfile(int.Parse(companyProfileId));
            if (_companyProfile == null) return;

            View.LineId = _companyProfile.LineId;
            View.AssetOwnArea = _companyProfile.AssetOwnArea;
            View.AssetOwnRoom = _companyProfile.AssetOwnRoom;
            View.AssetBuyDate = _companyProfile.AssetBuyDate;
            View.AssetOwnDescription = _companyProfile.AssetOwnDescription;
            View.AssetMutualArea = _companyProfile.AssetMutualArea;
            View.AssetMutualRoom = _companyProfile.AssetMutualRoom;
            View.AssetMutualMethod = _companyProfile.AssetMutualMethod;
            View.AssetMutualDescription = _companyProfile.AssetMutualDescription;
            View.AssetRentContractLen = _companyProfile.AssetRentContractLen;
            View.AssetRentPrice = _companyProfile.AssetRentPrice;
            View.AssetRentRoom = _companyProfile.AssetRentRoom;
            View.AssetRentArea = _companyProfile.AssetRentArea;
            View.AssetRentDescription = _companyProfile.AssetRentDescription;
            View.AssetNumberOfCars = _companyProfile.AssetNumberOfCars;
            View.AssetCarDetail = _companyProfile.AssetCarDetail;
            View.EmployeePayrollsTotal = _companyProfile.EmployeePayrollsTotal;
            View.EmployeeNumberOfWifeOrHusband = _companyProfile.EmployeeNumberOfWifeOrHusband;
            View.EmployeeNumberOfOfficers = _companyProfile.EmployeeNumberOfOfficers;
            View.EmployeeNumberOfStaff = _companyProfile.EmployeeNumberOfStaff;
            View.EmployeeOtherCompany = _companyProfile.EmployeeOtherCompany;
            View.EmployeeNumberOfSecondingOfficers = _companyProfile.EmployeeNumberOfSecondingOfficers;
            View.EmployeeDetail = _companyProfile.EmployeeDetail;
            View.EmployeeNumberOfRentLocal = _companyProfile.EmployeeNumberOfRentLocal;
            View.ProfileAddress = _companyProfile.ProfileAddress;
            View.ProfileFoundDate = _companyProfile.ProfileFoundDate;
            View.ProfileHeadPhone = _companyProfile.ProfileHeadPhone;
            View.ProfileAmbassadorName = _companyProfile.ProfileAmbassadorName;
            View.ProfileAmbassadorPhone = _companyProfile.ProfileAmbassadorPhone;
            View.ProfileAmbassadorStartDate = _companyProfile.ProfileAmbassadorStartDate;
            View.ProfileAmbassadorFinishDate = _companyProfile.ProfileAmbassadorFinishDate;
            View.ProfileAccountingManagerName = _companyProfile.ProfileAccountingManagerName;
            View.ProfileAccountingManagerPhone = _companyProfile.ProfileAccountingManagerPhone;
            View.ProfileAccountingManagerStartDate = _companyProfile.ProfileAccountingManagerStartDate;
            View.ProfileAccountingManagerFinishDate = _companyProfile.ProfileAccountingManagerFinishDate;
            View.ProfileAccountantName = _companyProfile.ProfileAccountantName;
            View.ProfileAccountantPhone = _companyProfile.ProfileAccountantPhone;
            View.ProfileAccountantStartDate = _companyProfile.ProfileAccountantStartDate;
            View.ProfileAccountantFinishDate = _companyProfile.ProfileAccountantFinishDate;
            View.ProfileMinimumSalary = _companyProfile.ProfileMinimumSalary;
            View.ProfileSalaryGroup = _companyProfile.ProfileSalaryGroup;
            View.ProfileWorkingArea = _companyProfile.ProfileWorkingArea;
            View.ProfileCurrencyCodeFinalization = _companyProfile.ProfileCurrencyCodeFinalization;
            View.ProfileServices = _companyProfile.ProfileServices;
            View.ProfileReportHeader = _companyProfile.ProfileReportHeader;
            View.ProfileBankName = _companyProfile.ProfileBankName;
            View.ProfileBankAddress = _companyProfile.ProfileBankAddress;
            View.ProfileBankAccount = _companyProfile.ProfileBankAccount;
            View.ProfileBankCIF = _companyProfile.ProfileBankCIF;
            View.OtherNote = _companyProfile.OtherNote;
            View.NativeCategory = _companyProfile.NativeCategory;
            View.ManagementArea = _companyProfile.ManagementArea;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var companyProfile = new CompanyProfileModel
            {
                LineId = View.LineId,
                AssetOwnArea = View.AssetOwnArea,
                AssetOwnRoom = View.AssetOwnRoom,
                AssetBuyDate = View.AssetBuyDate,
                AssetOwnDescription = View.AssetOwnDescription,
                AssetMutualArea = View.AssetMutualArea,
                AssetMutualRoom = View.AssetMutualRoom,
                AssetMutualMethod = View.AssetMutualMethod,
                AssetMutualDescription = View.AssetMutualDescription,
                AssetRentContractLen = View.AssetRentContractLen,
                AssetRentPrice = View.AssetRentPrice,
                AssetRentRoom = View.AssetRentRoom,
                AssetRentArea = View.AssetRentArea,
                AssetRentDescription = View.AssetRentDescription,
                AssetNumberOfCars = View.AssetNumberOfCars,
                AssetCarDetail = View.AssetCarDetail,
                EmployeePayrollsTotal = View.EmployeePayrollsTotal,
                EmployeeNumberOfWifeOrHusband = View.EmployeeNumberOfWifeOrHusband,
                EmployeeNumberOfOfficers = View.EmployeeNumberOfOfficers,
                EmployeeNumberOfStaff = View.EmployeeNumberOfStaff,
                EmployeeOtherCompany = View.EmployeeOtherCompany,
                EmployeeNumberOfSecondingOfficers = View.EmployeeNumberOfSecondingOfficers,
                EmployeeDetail = View.EmployeeDetail,
                EmployeeNumberOfRentLocal = View.EmployeeNumberOfRentLocal,
                ProfileAddress = View.ProfileAddress,
                ProfileFoundDate = View.ProfileFoundDate,
                ProfileHeadPhone = View.ProfileHeadPhone,
                ProfileAmbassadorName = View.ProfileAmbassadorName,
                ProfileAmbassadorPhone = View.ProfileAmbassadorPhone,
                ProfileAmbassadorStartDate = View.ProfileAmbassadorStartDate,
                ProfileAmbassadorFinishDate = View.ProfileAmbassadorFinishDate,
                ProfileAccountingManagerName = View.ProfileAccountingManagerName,
                ProfileAccountingManagerPhone = View.ProfileAccountingManagerPhone,
                ProfileAccountingManagerStartDate = View.ProfileAccountingManagerStartDate,
                ProfileAccountingManagerFinishDate = View.ProfileAccountingManagerFinishDate,
                ProfileAccountantName = View.ProfileAccountantName,
                ProfileAccountantPhone = View.ProfileAccountantPhone,
                ProfileAccountantStartDate = View.ProfileAccountantStartDate,
                ProfileAccountantFinishDate = View.ProfileAccountantFinishDate,
                ProfileMinimumSalary = View.ProfileMinimumSalary,
                ProfileSalaryGroup = View.ProfileSalaryGroup,
                ProfileWorkingArea = View.ProfileWorkingArea,
                ProfileCurrencyCodeFinalization = View.ProfileCurrencyCodeFinalization,
                ProfileServices = View.ProfileServices,
                ProfileReportHeader = View.ProfileReportHeader,
                ProfileBankName = View.ProfileBankName,
                ProfileBankAddress = View.ProfileBankAddress,
                ProfileBankAccount = View.ProfileBankAccount,
                ProfileBankCIF = View.ProfileBankCIF,
                OtherNote = View.OtherNote,
                NativeCategory = View.NativeCategory,
                ManagementArea = View.ManagementArea,
            };
            return Model.GetCompanyProfile(1) != null ? Model.UpdateCompanyProfile(companyProfile) : Model.AddCompanyProfile(companyProfile);
        }

        /// <summary>
        /// Deletes the specified companyProfile identifier.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns></returns>
        public int Delete(int companyProfileId)
        {
            return Model.DeleteCompanyProfile(companyProfileId);
        }
    }
}
