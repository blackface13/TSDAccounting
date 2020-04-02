using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Tool
{
    public class SUIncrementDecrementResponse : ResponseBase
    {
        public long RefId { get; set; }
        public SUIncrementDecrementEntity SUIncrementDecrementEntity { get; set; }
    }
}
