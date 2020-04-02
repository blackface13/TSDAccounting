/***********************************************************************
 * <copyright file="DataAccess.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Configuration;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Report;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Search;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Tool;

namespace TSD.AccountingSoft.DataAccess
{
    /// <summary>
    /// DataAccess class
    /// </summary>
    public static class DataAccess
    {
        private static readonly string ConnectionStringName =
            ConfigurationManager.AppSettings.Get("ConnectionStringName");

        private static readonly IDaoFactory Factory = DaoFactories.GetFactory(ConnectionStringName);

        #region Dictionary

        public static IAccountingObjectCategoryDao AccountingObjectCategoryDao
        {
            get { return Factory.AccountingObjectCategoryDao; }
        }

        public static IActivityDao ActivityDao
        {
            get { return Factory.ActivityDao; }
        }

        public static IAutoBusinessParallelDao AutoBusinessParallelDao
        {
            get { return Factory.AutoBusinessParallelDao; }
        }

        public static IElectricalWorkDao ElectricalWorkDao
        {
            get { return Factory.ElectricalWorkDao; }
        }

        /// <summary>
        /// Gets the exchange rate DAO.
        /// </summary>
        /// <value>
        /// The exchange rate DAO.
        /// </value>
        public static IExchangeRateDao ExchangeRateDao
        {
            get { return Factory.ExchangeRateDao; }
        }

        /// <summary>
        /// Gets the account DAO.
        /// </summary>
        /// <value>
        /// The account DAO.
        /// </value>
        public static IAccountDao AccountDao
        {
            get { return Factory.AccountDao; }
        }


        public static IMutualDao MutualDao
        {
            get { return Factory.MutualDao; }
        }

        /// <summary>
        /// Gets the automatic number DAO.
        /// </summary>
        /// <value>
        /// The automatic number DAO.
        /// </value>
        public static IAutoNumberDao AutoNumberDao
        {
            get { return Factory.AutoNumberDao; }
        }

        public static ICalculateClosingDao CalculateClosingDao
        {
            get { return Factory.CalculateClosingDao; }
        }

        /// <summary>
        /// Gets the department DAO.
        /// </summary>
        /// <value>
        /// The department DAO.
        /// </value>
        public static IDepartmentDao DepartmentDao
        {
            get { return Factory.DepartmentDao; }
        }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        public static IBudgetItemDao BudgetItemDao
        {
            get { return Factory.BudgetItemDao; }
        }

        /// <summary>
        /// Gets the account category DAO.
        /// </summary>
        /// <value>
        /// The account category DAO.
        /// </value>
        public static IAccountCategoryDao AccountCategoryDao
        {
            get { return Factory.AccountCategoryDao; }
        }

        /// <summary>
        /// Gets the customer DAO.
        /// </summary>
        /// <value>
        /// The customer DAO.
        /// </value>
        public static ICustomerDao CustomerDao
        {
            get { return Factory.CustomerDao; }
        }

        /// <summary>
        /// Gets the vendor DAO.
        /// </summary>
        /// <value>
        /// The vendor DAO.
        /// </value>
        public static IVendorDao VendorDao
        {
            get { return Factory.VendorDao; }
        }

        /// <summary>
        /// Gets the accounting object DAO.
        /// </summary>
        /// <value>
        /// The accounting object DAO.
        /// </value>
        public static IAccountingObjectDao AccountingObjectDao
        {
            get { return Factory.AccountingObjectDao; }
        }

        /// <summary>
        /// Gets the voucher list DAO.
        /// </summary>
        /// <value>
        /// The voucher list DAO.
        /// </value>
        public static IVoucherListDao VoucherListDao
        {
            get { return Factory.VoucherListDao; }
        }

        /// <summary>
        /// Gets the other accouting object.
        /// </summary>
        /// <value>
        /// The other accouting object.
        /// </value>
        public static IAccountingObjectDao OtherAccoutingObject
        {
            get { return Factory.OtherAccoutingObjectDao; }
        }

        /// <summary>
        /// Gets the fixed asset category DAO.
        /// </summary>
        /// <value>
        /// The fixed asset category DAO.
        /// </value>
        public static IFixedAssetCategoryDao FixedAssetCategoryDao
        {
            get { return Factory.FixedAssetCategoryDao; }
        }

        /// <summary>
        /// Gets the fixed asset DAO.
        /// </summary>
        /// <value>
        /// The fixed asset DAO.
        /// </value>
        public static IFixedAssetDao FixedAssetDao
        {
            get { return Factory.FixedAssetDao; }
        }

        /// <summary>
        /// Gets the pay item DAO.
        /// </summary>
        /// <value>
        /// The pay item DAO.
        /// </value>
        public static IPayItemDao PayItemDao
        {
            get { return Factory.PayItemDao; }
        }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        public static IBudgetChapterDao BudgetChapterDao
        {
            get { return Factory.BudgetChapterDao; }
        }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        public static IFixedAssetHousingReportDao FixedAssetHousingReportDao
        {
            get { return Factory.FixedAssetHousingReportDao; }
        }

        /// <summary>
        /// Gets the budget category DAO.
        /// </summary>
        /// <value>
        /// The budget category DAO.
        /// </value>
        public static IBudgetCategoryDao BudgetCategoryDao
        {
            get { return Factory.BudgetCategoryDao; }
        }

        /// <summary>
        /// Gets the budget source DAO.
        /// </summary>
        /// <value>
        /// The budget source DAO.
        /// </value>
        public static IBudgetSourceDao BudgetSourceDao
        {
            get { return Factory.BudgetSourceDao; }
        }

        /// <summary>
        /// Gets the employee DAO.
        /// </summary>
        /// <value>
        /// The employee DAO.
        /// </value>
        public static IEmployeeDao EmployeeDao
        {
            get { return Factory.EmployeeDao; }
        }

        /// <summary>
        /// Gets the plan template list DAO.
        /// </summary>
        /// <value>
        /// The plan template list DAO.
        /// </value>
        public static IPlanTemplateListDao PlanTemplateListDao
        {
            get { return Factory.PlanTemplateListDao; }
        }

        /// <summary>
        /// Gets the plan template item DAO.
        /// </summary>
        /// <value>
        /// The plan template item DAO.
        /// </value>
        public static IPlanTemplateItemDao PlanTemplateItemDao
        {
            get { return Factory.PlanTemplateItemDao; }
        }

        /// <summary>
        /// Gets the employee pay item DAO.
        /// </summary>
        /// <value>
        /// The employee pay item DAO.
        /// </value>
        public static IEmployeePayItemDao EmployeePayItemDao
        {
            get { return Factory.EmployeePayItemDao; }
        }

        /// <summary>
        /// Gets the stock DAO.
        /// </summary>
        /// <value>
        /// The stock DAO.
        /// </value>
        public static IStockDao StockDao
        {
            get { return Factory.StockDao; }
        }

        /// <summary>
        /// Gets the inventory item DAO.
        /// </summary>
        /// <value>
        /// The inventory item DAO.
        /// </value>
        public static IInventoryItemDao InventoryItemDao
        {
            get { return Factory.InventoryItemDao; }
        }

        /// <summary>
        /// Gets the capital allocate DAO.
        /// </summary>
        /// <value>
        /// The capital allocate DAO.
        /// </value>
        public static ICapitalAllocateDao CapitalAllocateDao
        {
            get { return Factory.CapitalAllocateDao; }
        }

        /// <summary>
        /// Gets the currency DAO.
        /// </summary>
        /// <value>
        /// The currency DAO.
        /// </value>
        public static ICurrencyDao CurrencyDao
        {
            get { return Factory.CurrencyDao; }
        }

        /// <summary>
        /// Gets the bank DAO.
        /// </summary>
        /// <value>
        /// The bank DAO.
        /// </value>
        public static IBankDao BankDao
        {
            get { return Factory.BankDao; }
        }

        /// <summary>
        /// Gets the merger fund DAO.
        /// </summary>
        /// <value>
        /// The merger fund DAO.
        /// </value>
        public static IMergerFundDao MergerFundDao
        {
            get { return Factory.MergerFundDao; }
        }

        /// <summary>
        /// Gets the account tranfer DAO.
        /// </summary>
        /// <value>
        /// The account tranfer DAO.
        /// </value>
        public static IAccountTranferDao AccountTranferDao
        {
            get { return Factory.AccountTranferDao; }
        }

        /// <summary>
        /// Gets the database option DAO.
        /// </summary>
        /// <value>
        /// The database option DAO.
        /// </value>
        public static IDBOptionDao DBOptionDao
        {
            get { return Factory.DBOptionDao; }
        }

        /// <summary>
        /// Gets the report list DAO.
        /// </summary>
        /// <value>
        /// The report list DAO.
        /// </value>
        public static IReportListDao ReportListDao
        {
            get { return Factory.ReportListDao; }
        }

        /// <summary>
        /// Gets the report group DAO.
        /// </summary>
        /// <value>
        /// The report group DAO.
        /// </value>
        public static IReportGroupDao ReportGroupDao
        {
            get { return Factory.ReportGroupDao; }
        }

        /// <summary>
        /// Gets the auditting log DAO.
        /// </summary>
        /// <value>
        /// The auditting log DAO.
        /// </value>
        public static IAudittingLogDao AudittingLogDao
        {
            get { return Factory.AudittingLogDao; }
        }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        public static IAutoBusinessDao AutoBusinessDao
        {
            get { return Factory.AutoBusinessDao; }
        }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        public static IRefTypeDao RefTypeDao
        {
            get { return Factory.RefTypeDao; }
        }

        /// <summary>
        /// Gets the project DAO.
        /// </summary>
        /// <value>
        /// The project DAO.
        /// </value>
        public static IProjectDao ProjectDao
        {
            get { return Factory.ProjectDao; }
        }

        /// <summary>
        /// Gets the fixed asset currency DAO.
        /// </summary>
        /// <value>
        /// The fixed asset currency DAO.
        /// </value>
        public static IFixedAssetCurrencyDao FixedAssetCurrencyDao
        {
            get { return Factory.FixedAssetCurrencyDao; }
        }

        /// <summary>
        /// Gets the employee leasing DAO.
        /// </summary>
        /// <value>
        /// The employee leasing DAO.
        /// </value>
        public static IEmployeeLeasingDao EmployeeLeasingDao
        {
            get { return Factory.EmployeeLeasingDao; }
        }

        /// <summary>
        /// Gets the building DAO.
        /// </summary>
        /// <value>
        /// The building DAO.
        /// </value>
        public static IBuildingDao BuildingDao
        {
            get { return Factory.BuildingDao; }
        }


        public static IAutoNumberListDao AutoNumberListDao
        {
            get { return Factory.AutoNumberListDao; }
        }

        /// <summary>
        /// Gets the budget source category DAO.
        /// </summary>
        /// <value>
        /// The budget source category DAO.
        /// </value>
        public static IBudgetSourceCategoryDao BudgetSourceCategoryDao
        {
            get { return Factory.BudgetSourceCategory; }
        }

        /// <summary>
        /// Gets the company profile DAO.
        /// </summary>
        /// <value>
        /// The company profile DAO.
        /// </value>
        public static ICompanyProfileDao CompanyProfileDao
        {
            get { return Factory.CompanyProfileDao; }
        }

        public static ISalaryVoucherDao SalaryVoucherDao
        {
            get { return Factory.SalaryVoucherDao; }
        }

        public static IFixedAssetAccessaryDao FixedAssetAccessaryDao
        {
            get { return Factory.FixedAssetAccessaryDao; }
        }

        public static IReportDataTemplateDao ReportDataTemplateDao
        {
            get { return Factory.ReportDataTemplateDao; }
        }

        #endregion

        #region Business

        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        public static IOpeningInventoryEntryDao OpeningInventoryEntryDao
        {
            get { return Factory.OpeningInventoryEntryDao; }
        }

        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        public static ISearchDao SearchDao
        {
            get { return Factory.SearchDao; }
        }

        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        public static ICaptitalAllocateVoucherDao CaptitalAllocateVoucherDao
        {
            get { return Factory.CaptitalAllocateVoucherDao; }
        }

        /// <summary>
        /// Gets the account tranfer vourcher DAO.
        /// </summary>
        /// <value>
        /// The account tranfer vourcher DAO.
        /// </value>
        public static IAccountTranferVourcherDao AccountTranferVourcherDao
        {
            get { return Factory.AccountTranferVourcherDao; }
        }

        /// <summary>
        /// Gets the general DAO.
        /// </summary>
        /// <value>
        /// The general DAO.
        /// </value>
        public static IGeneralDao GeneralDao
        {
            get { return Factory.GeneralDao; }
        }

        /// <summary>
        /// Gets the general detail DAO.
        /// </summary>
        /// <value>
        /// The general detail DAO.
        /// </value>
        public static IGeneralDetailDao GeneralDetailDao
        {
            get { return Factory.GeneralDetailDao; }
        }

        /// <summary>
        /// Gets the voucher type DAO.
        /// </summary>
        /// <value>
        /// The voucher type DAO.
        /// </value>
        public static IVoucherTypeDao VoucherTypeDao
        {
            get { return Factory.VoucherTypeDao; }
        }

        /// <summary>
        /// Gets the journal entry account DAO.
        /// </summary>
        /// <value>
        /// The journal entry account DAO.
        /// </value>
        public static IJournalEntryAccountDao JournalEntryAccountDao
        {
            get { return Factory.JournalEntryAccountDao; }
        }

        /// <summary>
        /// Gets the Salary DAO.
        /// </summary>
        /// <value>
        /// The Salary DAO.
        /// </value>
        public static ISalaryDao SalaryDao
        {
            get { return Factory.SalaryDao; }
        }

        /// <summary>
        /// Gets the account balance DAO.
        /// </summary>
        /// <value>
        /// The account balance DAO.
        /// </value>
        public static IAccountBalanceDao AccountBalanceDao
        {
            get { return Factory.AccountBalanceDao; }
        }

        /// <summary>
        /// Gets the general ledger DAO.
        /// </summary>
        /// <value>
        /// The general ledger DAO.
        /// </value>
        public static IGeneralLedgerDao GeneralLedgerDao
        {
            get { return Factory.GeneralLedgerDao; }
        }

        /// <summary>
        /// Gets the opening supply entry DAO.
        /// </summary>
        /// <value>The opening supply entry DAO.</value>
        public static IOpeningSupplyEntryDao OpeningSupplyEntryDao
        {
            get { return Factory.OpeningSupplyEntryDao; }
        }

        /// <summary>
        /// Gets the supply ledger DAO.
        /// </summary>
        /// <value>
        /// The supply ledger DAO.
        /// </value>
        public static ISupplyLedgerDao SupplyLedgerDao
        {
            get { return Factory.SupplyLedgerDao; }
        }

        /// <summary>
        /// Gets the estimate DAO.
        /// </summary>
        /// <value>
        /// The estimate DAO.
        /// </value>
        public static IEstimateDao EstimateDao
        {
            get { return Factory.EstimateDao; }
        }

        /// <summary>
        /// Gets the estimate detail DAO.
        /// </summary>
        /// <value>
        /// The estimate detail DAO.
        /// </value>
        public static IEstimateDetailDao EstimateDetailDao
        {
            get { return Factory.EstimateDetailDao; }
        }

        /// <summary>
        /// Gets the cash DAO.
        /// </summary>
        /// <value>
        /// The cash DAO.
        /// </value>
        public static ICashDao CashDao
        {
            get { return Factory.CashDao; }
        }

        /// <summary>
        /// Gets the cash detail DAO.
        /// </summary>
        /// <value>
        /// The cash detail DAO.
        /// </value>
        public static ICashDetailDao CashDetailDao
        {
            get { return Factory.CashDetailDao; }
        }

        /// <summary>
        /// Gets the deposit DAO.
        /// </summary>
        /// <value>
        /// The deposit DAO.
        /// </value>
        public static IDepositDao DepositDao
        {
            get { return Factory.DepositDao; }
        }

        /// <summary>
        /// Gets the deposit detail DAO.
        /// </summary>
        /// <value>
        /// The deposit detail DAO.
        /// </value>
        public static IDepositDetailDao DepositDetailDao
        {
            get { return Factory.DepositDetailDao; }
        }

        /// <summary>
        /// Gets the cash DAO.
        /// </summary>
        /// <value>
        /// The cash DAO.
        /// </value>
        public static IItemTransactionDao ItemTransactionDao
        {
            get { return Factory.ItemTransactionDao; }
        }

        /// <summary>
        /// Gets the cash detail DAO.
        /// </summary>
        /// <value>
        /// The cash detail DAO.
        /// </value>
        public static IItemTransactionDetailDao ItemTransactionDetailDao
        {
            get { return Factory.ItemTransactionDetailDao; }
        }

        public static ISUIncrementDecrementDao SUIncrementDecrementDao
        {
            get { return Factory.SUIncrementDecrementDao; }
        }

        public static ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao
        {
            get { return Factory.SUIncrementDecrementDetailDao; }
        }

        /// <summary>
        /// Gets the fixed asset armortization DAO.
        /// </summary>
        /// <value>
        /// The fixed asset armortization DAO.
        /// </value>
        public static IFixedAssetArmortizationDao FixedAssetArmortizationDao
        {
            get { return Factory.FixedAssetArmortizationDao; }
        }

        /// <summary>
        /// Gets the fixed asset armortization detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset armortization detail DAO.
        /// </value>
        public static IFixedAssetArmortizationDetailDao FixedAssetArmortizationDetailDao
        {
            get { return Factory.FixedAssetArmortizationDetailDao; }
        }

        /// <summary>
        /// Gets the fixed asset decrement DAO.
        /// </summary>
        /// <value>
        /// The fixed asset decrement DAO.
        /// </value>
        public static IFixedAssetDecrementDao FixedAssetDecrementDao
        {
            get { return Factory.FixedAssetDecrement; }
        }

        /// <summary>
        /// Gets the fixed asset decrement detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset decrement detail DAO.
        /// </value>
        public static IFixedAssetDecrementDetailDao FixedAssetDecrementDetailDao
        {
            get { return Factory.FixedAssetDecrementDetailDao; }
        }

        public static IFixedAssetDecrementDetailParallelDao FixedAssetDecrementDetailParallelDao
        {
            get { return Factory.FixedAssetDecrementDetailParallelDao; }
        }

        /// <summary>
        /// Gets the fixed asset increment DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment DAO.
        /// </value>
        public static IFixedAssetIncrementDao FixedAssetIncrementDao
        {
            get { return Factory.FixedAssetIncrementDao; }
        }

        /// <summary>
        /// Gets the fixed asset increment detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment detail DAO.
        /// </value>
        public static IFixedAssetIncrementDetailDao FixedAssetIncrementDetailDao
        {
            get { return Factory.FixedAssetIncrementDetailDao; }
        }

        public static IFixedAssetIncrementDetailParallelDao FixedAssetIncrementDetailParallelDao
        {
            get { return Factory.FixedAssetIncrementDetailParallelDao; }
        }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        public static IFixedAssetLedgerDao FixedAssetLedgerDao
        {
            get { return Factory.FixedAssetLedgerDao; }
        }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        public static IFixedAssetVoucherDao FixedAssetVoucherDao
        {
            get { return Factory.FixedAssetVoucherDao; }
        }

        /// <summary>
        /// Gets or sets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        public static IOpeningAccountEntryDao OpeningAccountEntryDao
        {
            get { return Factory.OpeningAccountEntryDao; }
        }

        /// <summary>
        /// Gets the opening account entry detail DAO.
        /// </summary>
        /// <value>
        /// The opening account entry detail DAO.
        /// </value>
        public static IOpeningAccountEntryDetailDao OpeningAccountEntryDetailDao
        {
            get { return Factory.OpeningAccountEntryDetailDao; }
        }

        /// <summary>
        /// Gets the opening account entry detail DAO.
        /// </summary>
        /// <value>
        /// The opening account entry detail DAO.
        /// </value>
        public static IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao
        {
            get { return Factory.OpeningFixedAssetEntryDao; }
        }

        /// <summary>
        /// Gets the common DAO.
        /// </summary>
        /// <value>
        /// The common DAO.
        /// </value>
        public static ICommonDao CommonDao
        {
            get { return Factory.CommonDao; }
        }

        /// <summary>
        /// Gets the estimate detail statement DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement DAO.
        /// </value>
        public static IEstimateDetailStatementDao EstimateDetailStatementDao
        {
            get { return Factory.EstimateDetailStatementDao; }
        }

        /// <summary>
        /// Gets the estimate detail statement DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement DAO.
        /// </value>
        public static IEstimateDetailStatementPartBDao EstimateDetailStatementPartBDao
        {
            get { return Factory.EstimateDetailStatementPartBDao; }
        }

        /// <summary>
        /// Gets the estimate detail statement DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement DAO.
        /// </value>
        public static IEstimateDetailStatementFixedAssetDao EstimateDetailStatementFixedAssetDao
        {
            get { return Factory.EstimateDetailStatementFixedAssetDao; }
        }

        public static IDepositDetailParallelDao DepositDetailParallelDao
        {
            get { return Factory.DepositDetailParallelDao; }
        }

        public static IItemTransactionDetailParallelDao ItemTransactionDetailParallelDao
        {
            get { return Factory.ItemTransactionDetailParallelDao; }
        }

        public static IEstimateExchangeRateDao IEstimateExchangeRateDao
        {
            get { return Factory.EstimateExchangeRateDao; }
        }

        #endregion

        #region System

        public static ILockDao LockDao
        {
            get { return Factory.LockDao; }
        }

        /// <summary>
        /// Gets the role DAO.
        /// </summary>
        /// <value>
        /// The role DAO.
        /// </value>
        public static IRoleDao RoleDao
        {
            get { return Factory.RoleDao; }
        }

        /// <summary>
        /// Gets the site DAO.
        /// </summary>
        /// <value>
        /// The site DAO.
        /// </value>
        public static ISiteDao SiteDao
        {
            get { return Factory.SiteDao; }
        }

        /// <summary>
        /// Gets the permission DAO.
        /// </summary>
        /// <value>
        /// The permission DAO.
        /// </value>
        public static IPermissionDao PermissionDao
        {
            get { return Factory.PermissionDao; }
        }

        /// <summary>
        /// Gets the permission site DAO.
        /// </summary>
        /// <value>
        /// The permission site DAO.
        /// </value>
        public static IPermissionSiteDao PermissionSiteDao
        {
            get { return Factory.PermissionSiteDao; }
        }

        /// <summary>
        /// Gets the role site DAO.
        /// </summary>
        /// <value>
        /// The role site DAO.
        /// </value>
        public static IRoleSiteDao RoleSiteDao
        {
            get { return Factory.RoleSiteDao; }
        }

        /// <summary>
        /// Gets the user profile DAO.
        /// </summary>
        /// <value>
        /// The user profile DAO.
        /// </value>
        public static IUserProfileDao UserProfileDao
        {
            get { return Factory.UserProfileDao; }
        }

        #endregion
    }
}