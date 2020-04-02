using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.BusinessEntities.Business.Search;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Search
{
    public class SearchRequest : RequestBase
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
        public SearchEntity Search;  

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string CurrencyCode { get; set; } 
        public string WhereClause { get; set; }
        public string DepartmentCode { get; set; }
        public string FixedAssetCode { get; set; }

        public string BudgetGroupCode { get; set; } 
    }
}
