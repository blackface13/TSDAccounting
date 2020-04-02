/***********************************************************************
 * <copyright file="FADecrementRequest.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;


namespace TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset
{
    /// <summary>
    /// class FADecrementRequest
    /// </summary>
    public class FADecrementRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// The fa decrements
        /// </summary>
        public IList<FADecrementEntity> FADecrements;

        /// <summary>
        /// The bank
        /// </summary>
        public FADecrementEntity FADecrement;

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public string RefDate { get; set; }
    }
}
