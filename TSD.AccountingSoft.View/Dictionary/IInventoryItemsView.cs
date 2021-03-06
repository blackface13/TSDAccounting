﻿/***********************************************************************
 * <copyright file="IInventoryItemsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemsView
    /// </summary>
    public interface IInventoryItemsView : IView
    {
        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value>
        IList<InventoryItemModel> InventoryItems { set; }
    }
}
