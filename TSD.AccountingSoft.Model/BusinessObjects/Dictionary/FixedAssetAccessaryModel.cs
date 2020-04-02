using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class FixedAssetAccessaryModel
    {
        public int FixedAssetAccessaryId { get; set; }

        public int FixedAssetId { get; set; }

        public string FixedAssetAccessaryName { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string CurrencyCode { get; set; }
        
        public decimal ExchangeRate { get; set; }

        public decimal AmountOc { get; set; }

        public decimal AmountEx { get; set; }
    }
}
