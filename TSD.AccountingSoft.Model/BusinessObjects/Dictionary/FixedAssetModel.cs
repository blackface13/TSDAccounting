/***********************************************************************
 * <copyright file="FixedAssetModel.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class FixedAssetModel
    {
        public FixedAssetModel()
        {
            FixedAssetCurrencies = new List<FixedAssetCurrencyModel>();
        }

        public int FixedAssetId { get; set; }

        public string FixedAssetCode { get; set; }

        public string FixedAssetName { get; set; }

        public string FixedAssetForeignName { get; set; }

        public int FixedAssetCategoryId { get; set; }

        public int State { get; set; }

        public string Description { get; set; }

        public int ProductionYear { get; set; }

        public string MadeIn { get; set; }

        public DateTime PurchasedDate { get; set; }

        public DateTime UsedDate { get; set; }

        public DateTime DepreciationDate { get; set; }

        public DateTime IncrementDate { get; set; }

        public DateTime DisposedDate { get; set; }

        public string Unit { get; set; }

        public string SerialNumber { get; set; }

        public string Accessories { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OrgPrice { get; set; }

        public decimal AccumDepreciationAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal UnitPriceUSD { get; set; }

        public decimal OrgPriceUSD { get; set; }

        public decimal AccumDepreciationAmountUSD { get; set; }

        public decimal RemainingAmountUSD { get; set; }

        public decimal AnnualDepreciationAmount { get; set; }

        public decimal AnnualDepreciationAmountUSD { get; set; }

        public decimal LifeTime { get; set; }

        public decimal DepreciationRate { get; set; }

        public string OrgPriceAccountCode { get; set; }

        public string DepreciationAccountCode { get; set; }

        public string CapitalAccountCode { get; set; }

        public int DepartmentId { get; set; }

        public int? EmployeeId { get; set; }

        public bool IsActive { get; set; }

        public IList<FixedAssetCurrencyModel> FixedAssetCurrencies { get; set; }

        public decimal RemainingOrgPrice { get; set; }

        public decimal RemainingOrgPriceUSD { get; set; }

        public short NumberOfFloor { get; set; }

        public decimal AreaOfBuilding { get; set; }

        public decimal AreaOfFloor { get; set; }

        public decimal WorkingArea { get; set; }

        public decimal AdministrationArea { get; set; }

        public decimal HousingArea { get; set; }

        public decimal VacancyArea { get; set; }

        public decimal OccupiedArea { get; set; }

        public decimal LeasingArea { get; set; }

        public decimal GuestHouseArea { get; set; }

        public decimal OtherArea { get; set; }

        public short NumberOfSeat { get; set; }

        public string ControlPlate { get; set; }

        public bool IsStateManagement { get; set; }

        public bool IsBussiness { get; set; }

        public string Address { get; set; }

        public string BudgetSourceCode { get; set; }

        public int ManagementCar { get; set; }

        public string Brand { get; set; }

        public bool IsEstimateEmployee { get; set; }

        public string ArmortizationAccount { get; set; }

        public string BudgetItemCode { get; set; }

        public DateTime? DateSuspension { get; set; }

        public string ReasonSuspension { get; set; }

        public IList<FixedAssetAccessaryModel> FixedAssetAccessarys { get; set; }
    }
}
