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
using TSD.AccountingSoft.BusinessEntities.Report.Finacial;



namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    /// <summary>
    /// Class CashReportResponse.
    /// </summary>
  public  class CashReportResponse: ResponseBase
    {
        /// <summary>
        /// The cash repport lists
        /// </summary>
      public List<CashReportEntity> CashRepportLists;

    }
}
