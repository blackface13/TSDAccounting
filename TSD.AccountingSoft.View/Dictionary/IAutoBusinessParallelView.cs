using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IAutoBusinessParallelView : IView
    {
        int AutoBusinessParallelId { get; set; }
        string AutoBusinessCode { get; set; }
        string AutoBusinessName { get; set; }
        string Description { get; set; }
        bool IsActive { get; set; }
        string DebitAccount { get; set; }
        string CreditAccount { get; set; }
        int BudgetSourceId { get; set; }
        int BudgetItemId { get; set; }
        int BudgetSubItemId { get; set; }
        int VoucherTypeId { get; set; }
        string DebitAccountParallel { get; set; }
        string CreditAccountParallel { get; set; }
        int BudgetSourceIdParallel { get; set; }
        int BudgetItemIdParallel { get; set; }
        int BudgetSubItemIdParallel { get; set; }
        int VoucherTypeIdParallel { get; set; }
        int SortOrder { get; set; }
        bool IsNegative { get; set; }
    }
}
