/***********************************************************************
 * <copyright file="ReportGroupPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.View.Report;


namespace TSD.AccountingSoft.Presenter.Report
{
    /// <summary>
    /// Report Group Presenter
    /// </summary>
    public class ReportGroupPresenter : Presenter<IReportGroupView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGroupPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReportGroupPresenter(IReportGroupView view)
            : base(view)
        {
        }

        /// <summary>
        /// Gets all report group.
        /// </summary>
        /// <returns></returns>
        public List<ReportGroupModel> GetAllReportGroup()
        {
            return View.ReportGroups = Model.GetReportGroups();
        }

        /// <summary>
        /// Gets the report group by identifier.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns></returns>
        public ReportGroupModel GetReportGroupById(int reportGroupId)
        {
            return Model.GetReportGroupById(reportGroupId);
        }
    }
}
