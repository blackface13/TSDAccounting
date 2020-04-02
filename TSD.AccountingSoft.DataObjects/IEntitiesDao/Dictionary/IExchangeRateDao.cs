/***********************************************************************
 * <copyright file="IExchangeRateDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IExchangeRateDao
    /// </summary>
    public interface IExchangeRateDao
    {
        /// <summary>
        /// Gets the exchange rate.
        /// </summary>
        /// <param name="exchangeId">The exchange identifier.</param>
        /// <returns></returns>
        ExchangeRateEntity GetExchangeRate(int exchangeId);

        /// <summary>
        /// Gets the exchange rates by date and budget source.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="budgetSouceCode">The budget souce code.</param>
        /// <returns></returns>
        ExchangeRateEntity GetExchangeRatesByDateAndBudgetSource(DateTime fromdate, DateTime todate, string budgetSouceCode);

        /// <summary>
        /// Gets the exchange rates.
        /// </summary>
        /// <returns></returns>
        List<ExchangeRateEntity> GetExchangeRates();

        /// <summary>
        /// Gets the exchange rates by date.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <returns></returns>
        List<ExchangeRateEntity> GetExchangeRatesByDate(DateTime fromdate, DateTime todate);

        /// <summary>
        /// Gets the exchange rates by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<ExchangeRateEntity> GetExchangeRatesByActive(bool isActive);

        /// <summary>
        /// Inserts the exchange rate.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <returns></returns>
        int InsertExchangeRate(ExchangeRateEntity exchangeRate);

        /// <summary>
        /// Updates the exchange rate.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <returns></returns>
        string UpdateExchangeRate(ExchangeRateEntity exchangeRate);

        /// <summary>
        /// Deletes the exchange rate.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <returns></returns>
        string DeleteExchangeRate(ExchangeRateEntity exchangeRate);
    }
}
