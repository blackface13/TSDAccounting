/***********************************************************************
 * <copyright file="C22H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 03 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessEntities.Report.Voucher
{
    /// <summary>
    /// C22HEntity
    /// </summary>
    public class C11HEntity : BusinessEntities
    {
        public C11HEntity()
        {
            InventoryItems = new List<InventoryItemReportEntity>();
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
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
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>
        /// The name of the accounting object.
        /// </value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>
        /// The accounting object address.
        /// </value>
        public string AccountingObjectAddress { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the buildings.
        /// </summary>
        /// <value>
        /// The buildings.
        /// </value>
        public IList<InventoryItemReportEntity> InventoryItems { get; set; }

        public string CurrencyCode { get; set; }

        public string StockName { get; set; }

        public string Trader { get; set; }
    
}
}
