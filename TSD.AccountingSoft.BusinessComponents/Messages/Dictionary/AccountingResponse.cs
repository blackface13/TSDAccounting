using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    public class AccountingResponse: ResponseBase
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// The accounting object
        /// </summary>
        public AccountingObjectEntity AccountingObject;
        /// <summary>
        /// The accounting objects
        /// </summary>
        public List<AccountingObjectEntity> AccountingObjects;
    }
}
