/***********************************************************************
 * <copyright file="CommonDao.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao
{
    public interface ICommonDao
    {
        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        int GetIdByCode(string query);

        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="idFieldName">Name of the identifier field.</param>
        /// <param name="codeFieldName">Name of the code field.</param>
        /// <param name="codeValueField">The code value field.</param>
        /// <returns></returns>
        int? GetIdByCode(string tableName, string idFieldName, string codeFieldName, string codeValueField);

        /// <summary>
        /// Resets the automatic increment.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="startIncrementNumber">The start increment number.</param>
        /// <returns></returns>
        bool ResetAutoIncrement(string tableName, int startIncrementNumber);

        /// <summary>
        /// Updates the amount exchange.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        string UpdateAmountExchange(decimal exchangeRate, short currencyDecimalDigits, DateTime fromDate,
            DateTime toDate);

    }
}
