using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Business.General
{
    public class EstimateExchangeRateEntity : BusinessEntities
    {
        public decimal ExchangeRateThisYear { get; set; }
        public decimal ExchangeRateLastYear { get; set; }
    }
}
