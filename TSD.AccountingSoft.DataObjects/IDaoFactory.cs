/***********************************************************************
 * <copyright file="IDaoFactory.cs" company="BUCA JSC">
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
    /// interface IDaoFactory
    /// </summary>
    public interface IDaoFactory
    {
        #region Dictionary

        IAccountingObjectCategoryDao AccountingObjectCategoryDao { get; }

        IActivityDao ActivityDao { get; }

        IAutoBusinessParallelDao AutoBusinessParallelDao { get; }

        IElectricalWorkDao ElectricalWorkDao { get; }

        /// <summary>
        /// Gets the account DAO.
        /// </summary>
        /// <value>
        /// The account DAO.
        /// </value>
        IAccountDao AccountDao { get; }

        /// <summary>
        /// Gets the automatic number DAO.
        /// </summary>
        /// <value>
        /// The automatic number DAO.
        /// </value>
        IAutoNumberDao AutoNumberDao { get; }

        IMutualDao MutualDao { get; }

        /// <summary>
        /// Gets the exchange rate DAO.
        /// </summary>
        /// <value>
        /// The exchange rate DAO.
        /// </value>
        IExchangeRateDao ExchangeRateDao { get; }

        IAutoNumberListDao AutoNumberListDao { get; }

        /// <summary>
        /// Gets the Calculate Closing Dao.
        /// </summary>
        /// <value>
        /// The Calculate Closing Dao.
        /// </value>
        ICalculateClosingDao CalculateClosingDao { get; }

        /// <summary>
        /// Gets the department DAO.
        /// </summary>
        /// <value>
        /// The department DAO.
        /// </value>
        IDepartmentDao DepartmentDao { get; }

        /// <summary>
        /// Gets the account category DAO.
        /// </summary>
        /// <value>
        /// The account category DAO.
        /// </value>
        IAccountCategoryDao AccountCategoryDao { get; }

        /// <summary>
        /// Gets the budget item DAO.
        /// </summary>
        /// <value>
        /// The budget item DAO.
        /// </value>
        IBudgetItemDao BudgetItemDao { get; }

        /// <summary>
        /// Gets the customer DAO.
        /// </summary>
        /// <value>
        /// The customer DAO.
        /// </value>
        ICustomerDao CustomerDao { get; }

        /// <summary>
        /// Gets the vendor DAO.
        /// </summary>
        /// <value>
        /// The vendor DAO.
        /// </value>
        IVendorDao VendorDao { get; }

        /// <summary>
        /// Gets the accounting object DAO.
        /// </summary>
        /// <value>
        /// The accounting object DAO.
        /// </value>
        IAccountingObjectDao AccountingObjectDao { get; }

        /// <summary>
        /// Gets the voucher list DAO.
        /// </summary>
        /// <value>
        /// The voucher list DAO.
        /// </value>
        IVoucherListDao VoucherListDao { get; }

        /// <summary>
        /// Gets the other accouting object DAO.
        /// </summary>
        /// <value>
        /// The other accouting object DAO.
        /// </value>
        IAccountingObjectDao OtherAccoutingObjectDao { get; }

        /// <summary>
        /// Gets the fixed asset category DAO.
        /// </summary>
        /// <value>
        /// The fixed asset category DAO.
        /// </value>
        IFixedAssetCategoryDao FixedAssetCategoryDao { get; }

        /// <summary>
        /// Gets the fixed asset DAO.
        /// </summary>
        /// <value>
        /// The fixed asset DAO.
        /// </value>
        IFixedAssetDao FixedAssetDao { get; }

        /// <summary>
        /// Gets the pay item DAO.
        /// </summary>
        /// <value>
        /// The pay item DAO.
        /// </value>
        IPayItemDao PayItemDao { get; }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        IBudgetChapterDao BudgetChapterDao { get; }

        /// <summary>
        /// Gets the budget chapter DAO.
        /// </summary>
        /// <value>
        /// The budget chapter DAO.
        /// </value>
        IFixedAssetHousingReportDao FixedAssetHousingReportDao { get; }

        /// <summary>
        /// Gets the budget category DAO.
        /// </summary>
        /// <value>
        /// The budget category DAO.
        /// </value>
        IBudgetCategoryDao BudgetCategoryDao { get; }

        /// <summary>
        /// Gets the budget source DAO.
        /// </summary>
        /// <value>
        /// The budget source DAO.
        /// </value>
        IBudgetSourceDao BudgetSourceDao { get; }

        /// <summary>
        /// Gets the employee DAO.
        /// </summary>
        /// <value>
        /// The employee DAO.
        /// </value>
        IEmployeeDao EmployeeDao { get; }

        /// <summary>
        /// Gets the plan template list DAO.
        /// </summary>
        /// <value>
        /// The plan template list DAO.
        /// </value>
        IPlanTemplateListDao PlanTemplateListDao { get; }

        /// <summary>
        /// Gets the plan template item DAO.
        /// </summary>
        /// <value>
        /// The plan template item DAO.
        /// </value>
        IPlanTemplateItemDao PlanTemplateItemDao { get; }

        /// <summary>
        /// Gets the employee pay item DAO.
        /// </summary>
        /// <value>
        /// The employee pay item DAO.
        /// </value>
        IEmployeePayItemDao EmployeePayItemDao { get; }

        /// <summary>
        /// Gets the stock DAO.
        /// </summary>
        /// <value>
        /// The stock DAO.
        /// </value>
        IStockDao StockDao { get; }

        /// <summary>
        /// Gets the inventory item DAO.
        /// </summary>
        /// <value>
        /// The inventory item DAO.
        /// </value>
        IInventoryItemDao InventoryItemDao { get; }

        /// <summary>
        /// Gets the capital allocate DAO.
        /// </summary>
        /// <value>
        /// The capital allocate DAO.
        /// </value>
        ICapitalAllocateDao CapitalAllocateDao { get; }

        /// <summary>
        /// Gets the currency DAO.
        /// </summary>
        /// <value>
        /// The currency DAO.
        /// </value>
        ICurrencyDao CurrencyDao { get; }

        /// <summary>
        /// Gets the bank DAO.
        /// </summary>
        /// <value>
        /// The bank DAO.
        /// </value>
        IBankDao BankDao { get; }

        /// <summary>
        /// Gets the merger fund DAO.
        /// </summary>
        /// <value>
        /// The merger fund DAO.
        /// </value>
        IMergerFundDao MergerFundDao { get; }

        /// <summary>
        /// Gets the account tranfer DAO.
        /// </summary>
        /// <value>
        /// The account tranfer DAO.
        /// </value>
        IAccountTranferDao AccountTranferDao { get; }

        /// <summary>
        /// Gets the database option DAO.
        /// </summary>
        /// <value>
        /// The database option DAO.
        /// </value>
        IDBOptionDao DBOptionDao { get; }

        /// <summary>
        /// Gets the report list DAO.
        /// </summary>
        /// <value>
        /// The report list DAO.
        /// </value>
        IReportListDao ReportListDao { get; }

        /// <summary>
        /// Gets the report group DAO.
        /// </summary>
        /// <value>
        /// The report group DAO.
        /// </value>
        IReportGroupDao ReportGroupDao { get; }

        /// <summary>
        /// Gets the auditting log DAO.
        /// </summary>
        /// <value>
        /// The auditting log DAO.
        /// </value>
        IAudittingLogDao AudittingLogDao { get; }

        /// <summary>
        /// Gets the automatic business DAO.
        /// </summary>
        /// <value>
        /// The automatic business DAO.
        /// </value>
        IAutoBusinessDao AutoBusinessDao { get; }

        /// <summary>
        /// Gets the reference type DAO.
        /// </summary>
        /// <value>
        /// The reference type DAO.
        /// </value>
        IRefTypeDao RefTypeDao { get; }

        /// <summary>
        /// Gets the project DAO.
        /// </summary>
        /// <value>
        /// The project DAO.
        /// </value>
        IProjectDao ProjectDao { get; }

        /// <summary>
        /// Gets the fixed asset currency DAO.
        /// </summary>
        /// <value>
        /// The fixed asset currency DAO.
        /// </value>
        IFixedAssetCurrencyDao FixedAssetCurrencyDao { get; }

        /// <summary>
        /// Gets the employee leasing DAO.
        /// </summary>
        /// <value>
        /// The employee leasing DAO.
        /// </value>
        IEmployeeLeasingDao EmployeeLeasingDao { get; }

        /// <summary>
        /// Gets the building DAO.
        /// </summary>
        /// <value>
        /// The building DAO.
        /// </value>
        IBuildingDao BuildingDao { get; }

        /// <summary>
        /// Gets the budget source category.
        /// </summary>
        /// <value>
        /// The budget source category.
        /// </value>
        IBudgetSourceCategoryDao BudgetSourceCategory { get; }

        /// <summary>
        /// Gets the company profile DAO.
        /// </summary>
        /// <value>
        /// The company profile DAO.
        /// </value>
        ICompanyProfileDao CompanyProfileDao { get; }

        ISalaryVoucherDao SalaryVoucherDao { get; }

        IFixedAssetAccessaryDao FixedAssetAccessaryDao { get; }

        IReportDataTemplateDao ReportDataTemplateDao { get; }

        #endregion

        #region Bussiness
        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        ISearchDao SearchDao { get; }

        /// <summary>
        /// Gets the captital allocate voucher DAO.
        /// </summary>
        /// <value>
        /// The captital allocate voucher DAO.
        /// </value>
        ICaptitalAllocateVoucherDao CaptitalAllocateVoucherDao { get; }

        /// <summary>
        /// Gets the account tranfer vourcher DAO.
        /// </summary>
        /// <value>
        /// The account tranfer vourcher DAO.
        /// </value>
        IAccountTranferVourcherDao AccountTranferVourcherDao { get; }

        /// <summary>
        /// Gets the general DAO.
        /// </summary>
        /// <value>
        /// The general DAO.
        /// </value>
        IGeneralDao GeneralDao { get; }

        /// <summary>
        /// Gets the general detail DAO.
        /// </summary>
        /// <value>
        /// The general detail DAO.
        /// </value>
        IGeneralDetailDao GeneralDetailDao { get; }

        /// <summary>
        /// Gets the voucher type DAO.
        /// </summary>
        /// <value>
        /// The voucher type DAO.
        /// </value>
        IVoucherTypeDao VoucherTypeDao { get; }

        /// <summary>
        /// Gets the journal entry account DAO.
        /// </summary>
        /// <value>
        /// The journal entry account DAO.
        /// </value>
        IJournalEntryAccountDao JournalEntryAccountDao { get; }

        /// <summary>
        /// Gets the Salary DAO.
        /// </summary>
        /// <value>
        /// The Salary DAO.
        /// </value>
        ISalaryDao SalaryDao { get; }

        /// <summary>
        /// Gets the general ledger DAO.
        /// </summary>
        /// <value>
        /// The general ledger DAO.
        /// </value>
        IGeneralLedgerDao GeneralLedgerDao { get; }
        /// <summary>
        /// Gets the opening supply entry DAO.
        /// </summary>
        /// <value>The opening supply entry DAO.</value>
        IOpeningSupplyEntryDao OpeningSupplyEntryDao { get; }

        /// <summary>
        /// Gets the supply ledger DAO.
        /// </summary>
        /// <value>
        /// The supply ledger DAO.
        /// </value>
        ISupplyLedgerDao SupplyLedgerDao { get; }
        /// <summary>
        /// Gets the account balance DAO.
        /// </summary>
        /// <value>
        /// The account balance DAO.
        /// </value>
        IAccountBalanceDao AccountBalanceDao { get; }

        /// <summary>
        /// Gets the estimate DAO.
        /// </summary>
        /// <value>
        /// The estimate DAO.
        /// </value>
        IEstimateDao EstimateDao { get; }

        /// <summary>
        /// Gets the estimate detail DAO.
        /// </summary>
        /// <value>
        /// The estimate detail DAO.
        /// </value>
        IEstimateDetailDao EstimateDetailDao { get; }

        /// <summary>
        /// Gets the cash DAO.
        /// </summary>
        /// <value>
        /// The cash DAO.
        /// </value>
        ICashDao CashDao { get; }

        /// <summary>
        /// Gets the cash detail DAO.
        /// </summary>
        /// <value>
        /// The cash detail DAO.
        /// </value>
        ICashDetailDao CashDetailDao { get; }

        /// <summary>
        /// Gets the deposit DAO.
        /// </summary>
        /// <value>
        /// The deposit DAO.
        /// </value>
        IDepositDao DepositDao { get; }

        /// <summary>
        /// Gets the deposit detail DAO.
        /// </summary>
        /// <value>
        /// The deposit detail DAO.
        /// </value>
        IDepositDetailDao DepositDetailDao { get; }

        /// <summary>
        /// Gets the ItemTransaction DAO.
        /// </summary>
        /// <value>
        /// The ItemTransaction DAO.
        /// </value>
        IItemTransactionDao ItemTransactionDao { get; }

        /// <summary>
        /// Gets the ItemTransaction detail DAO.
        /// </summary>
        /// <value>
        /// The ItemTransaction detail DAO.
        /// </value>
        IItemTransactionDetailDao ItemTransactionDetailDao { get; }

        ISUIncrementDecrementDao SUIncrementDecrementDao { get; }

        ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao { get; }

        /// <summary>
        /// Gets the fixed asset armortization DAO.
        /// </summary>
        /// <value>
        /// The fixed asset armortization DAO.
        /// </value>
        IFixedAssetArmortizationDao FixedAssetArmortizationDao { get; }

        /// <summary>
        /// Gets the fixed asset armortization detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset armortization detail DAO.
        /// </value>
        IFixedAssetArmortizationDetailDao FixedAssetArmortizationDetailDao { get; }

        /// <summary>
        /// Gets the fixed asset increment DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment DAO.
        /// </value>
        IFixedAssetDecrementDao FixedAssetDecrement { get; }

        /// <summary>
        /// Gets the fixed asset decrement detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset decrement detail DAO.
        /// </value>
        IFixedAssetDecrementDetailDao FixedAssetDecrementDetailDao { get; }

        IFixedAssetDecrementDetailParallelDao FixedAssetDecrementDetailParallelDao { get; }

        /// <summary>
        /// Gets the fixed asset increment DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment DAO.
        /// </value>
        IFixedAssetIncrementDao FixedAssetIncrementDao { get; }

        /// <summary>
        /// Gets the fixed asset increment detail DAO.
        /// </summary>
        /// <value>
        /// The fixed asset increment detail DAO.
        /// </value>
        IFixedAssetIncrementDetailDao FixedAssetIncrementDetailDao { get; }

        IFixedAssetIncrementDetailParallelDao FixedAssetIncrementDetailParallelDao { get; }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        IFixedAssetLedgerDao FixedAssetLedgerDao { get; }

        /// <summary>
        /// Gets the fixed asset ledger DAO.
        /// </summary>
        /// <value>
        /// The fixed asset ledger DAO.
        /// </value>
        IFixedAssetVoucherDao FixedAssetVoucherDao { get; }
        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        IOpeningAccountEntryDao OpeningAccountEntryDao { get; }

        /// <summary>
        /// Gets the opening account entry detail DAO.
        /// </summary>
        /// <value>
        /// The opening account entry detail DAO.
        /// </value>
        IOpeningAccountEntryDetailDao OpeningAccountEntryDetailDao { get; }

        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO.
        /// </value>
        IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao { get; }

        /// <summary>
        /// Gets the opening account entry DAO.
        /// </summary>
        /// <value>
        /// The opening account entry DAO. 
        /// </value>
        IOpeningInventoryEntryDao OpeningInventoryEntryDao { get; }

        /// <summary>
        /// Gets the common DAO.
        /// </summary>
        /// <value>
        /// The common DAO.
        /// </value>
        ICommonDao CommonDao { get; }

        /// <summary>
        /// Gets the estimate detail statement DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement DAO.
        /// </value>
        IEstimateDetailStatementDao EstimateDetailStatementDao { get; }

        /// <summary>
        /// Gets the estimate detail statement part b DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement part b DAO.
        /// </value>
        IEstimateDetailStatementPartBDao EstimateDetailStatementPartBDao { get; }

        /// <summary>
        /// Gets the estimate detail statement part b DAO.
        /// </summary>
        /// <value>
        /// The estimate detail statement part b DAO.
        /// </value>
        IEstimateDetailStatementFixedAssetDao EstimateDetailStatementFixedAssetDao { get; }

        IDepositDetailParallelDao DepositDetailParallelDao { get; }

        IItemTransactionDetailParallelDao ItemTransactionDetailParallelDao { get; }

        IEstimateExchangeRateDao EstimateExchangeRateDao { get; }

        #endregion

        #region System

        ILockDao LockDao { get; }

        /// <summary>
        /// Gets the role DAO.
        /// </summary>
        /// <value>
        /// The role DAO.
        /// </value>
        IRoleDao RoleDao { get; }

        /// <summary>
        /// Gets the site DAO.
        /// </summary>
        /// <value>
        /// The site DAO.
        /// </value>
        ISiteDao SiteDao { get; }

        /// <summary>
        /// Gets the permission DAO.
        /// </summary>
        /// <value>
        /// The permission DAO.
        /// </value>
        IPermissionDao PermissionDao { get; }

        /// <summary>
        /// Gets the permission site DAO.
        /// </summary>
        /// <value>
        /// The permission site DAO.
        /// </value>
        IPermissionSiteDao PermissionSiteDao { get; }

        /// <summary>
        /// Gets the role site DAO.
        /// </summary>
        /// <value>
        /// The role site DAO.
        /// </value>
        IRoleSiteDao RoleSiteDao { get; }

        /// <summary>
        /// Gets the user profile DAO.
        /// </summary>
        /// <value>
        /// The user profile DAO.
        /// </value>
        IUserProfileDao UserProfileDao { get; }

        #endregion
    }
}