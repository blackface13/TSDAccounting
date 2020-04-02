using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportF03BCTModel
    {
        public List<ReportF03BCTDetailModel> Table1 { get; set; }
        public List<ReportF03BCTDetailModel> Table2 { get; set; }
    }

    public class ReportF03BCTDetailModel
    {
        public int? OrderNumber { get; set; }
        public string BudgetItemCode { get; set; }
        public int? BudgetItemType { get; set; }
        public string Content { get; set; }
        public string FontStyle { get; set; }
        public int? ParentId { get; set; }
        public decimal Amount1 { get; set; }
        public decimal Amount2 { get; set; }
        public decimal Amount3 { get; set; }
        public decimal Amount4 { get; set; }
        public decimal Amount5 { get; set; }
        public decimal Amount6 { get; set; }
        public decimal Amount7 { get; set; }
        public decimal Amount8 { get; set; }
        public decimal Amount9 { get; set; }
        public decimal Amount10 { get; set; }
    }
}
