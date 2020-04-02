/***********************************************************************
 * <copyright file="SqlServerFixedAssetCurrencyDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System.Data;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerFixedAssetCurrencyDao
    /// </summary>
    public class SqlServerFixedAssetCurrencyDao : IFixedAssetCurrencyDao
    {
        /// <summary>
        /// Gets the fixed asset currencys by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public IList<FixedAssetCurrencyEntity> GetFixedAssetCurrencysByFixedAssetId(int fixedAssetId)
        {
            const string sql = @"uspGet_FixedAssetCurrency_ByFixedAssetID";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset currency by fixed asset currency identifier.
        /// </summary>
        /// <param name="fixedAssetCurrencyId">The fixed asset currency identifier.</param>
        /// <returns></returns>
        public FixedAssetCurrencyEntity GetFixedAssetCurrencyByFixedAssetCurrencyId(int fixedAssetCurrencyId)
        {
            const string sql = @"uspGet_FixedAssetCurrency_FixedAssetCurrencyID";

            object[] parms = { "@FixedAssetCurrencyID", fixedAssetCurrencyId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fixed asset currency.
        /// </summary>
        /// <param name="fixedAssetCurrencyEntity">The fixed asset currency entity.</param>
        /// <returns></returns>
        public int InsertFixedAssetCurrency(FixedAssetCurrencyEntity fixedAssetCurrencyEntity)
        {
            const string sql = @"uspInsert_FixedAssetCurrency";
            return Db.Insert(sql, true, Take(fixedAssetCurrencyEntity));
        }

        /// <summary>
        /// Deletes the fixed asset currency by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetCurrencyByFixedAssetId(int fixedAssetId)
        {
            const string sql = @"uspDelete_FixedAssetCurrency_ByFixedAssetID";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Update(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetCurrencyEntity> Make = reader =>
            new FixedAssetCurrencyEntity
            {
                FixedAssetCurrencyId = reader["FixedAssetCurrencyID"].AsInt(),
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                UnitPriceUSD = reader["UnitPriceUSD"].AsDecimal(),
                OrgPrice = reader["OrgPrice"].AsDecimal(),
                OrgPriceUSD = reader["OrgPriceUSD"].AsDecimal(),
                AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
                AccumDepreciationAmountUSD = reader["AccumDepreciationAmountUSD"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                RemainingAmountUSD = reader["RemainingAmountUSD"].AsDecimal(),
                AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
                AnnualDepreciationAmountUSD = reader["AnnualDepreciationAmountUSD"].AsDecimal(),
                Description = reader["Description"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsFloat(),
            };

        /// <summary>
        /// Takes the specified fixed asset currency.
        /// </summary>
        /// <param name="fixedAssetCurrency">The fixed asset currency.</param>
        /// <returns></returns>
        private static object[] Take(FixedAssetCurrencyEntity fixedAssetCurrency)
        {
            return new object[]  
            {
                "@FixedAssetCurrencyID", fixedAssetCurrency.FixedAssetCurrencyId,
                "@FixedAssetID", fixedAssetCurrency.FixedAssetId,
                "@CurrencyCode", fixedAssetCurrency.CurrencyCode,
                "@UnitPrice", fixedAssetCurrency.UnitPrice,
                "@UnitPriceUSD", fixedAssetCurrency.UnitPriceUSD,
                "@OrgPrice", fixedAssetCurrency.OrgPrice,
                "@OrgPriceUSD", fixedAssetCurrency.OrgPriceUSD,
                "@AccumDepreciationAmount", fixedAssetCurrency.AccumDepreciationAmount,
                "@AccumDepreciationAmountUSD", fixedAssetCurrency.AccumDepreciationAmountUSD,
                "@RemainingAmount", fixedAssetCurrency.RemainingAmount,
                "@RemainingAmountUSD", fixedAssetCurrency.RemainingAmountUSD,
                "@AnnualDepreciationAmount", fixedAssetCurrency.AnnualDepreciationAmount,
                "@AnnualDepreciationAmountUSD", fixedAssetCurrency.AnnualDepreciationAmountUSD,
                "@Description", fixedAssetCurrency.Description,
                "@ExchangeRate", fixedAssetCurrency.ExchangeRate
            };
        }
    }
}
