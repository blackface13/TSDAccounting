/***********************************************************************
 * <copyright file="IAccountingObjectsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
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
    /// IAccountingObjectsView interface
    /// </summary>
    public interface IAccountingObjectsView:IView
    {
        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>
        /// The accounting objects.
        /// </value>
        IList<AccountingObjectModel> AccountingObjects { set; }
    }
}
