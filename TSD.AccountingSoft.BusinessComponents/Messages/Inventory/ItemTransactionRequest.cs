/***********************************************************************
 * <copyright file="ItemTransactionRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, November 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Inventory
{
    public class ItemTransactionRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The Deposit identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// The ItemTransaction 
        /// </summary>
        public ItemTransactionEntity ItemTransaction; 

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        public DateTime FromDateForReCalOutputStock { get; set; }

        public DateTime ToDateForReCalOutputStock { get; set; }

        public int SstockId { get; set; } 

        public   List<int> StockId { get; set; } 
        public string CurrencyCode { get; set; }

        public int CurrencyDecimalDigits { get; set; } 
    }
}
