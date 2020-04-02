/***********************************************************************
 * <copyright file="SalaryReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 10/9/2014    LinhMC               Sửa lại toàn bộ method check điều kiện nếu nạp lại dữ liệu thì ko show form param
 * ************************************************************************/

using System;
using System.Linq;
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
    /// SalaryReport
    /// </summary>
    public class SalaryReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;
        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryReport"/> class.
        /// </summary>
        public SalaryReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();
        }


        /// <summary>
        /// Bảng sinh hoạt phí
        /// Gets the report a02 LDTL.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<A02LDTLModel> GetReportA02LDTL(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<A02LDTLModel> list = null;
            decimal numbershp = 0;
            decimal pckiemnhiem = 0;
            decimal pcvs = 0;
            decimal shp = 0;
            decimal trocapct = 0;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmA02LDTL())
                {
                    frmParam.ReporDate = _globalVariable.PostedDate;
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        list = Model.Get02LdtlWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString());
                    }
                    if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                        oRsTool.Parameters.Add("IsTotalBandInNewPage", frmParam.IsTotalBandInNewPage);
                }

            }
            else
            {
                list = Model.Get02LdtlWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString());
            }
            if (list != null && list.Count > 0)
            {
                decimal  baseOfSalary = Math.Round(list[0].BaseOfSalary, int.Parse(commonVariable.CurrencyDecimalDigits));
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("BaseOfSalary"))
                    oRsTool.Parameters.Add("BaseOfSalary", baseOfSalary);
                if (!oRsTool.Parameters.ContainsKey("CoefficientOfSalaryByArea"))
                    oRsTool.Parameters.Add("CoefficientOfSalaryByArea", commonVariable.CoefficientOfSalaryByArea);

                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", list[0].CalcDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ExchangeRate"))
                    oRsTool.Parameters.Add("ExchangeRate", list[0].ExchangeRate);
                if (!oRsTool.Parameters.ContainsKey("CurrencyAccounting"))
                    oRsTool.Parameters.Add("CurrencyAccounting", list[0].CurrencyCode);
                //Luon hieen tien DP
                if (!oRsTool.Parameters.ContainsKey("CurrencyLocal"))
                    oRsTool.Parameters.Add("CurrencyLocal", _globalVariable.CurrencyLocal);

                if (!oRsTool.Parameters.ContainsKey("CurrencyLocal"))
                    oRsTool.Parameters.Add("CurrencyLocal", _globalVariable.CurrencyLocal);

                foreach (var it in list)
                {
                    numbershp = numbershp + it.NumberSHP;
                    pckiemnhiem = pckiemnhiem + it.PCKiemNhiem ; 
                    pcvs = pcvs + it.PCVS ;
                    shp = shp + it.SHP ; 
                    trocapct = trocapct + it.TroCapCT ;
                }
                numbershp =   Math.Round(numbershp * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                pckiemnhiem = Math.Round(pckiemnhiem * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                pcvs =  Math.Round(pcvs * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                shp = Math.Round(shp * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                trocapct =  Math.Round(trocapct * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));


                if (!oRsTool.Parameters.ContainsKey("NumberSHP"))
                    oRsTool.Parameters.Add("NumberSHP", numbershp);
                if (!oRsTool.Parameters.ContainsKey("PCKiemNhiem"))
                    oRsTool.Parameters.Add("PCKiemNhiem", pckiemnhiem);
                if (!oRsTool.Parameters.ContainsKey("PCVS"))
                    oRsTool.Parameters.Add("PCVS", pcvs);
                if (!oRsTool.Parameters.ContainsKey("SHP"))
                    oRsTool.Parameters.Add("SHP", shp);
                if (!oRsTool.Parameters.ContainsKey("TroCapCT"))
                    oRsTool.Parameters.Add("TroCapCT", trocapct);
                if (!oRsTool.Parameters.ContainsKey("TotalSHP"))
                    oRsTool.Parameters.Add("TotalSHP", trocapct + shp + pcvs + pckiemnhiem);

                if (!oRsTool.Parameters.ContainsKey("CurrencyDecimalDigits"))
                    oRsTool.Parameters.Add("CurrencyDecimalDigits", commonVariable.CurrencyDecimalDigits);

                var globalVariable = new GlobalVariable();
                if(globalVariable.CurrencyCodeOfSalary != list[0].CurrencyCode)
                //if (GlobalVariable.CurrencyViewReport != list[0].CurrencyCode)
                {

                    list = new List<A02LDTLModel>();
                }
            }
            return list;
        }

        public IList<A02LDTLModel> GetReportA02LDTLRETAIL(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<A02LDTLModel> list = null;
            decimal numbershp = 0;
            decimal pckiemnhiem = 0;
            decimal pcvs = 0;
            decimal shp = 0;
            decimal trocapct = 0;


            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmA02LDTLRETAIL())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        if (frmParam.WhereClauseListEmployee!="")
                            list = Model.Get02LdtlIsRetailWithStoreProdure(commonVariable.ReportList.ProcedureName, frmParam.FromDate, frmParam.ToDate, frmParam.WhereClauseListEmployee, true);
                         if (frmParam.WhereClauseListRefNo!="")
                             list = Model.Get02LdtlIsRetailWithStoreProdure(commonVariable.ReportList.ProcedureName, frmParam.FromDate, frmParam.ToDate, frmParam.WhereClauseListRefNo, false);
                        if (list == null)
                            list = new List<A02LDTLModel>();
                    }
                    if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                        oRsTool.Parameters.Add("IsTotalBandInNewPage", frmParam.IsTotalBandInNewPage);
                }
            }
            else
            {
                list = Model.Get02LdtlWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString()) ?? new List<A02LDTLModel>();
            }
            if (list != null && list.Count > 0)
            {
                decimal baseOfSalary = Math.Round(list[0].BaseOfSalary, int.Parse(commonVariable.CurrencyDecimalDigits));
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
                if (!oRsTool.Parameters.ContainsKey("BaseOfSalary"))
                    oRsTool.Parameters.Add("BaseOfSalary", baseOfSalary);
                if (!oRsTool.Parameters.ContainsKey("CoefficientOfSalaryByArea"))
                    oRsTool.Parameters.Add("CoefficientOfSalaryByArea", commonVariable.CoefficientOfSalaryByArea);

                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", list[0].CalcDate.ToShortDateString()); 
                if (!oRsTool.Parameters.ContainsKey("ExchangeRate"))
                    oRsTool.Parameters.Add("ExchangeRate", list[0].ExchangeRate);
                if (!oRsTool.Parameters.ContainsKey("CurrencyAccounting"))
                    oRsTool.Parameters.Add("CurrencyAccounting", list[0].CurrencyCode);
                //Luon hieen tien DP
                if (!oRsTool.Parameters.ContainsKey("CurrencyLocal"))
                    oRsTool.Parameters.Add("CurrencyLocal", _globalVariable.CurrencyLocal);


                foreach (var it in list)
                {
                    numbershp = numbershp + it.NumberSHP;
                    pckiemnhiem = pckiemnhiem + it.PCKiemNhiem;
                    pcvs = pcvs + it.PCVS;
                    shp = shp + it.SHP;
                    trocapct = trocapct + it.TroCapCT;
                }
                numbershp = Math.Round(numbershp * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                pckiemnhiem = Math.Round(pckiemnhiem * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                pcvs = Math.Round(pcvs * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                shp = Math.Round(shp * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));
                trocapct = Math.Round(trocapct * list[0].ExchangeRate, int.Parse(commonVariable.CurrencyDecimalDigits));


                if (!oRsTool.Parameters.ContainsKey("NumberSHP"))
                    oRsTool.Parameters.Add("NumberSHP", numbershp);
                if (!oRsTool.Parameters.ContainsKey("PCKiemNhiem"))
                    oRsTool.Parameters.Add("PCKiemNhiem", pckiemnhiem);
                if (!oRsTool.Parameters.ContainsKey("PCVS"))
                    oRsTool.Parameters.Add("PCVS", pcvs);
                if (!oRsTool.Parameters.ContainsKey("SHP"))
                    oRsTool.Parameters.Add("SHP", shp);
                if (!oRsTool.Parameters.ContainsKey("TroCapCT"))
                    oRsTool.Parameters.Add("TroCapCT", trocapct);
                if (!oRsTool.Parameters.ContainsKey("TotalSHP"))
                    oRsTool.Parameters.Add("TotalSHP", trocapct + shp + pcvs + pckiemnhiem);

                if (!oRsTool.Parameters.ContainsKey("CurrencyDecimalDigits"))
                    oRsTool.Parameters.Add("CurrencyDecimalDigits", commonVariable.CurrencyDecimalDigits);

                var globalVariable = new GlobalVariable();
                if (globalVariable.CurrencyCodeOfSalary != list[0].CurrencyCode)
                //if (GlobalVariable.CurrencyViewReport != list[0].CurrencyCode)
                {
                    list = new List<A02LDTLModel>();
                }
            }
            return list;
        }




    }
}
