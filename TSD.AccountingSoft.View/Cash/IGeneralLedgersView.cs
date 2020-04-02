/***********************************************************************
 * <copyright file="IGeneralLedgersView.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Cash;


namespace TSD.AccountingSoft.View.Cash
{
    /// <summary>
    /// interface IGeneralLedgersView
    /// </summary>
    public interface IGeneralLedgersView : IView
    {
        /// <summary>
        /// Sets the general ledgers.
        /// </summary>
        /// <value>
        /// The general ledgers.
        /// </value>
        IList<GeneralLedgerModel> GeneralLedgers { set; }
    }
}
