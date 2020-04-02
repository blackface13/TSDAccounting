/***********************************************************************
 * <copyright file="IAutoNumbersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 May 2014
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
    /// IAutoNumbersView
    /// </summary>
    public interface IAutoNumbersView : IView
    {
        /// <summary>
        /// Gets or sets the automatic numbers.
        /// </summary>
        /// <value>
        /// The automatic numbers.
        /// </value>
        IList<AutoNumberModel> AutoNumbers { get; set; }
    }
}
