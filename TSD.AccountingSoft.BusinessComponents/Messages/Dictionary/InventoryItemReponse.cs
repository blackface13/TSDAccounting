/***********************************************************************
 * <copyright file="InventoryItemReponse.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// class InventoryItemResponse
    /// </summary>
    public class InventoryItemResponse :ResponseBase
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// The customer
        /// </summary>
        public InventoryItemEntity InventoryItem;

        /// <summary>
        /// The customers
        /// </summary>
        public List<InventoryItemEntity> InventoryItems;

    }
}
