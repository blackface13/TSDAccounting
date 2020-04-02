/***********************************************************************
 * <copyright file="IItemTransactionsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;


namespace TSD.AccountingSoft.View.Inventory
{
    /// <summary>
    /// interface IItemTransactionsView  
    /// </summary>
    public interface IItemTransactionsView   
    {
        /// <summary>
        /// Sets the ItemTransaction vouchers.
        /// </summary>
        /// <value>
        /// The ItemTransaction vouchers.
        /// </value>
        IList<ItemTransactionModel> ItemTransactions { set; }

        IList<ItemTransactionDetailModel> ItemTransactionDetails { set; } 
    }
}
