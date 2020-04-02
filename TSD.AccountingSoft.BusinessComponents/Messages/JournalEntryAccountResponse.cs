/***********************************************************************
 * <copyright file="JournalEntryAccountResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;


namespace TSD.AccountingSoft.BusinessComponents.Messages
{
    /// <summary>
    /// JournalEntryAccountResponse
    /// </summary>
    public class JournalEntryAccountResponse : ResponseBase
    {
        /// <summary>
        /// The journal entry accounts
        /// </summary>
        public IList<JournalEntryAccountEntity> JournalEntryAccounts;

        /// <summary>
        /// The journal entry account
        /// </summary>
        public JournalEntryAccountEntity JournalEntryAccount;

        /// <summary>
        /// The journal entry identifier
        /// </summary>
        public long JournalEntryId;
    }
}
