/***********************************************************************
 * <copyright file="CalculateClosingRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, December 23, 2014
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
    ///     CalculateClosingRequest
    /// </summary>
    public class CalculateClosingRequest : RequestBase
    {
        /// <summary>
        ///     The automatic number
        /// </summary>
        public CalculateClosingEntity calculateClosing;

        /// <summary>
        ///     The automatic numbers
        /// </summary>
        public IList<CalculateClosingEntity> calculateClosings;

        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        public string PaymentAccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the payment account code.
        /// </summary>
        /// <value>
        ///     The payment account code.
        /// </value>
        public string CreditAccount { get; set; }

        /// <summary>
        ///     Gets or sets the where clause.
        /// </summary>
        /// <value>
        ///     The where clause.
        /// </value>
        public string WhereClause { get; set; }

        /// <summary>
        ///     Gets or sets the currency code.
        /// </summary>
        /// <value>
        ///     The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        ///     Gets or sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        public string ToDate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [is approximate].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is approximate]; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproximate { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }
    }
}