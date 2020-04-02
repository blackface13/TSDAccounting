/***********************************************************************
 * <copyright file="IEstimateDetailStatementPartBDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 23 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate
{
    public interface IEstimateDetailStatementPartBDao
    {
        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        List<EstimateDetailStatementPartBEntity> GetEstimateDetailStatementPartBs();

        /// <summary>
        /// Inserts the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        int InsertEstimateDetailStatementPartB(EstimateDetailStatementPartBEntity estimateDetailStatement);

        /// <summary>
        /// Updates the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        string UpdateEstimateDetailStatementPartB(EstimateDetailStatementPartBEntity estimateDetailStatement);

        /// <summary>
        /// Deletes the estimateDetailStatement.
        /// </summary>
        /// <returns></returns>
        string DeleteEstimateDetailStatementPartB();
    }
}
