/***********************************************************************
 * <copyright file="CommonRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, May 30, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;

namespace TSD.AccountingSoft.BusinessComponents.Messages
{
    /// <summary>
    /// Common Request
    /// </summary>
    public class CommonRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        /// <value>
        /// The query string.
        /// </value>
        public string QueryString { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the identifier field.
        /// </summary>
        /// <value>
        /// The name of the identifier field.
        /// </value>
        public string IdFieldName { get; set; }

        /// <summary>
        /// Gets or sets the name of the code field.
        /// </summary>
        /// <value>
        /// The name of the code field.
        /// </value>
        public string CodeFieldName { get; set; }

        /// <summary>
        /// Gets or sets the code field value.
        /// </summary>
        /// <value>
        /// The code field value.
        /// </value>
        public string CodeFieldValue { get; set; }

        /// <summary>
        /// Gets or sets the start increment number.
        /// </summary>
        /// <value>
        /// The start increment number.
        /// </value>
        public int StartIncrementNumber { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal digits.
        /// </summary>
        /// <value>
        /// The currency decimal digits.
        /// </value>
        public short CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate { get; set; }

    }
}
