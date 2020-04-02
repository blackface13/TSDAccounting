using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.LedgerAccounting
{
    public class ReportS104HModel
    {
        public long RefId { get; set; }
        public string RefNo { get; set; }
        public string RefDate { get; set; }
        public string Description { get; set; }
        public int RefTypeId { get; set; }

        /// <summary>
        /// kinh phí được cấp
        /// </summary>
        public decimal ExpenseAmount { get; set; }
        /// <summary>
        /// kinh phí đã sử dụng
        /// </summary>
        public decimal UsedAmount { get; set; }
        /// <summary>
        /// số nộp trả NSNN
        /// </summary>
        public decimal RepayAmount { get; set; }
        /// <summary>
        /// kinh phí chưa sử dụng
        /// </summary>
        public decimal UnusedAmount { get; set; }

        public string FontStyle { get; set; }
        public int Grade { get; set; }
        public int SortOrder { get; set; }
    }
}
