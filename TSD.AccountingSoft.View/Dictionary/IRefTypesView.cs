/***********************************************************************
 * <copyright file="IRefTypesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
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
    /// IRefTypesView
    /// </summary>
    public interface IRefTypesView : IView
    {
        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        IList<RefTypeModel> RefTypes { set; }
    }
}
