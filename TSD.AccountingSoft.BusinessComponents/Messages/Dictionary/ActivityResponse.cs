using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    public class ActivityResponse : ResponseBase
    {
        public ActivityEntity ActivityEntity { get; set; }
        public int ActivityId { get; set; }
    }
}
