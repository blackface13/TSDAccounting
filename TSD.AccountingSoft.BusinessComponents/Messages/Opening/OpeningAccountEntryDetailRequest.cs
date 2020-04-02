/***********************************************************************
 * <copyright file="OpeningAccountEntryDetailRequesst.cs" company="BUCA JSC">
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
    /// OpeningAccountEntryDetailRequesst
    /// </summary>
    public class OpeningAccountEntryDetailRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the opening account entry details.
        /// </summary>
        /// <value>
        /// The opening account entry details.
        /// </value>
        public IList<OpeningAccountEntryDetailEntity> OpeningAccountEntryDetails { get; set; }
    }
}
