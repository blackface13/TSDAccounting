/***********************************************************************
 * <copyright file="CompanyProfileModel.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class CompanyProfileModel
    {
        public int LineId { get; set; }

        public float AssetOwnArea { get; set; }

        public int AssetOwnRoom { get; set; }

        public DateTime AssetBuyDate { get; set; }

        public string AssetOwnDescription { get; set; }

        public float AssetMutualArea { get; set; }

        public int AssetMutualRoom { get; set; }

        public string AssetMutualMethod { get; set; }

        public string AssetMutualDescription { get; set; }

        public int AssetRentContractLen { get; set; }

        public decimal AssetRentPrice { get; set; }

        public int AssetRentRoom { get; set; }

        public float AssetRentArea { get; set; }

        public string AssetRentDescription { get; set; }

        public int AssetNumberOfCars { get; set; }

        public string AssetCarDetail { get; set; }

        public int EmployeePayrollsTotal { get; set; }

        public int EmployeeNumberOfWifeOrHusband { get; set; }

        public int EmployeeNumberOfOfficers { get; set; }

        public int EmployeeNumberOfStaff { get; set; }

        public int EmployeeOtherCompany { get; set; }

        public int EmployeeNumberOfSecondingOfficers { get; set; }

        public string EmployeeDetail { get; set; }

        public int EmployeeNumberOfRentLocal { get; set; }

        public string ProfileAddress { get; set; }

        public DateTime ProfileFoundDate { get; set; }

        public string ProfileHeadPhone { get; set; }

        public string ProfileAmbassadorName { get; set; }

        public string ProfileAmbassadorPhone { get; set; }

        public DateTime ProfileAmbassadorStartDate { get; set; }

        public DateTime ProfileAmbassadorFinishDate { get; set; }

        public string ProfileAccountingManagerName { get; set; }

        public string ProfileAccountingManagerPhone { get; set; }

        public DateTime ProfileAccountingManagerStartDate { get; set; }

        public DateTime ProfileAccountingManagerFinishDate { get; set; }

        public string ProfileAccountantName { get; set; }

        public string ProfileAccountantPhone { get; set; }

        public DateTime ProfileAccountantStartDate { get; set; }

        public DateTime ProfileAccountantFinishDate { get; set; }

        public decimal ProfileMinimumSalary { get; set; }

        public string ProfileSalaryGroup { get; set; }

        public string ProfileWorkingArea { get; set; }

        public string ProfileCurrencyCodeFinalization { get; set; }

        public string ProfileServices { get; set; }

        public string ProfileReportHeader { get; set; }

        public string ProfileBankName { get; set; }

        public string ProfileBankAddress { get; set; }

        public string ProfileBankAccount { get; set; }

        public string ProfileBankCIF { get; set; }

        public string OtherNote { get; set; }

        public int NativeCategory { get; set; }

        public int ManagementArea { get; set; }

    }

}
