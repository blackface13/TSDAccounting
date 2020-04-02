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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report.Voucher;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    /// <summary>
    /// C30BBResponse
    /// </summary>
  public  class C30BBResponse: ResponseBase
    {
        /// <summary>
        /// The C30 bb repport lists
        /// </summary>
      public List<C30BBEntity> C30BBRepportLists;

    }
}
