using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Business.Tool
{
    public class SUIncrementDecrementEntity : BusinessEntities
    {
        public SUIncrementDecrementEntity()
        {
            SUIncrementDecrementDetails = new List<SUIncrementDecrementDetailEntity>();
        }

        public long RefId { get; set; }

        public int RefType { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }

        public string RefNo { get; set; }

        public string JournalMemo { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal TotalAmountOc { get; set; }

        public decimal TotalAmountExchange { get; set; }

        public IList<SUIncrementDecrementDetailEntity> SUIncrementDecrementDetails { get; set; }
    }
}
