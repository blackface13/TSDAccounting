/***********************************************************************
 * <copyright file="FixedAssetEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// FixedAsset Entity
    /// </summary>
    public class FixedAssetEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetEntity"/> class.
        /// </summary>
        public FixedAssetEntity()
        {
            AddRule(new ValidateRequired("FixedAssetCode"));
            AddRule(new ValidateRequired("FixedAssetName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetEntity" /> class.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <param name="fixedAssetName">Name of the fixed asset.</param>
        /// <param name="fixedAssetForeignName">The fixed asset name en.</param>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="state">The state.</param>
        /// <param name="description">The description.</param>
        /// <param name="productionYear">The production year.</param>
        /// <param name="madeIn">The made in.</param>
        /// <param name="purchasedDate">The purchased date.</param>
        /// <param name="usedDate">The used date.</param>
        /// <param name="depreciationDate">The depreciation date.</param>
        /// <param name="incrementDate">The increment date.</param>
        /// <param name="disposedDate">The disposed date.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="accessories">The accessories.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="unitPrice">The unit price.</param>
        /// <param name="orgPrice">The org price.</param>
        /// <param name="accumDepreciationAmount">The accum depreciation amount.</param>
        /// <param name="remainingAmount">The remaining amount.</param>
        /// <param name="currencyCode">The ccy identifier.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="unitPriceUSD">The unit price usd.</param>
        /// <param name="orgPriceUSD">The org price usd.</param>
        /// <param name="accumDepreciationAmountUSD">The accum depreciation amount usd.</param>
        /// <param name="remainingAmountUSD">The remaining amount usd.</param>
        /// <param name="annualDepreciationAmount">The annual depreciation amount.</param>
        /// <param name="annualDepreciationAmountUSD">The annual depreciation amount usd.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <param name="depreciationRate">The depreciation rate.</param>
        /// <param name="orgPriceAccountCode">The org price account.</param>
        /// <param name="depreciationAccountCode">The depreciation account.</param>
        /// <param name="capitalAccountCode">The capital account.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="remainingOrgPrice">The remaining org price.</param>
        /// <param name="remainingOrgPriceUSD">The remaining org price usd.</param>
        /// <param name="numberOfFloor">The number of floor.</param>
        /// <param name="areaOfBuilding">The area of building.</param>
        /// <param name="areaOfFloor">The area of floor.</param>
        /// <param name="workingArea">The working area.</param>
        /// <param name="administrationArea">The administration area.</param>
        /// <param name="housingArea">The housing area.</param>
        /// <param name="vacancyArea">The vacancy area.</param>
        /// <param name="occupiedArea">The occupied area.</param>
        /// <param name="leasingArea">The leasing area.</param>
        /// <param name="guestHouseArea">The guest house area.</param>
        /// <param name="otherArea">The other area.</param>
        /// <param name="numberOfSeat">The number of seat.</param>
        /// <param name="controlPlate">The control plate.</param>
        /// <param name="isStateManagement">if set to <c>true</c> [is state management].</param>
        /// <param name="isBussiness">if set to <c>true</c> [is bussiness].</param>
        /// <param name="address">The address.</param>
        /// <param name="isEstimateEmployee">if set to <c>true</c> [is estimate employee].</param>
        public FixedAssetEntity(int fixedAssetId, string fixedAssetCode, string fixedAssetName, string fixedAssetForeignName, int fixedAssetCategoryId,
            int state, string description, int productionYear, string madeIn, DateTime purchasedDate, DateTime usedDate, DateTime depreciationDate,
            DateTime incrementDate, DateTime disposedDate, string unit, string serialNumber, string accessories, int quantity, decimal unitPrice,
            decimal orgPrice, decimal accumDepreciationAmount, decimal remainingAmount, string currencyCode, decimal exchangeRate, decimal unitPriceUSD,
            decimal orgPriceUSD, decimal accumDepreciationAmountUSD, decimal remainingAmountUSD, decimal annualDepreciationAmount,
            decimal annualDepreciationAmountUSD, decimal lifeTime, decimal depreciationRate, string orgPriceAccountCode, string depreciationAccountCode,
            string capitalAccountCode, int departmentId, int? employeeId, bool isActive, decimal remainingOrgPrice, decimal remainingOrgPriceUSD,
            short numberOfFloor, decimal areaOfBuilding, decimal areaOfFloor, decimal workingArea, decimal administrationArea, decimal housingArea,
            decimal vacancyArea, decimal occupiedArea, decimal leasingArea, decimal guestHouseArea, decimal otherArea, short numberOfSeat,
            string controlPlate, bool isStateManagement, bool isBussiness, string address, bool isEstimateEmployee, string armortizationAccount, string budgetItemCode, 
            List<FixedAssetAccessaryEntity> fixedAssetAccessarys, DateTime? dateSuspension, string reasonSuspension)
            : this()
        {
            FixedAssetId = fixedAssetId;
            FixedAssetCode = fixedAssetCode;
            FixedAssetName = fixedAssetName;
            FixedAssetForeignName = fixedAssetForeignName;
            FixedAssetCategoryId = fixedAssetCategoryId;
            State = state;
            Description = description;
            ProductionYear = productionYear;
            MadeIn = madeIn;
            PurchasedDate = purchasedDate;
            UsedDate = usedDate;
            DepreciationDate = depreciationDate;
            IncrementDate = incrementDate;
            DisposedDate = disposedDate;
            Unit = unit;
            SerialNumber = serialNumber;
            Accessories = accessories;
            Quantity = quantity;
            UnitPrice = unitPrice;
            OrgPrice = orgPrice;
            AccumDepreciationAmount = accumDepreciationAmount;
            RemainingAmount = remainingAmount;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            UnitPriceUSD = unitPriceUSD;
            OrgPriceUSD = orgPriceUSD;
            AccumDepreciationAmountUSD = accumDepreciationAmountUSD;
            RemainingAmountUSD = remainingAmountUSD;
            AnnualDepreciationAmount = annualDepreciationAmount;
            AnnualDepreciationAmountUSD = annualDepreciationAmountUSD;
            LifeTime = lifeTime;
            DepreciationRate = depreciationRate;
            OrgPriceAccountCode = orgPriceAccountCode;
            DepreciationAccountCode = depreciationAccountCode;
            CapitalAccountCode = capitalAccountCode;
            DepartmentId = departmentId;
            EmployeeId = employeeId;
            IsActive = isActive;
            RemainingOrgPrice = remainingOrgPrice;
            RemainingOrgPriceUSD = remainingOrgPriceUSD;
            NumberOfFloor = numberOfFloor;
            AreaOfBuilding = areaOfBuilding;
            AreaOfFloor = areaOfFloor;
            WorkingArea = workingArea;
            AdministrationArea = administrationArea;
            HousingArea = housingArea;
            VacancyArea = vacancyArea;
            OccupiedArea = occupiedArea;
            LeasingArea = leasingArea;
            GuestHouseArea = guestHouseArea;
            OtherArea = otherArea;
            NumberOfSeat = numberOfSeat;
            ControlPlate = controlPlate;
            IsStateManagement = isStateManagement;
            IsBussiness = isBussiness;
            Address = address;
            IsEstimateEmployee = isEstimateEmployee;
            ArmortizationAccount = armortizationAccount;
            BudgetItemCode = budgetItemCode;
            FixedAssetAccessarys = fixedAssetAccessarys;
            DateSuspension = dateSuspension;
            ReasonSuspension = reasonSuspension;
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

        public decimal RemainingOrgPrice { set; get; }

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

        public IList<FixedAssetCurrencyEntity> FixedAssetCurrencies { get; set; }

        public IList<FixedAssetAccessaryEntity> FixedAssetAccessarys { get; set; }
    }
}
