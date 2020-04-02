/***********************************************************************
 * <copyright file="ICurrenciesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
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
    /// Interface ICurrenciesView
    /// </summary>
    public interface ICurrenciesView : IView 
    {
        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        IList<CurrencyModel> Currencies { set; } 
    }
}
