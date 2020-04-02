/***********************************************************************
 * <copyright file="IDepositDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit
{
    /// <summary>
    /// IDepositDetailDao
    /// </summary>
    public interface IDepositDetailDao
    {
        /// <summary>
        /// Gets the deposit details by deposit.
        /// </summary>
        /// <param name="refId">The deposit identifier.</param>
        /// <returns></returns>
        List<DepositDetailEntity> GetDepositDetailsByDeposit(long refId);

        /// <summary>
        /// Inserts the deposit detail.
        /// </summary>
        /// <param name="depositDetail">The deposit detail.</param>
        /// <returns></returns>
        int InsertDepositDetail(DepositDetailEntity depositDetail);

        /// <summary>
        /// Deletes the deposit detail by deposit identifier.
        /// </summary>
        /// <param name="refId">The deposit identifier.</param>
        /// <returns></returns>
        string DeleteDepositDetailByDepositId(long refId);
    }
}
