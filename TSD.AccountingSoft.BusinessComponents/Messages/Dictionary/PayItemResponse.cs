/***********************************************************************
 * <copyright file="PayItemResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// PayItemResponse
    /// </summary>
    public class PayItemResponse : ResponseBase
    {
        /// <summary>
        /// The pay items
        /// </summary>
        public IList<PayItemEntity> PayItems;

        /// <summary>
        /// The pay item
        /// </summary>
        public PayItemEntity PayItem;

        /// <summary>
        /// Gets or sets the pay item identifier.
        /// </summary>
        /// <value>
        /// The pay item identifier.
        /// </value>
        public int PayItemId { get; set; }
    }
}
