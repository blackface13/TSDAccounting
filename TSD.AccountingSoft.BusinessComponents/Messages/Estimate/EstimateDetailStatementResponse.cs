/***********************************************************************
 * <copyright file="EstimateDetailStatementResponse.cs" company="BUCA JSC">
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
    /// EstimateDetailStatementResponse
    /// </summary>
    public class EstimateDetailStatementResponse : ResponseBase
    {
        /// <summary>
        /// The estimates
        /// </summary>
        public IList<EstimateDetailStatementInfoEntity> EstimateDetailStatements;

        /// <summary>
        /// The estimate
        /// </summary>
        public EstimateDetailStatementInfoEntity EstimateDetailStatement;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public int EstimateDetailStatementId;
    }
}
