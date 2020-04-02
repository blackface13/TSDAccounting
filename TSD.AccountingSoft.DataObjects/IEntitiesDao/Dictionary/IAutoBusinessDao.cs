/***********************************************************************
 * <copyright file="IAutoBusinessDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAutoBusinessDao
    {
        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        AutoBusinessEntity GetAutoBusiness(int autoBusinessId);

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinesss();

        /// <summary>
        /// Gets the autoBusinesss by autoBusiness account.
        /// </summary>
        /// <param name="autoBusinessAccount">The autoBusiness account.</param>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinesssByAutoBusinessAccount(string autoBusinessAccount);

        /// <summary>
        /// Gets the autoBusinesss by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinesssByActive(bool isActive);

        /// <summary>
        /// Gets the automatic business.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinessByRefType(int refTypeId, bool isActive);

        /// <summary>
        /// Inserts the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        int InsertAutoBusiness(AutoBusinessEntity autoBusiness);

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        string UpdateAutoBusiness(AutoBusinessEntity autoBusiness);

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        string DeleteAutoBusiness(AutoBusinessEntity autoBusiness);
    }
}
