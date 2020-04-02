using TSD.AccountingSoft.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    public class ActivityEntity : BusinessEntities
    {
        public ActivityEntity()
        {
            AddRule(new ValidateRequired("ActivityCode"));
            AddRule(new ValidateRequired("ActivityName"));
        }
        public int ActivityId { get; set; }
        public string ActivityCode { get; set; }
        public string ActivityName { get; set; }
        public int? ParentID { get; set; }
        public bool IsActive { get; set; }
        public bool IsParent { get; set; }
        public bool IsSystem { get; set; }
        public int Grade { get; set; }
    }
}
