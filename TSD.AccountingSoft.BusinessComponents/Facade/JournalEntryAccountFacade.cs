/***********************************************************************
 * <copyright file="JournalEntryAccountFacade.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessComponents.Messages;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;


namespace TSD.AccountingSoft.BusinessComponents.Facade
{
    /// <summary>
    /// class JournalEntryAccountFacade
    /// </summary>
    public class JournalEntryAccountFacade
    {
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;

        public JournalEntryAccountResponse GetJournalEntryAccounts(JournalEntryAccountRequest request)
        {
            var response = new JournalEntryAccountResponse();

            response.JournalEntryAccounts = JournalEntryAccountDao.GetJournalEntryAccounts(request.ExportType, request.FromDate, request.ToDate);
            
            return response;
        }
    }
}
