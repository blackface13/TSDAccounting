/***********************************************************************
 * <copyright file="IAccountTranfersView.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IAccountTranfersView
    /// </summary>
    public interface IAccountTranfersView : IView
    {
        /// <summary>
        /// Sets the account tranfers.
        /// </summary>
        /// <value>
        /// The account tranfers.
        /// </value>
        IList<AccountTranferModel> AccountTranfers { set; }
    }
}
