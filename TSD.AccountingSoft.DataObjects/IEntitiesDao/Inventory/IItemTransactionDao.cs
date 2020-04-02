/***********************************************************************
 * <copyright file="IItemTransactionDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    TuanHM@buca.vn
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
    public interface IItemTransactionDao
    {
        List<ItemTransactionEntity> GetOutputItemTransactionsByDate(DateTime fromDate, DateTime toDate);

        List<ItemTransactionEntity> GetOutputItemTransactionsByArisePeriod(DateTime fromDate, DateTime toDate,List<int> stockId, string currencyCode ); 

        List<ItemTransactionEntity> GetItemTransactionsByDate(DateTime fromDate, DateTime toDate);

        ItemTransactionEntity GetItemTransaction(long refId);

        ItemTransactionEntity GetItemTransactionByRefdateAndReftype(ItemTransactionEntity itemTransaction);
        
        List<ItemTransactionEntity> GetItemTransactionsForCalOutputInventory(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode);

        List<ItemTransactionEntity> GetItemTransactionsByRefTypeId(int refTypeId);

        List<ItemTransactionEntity> GetItemTransactions();

        int InsertItemTransaction(ItemTransactionEntity itemTransaction);

        string UpdateItemTransaction(ItemTransactionEntity itemTransaction);

        string DeleteItemTransaction(ItemTransactionEntity itemTransaction);

        ItemTransactionEntity GetItemTransactionByRefNo(string refNo);

        decimal GetQuantityOfInventory(int inventoryItemId, int stockId, DateTime postDate, long refID, string currencyCode);
    }
}
