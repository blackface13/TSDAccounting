/***********************************************************************
 * <copyright file="EstimateDetailStatementView.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;


namespace TSD.AccountingSoft.View.Estimate
{
    /// <summary>
    /// interface IEstimateDetailStatementPartBView
    /// </summary>
    public interface IEstimateDetailStatementPartBView : IView
    {
        /// <summary>
        /// Sets the payment estimates.
        /// </summary>
        /// <value>The payment estimates.</value>
        IList<EstimateDetailStatementPartBModel> EstimateDetailStatementPartB { set; }
    }
}
