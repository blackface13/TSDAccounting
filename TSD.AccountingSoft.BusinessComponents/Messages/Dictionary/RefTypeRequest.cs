/***********************************************************************
 * <copyright file="RefTypeRequest.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// RefTypeRequest
    /// </summary>
    public class RefTypeRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the refType identifier.
        /// </summary>
        /// <value>
        /// The refType identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// The refType
        /// </summary>
        public RefTypeEntity RefType;
    }
}
