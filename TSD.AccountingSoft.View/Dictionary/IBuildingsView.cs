/***********************************************************************
 * <copyright file="IBuildingsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
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
    /// IBuildingsView
    /// </summary>
    public interface IBuildingsView : IView
    {
        /// <summary>
        /// Sets the buildings.
        /// </summary>
        /// <value>
        /// The buildings.
        /// </value>
        IList<BuildingModel> Buildings { set; }
    }
}
