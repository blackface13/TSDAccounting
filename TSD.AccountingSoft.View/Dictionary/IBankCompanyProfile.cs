/***********************************************************************
 * <copyright file="IBankCompanyProfile.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// ICompanyProfileView
    /// </summary>
    public interface ICompanyProfileView : IView
    {
        /// <summary>
        /// Gets or sets the line identifier.
        /// </summary>
        /// <value>
        /// The line identifier.
        /// </value>
        int LineId { get; set; }
        /// <summary>
        /// Gets or sets the asset own area.
        /// </summary>
        /// <value>
        /// The asset own area.
        /// </value>
        float AssetOwnArea { get; set; }
        /// <summary>
        /// Gets or sets the asset own room.
        /// </summary>
        /// <value>
        /// The asset own room.
        /// </value>
        int AssetOwnRoom { get; set; }
        /// <summary>
        /// Gets or sets the asset buy date.
        /// </summary>
        /// <value>
        /// The asset buy date.
        /// </value>
        DateTime AssetBuyDate { get; set; }
        /// <summary>
        /// Gets or sets the asset own description.
        /// </summary>
        /// <value>
        /// The asset own description.
        /// </value>
        string AssetOwnDescription { get; set; }
        /// <summary>
        /// Gets or sets the asset mutual area.
        /// </summary>
        /// <value>
        /// The asset mutual area.
        /// </value>
        float AssetMutualArea { get; set; }
        /// <summary>
        /// Gets or sets the asset mutual room.
        /// </summary>
        /// <value>
        /// The asset mutual room.
        /// </value>
        int AssetMutualRoom { get; set; }
        /// <summary>
        /// Gets or sets the asset mutual method.
        /// </summary>
        /// <value>
        /// The asset mutual method.
        /// </value>
        string AssetMutualMethod { get; set; }
        /// <summary>
        /// Gets or sets the asset mutual description.
        /// </summary>
        /// <value>
        /// The asset mutual description.
        /// </value>
        string AssetMutualDescription { get; set; }
        /// <summary>
        /// Gets or sets the length of the asset rent contract.
        /// </summary>
        /// <value>
        /// The length of the asset rent contract.
        /// </value>
        int AssetRentContractLen { get; set; }
        /// <summary>
        /// Gets or sets the asset rent price.
        /// </summary>
        /// <value>
        /// The asset rent price.
        /// </value>
        decimal AssetRentPrice { get; set; }
        /// <summary>
        /// Gets or sets the asset rent room.
        /// </summary>
        /// <value>
        /// The asset rent room.
        /// </value>
        int AssetRentRoom { get; set; }
        /// <summary>
        /// Gets or sets the asset rent area.
        /// </summary>
        /// <value>
        /// The asset rent area.
        /// </value>
        float AssetRentArea { get; set; }
        /// <summary>
        /// Gets or sets the asset rent description.
        /// </summary>
        /// <value>
        /// The asset rent description.
        /// </value>
        string AssetRentDescription { get; set; }
        /// <summary>
        /// Gets or sets the asset number of cars.
        /// </summary>
        /// <value>
        /// The asset number of cars.
        /// </value>
        int AssetNumberOfCars { get; set; }
        /// <summary>
        /// Gets or sets the asset car detail.
        /// </summary>
        /// <value>
        /// The asset car detail.
        /// </value>
        string AssetCarDetail { get; set; }
        /// <summary>
        /// Gets or sets the employee payrolls total.
        /// </summary>
        /// <value>
        /// The employee payrolls total.
        /// </value>
        int EmployeePayrollsTotal { get; set; }
        /// <summary>
        /// Gets or sets the employee number of wife or husband.
        /// </summary>
        /// <value>
        /// The employee number of wife or husband.
        /// </value>
        int EmployeeNumberOfWifeOrHusband { get; set; }
        /// <summary>
        /// Gets or sets the employee number of officers.
        /// </summary>
        /// <value>
        /// The employee number of officers.
        /// </value>
        int EmployeeNumberOfOfficers { get; set; }
        /// <summary>
        /// Gets or sets the employee number of staff.
        /// </summary>
        /// <value>
        /// The employee number of staff.
        /// </value>
        int EmployeeNumberOfStaff { get; set; }
        /// <summary>
        /// Gets or sets the employee other company.
        /// </summary>
        /// <value>
        /// The employee other company.
        /// </value>
        int EmployeeOtherCompany { get; set; }
        /// <summary>
        /// Gets or sets the employee number of seconding officers.
        /// </summary>
        /// <value>
        /// The employee number of seconding officers.
        /// </value>
        int EmployeeNumberOfSecondingOfficers { get; set; }
        /// <summary>
        /// Gets or sets the employee detail.
        /// </summary>
        /// <value>
        /// The employee detail.
        /// </value>
        string EmployeeDetail { get; set; }
        /// <summary>
        /// Gets or sets the employee number of rent local.
        /// </summary>
        /// <value>
        /// The employee number of rent local.
        /// </value>
        int EmployeeNumberOfRentLocal { get; set; }
        /// <summary>
        /// Gets or sets the profile address.
        /// </summary>
        /// <value>
        /// The profile address.
        /// </value>
        string ProfileAddress { get; set; }
        /// <summary>
        /// Gets or sets the profile found date.
        /// </summary>
        /// <value>
        /// The profile found date.
        /// </value>
        DateTime ProfileFoundDate { get; set; }
        /// <summary>
        /// Gets or sets the profile head phone.
        /// </summary>
        /// <value>
        /// The profile head phone.
        /// </value>
        string ProfileHeadPhone { get; set; }
        /// <summary>
        /// Gets or sets the name of the profile ambassador.
        /// </summary>
        /// <value>
        /// The name of the profile ambassador.
        /// </value>
        string ProfileAmbassadorName { get; set; }
        /// <summary>
        /// Gets or sets the profile ambassador phone.
        /// </summary>
        /// <value>
        /// The profile ambassador phone.
        /// </value>
        string ProfileAmbassadorPhone { get; set; }
        /// <summary>
        /// Gets or sets the profile ambassador start date.
        /// </summary>
        /// <value>
        /// The profile ambassador start date.
        /// </value>
        DateTime ProfileAmbassadorStartDate { get; set; }
        /// <summary>
        /// Gets or sets the profile ambassador finish date.
        /// </summary>
        /// <value>
        /// The profile ambassador finish date.
        /// </value>
        DateTime ProfileAmbassadorFinishDate { get; set; }
        /// <summary>
        /// Gets or sets the name of the profile accounting manager.
        /// </summary>
        /// <value>
        /// The name of the profile accounting manager.
        /// </value>
        string ProfileAccountingManagerName { get; set; }
        /// <summary>
        /// Gets or sets the profile accounting manager phone.
        /// </summary>
        /// <value>
        /// The profile accounting manager phone.
        /// </value>
        string ProfileAccountingManagerPhone { get; set; }
        /// <summary>
        /// Gets or sets the profile accounting manager start date.
        /// </summary>
        /// <value>
        /// The profile accounting manager start date.
        /// </value>
        DateTime ProfileAccountingManagerStartDate { get; set; }
        /// <summary>
        /// Gets or sets the profile accounting manager finish date.
        /// </summary>
        /// <value>
        /// The profile accounting manager finish date.
        /// </value>
        DateTime ProfileAccountingManagerFinishDate { get; set; }
        /// <summary>
        /// Gets or sets the name of the profile accountant.
        /// </summary>
        /// <value>
        /// The name of the profile accountant.
        /// </value>
        string ProfileAccountantName { get; set; }
        /// <summary>
        /// Gets or sets the profile accountant phone.
        /// </summary>
        /// <value>
        /// The profile accountant phone.
        /// </value>
        string ProfileAccountantPhone { get; set; }
        /// <summary>
        /// Gets or sets the profile accountant start date.
        /// </summary>
        /// <value>
        /// The profile accountant start date.
        /// </value>
        DateTime ProfileAccountantStartDate { get; set; }
        /// <summary>
        /// Gets or sets the profile accountant finish date.
        /// </summary>
        /// <value>
        /// The profile accountant finish date.
        /// </value>
        DateTime ProfileAccountantFinishDate { get; set; }
        /// <summary>
        /// Gets or sets the profile minimum salary.
        /// </summary>
        /// <value>
        /// The profile minimum salary.
        /// </value>
        decimal ProfileMinimumSalary { get; set; }
        /// <summary>
        /// Gets or sets the profile salary group.
        /// </summary>
        /// <value>
        /// The profile salary group.
        /// </value>
        string ProfileSalaryGroup { get; set; }
        /// <summary>
        /// Gets or sets the profile working area.
        /// </summary>
        /// <value>
        /// The profile working area.
        /// </value>
        string ProfileWorkingArea { get; set; }
        /// <summary>
        /// Gets or sets the profile currency code finalization.
        /// </summary>
        /// <value>
        /// The profile currency code finalization.
        /// </value>
        string ProfileCurrencyCodeFinalization { get; set; }
        /// <summary>
        /// Gets or sets the profile services.
        /// </summary>
        /// <value>
        /// The profile services.
        /// </value>
        string ProfileServices { get; set; }
        /// <summary>
        /// Gets or sets the profile report header.
        /// </summary>
        /// <value>
        /// The profile report header.
        /// </value>
        string ProfileReportHeader { get; set; }
        /// <summary>
        /// Gets or sets the name of the profile bank.
        /// </summary>
        /// <value>
        /// The name of the profile bank.
        /// </value>
        string ProfileBankName { get; set; }
        /// <summary>
        /// Gets or sets the profile bank address.
        /// </summary>
        /// <value>
        /// The profile bank address.
        /// </value>
        string ProfileBankAddress { get; set; }
        /// <summary>
        /// Gets or sets the profile bank account.
        /// </summary>
        /// <value>
        /// The profile bank account.
        /// </value>
        string ProfileBankAccount { get; set; }
        /// <summary>
        /// Gets or sets the profile bank cif.
        /// </summary>
        /// <value>
        /// The profile bank cif.
        /// </value>
        string ProfileBankCIF { get; set; }
        /// <summary>
        /// Gets or sets the other note.
        /// </summary>
        /// <value>
        /// The other note.
        /// </value>
        string OtherNote { get; set; }

        /// <summary>
        /// Gets or sets the native category.
        /// </summary>
        /// <value>
        /// The native category.
        /// </value>
        int NativeCategory { get; set; }

        /// <summary>
        /// Gets or sets the management area.
        /// </summary>
        /// <value>
        /// The management area.
        /// </value>
        int ManagementArea { get; set; }
    }
}