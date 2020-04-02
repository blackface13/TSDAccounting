/***********************************************************************
 * <copyright file="EstimateDetailStatementRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Thursday, June 23, 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    thodd           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Estimate
{
    /// <summary>
    /// class EstimateDetailStatementFixedAssetRequest
    /// </summary>
    public class EstimateDetailStatementFixedAssetRequest : RequestBase
    {
        /// <summary>
        /// The estimate detail statement
        /// </summary>
        public IList<EstimateDetailStatementFixedAssetEntity> EstimateDetailStatementFixedAssets;

        /// <summary>
        /// The estimate detail statement part b identifier
        /// </summary>
        public int EstimateDetailStatementFixedAssetId;
    }
}
