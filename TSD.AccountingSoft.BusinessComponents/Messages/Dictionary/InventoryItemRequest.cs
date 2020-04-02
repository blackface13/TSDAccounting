/***********************************************************************
 * <copyright file="InventoryItemRequest.cs" company="BUCA JSC">
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

using System;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class InventoryItemRequest.
    /// </summary>
    public class InventoryItemRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The StockId.</value>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        public DateTime PostDate { get; set; }

        /// <summary>
        /// Gets or sets the item stock identifier.
        /// </summary>
        /// <value>
        /// The item stock identifier.
        /// </value>
        public int ItemStockId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        public long RefId { get; set; }

        /// <summary>
        /// The InventoryItem
        /// </summary>
        public InventoryItemEntity InventoryItem;
    }
}
