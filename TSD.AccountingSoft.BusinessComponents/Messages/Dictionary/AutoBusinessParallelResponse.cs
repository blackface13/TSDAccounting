using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    public class AutoBusinessParallelResponse : ResponseBase
    {
        public AutoBusinessParallelEntity AutoBusinessParallelEntity { get; set; }

        public int AutoBusinessParallelId { get; set; }
    }
}
