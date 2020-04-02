using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Inventory
{
    public class ItemTransactionResponse : ResponseBase
    {
        /// <summary>
        /// The estimates
        /// </summary>
        public IList<ItemTransactionEntity> ItemTransactions; 

        /// <summary>
        /// The estimate
        /// </summary>
        public ItemTransactionEntity ItemTransaction; 

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
