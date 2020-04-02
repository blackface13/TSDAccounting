/***********************************************************************
 * <copyright file="IFixedAssetView.cs" company="BUCA JSC">
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
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// FixedAsset View Interface
    /// </summary>
    public interface IFixedAssetView : IView
    {
        int FixedAssetId { get; set; }

        string FixedAssetCode { get; set; }

        string FixedAssetName { get; set; }

        string FixedAssetForeignName { get; set; }

        int FixedAssetCategoryId { get; set; }

        int State { get; set; }

        string Description { get; set; }

        int ProductionYear { get; set; }

        string MadeIn { get; set; }

        DateTime PurchasedDate { get; set; }

        DateTime UsedDate { get; set; }

        DateTime DepreciationDate { get; set; }

        DateTime IncrementDate { get; set; }

        DateTime DisposedDate { get; set; }

        string Unit { get; set; }

        string SerialNumber { get; set; }

        string Accessories { get; set; }

        int Quantity { get; set; }

        decimal UnitPrice { get; set; }

        decimal OrgPrice { get; set; }

        decimal AccumDepreciationAmount { get; set; }

        decimal RemainingAmount { get; set; }

        string CurrencyCode { get; set; }

        decimal ExchangeRate { get; set; }

        decimal UnitPriceUSD { get; set; }

        decimal OrgPriceUSD { get; set; }

        decimal AccumDepreciationAmountUSD { get; set; }

        decimal RemainingAmountUSD { get; set; }

        decimal AnnualDepreciationAmount { get; set; }

        decimal AnnualDepreciationAmountUSD { get; set; }

        decimal LifeTime { get; set; }

        decimal DepreciationRate { get; set; }

        string OrgPriceAccountCode { get; set; }

        string DepreciationAccountCode { get; set; }

        string CapitalAccountCode { get; set; }

        int DepartmentId { get; set; }

        int? EmployeeId { get; set; }

        bool IsActive { get; set; }

        short NumberOfFloor { get; set; }

        decimal AreaOfBuilding { get; set; }

        decimal AreaOfFloor { get; set; }

        decimal WorkingArea { get; set; }

        decimal AdministrationArea { get; set; }

        decimal HousingArea { get; set; }

        decimal VacancyArea { get; set; }

        decimal OccupiedArea { get; set; }

        decimal LeasingArea { get; set; }

        decimal GuestHouseArea { get; set; }

        decimal OtherArea { get; set; }

        short NumberOfSeat { get; set; }

        string ControlPlate { get; set; }

        bool IsStateManagement { get; set; }

        bool IsBussiness { get; set; }

        string Address { get; set; }

        string BudgetSourceCode { get; set; }

        int ManagementCar { get; set; }

        string Brand { get; set; }

        bool IsEstimateEmployee { get; set; }

        string ArmortizationAccount { get; set; }

        string BudgetItemCode { get; set; }

        DateTime? DateSuspension { get; set; }

        string ReasonSuspension { get; set; }

        IList<FixedAssetCurrencyModel> FixedAssetCurrencies { get; set; }

        IList<FixedAssetAccessaryModel> FixedAssetAccessarys { get; set; }
    }
}
