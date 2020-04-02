/***********************************************************************
 * <copyright file="RefTypeResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
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
    /// RefTypeResponse
    /// </summary>
    public class RefTypeResponse : ResponseBase
    {
        /// <summary>
        /// The refTypes
        /// </summary>
        public IList<RefTypeEntity> RefTypes;

        /// <summary>
        /// The refType
        /// </summary>
        public RefTypeEntity RefType;

        /// <summary>
        /// Gets or sets the refType identifier.
        /// </summary>
        /// <value>
        /// The refType identifier.
        /// </value>
        public int RefTypeId { get; set; }
    }
}
