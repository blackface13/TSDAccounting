/***********************************************************************
 * <copyright file="SqlServerCompanyProfileDao.cs" company="BUCA JSC">
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
using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerCompanyProfileDao
    /// </summary>
    public class SqlServerCompanyProfileDao : ICompanyProfileDao
    {
        /// <summary>
        /// Gets the companyProfile.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns></returns>
        public CompanyProfileEntity GetCompanyProfile(int companyProfileId)
        {
            const string sql = @"uspGet_CompanyProfile_ByID";

            object[] parms = { "@LineID", companyProfileId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the companyProfiles.
        /// </summary>
        /// <returns></returns>
        public List<CompanyProfileEntity> GetCompanyProfiles()
        {
            const string procedures = @"uspGet_All_CompanyProfile";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the companyProfiles by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<CompanyProfileEntity> GetCompanyProfilesByActive(bool isActive)
        {
            const string sql = @"uspGet_CompanyProfile_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        public int InsertCompanyProfile(CompanyProfileEntity companyProfile)
        {
            const string sql = @"uspInsert_CompanyProfile";
            return Db.Insert(sql, true, Take(companyProfile));
        }

        /// <summary>
        /// Updates the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        public string UpdateCompanyProfile(CompanyProfileEntity companyProfile)
        {
            const string sql = @"uspUpdate_CompanyProfile";
            return Db.Update(sql, true, Take(companyProfile));
        }

        /// <summary>
        /// Deletes the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        public string DeleteCompanyProfile(CompanyProfileEntity companyProfile)
        {
            const string sql = @"uspDelete_CompanyProfile";

            object[] parms = { "@LineID", companyProfile.LineId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CompanyProfileEntity> Make = reader =>
            new CompanyProfileEntity
            {
                LineId = reader["LineID"].AsInt(),
                AssetOwnArea = reader["AssetOwnArea"].AsFloat(),
                AssetOwnRoom = reader["AssetOwnRoom"].AsInt(),
                AssetBuyDate = reader["AssetBuyDate"].AsDateTime(),
                AssetOwnDescription = reader["AssetOwnDescription"].AsString(),
                AssetMutualArea = reader["AssetMutualArea"].AsFloat(),
                AssetMutualRoom = reader["AssetMutualRoom"].AsInt(),
                AssetMutualMethod = reader["AssetMutualMethod"].AsString(),
                AssetMutualDescription = reader["AssetMutualDescription"].AsString(),
                AssetRentContractLen = reader["AssetRentContractLen"].AsInt(),
                AssetRentPrice = reader["AssetRentPrice"].AsDecimal(),
                AssetRentRoom = reader["AssetRentRoom"].AsInt(),
                AssetRentArea = reader["AssetRentArea"].AsFloat(),
                AssetRentDescription = reader["AssetRentDescription"].AsString(),
                AssetNumberOfCars = reader["AssetNumberOfCars"].AsInt(),
                AssetCarDetail = reader["AssetCarDetail"].AsString(),
                EmployeePayrollsTotal = reader["EmployeePayrollsTotal"].AsInt(),
                EmployeeNumberOfWifeOrHusband = reader["EmployeeNumberOfWifeOrHusband"].AsInt(),
                EmployeeNumberOfOfficers = reader["EmployeeNumberOfOfficers"].AsInt(),
                EmployeeNumberOfStaff = reader["EmployeeNumberOfStaff"].AsInt(),
                EmployeeOtherCompany = reader["EmployeeOtherCompany"].AsInt(),
                EmployeeNumberOfSecondingOfficers = reader["EmployeeNumberOfSecondingOfficers"].AsInt(),
                EmployeeDetail = reader["EmployeeDetail"].AsString(),
                EmployeeNumberOfRentLocal = reader["EmployeeNumberOfRentLocal"].AsInt(),
                ProfileAddress = reader["ProfileAddress"].AsString(),
                ProfileFoundDate = reader["ProfileFoundDate"].AsDateTime(),
                ProfileHeadPhone = reader["ProfileHeadPhone"].AsString(),
                ProfileAmbassadorName = reader["ProfileAmbassadorName"].AsString(),
                ProfileAmbassadorPhone = reader["ProfileAmbassadorPhone"].AsString(),
                ProfileAmbassadorStartDate = reader["ProfileAmbassadorStartDate"].AsDateTime(),
                ProfileAmbassadorFinishDate = reader["ProfileAmbassadorFinishDate"].AsDateTime(),
                ProfileAccountingManagerName = reader["ProfileAccountingManagerName"].AsString(),
                ProfileAccountingManagerPhone = reader["ProfileAccountingManagerPhone"].AsString(),
                ProfileAccountingManagerStartDate = reader["ProfileAccountingManagerStartDate"].AsDateTime(),
                ProfileAccountingManagerFinishDate = reader["ProfileAccountingManagerFinishDate"].AsDateTime(),
                ProfileAccountantName = reader["ProfileAccountantName"].AsString(),
                ProfileAccountantPhone = reader["ProfileAccountantPhone"].AsString(),
                ProfileAccountantStartDate = reader["ProfileAccountantStartDate"].AsDateTime(),
                ProfileAccountantFinishDate = reader["ProfileAccountantFinishDate"].AsDateTime(),
                ProfileMinimumSalary = reader["ProfileMinimumSalary"].AsDecimal(),
                ProfileSalaryGroup = reader["ProfileSalaryGroup"].AsString(),
                ProfileWorkingArea = reader["ProfileWorkingArea"].AsString(),
                ProfileCurrencyCodeFinalization = reader["ProfileCurrencyCodeFinalization"].AsString(),
                ProfileServices = reader["ProfileServices"].AsString(),
                ProfileReportHeader = reader["ProfileReportHeader"].AsString(),
                ProfileBankName = reader["ProfileBankName"].AsString(),
                ProfileBankAddress = reader["ProfileBankAddress"].AsString(),
                ProfileBankAccount = reader["ProfileBankAccount"].AsString(),
                ProfileBankCIF = reader["ProfileBankCIF"].AsString(),
                OtherNote = reader["OtherNote"].AsString(),
                NativeCategory = reader["NativeCategory"].AsInt(),
                ManagementArea = reader["ManagementArea"].AsInt(),
            };

        /// <summary>
        /// Takes the specified companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        private static object[] Take(CompanyProfileEntity companyProfile)
        {
            return new object[]  
            {
                "@LineID", companyProfile.LineId,
                "@AssetOwnArea", companyProfile.AssetOwnArea,
                "@AssetOwnRoom", companyProfile.AssetOwnRoom,
                "@AssetBuyDate", companyProfile.AssetBuyDate,
                "@AssetOwnDescription", companyProfile.AssetOwnDescription,
                "@AssetMutualArea", companyProfile.AssetMutualArea,
                "@AssetMutualRoom", companyProfile.AssetMutualRoom,
                "@AssetMutualMethod", companyProfile.AssetMutualMethod,
                "@AssetMutualDescription", companyProfile.AssetMutualDescription,
                "@AssetRentContractLen", companyProfile.AssetRentContractLen,
                "@AssetRentPrice", companyProfile.AssetRentPrice,
                "@AssetRentRoom", companyProfile.AssetRentRoom,
                "@AssetRentArea", companyProfile.AssetRentArea,
                "@AssetRentDescription", companyProfile.AssetRentDescription,
                "@AssetNumberOfCars", companyProfile.AssetNumberOfCars,
                "@AssetCarDetail", companyProfile.AssetCarDetail,
                "@EmployeePayrollsTotal", companyProfile.EmployeePayrollsTotal,
                "@EmployeeNumberOfWifeOrHusband", companyProfile.EmployeeNumberOfWifeOrHusband,
                "@EmployeeNumberOfOfficers", companyProfile.EmployeeNumberOfOfficers,
                "@EmployeeNumberOfStaff", companyProfile.EmployeeNumberOfStaff,
                "@EmployeeOtherCompany", companyProfile.EmployeeOtherCompany,
                "@EmployeeNumberOfSecondingOfficers", companyProfile.EmployeeNumberOfSecondingOfficers,
                "@EmployeeDetail", companyProfile.EmployeeDetail,
                "@EmployeeNumberOfRentLocal", companyProfile.EmployeeNumberOfRentLocal,
                "@ProfileAddress", companyProfile.ProfileAddress,
                "@ProfileFoundDate", companyProfile.ProfileFoundDate,
                "@ProfileHeadPhone", companyProfile.ProfileHeadPhone,
                "@ProfileAmbassadorName", companyProfile.ProfileAmbassadorName,
                "@ProfileAmbassadorPhone", companyProfile.ProfileAmbassadorPhone,
                "@ProfileAmbassadorStartDate", companyProfile.ProfileAmbassadorStartDate,
                "@ProfileAmbassadorFinishDate", companyProfile.ProfileAmbassadorFinishDate,
                "@ProfileAccountingManagerName", companyProfile.ProfileAccountingManagerName,
                "@ProfileAccountingManagerPhone", companyProfile.ProfileAccountingManagerPhone,
                "@ProfileAccountingManagerStartDate", companyProfile.ProfileAccountingManagerStartDate,
                "@ProfileAccountingManagerFinishDate", companyProfile.ProfileAccountingManagerFinishDate,
                "@ProfileAccountantName", companyProfile.ProfileAccountantName,
                "@ProfileAccountantPhone", companyProfile.ProfileAccountantPhone,
                "@ProfileAccountantStartDate", companyProfile.ProfileAccountantStartDate,
                "@ProfileAccountantFinishDate", companyProfile.ProfileAccountantFinishDate,
                "@ProfileMinimumSalary", companyProfile.ProfileMinimumSalary,
                "@ProfileSalaryGroup", companyProfile.ProfileSalaryGroup,
                "@ProfileWorkingArea", companyProfile.ProfileWorkingArea,
                "@ProfileCurrencyCodeFinalization", companyProfile.ProfileCurrencyCodeFinalization,
                "@ProfileServices", companyProfile.ProfileServices,
                "@ProfileReportHeader", companyProfile.ProfileReportHeader,
                "@ProfileBankName", companyProfile.ProfileBankName,
                "@ProfileBankAddress", companyProfile.ProfileBankAddress,
                "@ProfileBankAccount", companyProfile.ProfileBankAccount,
                "@ProfileBankCIF", companyProfile.ProfileBankCIF,
                "@OtherNote", companyProfile.OtherNote,
                "@NativeCategory", companyProfile.NativeCategory,
                "@ManagementArea", companyProfile.ManagementArea,
                
            };
        }
    }
}
