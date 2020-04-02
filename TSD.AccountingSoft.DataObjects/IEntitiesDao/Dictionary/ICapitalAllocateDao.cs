/***********************************************************************
 * <copyright file="ICapitalAllocateDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface ICapitalAllocateDao
    /// </summary>
    public interface ICapitalAllocateDao 
    {
        /// <summary>
        /// Gets the CapitalAllocates.
        /// </summary>
        /// <returns>List{CapitalAllocateEntity}.</returns>
        List<CapitalAllocateEntity> GetCapitalAllocatesByDate(DateTime fromDate,DateTime toDate);

        /// <summary>
        /// Gets the CapitalAllocates.
        /// </summary>
        /// <returns>List{CapitalAllocateEntity}.</returns>
        List<CapitalAllocateEntity> GetCapitalAllocatesByActive();

        /// <summary>
        /// Gets the CapitalAllocates by CapitalAllocateCode .
        /// </summary>
        /// <param name="capitalAllocateCode">The CapitalAllocateCode .</param>
        /// <returns></returns>
        List<CapitalAllocateEntity> GetCapitalAllocatesByCapitalAllocateCode(string capitalAllocateCode);  

        /// <summary>
        /// Gets the CapitalAllocates.
        /// </summary>
        /// <param name="capitalAllocateId">The budget source property identifier.</param>
        /// <returns>CapitalAllocateEntity.</returns>
        CapitalAllocateEntity GetCapitalAllocate(int capitalAllocateId);

        /// <summary>
        /// Gets the CapitalAllocates.
        /// </summary>
        /// <returns>List{CapitalAllocateEntity}.</returns>
        List<CapitalAllocateEntity> GetCapitalAllocates();

        /// <summary>
        /// Inserts the budget source property.
        /// </summary>
        /// <param name="capitalAllocate">The  capitalAllocate.</param>
        /// <returns>System.Int32.</returns>
        int InsertCapitalAllocate(CapitalAllocateEntity capitalAllocate);

        /// <summary>
        /// Updates the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capitalAllocate .</param>
        /// <returns>System.String.</returns>
        string UpdateCapitalAllocate(CapitalAllocateEntity capitalAllocate);

        /// <summary>
        /// Deletes the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capitalAllocate.</param>
        /// <returns>System.String.</returns>
        string DeleteCapitalAllocate(CapitalAllocateEntity capitalAllocate); 
    }
}
