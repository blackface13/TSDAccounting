using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class S05HModel
    {
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public Decimal OpeningDebit { get; set; }
        public Decimal OpeningCredit { get; set; }
        public Decimal AdjustmentDebitBeginningYear { get; set; }
        public Decimal AdjustmentCreditBeginningYear { get; set; }
        public Decimal MovementDebit { get; set; }
        public Decimal MovementCredit { get; set; }
        public Decimal MovementAccumDebit { get; set; }
        public Decimal MovementAccumCredit { get; set; }
        public Decimal ClosingDebit { get; set; }
        public Decimal ClosingCredit { get; set; }
        public string FontStyle { get; set; }
        public bool IsDetail { get; set; }
        public int Grade { get; set; }
    }

    public class S05HGroupModel
    {
        public List<S05HModel> GroupA { get; set; }
        public List<S05HModel> GroupB { get; set; }
    }
}
