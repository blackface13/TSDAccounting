using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Opening
{
    /// <summary>
    /// class SqlServerOpeningFixedAssetEntryDao
    /// </summary>
    public class SqlServerOpeningFixedAssetEntryDao : IOpeningFixedAssetEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        public List<OpeningFixedAssetEntryEntity> GetOpeningAccountEntries()
        {
            const string procedures = @"uspGet_All_OpeningFixedAssetEntry";
            return Db.ReadList(procedures, true, MakeIncludeAccountDetail);
        }

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        public List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntryEntityByAccountCode(string accountCode)
        {
            const string procedures = @"uspGet_OpeningFixedAssetEntry_ByAccountCode";

            object[] parms = { "@AccountCode", accountCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ref.
        /// </summary>
        /// <param name="refId">The ref identifier.</param>
        /// <returns></returns>
        public OpeningFixedAssetEntryEntity GetOpeningFixedAssetEntry(long refId)
        {
            const string sql = @"uspGet_OpeningFixedAssetEntry_FA";

            object[] parms = { "@FixedAssetID", refId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public long InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            const string sql = @"uspInsert_OpeningFixedAssetEntry";
            return Db.Insert(sql, true, Take(openingFixedAssetEntryEntity));
        }


        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public string UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            const string sql = @"uspUpdate_OpeningFixedAssetEntry";
            return Db.Update(sql, true, Take(openingFixedAssetEntryEntity));
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public string DeleteOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            const string sql = @"uspDelete_OpeningFixedAssetEntry";
            object[] parms = { "@RefID", openingFixedAssetEntryEntity.RefId };
            return Db.Delete(sql, true, parms);
        }



        /// <summary>
        /// Deletes the opening account entry detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteOpeningFixedAssetEntryByRefId(long refId)
        {
            const string sql = @"uspDelete_OpeningFixedAssetEntry";
            object[] parms = { "@RefID", refId };
            return Db.Delete(sql, true, parms);
        }


        /// <summary>
        /// Deletes the opening fixed asset entry by reference fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public string DeleteOpeningFixedAssetEntryByRefFixedAssetId(long fixedAssetId)
        {
            const string procedures = @"uspDelete_OpeningFixedAssetEntry_By_FixedAssetID";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningFixedAssetEntryEntity> MakeIncludeAccountDetail = reader =>
            new OpeningFixedAssetEntryEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                AccountNumber = reader["AccountCode"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                Quantity = reader["Quantity"].AsString().AsInt(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AmountOc = reader["AmountOC"].AsDecimal(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                AccountName = reader["AccountName"].AsString(),
                AccountId = reader["AccountId"].AsInt(),
                ParentId = reader["ParentId"].AsString().AsIntForNull(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningFixedAssetEntryEntity> Make = reader =>
            new OpeningFixedAssetEntryEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefNo = reader["RefNo"].AsString(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                DepartmentId = reader["DepartmentID"].AsInt(),
                LifeTime = reader["LifeTime"].AsInt(),
                IncrementDate = reader["IncrementDate"].AsDateTime(),
                Unit = reader["Unit"].AsString(),
                UsedDate = reader["UsedDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                OrgPriceDebitAmount = reader["OrgPriceDebitAmount"].AsDecimal(),
                OrgPriceDebitAmountUSD = reader["OrgPriceDebitAmountUSD"].AsDecimal(),
                DepreciationAccount = reader["DepreciationAccount"].AsString(),
                DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                DepreciationCreditAmountUSD = reader["DepreciationCreditAmountUSD"].AsDecimal(),
                CapitalAccount = reader["CapitalAccount"].AsString(),
                CapitalCreditAmount = reader["CapitalCreditAmount"].AsDecimal(),
                CapitalCreditAmountUSD = reader["CapitalCreditAmountUSD"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                RemainingAmountUSD = reader["RemainingAmountUSD"].AsDecimal(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                Description = reader["Description"].AsString(),
                Quantity = reader["Quantity"].AsInt(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString()
            };

        /// <summary>
        /// Takes the specified opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        private static object[] Take(OpeningFixedAssetEntryEntity openingAccountEntry)
        {
            return new object[]  
            {
                @"RefID", openingAccountEntry.RefId,
                @"RefNo", openingAccountEntry.RefNo,
                @"RefTypeID", openingAccountEntry.RefTypeId,
                @"PostedDate", openingAccountEntry.PostedDate,
                @"FixedAssetID", openingAccountEntry.FixedAssetId,
                @"DepartmentID", openingAccountEntry.DepartmentId,
                @"LifeTime", openingAccountEntry.LifeTime,
                @"IncrementDate", openingAccountEntry.IncrementDate,
                @"Unit", openingAccountEntry.Unit,
                @"UsedDate", openingAccountEntry.UsedDate,
                @"CurrencyCode", openingAccountEntry.CurrencyCode,
                @"ExchangeRate", openingAccountEntry.ExchangeRate,
                @"OrgPriceAccount", openingAccountEntry.OrgPriceAccount,
                @"OrgPriceDebitAmount", openingAccountEntry.OrgPriceDebitAmount,
                @"OrgPriceDebitAmountUSD", openingAccountEntry.OrgPriceDebitAmountUSD,
                @"DepreciationAccount", openingAccountEntry.DepreciationAccount,
                @"DepreciationCreditAmount", openingAccountEntry.DepreciationCreditAmount,
                @"DepreciationCreditAmountUSD", openingAccountEntry.DepreciationCreditAmountUSD,
                @"CapitalAccount", openingAccountEntry.CapitalAccount,
                @"CapitalCreditAmount", openingAccountEntry.CapitalCreditAmount,
                @"CapitalCreditAmountUSD", openingAccountEntry.CapitalCreditAmountUSD,
                @"RemainingAmount", openingAccountEntry.RemainingAmount,
                @"RemainingAmountUSD", openingAccountEntry.RemainingAmountUSD,
                @"BudgetChapterCode", openingAccountEntry.BudgetChapterCode,
                @"Description", openingAccountEntry.Description,
                @"Quantity", openingAccountEntry.Quantity,
                @"BudgetSourceCode",openingAccountEntry.BudgetSourceCode
                
            };
        }
    }
}
