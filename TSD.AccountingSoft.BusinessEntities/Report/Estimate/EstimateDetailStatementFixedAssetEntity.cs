/***********************************************************************
 * <copyright file="EstimateDetailStatement.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 11 June 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.Report.Estimate
{
    public class EstimateDetailStatementFixedAssetEntity
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
