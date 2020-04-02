/***********************************************************************
 * <copyright file="FAIncrementResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;


namespace TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset
{
    /// <summary>
    /// FAIncrementResponse
    /// </summary>
    public class FAIncrementResponse : ResponseBase
    {
        /// <summary>
        /// The fAIncrements
        /// </summary>
        public IList<FAIncrementEntity> FAIncrements;

        /// <summary>
        /// The fAIncrement
        /// </summary>
        public FAIncrementEntity FAIncrement;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
