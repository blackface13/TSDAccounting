using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    public class ReportB04BCTCEntity
    {
        public List<ReportB04BCTCDetail01Entity> Table01 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table02 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table03 { get; set; }
        public List<ReportB04BCTCDetail02Entity> Table04 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table05 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table06 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table07 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table08 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table09 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table10 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table11 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table12 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table13 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table14 { get; set; }
        public List<ReportB04BCTCDetail03Entity> Table15 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table16 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table17 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table18 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table19 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table20 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table21 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table22 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table23 { get; set; }
        public List<ReportB04BCTCDetail01Entity> Table24 { get; set; }
    }
    public class ReportB04BCTCDetail01Entity
    {
        public string Content { get; set; }
        public decimal BeginAmount { get; set; }
        public decimal EndAmount { get; set; }
    }

    public class ReportB04BCTCDetail02Entity
    {
        public string Content { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TangibleFixedAssets { get; set; }
        public decimal IntangibleFixedAssets { get; set; }
    }

    public class ReportB04BCTCDetail03Entity
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
