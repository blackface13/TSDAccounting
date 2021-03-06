﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportActivityB02Model
    {
        public string OrderNumber { get; set; }
        public string ReportItemCode { get; set; }
        public string ReportItemName { get; set; }
        public string ReportItemAlias { get; set; }
        public decimal ThisYear { get; set; }
        public decimal LastYear { get; set; }
        public bool IsBold { get; set; }
        public int SortOrder { get; set; }
    }
}
