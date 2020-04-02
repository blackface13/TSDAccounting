/***********************************************************************
 * <copyright file="CashReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangNK@buca.vn
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
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;
using DevExpress.XtraEditors;
using RSSHelper;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// CashReport
    /// </summary>
    public class CashReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;

        /// <summary>
        /// Initializes a new instance of the <see cref="CashReport"/> class.
        /// </summary>
        public CashReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();
        }

        /// <summary>
        /// Gets the cash report S11 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<CashReportModel> GetCashReportS11H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<CashReportModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS11H())
                {
                    frmParam.Text = @"Sổ chi quỹ tiền mặt";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        var accountNumber = frmParam.AccountCode;
                        if (!oRsTool.Parameters.ContainsKey("Account"))
                            oRsTool.Parameters.Add("Account",
                                "Tài khoản: " + accountNumber + " - " + frmParam.AccountName);
                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", accountNumber);

                        list = Model.GetCashS12HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, currencyCode, false, null);
                        
                    }
                }
            }
            else
            {
                var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
                list = Model.GetCashS12HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, currencyCode, false, null);
            }

            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                if (!oRsTool.Parameters.ContainsKey("Year"))
                    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                // ThoDD add trạng thái chuyển sang trang sau
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                //làm Footer  để có cấu trúc sang trang
                if (!oRsTool.Parameters.ContainsKey("footClosing"))
                    oRsTool.Parameters.Add("footClosing", list[list.Count - 1].RestAmount);
                list.RemoveAt(list.Count-1);
                if (!oRsTool.Parameters.ContainsKey("footReceipt"))
                    oRsTool.Parameters.Add("footReceipt", list[list.Count-1].ReceiptAmount);
                if (!oRsTool.Parameters.ContainsKey("footPay"))
                    oRsTool.Parameters.Add("footPay", list[list.Count - 1].PayAmount);
                if (!oRsTool.Parameters.ContainsKey("footExist"))
                    oRsTool.Parameters.Add("footExist", list[list.Count - 1].RestAmount);

                //list.RemoveAt(list.Count - 1);
                //list.RemoveAt(list.Count - 1);

            }
            return list;
        }

        /// <summary>
        /// Gets the cash report S11 ah.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<CashReportModel> GetCashReportS11AH(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<CashReportModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS11AH())
                {
                    frmParam.Text = @"Sổ chi tiết tiền mặt";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        var accountNumber = frmParam.AccountCode;



                        if (!oRsTool.Parameters.ContainsKey("Account"))
                            oRsTool.Parameters.Add("Account","Tài khoản: " + accountNumber + " - " + frmParam.AccountName);

                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", accountNumber);

                        var correspondingAccountNumber = frmParam.CorrespondingAccountNumber;
                        if (!oRsTool.Parameters.ContainsKey("CorrespondingAccountNumber"))
                            oRsTool.Parameters.Add("CorrespondingAccountNumber", correspondingAccountNumber);

                        list = Model.GetCashS12AHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, correspondingAccountNumber, currencyCode, false, null);
                        
                    }
                }
            }
            else
            {
                var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
                var correspondingAccountNumber = oRsTool.Parameters["CorrespondingAccountNumber"].ToString();

                list = Model.GetCashS12AHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, correspondingAccountNumber, currencyCode, false, null);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                if (!oRsTool.Parameters.ContainsKey("Year"))
                    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);


                if (!oRsTool.Parameters.ContainsKey("ckClosing"))
                    oRsTool.Parameters.Add("ckClosing", list[list.Count-1].RestAmount);
                list.RemoveAt(list.Count - 1);
                if (!oRsTool.Parameters.ContainsKey("lkReceipt"))
                    oRsTool.Parameters.Add("lkReceipt", list[list.Count - 1].ReceiptAmount);
                if (!oRsTool.Parameters.ContainsKey("lkPayment"))
                    oRsTool.Parameters.Add("lkPayment", list[list.Count - 1].PayAmount);
                list.RemoveAt(list.Count - 1);
                if (!oRsTool.Parameters.ContainsKey("psReceipt"))
                    oRsTool.Parameters.Add("psReceipt", list[list.Count - 1].ReceiptAmount);
                if (!oRsTool.Parameters.ContainsKey("psPayment"))
                    oRsTool.Parameters.Add("psPayment", list[list.Count - 1].PayAmount);
                list.RemoveAt(list.Count - 1);
                // ThoDD add trạng thái chuyển sang trang sau
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
               
            }
            return list;
        }

        /// <summary>
        /// Gets the cash report S12 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<CashReportModel> GetCashReportS12H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<CashReportModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            bool isBank = false;
            int? bankId = null;

            var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS12H())
                {
                    frmParam.Text = @"Sổ chi tiền gửi ngân hàng";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        var accountNumber = frmParam.AccountCode;
                        isBank = frmParam.IsBank;
                        bankId = frmParam.BankId;


                        if (!oRsTool.Parameters.ContainsKey("Account"))
                            oRsTool.Parameters.Add("Account", "Tài khoản: " + accountNumber + " - " + frmParam.AccountName);

                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", accountNumber);

                        if (!oRsTool.Parameters.ContainsKey("BankName"))
                            oRsTool.Parameters.Add("BankName", frmParam.BankName);

                        list = Model.GetCashS12HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, currencyCode, isBank, bankId);

                    }
                }
            }
            else
            {
                var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
                list = Model.GetCashS12HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, currencyCode, false, null);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("Year"))
                    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                // ThoDD add trạng thái chuyển sang trang sau
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                //làm Footer  để có cấu trúc sang trang
                if (!oRsTool.Parameters.ContainsKey("footClosing"))
                    oRsTool.Parameters.Add("footClosing", list[list.Count - 1].RestAmount);
                list.RemoveAt(list.Count - 1);
                if (!oRsTool.Parameters.ContainsKey("footReceipt"))
                    oRsTool.Parameters.Add("footReceipt", list[list.Count - 1].ReceiptAmount);
                if (!oRsTool.Parameters.ContainsKey("footPay"))
                    oRsTool.Parameters.Add("footPay", list[list.Count - 1].PayAmount);
                if (!oRsTool.Parameters.ContainsKey("footExist"))
                    oRsTool.Parameters.Add("footExist", list[list.Count - 1].RestAmount);

                list.RemoveAt(list.Count - 1);
                list.RemoveAt(list.Count - 1);

            }
            return list;
        }


        /// <summary>
        /// Gets the cash report S12 ah.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<CashReportModel> GetCashReportS12AH(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<CashReportModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            var isBank = false;
            int? bankId = null;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS12AH())
                {
                    frmParam.Text = @"Sổ chi tiết tiền gửi ngân hàng";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        var accountNumber = frmParam.AccountCode;
                        isBank = frmParam.IsBank;
                        bankId = frmParam.BankId;

                        if (!oRsTool.Parameters.ContainsKey("Account"))
                            oRsTool.Parameters.Add("Account", "Tài khoản: " + accountNumber + " - " + frmParam.AccountName);

                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", accountNumber);
                        
                        var correspondingAccountNumber = frmParam.CorrespondingAccountNumber;
                        if (!oRsTool.Parameters.ContainsKey("CorrespondingAccountNumber"))
                            oRsTool.Parameters.Add("CorrespondingAccountNumber", correspondingAccountNumber);

                        if (!oRsTool.Parameters.ContainsKey("BankName"))
                            oRsTool.Parameters.Add("BankName", frmParam.BankName);

                        list = Model.GetCashS12AHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                            GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, correspondingAccountNumber, currencyCode, isBank, bankId);
                        
                    }
                }
            }
            else
            {
                var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
                var correspondingAccountNumber = oRsTool.Parameters["CorrespondingAccountNumber"].ToString();
                list = Model.GetCashS12AHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
                       GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, correspondingAccountNumber, currencyCode, isBank, bankId);
            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit",
                        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("Year"))
                    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);

                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);




                if (!oRsTool.Parameters.ContainsKey("ckClosing"))
                    oRsTool.Parameters.Add("ckClosing", list[list.Count - 1].RestAmount);
                list.RemoveAt(list.Count - 1);
                if (!oRsTool.Parameters.ContainsKey("lkReceipt"))
                    oRsTool.Parameters.Add("lkReceipt", list[list.Count - 1].ReceiptAmount);
                if (!oRsTool.Parameters.ContainsKey("lkPayment"))
                    oRsTool.Parameters.Add("lkPayment", list[list.Count - 1].PayAmount);
                list.RemoveAt(list.Count - 1);
                if (!oRsTool.Parameters.ContainsKey("psReceipt"))
                    oRsTool.Parameters.Add("psReceipt", list[list.Count - 1].ReceiptAmount);
                if (!oRsTool.Parameters.ContainsKey("psPayment"))
                    oRsTool.Parameters.Add("psPayment", list[list.Count - 1].PayAmount);
                list.RemoveAt(list.Count - 1);

                // ThoDD add trạng thái chuyển sang trang sau
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

            }
            return list;
        }

        /// <summary>
        /// Gets the report C30 bb.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C30BBModel> GetReportC30BB(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<C30BBModel> list = new List<C30BBModel>();
            using (var frmParam = new FrmC30BB2())
            {
                frmParam.Text = @"In Phiếu thu";
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    var currencyCode = GlobalVariable.CurrencyViewReport;
                    list = frmParam.C30BBList;
                    list = list.Where(x => x.IsSelect).ToList();
                    oRsTool.Parameters.Add("CurrencyCodeUnit", currencyCode);
                }

            }
            if (list!=null && list.Count>0)
            {
                string exchangeRate = Math.Round(list[0].ExchangeRate, int.Parse(commonVariable.ExchangeRateDecimalDigits)).ToString("G", CultureInfo.CreateSpecificCulture("fr-FR"));
                if (!oRsTool.Parameters.ContainsKey("ExchangeRate10"))
                    oRsTool.Parameters.Add("ExchangeRate10",exchangeRate);

                return list;
            }
            return null;
        }

    }
}
