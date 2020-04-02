/***********************************************************************
 * <copyright file="VoucherReport.cs" company="BUCA JSC">
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
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;
using DevExpress.XtraEditors;
using RSSHelper;


namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// Voucher Report
    /// </summary>
    public class VoucherReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherReport"/> class.
        /// </summary>
        public VoucherReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
        }

        /// <summary>
        /// Gets the report C22 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C22HModel> GetReportC22H(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            if (commonVariable.RefIdList == null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }

            IList<C22HModel> list = Model.GetC22H(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList) ;
            foreach (var c22HModel in list)
            {
                if (c22HModel.AccountingObjectAddress==null)
                {
                    c22HModel.AccountingObjectAddress = "";
                }
                if (c22HModel.AccountingObjectName == null)
                {
                    c22HModel.AccountingObjectName = "";
                }
                if (c22HModel.DocumentInclude == null)
                {
                    c22HModel.DocumentInclude = "";
                }
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
        public IList<C30BBModel> GetReportC30BB(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            if (commonVariable.RefIdList == null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }
            string[] lstId = commonVariable.RefIdList.Split(';');
            IList<C30BBModel> list = Model.GetC30BBWithStoreProdure(DateTime.Parse(commonVariable.PostedDate).Year, commonVariable.ReportList.RefRypeVoucherID);
            IList<C30BBModel> listTemp = new List<C30BBModel>();
            foreach (var it in list)
            {
                if (lstId.Any())
                {
                    for (int i = 0; i < lstId.Count();i++ )
                    {
                        if (int.Parse(lstId[i])==it.RefId)
                        {
                            listTemp.Add(it);
                        }
                    }
                }

            }
            return listTemp;
        }

        /// <summary>
        /// Gets the report C30 BB501 models.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C30BB501Model> GetReportC30Bb501Models(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            if (commonVariable.RefIdList == null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }

            IList<C30BB501Model> list = Model.GetC30BB501(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList);
            foreach (var c30BB501Model in list)
            {
                if (c30BB501Model.Trader == null)
                {
                    c30BB501Model.Trader = "";
                }
                if (c30BB501Model.DocumentInclude == null)
                {
                    c30BB501Model.DocumentInclude = "";
                }
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
        public IList<C30BBModel> GetReportC30BBItem(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            if (commonVariable.RefIdList == null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }
            string[] lstId = commonVariable.RefIdList.Split(';');
            IList<C30BBModel> list = Model.GetC30BBItemWithStoreProdure(DateTime.Parse(commonVariable.PostedDate).Year, commonVariable.ReportList.RefRypeVoucherID);
            IList<C30BBModel> listTemp = new List<C30BBModel>();
            foreach (var it in list)
            {
                if (lstId.Any())
                {
                    for (int i = 0; i < lstId.Count(); i++)
                    {
                        if (int.Parse(lstId[i]) == it.RefId)
                        {
                            listTemp.Add(it);
                        }
                    }
                }

            }
            return listTemp;
        }












        /// <summary>
        /// Gets the report C11 h.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C11HModel> GetReportC11H(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool) 
        {
            if (commonVariable.RefIdList ==null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }
            IList<C11HModel> list = Model.GetC11H(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList);
            return list;
        }

        /// <summary>
        /// Gets the report accounting voucher.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<AccountingVoucherModel> GetReportAccountingVoucher(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            if (commonVariable.RefIdList == null)
            {
                commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            }
            IList<AccountingVoucherModel> list = Model.AccountingVoucherModel(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList, commonVariable.RefType);
            //ThangNK bổ sung
            if (list.Count>0)
            {
                string  todate = list[0].PostedDate.ToString();
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", todate);
            }
            return list;
        }   
 
    }
}
