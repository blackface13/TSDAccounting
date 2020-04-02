using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportB04BCTCModel
    {
        public List<ReportB04BCTCDetail01Model> Table01 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table02 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table03 { get; set; }
        public List<ReportB04BCTCDetail02Model> Table04 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table05 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table06 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table07 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table08 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table09 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table10 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table11 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table12 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table13 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table14 { get; set; }
        public List<ReportB04BCTCDetail03Model> Table15 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table16 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table17 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table18 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table19 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table20 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table21 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table22 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table23 { get; set; }
        public List<ReportB04BCTCDetail01Model> Table24 { get; set; }
    }

    public class ReportB04BCTCDetail01Model
    {
        public string Content { get; set; }
        public decimal BeginAmount { get; set; }
        public decimal EndAmount { get; set; }
    }

    public class ReportB04BCTCDetail02Model
    {
        public string Content { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TangibleFixedAssets { get; set; }
        public decimal IntangibleFixedAssets { get; set; }
    }

    public class ReportB04BCTCDetail03Model
    {
        public string Content { get; set; }
        public decimal BusinessCapital { get; set; }
        public decimal ExchangeRateDifference { get; set; }
        public decimal AccumulatedSurplus { get; set; }
        public decimal Funds { get; set; }
        public decimal SourceWageReform { get; set; }
        public decimal Other { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
