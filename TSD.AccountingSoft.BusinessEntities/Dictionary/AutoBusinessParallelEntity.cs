using TSD.AccountingSoft.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    public class AutoBusinessParallelEntity : BusinessEntities
    {
        public AutoBusinessParallelEntity()
        {
            AddRule(new ValidateRequired("AutoBusinessCode"));
            AddRule(new ValidateRequired("AutoBusinessName"));
        }

        public int AutoBusinessParallelId { get; set; }
        public string AutoBusinessCode { get; set; }
        public string AutoBusinessName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public int BudgetSourceId { get; set; }
        public int BudgetItemId { get; set; }
        public int BudgetSubItemId { get; set; }
        public int VoucherTypeId { get; set; }
        public string DebitAccountParallel { get; set; }
        public string CreditAccountParallel { get; set; }
        public int BudgetSourceIdParallel { get; set; }
        public int BudgetItemIdParallel { get; set; }
        public int BudgetSubItemIdParallel { get; set; }
        public int VoucherTypeIdParallel { get; set; }
        public int SortOrder { get; set; }
        public bool IsNegative { get; set; }
    }
}
