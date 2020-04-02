/***********************************************************************
 * <copyright file="IPayItemsView.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IPayItemsView
    /// </summary>
    public interface IPayItemsView : IView
    {
        /// <summary>
        /// Gets or sets the pay items.
        /// </summary>
        /// <value>
        /// The pay items.
        /// </value>
        IList<PayItemModel> PayItems { set; }
    }
}
