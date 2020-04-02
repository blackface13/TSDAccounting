using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    public class ReportB01CII01Entity
    {
        public List<ReportB01CII01ExchangeRateEntity> ExchangeRate { get; set; }
        public List<ReportB01CII01ReportEntity> UncontrolledSource { get; set; }
        public List<ReportB01CII01ReportEntity> SourceAutonomy { get; set; }
    }
    public class ReportB01CII01ExchangeRateEntity
    {
        public decimal ExchangeRateLastYear { get; set; }
        public decimal ExchangeRateThisYear { get; set; }
    }

    public class ReportB01CII01ReportEntity
    {
        public int OrderNumber { get; set; }
        public int Grade { get; set; }
        public string FontStyle { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetItemName { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string BudgetSubItemName { get; set; }
        public decimal Column1 { get; set; }
        public decimal Column2 { get; set; }
        public decimal Column3 { get; set; }
        public decimal Column4 { get; set; }
        public decimal Column5 { get; set; }
        public decimal Column6 { get; set; }
        public decimal Column7 { get; set; }
        public decimal Column8 { get; set; }
        public decimal Column9 { get; set; }
        public decimal Column10 { get; set; }
        public decimal Column11 { get; set; }
        public decimal Column12 { get; set; }
        public decimal Column13 { get; set; }
    }
}
