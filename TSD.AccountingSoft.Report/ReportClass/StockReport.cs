/***********************************************************************
 * <copyright file="StockReport.cs" company="BUCA JSC">
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
using System.Windows.Forms;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using DevExpress.XtraEditors;
using RSSHelper;


namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// StockReport
    /// </summary>
    public class StockReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;
        /// <summary>
        /// Initializes a new instance of the <see cref="StockReport"/> class.
        /// </summary>
        public StockReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();
        }

        /// <summary>
        /// Tồn kho
        /// Gets the report B14 q.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<B14QModel> GetReportB14Q(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<B14QModel> list = null;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var reportDate = _globalVariable.PostedDate;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB14Q())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        var listStockId = frmParam.ListStockId;
                        var stockName = frmParam.StockName;
                        var accountCode = frmParam.AccountCode;
                        
                        if (accountCode == " ")
                        {
                            
                            if (!oRsTool.Parameters.ContainsKey("AccountCode"))
                                oRsTool.Parameters.Add("AccountCode", "152,153");
                        }
                        else
                        {// cần xử lý nhiều tền nhiều kho

                        }
                        if (!oRsTool.Parameters.ContainsKey("StockName"))
                            oRsTool.Parameters.Add("StockName", stockName);
                        if (!oRsTool.Parameters.ContainsKey("ListStockId"))
                            oRsTool.Parameters.Add("ListStockId", listStockId);
                        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                            oRsTool.Parameters.Add("IsTotalBandInNewPage", frmParam.IsTotalBandInNewPage);

                        list = Model.GetB14QWithStoreProdure(commonVariable.ReportList.ProcedureName,
                            GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(),
                            currencyCode, accountCode, listStockId, amountType);

                        accountCode = accountCode +  " - " + frmParam.AccountName;
                        if (!oRsTool.Parameters.ContainsKey("AccountCode"))
                            oRsTool.Parameters.Add("AccountCode", accountCode);
                    }
                }
            }
            else
            {
                var listStockId = oRsTool.Parameters["ListStockId"].ToString();
                var accountCode = oRsTool.Parameters["AccountCode"].ToString();
                list = Model.GetB14QWithStoreProdure(commonVariable.ReportList.ProcedureName,
                            GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(),
                            currencyCode, accountCode, listStockId, amountType);
            }
            if (list != null && list.Count > 0)
            {
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
            }
            return list;
        }

    }
}
