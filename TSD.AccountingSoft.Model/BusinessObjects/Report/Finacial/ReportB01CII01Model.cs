using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportB01CII01Model
    {
        public List<ReportB01CII01ExchangeRateModel> ExchangeRate { get; set; }
        public List<ReportB01CII01ReportModel> UncontrolledSource { get; set; }
        public List<ReportB01CII01ReportModel> SourceAutonomy { get; set; }
    }
    public class ReportB01CII01ExchangeRateModel
    {
        public decimal ExchangeRateLastYear { get; set; }
        public decimal ExchangeRateThisYear { get; set; }
    }

    public class ReportB01CII01ReportModel
    {
        public int     OrderNumber       { get; set; }
        public int     Grade             { get; set; }
        public string  FontStyle         { get; set; }
        public string  BudgetItemCode    { get; set; }
        public string  BudgetItemName    { get; set; }
        public string  BudgetSubItemCode { get; set; }
        public string  BudgetSubItemName { get; set; }
        public decimal Column1           { get; set; }
        public decimal Column2           { get; set; }
        public decimal Column3           { get; set; }
        public decimal Column4           { get; set; }
        public decimal Column5           { get; set; }
        public decimal Column6           { get; set; }
        public decimal Column7           { get; set; }
        public decimal Column8           { get; set; }
        public decimal Column9           { get; set; }
        public decimal Column10           { get; set; }
        public decimal Column11           { get; set; }
        public decimal Column12           { get; set; }
        public decimal Column13           { get; set; }
    }
}
