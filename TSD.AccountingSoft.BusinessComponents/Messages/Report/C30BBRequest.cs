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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report.Voucher;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{

    /// <summary>
    /// Class C30BBRequest.
    /// </summary>
  public  class C30BBRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int  Year { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int  RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the C30 bb repport.
        /// </summary>
        /// <value>The C30 bb repport.</value>
        public C30BBEntity C30BBRepport { get; set; }

    }

}
