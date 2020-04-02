/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 19, 2014
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
    /// Class IPaymentEstimateDetailsView.
    /// </summary>
    public interface IPaymentEstimateDetailsView
    {
        /// <summary>
        /// Sets the payment estimates.
        /// </summary>
        /// <value>The payment estimates.</value>
        IList<EstimateDetailModel> PaymentEstimateDetails { set; }
    }
}
