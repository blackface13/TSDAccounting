/***********************************************************************
 * <copyright file="FixedAssetsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.FixedAsset
{
    /// <summary>
    /// FixedAssets Presenter
    /// </summary>
    public class FixedAssetsPresenter : Presenter<IFixedAssetsView>
    {
        private CompanyProfileModel _companyProfile;
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetsPresenter(IFixedAssetsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.FixedAssets = Model.GetAllFixedAssetsWithStoreProdure("uspGet_All_FixedAsset_WithCurrencyCode");
        }

        public void DisplayByYear()
        {
            View.FixedAssets = Model.GetAllFixedAssetsWithStoreProdure("uspGet_All_FixedAsset_ByYear");
        }

        /// <summary>
        /// Displays the specified fixed asset identifier.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByActive(bool isActive)
        {
            View.FixedAssets = Model.GetFixedAssetsActive(isActive);
        }

        /// <summary>
        /// Displays the by active with fixed asset currency.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayByActiveWithFixedAssetCurrency(bool isActive)
        {
            View.FixedAssets = Model.GetFixedAssetsActiveWithFixedAssetCurrency(isActive);
        }

        /// <summary>
        /// Displays the specified fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        public FixedAssetModel DisplayInFaIncreamnet(string fixedAssetId)
        {

            var fixedAsset = Model.GetFixedAssetByFaIncrement(int.Parse(fixedAssetId));
            return fixedAsset;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCompanyProfile()
        {
            _companyProfile = Model.GetCompanyProfile(1);
            var fixedAssetsHouseModels = Model.GetAllFixedAssetsWithStoreProdure("uspGet_FixedAsset_ByState_Houser");
            var fixedAssetsCarModels = Model.GetAllFixedAssetsWithStoreProdure("uspGet_FixedAsset_ByState_Car");
            int fixedAssetsCar = fixedAssetsCarModels.ToList().Count;
            int fixedAssetsHouse = fixedAssetsHouseModels.ToList().Count;
            float assetOwnArea = 0;
            foreach (var fixedAssetsModel in fixedAssetsHouseModels)
            {
                assetOwnArea = assetOwnArea + float.Parse(fixedAssetsModel.AreaOfBuilding.ToString());
            }
            var companyProfile = new CompanyProfileModel();
            companyProfile.LineId = _companyProfile.LineId;
            companyProfile.AssetOwnArea = assetOwnArea;
            companyProfile.AssetOwnRoom = fixedAssetsHouse;
            companyProfile.AssetBuyDate = _companyProfile.AssetBuyDate;
            companyProfile.AssetOwnDescription = _companyProfile.AssetOwnDescription;
            companyProfile.AssetMutualArea = _companyProfile.AssetMutualArea;
            companyProfile.AssetMutualRoom = _companyProfile.AssetMutualRoom;
            companyProfile.AssetMutualMethod = _companyProfile.AssetMutualMethod;
            companyProfile.AssetMutualDescription = _companyProfile.AssetMutualDescription;
            companyProfile.AssetRentContractLen = _companyProfile.AssetRentContractLen;
            companyProfile.AssetRentPrice = _companyProfile.AssetRentPrice;
            companyProfile.AssetRentRoom = _companyProfile.AssetRentRoom;
            companyProfile.AssetRentArea = _companyProfile.AssetRentArea;
            companyProfile.AssetRentDescription = _companyProfile.AssetRentDescription;
            companyProfile.AssetNumberOfCars = fixedAssetsCar;
            companyProfile.AssetCarDetail = _companyProfile.AssetCarDetail;
            companyProfile.EmployeePayrollsTotal = _companyProfile.EmployeePayrollsTotal;
            companyProfile.EmployeeNumberOfWifeOrHusband = _companyProfile.EmployeeNumberOfWifeOrHusband;
            companyProfile.EmployeeNumberOfOfficers = _companyProfile.EmployeeNumberOfOfficers;
            companyProfile.EmployeeNumberOfStaff = _companyProfile.EmployeeNumberOfStaff;
            companyProfile.EmployeeOtherCompany = _companyProfile.EmployeeOtherCompany;
            companyProfile.EmployeeNumberOfSecondingOfficers = _companyProfile.EmployeeNumberOfSecondingOfficers;
            companyProfile.EmployeeDetail = _companyProfile.EmployeeDetail;
            companyProfile.EmployeeNumberOfRentLocal = _companyProfile.EmployeeNumberOfRentLocal;
            companyProfile.ProfileAddress = _companyProfile.ProfileAddress;
            companyProfile.ProfileFoundDate = _companyProfile.ProfileFoundDate;
            companyProfile.ProfileHeadPhone = _companyProfile.ProfileHeadPhone;
            companyProfile.ProfileAmbassadorName = _companyProfile.ProfileAmbassadorName;
            companyProfile.ProfileAmbassadorPhone = _companyProfile.ProfileAmbassadorPhone;
            companyProfile.ProfileAmbassadorStartDate = _companyProfile.ProfileAmbassadorStartDate;
            companyProfile.ProfileAmbassadorFinishDate = _companyProfile.ProfileAmbassadorFinishDate;
            companyProfile.ProfileAccountingManagerName = _companyProfile.ProfileAccountingManagerName;
            companyProfile.ProfileAccountingManagerPhone = _companyProfile.ProfileAccountingManagerPhone;
            companyProfile.ProfileAccountingManagerStartDate = _companyProfile.ProfileAccountingManagerStartDate;
            companyProfile.ProfileAccountingManagerFinishDate = _companyProfile.ProfileAccountingManagerFinishDate;
            companyProfile.ProfileAccountantName = _companyProfile.ProfileAccountantName;
            companyProfile.ProfileAccountantPhone = _companyProfile.ProfileAccountantPhone;
            companyProfile.ProfileAccountantStartDate = _companyProfile.ProfileAccountantStartDate;
            companyProfile.ProfileAccountantFinishDate = _companyProfile.ProfileAccountantFinishDate;
            companyProfile.ProfileMinimumSalary = _companyProfile.ProfileMinimumSalary;
            companyProfile.ProfileSalaryGroup = _companyProfile.ProfileSalaryGroup;
            companyProfile.ProfileWorkingArea = _companyProfile.ProfileWorkingArea;
            companyProfile.ProfileCurrencyCodeFinalization = _companyProfile.ProfileCurrencyCodeFinalization;
            companyProfile.ProfileServices = _companyProfile.ProfileServices;
            companyProfile.ProfileReportHeader = _companyProfile.ProfileReportHeader;
            companyProfile.ProfileBankName = _companyProfile.ProfileBankName;
            companyProfile.ProfileBankAddress = _companyProfile.ProfileBankAddress;
            companyProfile.ProfileBankAccount = _companyProfile.ProfileBankAccount;
            companyProfile.ProfileBankCIF = _companyProfile.ProfileBankCIF;
            companyProfile.OtherNote = _companyProfile.OtherNote;
            return Model.GetCompanyProfile(1) != null ? Model.UpdateCompanyProfile(companyProfile) : Model.AddCompanyProfile(companyProfile);
        }

    }
}
