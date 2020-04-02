/***********************************************************************
 * <copyright file="ReportListPresenter.cs" company="Linh Khang">
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
using TSD.AccountingSoft.View.Report;


namespace TSD.AccountingSoft.Presenter.Report
{
    /// <summary>
    /// Report List Presenter
    /// </summary>
    public class ReportListPresenter : Presenter<IReportView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReportListPresenter(IReportView view)
            : base(view)
        {
        }

        /// <summary>
        /// Gets all report list.
        /// </summary>
        /// <returns></returns>
        public List<ReportListModel> GetAllReportList()
        {
            return View.ReportLists = Model.GetReportLists();
        }

        /// <summary>
        /// Gets the report lists by report group.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns></returns>
        public List<ReportListModel> GetReportListsByReportGroup(int reportGroupId)
        {
            return View.ReportLists = Model.GetReportListsByReportGroup(reportGroupId);
        }

        /// <summary>
        /// Gets the report list by identifier.
        /// </summary>
        /// <param name="reportId">The report identifier.</param>
        /// <returns></returns>
        public ReportListModel GetReportListById(string reportId)
        {
            return Model.GetReportListById(reportId);
        }

        /// <summary>
        /// Updates the report list.
        /// </summary>
        /// <param name="reportListModel">The report list model.</param>
        /// <returns></returns>
        public string UpdateReportList(ReportListModel reportListModel)
        {
            return Model.UpdateReportList(reportListModel);
        }

    }
}
