/***********************************************************************
 * <copyright file="OpeningAccountEntryResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Opening
{
    /// <summary>
    /// OpeningAccountEntryResponse
    /// </summary>
    public class OpeningAccountEntryResponse : ResponseBase
    {
        /// <summary>
        /// The opening account entries
        /// </summary>
        public IList<OpeningAccountEntryEntity> OpeningAccountEntries;

        /// <summary>
        /// The opening account entry
        /// </summary>
        public OpeningAccountEntryEntity OpeningAccountEntry;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}