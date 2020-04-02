using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;

namespace TSD.AccountingSoft.Model.BusinessObjects.Inventory
{
    public class ReCalOutputItemTransactionModel 
    {
        public string FromDate { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate { get; set; }  

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public List<int> StockId { get; set; } 

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string CurrencyCode { get; set; } 

       
    }
}
