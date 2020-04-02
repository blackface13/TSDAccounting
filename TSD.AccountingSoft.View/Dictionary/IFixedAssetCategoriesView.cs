/***********************************************************************
 * <copyright file="IFixedAssetCategoryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
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
    /// FixedAssetCategory view interface
    /// </summary>
    public interface IFixedAssetCategoriesView : IView
    {
        /// <summary>
        /// Sets the fixed asset categories.
        /// </summary>
        /// <value>The fixed asset categories.</value>
        IList<FixedAssetCategoryModel> FixedAssetCategories { set; }
    }
}
