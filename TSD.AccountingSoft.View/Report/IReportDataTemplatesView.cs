using TSD.AccountingSoft.Model.BusinessObjects.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Report
{
    public interface IReportDataTemplatesView
    {
        IList<ReportDataTemplateModel> ReportDataTemplates { get; set; }
    }
}
