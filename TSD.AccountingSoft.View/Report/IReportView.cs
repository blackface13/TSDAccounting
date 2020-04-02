/***********************************************************************
 * <copyright file="IReportView.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Monday, February 24, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Report;


namespace TSD.AccountingSoft.View.Report
{
    /// <summary>
    /// interface IReportView
    /// </summary>
    public interface IReportView : IView
    {
        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        List<ReportListModel> ReportLists {set; }
    }
}
