using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate
{
    public class EstimateDetailStatementFixedAssetModel
    {
        public int EstimateDetailStatementFixedAssetId { get; set; }

        public int OrderNumber { get; set; }

        public int PurchasedYear { get; set; }

        public decimal OrgPriceUsd { get; set; }

        public decimal PurchasedOrgPriceUsd { get; set; }

        public string Department { get; set; }

        public string ReplacementReason { get; set; }

        public int PostedYear { get; set; }

        public bool IsActive { get; set; }
    }
}
