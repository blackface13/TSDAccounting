/***********************************************************************
 * <copyright file="FixedAssetCategoryResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// class FixedAssetCategoryResponse
    /// </summary>
    public class FixedAssetCategoryResponse : ResponseBase
    {
        /// <summary>
        /// The fixed asset categorys
        /// </summary>
        public IList<FixedAssetCategoryEntity> FixedAssetCategories;

        /// <summary>
        /// The fixed asset category
        /// </summary>
        public FixedAssetCategoryEntity FixedAssetCategory;

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        public int FixedAssetCategoryId { get; set; }
    }
}
