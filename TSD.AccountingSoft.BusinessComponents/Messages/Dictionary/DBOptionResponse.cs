/***********************************************************************
 * <copyright file="DBOptionResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// DBOptionResponse
    /// </summary>
    public class DBOptionResponse : ResponseBase
    {
        /// <summary>
        /// The database options
        /// </summary>
        public IList<DBOptionEntity> DBOptions;

        /// <summary>
        /// The database option
        /// </summary>
        public DBOptionEntity DBOption;

        /// <summary>
        /// Gets or sets the database option identifier.
        /// </summary>
        /// <value>
        /// The database option identifier.
        /// </value>
        public int DBOptionId { get; set; }
    }
}
