using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// PlanReceiptTempateItemRequest
    /// </summary>
    public class PlanReceiptTempateItemRequest : RequestBase
    {
 
    /// <summary>
    /// Gets or sets the plan receipt tempate item identifier.
    /// </summary>
    /// <value>
    /// The plan receipt tempate item identifier.
    /// </value>
    public int PlanReceiptTempateItemId { get; set; }

        /// <summary>
        /// The plan receipt tempate item
        /// </summary>
        public PlanReceiptTempateItemEntity PlanReceiptTempateItem;
    }
}
