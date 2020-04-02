/***********************************************************************
 * <copyright file="DBOptionPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.DBOption
{
    /// <summary>
    /// DBOptionPresenter
    /// </summary>
    public class DBOptionPresenter : Presenter<IDBOptionView>
    {
        private CompanyProfileModel _companyProfile;
        /// <summary>
        /// Initializes a new instance of the <see cref="DBOptionPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public DBOptionPresenter(IDBOptionView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified dbOption identifier.
        /// </summary>
        /// <param name="dbOptionId">The dbOption identifier.</param>
        public void Display(string dbOptionId)
        {
            if (dbOptionId == null) { return; }

            var dbOption = Model.GetDBOption(dbOptionId);

            View.OptionId = dbOption.OptionId;
            View.OptionValue = dbOption.OptionValue;
            View.ValueType = dbOption.ValueType;
            View.IsSystem = dbOption.IsSystem;
            View.Description = dbOption.Description;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var dbOption = new DBOptionModel
            {
                OptionId = View.OptionId,
                OptionValue = View.OptionValue,
                ValueType = View.ValueType,
                IsSystem = View.IsSystem,
                Description = View.Description,
            };

            return Model.UpdateDBOption(false, dbOption);
        }

        

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCompanyProfile()
        {
            _companyProfile = Model.GetCompanyProfile(1);

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
                
                ProfileAmbassadorName = View.OptionValue,

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

        public CompanyProfileModel GetCompanyProfile()
        {
            return null;
        }
    }
}
