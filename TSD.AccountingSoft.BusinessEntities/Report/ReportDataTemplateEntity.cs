using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report
{
    public class ReportDataTemplateEntity: BusinessEntities
    {
        public string DataTemplateCode { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
