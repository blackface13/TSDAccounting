/***********************************************************************
 * <copyright file="IPayItemDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
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
    /// IPayItemDao
    /// </summary>
    public interface IPayItemDao
    {
        /// <summary>
        /// Gets the pay item.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <returns></returns>
        PayItemEntity GetPayItem(int payItemId);

        /// <summary>
        /// Gets the pay items.
        /// </summary>
        /// <returns></returns>
        List<PayItemEntity> GetPayItems();

        /// <summary>
        /// Gets the pay items is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<PayItemEntity> GetPayItemsIsActive(bool isActive);

        /// <summary>
        /// Gets the pay items by pay item code.
        /// </summary>
        /// <param name="payItemCode">The pay item code.</param>
        /// <returns></returns>
        List<PayItemEntity> GetPayItemsByPayItemCode(string payItemCode);

        /// <summary>
        /// Inserts the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns></returns>
        int InsertPayItem(PayItemEntity payItem);

        /// <summary>
        /// Updates the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns></returns>
        string UpdatePayItem(PayItemEntity payItem);

        /// <summary>
        /// Deletes the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns></returns>
        string DeletePayItem(PayItemEntity payItem);
    }
}
