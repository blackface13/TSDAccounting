using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Tool
{
    public interface ISUIncrementDecrementView : IView
    {
        long RefId { get; set; }

        int RefType { get; set; }

        DateTime RefDate { get; set; }

        DateTime PostedDate { get; set; }

        string RefNo { get; set; }

        string JournalMemo { get; set; }

        string CurrencyCode { get; set; }

        decimal ExchangeRate { get; set; }

        decimal TotalAmountOc { get; set; }

        decimal TotalAmountExchange { get; set; }

        IList<SUIncrementDecrementDetailModel> SUIncrementDecrementDetails { get; set; }
    }
}
