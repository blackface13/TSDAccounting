/***********************************************************************
 * <copyright file="AccountRequest.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class AccountRequest.
    /// </summary>
    public class AccountRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public string AccountCode { get; set; } 

        /// <summary>
        /// The account
        /// </summary>
        public AccountEntity Account;

        /// <summary>
        /// Gets or sets the is detail.
        /// </summary>
        /// <value>
        /// The is detail.
        /// </value>
        public bool IsDetail { get; set; } 
    }
}
