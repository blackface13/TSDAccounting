/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Tuesday, June 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  13/06/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// PlanReceiptTempateItemResponse
    /// </summary>
    public class PlanReceiptTempateItemResponse : ResponseBase
    {
        /// <summary>
        /// The plan receipt tempate items
        /// </summary>
        public IList<PlanReceiptTempateItemEntity> PlanReceiptTempateItems;

        /// <summary>
        /// The plan receipt tempate item
        /// </summary>
        public PlanReceiptTempateItemEntity PlanReceiptTempateItem;
    }
}
