/***********************************************************************
 * <copyright file="ReportGroupResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
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
using TSD.AccountingSoft.BusinessEntities.Report;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    /// <summary>
    /// Report Group Response
    /// </summary>
    public class ReportGroupResponse : ResponseBase
    {
        /// <summary>
        /// The report groups
        /// </summary>
        public List<ReportGroupEntity> ReportGroups;

        /// <summary>
        /// The report group
        /// </summary>
        public ReportGroupEntity ReportGroup;
    }
}
