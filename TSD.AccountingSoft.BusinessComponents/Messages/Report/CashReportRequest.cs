/***********************************************************************
 * <copyright file="CashReportRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 15 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report.Finacial;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    /// <summary>
    /// CashReportRequest
    /// </summary>
  public  class CashReportRequest:RequestBase
    {

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets the tod date.
        /// </summary>
        /// <value>
        /// The tod date.
        /// </value>
        public DateTime TodDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the amoun.
        /// </summary>
        /// <value>
        /// The type of the amoun.
        /// </value>
        public int AmounType { get; set; }


        /// <summary>
        /// Gets or sets the cash repport.
        /// </summary>
        /// <value>
        /// The cash repport.
        /// </value>
        public CashReportEntity CashRepport { get; set; }

    }

}
