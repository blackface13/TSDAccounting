/***********************************************************************
 * <copyright file="IItemTransactionDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanMH
 * Email:    TuanMH@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory
{
    public interface IItemTransactionDetailDao
    {
        /// <summary>
        /// Gets the item transaction details for cal output inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<ItemTransactionDetailEntity> GetItemTransactionDetailsForCalOutputInventory(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode);

        /// <summary>
        /// Gets the item transaction details by item transaction.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<ItemTransactionDetailEntity> GetItemTransactionDetailsByItemTransaction(long refId);

        /// <summary>
        /// Inserts the item transaction detail.
        /// </summary>
        /// <param name="itemTransactionDetail">The item transaction detail.</param>
        /// <returns></returns>
        int InsertItemTransactionDetail(ItemTransactionDetailEntity itemTransactionDetail);

        /// <summary>
        /// Deletes the item transaction detail by item transaction identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteItemTransactionDetailByItemTransactionId(long refId);
    }
}
