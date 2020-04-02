/***********************************************************************
 * <copyright file="ReportLedgerAccounting.cs" company="BUCA JSC">
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
 * 04/10/2016   ThoDD               Thêm toàn bộ các báo cáo có chức năng chuyển sang dòng sau 
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
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// ReportLedgerAccounting
    /// </summary>
    public class ReportLedgerAccounting : BaseReport
    {
        private readonly GlobalVariable _globalVariable;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportLedgerAccounting"/> class.
        /// </summary>
        public ReportLedgerAccounting()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();
        }

        /// <summary>
        /// Sổ nhật ký chung
        /// Gets the report S03 ah.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S03AHModel> GetReportS03AH(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<S03AHModel> list;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = _globalVariable.PostedDate;
            var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS03a_H())
                {
                    frmParam.ReporDate = _globalVariable.PostedDate;
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                        GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        list = Model.GetS03AHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode, amountType);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            else
            {
                list = Model.GetS03AHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode, amountType);
            }
            if (list != null)
            {
                list = list.Where(w => !string.IsNullOrEmpty(w.RefNo)).Select(s =>
                  {
                      if (s.AccountNumber.StartsWith("0"))
                          s.AccountGroupCode = "B";
                      else
                          s.AccountGroupCode = "A";
                      return s;
                  }).ToList();


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
                if (!oRsTool.Parameters.ContainsKey("Province"))
                    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
                if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
            }

            return list;
        }

        /// <summary>
        /// Sổ chi Cái tài khoản
        /// Gets the report S03 bh.
        /// LinhMC thêm code kiểm tra nếu là xem báo cáo bằng cách truy xuất từ báo cáo khác thì không cần mở form lấy tham số báo cáo
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S03BHModel> GetReportS03BH(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {

            IList<S03BHModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var isTotalBandInNewPage = false;
            if (commonVariable.IsDrillDownReport)
            {
                GlobalVariable.FromDate = DateTime.Parse(commonVariable.DrillDownParram[9].ToString());
                GlobalVariable.ToDate = DateTime.Parse(commonVariable.DrillDownParram[10].ToString());
                var accountNumber = commonVariable.DrillDownParram[4].ToString();
                const string correspondingAccountNumber = "";
                amountType = int.Parse(commonVariable.DrillDownParram[2].ToString());
                currencyCode = commonVariable.DrillDownParram[3].ToString();

                list = Model.GetS03BHWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, correspondingAccountNumber, currencyCode);

                var accountName = Model.GetAccountByCode(accountNumber).AccountName;

                if (!oRsTool.Parameters.ContainsKey("Account"))
                    oRsTool.Parameters.Add("Account", "Tài khoản: " + accountNumber + " - " + accountName);

                if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                    oRsTool.Parameters.Add("AccountNumber", accountNumber);

                if (!oRsTool.Parameters.ContainsKey("CorrespondingAccountNumber"))
                    oRsTool.Parameters.Add("CorrespondingAccountNumber", correspondingAccountNumber);

            }
            else
            {
                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmS03BH())
                    {
                        frmParam.Text = @"Sổ cái";
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                            GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                            isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                            var accountNumber = frmParam.AccountCode;
                            if (!oRsTool.Parameters.ContainsKey("Account"))
                                oRsTool.Parameters.Add("Account", "Tài khoản: " + accountNumber + " - " + frmParam.AccountName);

                            if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                                oRsTool.Parameters.Add("AccountNumber", accountNumber);

                            var correspondingAccountNumber = frmParam.CorrespondingAccountNumber;
                            if (!oRsTool.Parameters.ContainsKey("CorrespondingAccountNumber"))
                                oRsTool.Parameters.Add("CorrespondingAccountNumber", correspondingAccountNumber);

                            if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                                oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                            list = Model.GetS03BHWithStoreProdure(commonVariable.ReportList.ProcedureName,
                                GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(),
                                amountType, accountNumber, correspondingAccountNumber, currencyCode);
                        }
                    }
                }
                else
                {
                    var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
                    var correspondingAccountNumber = oRsTool.Parameters["CorrespondingAccountNumber"].ToString();
                    list = Model.GetS03BHWithStoreProdure(commonVariable.ReportList.ProcedureName,
                        GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(),
                        amountType, accountNumber, correspondingAccountNumber, currencyCode);
                }

            }
            if (list != null && list.Count > 0)
            {
                if (!oRsTool.Parameters.ContainsKey("Year"))
                    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);
                if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                    oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(tính quy đổi): ") + currencyCode);
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
        /// Sổ chi tiết tài khoản
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S33HModel> GetReportS33H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            IList<S33HModel> list;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS33H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        string FromDate = DateTime.Parse(frmParam.FromDate).ToShortDateString();
                        string ToDate = DateTime.Parse(frmParam.ToDate).ToShortDateString();
                        string whereClause = frmParam.WhereClause;
                        string accountCode = frmParam.AccountCode;
                        string accountName = frmParam.AccountName;
                        string currencyCode = GlobalVariable.CurrencyViewReport;
                        //string currencyCode = frmParam.CurrencyCode;
                        string fixedAssetCode = frmParam.FixedAssetCode;
                        string budgetGroupCode = frmParam.BudgetGroupCode;
                        string departmentCode = frmParam.DepartmentCode;
                        isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        string selectedField = frmParam.SelectedField;
                        string selectedAllValueField = frmParam.SelectedAllValueField;

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

                        if (!oRsTool.Parameters.ContainsKey("EmployeeName"))
                            oRsTool.Parameters.Add("EmployeeName", frmParam.EmployeeName);
                        if (!oRsTool.Parameters.ContainsKey("VendorId"))
                            oRsTool.Parameters.Add("VendorId", frmParam.VendorId);
                        if (!oRsTool.Parameters.ContainsKey("VendorName"))
                            oRsTool.Parameters.Add("VendorName", frmParam.VendorName);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjectId"))
                            oRsTool.Parameters.Add("AccountingObjectId", frmParam.AccountingObjectId);
                        if (!oRsTool.Parameters.ContainsKey("FullName"))
                            oRsTool.Parameters.Add("FullName", frmParam.FullName);
                        if (!oRsTool.Parameters.ContainsKey("AccountCode"))
                            oRsTool.Parameters.Add("AccountCode",
                                "Tên tài khoản: " + accountName + " Số hiệu: " + accountCode);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", FromDate);
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", ToDate);
                        // ThoDD add chuyển dòng sang trang sau
                        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                        /*=== LinhMC add thêm 1 số biến lưu giữ giá trị, để Refresh dữ liệu ===*/
                        if (!oRsTool.Parameters.ContainsKey("WhereClause"))
                            oRsTool.Parameters.Add("WhereClause", frmParam.WhereClause);
                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", accountCode);


                        if (!oRsTool.Parameters.ContainsKey("BudgetGroupCode"))
                            oRsTool.Parameters.Add("BudgetGroupCode", budgetGroupCode);
                        if (!oRsTool.Parameters.ContainsKey("FixedAssetCode"))
                            oRsTool.Parameters.Add("FixedAssetCode", fixedAssetCode);

                        if (!oRsTool.Parameters.ContainsKey("DepartmentCode"))
                            oRsTool.Parameters.Add("DepartmentCode", departmentCode);

                        if (!oRsTool.Parameters.ContainsKey("SelectedField"))
                            oRsTool.Parameters.Add("SelectedField", frmParam.SelectedField);

                        if (!oRsTool.Parameters.ContainsKey("SelectedAllValueField"))
                            oRsTool.Parameters.Add("SelectedAllValueField", frmParam.SelectedAllValueField);

                        if (!oRsTool.Parameters.ContainsKey("ObjectName"))
                            oRsTool.Parameters.Add("ObjectName", frmParam.ObjectName);

                        if (!oRsTool.Parameters.ContainsKey("Province"))
                            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                        if (!oRsTool.Parameters.ContainsKey("ObjectName"))
                            oRsTool.Parameters.Add("ObjectName", frmParam.ObjectName);

                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                        list = Model.GetS33HWithStoreProdure(commonVariable.ReportList.ProcedureName, accountCode, FromDate, ToDate, currencyCode, budgetGroupCode, fixedAssetCode, departmentCode, amountType, whereClause);

                        if (!oRsTool.Parameters.ContainsKey("ckAccountNumber"))
                            oRsTool.Parameters.Add("ckAccountNumber", list[list.Count - 1].DebitAmountBalance);

                        if (!oRsTool.Parameters.ContainsKey("ckCorrAccountNumber"))
                            oRsTool.Parameters.Add("ckCorrAccountNumber", list[list.Count - 1].CreditAmountBalance);
                        list.RemoveAt(list.Count - 1);
                    }

                    else
                    {
                        list = null;
                    }
                }
            }
            else
            {
                var accountCode = oRsTool.Parameters["AccountNumber"].ToString();
                var currencyCode = oRsTool.Parameters["CurrencyCode"].ToString();
                var whereClause = oRsTool.Parameters["WhereClause"].ToString();
                var budgetGroupCode = oRsTool.Parameters["BudgetGroupCode"].ToString();
                var fixedAssetCode = oRsTool.Parameters["FixedAssetCode"].ToString();
                var selectedField = oRsTool.Parameters["SelectedField"].ToString();
                var selectedAllValueField = oRsTool.Parameters["SelectedAllValueField"].ToString();
                string departmentCode = oRsTool.Parameters["DepartmentCode"].ToString();
                string fromDate = oRsTool.Parameters["FromDate"].ToString();
                string toDate = oRsTool.Parameters["ToDate"].ToString();

                list = Model.GetS33HWithStoreProdure(commonVariable.ReportList.ProcedureName, accountCode, fromDate, toDate, currencyCode, budgetGroupCode, fixedAssetCode, departmentCode, amountType, whereClause, selectedField, selectedAllValueField);
            }
            return list;
        }

        public IList<S05HGroupModel> GetReportS05H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                IList<S05HModel> list = null;
                S05HGroupModel s05HGroup = new S05HGroupModel();
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

                            list = Model.GetS05HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode, amountType);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    list = Model.GetS05HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode, amountType);
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

                    s05HGroup.GroupA = list.Where(w => !w.AccountCode.StartsWith("0")).ToList() ?? new List<S05HModel>();
                    s05HGroup.GroupB = list.Where(w => w.AccountCode.StartsWith("0")).ToList() ?? new List<S05HModel>();

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

                    //decimal TotalOpeningCredit = list.Where(x => x.Grade == 1).Sum(x => x.OpeningCredit);
                    //decimal TotalOpeningDebit = list.Where(x => x.Grade == 1).Sum(x => x.OpeningDebit);
                    //decimal TotalMovementAccumCredit = list.Where(x => x.Grade == 1).Sum(x => x.MovementAccumCredit);
                    //decimal TotalMovementAccumDebit = list.Where(x => x.Grade == 1).Sum(x => x.MovementAccumDebit);
                    //decimal TotalMovementCredit = list.Where(x => x.Grade == 1).Sum(x => x.MovementCredit);
                    //decimal TotalMovementDebit = list.Where(x => x.Grade == 1).Sum(x => x.MovementDebit);
                    //decimal TotalClosingCredit = list.Where(x => x.Grade == 1).Sum(x => x.ClosingCredit);
                    //decimal TotalClosingDebit = list.Where(x => x.Grade == 1).Sum(x => x.ClosingDebit);
                    decimal TotalOpeningCredit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.OpeningCredit);
                    decimal TotalOpeningDebit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.OpeningDebit);
                    decimal TotalMovementAccumCredit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.MovementAccumCredit);
                    decimal TotalMovementAccumDebit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.MovementAccumDebit);
                    decimal TotalMovementCredit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.MovementCredit);
                    decimal TotalMovementDebit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.MovementDebit);
                    decimal TotalClosingCredit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.ClosingCredit);
                    decimal TotalClosingDebit = s05HGroup.GroupA.Where(x => x.Grade == 1).Sum(x => x.ClosingDebit);

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

                    TotalOpeningCredit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.OpeningCredit);
                    TotalOpeningDebit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.OpeningDebit);
                    TotalMovementAccumCredit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.MovementAccumCredit);
                    TotalMovementAccumDebit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.MovementAccumDebit);
                    TotalMovementCredit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.MovementCredit);
                    TotalMovementDebit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.MovementDebit);
                    TotalClosingCredit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.ClosingCredit);
                    TotalClosingDebit = s05HGroup.GroupB.Where(x => x.Grade == 1).Sum(x => x.ClosingDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementCreditGroupB"))
                        oRsTool.Parameters.Add("TotalMovementCreditGroupB", TotalMovementCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementDebitGroupB"))
                        oRsTool.Parameters.Add("TotalMovementDebitGroupB", TotalMovementDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalClosingCreditGroupB"))
                        oRsTool.Parameters.Add("TotalClosingCreditGroupB", TotalClosingCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalClosingDebitGroupB"))
                        oRsTool.Parameters.Add("TotalClosingDebitGroupB", TotalClosingDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalOpeningCreditGroupB"))
                        oRsTool.Parameters.Add("TotalOpeningCreditGroupB", TotalOpeningCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalOpeningDebitGroupB"))
                        oRsTool.Parameters.Add("TotalOpeningDebitGroupB", TotalOpeningDebit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumCreditGroupB"))
                        oRsTool.Parameters.Add("TotalMovementAccumCreditGroupB", TotalMovementAccumCredit);
                    if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumDebitGroupB"))
                        oRsTool.Parameters.Add("TotalMovementAccumDebitGroupB", TotalMovementAccumDebit);
                }
                else
                {
                    return new List<S05HGroupModel>();
                }

                return new List<S05HGroupModel> { s05HGroup };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        public IList<AdvancePaymentModel> GetReportAdvancePayment(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                IList<AdvancePaymentModel> list = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = _globalVariable.PostedDate;
                var isTotalBandInNewPage = false;
                var accountType = 0;
                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmB01H())
                    {
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {

                            GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
                            GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
                            isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                            accountType = frmParam.AccountType;
                            list = Model.GetAdvancePaymentWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), GlobalVariable.CurrencyViewReport, GlobalVariable.AmountTypeViewReport, accountType);
                        }
                    }
                }
                else
                {
                    list = Model.GetAdvancePaymentWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), GlobalVariable.CurrencyViewReport, GlobalVariable.AmountTypeViewReport, accountType);
                }
                if (list != null && list.Count > 0)
                {

                    if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                        oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
                    //if (!oRsTool.Parameters.ContainsKey("AmountType"))
                    //    oRsTool.Parameters.Add("AmountType", amountType);

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
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        public IList<TSD.AccountingSoft.Model.BusinessObjects.Report.LedgerAccounting.ReportS104HModel> GetReportS104H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            try
            {
                IList<TSD.AccountingSoft.Model.BusinessObjects.Report.LedgerAccounting.ReportS104HModel> lstResults = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = _globalVariable.PostedDate;
                var isTotalBandInNewPage = false;

                DateTime fromDate = GlobalVariable.FromDate;
                DateTime toDate = GlobalVariable.ToDate;
                DateTime? openDate = null;
                string selectedBudgetSourceCodes = "";
                string expenseName = "NSNN";

                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmLedgerAccountingS104H())
                    {
                        frmParam.Text = "Sổ theo dõi kinh phí NSNN cấp bằng lệnh chi tiền";
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            fromDate = frmParam.FromDate;
                            toDate = frmParam.ToDate;
                            openDate = frmParam.OpenDate;
                            selectedBudgetSourceCodes = frmParam.SelectedBudgetSourceCodes;
                            expenseName = frmParam.ExpenseName;
                        }
                        else
                            return null;
                    }
                }

                lstResults = Model.LedgerAccountingS104H(commonVariable.ReportList.ProcedureName, fromDate.ToShortDateString(), toDate.ToShortDateString(), selectedBudgetSourceCodes, currencyCode, amountType);
                if (lstResults != null && lstResults.Count > 0)
                {

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
                        oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ToDate"))
                        oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ExpenseName"))
                        oRsTool.Parameters.Add("ExpenseName", expenseName);
                    if (!oRsTool.Parameters.ContainsKey("OpenDate"))
                        oRsTool.Parameters.Add("OpenDate", openDate);
                }

                return lstResults;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }
    }
}
