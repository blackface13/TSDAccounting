/***********************************************************************
 * <copyright file="IFixedAssetIncrementsView.cs" company="BUCA JSC">
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
    /// interface IFixedAssetIncrementsView
    /// </summary>
    public interface IFixedAssetIncrementsView : IView
    {
        /// <summary>
        /// Sets the fixed asset increment.
        /// </summary>
        /// <value>
        /// The fixed asset increment.
        /// </value>
        IList<FixedAssetIncrementModel> FixedAssetIncrements { set; }

        IList<FixedAssetIncrementDetailModel> FixedAssetIncrementDetails { set; }
    }
}
