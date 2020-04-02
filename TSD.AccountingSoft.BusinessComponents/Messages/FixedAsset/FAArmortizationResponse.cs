/***********************************************************************
 * <copyright file="FAArmortizationResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
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
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;


namespace TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset
{
    /// <summary>
    /// FAArmortizationResponse
    /// </summary>
    public class FAArmortizationResponse : ResponseBase
    {
        /// <summary>
        /// The fAArmortizations
        /// </summary>
        public IList<FAArmortizationEntity> FAArmortizations;

        /// <summary>
        /// The fAArmortizations
        /// </summary>
        public IList<FAArmortizationDetailEntity> FADecrementDetails;

        /// <summary>
        /// The fAArmortization
        /// </summary>
        public FAArmortizationEntity FAArmortization;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
