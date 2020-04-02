/***********************************************************************
 * <copyright file="IAutoBusinesssView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
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
    /// IAutoBusinessesView
    /// </summary>
    public interface IAutoBusinessesView : IView
    {
        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <value>
        /// The automatic businesses.
        /// </value>
        IList<AutoBusinessModel> AutoBusinesses { set; }
    }
}