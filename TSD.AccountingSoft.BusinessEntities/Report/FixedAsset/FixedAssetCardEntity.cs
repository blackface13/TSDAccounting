using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    public class FixedAssetCardEntity : BusinessEntities
    {
        public int FixedAssetId { get; set; }

        public string OrderNumber { get; set; }

        public string FixedAssetName { get; set; }

        public string FixedAssetCode { get; set; }

        public int ProductionYear { get; set; }

        public string MadeIn { get; set; }

        public DateTime UsedDate { get; set; }

        public DateTime PurchasedDate { get; set; }

        public decimal OrgPrice { get; set; }

        public decimal OrgPriceUsd { get; set; }

        public decimal TotalOrgPriceUsd { get; set; }

        public string DepartmentName { get; set; }

        public string EmployeeName { get; set; }

    }
}
