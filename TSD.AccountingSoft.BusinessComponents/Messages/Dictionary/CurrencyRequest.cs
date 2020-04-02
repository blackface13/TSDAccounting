/***********************************************************************
 * <copyright file="CurrencyRequest.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class CurrencyRequest.
    /// </summary>
    public class CurrencyRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the Currency property identifier.
        /// </summary>
        /// <value>The Currency property identifier.</value>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The Currency
        /// </summary>
        public CurrencyEntity Currency; 
    }
}
