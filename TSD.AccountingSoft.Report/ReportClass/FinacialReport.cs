/***********************************************************************
 * <copyright file="FinacialReport.cs" company="BUCA JSC">
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
 * 10/9/2014    LinhMC               Sửa lại toàn bộ method check điều kiện nếu nạp lại dữ liệu thì ko show form param
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using DevExpress.XtraEditors;
using RSSHelper;
using TSD.AccountingSoft.Model.BusinessObjects.Report;

namespace TSD.AccountingSoft.Report.ReportClass
{
    public class FinacialReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;
        public FinacialReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();
        }

        #region Financial Report //chỉ giành cho báo cáo tài chính

        /// <summary>
        /// Bảng cân đối tài khoản
        /// Gets the report B01 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<B01HModel> GetReportB01H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                IList<B01HModel> list = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = _globalVariable.PostedDate;
                var isTotalBandInNewPage = false;

                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmB01H())
                    {
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {

                            GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                            GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                            isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

                            list = Model.GetB01HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode, amountType);
                        }
                    }
                }
                else
                {
                    list = Model.GetB01HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode, amountType);
                }
                if (list != null && list.Count > 0)
                {
                    foreach (var obj in list.ToList())
                    {
                        if (obj.ClosingCredit == 0 && obj.ClosingDebit == 0 && obj.MovementAccumCredit == 0 && obj.MovementAccumDebit == 0 && obj.MovementCredit == 0 && obj.MovementDebit == 0 && obj.OpeningCredit == 0 && obj.OpeningDebit == 0)
                        {
                            list.Remove(obj);
                        }
                    }
                    if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                        oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                    if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                        oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                    if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                        oRsTool.Parameters.Add("ReportDate", reportDate);
                    if (amountType == 1)
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                    }
                    else
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                    }
                    if (!oRsTool.Parameters.ContainsKey("FromDate"))
                        oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ToDate"))
                        oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                    decimal TotalOpeningCredit = list.Where(x => x.Grade == 1).Sum(x => x.OpeningCredit);
                    decimal TotalOpeningDebit = list.Where(x => x.Grade == 1).Sum(x => x.OpeningDebit);
                    decimal TotalMovementAccumCredit = list.Where(x => x.Grade == 1).Sum(x => x.MovementAccumCredit);
                    decimal TotalMovementAccumDebit = list.Where(x => x.Grade == 1).Sum(x => x.MovementAccumDebit);
                    decimal TotalMovementCredit = list.Where(x => x.Grade == 1).Sum(x => x.MovementCredit);
                    decimal TotalMovementDebit = list.Where(x => x.Grade == 1).Sum(x => x.MovementDebit);
                    decimal TotalClosingCredit = list.Where(x => x.Grade == 1).Sum(x => x.ClosingCredit);
                    decimal TotalClosingDebit = list.Where(x => x.Grade == 1).Sum(x => x.ClosingDebit);

                    if (!oRsTool.Parameters.ContainsKey("TotalMovementCredit"))
                        oRsTool.Parameters.Add("TotalMovementCredit", TotalMovementCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementDebit"))
                        oRsTool.Parameters.Add("TotalMovementDebit", TotalMovementDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalClosingCredit"))
                        oRsTool.Parameters.Add("TotalClosingCredit", TotalClosingCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalClosingDebit"))
                        oRsTool.Parameters.Add("TotalClosingDebit", TotalClosingDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalOpeningCredit"))
                        oRsTool.Parameters.Add("TotalOpeningCredit", TotalOpeningCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalOpeningDebit"))
                        oRsTool.Parameters.Add("TotalOpeningDebit", TotalOpeningDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumCredit"))
                        oRsTool.Parameters.Add("TotalMovementAccumCredit", TotalMovementAccumCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumDebit"))
                        oRsTool.Parameters.Add("TotalMovementAccumDebit", TotalMovementAccumDebit);
                }

                return list;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Gets the report B03 BNG.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<B03BNGModel> GetReportB03BNG(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<B03BNGModel> b03BNGs = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1
                ? GlobalVariable.CurrencyMain
                : GlobalVariable.CurrencyViewReport;
            var reportDate = _globalVariable.PostedDate;
            var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB03BNG())
                {
                    frmParam.ReporDate = _globalVariable.PostedDate;
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        b03BNGs = Model.GetReportB03BNGs((short)amountType, currencyCode, GlobalVariable.FromDate,
                            GlobalVariable.ToDate) as List<B03BNGModel>;
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                    }
                }
            }
            else
            {
                b03BNGs = Model.GetReportB03BNGs((short)amountType, currencyCode, GlobalVariable.FromDate,
                            GlobalVariable.ToDate) as List<B03BNGModel>;
            }
            if (b03BNGs != null && b03BNGs.Count > 0)
            {
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", reportDate);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                //ThangNK Add
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);


            }
            return b03BNGs;
        }

        /// <summary>
        /// Báo cáo Quyết toán nguồn kinh phí
        /// Gets the report F03_ BNG.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<F03BNGModel> GetReportF03_BNG(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<F03BNGModel> f03BNGs = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1
                ? GlobalVariable.CurrencyMain
                : GlobalVariable.CurrencyViewReport;

            var isViewDetailUSD = false;

            var isTotalBandInNewPage = false;
            if (commonVariable.StoreProcedureName == null)
            {
                XtraMessageBox.Show(
                    "Không tìm thấy thủ tục lấy dữ liệu cho báo cáo, vui lòng kiểm tra lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmF03Bng())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        isViewDetailUSD = frmParam.IsDetailToUSD;
                        if (isViewDetailUSD)
                        {
                            commonVariable.StoreProcedureName = "uspReport_F03BNG_ForEstimate";
                        }


                        f03BNGs = Model.GetReportF03BNGs(commonVariable.StoreProcedureName, (short)amountType, currencyCode,
                                GlobalVariable.FromDate, GlobalVariable.ToDate) as List<F03BNGModel>;
                    }
                }
            }
            else
            {
                f03BNGs = Model.GetReportF03BNGs(commonVariable.StoreProcedureName, (short)amountType, currencyCode,
                                GlobalVariable.FromDate, GlobalVariable.ToDate) as List<F03BNGModel>;
            }
            if (f03BNGs != null && f03BNGs.Count > 0)
            {
                if (isViewDetailUSD)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (amountType == 1)
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                    }
                    else
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                    }
                }

                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("SignDate"))
                    oRsTool.Parameters.Add("SignDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                /*Lay thong tin don vi*/
                var companyProfile = Model.GetCompanyProfile(1);
                if (companyProfile != null)
                {
                    if (!oRsTool.Parameters.ContainsKey("EmployeePayrollsTotal"))
                        oRsTool.Parameters.Add("EmployeePayrollsTotal", companyProfile.EmployeePayrollsTotal);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfOfficers"))
                        oRsTool.Parameters.Add("EmployeeNumberOfOfficers", companyProfile.EmployeeNumberOfOfficers);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfWifeOrHusband"))
                        oRsTool.Parameters.Add("EmployeeNumberOfWifeOrHusband", companyProfile.EmployeeNumberOfWifeOrHusband);
                    if (!oRsTool.Parameters.ContainsKey("AssetNumberOfCars"))
                        oRsTool.Parameters.Add("AssetNumberOfCars", companyProfile.AssetNumberOfCars);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("EmployeePayrollsTotal"))
                        oRsTool.Parameters.Add("EmployeePayrollsTotal", 0);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfOfficers"))
                        oRsTool.Parameters.Add("EmployeeNumberOfOfficers", 0);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfWifeOrHusband"))
                        oRsTool.Parameters.Add("EmployeeNumberOfWifeOrHusband", 0);
                    if (!oRsTool.Parameters.ContainsKey("AssetNumberOfCars"))
                        oRsTool.Parameters.Add("AssetNumberOfCars", 0);
                }
            }
            return f03BNGs;
        }

        /// <summary>
        /// Báo cáo Quyết toán nguồn kinh phí quỹ tạm giữ 33189x
        /// Gets the report F331_ BNG.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<F331BNGModel> GetReportF331_BNG(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<F331BNGModel> f331BNGs = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1
                ? GlobalVariable.CurrencyMain
                : GlobalVariable.CurrencyViewReport;
            var accountCode = "";
            var accountName = "";
            var isTotalBandInNewPage = false;

            if (commonVariable.StoreProcedureName == null)
            {
                XtraMessageBox.Show(
                    "Không tìm thấy thủ tục lấy dữ liệu cho báo cáo, vui lòng kiểm tra lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }



            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmF331BNG())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        accountCode = frmParam.AccountList;
                        accountName = frmParam.AccountName;
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

                        f331BNGs = Model.GetReportF331BNGs(commonVariable.StoreProcedureName, (short)amountType, accountCode, currencyCode,
                                GlobalVariable.FromDate, GlobalVariable.ToDate) as List<F331BNGModel>;
                    }
                }
            }
            else
            {
                accountCode = oRsTool.Parameters["AccountCode"].ToString();
                f331BNGs = Model.GetReportF331BNGs(commonVariable.StoreProcedureName, (short)amountType, accountCode, currencyCode,
                                GlobalVariable.FromDate, GlobalVariable.ToDate) as List<F331BNGModel>;
            }
            if (f331BNGs != null && f331BNGs.Count > 0)
            {
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("SignDate"))
                    oRsTool.Parameters.Add("SignDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("AccountCode"))
                    oRsTool.Parameters.Add("AccountCode", accountCode);
                if (!oRsTool.Parameters.ContainsKey("AccountName"))
                    oRsTool.Parameters.Add("AccountName", accountName);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
            }
            return f331BNGs;
        }

        /// <summary>
        /// Gets the report B09_ BNG.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<B09BNGModel> GetReportB09_BNG(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<B09BNGModel> b09BNGs = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1 ? GlobalVariable.CurrencyMain : GlobalVariable.CurrencyViewReport;
            if (commonVariable.StoreProcedureName == null)
            {
                XtraMessageBox.Show(
                    "Không tìm thấy thủ tục lấy dữ liệu cho báo cáo, vui lòng kiểm tra lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmF09Bng())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);

                        b09BNGs = Model.GetReportB09BNGs(commonVariable.StoreProcedureName, (short)amountType, currencyCode,
                                GlobalVariable.FromDate, GlobalVariable.ToDate) as List<B09BNGModel>;
                    }
                }
            }
            else
            {
                b09BNGs = Model.GetReportB09BNGs(commonVariable.StoreProcedureName, (short)amountType, currencyCode,
                                GlobalVariable.FromDate, GlobalVariable.ToDate) as List<B09BNGModel>;
            }
            if (b09BNGs != null && b09BNGs.Count > 0)
            {
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }
                if (!oRsTool.Parameters.ContainsKey("SignDate"))
                    oRsTool.Parameters.Add("SignDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
            }
            return b09BNGs;
        }

        /// <summary>
        /// Báo cáo quyết toán kinh phí hoạt động
        /// </summary>
        /// <param name="frmParent"></param>
        /// <param name="commonVariable"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<B01BCQTModel> GetReportB01BCQT(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<B01BCQTModel> lstResults = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1 ? GlobalVariable.CurrencyMain : GlobalVariable.CurrencyViewReport;
            if (commonVariable.StoreProcedureName == null)
            {
                XtraMessageBox.Show("Không tìm thấy thủ tục lấy dữ liệu cho báo cáo, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinacialB01BCQT())
                {
                    frmParam.Text = "Tham số báo cáo";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = frmParam.FromDate;
                        GlobalVariable.ToDate = frmParam.ToDate;

                        lstResults = Model.GetReportB01BCQTs(commonVariable.StoreProcedureName, (short)amountType, currencyCode, GlobalVariable.FromDate, GlobalVariable.ToDate).ToList();
                    }
                }
            }
            else
            {
                lstResults = Model.GetReportB01BCQTs(commonVariable.StoreProcedureName, (short)amountType, currencyCode, GlobalVariable.FromDate, GlobalVariable.ToDate).ToList();
            }
            if (lstResults != null && lstResults.Count > 0)
            {
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }
                if (!oRsTool.Parameters.ContainsKey("SignDate"))
                    oRsTool.Parameters.Add("SignDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
            }
            return lstResults;
        }

        public IList<ReportF03BCTModel> GetReportF03_BCT(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<ReportF03BCTModel> f03BNGs = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1 ? GlobalVariable.CurrencyMain : GlobalVariable.CurrencyViewReport;

            var isViewDetailUSD = false;

            var isTotalBandInNewPage = false;
            if (commonVariable.StoreProcedureName == null)
            {
                XtraMessageBox.Show("Không tìm thấy thủ tục lấy dữ liệu cho báo cáo, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return null;
            }

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmF03Bng())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        isViewDetailUSD = frmParam.IsDetailToUSD;

                        if (isViewDetailUSD)
                        {
                            commonVariable.StoreProcedureName = "uspReport_F03BCT_ExchangeRate";
                        }

                        f03BNGs = Model.GetReportF03_BCTs(commonVariable.StoreProcedureName, (short)amountType, currencyCode, GlobalVariable.FromDate, GlobalVariable.ToDate) as List<ReportF03BCTModel>;
                    }
                }
            }
            else
            {
                f03BNGs = Model.GetReportF03_BCTs(commonVariable.StoreProcedureName, (short)amountType, currencyCode, GlobalVariable.FromDate, GlobalVariable.ToDate) as List<ReportF03BCTModel>; ;
            }

            if (f03BNGs != null && f03BNGs.Count > 0)
            {
                if (isViewDetailUSD)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (amountType == 1)
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                    }
                    else
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                    }
                }

                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("SignDate"))
                    oRsTool.Parameters.Add("SignDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                /*Lay thong tin don vi*/
                var companyProfile = Model.GetCompanyProfile(1);
                if (companyProfile != null)
                {
                    if (!oRsTool.Parameters.ContainsKey("EmployeePayrollsTotal"))
                        oRsTool.Parameters.Add("EmployeePayrollsTotal", companyProfile.EmployeePayrollsTotal);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfOfficers"))
                        oRsTool.Parameters.Add("EmployeeNumberOfOfficers", companyProfile.EmployeeNumberOfOfficers);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfWifeOrHusband"))
                        oRsTool.Parameters.Add("EmployeeNumberOfWifeOrHusband", companyProfile.EmployeeNumberOfWifeOrHusband);
                    if (!oRsTool.Parameters.ContainsKey("AssetNumberOfCars"))
                        oRsTool.Parameters.Add("AssetNumberOfCars", companyProfile.AssetNumberOfCars);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("EmployeePayrollsTotal"))
                        oRsTool.Parameters.Add("EmployeePayrollsTotal", 0);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfOfficers"))
                        oRsTool.Parameters.Add("EmployeeNumberOfOfficers", 0);
                    if (!oRsTool.Parameters.ContainsKey("EmployeeNumberOfWifeOrHusband"))
                        oRsTool.Parameters.Add("EmployeeNumberOfWifeOrHusband", 0);
                    if (!oRsTool.Parameters.ContainsKey("AssetNumberOfCars"))
                        oRsTool.Parameters.Add("AssetNumberOfCars", 0);
                }
            }
            return f03BNGs;
        }

        public IList<ReportActivityB02Model> GetReportActivityB02(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<ReportActivityB02Model> lstResults = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1 ? GlobalVariable.CurrencyMain : GlobalVariable.CurrencyViewReport;
            DateTime fromDate = GlobalVariable.FromDate;
            DateTime toDate = GlobalVariable.ToDate;
            string periodName = "";

            if (commonVariable.StoreProcedureName == null)
            {
                XtraMessageBox.Show("Không tìm thấy thủ tục lấy dữ liệu cho báo cáo, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB01CII())
                {
                    frmParam.Text = "Tham số báo cáo";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        fromDate = Convert.ToDateTime(frmParam.FromDate);
                        toDate = Convert.ToDateTime(frmParam.ToDate);
                        periodName = frmParam.PeriodName;

                        lstResults = Model.GetReportActivityB02(commonVariable.StoreProcedureName, amountType, currencyCode, fromDate, toDate).ToList();
                    }
                }

                if (lstResults != null && lstResults.Count > 0)
                {
                    //string reportTime = string.Format("Từ ngày: {0} - đến ngày: {1}", GlobalVariable.FromDate.ToString("dd/MM/yyyy"), GlobalVariable.ToDate.ToString("dd/MM/yyyy"));
                    //if (!oRsTool.Parameters.ContainsKey("ReportTime"))
                    //    oRsTool.Parameters.Add("ReportTime", reportTime);
                    if (!oRsTool.Parameters.ContainsKey("FromDate"))
                        oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ToDate"))
                        oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                        oRsTool.Parameters.Add("ReportDate", DateTime.UtcNow.AddHours(7).ToString("dd/MM/yyyy HH:mm:ss"));
                    if (!oRsTool.Parameters.ContainsKey("Province"))
                        oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                    if (!oRsTool.Parameters.ContainsKey("PrintDate"))
                        oRsTool.Parameters.Add("PrintDate",
                            "Ngày " + toDate.Day.ToString().PadLeft(2, '0')
                            + " tháng " + toDate.Month.ToString().PadLeft(2, '0')
                            + " năm " + toDate.Year);

                    if (amountType == 1)
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                    }
                    else
                    {
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                    }

                    if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                        oRsTool.Parameters.Add("PeriodName", periodName);
                }
            }

            return lstResults;
        }

        public IList<ReportB01BCTCModel> GetReportB01BCTC(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                List<ReportB01BCTCModel> lstResults = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = _globalVariable.PostedDate;
                var fromDate = GlobalVariable.FromDate;
                var toDate = GlobalVariable.ToDate;
                var periodName = "";

                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmB01CI())
                    {
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            fromDate = frmParam.FromDate;
                            toDate = frmParam.ToDate;
                            periodName = frmParam.PeriodName;
                        }
                        else
                            return null;
                    }
                }

                lstResults = Model.GetB01BCTC(commonVariable.ReportList.ProcedureName, fromDate.ToShortDateString(), toDate.ToShortDateString(), currencyCode, amountType).ToList();

                if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                    oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", fromDate.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", toDate.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                    oRsTool.Parameters.Add("PeriodName", periodName);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", reportDate);
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }
                if (!oRsTool.Parameters.ContainsKey("CurrencyNegativePattern"))
                    oRsTool.Parameters.Add("CurrencyNegativePattern", _globalVariable.CurrencyNegativePattern);

                return lstResults;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        public IList<ReportB03bBCTCModel> GetReportB03bBCTC(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                var lstResults = new List<ReportB03bBCTCModel>();
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = _globalVariable.PostedDate;
                var fromDate = GlobalVariable.FromDate;
                var toDate = GlobalVariable.ToDate;
                var periodName = "";

                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmB01CI())
                    {
                        frmParam.Text = "Báo cáo lưu chuyển tiền tệ gián tiếp";
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            fromDate = frmParam.FromDate;
                            toDate = frmParam.ToDate;
                            periodName = frmParam.PeriodName;
                        }
                        else
                            return null;
                    }
                }

                lstResults = Model.GetB03bBCTC(commonVariable.ReportList.ProcedureName, fromDate.ToShortDateString(), toDate.ToShortDateString(), currencyCode, amountType).ToList();

                if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                    oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", fromDate.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", toDate.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                    oRsTool.Parameters.Add("PeriodName", periodName);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }

                return lstResults;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        public IList<ReportB04BCTCModel> GetReportB04BCTC(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                List<ReportB04BCTCModel> lstResults = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = DateTime.Now;
                var fromDate = GlobalVariable.FromDate;
                var toDate = GlobalVariable.ToDate;
                var periodName = string.Empty;

                var paramater01 = string.Empty;
                var paramater02 = string.Empty;
                var paramater03 = string.Empty;
                DateTime? paramater04 = null;
                var paramater05 = string.Empty;
                var paramater06 = string.Empty;
                var paramater07 = string.Empty;
                var paramater08 = string.Empty;
                var paramater09 = string.Empty;
                DateTime? paramater10 = null;

                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmB04BCTC())
                    {
                        frmParam.Text = "Thuyết minh báo cáo tài chính";

                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            fromDate = frmParam.FromDate;
                            toDate = frmParam.ToDate;
                            periodName = frmParam.PeriodName;

                            paramater01 = frmParam.Paramater01;
                            paramater02 = frmParam.Paramater02;
                            paramater03 = frmParam.Paramater03;
                            paramater04 = frmParam.Paramater04;
                            paramater05 = frmParam.Paramater05;
                            paramater06 = frmParam.Paramater06;
                            paramater07 = frmParam.Paramater07;
                            paramater08 = frmParam.Paramater08;
                            paramater09 = frmParam.Paramater09;
                            paramater10 = frmParam.Paramater10;
                        }
                        else
                            return null;
                    }
                }

                lstResults = Model.GetB04BCTC(commonVariable.ReportList.ProcedureName, fromDate.ToShortDateString(), toDate.ToShortDateString(), currencyCode, amountType).ToList();

                if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                    oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", fromDate.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", toDate.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                    oRsTool.Parameters.Add("PeriodName", periodName);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", string.Format("Lập, ngày {0} tháng {1} năm {2}", reportDate.Day, reportDate.Month, reportDate.Year));
                if (!oRsTool.Parameters.ContainsKey("DecisionNo"))
                    oRsTool.Parameters.Add("DecisionNo", paramater01);
                if (!oRsTool.Parameters.ContainsKey("DecisionDate"))
                    oRsTool.Parameters.Add("DecisionDate", paramater04 == (DateTime?)null ? null : paramater04.Value.ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("HandOverDecision"))
                    oRsTool.Parameters.Add("HandOverDecision", paramater02);
                if (!oRsTool.Parameters.ContainsKey("Mission"))
                    oRsTool.Parameters.Add("Mission", paramater03);
                if (!oRsTool.Parameters.ContainsKey("CompanyName"))
                    oRsTool.Parameters.Add("CompanyName", GlobalVariable.CompanyName);
                if (!oRsTool.Parameters.ContainsKey("CompanyParentName"))
                    oRsTool.Parameters.Add("CompanyParentName", "Bộ công thương");
                if (!oRsTool.Parameters.ContainsKey("Paramater05"))
                    oRsTool.Parameters.Add("Paramater05", paramater05);
                if (!oRsTool.Parameters.ContainsKey("Paramater06"))
                    oRsTool.Parameters.Add("Paramater06", paramater06);
                if (!oRsTool.Parameters.ContainsKey("Paramater07"))
                    oRsTool.Parameters.Add("Paramater07", paramater07);
                if (!oRsTool.Parameters.ContainsKey("Paramater08"))
                    oRsTool.Parameters.Add("Paramater08", paramater08);
                if (!oRsTool.Parameters.ContainsKey("Paramater09"))
                    oRsTool.Parameters.Add("Paramater09", paramater09);
                if (!oRsTool.Parameters.ContainsKey("Paramater10"))
                    oRsTool.Parameters.Add("Paramater10", paramater10 == (DateTime?)null ? null : paramater04.Value.ToString("dd/MM/yyyy"));
                if (amountType == 1)
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                }
                else
                {
                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                }
                if (!oRsTool.Parameters.ContainsKey("CurrencyNegativePattern"))
                    oRsTool.Parameters.Add("CurrencyNegativePattern", _globalVariable.CurrencyNegativePattern);

                return lstResults;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        #endregion
    }
}
