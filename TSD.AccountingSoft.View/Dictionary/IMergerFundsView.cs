/***********************************************************************
 * <copyright file="IMergerFundsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// Interface IMergerFundsView
    /// </summary>
    public interface IMergerFundsView : IView
    {
        /// <summary>
        /// Sets the merger funds.
        /// </summary>
        /// <value>The merger funds.</value>
        IList<MergerFundModel> MergerFunds { set; }
    }
}
