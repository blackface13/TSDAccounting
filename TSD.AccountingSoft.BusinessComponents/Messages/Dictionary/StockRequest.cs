/***********************************************************************
 * <copyright file="StockRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
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
    /// Class StockRequest.
    /// </summary>
    public class StockRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the Stock identifier.
        /// </summary>
        /// <value>
        /// The Stock identifier.
        /// </value>
        public int StockId { get; set; }

        /// <summary>
        /// The Stock
        /// </summary>
        public StockEntity Stock;
    }
}
