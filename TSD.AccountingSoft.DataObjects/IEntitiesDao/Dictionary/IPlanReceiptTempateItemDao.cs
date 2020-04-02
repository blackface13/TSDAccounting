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
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// interface IBudgetItemDao
    /// </summary>
    public interface IPlanReceiptTempateItemDao
    {
        /// <summary>
        /// Gets the plan receipt tempate item.
        /// </summary>
        /// <returns></returns>
       IList<PlanReceiptTempateItemEntity> GetPlanReceiptTempateItems();

       /// <summary>
       /// Gets the plan receipt tempate item.
       /// </summary>
       /// <param name="planReceiptTempateItemId">The budget item identifier.</param>
       /// <returns></returns>
       PlanReceiptTempateItemEntity GetPlanReceiptTempateItem(int planReceiptTempateItemId);
       
    }

}
