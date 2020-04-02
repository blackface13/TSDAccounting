/***********************************************************************
 * <copyright file="IFixedAssetHousingReportsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;


namespace TSD.AccountingSoft.View.Report
{
    /// <summary>
    /// Interface IFixedAssetHousingReportsView
    /// </summary>
    public interface IFixedAssetHousingReportsView : IView
    {
        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        IList<FixedAssetHousingReportModel> FixedAssetHousingReports { set; }
    }
}
