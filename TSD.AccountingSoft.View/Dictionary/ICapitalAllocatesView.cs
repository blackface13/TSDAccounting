/***********************************************************************
 * <copyright file="ICapitalAllocatesView.cs" company="BUCA JSC">
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
    /// Interface ICapitalAllocatesView
    /// </summary>
    public interface ICapitalAllocatesView : IView  
    {
        /// <summary>
        /// Sets the capital allocates.
        /// </summary>
        /// <value>The capital allocates.</value>
        IList<CapitalAllocateModel> CapitalAllocates { set; }  
    }
}
