using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using DevExpress.XtraEditors;
using RSSHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSD.AccountingSoft.Report.ReportClass
{
    public class SettlementReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;

        public SettlementReport()
        {
            _globalVariable = new GlobalVariable();
            Model = new TSD.AccountingSoft.Model.Model();
        }

        public IList<ReportB01CIIModel> GetReportB01CII(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<ReportB01CIIModel> lstResult = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB01CII())
                {
                    frmParam.Text = @"Báo cáo quyết toán phần II";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        string FromDate = DateTime.Parse(frmParam.FromDate).ToShortDateString();
                        string ToDate = DateTime.Parse(frmParam.ToDate).ToShortDateString();

                        lstResult = Model.GetB01CIIWithStoreProdure(commonVariable.ReportList.ProcedureName, FromDate, ToDate);
                        if (lstResult != null)
                        {
                            decimal defaultExchange = 1;
                            if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                                oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                            if (!oRsTool.Parameters.ContainsKey("FromDate"))
                                oRsTool.Parameters.Add("FromDate", frmParam.FromDate);
                            if (!oRsTool.Parameters.ContainsKey("ToDate"))
                                oRsTool.Parameters.Add("ToDate", frmParam.ToDate);
                            if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                                oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
                            if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                                oRsTool.Parameters.Add("PeriodName", frmParam.PeriodName);
                            if (!oRsTool.Parameters.ContainsKey("ExchangeRateLastYear"))
                                oRsTool.Parameters.Add("ExchangeRateLastYear", lstResult.FirstOrDefault().ExchangeRateLastYear == defaultExchange ? 0 : lstResult.FirstOrDefault().ExchangeRateLastYear);
                            if (!oRsTool.Parameters.ContainsKey("ExchangeRateThisYear"))
                                oRsTool.Parameters.Add("ExchangeRateThisYear", lstResult.FirstOrDefault().ExchangeRateThisYear == defaultExchange ? 0 : lstResult.FirstOrDefault().ExchangeRateThisYear);
                        }
                    }
                }
            }
            return lstResult;
        }

        public IList<ReportB01CIModel> GetReportB01CI(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<ReportB01CIModel> lstResult = new List<ReportB01CIModel>();
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB01CI())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        lstResult = Model.GetB01CIWithStoreProdure(commonVariable.ReportList.ProcedureName, frmParam.FromDate, frmParam.ToDate);
                        if (lstResult != null)
                        {
                            decimal defaultExchange = 1;
                            if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                                oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                            if (!oRsTool.Parameters.ContainsKey("FromDate"))
                                oRsTool.Parameters.Add("FromDate", frmParam.FromDate.ToString("dd/MM/yyyy"));
                            if (!oRsTool.Parameters.ContainsKey("ToDate"))
                                oRsTool.Parameters.Add("ToDate", frmParam.ToDate.ToString("dd/MM/yyyy"));
                            if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                                oRsTool.Parameters.Add("PeriodName", frmParam.PeriodName);
                            if (!oRsTool.Parameters.ContainsKey("ExchangeRateLastYear"))
                                oRsTool.Parameters.Add("ExchangeRateLastYear", lstResult.FirstOrDefault().ExchangeRateLastYear == defaultExchange ? 0 : lstResult.FirstOrDefault().ExchangeRateLastYear);
                            if (!oRsTool.Parameters.ContainsKey("ExchangeRateThisYear"))
                                oRsTool.Parameters.Add("ExchangeRateThisYear", lstResult.FirstOrDefault().ExchangeRateThisYear == defaultExchange ? 0 : lstResult.FirstOrDefault().ExchangeRateThisYear);
                        }
                    }
                    else
                        return null;
                }
            }
            return lstResult;
        }

        public IList<ReportS104HModel> GetReportS104H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<ReportS104HModel> lstResult = new List<ReportS104HModel>();
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = amountType == 1
                ? GlobalVariable.CurrencyMain
                : GlobalVariable.CurrencyViewReport;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB01CI())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        lstResult = Model.GetS104HWithStoreProdure(commonVariable.ReportList.ProcedureName, frmParam.FromDate, frmParam.ToDate, currencyCode, amountType);
                        if (lstResult != null)
                        {
                            //decimal defaultExchange = 1;
                            //if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                            //    oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(_globalVariable.PostedDate).ToString("dd/MM/yyyy"));
                            //if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            //    oRsTool.Parameters.Add("FromDate", frmParam.FromDate.ToString("dd/MM/yyyy"));
                            //if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            //    oRsTool.Parameters.Add("ToDate", frmParam.ToDate.ToString("dd/MM/yyyy"));
                            //if (!oRsTool.Parameters.ContainsKey("ExchangeRateLastYear"))
                            //    oRsTool.Parameters.Add("ExchangeRateLastYear", lstResult.FirstOrDefault().ExchangeRateLastYear == defaultExchange ? 0 : lstResult.FirstOrDefault().ExchangeRateLastYear);
                            //if (!oRsTool.Parameters.ContainsKey("ExchangeRateThisYear"))
                            //    oRsTool.Parameters.Add("ExchangeRateThisYear", lstResult.FirstOrDefault().ExchangeRateThisYear == defaultExchange ? 0 : lstResult.FirstOrDefault().ExchangeRateThisYear);
                        }
                    }
                    else
                        return null;
                }
            }
            return lstResult;
        }

        public IList<ReportB01CII01Model> GetReportB01CII01(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<ReportB01CII01Model> list = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmB01CII())
                {
                    frmParam.Text = @"Báo cáo quyết toán phần II";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        string FromDate = DateTime.Parse(frmParam.FromDate).ToShortDateString();
                        string ToDate = DateTime.Parse(frmParam.ToDate).ToShortDateString();

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", frmParam.FromDate);
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                        list = Model.GetB01CII01WithStoreProdure(commonVariable.ReportList.ProcedureName, FromDate, ToDate);
                    }
                }
            }
            return list;
        }
    }
}
