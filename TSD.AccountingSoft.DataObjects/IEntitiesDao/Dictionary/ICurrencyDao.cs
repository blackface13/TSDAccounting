/***********************************************************************
 * <copyright file="ICurrencyDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface ICurrencyDao
    /// </summary>
    public interface ICurrencyDao
    {
        /// <summary>
        /// Gets the currencies by active.
        /// </summary>
        /// <returns>List{CurrencyEntity}.</returns>
        List<CurrencyEntity> GetCurrenciesByIsMain(); 
        /// <summary>
        /// Gets the currencies by active.
        /// </summary>
        /// <returns>List{CurrencyEntity}.</returns>
        List<CurrencyEntity> GetCurrenciesByActive();

        /// <summary>
        /// Gets the currencies by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        CurrencyEntity GetCurrenciesByCurrencyCode(string currencyCode);    

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>CurrencyEntity.</returns>
        CurrencyEntity GetCurrency(int currencyId);

        /// <summary>
        /// Gets the budget source properties.
        /// </summary>
        /// <returns>List{CurrencyEntity}.</returns>
        List<CurrencyEntity> GetCurrencies();

        /// <summary>
        /// Inserts the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.Int32.</returns>
        int InsertCurrency(CurrencyEntity currency);

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        string UpdateCurrency(CurrencyEntity currency);

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        string DeleteCurrency(CurrencyEntity currency);
    }
}
