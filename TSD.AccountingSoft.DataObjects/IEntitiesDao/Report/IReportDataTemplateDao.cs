using TSD.AccountingSoft.BusinessEntities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Report
{
    public interface IReportDataTemplateDao
    {
        ReportDataTemplateEntity GetReportDataTemplateByCode(string dataTemplateCode);
        long ReportDataTemplate_InsertOrUpdate(ReportDataTemplateEntity reportDataTemplate);
    }
}
