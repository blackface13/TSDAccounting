/***********************************************************************
 * <copyright file="DictionaryReport.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using DevExpress.XtraEditors;
using RSSHelper;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// Get data for Dictionary Report
    /// </summary>
    public class DictionaryReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryReport"/> class.
        /// </summary>
        public DictionaryReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
        }

        /// <summary>
        /// Gets the fixed asset category list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategoryList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetFixedAssetCategoriesActive();
        }

        /// <summary>
        /// Gets the fixed asset list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetModel> GetFixedAssetList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            //return Model.GetAllFixedAssetsWithStoreProdure(commonVariable.ReportList.ProcedureName);
            return Model.GetFixedAsset();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<BudgetChapterModel> GetBudgetChapterList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetBudgetChapters();
        }

        /// <summary>
        /// Gets the fixed asset category list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<BudgetCategoryModel> GetBudgetCategoryList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetBudgetCategories();
        }

        /// <summary>
        /// Gets the fixed asset category list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<AccountModel> GetAccountList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetAccounts();
        }

        /// <summary>
        /// Gets the fixed asset category list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<AccountCategoryModel> GetAccountCategoryList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetAccountCategories();
        }

        /// <summary>
        /// Gets the fixed asset category list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<AccountTranferModel> GetAccountTranferList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetAccountTranfers();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<BudgetItemModel> GetBudgetItemList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetBudgetItems();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<BudgetSourceModel> GetBudgetSourceList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetBudgetSources();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<CurrencyModel> GetCurrencyList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetCurrencies();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<BankModel> GetBankList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetBanks();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<MergerFundModel> GetMergerFundList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetMergerFunds();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<PlanTemplateListModel> GetPlanTemplateListList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetPlanTemplateLists();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<VoucherListModel> GetVoucherListList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetVoucherLists();
        }
        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<DepartmentModel> GetDepartmentList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetDepartments();
        }

        public IList<CapitalAllocateModel> GetCapitalAllocateList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetCapitalAllocates();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<EmployeeModel> GetEmployeeList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetEmployees();
        }
        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<PayItemModel> GetPayItemList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetPayItems();
        }
        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<CustomerModel> GetCustomerList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetCustomers();
        }
        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<VendorModel> GetVendorList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetVendors();
        }
        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<AccountingObjectModel> GetAccountingObjectList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetAccountingObjects();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<StockModel> GetStockList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetStocks();
        }

        /// <summary>
        /// Gets the budget chapter list.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<InventoryItemModel> GetInventoryItemList(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            return Model.GetInventoryItems();
        }
    }
}
