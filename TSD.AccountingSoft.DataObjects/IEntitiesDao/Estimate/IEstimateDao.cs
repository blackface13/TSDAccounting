/***********************************************************************
 * <copyright file="IEstimateDao.cs" company="BUCA JSC">
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
    /// IEstimateDao
    /// </summary>
    public interface IEstimateDao
    {
        /// <summary>
        /// Gets the estimate.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        EstimateEntity GetEstimate(long refId);

        /// <summary>
        /// LinhMC
        /// Checks the constraint plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns></returns>
        EstimateEntity CheckConstraintPlanTemplateList(int planTemplateListId);

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<EstimateEntity> GetEstimatesByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the estimates.
        /// </summary>
        /// <returns></returns>
        List<EstimateEntity> GetEstimates();

        /// <summary>
        /// Gets the estimates by year of planing.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of planing.</param>
        /// <returns></returns>
        List<EstimateEntity> GetEstimatesByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        /// Gets the estimates by year of planing.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfPlaning">The year of planing.</param>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <returns></returns>
        List<EstimateEntity> GetEstimatesByYearOfPlaning(int refTypeId, short yearOfPlaning, int budgetSourceCategoryId);

        /// <summary>
        /// Gets the estimates by year of planing.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfPlaning">The year of planing.</param>
        /// <returns></returns>
        List<EstimateEntity> GetEstimatesByYearOfPlaning(int refTypeId, short yearOfPlaning);

        /// <summary>
        /// Inserts the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        int InsertEstimate(EstimateEntity estimate);

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        string UpdateEstimate(EstimateEntity estimate);

        /// <summary>
        /// Deletes the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        string DeleteEstimate(EstimateEntity estimate);
    }
}