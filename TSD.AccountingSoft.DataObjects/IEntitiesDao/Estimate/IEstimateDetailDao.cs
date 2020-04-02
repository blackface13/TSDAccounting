/***********************************************************************
 * <copyright file="IEstimateDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Business.Estimate;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    /// IEstimateDetailDao
    /// </summary>
    public interface IEstimateDetailDao
    {
        /// <summary>
        /// Gets the estimate details by estimate.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<EstimateDetailEntity> GetEstimateDetailsByEstimate(long refId);

        /// <summary>
        /// Gets the estimate details by estimate include budget item name.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<EstimateDetailEntity> GetEstimateDetailsByEstimateIncludeBudgetItemName(long refId);

        List<EstimateDetailEntity> GetEstimateDetailsByEstimateOption(long refId, int option, int budgetSourceCategoryId, int yearOfPlaning);

        List<EstimateDetailEntity> GetEstimateDetailsByEstimateOption(int planTemplateListId);

        /// <summary>
        /// Inserts the estimate detail.
        /// </summary>
        /// <param name="estimateDetail">The estimate detail.</param>
        /// <returns></returns>
        int InsertEstimateDetail(EstimateDetailEntity estimateDetail);

        /// <summary>
        /// LINHMC
        /// Updates the estimate detail.
        /// </summary>
        /// <param name="estimateDetail">The estimate detail.</param>
        /// <returns></returns>
        string UpdateEstimateDetail(EstimateDetailEntity estimateDetail);
        
        /// <summary>
        /// Deletes the estimate detail by estimate identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteEstimateDetailByRefId(long refId);
    }
}
