/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
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
    public class SqlServerFixedAssetDao : IFixedAssetDao
    {
        #region IFixedAsset Members

        public FixedAssetEntity GetFixedAssetOnFixedAssetIncrement(int fixedAssetId)
        {
            const string sql = @"uspGet_Check_Fa_In_FaIncrementDetail";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, Make, parms);
        }

        public FixedAssetEntity GetFixedAssetByCode(string fixedAssetCode)
        {
            object[] parms = { "@FixedAssetCode", fixedAssetCode };
            const string sql = @"uspGet_FixedAsset_ByFixedAssetCode";
            return Db.Read(sql, true, Make, parms);
        }

        public List<FixedAssetEntity> GetFixedAssetsByCode(string fixedAssetCode)
        {
            object[] parms = { "@FixedAssetCode", fixedAssetCode };
            const string sql = @"uspGet_FixedAsset_ByFixedAssetCode";
            return Db.ReadList(sql, true, Make, parms);
        }

        public FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, int refTypeId)
        {
            const string sql = @"uspCheck_FADecrement";

            object[] parms = { "@FixedAssetID", fixedAssetId, "@RefTypeID", refTypeId };
            return Db.Read(sql, true, MakeForDecrementQuantity, parms);
        }

        public FixedAssetEntity GetFixedAssetOpening(int fixedAssetId)
        {
            const string sql = @"uspCheck_FAOpening";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, MakeOnlyFixedAssetId, parms);
        }

        public FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, DateTime postedDate)
        {
            const string sql = @"uspGet_FixedAssetDecrement";

            object[] parms = { "@FixedAssetID", fixedAssetId, "@CurrencyCode", currencyCode, "@ToDate", postedDate };
            return Db.Read(sql, true, MakeForDecrement, parms);
        }

        public FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, int refTypeId)
        {
            const string sql = @"uspGet_FixedAssetDecrementQuantity";

            object[] parms = { "@FixedAssetID", fixedAssetId, "@CurrencyCode", currencyCode, "@RefTypeID", refTypeId };
            return Db.Read(sql, true, MakeForDecrementQuantity, parms);
        }

        public FixedAssetEntity GetFixedAsset(int fixedAssetId)
        {
            const string sql = @"uspGet_FixedAsset_ByID";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, Make, parms);
        }

        public FixedAssetEntity GetFixedAssetRemainingQuantity(int fixedAssetId)
        {
            const string sql = @"uspCheck_FixedAsset_RemainingQuantity";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Read(sql, true, Make, parms);
        }

        public List<FixedAssetEntity> GetAllFixedAssetsWithStoreProdure(string storeProdure)
        {
            return Db.ReadList(storeProdure, true, Make);
        }

        public List<FixedAssetEntity> GetFixedAssets()
        {
            const string procedures = @"uspGet_All_FixedAsset";
            return Db.ReadList(procedures, true, Make);
        }

        public List<FixedAssetEntity> GetFixedAssetsByActive(bool isActive)
        {
            const string sql = @"uspGet_FixedAsset_ByActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryCode(string fixedAssetCategoryCode)
        {
            const string sql = @"uspGet_FixedAsset_ByFixedAssetCategorycode";

            object[] parms = { "@FixedAssetCategoryCode", fixedAssetCategoryCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<FixedAssetEntity> GetFixedAssetsByFixedAssetTMDT(int yearPosted)
        {
            const string sql = @"uspReport_FixedAssetEsTimate_CarTMDT";

            object[] parms = { "@Year", yearPosted };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryId(int fixedAssetCategoryId)
        {
            const string sql = @"uspGet_FixedAsset_ByFixedAsseyCategoryID";

            object[] parms = { "@FixedAsseyCategoryID", fixedAssetCategoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public int InsertFixedAsset(FixedAssetEntity fixedAsset)
        {
            const string sql = "uspInsert_FixedAsset";
            return Db.Insert(sql, true, Take(fixedAsset));
        }

        public string UpdateFixedAsset(FixedAssetEntity fixedAsset)
        {
            const string sql = "uspUpdate_FixedAsset";
            return Db.Update(sql, true, Take(fixedAsset));
        }

        public string DeleteFixedAsset(FixedAssetEntity fixedAsset)
        {
            const string sql = @"uspDelete_FixedAsset";
            object[] parms = { "@FixedAssetID", fixedAsset.FixedAssetId };
            return Db.Delete(sql, true, parms);
        }

        #endregion

        private static readonly Func<IDataReader, FixedAssetEntity> Make = reader =>
        {
            var fixedAsset = new FixedAssetEntity();
            fixedAsset.FixedAssetId = reader["FixedAssetID"].AsInt();
            fixedAsset.FixedAssetCode = reader["FixedAssetCode"].AsString();
            fixedAsset.FixedAssetName = reader["FixedAssetName"].AsString();
            fixedAsset.FixedAssetForeignName = reader["FixedAssetForeignName"].AsString();
            fixedAsset.FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsInt();
            fixedAsset.State = reader["State"].AsInt();
            fixedAsset.Description = reader["Description"].AsString();
            fixedAsset.ProductionYear = reader["ProductionYear"].AsInt();
            fixedAsset.MadeIn = reader["MadeIn"].AsString();
            fixedAsset.PurchasedDate = reader["PurchasedDate"].AsDateTime();
            fixedAsset.UsedDate = reader["UsedDate"].AsDateTime();
            fixedAsset.DepreciationDate = reader["DepreciationDate"].AsDateTime();
            fixedAsset.IncrementDate = reader["IncrementDate"].AsDateTime();
            fixedAsset.DisposedDate = reader["DisposedDate"].AsDateTime();
            fixedAsset.Unit = reader["Unit"].AsString();
            fixedAsset.SerialNumber = reader["SerialNumber"].AsString();
            fixedAsset.Accessories = reader["Accessories"].AsString();
            fixedAsset.Quantity = reader["Quantity"].AsInt();
            fixedAsset.UnitPrice = reader["UnitPrice"].AsDecimal();
            fixedAsset.OrgPrice = reader["OrgPrice"].AsDecimal();
            fixedAsset.AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal();
            fixedAsset.RemainingAmount = reader["RemainingAmount"].AsDecimal();
            fixedAsset.CurrencyCode = reader["CurrencyCode"].AsString();
            fixedAsset.ExchangeRate = reader["ExchangeRate"].AsDecimal();
            fixedAsset.UnitPriceUSD = reader["UnitPriceUSD"].AsDecimal();
            fixedAsset.OrgPriceUSD = reader["OrgPriceUSD"].AsDecimal();
            fixedAsset.AccumDepreciationAmountUSD = reader["AccumDepreciationAmountUSD"].AsDecimal();
            fixedAsset.RemainingAmountUSD = reader["RemainingAmountUSD"].AsDecimal();
            fixedAsset.AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal();
            fixedAsset.AnnualDepreciationAmountUSD = reader["AnnualDepreciationAmountUSD"].AsDecimal();
            fixedAsset.LifeTime = reader["LifeTime"].AsDecimal();
            fixedAsset.DepreciationRate = reader["DepreciationRate"].AsDecimal();
            fixedAsset.OrgPriceAccountCode = reader["OrgPriceAccountCode"].AsString();
            fixedAsset.DepreciationAccountCode = reader["DepreciationAccountCode"].AsString();
            fixedAsset.CapitalAccountCode = reader["CapitalAccountCode"].AsString();
            fixedAsset.DepartmentId = reader["DepartmentID"].AsInt();
            fixedAsset.EmployeeId = reader["EmployeeID"].AsString().AsIntForNull();
            fixedAsset.IsActive = reader["IsActive"].AsBool();
            fixedAsset.NumberOfFloor = reader["NumberOfFloor"].AsShort();
            fixedAsset.AreaOfBuilding = reader["AreaOfBuilding"].AsDecimal();
            fixedAsset.AreaOfFloor = reader["AreaOfFloor"].AsDecimal();
            fixedAsset.WorkingArea = reader["WorkingArea"].AsDecimal();
            fixedAsset.AdministrationArea = reader["AdministrationArea"].AsDecimal();
            fixedAsset.HousingArea = reader["HousingArea"].AsDecimal();
            fixedAsset.VacancyArea = reader["VacancyArea"].AsDecimal();
            fixedAsset.OccupiedArea = reader["OccupiedArea"].AsDecimal();
            fixedAsset.LeasingArea = reader["LeasingArea"].AsDecimal();
            fixedAsset.GuestHouseArea = reader["GuestHouseArea"].AsDecimal();
            fixedAsset.OtherArea = reader["OtherArea"].AsDecimal();
            fixedAsset.NumberOfSeat = reader["NumberOfSeat"].AsShort();
            fixedAsset.ControlPlate = reader["ControlPlate"].AsString();
            fixedAsset.IsStateManagement = reader["IsStateManagement"].AsBool();
            fixedAsset.IsBussiness = reader["IsBussiness"].AsBool();
            fixedAsset.Address = reader["Address"].AsString();
            fixedAsset.BudgetSourceCode = reader["BudgetSourceCode"].AsString();
            fixedAsset.ManagementCar = reader["ManagementCar"].AsInt();
            fixedAsset.Brand = reader["Brand"].AsString();
            fixedAsset.IsEstimateEmployee = reader["IsEstimateEmployee"].AsBool();
            fixedAsset.ArmortizationAccount = reader["ArmortizationAccount"].AsString();
            fixedAsset.BudgetItemCode = reader["BudgetItemCode"].AsString();
            fixedAsset.DateSuspension = reader["DateSuspension"].AsDateTimeForNull();
            fixedAsset.ReasonSuspension = reader["ReasonSuspension"].AsString();
            return fixedAsset;
        };

        private static readonly Func<IDataReader, FixedAssetEntity> MakeForDecrement = reader =>
            new FixedAssetEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
                OrgPriceUSD = reader["OrgPriceUSD"].AsDecimal(),
                AccumDepreciationAmountUSD = reader["AccumDepreciationAmountUSD"].AsDecimal(),
                RemainingOrgPrice = reader["RemainingOrgPrice"].AsDecimal(),
                RemainingOrgPriceUSD = reader["RemainingOrgPriceUSD"].AsDecimal(),

            };

        private static readonly Func<IDataReader, FixedAssetEntity> MakeForDecrementQuantity = reader =>
            new FixedAssetEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                Quantity = reader["Quantity"].AsInt(),
                State = reader["State"].AsInt()
            };

        private static readonly Func<IDataReader, FixedAssetEntity> MakeOnlyFixedAssetId = reader =>
            new FixedAssetEntity
            {
                FixedAssetId = reader["FixedAssetID"].AsInt()
            };

        private object[] Take(FixedAssetEntity fixedAsset)
        {
            return new object[]
            {
                "@FixedAssetID", fixedAsset.FixedAssetId,
                "@FixedAssetCode", fixedAsset.FixedAssetCode,
                "@FixedAssetName", fixedAsset.FixedAssetName,
                "@FixedAssetForeignName", fixedAsset.FixedAssetForeignName,
                "@FixedAssetCategoryID", fixedAsset.FixedAssetCategoryId,
                "@State", fixedAsset.State,
                "@Description", fixedAsset.Description,
                "@ProductionYear", fixedAsset.ProductionYear,
                "@MadeIn", fixedAsset.MadeIn,
                "@PurchasedDate", fixedAsset.PurchasedDate,
                "@UsedDate", fixedAsset.UsedDate,
                "@DepreciationDate", fixedAsset.DepreciationDate,
                "@IncrementDate", fixedAsset.IncrementDate,
                "@DisposedDate", fixedAsset.DisposedDate,
                "@Unit", fixedAsset.Unit,
                "@SerialNumber", fixedAsset.SerialNumber,
                "@Accessories", fixedAsset.Accessories,
                "@Quantity", fixedAsset.Quantity,
                "@UnitPrice", fixedAsset.UnitPrice,
                "@OrgPrice", fixedAsset.OrgPrice,
                "@AccumDepreciationAmount", fixedAsset.AccumDepreciationAmount,
                "@RemainingAmount", fixedAsset.RemainingAmount,
                "@CurrencyCode", fixedAsset.CurrencyCode,
                "@ExchangeRate", fixedAsset.ExchangeRate,
                "@UnitPriceUSD", fixedAsset.UnitPriceUSD,
                "@OrgPriceUSD", fixedAsset.OrgPriceUSD,
                "@AccumDepreciationAmountUSD", fixedAsset.AccumDepreciationAmountUSD,
                "@RemainingAmountUSD", fixedAsset.RemainingAmountUSD,
                "@AnnualDepreciationAmount", fixedAsset.AnnualDepreciationAmount,
                "@AnnualDepreciationAmountUSD", fixedAsset.AnnualDepreciationAmountUSD,
                "@LifeTime", fixedAsset.LifeTime,
                "@DepreciationRate", fixedAsset.DepreciationRate,
                "@OrgPriceAccountCode", fixedAsset.OrgPriceAccountCode,
                "@DepreciationAccountCode", fixedAsset.DepreciationAccountCode,
                "@CapitalAccountCode", fixedAsset.CapitalAccountCode,
                "@DepartmentID", fixedAsset.DepartmentId,
                "@EmployeeID", fixedAsset.EmployeeId,
                "@IsActive", fixedAsset.IsActive,
                "@NumberOfFloor", fixedAsset.NumberOfFloor,
                "@AreaOfBuilding", fixedAsset.AreaOfBuilding,
                "@AreaOfFloor", fixedAsset.AreaOfFloor,
                "@WorkingArea", fixedAsset.WorkingArea,
                "@AdministrationArea", fixedAsset.AdministrationArea,
                "@HousingArea", fixedAsset.HousingArea,
                "@VacancyArea", fixedAsset.VacancyArea,
                "@OccupiedArea", fixedAsset.OccupiedArea,
                "@LeasingArea", fixedAsset.LeasingArea,
                "@GuestHouseArea", fixedAsset.GuestHouseArea,
                "@OtherArea", fixedAsset.OtherArea,
                "@NumberOfSeat", fixedAsset.NumberOfSeat,
                "@ControlPlate", fixedAsset.ControlPlate,
                "@IsStateManagement", fixedAsset.IsStateManagement,
                "@IsBussiness", fixedAsset.IsBussiness,
                "@Address", fixedAsset.Address,
                "@BudgetSourceCode", fixedAsset.BudgetSourceCode,
                "@ManagementCar", fixedAsset.ManagementCar,
                "@Brand", fixedAsset.Brand,
                "@IsEstimateEmployee", fixedAsset.IsEstimateEmployee,
                "@ArmortizationAccount", fixedAsset.ArmortizationAccount,
                "@BudgetItemCode", fixedAsset.BudgetItemCode,
                "@DateSuspension", fixedAsset.DateSuspension,
                "@ReasonSuspension", fixedAsset.ReasonSuspension
            };
        }
    }
}
