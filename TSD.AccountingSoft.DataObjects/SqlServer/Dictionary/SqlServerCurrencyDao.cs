/***********************************************************************
 * <copyright file="SqlServerCurrencyDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
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
    /// <summary>
    /// Class SqlServerCurrencyDao.
    /// </summary>
    public class SqlServerCurrencyDao : ICurrencyDao
    {
        /// <summary>
        /// Gets the budget source property.
        /// </summary>
        /// <param name="currencyId">The budget source property identifier.</param>
        /// <returns>CurrencyEntity.</returns>
        public CurrencyEntity GetCurrency(int currencyId)
        {
            const string sql = @"uspGet_Currency_ByID";

            object[] parms = { "@CurrencyID", currencyId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget source properties.
        /// </summary>
        /// <returns>List{CurrencyEntity}.</returns>
        public List<CurrencyEntity> GetCurrencies()
        {
            const string procedures = @"uspGet_All_Currency";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.Int32.</returns>
        public int InsertCurrency(CurrencyEntity currency)
        {
            const string sql = "uspInsert_Currency";
            return Db.Insert(sql, true, Take(currency));
        }

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        public string UpdateCurrency(CurrencyEntity currency)
        {
            const string sql = "uspUpdate_Currency";
            return Db.Update(sql, true, Take(currency));
        }

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        public string DeleteCurrency(CurrencyEntity currency)
        {
            const string sql = @"uspDelete_Currency";
            object[] parms = { "@CurrencyID", currency.CurrencyId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CurrencyEntity> Make = reader =>
            new CurrencyEntity
            {
                CurrencyId = reader["CurrencyID"].AsInt(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                CurrencyName = reader["CurrencyName"].AsString(),
                Prefix = reader["Prefix"].AsString(),
                Suffix = reader["Suffix"].AsString(),
                IsMain = reader["IsMain"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="currency">The budget source property.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(CurrencyEntity currency)
        {
            return new object[]  
            {
                "@CurrencyID", currency.CurrencyId,
                "@CurrencyCode", currency.CurrencyCode,
                "@CurrencyName", currency.CurrencyName,
                "@Prefix", currency.Prefix,
                "@Suffix", currency.Suffix,
                "@IsMain", currency.IsMain,
                "@IsActive", currency.IsActive
            };
        }

        /// <summary>
        /// Gets the currencies by active.
        /// </summary>
        /// <returns>List{CurrencyEntity}.</returns>
        public List<CurrencyEntity> GetCurrenciesByActive()
        {
            const string procedures = @"uspGet_Currency_ByActive";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the currencies by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public CurrencyEntity GetCurrenciesByCurrencyCode(string currencyCode)
        {
            const string sql = @"uspGet_Currency_ByCode";

            object[] parms = { "@CurrencyCode", currencyCode }; 
            return Db.Read(sql, true, Make, parms);
        }

        public List<CurrencyEntity> GetCurrenciesByIsMain()
        {
            const string procedures = @"uspGet_CurrencyIsMain";
            return Db.ReadList(procedures, true, Make);
        }
    }
}
