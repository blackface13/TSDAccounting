/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;


namespace TSD.AccountingSoft.View.Estimate
{
    /// <summary>
    /// Interface IReceiptEstimatesView
    /// </summary>
    public interface IReceiptEstimatesView : IView
    {
        /// <summary>
        /// Sets the receipt estimates.
        /// </summary>
        /// <value>
        /// The receipt estimates.
        /// </value>
        IList<EstimateModel> ReceiptEstimates { set; }

        IList<EstimateDetailModel> ReceiptEstimateDetails { set; }
    }
}
