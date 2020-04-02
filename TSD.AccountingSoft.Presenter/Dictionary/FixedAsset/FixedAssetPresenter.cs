/***********************************************************************
 * <copyright file="FixedAssetPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.FixedAsset
{
    /// <summary>
    /// FixedAsset Presenter
    /// </summary>
    public class FixedAssetPresenter : Presenter<IFixedAssetView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetPresenter(IFixedAssetView view)
            : base(view)
        {
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
        /// Displays the specified fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        public void Display(string fixedAssetId)
        {
            var fixedAsset = Model.GetFixedAssetById(int.Parse(fixedAssetId));

            View.FixedAssetId = fixedAsset.FixedAssetId;
            View.FixedAssetCode = fixedAsset.FixedAssetCode;
            View.FixedAssetName = fixedAsset.FixedAssetName;
            View.FixedAssetForeignName = fixedAsset.FixedAssetForeignName;
            View.FixedAssetCategoryId = fixedAsset.FixedAssetCategoryId;
            View.State = fixedAsset.State;
            View.Description = fixedAsset.Description;
            View.ProductionYear = fixedAsset.ProductionYear;
            View.MadeIn = fixedAsset.MadeIn;
            View.PurchasedDate = fixedAsset.PurchasedDate;
            View.UsedDate = fixedAsset.UsedDate;
            View.DepreciationDate = fixedAsset.DepreciationDate;
            View.IncrementDate = fixedAsset.IncrementDate;
            View.DisposedDate = fixedAsset.DisposedDate;
            View.Unit = fixedAsset.Unit;
            View.SerialNumber = fixedAsset.SerialNumber;
            View.Accessories = fixedAsset.Accessories;
            View.Quantity = fixedAsset.Quantity;
            View.UnitPrice = fixedAsset.UnitPrice;
            View.OrgPrice = fixedAsset.OrgPrice;
            View.AccumDepreciationAmount = fixedAsset.AccumDepreciationAmount;
            View.RemainingAmount = fixedAsset.RemainingAmount;
            View.CurrencyCode = fixedAsset.CurrencyCode;
            View.ExchangeRate = fixedAsset.ExchangeRate;
            View.UnitPriceUSD = fixedAsset.UnitPriceUSD;
            View.OrgPriceUSD = fixedAsset.OrgPriceUSD;
            View.AccumDepreciationAmountUSD = fixedAsset.AccumDepreciationAmountUSD;
            View.RemainingAmountUSD = fixedAsset.RemainingAmountUSD;
            View.LifeTime = fixedAsset.LifeTime;
            View.DepreciationRate = fixedAsset.DepreciationRate;
            View.OrgPriceAccountCode = fixedAsset.OrgPriceAccountCode;
            View.DepreciationAccountCode = fixedAsset.DepreciationAccountCode;
            View.CapitalAccountCode = fixedAsset.CapitalAccountCode;
            View.DepartmentId = fixedAsset.DepartmentId;
            View.EmployeeId = fixedAsset.EmployeeId;
            View.IsActive = fixedAsset.IsActive;
            View.NumberOfFloor = fixedAsset.NumberOfFloor;
            View.AreaOfBuilding = fixedAsset.AreaOfBuilding;
            View.AreaOfFloor = fixedAsset.AreaOfFloor;
            View.AdministrationArea = fixedAsset.AdministrationArea;
            View.HousingArea = fixedAsset.HousingArea;
            View.VacancyArea = fixedAsset.OccupiedArea;
            View.LeasingArea = fixedAsset.LeasingArea;
            View.GuestHouseArea = fixedAsset.GuestHouseArea;
            View.OtherArea = fixedAsset.OtherArea;
            View.NumberOfSeat=fixedAsset.NumberOfSeat;
            View.ControlPlate=fixedAsset.ControlPlate;
            View.IsStateManagement = fixedAsset.IsStateManagement;
            View.IsBussiness = fixedAsset.IsBussiness;
            View.Address = fixedAsset.Address;
            View.WorkingArea = fixedAsset.WorkingArea;
            View.OccupiedArea = fixedAsset.OccupiedArea;
            View.BudgetSourceCode = fixedAsset.BudgetSourceCode;
            View.ManagementCar = fixedAsset.ManagementCar;
            View.Brand = fixedAsset.Brand;
            View.IsEstimateEmployee = fixedAsset.IsEstimateEmployee;
            View.FixedAssetCurrencies = fixedAsset.FixedAssetCurrencies;
            View.ArmortizationAccount = fixedAsset.ArmortizationAccount;
            View.BudgetItemCode = fixedAsset.BudgetItemCode;
            View.FixedAssetAccessarys = fixedAsset.FixedAssetAccessarys;
            View.DateSuspension = fixedAsset.DateSuspension;
            View.ReasonSuspension = fixedAsset.ReasonSuspension;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save(int replication)
        {
            var fixedAsset = new FixedAssetModel
            {
                FixedAssetId = View.FixedAssetId,
                FixedAssetCode = View.FixedAssetCode,
                FixedAssetName = View.FixedAssetName,
                FixedAssetForeignName = View.FixedAssetForeignName,
                FixedAssetCategoryId = View.FixedAssetCategoryId,
                State = View.State,
                Description = View.Description,
                ProductionYear = View.ProductionYear,
                MadeIn = View.MadeIn,
                PurchasedDate = View.PurchasedDate,
                UsedDate = View.UsedDate,
                DepreciationDate = View.DepreciationDate,
                IncrementDate = View.IncrementDate,
                DisposedDate = View.DisposedDate,
                Unit = View.Unit,
                SerialNumber = View.SerialNumber,
                Accessories = View.Accessories,
                Quantity = View.Quantity,
                UnitPrice = View.UnitPrice,
                OrgPrice = View.OrgPrice,
                AccumDepreciationAmount = View.AccumDepreciationAmount,
                RemainingAmount = View.RemainingAmount,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                UnitPriceUSD = View.UnitPriceUSD,
                OrgPriceUSD = View.OrgPriceUSD,
                AccumDepreciationAmountUSD = View.AccumDepreciationAmountUSD,
                RemainingAmountUSD = View.RemainingAmountUSD,
                AnnualDepreciationAmountUSD = View.AnnualDepreciationAmountUSD,
                AnnualDepreciationAmount = View.AnnualDepreciationAmount,
                LifeTime = View.LifeTime,
                DepreciationRate = View.DepreciationRate,
                OrgPriceAccountCode = View.OrgPriceAccountCode,
                DepreciationAccountCode = View.DepreciationAccountCode,
                CapitalAccountCode = View.CapitalAccountCode,
                DepartmentId = View.DepartmentId,
                EmployeeId = View.EmployeeId,
                IsActive = View.IsActive,
                FixedAssetCurrencies = View.FixedAssetCurrencies,
                NumberOfFloor = View.NumberOfFloor,
                AreaOfBuilding = View.AreaOfBuilding,
                AreaOfFloor = View.AreaOfFloor,
                AdministrationArea = View.AdministrationArea,
                WorkingArea = View.WorkingArea,
                HousingArea = View.HousingArea,
                VacancyArea = View.VacancyArea,
                OccupiedArea = View.OccupiedArea,
                LeasingArea = View.LeasingArea,
                GuestHouseArea = View.GuestHouseArea,
                OtherArea = View.OtherArea,
                NumberOfSeat = View.NumberOfSeat,
                ControlPlate = View.ControlPlate,
                IsStateManagement = View.IsStateManagement,
                IsBussiness = View.IsBussiness,
                Address =  View.Address,
                BudgetSourceCode = View.BudgetSourceCode,
                ManagementCar = View.ManagementCar,
                Brand = View.Brand,
                IsEstimateEmployee = View.IsEstimateEmployee,
                ArmortizationAccount = View.ArmortizationAccount,
                BudgetItemCode = View.BudgetItemCode,
                FixedAssetAccessarys = View.FixedAssetAccessarys,
                DateSuspension = View.DateSuspension,
                ReasonSuspension = View.ReasonSuspension
            };

            if (View.FixedAssetId == 0)
                return Model.AddFixedAssetReplication(fixedAsset, replication);
            return Model.UpdateFixedAssetReplication(fixedAsset, replication);
        }

        /// <summary>
        /// Gets the fixed asset increment by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public string GetFixedAssetIncrementByRefNo(string refNo)
        {
            var fixedAssetIncrementModel = Model.GetFixedAssetIncrementByRefNo(refNo);
            return fixedAssetIncrementModel != null ? fixedAssetIncrementModel.RefId.ToString() : "0";
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long SaveFixedAssetIncrements(List<FixedAssetIncrementModel> fixedAssetIncrements)
        {
            return Model.AddFixedAssetIncrements(fixedAssetIncrements, false);
        }

        /// <summary>
        /// Saves the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetDecrements">The fixed asset decrements.</param>
        /// <returns></returns>
        public long SaveFixedAssetDecrements(List<FixedAssetDecrementModel> fixedAssetDecrements, bool isAutoGenerateParallel = false)
        {
            return Model.AddFixedAssetDecrements(fixedAssetDecrements, isAutoGenerateParallel);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long SaveOpeningFixedAssetEntry(List<OpeningFixedAssetEntryModel> openingFixedAssetEntries)
        {
            if (View.FixedAssetId == 0)
                return Model.InsertOpeningFixedAssetEntries(openingFixedAssetEntries);
            return Model.UpdateOpeningFixedAssetEntries(openingFixedAssetEntries, View.FixedAssetId);
        }

        /// <summary>
        /// Deletes the opening fixed asset entry.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public int DeleteOpeningFixedAssetEntry(int fixedAssetId)
        {
            return Model.DeleteOpeningFixedAssetEntry(fixedAssetId);
        }

        /// <summary>
        /// Gets the fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public FixedAssetModel GetFADecrement(string fixedAssetId, string currencyCode, string postedDate)
        {
            var fixedAsset = Model.GetFixedAssetByFaDecrement(int.Parse(fixedAssetId), currencyCode, postedDate);
            return fixedAsset;
        }

        /// <summary>
        /// Gets the fa decrement quantity.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public FixedAssetModel GetFADecrement(string fixedAssetId, string currencyCode, int refTypeId)
        {
            var fixedAsset = Model.GetFixedAssetByFaDecrement(int.Parse(fixedAssetId), currencyCode,refTypeId);
            return fixedAsset;
        }

        /// <summary>
        /// Gets the fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public FixedAssetModel GetFADecrement(string fixedAssetId, int refTypeId)
        {
            var fixedAsset = Model.GetFixedAssetByFaDecrement(int.Parse(fixedAssetId), refTypeId);
            return fixedAsset;
        }

        /// <summary>
        /// Gets the fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public FixedAssetModel GetFAOpening(string fixedAssetId)
        {
            var fixedAsset = Model.GetFixedAssetByFaOpening(int.Parse(fixedAssetId));
            return fixedAsset;
        }

        public FixedAssetModel GetFixedAssetById(string fixedAssetId)
        {
            var fixedAsset = Model.GetFixedAssetById(int.Parse(fixedAssetId));
            return fixedAsset;
        }
        /// <summary>
        /// Deletes the specified fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public int Delete(int fixedAssetId)
        {
            return Model.DeleteFixedAsset(fixedAssetId);
        }
    }
}
