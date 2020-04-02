using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    public class B01BCQTEntity
    {
        public int OrderNumber { get; set; }
        public string NumberCode { get; set; }
        public string TargetName { get; set; }
        public string Code { get; set; }
        public decimal Amount01 { get; set; }
        public decimal Amount02 { get; set; }
        public decimal Amount03 { get; set; }
        public decimal Amount04 { get; set; }
        public decimal Amount05 { get; set; }
        public decimal Amount06 { get; set; }
        public decimal Amount07 { get; set; }
        public int Grade { get; set; }
        public string FontStyle { get; set; }
    }
}
