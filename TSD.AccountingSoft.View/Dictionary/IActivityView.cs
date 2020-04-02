using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IActivityView
    {
        int ActivityId { get; set; }
        string ActivityCode { get; set; }
        string ActivityName { get; set; }
        int? ParentID { get; set; }
        bool IsActive { get; set; }
        bool IsParent { get; set; }
        bool IsSystem { get; set; }
        int Grade { get; set; }
    }
}
