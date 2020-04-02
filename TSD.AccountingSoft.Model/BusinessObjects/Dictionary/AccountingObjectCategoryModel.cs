using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class AccountingObjectCategoryModel
    {
        public int AccountingObjectCategoryId { get; set; }
        public string AccountingObjectCategoryCode { get; set; }
        public string AccountingObjectCategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
    }
}
