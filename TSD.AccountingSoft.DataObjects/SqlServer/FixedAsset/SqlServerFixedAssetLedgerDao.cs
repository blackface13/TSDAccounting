/***********************************************************************
 * <copyright file="SqlServerFixedAssetLedgerDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    /// <summary>
    /// SqlServerFixedAssetLedgerDao
    /// </summary>
    public class SqlServerFixedAssetLedgerDao : IFixedAssetLedgerDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public FixedAssetLedgerEntity GetFixedAssetLedgerByRefId(long refId, int refTypeId)
        {
            const string procedures = @"uspGet_FixedAssetLedger_ByRefID";

            object[] parms = { "@RefID", refId, "@RefTypeID", refTypeId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="FixedAssetId"> </param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public FixedAssetLedgerEntity GetFixedAssetLedgerByFixedAssetId(int FixedAssetId, int refTypeId)
        {
            const string procedures = @"uspGet_Check_Fa_In_FaIncrementDetail";

            object[] parms = { "@RefID", FixedAssetId, "@RefTypeID", refTypeId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="FixedAssetId"> </param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<FixedAssetLedgerEntity> GetFixedAssetLedgerByFixedAssetId(int fixedAssetId)
        {
            const string procedures = @"uspGet_GetFixedAssetByFixedAssetLedger";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fixed asset ledger.
        /// </summary>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int InsertFixedAssetLedger(FixedAssetLedgerEntity fixedAssetLedger)
        {
            const string sql = @"uspInsert_FixedAssetLedger";
            return Db.Insert(sql, true, Take(fixedAssetLedger));
        }

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetLedgerByRefId(long refId, int refTypeId)
        {
            const string procedures = @"uspDelete_FixedAssetLedger_ByRefID";

            object[] parms = { "@RefID", refId, "@RefTypeID", refTypeId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetLedgerByFixedAssetId(int FixedAssetId, int refTypeId)
        {
            const string procedures = @"uspDelete_FixedAssetLedger_ByFixedAssetID";
            object[] parms = { "@FixedAssetID", FixedAssetId, "@RefTypeID", refTypeId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetLedgerEntity> Make = reader =>
            new FixedAssetLedgerEntity
            {
                FixedAssetLedgerId = reader["FixedAssetLedgerId"].AsLong(),
                RefId = reader["RefId"].AsLong(),
                RefTypeId = reader["RefTypeId"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                FixedAssetId = reader["FixedAssetId"].AsInt(),
                DepartmentId = reader["DepartmentId"].AsInt(),
                LifeTime = reader["LifeTime"].AsFloat(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsFloat(),
                AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                OrgPriceDebitAmount = reader["OrgPriceDebitAmount"].AsDecimal(),
                OrgPriceCreditAmount = reader["OrgPriceCreditAmount"].AsDecimal(),
                OrgPriceDebitAmountExchange = reader["OrgPriceDebitAmountExchange"].AsDecimal(),
                OrgPriceCreditAmountExchange = reader["OrgPriceCreditAmountExchange"].AsDecimal(),
                DepreciationAccount = reader["DepreciationAccount"].AsString(),
                DepreciationDebitAmount = reader["DepreciationDebitAmount"].AsDecimal(),
                DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                DepreciationDebitAmountExchange = reader["DepreciationDebitAmountExchange"].AsDecimal(),
                DepreciationCreditAmountExchange = reader["DepreciationCreditAmountExchange"].AsDecimal(),
                BudgetSourceAccount = reader["BudgetSourceAccount"].AsString(),
                BudgetSourcelDebitAmount = reader["BudgetSourcelDebitAmount"].AsDecimal(),
                BudgetSourceCreditAmount = reader["BudgetSourceCreditAmount"].AsDecimal(),
                BudgetSourcelDebitAmountExchange = reader["BudgetSourcelDebitAmountExchange"].AsDecimal(),
                BudgetSourceCreditAmountExchange = reader["BudgetSourceCreditAmountExchange"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                Description = reader["Description"].AsString(),
                Quantity = reader["Quantity"].AsInt()
            };

        /// <summary>
        /// Takes the specified fixed asset ledger.
        /// </summary>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        private static object[] Take(FixedAssetLedgerEntity fixedAssetLedger)
        {
            return new object[]  
            {
                "@FixedAssetLedgerID", fixedAssetLedger.FixedAssetLedgerId,
                "@RefID", fixedAssetLedger.RefId,
                "@RefTypeID", fixedAssetLedger.RefTypeId,
                "@RefNo", fixedAssetLedger.RefNo,
                "@RefDate", fixedAssetLedger.RefDate,
                "@PostedDate", fixedAssetLedger.PostedDate,
                "@FixedAssetID", fixedAssetLedger.FixedAssetId,
                "@DepartmentID", fixedAssetLedger.DepartmentId,
                "@LifeTime", fixedAssetLedger.LifeTime,
                "@CurrencyCode", fixedAssetLedger.CurrencyCode,
                "@AnnualDepreciationRate", fixedAssetLedger.AnnualDepreciationRate,
                "@AnnualDepreciationAmount", fixedAssetLedger.AnnualDepreciationAmount,
                "@ExchangeRate", fixedAssetLedger.ExchangeRate,
                "@OrgPriceAccount", fixedAssetLedger.OrgPriceAccount,
                "@OrgPriceDebitAmount", fixedAssetLedger.OrgPriceDebitAmount,
                "@OrgPriceCreditAmount", fixedAssetLedger.OrgPriceCreditAmount,
                "@OrgPriceDebitAmountExchange", fixedAssetLedger.OrgPriceDebitAmountExchange,
                "@OrgPriceCreditAmountExchange", fixedAssetLedger.OrgPriceCreditAmountExchange,
                "@DepreciationAccount", fixedAssetLedger.DepreciationAccount,
                "@DepreciationDebitAmount", fixedAssetLedger.DepreciationDebitAmount,
                "@DepreciationCreditAmount", fixedAssetLedger.DepreciationCreditAmount,
                "@DepreciationDebitAmountExchange", fixedAssetLedger.DepreciationDebitAmountExchange,
                "@DepreciationCreditAmountExchange", fixedAssetLedger.DepreciationCreditAmountExchange,
                "@BudgetSourceAccount", fixedAssetLedger.BudgetSourceAccount,
                "@BudgetSourcelDebitAmount", fixedAssetLedger.BudgetSourcelDebitAmount,
                "@BudgetSourceCreditAmount", fixedAssetLedger.BudgetSourceCreditAmount,
                "@BudgetSourcelDebitAmountExchange", fixedAssetLedger.BudgetSourcelDebitAmountExchange,
                "@BudgetSourceCreditAmountExchange", fixedAssetLedger.BudgetSourceCreditAmountExchange,
                "@JournalMemo", fixedAssetLedger.JournalMemo,
                "@Description", fixedAssetLedger.Description,
                "Quantity", fixedAssetLedger.Quantity
            };
        }
    }
}