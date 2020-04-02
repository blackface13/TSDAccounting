/***********************************************************************
 * <copyright file="AccountResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
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
    /// Class AccountResponse.
    /// </summary>
    public class AccountResponse : ResponseBase
    {
        /// <summary>
        /// The accounts
        /// </summary>
        public IList<AccountEntity> Accounts;

        /// <summary>
        /// The account
        /// </summary>
        public AccountEntity Account;

        /// <summary>
        /// The account identifier
        /// </summary>
        public int AccountId;
    }
}
