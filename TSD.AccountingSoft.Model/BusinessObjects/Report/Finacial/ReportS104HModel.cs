using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportS104HModel
    {
        public int OrderNumber { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string Description { get; set; }

        public decimal Amount01 { get; set; }
        public decimal Amount02 { get; set; }
        public decimal Amount03 { get; set; }
        public decimal Amount04 { get; set; }

        public decimal Amount05 { get; set; }
        public decimal Amount06 { get; set; }
        public decimal Amount07 { get; set; }

    }
}
