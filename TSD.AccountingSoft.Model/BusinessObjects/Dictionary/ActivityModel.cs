using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class ActivityModel
    {
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
