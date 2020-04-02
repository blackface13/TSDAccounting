/***********************************************************************
 * <copyright file="SqlCommonDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, May 30, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer
{
    /// <summary>
    /// class SqlCommonDao
    /// </summary>
    public class SqlCommonDao : ICommonDao
    {
        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public int GetIdByCode(string query)
        {
            return (int)Db.GetScalar(query);
        }

        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="idFieldName">Name of the identifier field.</param>
        /// <param name="codeFieldName">Name of the code field.</param>
        /// <param name="codeValueField">The code value field.</param>
        /// <returns></returns>
        public int? GetIdByCode(string tableName, string idFieldName, string codeFieldName, string codeValueField)
        {
            string sqlQuery = "SELECT " + idFieldName + " FROM " + tableName + " WHERE " + codeFieldName + "='" +
                              codeValueField + "'";
            var value = Db.GetScalar(sqlQuery);
            return value == null ? (int?) null : (int)value;
        }

        /// <summary>
        /// Resets the automatic increment.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="startIncrementNumber">The start increment number.</param>
        /// <returns></returns>
        public bool ResetAutoIncrement(string tableName, int startIncrementNumber)
        {
            string sqlQuery = "DBCC CHECKIDENT (" + tableName + ", RESEED, " + startIncrementNumber + ");";
            Db.GetScalar(sqlQuery);
            return true;
        }

        /// <summary>
        /// Updates the amount exchange.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public string UpdateAmountExchange(decimal exchangeRate, short currencyDecimalDigits, DateTime fromDate, DateTime toDate)
        {
            const string sql = "uspUpdate_AmountExchange";
            object[] parms = { "@ExchangeRate", exchangeRate, "@CurrencyDecimalDigits", currencyDecimalDigits, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.Update(sql, true, parms);
        }
    }
}
