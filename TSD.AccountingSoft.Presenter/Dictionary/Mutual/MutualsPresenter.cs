/***********************************************************************
 * <copyright file="BuildingsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Mutual
{
    /// <summary>
    /// class BuildingsPresenter
    /// </summary>
    public class MutualsPresenter : Presenter<IMutualsView>
    {
        private CompanyProfileModel _companyProfile;
        /// <summary>

        /// </summary>
        /// <param name="view">The view.</param>
        public MutualsPresenter(IMutualsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Mutuals = Model.GetMutuals();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.Mutuals = Model.GetMutualByIsActive(true);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCompanyProfile()
        {

            //return 1;
            _companyProfile = Model.GetCompanyProfile(1);
            var fixedAssetsHouseModels = Model.GetMutuals().Where(x => x.IsActive = true);
            int fixedAssetsHouse = fixedAssetsHouseModels.ToList().Count;
            float assetMutualArea = 0;
            foreach (var fixedAssetsModel in fixedAssetsHouseModels)
            {
                assetMutualArea = assetMutualArea + float.Parse(fixedAssetsModel.Area.ToString());
            }

            var companyProfile = new CompanyProfileModel
            {
                LineId = _companyProfile.LineId,
                AssetOwnArea = _companyProfile.AssetOwnArea,
                AssetOwnRoom = _companyProfile.AssetOwnRoom,
                AssetBuyDate = _companyProfile.AssetBuyDate,
                AssetOwnDescription = _companyProfile.AssetOwnDescription,
                AssetMutualArea = assetMutualArea,
                AssetMutualRoom = fixedAssetsHouse,
                AssetMutualMethod = _companyProfile.AssetMutualMethod,
                AssetMutualDescription = _companyProfile.AssetMutualDescription,
                AssetRentContractLen = _companyProfile.AssetRentContractLen,
                AssetRentPrice = _companyProfile.AssetRentPrice,
                AssetRentRoom = _companyProfile.AssetRentRoom,
                AssetRentArea = _companyProfile.AssetRentArea,
                AssetRentDescription = _companyProfile.AssetRentDescription,
                AssetNumberOfCars = _companyProfile.AssetNumberOfCars,
                AssetCarDetail = _companyProfile.AssetCarDetail,
                EmployeePayrollsTotal = _companyProfile.EmployeePayrollsTotal,
                EmployeeNumberOfWifeOrHusband = _companyProfile.EmployeeNumberOfWifeOrHusband,
                EmployeeNumberOfOfficers = _companyProfile.EmployeeNumberOfOfficers,
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
