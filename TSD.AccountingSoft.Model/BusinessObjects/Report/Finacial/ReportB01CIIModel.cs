using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportB01CIIModel
    {
        public int SortOrder { get; set; }
        public int Grade { get; set; }
        public string FontStyle { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetItemName { get; set; }
        // tổng cộng
        public decimal Column1 { get; set; }
        public decimal Column2 { get; set; }
        public decimal Column3 { get; set; }
        public decimal Column4 { get; set; }
        // tự chủ
        public decimal Column5 { get; set; }
        public decimal Column6 { get; set; }
        public decimal Column7 { get; set; }
        public decimal Column8 { get; set; }
        // nguồn 13
        public decimal Column9 { get; set; }
        public decimal Column10 { get; set; }
        public decimal Column11 { get; set; }
        public decimal Column12 { get; set; }
        // nguồn 15.1
        public decimal Column13 { get; set; }
        public decimal Column14 { get; set; }
        public decimal Column15 { get; set; }
        public decimal Column16 { get; set; }

        // không tự chủ
        public decimal Column17 { get; set; }
        public decimal Column18 { get; set; }
        public decimal Column19 { get; set; }
        public decimal Column20 { get; set; }
        // nguồn 12
        public decimal Column21 { get; set; }
        public decimal Column22 { get; set; }
        public decimal Column23 { get; set; }
        public decimal Column24 { get; set; }
        // nguồn 15.2
        public decimal Column25 { get; set; }
        public decimal Column26 { get; set; }
        public decimal Column27 { get; set; }
        public decimal Column28 { get; set; }
        // tỷ giá năm trước
        public decimal ExchangeRateLastYear { get; set; }
        // tỷ giá năm nay
        public decimal ExchangeRateThisYear { get; set; }
    }
}
