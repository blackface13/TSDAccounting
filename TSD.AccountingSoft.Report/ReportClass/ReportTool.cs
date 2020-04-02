/***********************************************************************
 * <copyright file="ReportTool.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Session;
using DevExpress.XtraEditors;
using RSSHelper;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// Report Tool
    /// </summary>
    public class ReportTool
    {
        #region "Fields"

        /// <summary>
        /// Drilldown Voucher Event Handler
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        public delegate void DrilldownVoucherEventHandler(string refType, string refId);

        /// <summary>
        /// Report About Event Handler
        /// </summary>
        public delegate void ReportAboutEventHandler();

        /// <summary>
        /// Gets or sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        public static List<ReportListModel> ReportLists { get; set; }

        /// <summary>
        /// The common variable
        /// </summary>
        public static GlobalVariable CommonVariable;

        /// <summary>
        /// Occurs when [drilldown voucher event].
        /// </summary>
        public static event DrilldownVoucherEventHandler DrilldownVoucherEvent;

        /// <summary>
        /// Occurs when [report about event].
        /// </summary>
        public static event ReportAboutEventHandler ReportAboutEvent;

        /// <summary>
        /// Reports the about.
        /// </summary>
        public static void ReportAbout()
        {
            ReportAboutEventHandler handler = ReportAboutEvent;
            if (handler != null) handler();
        }

        /// <summary>
        /// Drills down report voucher.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        internal static void DrillDownReportVoucher(string refType, string refId)
        {
            DrilldownVoucherEventHandler handler = DrilldownVoucherEvent;
            if (handler != null)
            {
                handler(refType, refId);
            }
        }
        #endregion

        #region "Methods"

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportTool" /> class.
        /// </summary>
        public ReportTool()
        {
            InitData();
            CommonVariable = new GlobalVariable();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        private static void InitData()
        {
        }

        /// <summary>
        /// Prints the preview.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportList">The report list.</param>
        /// <param name="reportId">The report identifier.</param>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        public static void PrintPreview(XtraForm frmParent, List<ReportListModel> reportList, string reportId, bool isPrint)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var reportHelper = new ReportHelper();
                InitData();
                reportHelper.ReportLists = ReportLists = reportList;
                reportHelper.CommonVariable = CommonVariable;
                reportHelper.PrintPreviewReport(frmParent, reportId, isPrint);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Drills down report.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eParam">The e parameter.</param>
        internal static void DrillDownReport(object sender, DrilldownReportParam eParam)
        {
            DrillDownReport((XtraForm)sender, eParam);
        }

        /// <summary>
        /// Drills down report.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="eParam">The e parameter.</param>
        private static void DrillDownReport(XtraForm form, DrilldownReportParam eParam)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var viewer = new ReportHelper();
                InitData();
                viewer.ReportLists = ReportLists;
                viewer.CommonVariable = CommonVariable;
                viewer.PrintPreviewReportByReport(form, eParam, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
