/***********************************************************************
 * <copyright file="FrmXtraReportList.cs" company="BUCA JSC">
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
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Report;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.Report.MainReport
{
    /// <summary>
    /// FrmXtraReportList
    /// </summary>
    public partial class FrmXtraReportList : XtraForm, IReportView, IReportGroupView
    {
        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;

        /// <summary>
        /// The _report group presenter
        /// </summary>
        private readonly ReportGroupPresenter _reportGroupPresenter;

        /// <summary>
        /// The _report helper
        /// </summary>
        private readonly ReportHelper _reportHelper;

        /// <summary>
        /// Gets or sets the common variable.
        /// </summary>
        /// <value>
        /// The common variable.
        /// </value>
        public GlobalVariable CommonVariable { get; set; }

        /// <summary>
        /// The _report list
        /// </summary>
        private List<ReportListModel> _reportList;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraReportList"/> class.
        /// </summary>
        public FrmXtraReportList()
        {
            InitializeComponent();
            _reportGroupPresenter = new ReportGroupPresenter(this);
            _reportListPresenter = new ReportListPresenter(this);
            _reportHelper = new ReportHelper();
            CommonVariable = new GlobalVariable();
            dateTimeRangeV.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV.InitSelectedIndex = 0;
            dateTimeRangeV.InitData(DateTime.Parse(CommonVariable.PostedDate));
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            try
            {
                cboCurrencyCode.Properties.Items.Add(CommonVariable.CurrencyLocal);
                if (CommonVariable.CurrencyLocal != CommonVariable.CurrencyAccounting)
                {
                    cboCurrencyCode.Properties.Items.Add(CommonVariable.CurrencyAccounting);
                    cboCurrencyCode.EditValue = cboCurrencyCode.Properties.Items[1];
                }
                else
                    cboCurrencyCode.EditValue = cboCurrencyCode.Properties.Items[0];
                _reportGroupPresenter.GetAllReportGroup();
                _reportList = _reportListPresenter.GetAllReportList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Views the report.
        /// </summary>
        private void ViewReport(bool isPrint)
        {
            try
            {
                var reportId = gridReportDetailView.GetFocusedRowCellValue("ReportID").ToString();
                GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV.cboDateRange.SelectedIndex;
                GlobalVariable.FromDate = dateTimeRangeV.FromDate;
                GlobalVariable.ToDate = dateTimeRangeV.ToDate;
                GlobalVariable.AmountTypeViewReport = cboAmountType.SelectedIndex + 1;
                GlobalVariable.CurrencyViewReport = cboCurrencyCode.EditValue.ToString();
                ReportTool.CommonVariable = CommonVariable;
                ReportTool.PrintPreview(this, _reportList, reportId, isPrint);
                dateTimeRangeV.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "Lỗi:" + ex.InnerException);
            }
        }

        /// <summary>
        /// Loads the report group grid layout.
        /// </summary>
        private void LoadReportGroupGridLayout()
        {
            try
            {
                grdReportGroup.ForceInitialize();
                if (gridReportGroupView.RowCount <= 0)
                {
                    return;
                }
                gridReportGroupView.Columns["ReportGroupID"].Visible = false;
                gridReportGroupView.Columns["Description"].Visible = false;
                gridReportGroupView.Columns["IsVoucher"].Visible = false;
                gridReportGroupView.Columns["IsActive"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Loads the report detail grid layout.
        /// </summary>
        private void LoadReportDetailGridLayout()
        {
            try
            {
                if (_reportList.Count <= 0) return;
                for (int i = 0; i < gridReportDetailView.Columns.Count; i++)
                {
                    if (gridReportDetailView.Columns[i].FieldName != "ReportName")
                    {
                        gridReportDetailView.Columns[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region IReportView Members

        /// <summary>
        /// Gets or sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<ReportListModel> ReportLists
        {
            set { grdReportDetail.DataSource = value.FindAll(item => item.GroupID == (int)gridReportGroupView.GetFocusedRowCellValue("ReportGroupID")); }
        }

        /// <summary>
        /// Gets the report helper.
        /// </summary>
        /// <value>
        /// The report helper.
        /// </value>
        public ReportHelper ReportHelper
        {
            get { return _reportHelper; }
        }

        #endregion

        /// <summary>
        /// Handles the Load event of the FrmXtraReportList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraReportList_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadReportGroupGridLayout();
            LoadReportDetailGridLayout();
            
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        /// <summary>
        /// Handles the DoubleClick event of the gridReportDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridReportDetailView_DoubleClick(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        #region IReportGroupView Members

        /// <summary>
        /// Sets the report groups.
        /// </summary>
        /// <value>
        /// The report groups.
        /// </value>
        public List<ReportGroupModel> ReportGroups
        {
            get { return new List<ReportGroupModel>(); }
            set { grdReportGroup.DataSource = value; }
        }

        #endregion

        /// <summary>
        /// Handles the FocusedRowChanged event of the gridReportGroupView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs"/> instance containing the event data.</param>
        private void gridReportGroupView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var reportGroupId = (int)gridReportGroupView.GetFocusedRowCellValue("ReportGroupID");
            if (_reportList == null) return;
            ReportLists = _reportList.FindAll(item => item.GroupID == reportGroupId);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var reportFile = gridReportDetailView.GetFocusedRowCellValue("ReportFile").ToString();
                var fullPath = CommonVariable.ReportPath + reportFile;
                if (File.Exists(fullPath))
                    _reportHelper.DesignReportTemplate(fullPath);
                else
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show("Tệp báo cáo không tồn tại, vui lòng kiểm tra lại đường dẫn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ViewReport(true);
        }

        //ThangNK bổ sung hàm này
        private void cboAmountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboAmountType.SelectedIndex == 0)
            {
                cboCurrencyCode.EditValue = CommonVariable.CurrencyAccounting;
                cboCurrencyCode.Enabled = false;
            }
            else
            {
                cboCurrencyCode.Enabled = true;
            
            }

        }
    }
}