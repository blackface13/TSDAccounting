﻿/***********************************************************************
 * <copyright file="EstimateDetailStatementPartBResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, June 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Estimate
{
    /// <summary>
    /// class EstimateDetailStatementPartBResponse
    /// </summary>
    public class EstimateDetailStatementPartBResponse : ResponseBase
    {
        /// <summary>
        /// The estimates
        /// </summary>
        public IList<EstimateDetailStatementPartBEntity> EstimateDetailStatementPartBs;

        /// <summary>
        /// The estimate detail statement part b identifier
        /// </summary>
        public int EstimateDetailStatementPartBId ;
    }
}
