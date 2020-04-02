/***********************************************************************
 * <copyright file="ReportHelper.cs" company="BUCA JSC">
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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.MainReport;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Session;
using DevExpress.XtraEditors;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Reporting.Components;
using RSSHelper;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportHelper
    {
        #region "Fields"

        /// <summary>
        /// The _o rs tool
        /// </summary>
        private ReportSharpHelper _rsTool;

        /// <summary>
        /// The _report list model
        /// </summary>
        private ReportListModel _reportListModel;

        /// <summary>
        /// The _FRM parent form
        /// </summary>
        private XtraForm _frmParentForm;

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        public List<ReportListModel> ReportLists { get; set; }

        /// <summary>
        /// Gets or sets the currency models.
        /// </summary>
        /// <value>
        /// The currency models.
        /// </value>
        public IList<CurrencyModel> CurrencyModels { get; set; }

        /// <summary>
        /// The common variable
        /// </summary>
        public GlobalVariable CommonVariable;

        /// <summary>
        /// Gets or sets the rs tool.
        /// </summary>
        /// <value>
        /// The rs tool.
        /// </value>
        public ReportSharpHelper ReportSharpTool
        {
            get
            {
                return _rsTool;
            }
            set
            {
                var handler1 = new ReportSharpHelper.RefreshEventHandler(RefreshReport);
                var handler2 = new ReportSharpHelper.DrilldownVoucherEventHandler(ReportDrillDownVoucher);
                var handler3 = new ReportSharpHelper.DrilldownLedgerReportHandler(ReportDrillDownLedgerReport);
                var handler4 = new ReportSharpHelper.ReportAboutEventHandler(ReportAbout);
                _rsTool = value;
                if (_rsTool == null) return;
                _rsTool.RefreshEvent += handler1;
                _rsTool.DrilldownVoucherEvent += handler2;
                _rsTool.DrilldownLedgerReportEvent += handler3;
                _rsTool.ReportAboutEvent += handler4;
            }
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public SortedList Parameters { get; set; }

        /// <summary>
        /// Gets or sets the data member.
        /// </summary>
        /// <value>
        /// The data member.
        /// </value>
        public string DataMember { get; set; }

        #endregion

        #region "Methods"

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportHelper" /> class.
        /// </summary>
        public ReportHelper()
        {
            ReportSharpTool = new ReportSharpHelper();
        }

        /// <summary>
        /// Reports the about.
        /// </summary>
        private static void ReportAbout()
        {
            using (var frmAbout = new XtraAboutFormReport())
            {
                frmAbout.ShowDialog();
            }
        }

        /// <summary>
        /// Refreshes the report.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        private void RefreshReport(ref ICollection dataSource)
        {
            try
            {
                if (dataSource == null) return;
                if (_reportListModel == null) return;
                ReportSharpTool.IsRefresh = true;
                var data = GetDataSource(_frmParentForm, _reportListModel);
                if (data != null)
                {
                    dataSource = data;
                    if (dataSource.Count < 1)
                    {
                        XtraMessageBox.Show("Không có bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ReportSharpTool.IsRefresh = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Reports the drill down voucher.
        /// </summary>
        /// <param name="refType">The reftype.</param>
        /// <param name="refId">The refid.</param>
        private void ReportDrillDownVoucher(string refType, string refId)
        {
            try
            {
                var pageIndex = ReportSharpTool.oPreviewForm.ReportViewer.PageIndex;
                ReportTool.DrillDownReportVoucher(refType, refId);
                ReportSharpTool.PreviewForm.ReportViewer.Actions["RefreshReport"].ExecuteAction();
                var reportFileName = ReportSharpTool.ReportFileName;
                ReportSharpTool.PreviewForm.Text = ReportSharpTool.ReportTitle + @"  [" + reportFileName.Substring((reportFileName.LastIndexOf("\\", StringComparison.Ordinal) + 1),
                                                                              ((reportFileName.Length - reportFileName.LastIndexOf("\\", StringComparison.Ordinal)) - 1)) +
                                                                          @"] - Xem báo cáo";
                ReportSharpTool.oPreviewForm.ReportViewer.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Reports the drill down ledger report.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eParam">The e parameter.</param>
        private void ReportDrillDownLedgerReport(object sender, DrilldownReportParam eParam)
        {
            try
            {
                var pageIndex = ReportSharpTool.oPreviewForm.ReportViewer.PageIndex;
                ReportTool.DrillDownReport(sender, eParam);

                var zoom = ReportSharpTool.PreviewForm.ReportViewer.Zoom;
                var templateFile = ReportSharpTool.ReportSlot.FilePath;
                ReportSharpTool.ReportSlot.FilePath = ReportSharpTool.ReportFileName;
                ReportSharpTool.ReportSlot.Document = ReportSharpTool.ReportSlot.LoadReport();

                ReportSharpTool.RefreshInfo(ReportSharpTool.ReportSlot.Document);

                ReportSharpTool.ReportSlot.FilePath = templateFile;
                ReportSharpTool.ReportSlot.SaveReport(ReportSharpTool.ReportSlot.Document);
                ReportSharpTool.ReportSlot.RenderDocument();



                ReportSharpTool.PreviewForm.ReportViewer.Actions["RefreshReport"].ExecuteAction();

                var reportFileName = ReportSharpTool.ReportFileName;
                ReportSharpTool.PreviewForm.Text = ReportSharpTool.ReportTitle + @"  [" + reportFileName.Substring((reportFileName.LastIndexOf("\\", StringComparison.Ordinal) + 1),
                                                                              ((reportFileName.Length - reportFileName.LastIndexOf("\\", StringComparison.Ordinal)) - 1)) +
                                                                          @"] - Xem báo cáo";
                ReportSharpTool.PreviewForm.ReportViewer.Zoom = zoom;
                ReportSharpTool.oPreviewForm.ReportViewer.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <returns></returns>
        /// ReSharper disable once UnusedMember.Local
        /// ReSharper disable once UnusedParameter.Local
        private bool AddParameter(ref ICollection dataSource)
        {
            var oRsTool = ReportSharpTool;
            if (ReportSharpTool != null)
            {
                oRsTool.ProductName = "";
                oRsTool.Parameters.Add("CompanyDirector", CommonVariable.CompanyDirector);
                oRsTool.Parameters.Add("CompanyReportPreparer", CommonVariable.CompanyReportPreparer);
                oRsTool.Parameters.Add("CompanyChiefAccountant", CommonVariable.CompanyAccountant);
                oRsTool.Parameters.Add("CompanyCashier", CommonVariable.CompanyCashier);
                oRsTool.Parameters.Add("CompanyStoreKeeper", CommonVariable.CompanyStoreKeeper);
                
                if (!oRsTool.Parameters.ContainsKey("JobTitleCompanyAccountant"))
                    oRsTool.Parameters.Add("JobTitleCompanyAccountant", CommonVariable.JobTitleCompanyAccountant);
                if (!oRsTool.Parameters.ContainsKey("JobTitleCompanyDirector"))
                    oRsTool.Parameters.Add("JobTitleCompanyDirector", CommonVariable.JobTitleCompanyDirector);
                if (!oRsTool.Parameters.ContainsKey("JobTitleCompanyStoreKeeper"))
                    oRsTool.Parameters.Add("JobTitleCompanyStoreKeeper", CommonVariable.JobTitleCompanyStoreKeeper);
                if (!oRsTool.Parameters.ContainsKey("JobTitleCompanyReportPreparer"))
                    oRsTool.Parameters.Add("JobTitleCompanyReportPreparer", CommonVariable.JobTitleCompanyReportPreparer);
                if (!oRsTool.Parameters.ContainsKey("JobTitleCompanyCashier"))
                    oRsTool.Parameters.Add("JobTitleCompanyCashier", CommonVariable.JobTitleCompanyCashier);
                if (!oRsTool.Parameters.ContainsKey("TitleConsulManager"))
                    oRsTool.Parameters.Add("TitleConsulManager", CommonVariable.TitleConsulManager);
                if (!oRsTool.Parameters.ContainsKey("ConsulManager"))
                    oRsTool.Parameters.Add("ConsulManager", CommonVariable.ConsulManager);


                //Tham số định dạng báo cáo ==============================================
                if (!oRsTool.Parameters.ContainsKey("GroupSeparator"))
                    oRsTool.Parameters.Add("GroupSeparator", CommonVariable.CurrencyGroupSeparator);
                if (!oRsTool.Parameters.ContainsKey("CurrencySymbol"))
                    oRsTool.Parameters.Add("CurrencySymbol", CommonVariable.CurrencySymbol);
                if (!oRsTool.Parameters.ContainsKey("DecimalPlaces"))
                    oRsTool.Parameters.Add("DecimalPlaces", CommonVariable.ExchangeRateDecimalDigits);
                if (!oRsTool.Parameters.ContainsKey("DecimalSeparator"))
                    oRsTool.Parameters.Add("DecimalSeparator", CommonVariable.CurrencyDecimalSeparator);

                if (!oRsTool.Parameters.ContainsKey("UnitPriceDecimalDigits"))
                    oRsTool.Parameters.Add("UnitPriceDecimalDigits", CommonVariable.UnitPriceDecimalDigits);
                //=========================================================================
            }
            else
            {
                oRsTool.Parameters.Add("CompanyDirector", "");
                oRsTool.Parameters.Add("CompanyReportPreparer", "");
                oRsTool.Parameters.Add("CompanyChiefAccountant", "");
                oRsTool.Parameters.Add("CompanyCashier", "");
                oRsTool.Parameters.Add("CompanyStoreKeeper", "");
            }

            oRsTool.Parameters.Add("StartDate", GlobalVariable.StartedDate);
            oRsTool.Parameters.Add("AmountType", GlobalVariable.AmountTypeViewReport);
            oRsTool.Parameters.Add("CurrencyCode", GlobalVariable.CurrencyViewReport);
            if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                oRsTool.Parameters.Add("CompanyProvince", CommonVariable.CompanyProvince);
           
            var licenseParameter = oRsTool.LicenseParameters;

            licenseParameter.Add("IsValidLicense", GlobalVariable.IsValidLicense);

            licenseParameter.Add("CompanyParentName", "BỘ CÔNG THƯƠNG");

            var parentCompanyFont = CommonVariable.CompanyInChargeFont != null ? CommonVariable.CompanyInChargeFont.Split(';') : null;
            if (parentCompanyFont != null && parentCompanyFont.Length != 0)
            {
                var fontstyle = (FontStyle)Enum.Parse(typeof(FontStyle), parentCompanyFont[2], true);
                var font = new Font(parentCompanyFont[0], float.Parse(parentCompanyFont[1]), fontstyle);
                licenseParameter.Add("CompanyParentNameFont", new FontDescriptor(font));
            }
            else
            {
                licenseParameter.Add("CompanyParentNameFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
            }

            licenseParameter.Add("CompanyName", GlobalVariable.CompanyName);

            var companyNameFont = CommonVariable.CompanyNameFont != null ? CommonVariable.CompanyNameFont.Split(';') : null;
            if (companyNameFont != null && companyNameFont.Length != 0)
            {
                var fontstyle = (FontStyle)Enum.Parse(typeof(FontStyle), companyNameFont[1], true);
                var font = new Font(companyNameFont[0], float.Parse(companyNameFont[2]), fontstyle);
                licenseParameter.Add("CompanyNameFont", new FontDescriptor(font));
            }
            else
            {
                licenseParameter.Add("CompanyNameFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
            }
            licenseParameter.Add("CompanyAddress", "Mã đơn vị: " + GlobalVariable.CompanyCode);

            var companyAddressFont = CommonVariable.CompanyAddressFont != null ? CommonVariable.CompanyAddressFont.Split(';') : null;
            if (companyAddressFont != null && companyAddressFont.Length != 0)
            {
                var fontstyle = (FontStyle)Enum.Parse(typeof(FontStyle), companyAddressFont[1], true);
                var font = new Font(companyAddressFont[0], float.Parse(companyAddressFont[2]), fontstyle);
                licenseParameter.Add("CompanyAddressFont", new FontDescriptor(font));
            }
            else
            {
                licenseParameter.Add("CompanyAddressFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
            }


            return true;
        }

        /// <summary>
        /// Designs the report template.
        /// </summary>
        /// <param name="reportPathFile">The sreportpathfile.</param>
        /// ReSharper disable once UnusedMember.Local
        public void DesignReportTemplate(string reportPathFile)
        {
            try
            {
                ReportSharpTool.ReportFileName = reportPathFile;
                ReportSharpTool.DesignReport();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Prints the preview report.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportId">The s report identifier.</param>
        /// <param name="isPint">if set to <c>true</c> [is pint].</param>
        public void PrintPreviewReport(XtraForm frmParent, string reportId, bool isPint)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _reportListModel = ReportLists.Find(item => item.ReportID == reportId);
                if (_reportListModel == null) return;
                _frmParentForm = frmParent;
                var reportListSource = GetDataSource(frmParent, _reportListModel);
                if (reportListSource == null)
                {
                    return;
                }
                if (reportListSource.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu lấy lên báo cáo Không có bản ghi nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!string.IsNullOrEmpty(_reportListModel.TableName))
                {
                    DataMember = _reportListModel.TableName.Trim();
                }
                DisplayReport(ref reportListSource, _reportListModel, false, frmParent, false, isPint, DateTime.MinValue);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Prints the preview report by report.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="param">The e parameter.</param>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        public void PrintPreviewReportByReport(XtraForm frmParent, DrilldownReportParam param, bool isPrint)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _reportListModel = ReportLists.Find(item => item.ReportID == param.ArgParameter[0].ToString());
                if (_reportListModel == null) return;
                _frmParentForm = frmParent;

                var reportListSource = GetDrillDownDataSource(frmParent, _reportListModel, param.ArgParameter);
                if (reportListSource == null || reportListSource.Count <= 0) return;
                if (reportListSource.Count > 0)
                {
                    if (!string.IsNullOrEmpty(_reportListModel.TableName))
                    {
                        DataMember = _reportListModel.TableName.Trim();
                    }
                    DisplayReport(ref reportListSource, _reportListModel, false, frmParent, false, isPrint, DateTime.MinValue);
                }
                else
                {
                    XtraMessageBox.Show("Không có bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Gets the drill down data source.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportList">The report list.</param>
        /// <param name="parramDrilldown">The parram drilldown.</param>
        /// <returns></returns>
        private ICollection GetDrillDownDataSource(XtraForm frmParent, ReportListModel reportList, object[] parramDrilldown)
        {
            IList dataSource = null;
            try
            {
                if (!string.IsNullOrEmpty(reportList.InputTypeName))
                {
                    var type = Assembly.GetExecutingAssembly().GetType((GetType().Namespace + "." + reportList.InputTypeName));
                    var target = (BaseReport)Activator.CreateInstance(type);
                    if (!string.IsNullOrEmpty(reportList.ProcedureName))
                    {
                        if (CommonVariable == null)
                        {
                            CommonVariable = new GlobalVariable();
                        }
                        CommonVariable.StoreProcedureName = reportList.ProcedureName;
                        CommonVariable.ReportList = reportList;
                        CommonVariable.DrillDownParram = parramDrilldown;
                        CommonVariable.IsDrillDownReport = true;
                        var args = new object[] { frmParent, CommonVariable, _rsTool };
                        dataSource = (IList)(type.InvokeMember(reportList.FunctionReportName, BindingFlags.InvokeMethod, null, target, args));
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataSource;
        }

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportList">The report list.</param>
        /// <returns></returns>
        private ICollection GetDataSource(XtraForm frmParent, ReportListModel reportList)
        {
            IList dataSource = null;
            try
            {
                if (!string.IsNullOrEmpty(reportList.InputTypeName))
                {
                    var type = Assembly.GetExecutingAssembly().GetType((GetType().Namespace + "." + reportList.InputTypeName));
                    var target = (BaseReport)Activator.CreateInstance(type);
                    if (!string.IsNullOrEmpty(reportList.ProcedureName))
                    {
                        if (CommonVariable == null)
                        {
                            CommonVariable = new GlobalVariable();
                        }
                        CommonVariable.StoreProcedureName = reportList.ProcedureName;
                        CommonVariable.ReportList = reportList;
                        CommonVariable.IsDrillDownReport = false;
                        var args = new object[] { frmParent, CommonVariable, _rsTool };
                        dataSource = (IList)(type.InvokeMember(reportList.FunctionReportName, BindingFlags.InvokeMethod, null, target, args));
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataSource;
        }

        /// <summary>
        /// Displays the report.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="reportList">The report list.</param>
        /// <param name="isVoucher">if set to <c>true</c> [b is voucher].</param>
        /// <param name="frmForm">The   form.</param>
        /// <param name="isShowDialog">if set to <c>true</c> [b show dialog].</param>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        /// <param name="voucherDate">The d voucher date.</param>
        public void DisplayReport(ref ICollection dataSource, ReportListModel reportList, bool isVoucher, XtraForm frmForm, bool isShowDialog, bool isPrint, DateTime voucherDate)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (dataSource == null) return;
                CommonVariable = new GlobalVariable();
                var str = CommonVariable.ReportPath + reportList.ReportFile;
                var oRsTool = ReportSharpTool;
                oRsTool.RssObject.VoucherDate = voucherDate;
                oRsTool.ListDataSource = dataSource;
                oRsTool.DataMember = reportList.TableName.Trim();
                oRsTool.LayoutReportPath = CommonVariable.ReportPath;
                oRsTool.ReportFileName = str;
                if (!AddParameter(ref dataSource)) return;
                oRsTool.IsPrint = isPrint;
                oRsTool.ReportTitle = reportList.ReportName;
                oRsTool.ProductName = CommonVariable.ProducName;
                oRsTool.DisplayProductName = false;
                _frmParentForm = frmForm;
                var model = new TSD.AccountingSoft.Model.Model();
                CurrencyModels = model.GetCurrencies();
                NumberToWord.Currencies = new List<Currency>();
                foreach (var currencyModel in CurrencyModels)
                {
                    NumberToWord.Currencies.Add(new Currency
                    {
                        CurrencyId = currencyModel.CurrencyId,
                        CurrencyCode = currencyModel.CurrencyCode,
                        CurrencyName = currencyModel.CurrencyName,
                        Prefix = currencyModel.Prefix,
                        Suffix = currencyModel.Suffix
                    });
                }
                oRsTool.RunReport(frmForm, isShowDialog);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString() + ex.InnerException, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}