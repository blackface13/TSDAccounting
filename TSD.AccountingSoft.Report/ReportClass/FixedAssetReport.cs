/***********************************************************************
 * <copyright file="FixedAssetReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 10/9/2014    LinhMC               Sửa lại toàn bộ method check điều kiện nếu nạp lại dữ liệu thì ko show form param
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using RSSHelper;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// FixedAssetReport
    /// </summary>
    public class FixedAssetReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetReport"/> class.
        /// </summary>
        public FixedAssetReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();

        }

        /// <summary>
        /// Báo cáo tình hình tăng giảm tài sản cố định
        /// Gets the report fixed asset B03 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetB03HModel> GetReportFixedAssetB03H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetB03HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetB03H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        //list = Model.GetFixedAssetB03H(GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode);
                        list = amountType == 1 ? Model.GetFixedAssetB03HAmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB03H(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
                    }
                }
            }
            else
            {
                list = amountType == 1 ? Model.GetFixedAssetB03HAmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB03H(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
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
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        /// <summary>
        /// Báo cáo tình hình tăng giảm tài sản cố định
        /// Gets the report fixed asset B03 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetB01Model> GetReportFixedAssetB01(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetB01Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetB01())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = amountType == 1 ? Model.GetFixedAssetB01AmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB01(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
                    }
                }
            }
            else
            {
                //list = Model.GetFixedAssetB01(GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode);
                list = amountType == 1 ? Model.GetFixedAssetB01AmountType(GlobalVariable.FromDate.ToShortDateString(),
                              GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB01(GlobalVariable.FromDate.ToShortDateString(),
                              GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
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
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
                    oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
                if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
                    oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
                if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
                    oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
                    oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
                    oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
                // JobOfInventoryName 
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
                    oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
                    oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        /// <summary>
        /// Báo cáo tăng tài sản cố định
        /// Gets the report fixed asset B02.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetB02Model> GetReportFixedAssetB02(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {

            IList<FixedAssetB02Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = _globalVariable.PostedDate;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetB02())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

                        list = amountType == 1
                            ? Model.GetFixedAssetB02AmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits)
                            : Model.GetFixedAssetB02(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);

                    }
                }
            }
            else
            {
                list = amountType == 1
                            ? Model.GetFixedAssetB02AmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits)
                            : Model.GetFixedAssetB02(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", reportDate);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
                    oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
                if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
                    oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
                if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
                    oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
                    oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
                    oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
                // JobOfInventoryName 
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
                    oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
                    oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        /// <summary>
        /// Gets the report fixed asset c55a hd.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetC55aHDModel> GetReportFixedAssetC55aHD(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetC55aHDModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetS31HTreeList())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = frmParam.FromDate;
                        GlobalVariable.ToDate = frmParam.ToDate;
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        frmParam.Text = "Báo cáo hao mòn TSCĐ";

                        var listFixedAssetCategoryId = frmParam.SelectedFixedAssetCategory;
                        if (!oRsTool.Parameters.ContainsKey("ListFixedAssetCategoryId"))
                            oRsTool.Parameters.Add("ListFixedAssetCategoryId", listFixedAssetCategoryId);

                        //list = Model.GetFixedAssetC55aHD(GlobalVariable.FromDate.ToShortDateString(),
                        //        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
                        //    listFixedAssetCategoryId, currencyCode);

                        list = amountType == 1
                            ? Model.GetFixedAssetC55aHDAmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId, listFixedAssetCategoryId, currencyDecimalDigits)
                            : Model.GetFixedAssetC55aHD(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
                          listFixedAssetCategoryId, currencyCode);


                    }
                }
            }
            else
            {
                var listFixedAssetCategoryId = oRsTool.Parameters["ListFixedAssetCategoryId"].ToString();
                list = Model.GetFixedAssetC55aHD(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
                            listFixedAssetCategoryId, currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
                    oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
                if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
                    oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
                if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
                    oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
                    oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
                    oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
                // JobOfInventoryName 
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
                    oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
                    oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        /// <summary>
        /// Gets the report fixed asset S31 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetS31HModel> GetReportFixedAssetS31H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetS31HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetS31HTreeList())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = frmParam.FromDate;
                        GlobalVariable.ToDate = frmParam.ToDate;
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

                        var listFixedAssetCategoryId = frmParam.SelectedFixedAssetCategory;
                        if (!oRsTool.Parameters.ContainsKey("ListFixedAssetCategoryId"))
                            oRsTool.Parameters.Add("ListFixedAssetCategoryId", listFixedAssetCategoryId);

                        list = Model.GetFixedAssetS31H(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
                            listFixedAssetCategoryId, currencyCode);
                    }
                }
            }
            else
            {
                var listFixedAssetCategoryId = oRsTool.Parameters["ListFixedAssetCategoryId"].ToString();
                list = Model.GetFixedAssetS31H(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
                            listFixedAssetCategoryId, currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        /// <summary>
        /// Báo cáo kiểm kê tài sản cố định
        /// Gets the report fixed asset fa inventory.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetFAInventoryModel> GetReportFixedAssetFAInventory(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetFAInventoryModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventory())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

                        list = Model.GetFixedAssetFAInventoryAmountType(GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                        //list = amountType == 1 ? Model.GetFixedAssetFAInventoryAmountType(GlobalVariable.FromDate.ToShortDateString(),
                        //        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventory(GlobalVariable.FromDate.ToShortDateString(),
                        //        GlobalVariable.ToDate.ToShortDateString(), currencyCode, currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = Model.GetFixedAssetFAInventoryAmountType(GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                //list = amountType == 1 ? Model.GetFixedAssetFAInventoryAmountType(GlobalVariable.FromDate.ToShortDateString(),
                //                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventory(GlobalVariable.FromDate.ToShortDateString(),
                //                GlobalVariable.ToDate.ToShortDateString(), currencyCode, currencyDecimalDigits);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);

                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
                    oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
                if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
                    oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
                if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
                    oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
                    oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
                    oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
                // JobOfInventoryName 
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
                    oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
                    oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
            }
            return list;
        }

        /// <summary>
        /// Báo cáo kiểm kê tài sản cố định trên 3000USD
        /// Gets the report fixed asset fa inventory3000.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetFAInventoryModel> GetReportFixedAssetFAInventory3000(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {

            IList<FixedAssetFAInventoryModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventory())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = amountType == 1
                            ? Model.GetFixedAssetFAInventoryAmountType3000(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString())
                            : Model.GetFixedAssetFAInventory3000(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
                    }
                }
            }
            else
            {
                list = amountType == 1
                            ? Model.GetFixedAssetFAInventoryAmountType3000(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString())
                            : Model.GetFixedAssetFAInventory3000(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
                    oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
                if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
                    oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
                if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
                    oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

                if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
                    oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
                    oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
                // JobOfInventoryName 
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
                    oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
                    oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
            }
            return list;
        }

        public IList<FixedAssetFAInventoryHouseModel> GetReportFixedAssetFAInventoryHouse(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetFAInventoryHouseModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryHouse())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var totalArea = frmParam.AreaOfBuilding.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var housingArea = frmParam.HousingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var workingArea = frmParam.WorkingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var guestHouseArea = frmParam.GuestHouseArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var vacancyArea = frmParam.OccupiedArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var otherArea = frmParam.OtherArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var accountBook = frmParam.AccountingValue.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var other = frmParam.Attachments;

                        oRsTool.Parameters.Add("TotalArea", totalArea);
                        oRsTool.Parameters.Add("HousingArea", housingArea);
                        oRsTool.Parameters.Add("WorkingArea", workingArea);
                        oRsTool.Parameters.Add("GuestHouseArea", guestHouseArea);
                        oRsTool.Parameters.Add("VacancyArea", vacancyArea);
                        oRsTool.Parameters.Add("OtherArea", otherArea);
                        oRsTool.Parameters.Add("AccountBook", accountBook);
                        oRsTool.Parameters.Add("Other", other);
                        oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetFixedAssetFAInventoryHouseAmountType(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = amountType == 1 ? Model.GetFixedAssetFAInventoryHouseAmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryHouse(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        public IList<FixedAssetFAInventoryHouseModel> GetReportFixedAssetFAB01House(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetFAInventoryHouseModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryHouseB01())
                {
                    frmParam.Text = "Danh mục trụ sở làm việc , nhà ở cơ sở hoạt động sự nghiệp đề nghị xử lý ";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var totalArea = frmParam.AreaOfBuilding.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var housingArea = frmParam.HousingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var workingArea = frmParam.WorkingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var guestHouseArea = frmParam.GuestHouseArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var vacancyArea = frmParam.OccupiedArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var otherArea = frmParam.OtherArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var accountBook = frmParam.AccountingValue.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
                        var other = frmParam.Attachments;


                        oRsTool.Parameters.Add("TotalArea", totalArea);
                        oRsTool.Parameters.Add("HousingArea", housingArea);
                        oRsTool.Parameters.Add("WorkingArea", workingArea);
                        oRsTool.Parameters.Add("GuestHouseArea", guestHouseArea);
                        oRsTool.Parameters.Add("VacancyArea", vacancyArea);
                        oRsTool.Parameters.Add("OtherArea", otherArea);
                        oRsTool.Parameters.Add("AccountBook", accountBook);
                        oRsTool.Parameters.Add("Other", other);

                        oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetFixedAssetFAB01House(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = amountType == 1 ? Model.GetFixedAssetFAB01House(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryHouse(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        /// <summary>
        /// Báo cáo kiểm kê tài sản cố định
        /// Gets the report fixed asset fa inventory.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetFAInventoryCarModel> GetReportFixedAssetFAInventoryCar(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetFAInventoryCarModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetFixedAssetFAInventoryCarAmountType(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = amountType == 1 ? Model.GetFixedAssetFAInventoryCarAmountType(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryCar(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        public IList<FixedAssetFAInventoryCarModel> GetReportFixedAssetFAB01Car(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetFAInventoryCarModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
                {
                    frmParam.Text = "Danh mục xe ô tô đề nghị xử lý ";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetFixedAssetFAB01Car(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = amountType == 1 ? Model.GetFixedAssetFAB01Car(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryCar(GlobalVariable.FromDate.ToShortDateString(),
                                GlobalVariable.ToDate.ToShortDateString(), currencyCode);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        public IList<FixedAsset30KPart2Model> GetFixedAsset30KPart2(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAsset30KPart2Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
                {
                    frmParam.Text = "Báo cáo kê khai tài sản cố định có nguyên giá 30.000 trở lên ( Mẫu mới)";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetFixedAsset30KPart2(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = Model.GetFixedAsset30KPart2(GlobalVariable.FromDate.ToShortDateString(),
                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        public IList<FixedAssetB03H30KModel> GetFixedAssetB03H30K(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetB03H30KModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
                {
                    frmParam.Text = "Báo cáo tình hình tăng, giảm tài sản nhà nước";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetFixedAssetB03H30K(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = Model.GetFixedAssetB03H30K(GlobalVariable.FromDate.ToShortDateString(),
                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        public IList<FixedAsset30KPart2Model> GetFixedAssetFAB0130KPart2(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAsset30KPart2Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
                {
                    frmParam.Text = "Danh mục tài sản khác (trừ trụ sở làm việc và xe ô tô) đề nghị xử lý ";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        checked
                        {

                        }
                        list = Model.GetFixedAssetFAB0130KPart2(GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
                    }
                }
            }
            else
            {
                list = Model.GetFixedAssetFAB0130KPart2(GlobalVariable.FromDate.ToShortDateString(),
                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
            }
            return list;
        }

        //public IList<FixedAssetCardModel> GetReportFixedAssetCard(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (commonVariable.RefIdList == null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }

        //    IList<FixedAssetCardModel> list = Model.GetFixedAssetCard(commonVariable.RefIdList, currencyDecimalDigits);


        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);

        //        if (!oRsTool.Parameters.ContainsKey("CurrencyLocal"))
        //            oRsTool.Parameters.Add("CurrencyLocal", _globalVariable.CurrencyLocal);
        //    }

        //    return list;
        //}

        public IList<FixedAssetCardsModel> GetReportFixedAssetCard(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
            if (commonVariable.RefIdList == null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }

            IList<FixedAssetCardsModel> list = Model.GetFixedAssetCards(commonVariable.RefIdList, currencyDecimalDigits);

            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
                    oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
                if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
                    oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);

                if (!oRsTool.Parameters.ContainsKey("CurrencyLocal"))
                    oRsTool.Parameters.Add("CurrencyLocal", _globalVariable.CurrencyLocal);


                var fixedAsset = Model.GetFixedAssetById(list.FirstOrDefault().FixedAssetId);
                if (!oRsTool.Parameters.ContainsKey("PurchasedDate"))
                    oRsTool.Parameters.Add("PurchasedDate", fixedAsset?.PurchasedDate.ToShortDateString() ?? _globalVariable.PostedDate);
            }

            return list;
        }

        public IList<FixedAssetS26HModel> GetReportFixedAssetS26H(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<FixedAssetS26HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var fixedAssetType = 0;
            var department = "";
            var fixedAssetTypeName = "";
            var fromDate = "";
            var toDate = "";
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmXtraFixedAssetS26H())
                {
                    frmParam.Text = "Sổ theo dõi TSCĐ và CCDC tại nơi sử dụng";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        fixedAssetType = frmParam.FixedAssetType + 1;
                        department = frmParam.DepartmentName;
                        fixedAssetTypeName = frmParam.FixedAssetTypeName;
                        fromDate = frmParam.FromDate;
                        toDate = frmParam.ToDate;

                        list = Model.GetFixedAssetS26H(commonVariable.ReportList.ProcedureName, frmParam.FromDate, frmParam.ToDate, currencyCode, amountType, frmParam.DepartmentCode, frmParam.FixedAssetCategoryId, fixedAssetType);
                    }
                }
            }

            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", fromDate);
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", toDate);
                if (!oRsTool.Parameters.ContainsKey("FixedAssetType"))
                    oRsTool.Parameters.Add("FixedAssetType", fixedAssetType);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", DateTime.UtcNow.AddDays(7).ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("DepartmentName"))
                    oRsTool.Parameters.Add("DepartmentName", department == null ? "" : department);
                if (!oRsTool.Parameters.ContainsKey("FixedAssetTypeName"))
                    oRsTool.Parameters.Add("FixedAssetTypeName", fixedAssetTypeName == null ? "" : fixedAssetTypeName);
            }
            return list;
        }

        /// <summary>
        /// sổ tài sản cố định
        /// </summary>
        public IList<FixedAssetS24HModel> GetReportFixedAssetS24H(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<FixedAssetS24HModel> lstResults = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            DepartmentModel department = null;
            List<FixedAssetCategoryModel> lstFixedAssetCategory = null;
            string fixedAssetIds = null;
            string fromDate = GlobalVariable.FromDate.ToShortDateString();
            string toDate = GlobalVariable.ToDate.ToShortDateString();
            string periodName = "";
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFixedAssetS24H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        fromDate = frmParam.FromDate;
                        toDate = frmParam.ToDate;
                        department = frmParam.Department;
                        lstFixedAssetCategory = frmParam.SelectedFixedAssetCategorys;
                        fixedAssetIds = frmParam.FixedAssetIds;
                        periodName = frmParam.PeriodName;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            lstResults = Model.GetFixedAssetS24H(
                commonVariable.ReportList.ProcedureName
                , currencyCode
                , amountType
                , fromDate
                , toDate
                , department.DepartmentCode
                , string.Join(",", lstFixedAssetCategory.Select(s=>"'" + s.FixedAssetCategoryCode + "'").ToArray())
                , fixedAssetIds
            ).ToList();

            if (lstResults.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                    oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                    oRsTool.Parameters.Add("PeriodName", periodName);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", fromDate);
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", toDate);
                if (!oRsTool.Parameters.ContainsKey("FixedAssetCategoryName"))
                    oRsTool.Parameters.Add("FixedAssetCategoryName", string.Join(",", lstFixedAssetCategory.Select(s=>s.FixedAssetCategoryName).ToArray()));
                if (!oRsTool.Parameters.ContainsKey("DepartmentName"))
                    oRsTool.Parameters.Add("DepartmentName", department.DepartmentName);
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

            return lstResults;
        }
    }
}
