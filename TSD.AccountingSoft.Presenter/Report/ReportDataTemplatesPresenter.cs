using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.View.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Report
{
    public class ReportDataTemplatesPresenter : Presenter<IReportDataTemplatesView>
    {
        public ReportDataTemplatesPresenter(IReportDataTemplatesView view) : base(view) { }

        public long Save(IList<ReportDataTemplateModel> reportDataTemplates)
        {
            long index = 0;
            foreach (var item in reportDataTemplates)
            {
                index = Model.InsertOrUpdateReportDataTemplate(item);
            }
            return index;
        }

        public void Display(List<string> dataTemplateCode)
        {
            var reportDataTemplates = new List<ReportDataTemplateModel>();
            foreach (var item in dataTemplateCode)
            {
                var reportDataTemplate = Model.GetReportDataTemplate(item);
                if (reportDataTemplate != null)
                    reportDataTemplates.Add(reportDataTemplate);
            }

            View.ReportDataTemplates = reportDataTemplates;
        }
    }
}
