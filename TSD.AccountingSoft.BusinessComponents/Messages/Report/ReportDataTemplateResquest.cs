using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    public class ReportDataTemplateResquest: RequestBase
    {
        public long Index { get; set; }
        public ReportDataTemplateEntity ReportDataTemplate { get; set; }
    }
}
