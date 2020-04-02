/***********************************************************************
 * <copyright file="SqlServerDaoFactory.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Report;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Search;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;
using TSD.AccountingSoft.DataAccess.SqlServer.Cash;
using TSD.AccountingSoft.DataAccess.SqlServer.Deposit;
using TSD.AccountingSoft.DataAccess.SqlServer.Dictionary;
using TSD.AccountingSoft.DataAccess.SqlServer.Estimate;
using TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset;
using TSD.AccountingSoft.DataAccess.SqlServer.Inventory;
using TSD.AccountingSoft.DataAccess.SqlServer.Opening;
using TSD.AccountingSoft.DataAccess.SqlServer.Report;
using TSD.AccountingSoft.DataAccess.SqlServer.Salary;
using TSD.AccountingSoft.DataAccess.SqlServer.General;
using TSD.AccountingSoft.DataAccess.SqlServer.Search;
using TSD.AccountingSoft.DataAccess.SqlServer.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory;
using TSD.AccountingSoft.DataAccess.SqlServer.Tool;

namespace TSD.AccountingSoft.DataAccess.SqlServer
{
    /// <summary>
    /// class SqlServerDaoFactory
    /// </summary>
    public class SqlServerDaoFactory : IDaoFactory
    {
        #region Dictionary
        public IAccountingObjectCategoryDao AccountingObjectCategoryDao { get { return new SqlServerAccountingObjectCategoryDao(); } }

        public IActivityDao ActivityDao { get { return new SqlServerActivityDao(); } }

        public IAutoBusinessParallelDao AutoBusinessParallelDao
        {
            get { return new SqlServerAutoBusinessParallelDao(); }
        }

        public IAutoNumberListDao AutoNumberListDao
        {
            get { return new SqlServerAutoNumberListDao(); }
        }

        public IElectricalWorkDao ElectricalWorkDao
        {
            get { return new SqlserverElectricalWorkDao(); }
        }

        /// <summary>
        /// Gets the exchange rate DAO.
        /// </summary>
        /// <value>
        /// The exchange rate DAO.
        /// </value>
        public IExchangeRateDao ExchangeRateDao
        {
            get { return new SqlServerExchangeRateDao(); }
        }

        /// <summary>
        /// Gets the account DAO.
        /// </summary>
        /// <value>
        /// The account DAO.
        /// </value>
        public IAccountDao AccountDao
        {
            get { return new SqlServerAccountDao(); }
        }

        /// <summary>
        /// Gets the automatic number DAO.
        /// </summary>
        /// <value>
        /// The automatic number DAO.
        /// </value>
        public IAutoNumberDao AutoNumberDao
        {
            get { return new SqlServerAutoNumberDao(); }
        }

        /// <summary>
        /// Gets the capital allocate DAO.
        /// </summary>
        /// <value>
        /// The capital allocate DAO.
        /// </value>
        public ICapitalAllocateDao CapitalAllocateDao
        {
            get { return new SqlServerCapitalAllocateDao(); }
        }

        /// <summary>
        /// Gets the account tranfer vourcher DAO.
        /// </summary>
        /// <value>
        /// The account tranfer vourcher DAO.
        /// </value>
        public IAccountTranferVourcherDao AccountTranferVourcherDao
        {

            get { return new SqlServerAccountTranferVourcherDao(); }
        }

        /// <summary>
        /// Gets the currency DAO.
        /// </summary>
        /// <value>
        /// The currency DAO.
        /// </value>
        public ICurrencyDao CurrencyDao
        {
            get { return new SqlServerCurrencyDao(); }
        }

        /// <summary>
        /// Gets the bank DAO.
        /// </summary>
        /// <value>
        /// The bank DAO.
        /// </value>
        public IBankDao BankDao
        {
            get { return new SqlServerBankDao(); }
        }

        /// <summary>
        /// Gets the department DAO.
        /// </summary>
        /// <value>
        /// The department DAO.
        /// </value>
        public IDepartmentDao DepartmentDao
        {
            get { return new SqlServerDepartmentDao(); }
        }

        /// <summary>
        /// Gets the account category DAO.
        /// </summary>
        /// <value>
        /// The account category DAO.
        /// </value>
        public IAccountCategoryDao AccountCategoryDao
        {
            get { return new SqlServerAccountCategoryDao(); }
        }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        public IBudgetItemDao BudgetItemDao
        {
            get { return new SqlServerBudgetItemDao(); }
        }

        /// <summary>
        /// Gets the pay item DAO.
        /// </summary>
        /// <value>
        /// The pay item DAO.
        /// </value>
        public IPayItemDao PayItemDao
        {
            get { return new SqlServerPayItemDao(); }
        }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        public IBudgetChapterDao BudgetChapterDao
        {
            get { return new SqlServerBudgetChapterDao(); }
        }

        public IFixedAssetHousingReportDao FixedAssetHousingReportDao
        {
            get { return new SqlServerFixedAssetHousingReportDao(); }
        }

        /// <summary>
        /// Gets the budget category DAO.
        /// </summary>
        /// <value>
        /// The budget category DAO.
        /// </value>
        public IBudgetCategoryDao BudgetCategoryDao
        {
            get { return new SqlServerBudgetCategoryDao(); }
        }

        /// <summary>
        /// Gets the budget source DAO.
        /// </summary>
        /// <value>
        /// The budget source DAO.
        /// </value>
        public IBudgetSourceDao BudgetSourceDao
        {
            get { return new SqlServerBudgetSourceDao(); }
        }

        /// <summary>
        /// Gets the fixed asset DAO.
        /// </summary>
        /// <value>
        /// The fixed asset DAO.
        /// </value>
        public IFixedAssetDao FixedAssetDao
        {
            get { return new SqlServerFixedAssetDao(); }
        }

        /// <summary>
        /// Gets the fixed asset category DAO.
        /// </summary>
        /// <value>
        /// The fixed asset category DAO.
        /// </value>
        public IFixedAssetCategoryDao FixedAssetCategoryDao
        {
            get { return new SqlServerFixedAssetCategoryDao(); }
        }

        /// <summary>
        /// Gets the customer DAO.
        /// </summary>
        /// <value>
        /// The customer DAO.
        /// </value>
        public ICustomerDao CustomerDao
        {
            get { return new SqlServerCustomerDao(); }
        }

        /// <summary>
        /// Gets the vendor DAO.
        /// </summary>
        /// <value>
        /// The vendor DAO.
        /// </value>
        public IVendorDao VendorDao
        {
            get { return new SqlServerVendorDao(); }
        }

        /// <summary>
        /// Gets the accounting object DAO.
        /// </summary>
        /// <value>
        /// The accounting object DAO.
        /// </value>
        public IAccountingObjectDao AccountingObjectDao
        {
            get { return new SqlServerAccountingObjectDao(); }
        }

        /// <summary>
        /// Gets the voucher list DAO.
        /// </summary>
        /// <value>
        /// The voucher list DAO.
        /// </value>
        public IVoucherListDao VoucherListDao
        {
            get { return new SqlServerVoucherListDao(); }
        }

        /// <summary>
        /// Gets the other accouting object DAO.
        /// </summary>
        /// <value>
        /// The other accouting object DAO.
        /// </value>
        public IAccountingObjectDao OtherAccoutingObjectDao
        {
            get { return new SqlServerAccountingObjectDao(); }
        }

        /// <summary>
        /// Gets the employee DAO.
        /// </summary>
        /// <value>
        /// The employee DAO.
        /// </value>
        public IEmployeeDao EmployeeDao
        {
            get { return new SqlServerEmployeeDao(); }
        }

        /// <summary>
        /// Gets the plan template list DAO.
        /// </summary>
        /// <value>
        /// The plan template list DAO.
        /// </value>
        public IPlanTemplateListDao PlanTemplateListDao
        {
            get { return new SqlServerPlanTemplateListDao(); }
        }

        /// <summary>
        /// Gets the plan template item DAO.
        /// </summary>
        /// <value>
        /// The plan template item DAO.
        /// </value>
        public IPlanTemplateItemDao PlanTemplateItemDao
        {
            get { return new SqlServerPlanTemplateItemDao(); }
        }

        /// <summary>
        /// Gets the employee pay item DAO.
        /// </summary>
        /// <value>
        /// The employee pay item DAO.
        /// </value>
        public IEmployeePayItemDao EmployeePayItemDao
        {
            get { return new SqlServerEmployeePayItemDao(); }
        }

        /// <summary>
        /// Gets the stock DAO.
        /// </summary>
        /// <value>
        /// The stock DAO.
        /// </value>
        public IStockDao StockDao
        {
            get { return new SqlserverStockDao(); }
        }

        /// <summary>
        /// Gets the inventory item DAO.
        /// </summary>
        /// <value>
        /// The inventory item DAO.
        /// </value>
        public IInventoryItemDao InventoryItemDao
        {
            get { return new SqlServerInventoryItemDao(); }
        }

        /// <summary>
        /// Gets the merger fund DAO.
        /// </summary>
        /// <value>
        /// The merger fund DAO.
        /// </value>
        public IMergerFundDao MergerFundDao
        {
            get { return new SqlServerMergerFundDao(); }
        }

        /// <summary>
        /// Gets the account tranfer DAO.
        /// </summary>
        /// <value>
        /// The account tranfer DAO.
        /// </value>
        public IAccountTranferDao AccountTranferDao
        {
            get { return new SqlServerAccountTranferDao(); }
        }

        /// <summary>
        /// Gets the database option DAO.
        /// </summary>
        /// <value>
        /// The database option DAO.
        /// </value>
        public IDBOptionDao DBOptionDao
        {
            get { return new SqlServerDBOptionDao(); }
        }

        /// <summary>
        /// Gets the report list DAO.
        /// </summary>
        /// <value>
        /// The report list DAO.
        /// </value>
        public IEntitiesDao.Report.IReportListDao ReportListDao
        {
            get { return new SqlServerReportListDao(); }
        }

        /// <summary>
        /// Gets the report group DAO.
        /// </summary>
        /// <value>
        /// The report group DAO.
        /// </value>
        public IEntitiesDao.Report.IReportGroupDao ReportGroupDao
        {
            get { return new SqlServerReportGroupDao(); }
        }

        /// <summary>
        /// Gets the auditting log DAO.
        /// </summary>
        /// <value>
        /// 
        /// The auditting log DAO.
        /// </value>
        public IAudittingLogDao AudittingLogDao
        {
            get { return new SqlServerAudittingLogDao(); }
        }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        public IAutoBusinessDao AutoBusinessDao
        {
            get { return new SqlServerAutoBusinessDao(); }
        }

        /// <summary>
        /// Gets the reference type DAO.
        /// </summary>
        /// <value>
        /// The reference type DAO.
        /// </value>
        public IRefTypeDao RefTypeDao
        {
            get { return new SqlServerRefTypeDao(); }
        }

        /// <summary>
        /// Gets the project DAO.
        /// </summary>
        /// <value>
        /// The project DAO.
        /// </value>
        public IProjectDao ProjectDao
        {
            get { return new SqlServerProjectDao(); }
        }

        /// <summary>
        /// Gets the fixed asset currency DAO.
        /// </summary>
        /// <value>
        /// The fixed asset currency DAO.
        /// </value>
        public IFixedAssetCurrencyDao FixedAssetCurrencyDao
        {
            get { return new SqlServerFixedAssetCurrencyDao(); }
        }

        /// <summary>
        /// Gets the budget source category.
        /// </summary>
        /// <value>
        /// The budget source category.
        /// </value>
        public IBudgetSourceCategoryDao BudgetSourceCategory
        {
            get { return new SqlServerBudgetSourceCategoryDao(); }
        }

        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        public ISearchDao SearchDao
        {
            get { return new SqlServerSearchDao(); }
        }

        /// <summary>
        /// Gets the employee leasing DAO.
        /// </summary>
        /// <value>
        /// The employee leasing DAO.
        /// </value>
        public IEmployeeLeasingDao EmployeeLeasingDao
        {
            get { return new SqlServerEmployeeLeasingDao(); }
        }

        /// <summary>
        /// Gets the building DAO.
        /// </summary>
        /// <value>
        /// The building DAO.
        /// </value>
        public IBuildingDao BuildingDao
        {
            get { return new SqlServerBuildingDao(); }
        }

        /// <summary>
        /// Gets the company profile DAO.
        /// </summary>
        /// <value>
        /// The company profile DAO.
        /// </value>
        public ICompanyProfileDao CompanyProfileDao
        {
            get { return new SqlServerCompanyProfileDao(); }
        }

        public IFixedAssetAccessaryDao FixedAssetAccessaryDao
        {
            get { return new SqlServerFixedAssetAccessaryDao(); }
        }

        #endregion

        #region Bussiness

        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        public ICaptitalAllocateVoucherDao CaptitalAllocateVoucherDao
        {
            get { return new SqlServerCaptitalAllocateVoucherDao(); }
        }

        /// <summary>
        /// Gets the general DAO.
        /// </summary>
        /// <value>
        /// The general DAO.
        /// </value>
        public IGeneralDao GeneralDao
        {
            get { return new SqlServerGeneralDao(); }
        }

        /// <summary>
        /// Gets the general detail DAO.
        /// </summary>
        /// <value>
        /// The general detail DAO.
        /// </value>
        public IGeneralDetailDao GeneralDetailDao
        {
            get { return new SqlServerGeneralDetailDao(); }
        }

        /// <summary>
        /// Gets the voucher type DAO.
        /// </summary>
        /// <value>
        /// The voucher type DAO.
        /// </value>
        public IVoucherTypeDao VoucherTypeDao { get { return new SqlServerVoucherTypeDao(); } }

        /// <summary>
        /// Gets the journal entry account.
        /// </summary>
        /// <value>
        /// The journal entry account.
        /// </value>
        public IJournalEntryAccountDao JournalEntryAccountDao { get { return new SqlServerJournalEntryAccountDao(); } }

        /// <summary>
        /// Gets the Salary DAO.
        /// </summary>
        /// <value>
        /// The Salary DAO.
        /// </value>
        public ISalaryDao SalaryDao { get { return new SqlServerSalaryDao(); } }

        /// <summary>
        /// Gets the general ledger DAO.
        /// </summary>
        /// <value>
        /// The general ledger DAO.
        /// </value>
        public IGeneralLedgerDao GeneralLedgerDao { get { return new SqlServerGeneralLedgerDao(); } }

        /// <summary>
        /// Gets the account balance DAO.
        /// </summary>
        /// <value>
        /// The account balance DAO.
        /// </value>
        public IAccountBalanceDao AccountBalanceDao { get { return new SqlServerAccountBalanceDao(); } }

        /// <summary>
        /// Gets the estimate DAO.
        /// </summary>
        /// <value>
        /// The estimate DAO.
        /// </value>
        public IEstimateDao EstimateDao { get { return new SqlServerEstimateDao(); } }

        /// <summary>
        /// Gets the estimate detail DAO.
        /// </summary>
        /// <value>
        /// The estimate detail DAO.
        /// </value>
        public IEstimateDetailDao EstimateDetailDao { get { return new SqlServerEstimateDetailDao(); } }

        /// <summary>
        /// Gets the cash DAO.
        /// </summary>
        /// <value>
        /// The cash DAO.
        /// </value>
        public ICashDao CashDao { get { return new SqlServerCashDao(); } }

        /// <summary>
        /// Gets the cash detail DAO.
        /// </summary>
        /// <value>
        /// The cash detail DAO.
        /// </value>
        public ICashDetailDao CashDetailDao { get { return new SqlServerCashDetailDao(); } }

        /// <summary>
        /// Gets the deposit DAO.
        /// </summary>
        /// <value>
        /// The deposit DAO.
        /// </value>
        public IDepositDao DepositDao { get { return new SqlServerDepositDao(); } }

        /// <summary>
        /// Gets the deposit detail DAO.
        /// </summary>
        /// <value>
        /// The deposit detail DAO.
        /// </value>
        public IDepositDetailDao DepositDetailDao { get { return new SqlServerDepositDetailDao(); } }

        /// <summary>
        /// Gets the ItemTransaction DAO.
        /// </summary>
        /// <value>
        /// The ItemTransaction DAO.
        /// </value>
        public IEntitiesDao.Inventory.IItemTransactionDao ItemTransactionDao { get { return new SqlServerItemTransactionDao(); } }

        /// <summary>
        /// Gets the ItemTransaction detail DAO.
        /// </summary>
        /// <value>
        /// The ItemTransaction detail DAO.
        /// </value>
        public IEntitiesDao.Inventory.IItemTransactionDetailDao ItemTransactionDetailDao { get { return new SqlServerItemTransactionDetailDao(); } }

        public IEntitiesDao.Tool.ISUIncrementDecrementDao SUIncrementDecrementDao { get { return new SqlServerSUIncrementDecrementDao(); } }

        public IEntitiesDao.Tool.ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao { get { return new SqlServerSUIncrementDecrementDetailDao(); } }

        /// <summary>
        /// Gets the fixed asset armortization DAO.
        /// </summary>
        /// <value>
        /// The fixed asset armortization DAO.
        /// </value>
        public IFixedAssetArmortizationDao FixedAssetArmortizationDao { get { return new SqlServerFixedAssetArmortizationDao(); } }

        /// <summary>
        /// Gets the fixed asset armortization detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset armortization detail DAO.
        /// </value>
        public IFixedAssetArmortizationDetailDao FixedAssetArmortizationDetailDao { get { return new SqlServerFixedAssetArmortizationDetailDao(); } }

        /// <summary>
        /// Gets the fixed asset increment DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment DAO.
        /// </value>
        public IFixedAssetDecrementDao FixedAssetDecrement { get { return new SqlServerFixedAssetDecrementDao(); } }

        /// <summary>
        /// Gets the fixed asset decrement detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset decrement detail DAO.
        /// </value>
        public IFixedAssetDecrementDetailDao FixedAssetDecrementDetailDao { get { return new SqlServerFixedAssetDecrementDetailDao(); } }

        public IFixedAssetDecrementDetailParallelDao FixedAssetDecrementDetailParallelDao { get { return new SqlServerFixedAssetDecrementDetailParallelDao(); } }

        /// <summary>
        /// Gets the fixed asset increment DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment DAO.
        /// </value>
        public IFixedAssetIncrementDao FixedAssetIncrementDao { get { return new SqlServerFixedAssetIncrementDao(); } }

        /// <summary>
        /// Gets the fixed asset increment detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment detail DAO.
        /// </value>
        public IFixedAssetIncrementDetailDao FixedAssetIncrementDetailDao { get { return new SqlServerFixedAssetIncrementDetailDao(); } }

        public IFixedAssetIncrementDetailParallelDao FixedAssetIncrementDetailParallelDao { get { return new SqlServerFixedAssetIncrementDetailParallelDao(); } }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        public IFixedAssetLedgerDao FixedAssetLedgerDao { get { return new SqlServerFixedAssetLedgerDao(); } }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        public IFixedAssetVoucherDao FixedAssetVoucherDao { get { return new SqlServerFixedAssetVoucherDao(); } }
        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        public IOpeningAccountEntryDao OpeningAccountEntryDao { get { return new SqlServerOpeningAccountEntryDao(); } }

        /// <summary>
        /// Gets the opening account entry detail DAO.
        /// </summary>
        /// <value>
        /// The opening account entry detail DAO.
        /// </value>
        public IOpeningAccountEntryDetailDao OpeningAccountEntryDetailDao { get { return new SqlServerOpeningAccountEntryDetailDao(); } }

        public IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao { get { return new SqlServerOpeningFixedAssetEntryDao(); } }

        #endregion

        #region IDaoFactory Members

        /// <summary>
        /// Gets the common DAO.
        /// </summary>
        /// <value>
        /// The common DAO.
        /// </value>
        public ICommonDao CommonDao
        {
            get { return new SqlCommonDao(); }
        }

        /// <summary>
        /// Gets the estimate detail statement DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement DAO.
        /// </value>
        public IEstimateDetailStatementDao EstimateDetailStatementDao
        {
            get { return new SqlServerEstimateDetailStatementDao(); }
        }

        /// <summary>
        /// Gets the estimate detail statement part b DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement part b DAO.
        /// </value>
        public IEstimateDetailStatementPartBDao EstimateDetailStatementPartBDao
        {
            get { return new SqlServerEstimateDetailStatementPartBDao(); }
        }

        /// <summary>
        /// Gets the estimate detail statement part b DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement part b DAO.
        /// </value>
        public IEstimateDetailStatementFixedAssetDao EstimateDetailStatementFixedAssetDao
        {
            get { return new SqlServerEstimateDetailStatementFixedAssetDao(); }
        }

        public IDepositDetailParallelDao DepositDetailParallelDao
        {
            get { return new SqlServerDepositDetailParallelDao(); }
        }

        public IItemTransactionDetailParallelDao ItemTransactionDetailParallelDao
        {
            get { return new SqlServerItemTransactionDetailParallelDao(); }
        }

        #endregion

        #region System

        public ILockDao LockDao { get { return new SqlServerLockDao(); } }

        /// <summary>
        /// Gets the role DAO.
        /// </summary>
        /// <value>
        /// The role DAO.
        /// </value>
        public IRoleDao RoleDao { get { return new SqlServerRoleDao(); } }

        /// <summary>
        /// Gets the site DAO.
        /// </summary>
        /// <value>
        /// The site DAO.
        /// </value>
        public ISiteDao SiteDao { get { return new SqlServerSiteDao(); } }

        /// <summary>
        /// Gets the permission DAO.
        /// </summary>
        /// <value>
        /// The permission DAO.
        /// </value>
        public IPermissionDao PermissionDao { get { return new SqlServerPermissionDao(); } }

        /// <summary>
        /// Gets the permission site DAO.
        /// </summary>
        /// <value>
        /// The permission site DAO.
        /// </value>
        public IPermissionSiteDao PermissionSiteDao { get { return new SqlServerPermissionSiteDao(); } }

        /// <summary>
        /// Gets the role site DAO.
        /// </summary>
        /// <value>
        /// The role site DAO.
        /// </value>
        public IRoleSiteDao RoleSiteDao { get { return new SqlServerRoleSiteDao(); } }

        /// <summary>
        /// Gets the user profile DAO.
        /// </summary>
        /// <value>
        /// The user profile DAO.
        /// </value>
        public IUserProfileDao UserProfileDao { get { return new SqlServerUserProfileDao(); } }

        #endregion


        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        public IOpeningInventoryEntryDao OpeningInventoryEntryDao
        {
            get { return new SqlServerOpeningInventoryEntryDao(); }
        }


        public ICalculateClosingDao CalculateClosingDao
        {
            get { return new SqlServerCalculateClosingDao(); }
        }


        public IMutualDao MutualDao
        {
            get { return new SqlServerMutualDao(); }
        }


        public ISalaryVoucherDao SalaryVoucherDao
        {
            get { return new SqlServerSalaryVoucherDao(); }
        }
        /// <summary>
        /// Gets the opening supply entry DAO.
        /// </summary>
        /// <value>The opening supply entry DAO.</value>
        public IOpeningSupplyEntryDao OpeningSupplyEntryDao { get { return new SqlServerOpeningSupplyEntryDao(); } }
        /// <summary>
        /// Gets the supply ledger DAO.
        /// </summary>
        /// <value>
        /// The supply ledger DAO.
        /// </value>
        public ISupplyLedgerDao SupplyLedgerDao { get { return new SqlServerSupplyLedgerDao(); } }

        public IEstimateExchangeRateDao EstimateExchangeRateDao { get { return new SqlServerEstimateExchangeRateDao(); } }

        public IReportDataTemplateDao ReportDataTemplateDao { get { return new SqlReportDataTemplateDao(); } }
    }
}