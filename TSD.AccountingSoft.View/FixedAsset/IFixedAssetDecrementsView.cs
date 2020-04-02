/***********************************************************************
 * <copyright file="IFixedAssetDecrementsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;

namespace TSD.AccountingSoft.View.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetDecrementsView:IView
    /// </summary>
    public interface IFixedAssetDecrementsView:IView
    {
        /// <summary>
        /// Sets the fixed asset decrement.
        /// </summary>
        /// <value>
        /// The fixed asset decrement.
        /// </value>
        IList<FixedAssetDecrementModel> FixedAssetDecrements { set; }

        /// <summary>
        /// Sets the fixed asset decrement details.
        /// </summary>
        /// <value>
        /// The fixed asset decrement details.
        /// </value>
        IList<FixedAssetDecrementDetailModel> FixedAssetDecrementDetails { set; }
    }
}
