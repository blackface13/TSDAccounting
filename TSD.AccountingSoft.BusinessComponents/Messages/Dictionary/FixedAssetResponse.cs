/***********************************************************************
 * <copyright file="FixedAssetResponse.cs" company="BUCA JSC">
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
    /// class FixedAssetResponse 
    /// </summary>
    public class FixedAssetResponse : ResponseBase
    {
        /// <summary>
        /// The fixed assets
        /// </summary>
        public IList<FixedAssetEntity> FixedAssets;

        /// <summary>
        /// The fixed asset
        /// </summary>
        public FixedAssetEntity FixedAsset;

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }
    }
}
