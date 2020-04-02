using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportB03bBCTCModel
    {
        public string Index { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Present { get; set; }
        public decimal ThisYearAmount { get; set; }
        public decimal LastYearAmount { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public int SortOrder { get; set; }
    }
}
