/***********************************************************************
 * <copyright file="OpeningAccountEntryDetailResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
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
    /// OpeningAccountEntryDetailResponse
    /// </summary>
    public class OpeningAccountEntryDetailResponse : ResponseBase
    {
        /// <summary>
        /// The opening account entry details
        /// </summary>
        public IList<OpeningAccountEntryDetailEntity> OpeningAccountEntryDetails;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
