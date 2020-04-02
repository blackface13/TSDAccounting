/***********************************************************************
 * <copyright file="DBOptionsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.DBOption
{
    /// <summary>
    /// DBOptionsPresenter
    /// </summary>
    public class DBOptionsPresenter : Presenter<IDBOptionsView>
    {
        private CompanyProfileModel _companyProfile;
        /// <summary>
        /// DBOptionts the presenter.
        /// </summary>
        /// <param name="view">The view.</param>
        public DBOptionsPresenter(IDBOptionsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.DBOptions = Model.GetDBOptions();
        }

        /// <summary>
        /// Displays the is numeric.
        /// </summary>
        public void DisplayIsNumeric()
        {
            View.DBOptions = Model.GetDBOptionsIsNumeric();
        }

        /// <summary>
        /// Displays the is string.
        /// </summary>
        public void DisplayIsString()
        {
            View.DBOptions = Model.GetDBOptionsIsString();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var dbOptionModels = View.DBOptions;
            return Model != null ? Model.UpdateDBOption((List<DBOptionModel>)dbOptionModels) : null;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCompanyProfile()
        {
            _companyProfile = Model.GetCompanyProfile(1);
            var dbOptionModels = View.DBOptions;
            string companyDirector = "";
            string companyAccountant = "";
            decimal baseOfSalary = 0;
            string companyAdrress = "";
            string companyCode = "";
            foreach (var dbOptionModel in dbOptionModels)
            {
                //if (dbOptionModel.OptionId == "CompanyDirector")
                //{
                //    companyDirector = dbOptionModel.OptionValue;
                //}
                if (dbOptionModel.OptionId == "CompanyAccountant")
                {
                    companyAccountant = dbOptionModel.OptionValue;
                }

                if (dbOptionModel.OptionId == "BaseOfSalary")
                {
                    baseOfSalary = Convert.ToDecimal(dbOptionModel.OptionValue);
                }

                if (dbOptionModel.OptionId == "CompanyAdrress")
                {
                    companyAdrress = dbOptionModel.OptionValue;
                }

                if (dbOptionModel.OptionId == "CompanyAdrress")
                {
                    companyAdrress = dbOptionModel.OptionValue;
                }

                if (dbOptionModel.OptionId == "CompanyCode")
                {
                    companyCode = dbOptionModel.OptionValue;
                }
            }
                var companyProfile = new CompanyProfileModel
                {
                    LineId = _companyProfile==null ?0: _companyProfile.LineId,
                    AssetOwnArea = _companyProfile==null ?0:_companyProfile.AssetOwnArea,
                    AssetOwnRoom = _companyProfile==null ?0:_companyProfile.AssetOwnRoom,
                    AssetBuyDate = _companyProfile==null ?DateTime.Now:_companyProfile.AssetBuyDate,
                    AssetOwnDescription = _companyProfile==null ?"": _companyProfile.AssetOwnDescription,
                    AssetMutualArea = _companyProfile==null ?0: _companyProfile.AssetMutualArea,
                    AssetMutualRoom = _companyProfile==null ?0: _companyProfile.AssetMutualRoom,
                    AssetMutualMethod = _companyProfile==null ? "": _companyProfile.AssetMutualMethod,
                    AssetMutualDescription = _companyProfile==null ? "": _companyProfile.AssetMutualDescription,
                    AssetRentContractLen = _companyProfile==null ?0: _companyProfile.AssetRentContractLen,
                    AssetRentPrice = _companyProfile==null ?0: _companyProfile.AssetRentPrice,
                    AssetRentRoom = _companyProfile==null ?0: _companyProfile.AssetRentRoom,
                    AssetRentArea = _companyProfile==null ?0: _companyProfile.AssetRentArea,
                    AssetRentDescription = _companyProfile==null ? "": _companyProfile.AssetRentDescription,
                    AssetNumberOfCars = _companyProfile==null ?0: _companyProfile.AssetNumberOfCars,
                    AssetCarDetail = _companyProfile==null ? "": _companyProfile.AssetCarDetail,
                    EmployeePayrollsTotal = _companyProfile==null ?0: _companyProfile.EmployeePayrollsTotal,
                    EmployeeNumberOfWifeOrHusband = _companyProfile==null ?0: _companyProfile.EmployeeNumberOfWifeOrHusband,
                    EmployeeNumberOfOfficers = _companyProfile==null ?0: _companyProfile.EmployeeNumberOfOfficers,
                    EmployeeNumberOfStaff = _companyProfile==null ?0: _companyProfile.EmployeeNumberOfStaff,
                    EmployeeOtherCompany = _companyProfile==null ?0: _companyProfile.EmployeeOtherCompany,
                    EmployeeNumberOfSecondingOfficers = _companyProfile==null ?0: _companyProfile.EmployeeNumberOfSecondingOfficers,
                    EmployeeDetail = _companyProfile==null ? "": _companyProfile.EmployeeDetail,
                    EmployeeNumberOfRentLocal = _companyProfile==null ?0: _companyProfile.EmployeeNumberOfRentLocal,
                    ProfileAddress =  companyAdrress,
                    ProfileFoundDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileFoundDate,
                    ProfileHeadPhone = _companyProfile==null ? "": _companyProfile.ProfileHeadPhone,
                    ProfileAmbassadorName =  companyDirector,
                    ProfileAmbassadorPhone = _companyProfile==null ?"": _companyProfile.ProfileAmbassadorPhone,
                    ProfileAmbassadorStartDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileAmbassadorStartDate,
                    ProfileAmbassadorFinishDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileAmbassadorFinishDate,
                    ProfileAccountingManagerName = _companyProfile==null ? "" : _companyProfile.ProfileAccountingManagerName,
                    ProfileAccountingManagerPhone = _companyProfile==null ? "": _companyProfile.ProfileAccountingManagerPhone,
                    ProfileAccountingManagerStartDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileAccountingManagerStartDate,
                    ProfileAccountingManagerFinishDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileAccountingManagerFinishDate,
                    ProfileAccountantName =  companyAccountant,
                    ProfileAccountantPhone = _companyProfile==null ? "": _companyProfile.ProfileAccountantPhone,
                    ProfileAccountantStartDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileAccountantStartDate,
                    ProfileAccountantFinishDate = _companyProfile==null ? DateTime.Now: _companyProfile.ProfileAccountantFinishDate,
                    ProfileMinimumSalary =  baseOfSalary,
                    ProfileSalaryGroup = _companyProfile==null ? "": _companyProfile.ProfileSalaryGroup,
                    ProfileWorkingArea = _companyProfile==null ? "": _companyProfile.ProfileWorkingArea,
                    ProfileCurrencyCodeFinalization = _companyProfile==null ? "": _companyProfile.ProfileCurrencyCodeFinalization,
                    ProfileServices = _companyProfile==null ? "": _companyProfile.ProfileServices,
                    ProfileReportHeader = _companyProfile==null ? "": _companyProfile.ProfileReportHeader,
                    ProfileBankName = _companyProfile==null ? "": _companyProfile.ProfileBankName,
                    ProfileBankAddress = _companyProfile==null ? "": _companyProfile.ProfileBankAddress,
                    ProfileBankAccount = _companyProfile==null ? "": _companyProfile.ProfileBankAccount,
                    ProfileBankCIF = _companyProfile==null ? "": _companyProfile.ProfileBankCIF,
                    OtherNote = _companyProfile==null ? "": _companyProfile.OtherNote
                };
            
            return _companyProfile != null ? Model.UpdateCompanyProfile(companyProfile) : Model.AddCompanyProfile(companyProfile);
        }
    }
}
