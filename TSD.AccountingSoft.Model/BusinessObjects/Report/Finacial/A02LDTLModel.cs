using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class A02LDTLModel
    {
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public int OrderNumber  { get; set; }

        public string EmployeeName { get; set; }

        public string JobCandidateName { get; set; }

        public decimal NumberSHP { get; set; }

        public decimal SHP { get; set; }

        public decimal PCVS { get; set; }

        public decimal PCKiemNhiem { get; set; }

        public decimal TroCapCT { get; set; }

        public decimal TongCong { get; set; }

        public decimal QuiDoi { get; set; }

        public decimal ExchangeRate { get; set; }

        public string CurrencyCode { get; set; }

        public DateTime CalcDate { get; set; }

        public decimal BaseOfSalary { get; set; }

        public int WorkDays { get; set; } // số ngày hưởng lương
    }
}
