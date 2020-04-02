/***********************************************************************
 * <copyright file="IModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Thangnk
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 12 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date: 19/05/2014  Author: ThangND   Description: Thêm các region, mọi người code cho hẳn hoi chút tạo các phần mục theo chuẩn để code không bị lẫn lộn
 * 
* ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Model.BusinessObjects.Search;
using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.Model.BusinessObjects.Tool;


namespace TSD.AccountingSoft.Model
{
    /// <summary>
    /// Interface IModel
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// The is convert data
        /// Biến này để xác định nếu là chuyển đổi dữ liệu từ Foxpro lên
        /// thì không kiểm tra trùng số chứng từ, do ở Foxpro ko bắt lỗi
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is convert data]; otherwise, <c>false</c>.
        /// </value>
        bool IsConvertData { get; set; }

        #region AccountingObjectCategory
        IList<AccountingObjectCategoryModel> GetAccountingObjectCategories();
        #endregion

        #region Activity
        IList<ActivityModel> GetActivitys();
        IList<ActivityModel> GetActivitysActive(bool isActive);
        ActivityModel GetActivity(int activityId);
        int AddActivity(ActivityModel activity);
        int UpdateActivity(ActivityModel activity);
        int DeleteActivity(int activityId);
        #endregion

        #region AutoBusinessParallel

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessParallelModel}.
        /// </returns>
        IList<AutoBusinessParallelModel> GetAutoBusinessParallels();

        /// <summary>
        /// Gets the autoBusinesss active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessParallelModel}.
        /// </returns>
        IList<AutoBusinessParallelModel> GetAutoBusinessParallelsActive();

        /// <summary>
        /// Gets the autoBusinesss non active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessParallelModel}.
        /// </returns>
        IList<AutoBusinessParallelModel> GetAutoBusinessParallelsNonActive();

        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// AutoBusinessParallelModel.
        /// </returns>
        AutoBusinessParallelModel GetAutoBusinessParallel(int autoBusinessId);

        /// <summary>
        /// Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddAutoBusinessParallel(AutoBusinessParallelModel autoBusiness);

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateAutoBusinessParallel(AutoBusinessParallelModel autoBusiness);

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteAutoBusinessParallel(int autoBusinessId);

        #endregion

        #region ItemTransaction

        /// <summary>
        /// Gets the item transactions by date.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<ItemTransactionModel> GetOutputItemTransactionsByDate(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the output item transactions by arise period.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<ItemTransactionModel> GetOutputItemTransactionsByArisePeriod(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode);

        /// <summary>
        /// Gets the item transactions by date.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<ItemTransactionModel> GetItemTransactionsByDate(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Res the cal output stock.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        void ReCalOutputStock(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode, int currencyDecimalDigits);

        /// <summary>
        /// Gets the deposit.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        ItemTransactionModel GetItemTransactionVoucher(string refNo);

        /// <summary>
        /// Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<ItemTransactionModel> GetItemTransactionVoucherByRefTypeId(int refTypeId);


        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="itemTransactionId">The payment voucher identifier.</param>
        /// <returns></returns>
        ItemTransactionModel GetItemTransactionVoucher(long itemTransactionId);

        /// <summary>
        /// Adds the receipt voucher.
        /// </summary>
        /// <param name="itemTransaction">The payment voucher.</param>
        /// <returns></returns>
        long AddItemTransactionVoucher(ItemTransactionModel itemTransaction, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="itemTransaction">The payment voucher.</param>
        /// <returns></returns>
        long UpdateItemTransactionVoucher(ItemTransactionModel itemTransaction, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="itemTransactionId">The payment voucher identifier.</param>
        /// <returns></returns>
        long DeleteItemTransactionVoucher(long itemTransactionId);

        decimal GetQuantityOfInventory(int inventoryItemID, int stockId, DateTime postDate, long refID, string currencyCode);

        #endregion

        #region CapitalAllocate

        /// <summary>
        /// Gets the capital allocates.
        /// </summary>
        /// <returns>
        /// IList{CapitalAllocateModel}.
        /// </returns>
        IList<CapitalAllocateModel> GetCapitalAllocates();

        ///// <summary>
        ///// Gets the capital allocates.
        ///// </summary>
        ///// <returns>IList{CapitalAllocateModel}.</returns>
        //IList<CapitalAllocateModel> GetCapitalAllocatesByDate(DateTime fromDate, DateTime toDate);


        /// <summary>
        /// Gets the capital allocates active.
        /// </summary>
        /// <returns>
        /// IList{CapitalAllocateModel}.
        /// </returns>
        IList<CapitalAllocateModel> GetCapitalAllocatesActive();

        /// <summary>
        /// Gets the capital allocate.
        /// </summary>
        /// <param name="capitalAllocateId">The capital allocate identifier.</param>
        /// <returns>
        /// CapitalAllocateModel.
        /// </returns>
        CapitalAllocateModel GetCapitalAllocate(int capitalAllocateId);

        /// <summary>
        /// Adds the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capital allocate.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddCapitalAllocate(CapitalAllocateModel capitalAllocate);

        /// <summary>
        /// Updates the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capital allocate.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateCapitalAllocate(CapitalAllocateModel capitalAllocate);

        /// <summary>
        /// Deletes the capital allocate.
        /// </summary>
        /// <param name="capitalAllocateId">The capital allocate identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteCapitalAllocate(int capitalAllocateId);

        #endregion

        #region Currency

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <returns>
        /// IList{CurrencyModel}.
        /// </returns>
        IList<CurrencyModel> GetCurrenciesIsMain();

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <returns>
        /// IList{CurrencyModel}.
        /// </returns>
        IList<CurrencyModel> GetCurrencies();

        /// <summary>
        /// Gets the currencies active.
        /// </summary>
        /// <returns>
        /// IList{CurrencyModel}.
        /// </returns>
        IList<CurrencyModel> GetCurrenciesActive();

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>
        /// CurrencyModel.
        /// </returns>
        CurrencyModel GetCurrency(int currencyId);

        /// <summary>
        /// Gets the currency by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        CurrencyModel GetCurrencyByCurrencyCode(string currencyCode);

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddCurrency(CurrencyModel currency);

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateCurrency(CurrencyModel currency);

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteCurrency(int currencyId);

        #endregion

        #region BugdetSource

        /// <summary>
        /// Gets the budget sources.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSources();

        /// <summary>
        /// Gets the budget source.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>
        /// BudgetSourceModel.
        /// </returns>
        BudgetSourceModel GetBudgetSource(int budgetSourceId);

        /// <summary>
        /// Gets the budget sources for combo tree.
        /// </summary>
        /// <param name="budgetSourcePropertyId">The budget source property identifier.</param>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSourcesForComboTree(int budgetSourcePropertyId);

        /// <summary>
        /// Gets the budget sources active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSourcesActive();

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        IList<BudgetSourceModel> GetBudgetSourcesIsParent(bool isParent);

        /// <summary>
        /// Gets the budget sources by fund.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        IList<BudgetSourceModel> GetBudgetSourcesByFund();

        /// <summary>
        /// Adds the budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddBudgetSource(BudgetSourceModel budgetSource);

        /// <summary>
        /// Updates the budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateBudgetSource(BudgetSourceModel budgetSource);

        /// <summary>
        /// Deletes the budget source.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteBudgetSource(int budgetSourceId);

        #endregion

        #region BudgetChapter

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        IList<BudgetChapterModel> GetBudgetChapters();

        /// <summary>
        /// Gets the budget chapters active.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        IList<BudgetChapterModel> GetBudgetChaptersActive();

        /// <summary>
        /// Gets the budget chapters non active.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        IList<BudgetChapterModel> GetBudgetChaptersNonActive();

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="budgetSourcePropertyId">The budget source property identifier.</param>
        /// <returns>
        /// BudgetChapterModel.
        /// </returns>
        BudgetChapterModel GetBudgetChapter(int budgetSourcePropertyId);

        /// <summary>
        /// Adds the budget chapter.
        /// </summary>
        /// <param name="budgetSourceProperty">The budget source property.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddBudgetChapter(BudgetChapterModel budgetSourceProperty);

        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="budgetSourceProperty">The budget source property.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateBudgetChapter(BudgetChapterModel budgetSourceProperty);

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="budgetSourcePropertyId">The budget source property identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteBudgetChapter(int budgetSourcePropertyId);

        #endregion

        #region BudgetCategory

        /// <summary>
        /// Gets the budget categories.
        /// </summary>
        /// <returns>
        /// IList{BudgetCategoryModel}.
        /// </returns>
        IList<BudgetCategoryModel> GetBudgetCategories();

        /// <summary>
        /// Gets the budget category.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>
        /// BudgetCategoryModel.
        /// </returns>
        BudgetCategoryModel GetBudgetCategory(int budgetCategoryId);

        /// <summary>
        /// Gets the budget categories for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>
        /// IList{BudgetCategoryModel}.
        /// </returns>
        IList<BudgetCategoryModel> GetBudgetCategoriesForComboTree(int budgetCategoryId);

        /// <summary>
        /// Gets the budget categories active.
        /// </summary>
        /// <returns>
        /// IList{BudgetCategoryModel}.
        /// </returns>
        IList<BudgetCategoryModel> GetBudgetCategoriesActive();

        /// <summary>
        /// Adds the budget category.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddBudgetCategory(BudgetCategoryModel budgetCategory);

        /// <summary>
        /// Updates the budget category.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateBudgetCategory(BudgetCategoryModel budgetCategory);

        /// <summary>
        /// Deletes the budget category.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteBudgetCategory(int budgetCategoryId);

        #endregion

        #region MergerFund

        /// <summary>
        /// Gets the merger funds.
        /// </summary>
        /// <returns>
        /// IList{MergerFundModel}.
        /// </returns>
        IList<MergerFundModel> GetMergerFunds();

        /// <summary>
        /// Gets the merger fund.
        /// </summary>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <returns>
        /// MergerFundModel.
        /// </returns>
        MergerFundModel GetMergerFund(int mergerFundId);

        /// <summary>
        /// Gets the merger funds for combo tree.
        /// </summary>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <returns>
        /// IList{MergerFundModel}.
        /// </returns>
        IList<MergerFundModel> GetMergerFundsForComboTree(int mergerFundId);

        /// <summary>
        /// Gets the merger funds active.
        /// </summary>
        /// <returns>
        /// IList{MergerFundModel}.
        /// </returns>
        IList<MergerFundModel> GetMergerFundsActive();

        /// <summary>
        /// Adds the merger fund.
        /// </summary>
        /// <param name="mergerFund">The merger fund.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddMergerFund(MergerFundModel mergerFund);

        /// <summary>
        /// Updates the merger fund.
        /// </summary>
        /// <param name="mergerFund">The merger fund.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateMergerFund(MergerFundModel mergerFund);

        /// <summary>
        /// Deletes the merger fund.
        /// </summary>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteMergerFund(int mergerFundId);

        #endregion

        #region Account

        /// <summary>
        /// Gets the account by code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        AccountModel GetAccountByCode(string accountCode);
        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        IList<AccountModel> GetAccounts();

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        /// <returns></returns>
        IList<AccountModel> GetAccounts(bool isDetail);

        /// <summary>
        /// Gets the accounts for combo tree.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        IList<AccountModel> GetAccountsForComboTree(int accountId);

        /// <summary>
        /// Gets the accounts active.
        /// </summary>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        IList<AccountModel> GetAccountsActive();

        /// <summary>
        /// Gets the accounts inventory item.
        /// </summary>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        IList<AccountModel> GetAccountsInventoryItem();

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// AccountModel.
        /// </returns>
        AccountModel GetAccount(int accountId);

        /// <summary>
        /// Adds the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddAccount(AccountModel account);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateAccount(AccountModel account);

        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteAccount(int accountId);

        #endregion

        #region AccountCategory

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        IList<AccountCategoryModel> GetAccountCategories();

        /// <summary>
        /// Gets the account categories for combo tree.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        IList<AccountCategoryModel> GetAccountCategoriesForComboTree(int accountCategoryId);

        /// <summary>
        /// Gets the account categories active.
        /// </summary>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        IList<AccountCategoryModel> GetAccountCategoriesActive();

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// AccountCategoryModel.
        /// </returns>
        AccountCategoryModel GetAccountCategory(int accountCategoryId);

        /// <summary>
        /// Adds the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddAccountCategory(AccountCategoryModel accountCategory);

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateAccountCategory(AccountCategoryModel accountCategory);

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteAccountCategory(int accountCategoryId);

        #endregion

        #region ReceiptVoucher

        /// <summary>
        /// Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<ReceiptVoucherModel> GetReceiptVoucherByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucherId">The receipt voucher identifier.</param>
        /// <returns></returns>
        ReceiptVoucherModel GetReceiptVoucher(long receiptVoucherId);

        /// <summary>
        /// Adds the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        long AddReceiptVoucher(ReceiptVoucherModel receiptVoucher, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        long UpdateReceiptVoucher(ReceiptVoucherModel receiptVoucher, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucherId">The receipt voucher identifier.</param>
        /// <returns></returns>
        long DeleteReceiptVoucher(long receiptVoucherId);

        #endregion

        #region PaymentVoucher

        /// <summary>
        /// Gets the deposit.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        CashModel GetPaymentVoucher(string refNo);

        CashModel GetCashForSalary(DateTime dateMonth);


        /// <summary>
        /// Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<CashModel> GetPaymentVoucherByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucherId">The payment voucher identifier.</param>
        /// <returns></returns>
        CashModel GetPaymentVoucher(long paymentVoucherId);

        /// <summary>
        /// Adds the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucher">The payment voucher.</param>
        /// <returns></returns>
        long AddPaymentVoucher(CashModel paymentVoucher, bool isGenerateParalell = false);

        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucher">The payment voucher.</param>
        /// <returns></returns>
        long UpdatePaymentVoucher(CashModel paymentVoucher, bool isGenerateParalell);

        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucherId">The payment voucher identifier.</param>
        /// <returns></returns>
        long DeletePaymentVoucher(long paymentVoucherId);

        #endregion

        #region ExchangeRate
        /// <summary>
        /// Gets the exchange rate.
        /// </summary>
        /// <param name="exchangeId">The exchange identifier.</param>
        /// <returns></returns>
        ExchangeRateModel GetExchangeRate(int exchangeId);

        /// <summary>
        /// Gets the exchange rates by date and budget source.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <returns></returns>
        ExchangeRateModel GetExchangeRatesByDateAndBudgetSource(DateTime fromdate, DateTime todate, string budgetSourceCode);

        /// <summary>
        /// Gets the exchange rates.
        /// </summary>
        /// <returns></returns>
        IList<ExchangeRateModel> GetExchangeRates();

        /// <summary>
        /// Gets the exchange rates by date.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <returns></returns>
        IList<ExchangeRateModel> GetExchangeRatesByDate(DateTime fromdate, DateTime todate);

        /// <summary>
        /// Gets the exchange rates by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<ExchangeRateModel> GetExchangeRatesByActive(bool isActive);

        /// <summary>
        /// Inserts the exchange rate.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <returns></returns>
        int AddExchangeRate(ExchangeRateModel exchangeRate);

        /// <summary>
        /// Updates the exchange rate.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <returns></returns>
        int UpdateExchangeRate(ExchangeRateModel exchangeRate);

        /// <summary>
        /// Deletes the exchange rate.
        /// </summary>
        /// <param name="exchangeRateId">The exchange rate identifier.</param>
        /// <returns></returns>
        int DeleteExchangeRate(int exchangeRateId);
        #endregion

        #region Calculate closing
        /// <summary>
        /// Lấy tổng số có thể chi theo tài khoản chi
        /// </summary>
        /// <param name="paymentAccount">The payment account.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="isApproximate">if set to <c>true</c> [is approximate].</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        CalculateClosingModel GetCalculateClosing(string paymentAccount, string whereClause, string currencyCode, string todate, bool isApproximate, long refId, int refTypeId);

        /// <summary>
        /// Gets the calculate closing.
        /// </summary>
        /// <param name="debitAccount">The debit account.</param>
        /// <param name="creditAccount">The credit account.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="isApproximate">if set to <c>true</c> [is approximate].</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        CalculateClosingModel GetCalculateClosing(string debitAccount, string creditAccount, string whereClause, string currencyCode, string todate, bool isApproximate, long refId, int refTypeId);

        CalculateClosingModel AmountExist(string accountCode, string currentcyCode);


        #endregion

        #region AutoNumber

        /// <summary>
        /// Gets the type of the automatic number by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>
        /// AutoNumberModel.
        /// </returns>
        AutoNumberModel GetAutoNumberByRefType(int refType);

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <returns></returns>
        IList<AutoNumberModel> GetAutoNumbers();

        /// <summary>
        /// Updates the automatic numbers.
        /// </summary>
        /// <param name="autoNumbers">The automatic numbers.</param>
        /// <returns></returns>
        string UpdateAutoNumbers(List<AutoNumberModel> autoNumbers);

        #endregion

        #region Department

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns>
        /// IList{DepartmentModel}.
        /// </returns>
        IList<DepartmentModel> GetDepartments();

        /// <summary>
        /// Gets the departments active.
        /// </summary>
        /// <returns>
        /// IList{DepartmentModel}.
        /// </returns>
        IList<DepartmentModel> GetDepartmentsActive();

        /// <summary>
        /// Gets the departments non active.
        /// </summary>
        /// <returns>
        /// IList{DepartmentModel}.
        /// </returns>
        IList<DepartmentModel> GetDepartmentsNonActive();

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// DepartmentModel.
        /// </returns>
        DepartmentModel GetDepartment(int departmentId);

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddDepartment(DepartmentModel department);

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateDepartment(DepartmentModel department);

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteDepartment(int departmentId);

        #endregion

        #region BudgetItem

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItems();

        /// <summary>
        /// Gets the budget items by group.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByGroup();

        /// <summary>
        /// Gets the budget items by group item.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByGroupItem();

        /// <summary>
        /// Gets the budget items by kind item.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByKindItem();

        /// <summary>
        /// Gets the budget items by item.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByItem();

        /// <summary>
        /// Gets the budget items by receipt.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByReceipt();

        /// <summary>
        /// Gets the budget items capital allocate.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsCapitalAllocate();



        /// <summary>
        /// Gets the budget items pay voucher.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsPayVoucher();

        /// <summary>
        /// Gets the budget items by receipt for estimate.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsByReceiptForEstimate();

        /// <summary>
        /// Gets the budget items by payment.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        IList<BudgetItemModel> GetBudgetItemsByPayment();

        /// <summary>
        /// Gets the budget items by payment for estimate.
        /// </summary>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemsByPaymentForEstimate();

        /// <summary>
        /// Gets the budget item and sub item.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<BudgetItemModel> GetBudgetItemAndSubItem(int budgetItemType, bool isActive);

        /// <summary>
        /// Gets the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        /// BudgetItemModel.
        /// </returns>
        BudgetItemModel GetBudgetItem(int budgetItemId);

        /// <summary>
        /// Adds the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddBudgetItem(BudgetItemModel budgetItem);

        /// <summary>
        /// Updates the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateBudgetItem(BudgetItemModel budgetItem);

        /// <summary>
        /// Deletes the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteBudgetItem(int budgetItemId);

        #endregion

        #region FixedAssetCategory

        /// <summary>
        /// Gets the fixed asset category.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetCategoryModel}.
        /// </returns>
        IList<FixedAssetCategoryModel> GetFixedAssetCategories();

        IList<FixedAssetCategoryModel> GetFixedAssetCategoriesComboCheck();

        /// <summary>
        /// Gets the fixed asset categorys for combo tree.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns>
        /// IList{FixedAssetCategoryModel}.
        /// </returns>
        IList<FixedAssetCategoryModel> GetFixedAssetCategoriesForComboTree(int fixedAssetCategoryId);

        /// <summary>
        /// Gets the fixed asset categorys active.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetCategoryModel}.
        /// </returns>
        IList<FixedAssetCategoryModel> GetFixedAssetCategoriesActive();

        /// <summary>
        /// Gets the fixed asset category by identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns>
        /// FixedAssetCategoryModel.
        /// </returns>
        FixedAssetCategoryModel GetFixedAssetCategoryById(int fixedAssetCategoryId);

        /// <summary>
        /// Adds the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory);

        /// <summary>
        /// Updates the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory);

        /// <summary>
        /// Deletes the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteFixedAssetCategory(int fixedAssetCategoryId);

        #endregion

        #region FixedAsset

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetModel}.
        /// </returns>
        IList<FixedAssetModel> GetFixedAsset();

        /// <summary>
        /// Gets the fixed assets active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// IList{FixedAssetModel}.
        /// </returns>
        IList<FixedAssetModel> GetFixedAssetsActive(bool isActive);

        /// <summary>
        /// Gets the fixed assets active with fixed asset currency.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<FixedAssetModel> GetFixedAssetsActiveWithFixedAssetCurrency(bool isActive);

        /// <summary>
        /// Gets all fixed assets with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <returns>
        /// IList{FixedAssetModel}.
        /// </returns>
        IList<FixedAssetModel> GetAllFixedAssetsWithStoreProdure(string storeProdure);

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// FixedAssetModel.
        /// </returns>
        FixedAssetModel GetFixedAssetById(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// FixedAssetModel.
        /// </returns>
        FixedAssetModel GetFixedAssetRemainingQuantity(int fixedAssetId);


        /// <summary>
        /// Gets the fixed asset by fa increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetModel GetFixedAssetByFaIncrement(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset by fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset by fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetModel GetFixedAssetByFaOpening(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset by fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, string currencyCode, string postedDate);

        /// <summary>
        /// Gets the fixed asset by fa decrement quantity.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, string currencyCode, int refTypeId);

        /// <summary>
        /// Adds the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddFixedAsset(FixedAssetModel fixedAsset);

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateFixedAsset(FixedAssetModel fixedAsset);

        /// <summary>
        /// Adds the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <param name="replication">The replication.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddFixedAssetReplication(FixedAssetModel fixedAsset, int replication);

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <param name="replication">The replication.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateFixedAssetReplication(FixedAssetModel fixedAsset, int replication);
        /// <summary>
        /// Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteFixedAsset(int fixedAssetId);

        #endregion

        #region PayItem

        /// <summary>
        /// Gets the pay items.
        /// </summary>
        /// <returns>
        /// IList{PayItemModel}.
        /// </returns>
        IList<PayItemModel> GetPayItems();

        /// <summary>
        /// Gets the pay items active.
        /// </summary>
        /// <returns>
        /// IList{PayItemModel}.
        /// </returns>
        IList<PayItemModel> GetPayItemsActive();




        /// <summary>
        /// Gets the pay item.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <returns>
        /// PayItemModel.
        /// </returns>
        PayItemModel GetPayItem(int payItemId);

        /// <summary>
        /// Adds the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddPayItem(PayItemModel payItem);

        /// <summary>
        /// Updates the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdatePayItem(PayItemModel payItem);

        /// <summary>
        /// Deletes the pay item.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeletePayItem(int payItemId);

        #endregion

        #region Customer

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// CustomerModel.
        /// </returns>
        CustomerModel GetCustomer(int customerId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// List{CustomerModel}.
        /// </returns>
        List<CustomerModel> GetCustomers();

        /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List{CustomerModel}.
        /// </returns>
        List<CustomerModel> GetCustomersByActive(bool isActive);

        /// <summary>
        /// Inserts the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int InsertCustomer(CustomerModel customer);

        /// <summary>
        /// Updates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateCustomer(CustomerModel customer);

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteCustomer(int customerId);
        #endregion

        #region Vendor
        /// <summary>
        /// Gets the vendor.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// VendorModel.
        /// </returns>
        VendorModel GetVendor(int vendorId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// List{VendorModel}.
        /// </returns>
        List<VendorModel> GetVendors();

        /// <summary>
        /// Gets the vendors by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<VendorModel> GetVendorsByActive(bool isActive);

        /// <summary>
        /// Inserts the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int InsertVendor(VendorModel vendor);

        /// <summary>
        /// Updates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateVendor(VendorModel vendor);

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteVendor(int vendorId);

        #endregion

        #region AccountingObject

        AccountingObjectModel GetAccountingObject(int accountingId);

        IList<AccountingObjectModel> GetAccountingObjects();
        IList<AccountingObjectModel> GetAccountingObjectsForList();

        IList<AccountingObjectModel> GetAccountingObjectsByActive(bool isActive);

        int InsertAccountingObject(AccountingObjectModel accountingObject);

        int UpdateAccountingObject(AccountingObjectModel accountingObject);

        int DeleteAccountingObject(int accountingId);

        #endregion

        #region VoucherList

        /// <summary>
        /// Gets the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        /// VoucherListModel.
        /// </returns>
        VoucherListModel GetVoucherList(int voucherListId);

        /// <summary>
        /// Gets the voucher lists.
        /// </summary>
        /// <returns>
        /// IList{VoucherListModel}.
        /// </returns>
        IList<VoucherListModel> GetVoucherLists();

        /// <summary>
        /// Inserts the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int InsertVoucherList(VoucherListModel voucherList);

        /// <summary>
        /// Updates the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateVoucherList(VoucherListModel voucherList);

        /// <summary>
        /// Deletes the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteVoucherList(int voucherListId);
        #endregion

        #region Employee

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>
        /// IList{EmployeeModel}.
        /// </returns>
        IList<EmployeeModel> GetEmployees();

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// IList{EmployeeModel}.
        /// </returns>
        IList<EmployeeModel> GetEmployeesByDepartmentId(int departmentId);

        /// <summary>
        /// Gets the active employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        IList<EmployeeModel> GetActiveEmployeesByDepartmentId(int departmentId);

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="refdate">The refdate.</param>
        /// <returns></returns>
        IList<EmployeeModel> GetEmployeesByRefdateSalary(DateTime refdate);

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        IList<EmployeeModel> GetEmployeesByDepartmentId(bool isListDepartment, string departmentId);

        //ThangNK Add 
        IList<EmployeeModel> GetEmployeesByDepartmentIdAndMonth(bool isListDepartment, string departmentId, string strDate, int salaryOptionType, int salaryCalcType);
        IList<EmployeeModel> GetEmployeesByMonthDateAndRefNo(string strDate, string refNo);

        /// <summary>
        /// Gets the employees active.
        /// </summary>
        /// <returns>
        /// IList{EmployeeModel}.
        /// </returns>
        IList<EmployeeModel> GetEmployeesActive();

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>
        /// EmployeeModel.
        /// </returns>
        EmployeeModel GetEmployee(int employeeId);

        /// <summary>
        /// Gets the employee for edit.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        EmployeeModel GetEmployeeForEdit(int employeeId);

        /// <summary>
        /// Gets the employee for view salary.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        EmployeeModel GetEmployeeForViewSalary(int employeeId, DateTime refDate, decimal exchangeRate);


        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddEmployee(EmployeeModel employee);

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateEmployee(EmployeeModel employee);

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteEmployee(int employeeId);


        IList<EmployeeModel> GetEmployeesIsRetail(string monthDate, bool isRetail);

        #endregion

        #region PlanTemplateList

        /// <summary>
        /// Gets the plan template lists.
        /// </summary>
        /// <returns>
        /// IList{PlanTemplateListModel}.
        /// </returns>
        IList<PlanTemplateListModel> GetPlanTemplateLists();

        /// <summary>
        /// Gets the plan template lists by receipt.
        /// </summary>
        /// <returns>
        /// IList{PlanTemplateListModel}.
        /// </returns>
        IList<PlanTemplateListModel> GetPlanTemplateListsByReceipt();

        /// <summary>
        /// Gets the plan template lists by payment.
        /// </summary>
        /// <returns>
        /// IList{PlanTemplateListModel}.
        /// </returns>
        IList<PlanTemplateListModel> GetPlanTemplateListsByPayment();

        /// <summary>
        /// Gets the plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns>
        /// PlanTemplateListModel.
        /// </returns>
        PlanTemplateListModel GetPlanTemplateList(int planTemplateListId);

        /// <summary>
        /// Adds the plan template list.
        /// </summary>
        /// <param name="planTemplateList">The plan template list.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddPlanTemplateList(PlanTemplateListModel planTemplateList);

        /// <summary>
        /// Updates the plan template list.
        /// </summary>
        /// <param name="planTemplateList">The plan template list.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdatePlanTemplateList(PlanTemplateListModel planTemplateList);

        /// <summary>
        /// Deletes the plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeletePlanTemplateList(int planTemplateListId);

        /// <summary>
        /// LinhMC add
        /// Checks the constraint plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns></returns>
        bool CheckConstraintPlanTemplateList(int planTemplateListId);

        #endregion

        #region PlanTemplateItem

        /// <summary>
        /// Gets the plan template items.
        /// </summary>
        /// <returns>
        /// IList{PlanTemplateItemModel}.
        /// </returns>
        IList<PlanTemplateItemModel> GetPlanTemplateItems();

        /// <summary>
        /// Gets the plan template items.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns>
        /// IList{PlanTemplateItemModel}.
        /// </returns>
        IList<PlanTemplateItemModel> GetPlanTemplateItemsByPlanTemplateListId(int planTemplateListId);

        /// <summary>
        /// Gets the plan template items.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <param name="planYear">The plan template list identifier.</param>
        /// <returns>
        /// IList{PlanTemplateItemModel}.
        /// </returns>
        IList<PlanTemplateItemModel> GetPlanTemplateItemsForEstimate(int planTemplateListId, short planYear, int budgetSourceCategoryId);

        IList<PlanTemplateItemModel> GetPlanTemplateItemsForEstimateUpdate(int planTemplateListId, short planYear, int budgetSourceCategoryId, int option);

        #endregion

        #region Stock

        /// <summary>
        /// Gets the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        /// StockModel.
        /// </returns>
        StockModel GetStock(int stockId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// IList{StockModel}.
        /// </returns>
        IList<StockModel> GetStocks();

        /// <summary>
        /// Gets the stock by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// IList{StockModel}.
        /// </returns>
        IList<StockModel> GetStockByActives(bool isActive);

        /// <summary>
        /// Inserts the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int InsertStock(StockModel stock);

        /// <summary>
        /// Updates the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateStock(StockModel stock);

        /// <summary>
        /// Deletes the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteStock(int stockId);

        #endregion

        #region  InventoryItem
        /// <summary>
        /// Gets the inventory items by stock.
        /// </summary>
        /// <param name="itemStock">The item stock.</param>
        /// <returns></returns>
        IList<InventoryItemModel> GetInventoryItemsByStock(int itemStock);
        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        /// InventoryItemModel.
        /// </returns>
        InventoryItemModel GetInventoryItem(int inventoryItemId);

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <returns></returns>
        IList<InventoryItemModel> GetInventoryItems();


        /// <summary>
        /// Gets the inventory items by stock.
        /// </summary>
        /// <param name="itemStockId">The item stock identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="postDate">The post date.</param>
        /// <param name="curentcy">The curentcy.</param>
        /// <returns></returns>
        IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId, long refId, DateTime postDate, string curentcy);
        IList<InventoryItemModel> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode);

        /// <summary>
        /// Inserts the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int InsertInventoryItem(InventoryItemModel inventoryItem);

        /// <summary>
        /// Updates the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateInventoryItem(InventoryItemModel inventoryItem);

        /// <summary>
        /// Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int Delete(int inventoryItemId);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestModel&gt;.</returns>
        IList<OpeningSupplyEntryModel> GetOpeningSupplyEntry();

        /// <summary>
        /// Bus the commitment request voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedDetail">if set to <c>true</c> [is included detail].</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        OpeningSupplyEntryModel GetOpeningSupplyEntryVoucher(long refId, bool isIncludedDetail);

        string UpdateOpeningSupplyEntry(IList<OpeningSupplyEntryModel> openingCommitment);
        string DeleteOpeningSupplyEntry(long refId);
        #endregion

        #region Bank

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <returns>
        /// IList{BankModel}.
        /// </returns>
        IList<BankModel> GetBanks();

        /// <summary>
        /// Gets the banks active.
        /// </summary>
        /// <returns>
        /// IList{BankModel}.
        /// </returns>
        IList<BankModel> GetBanksActive();

        /// <summary>
        /// Gets the banks non active.
        /// </summary>
        /// <returns>
        /// IList{BankModel}.
        /// </returns>
        IList<BankModel> GetBanksNonActive();

        /// <summary>
        /// Gets the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns>
        /// BankModel.
        /// </returns>
        BankModel GetBank(int bankId);

        /// <summary>
        /// Adds the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddBank(BankModel bank);

        /// <summary>
        /// Updates the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateBank(BankModel bank);

        /// <summary>
        /// Deletes the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteBank(int bankId);

        #endregion

        #region AccountTranfer

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns>
        /// IList{AccountTranferModel}.
        /// </returns>
        IList<AccountTranferModel> GetAccountTranfers();

        /// <summary>
        /// Gets the account tranfers active.
        /// </summary>
        /// <returns>
        /// IList{AccountTranferModel}.
        /// </returns>
        IList<AccountTranferModel> GetAccountTranfersActive();

        /// <summary>
        /// Gets the account tranfers non active.
        /// </summary>
        /// <returns>
        /// IList{AccountTranferModel}.
        /// </returns>
        IList<AccountTranferModel> GetAccountTranfersNonActive();

        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns>
        /// AccountTranferModel.
        /// </returns>
        AccountTranferModel GetAccountTranfer(int accountTranferId);

        /// <summary>
        /// Adds the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddAccountTranfer(AccountTranferModel accountTranfer);

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateAccountTranfer(AccountTranferModel accountTranfer);

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteAccountTranfer(int accountTranferId);

        #endregion

        #region DBOption

        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="optionId">The option identifier.</param>
        /// <returns></returns>
        DBOptionModel GetDBOption(string optionId);

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptions();

        /// <summary>
        /// Gets the database options system.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsSystem();

        /// <summary>
        /// Gets the database options is string.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsIsString();

        /// <summary>
        /// Gets the database options is numeric.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsIsNumeric();

        /// <summary>
        /// Gets the database options is boolean.
        /// </summary>
        /// <returns>
        /// IList{DBOptionModel}.
        /// </returns>
        IList<DBOptionModel> GetDBOptionsIsBoolean();

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="isListDbOption">if set to <c>true</c> [is list database option].</param>
        /// <param name="dbOption">The database option.</param>
        /// <returns></returns>
        string UpdateDBOption(bool isListDbOption, DBOptionModel dbOption);

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dbOptions">The database options.</param>
        /// <returns></returns>
        string UpdateDBOption(List<DBOptionModel> dbOptions);

        #endregion

        #region ReportList

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <returns>
        /// List{ReportListModel}.
        /// </returns>
        List<ReportListModel> GetReportLists();

        /// <summary>
        /// Gets the report lists by report group.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns>
        /// List{ReportListModel}.
        /// </returns>
        List<ReportListModel> GetReportListsByReportGroup(int reportGroupId);

        /// <summary>
        /// Gets the report list by identifier.
        /// </summary>
        /// <param name="reportListId">The report list identifier.</param>
        /// <returns>
        /// ReportListModel.
        /// </returns>
        ReportListModel GetReportListById(string reportListId);

        /// <summary>
        /// Gets the report groups.
        /// </summary>
        /// <returns>
        /// List{ReportGroupModel}.
        /// </returns>
        List<ReportGroupModel> GetReportGroups();

        /// <summary>
        /// Gets the report group by identifier.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns>
        /// ReportGroupModel.
        /// </returns>
        ReportGroupModel GetReportGroupById(int reportGroupId);

        /// <summary>
        /// Updates the report list.
        /// </summary>
        /// <param name="reportList">The report list.</param>
        /// <returns></returns>
        string UpdateReportList(ReportListModel reportList);

        #endregion

        #region AudittingLog

        /// <summary>
        /// Gets the auditting logs.
        /// </summary>
        /// <returns>
        /// IList{AudittingLogModel}.
        /// </returns>
        IList<AudittingLogModel> GetAudittingLogs();

        /// <summary>
        /// Adds the auditing log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        int AddAuditingLog(AudittingLogModel audittingLog);

        /// <summary>
        /// Deletes the auditting log.
        /// </summary>
        /// <param name="audittingLogId">The auditting log identifier.</param>
        /// <returns></returns>
        int DeleteAudittingLog(int audittingLogId);

        #endregion

        #region Estimate

        /// <summary>
        /// Gets the payment estimates.
        /// </summary>
        /// <returns></returns>
        IList<EstimateModel> GetEstimates();

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<EstimateModel> GetEstimatesByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The post date.</param>
        /// <returns></returns>
        IList<EstimateModel> GetEstimatesByYearOfPostDate(int refTypeId, string refDate);

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <returns></returns>
        IList<EstimateModel> GetEstimatesByYearOfEstimate(int refTypeId, short yearOfEstimate, int budgetSourceCategoryId);

        IList<EstimateModel> GetEstimatesByYearOfEstimateNoBudget(int refTypeId, short yearOfEstimate);

        /// <summary>
        /// Gets the estimates by year of estimate.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        IList<EstimateModel> GetEstimatesByYearOfEstimate(int refTypeId, short yearOfEstimate);

        /// <summary>
        /// Gets the payment estimate.
        /// </summary>
        /// <param name="estimateId">The payment estimate identifier.</param>
        /// <returns></returns>
        EstimateModel GetEstimate(long estimateId);

        EstimateModel GetEstimateOption(long refId, int Option, int budgetSourceCategoryId, int YearOfPlaning);

        EstimateModel GetEstimateOption(int planTemplateListId, int yearOfPlaning);


        /// <summary>
        /// Adds the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        long AddEstimate(EstimateModel estimate);

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        long UpdateEstimate(EstimateModel estimate);

        /// <summary>
        /// Deletes the estimate.
        /// </summary>
        /// <param name="estimateId">The estimate identifier.</param>
        /// <returns></returns>
        long DeleteEstimate(long estimateId);

        #endregion

        #region Deposit

        /// <summary>
        /// Gets the deposits.
        /// </summary>
        /// <returns>
        /// IList{DepositModel}.
        /// </returns>
        IList<DepositModel> GetDeposits();

        /// <summary>
        /// Gets the deposits by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<DepositModel> GetDepositsByYearOfPostDate(int refTypeId, string refDate);

        /// <summary>
        /// Gets the deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{DepositModel}.
        /// </returns>
        IList<DepositModel> GetDepositsByRefTypeId(int refTypeId);
        /// <summary>
        /// Gets the deposit.
        /// </summary>
        /// <param name="depositId">The deposit identifier.</param>
        /// <returns>
        /// DepositModel.
        /// </returns>
        DepositModel GetDeposit(long depositId);

        DepositModel GetDepositForSalary(DateTime dateMonth);


        /// <summary>
        /// Gets the deposit.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        DepositModel GetDeposit(string refNo);

        /// <summary>
        /// Adds the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        long AddDeposit(DepositModel deposit);

        long AddDeposit(DepositModel deposit, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        long UpdateDeposit(DepositModel deposit);

        long UpdateDeposit(DepositModel deposit, bool isAutoGenerateParallel);
        /// <summary>
        /// Deletes the deposit.
        /// </summary>
        /// <param name="depositId">The deposit identifier.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        long DeleteDeposit(long depositId);

        #endregion

        #region Salary

        /// <summary>
        /// Gets the state of the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        SalaryModel GetCalSalaryState(SalaryModel model);
        /// <summary>
        /// Gets the salary by moth.
        /// </summary>
        /// <returns></returns>
        List<SalaryModel> GetSalaryByMoth();

        /// <summary>
        /// Checks the state of the cal salary posted.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        bool CheckCalSalaryPostedState(SalaryModel model);
        /// <summary>
        /// Checks the state of the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        bool CheckCalSalaryState(SalaryModel model);
        /// <summary>
        /// Saves the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        int SaveCalSalary(SalaryModel model);
        /// <summary>
        /// Saves all cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        int SaveAllCalSalary(SalaryModel model);
        /// <summary>
        /// Deletes the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        int DeleteCalSalary(SalaryModel model);
        /// <summary>
        /// Deletes all cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        int DeleteAllCalSalary(SalaryModel model);
        /// <summary>
        /// Saves the posted all salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        int SavePostedAllSalary(SalaryModel model);
        /// <summary>
        /// Saves the posted salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        int SavePostedSalary(SalaryModel model);
        /// <summary>
        /// Gets the reference no salary.
        /// </summary>
        /// <param name="currDate">The curr date.</param>
        /// <returns></returns>
        string GetRefNoSalary(string currDate, string currencyCode);

        string GetRefNoInEmployeePayroll(string currDate);

        string SararyExistRefNoInDay(string currDate, string refNo);


        #endregion

        #region VoucherType

        /// <summary>
        /// Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        IList<VoucherTypeModel> GetVoucherTypes();

        VoucherTypeModel GetVoucherTypeByCode(string code);

        /// <summary>
        /// Gets the voucher types active.
        /// </summary>
        /// <returns></returns>
        IList<VoucherTypeModel> GetVoucherTypesActive();

        #endregion

        #region AutoBusiness

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessModel}.
        /// </returns>
        IList<AutoBusinessModel> GetAutoBusinesss();

        /// <summary>
        /// Gets the autoBusinesss active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessModel}.
        /// </returns>
        IList<AutoBusinessModel> GetAutoBusinesssActive();

        /// <summary>
        /// Gets the autoBusinesss non active.
        /// </summary>
        /// <returns>
        /// IList{AutoBusinessModel}.
        /// </returns>
        IList<AutoBusinessModel> GetAutoBusinesssNonActive();

        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// AutoBusinessModel.
        /// </returns>
        AutoBusinessModel GetAutoBusiness(int autoBusinessId);

        /// <summary>
        /// Gets the type of the automatic business by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<AutoBusinessModel> GetAutoBusinessByRefType(int refTypeId, bool isActive);

        /// <summary>
        /// Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddAutoBusiness(AutoBusinessModel autoBusiness);

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateAutoBusiness(AutoBusinessModel autoBusiness);

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteAutoBusiness(int autoBusinessId);

        #endregion

        #region VoucherType

        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        //IList<RefTypeModel> GetRefTypes();

        /// <summary>
        /// Gets the reference types search.
        /// </summary>
        /// <returns></returns>
        IList<RefTypeModel> GetRefTypesSearch();

        #endregion

        #region Project

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns>
        /// IList{ProjectModel}.
        /// </returns>
        IList<ProjectModel> GetProjects();

        /// <summary>
        /// Gets the projects active.
        /// </summary>
        /// <returns>
        /// IList{ProjectModel}.
        /// </returns>
        IList<ProjectModel> GetProjectsActive();

        /// <summary>
        /// Gets the projects non active.
        /// </summary>
        /// <returns>
        /// IList{ProjectModel}.
        /// </returns>
        IList<ProjectModel> GetProjectsNonActive();

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// ProjectModel.
        /// </returns>
        ProjectModel GetProject(int projectId);

        /// <summary>
        /// Adds the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddProject(ProjectModel project);

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateProject(ProjectModel project);

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteProject(int projectId);

        #endregion

        #region CompanyProfile

        /// <summary>
        /// Gets the companyProfiles.
        /// </summary>
        /// <returns>
        /// IList{CompanyProfileModel}.
        /// </returns>
        IList<CompanyProfileModel> GetCompanyProfiles();

        /// <summary>
        /// Gets the companyProfile.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns>
        /// CompanyProfileModel.
        /// </returns>
        CompanyProfileModel GetCompanyProfile(int companyProfileId);

        /// <summary>
        /// Adds the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddCompanyProfile(CompanyProfileModel companyProfile);

        /// <summary>
        /// Updates the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateCompanyProfile(CompanyProfileModel companyProfile);

        /// <summary>
        /// Deletes the companyProfile.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteCompanyProfile(int companyProfileId);

        #endregion

        #region Report

        #region Estiamte Report //chỉ giành cho báo cáo dự toán

        /// <summary>
        /// Gets the general receipt estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        IList<GeneralReceiptEstimateModel> GetGeneralReceiptEstimate(short yearOfEstimate);

        /// <summary>
        /// Gets the general payment estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        IList<GeneralPaymentEstimateModel> GetGeneralPaymentEstimate(short yearOfEstimate);

        /// <summary>
        /// Gets the general estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        IList<GeneralEstimateModel> GetGeneralEstimate(short yearOfEstimate);

        /// <summary>
        /// Gets the general payment detail estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        IList<GeneralPaymentDetailEstimateModel> GetGeneralPaymentDetailEstimate(short yearOfEstimate);

        /// <summary>
        /// Gets the estimate detail statement.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <param name="isCompanyProfile">if set to <c>true</c> [is company profile].</param>
        /// <returns></returns>
        EstimateDetailStatementModel GetEstimateDetailStatement(short yearOfEstimate, bool isCompanyProfile);

        /// <summary>
        /// Gets the fund stuations.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        IList<FundStuationModel> GetFundStuations(short yearOfEstimate);

        #endregion

        #region Financial Report //chỉ giành cho báo cáo tài chính

        /// <summary>
        /// Gets the report B03 bn gs.
        /// </summary>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<B03BNGModel> GetReportB03BNGs(short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report F03 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<F03BNGModel> GetReportF03BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report F331 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountsCode">The accounts code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<F331BNGModel> GetReportF331BNGs(string storeProcedureName, short amountType, string accountsCode, string currencyCode, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the report B09 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<B09BNGModel> GetReportB09BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        IList<B01BCQTModel> GetReportB01BCQTs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        IList<ReportF03BCTModel> GetReportF03_BCTs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        IList<ReportActivityB02Model> GetReportActivityB02(string storeProcedureName, int amountType, string currencyCode, DateTime fromDate, DateTime toDate);

        #endregion

        /// <summary>
        /// Get02s the LDTL with store produre.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <param name="BudgetGroupCode">The budget group code.</param>
        /// <returns></returns>
        IList<SearchModel> GetSearch(string whereClause, string fromDate, string toDate, string currencyCode, string departmentCode, string fixedAssetCode, string BudgetGroupCode);

        /// <summary>
        /// Gets the B01 h with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        IList<B01HModel> GetB01HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        IList<ReportB01BCTCModel> GetB01BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        IList<ReportB03bBCTCModel> GetB03bBCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        IList<ReportB04BCTCModel> GetB04BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        /// <summary>
        /// Gets the C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="paymentVoucherIdList">The payment voucher identifier list.</param>
        /// <returns></returns>
        IList<C22HModel> GetC22H(string storeProdure, string paymentVoucherIdList);

        /// <summary>
        /// Gets the C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <param name="reftypeId">The reftype identifier.</param>
        /// <returns></returns>
        IList<AccountingVoucherModel> AccountingVoucherModel(string storeProdure, string refIdList, int reftypeId);

        /// <summary>
        /// Gets the C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="itemTransactionVoucherIdList">The item transaction voucher identifier list.</param>
        /// <returns></returns>
        IList<C11HModel> GetC11H(string storeProdure, string itemTransactionVoucherIdList);

        /// <summary>
        /// Get02s the LDTL with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<A02LDTLModel> Get02LdtlWithStoreProdure(string storeProdure, string fromDate, string toDate);


        IList<A02LDTLModel> Get02LdtlIsRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause, bool isEmployee);

        /// <summary>
        /// Gets the S03 ah model with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        IList<S03AHModel> GetS03AHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);

        /// <summary>
        /// Gets the S03 ah model with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetGroupCode">The budget group code.</param>
        /// <param name="fixedassetCode">The fixedasset code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        IList<S33HModel> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedAssetCode, string departmentCode, int amounType, string whereClause, string selectedField, string selectedAllValueField);

        /// <summary>
        /// Gets the S33 h with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetGroupCode">The budget group code.</param>
        /// <param name="fixedassetCode">The fixedasset code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        IList<S33HModel> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedassetCode, string departmentCode, int amounType, string whereClause);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeProdure"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="currencyCode"></param>
        /// <param name="amounType"></param>
        /// <returns></returns>
        IList<S05HModel> GetS05HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType);
        IList<AdvancePaymentModel> GetAdvancePaymentWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amountType, int accountType);

        /// <summary>
        /// Gets the C30 bb with store produre.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<C30BBModel> GetC30BBWithStoreProdure(int year, int refTypeId);

        /// <summary>
        /// Gets the C30 bb item with store produre.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<C30BBModel> GetC30BBItemWithStoreProdure(int year, int refTypeId);



        /// <summary>
        /// Gets the cash S11 h with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<CashReportModel> GetCashS11HWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber,
                                     string currencyCode);

        /// <summary>
        /// Gets the cash S12 h with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<CashReportModel> GetCashS12HWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string currencyCode, bool isBank, int? bankId);

        /// <summary>
        /// Gets the cash S11 ah with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<CashReportModel> GetCashS11AHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber,
                                             string currencyCode);


        /// <summary>
        /// Gets the cash S12 ah with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<CashReportModel> GetCashS12AHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber,
                                     string currencyCode, bool isBank, int? bankId);


        /// <summary>
        /// Gets the S03 bh with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<S03BHModel> GetS03BHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber,
                                     string currencyCode);


        /// <summary>
        /// Gets the B14 q with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="stockIdList">The stock identifier list.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        IList<B14QModel> GetB14QWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, string accountnumber, string stockIdList, int amounType);

        /// <summary>
        /// Gets the general payment detail estimate.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetB03HModel> GetFixedAssetB03H(string fromDate, string toDate, string currencyCode);

        /// <summary>
        /// Gets the type of the fixed asset B03 h amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetB03HModel> GetFixedAssetB03HAmountType(string fromDate, string toDate, int currencyDecimalDigits);
        /// <summary>
        /// Gets the general payment detail estimate.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetB01Model> GetFixedAssetB01(string fromDate, string toDate, string currencyCode);

        /// <summary>
        /// Gets the type of the fixed asset B01 amount.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetB01Model> GetFixedAssetB01AmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset c55a hd.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetC55aHDModel> GetFixedAssetC55aHD(string fromDate, string toDate, string faParameter,
                                                         string faCategoryCode, string currencyCode);

        /// <summary>
        /// Gets the fixed asset c55a hd.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetC55aHDModel> GetFixedAssetC55aHDAmountType(string fromDate, string toDate, string faParameter,
                                                         string faCategoryCode, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed assets by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        FixedAssetModel GetFixedAssetsByCode(string fixedAssetCode);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventory(string fromDate, string toDate,
                                                                   string currencyCode, int currencyDecimalDigits);
        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventoryAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAInventoryHouse(string fromDate, string toDate,
                                                                   string currencyCode);
        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAInventoryHouseAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAInventoryCar(string fromDate, string toDate,
                                                                   string currencyCode);
        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAInventoryCarAmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventory3000(string fromDate, string toDate, string currencyCode);
        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventoryAmountType3000(string fromDate, string toDate);


        /// <summary>
        /// Gets the fixed asset S31 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="faParameter">The fa parameter.</param>
        /// <param name="faCategoryCode">The fa category code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetS31HModel> GetFixedAssetS31H(string fromDate, string toDate, string faParameter, string faCategoryCode, string currencyCode);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetB02Model> GetFixedAssetB02(string fromDate, string toDate, string currencyCode);

        IList<FixedAssetB03H30KModel> GetFixedAssetB03H30K(string fromDate, string toDate, int currencyDecimalDigits);

        IList<FixedAsset30KPart2Model> GetFixedAsset30KPart2(string fromDate, string toDate, int currencyDecimalDigits);

        IList<FixedAssetCardModel> GetFixedAssetCard(string strFixedAssetId, int currencyDecimalDigits);

        IList<FixedAsset30KPart2Model> GetFixedAssetFAB0130KPart2(string fromDate, string toDate, int currencyDecimalDigits);

        IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAB01Car(string fromDate, string toDate, int currencyDecimalDigits);

        IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAB01House(string fromDate, string toDate, int currencyDecimalDigits);

        IList<FixedAssetS26HModel> GetFixedAssetS26H(string storedProcedure, string fromDate, string toDate, string currencyCode, int amountType, string departmentCode, int fixedAssetCategoryIds, int option);

        IList<FixedAssetS24HModel> GetFixedAssetS24H(string storedProcedure, string currencyCode, int amountType, string fromDate, string toDate, string departmentCode, string fixedAssetCategoryCode, string fixedAssetIds);

        /// <summary>
        /// Gets the fixed asset fa inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <returns></returns>
        IList<FixedAssetB02Model> GetFixedAssetB02AmountType(string fromDate, string toDate, int currencyDecimalDigits);

        /// <summary>
        /// Gets the C30 b B501.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="receiptVoucherIdList">The receipt voucher identifier list.</param>
        /// <returns></returns>
        IList<C30BB501Model> GetC30BB501(string storeProdure, string receiptVoucherIdList);

        IList<FixedAssetCardsModel> GetFixedAssetCards(string strFixedAssetId, int currencyDecimalDigits);

        IList<BusinessObjects.Report.LedgerAccounting.ReportS104HModel> LedgerAccountingS104H(string storeProdure, string fromDate, string toDate, string budgetSourceCodes, string currencyCode, int amountType);

        #endregion

        #region SettlementReport

        IList<ReportB01CIIModel> GetB01CIIWithStoreProdure(string storeProdure, string fromDate, string toDate);

        IList<ReportB01CII01Model> GetB01CII01WithStoreProdure(string storeProdure, string fromDate, string toDate);

        IList<ReportB01CIModel> GetB01CIWithStoreProdure(string storeProdure, DateTime fromDate, DateTime toDate);

        IList<ReportS104HModel> GetS104HWithStoreProdure(string storeProcedure, DateTime fromDate, DateTime toDate, string currencyCode, int amounType);

        #endregion

        #region FixedAssetArmortization

        /// <summary>
        /// Gets the fixed asset armortizations.
        /// </summary>
        /// <returns></returns>
        IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations();

        /// <summary>
        /// Gets the fixed asset armortizations include detail.
        /// </summary>
        /// <returns></returns>
        IList<FixedAssetArmortizationModel> GetFixedAssetArmortizationsIncludeDetail();

        /// <summary>
        /// Gets the fixed asset armortizations include detail.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<FixedAssetArmortizationModel> GetFixedAssetArmortizationsIncludeDetail(string refDate);

        /// <summary>
        /// Gets the f armortization by fa increments.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<FixedAssetArmortizationDetailModel> GetFArmortizationByFAIncrements(long refId);

        /// <summary>
        /// Gets the fixed asset armortizations.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations(string refDate);

        /// <summary>
        /// Gets the fixed asset armortizations.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations(string refDate, string currencyCode);

        /// <summary>
        /// Gets the payment fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortizationId">The payment fixedAssetArmortization identifier.</param>
        /// <returns></returns>
        FixedAssetArmortizationModel GetFixedAssetArmortization(long fixedAssetArmortizationId);

        /// <summary>
        /// Gets the fixed asset armortization.
        /// </summary>
        /// <param name="fixedAssetArmortizationId">The fixed asset armortization identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDepreciation">The year of depreciation.</param>
        /// <returns></returns>
        FixedAssetArmortizationModel GetFixedAssetArmortization(long fixedAssetArmortizationId, string currencyCode, int yearOfDepreciation);

        /// <summary>
        /// Adds the fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortization">The fixedAssetArmortization.</param>
        /// <returns></returns>
        long AddFixedAssetArmortization(FixedAssetArmortizationModel fixedAssetArmortization);

        /// <summary>
        /// Updates the fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortization">The fixedAssetArmortization.</param>
        /// <returns></returns>
        long UpdateFixedAssetArmortization(FixedAssetArmortizationModel fixedAssetArmortization);

        /// <summary>
        /// Deletes the fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortizationId">The fixedAssetArmortization identifier.</param>
        /// <returns></returns>
        long DeleteFixedAssetArmortization(long fixedAssetArmortizationId);

        #endregion

        #region FixedAssetDecrement

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <returns></returns>
        IList<FixedAssetDecrementModel> GetFixedAssetDecrements();

        /// <summary>
        /// Gets the fa decrement by fa increments.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<FixedAssetDecrementDetailModel> GetFADecrementByFAIncrements(long refId);
        /// <summary>
        /// Gets the fixed asset decrements by year of post date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<FixedAssetDecrementModel> GetFixedAssetDecrementsByYearOfPostDate(string refDate);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        FixedAssetDecrementModel GetFixedAssetDecrement(long refId);

        /// <summary>
        /// Adds the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetDecrement">The fixed asset decrement.</param>
        /// <returns></returns>
        long AddFixedAssetDecrement(FixedAssetDecrementModel fixedAssetDecrement, bool isAutoGenerateParallel);

        /// <summary>
        /// Adds the fixed asset decrements.
        /// </summary>
        /// <param name="fixedAssetDecrements">The fixed asset decrements.</param>
        /// <returns></returns>
        long AddFixedAssetDecrements(IList<FixedAssetDecrementModel> fixedAssetDecrements, bool isAutoGenerateParallel);

        /// <summary>
        /// Updates the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetDecrement">The fixed asset decrement.</param>
        /// <returns></returns>
        long UpdateFixedAssetDecrement(FixedAssetDecrementModel fixedAssetDecrement, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        long DeleteFixedAssetDecrement(long refId);

        #endregion

        #region FixedAssetIncrement

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <returns></returns>
        IList<FixedAssetIncrementModel> GetFixedAssetIncrements();

        /// <summary>
        /// Gets the fixed asset decrements by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<FixedAssetIncrementModel> GetFixedAssetIncrementsByYearOfPostDate(int refTypeId, string refDate);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        FixedAssetIncrementModel GetFixedAssetIncrement(long refId);

        /// <summary>
        /// Gets the deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{DepositModel}.
        /// </returns>
        IList<FixedAssetIncrementModel> GetFixedAssetIncrementsByRefTypeId(long refTypeId);

        /// <summary>
        /// Gets the fixed asset increment.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        FixedAssetIncrementModel GetFixedAssetIncrementByRefNo(string refNo);
        /// <summary>
        /// Adds the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetIncrement">The fixed asset increment.</param>
        /// <returns></returns>
        long AddFixedAssetIncrement(FixedAssetIncrementModel fixedAssetIncrement, bool isAutoGenerateParallel);

        /// <summary>
        /// Adds the fixed asset increments.
        /// </summary>
        /// <param name="fixedAssetIncrement">The fixed asset increment.</param>
        /// <returns></returns>
        long AddFixedAssetIncrements(IList<FixedAssetIncrementModel> fixedAssetIncrement, bool isAutoGenerateParallel);


        /// <summary>
        /// Updates the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetIncrement">The fixed asset increment.</param>
        /// <returns></returns>
        long UpdateFixedAssetIncrement(FixedAssetIncrementModel fixedAssetIncrement, bool isAutoGenerateParallel);

        /// <summary>
        /// Deletes the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        long DeleteFixedAssetIncrement(long refId);

        #endregion

        #region FixedAssetLedger

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        IList<FixedAssetLedgerModel> GetFixedAssetLedgerByFixedAssets(int fixedAssetId);
        #endregion

        #region FixedAssetVoucher

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        IList<FixedAssetVoucherModel> GetFixedAssetVoucherByFixedAssets(int fixedAssetId);
        #endregion

        #region GeneralVoucher

        /// <summary>
        /// Gets the genver voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<GeneralVocherModel> GetGenverVoucherByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the general voucher.
        /// </summary>
        /// <param name="generalVoucherId">The general voucher identifier.</param>
        /// <returns></returns>
        GeneralVocherModel GetGeneralVoucher(long generalVoucherId);

        GeneralVocherModel GetGeneralVoucher(int refType, long refForeignId);

        /// <summary>
        /// Adds the general voucher.
        /// </summary>
        /// <param name="generalVoucher">The general voucher.</param>
        /// <returns></returns>
        long AddGeneralVoucher(GeneralVocherModel generalVoucher, bool isGenerateParalell = false);


        /// <summary>
        /// Updates the general voucher.
        /// </summary>
        /// <param name="generalVoucher">The general voucher.</param>
        /// <returns></returns>
        long UpdateGeneralVoucher(GeneralVocherModel generalVoucher, bool isGenerateParalell = false);


        /// <summary>
        /// Deletes the general voucher.
        /// </summary>
        /// <param name="generalVoucherId">The general voucher identifier.</param>
        /// <returns></returns>
        long DeleteGeneralVoucher(long generalVoucherId);

        /// <summary>
        /// Gets the genver voucher by is capital allocate.
        /// </summary>
        /// <returns></returns>
        IList<GeneralVocherModel> GetGenverVoucherByIsCapitalAllocate();

        #endregion

        #region CaptitalAllocateVoucher


        /// <summary>
        /// Deletes the captital allocate voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        long DeleteCaptitalAllocateVoucher(long refId);

        /// <summary>
        /// Adds the g captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns></returns>
        long AddGCaptitalAllocateVoucher(CaptitalAllocateVoucherModel captitalAllocateVoucher);

        /// <summary>
        /// Updates the captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns></returns>
        long UpdateCaptitalAllocateVoucher(CaptitalAllocateVoucherModel captitalAllocateVoucher);


        /// <summary>
        /// Captitals the allocate vouchers to date to from date.
        /// </summary>
        /// <param name="toDate">To date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersToDateToFromDate(DateTime toDate, DateTime fromDate, int activityId, string currencyCode);


        /// <summary>
        /// Captitals the allocate vouchers to date to from date for update.
        /// </summary>
        /// <param name="toDate">To date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersToDateToFromDateForUpdate(DateTime toDate, DateTime fromDate, string currencyCode, int activityId, int refTypeId, long refId);

        /// <summary>
        /// Captitals the allocate vouchers by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersByRefId(long refId);



        #endregion

        #region AccountTranfer

        /// <summary>
        /// Deletes the account tranfer voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        long DeleteAccountTranferVoucher(long refId);

        /// <summary>
        /// Adds the account tranfer voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns></returns>
        long AddAccountTranferVoucher(AccountTranferVourcherModel captitalAllocateVoucher);

        /// <summary>
        /// Accounts the tranfer vouchers by posted date and currency code.
        /// </summary>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        IList<AccountTranferVourcherModel> AccountTranferVouchersByPostedDateAndCurrencyCode(DateTime postedDate, string currencyCode);

        /// <summary>
        /// Accounts the tranfer vouchers by edit.
        /// </summary>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        IList<AccountTranferVourcherModel> AccountTranferVouchersByEdit(DateTime postedDate, string currencyCode, int refTypeId);

        /// <summary>
        /// Accounts the tranfer vouchers by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<AccountTranferVourcherModel> AccountTranferVouchersByRefId(long refId);

        #endregion

        #region OpeningAccountEntry

        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        IList<OpeningAccountEntryModel> GetOpeningAccountEntries();

        /// <summary>
        /// Gets the opening account entry.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        OpeningAccountEntryModel GetOpeningAccountEntry(string accountCode);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        long UpdateOpeningAccountEntry(OpeningAccountEntryModel openingAccountEntry);



        #endregion

        #region OpeningAccountEntryDetail

        /// <summary>
        /// Gets the opening account entry details.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        IList<OpeningAccountEntryDetailModel> GetOpeningAccountEntryDetails(string accountCode);

        /// <summary>
        /// Adds the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns></returns>
        long AddOpeningAccountEntryDetails(IList<OpeningAccountEntryDetailModel> openingAccountEntryDetails);

        /// <summary>
        /// Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns></returns>
        long UpdateOpeningAccountEntryDetails(IList<OpeningAccountEntryDetailModel> openingAccountEntryDetails);



        #endregion

        #region OpeningFixedAssetEntry

        /// <summary>
        /// Gets the opening fixed asset entries.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries(string accountCode);

        /// <summary>
        /// Gets the opening fixed asset entries.
        /// </summary>
        /// <returns></returns>
        IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries();
        /// <summary>
        /// Adds the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns></returns>
        long InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryModel openingAccountEntryDetails);

        /// <summary>
        /// Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        long UpdateOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingAccountEntries, int fixedAssetId);

        /// <summary>
        /// Updates the opening fixed asset entries detail.
        /// </summary>
        /// <param name="openingAccountEntries">The opening account entries.</param>
        /// <returns></returns>
        long UpdateOpeningFixedAssetEntriesDetail(IList<OpeningFixedAssetEntryModel> openingAccountEntries);

        /// <summary>
        /// Inserts the opening fixed asset entries.
        /// </summary>
        /// <param name="openingFixedAssetEntry">The opening fixed asset entry.</param>
        /// <returns></returns>
        long InsertOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingFixedAssetEntry);
        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteOpeningFixedAssetEntry(int departmentId);

        #endregion

        #region Common

        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        int? GetIdByCode(string query);

        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="idFieldName">Name of the identifier field.</param>
        /// <param name="codeFieldName">Name of the code field.</param>
        /// <param name="codeValueField">The code value field.</param>
        /// <returns></returns>
        int? GetIdByCode(string tableName, string idFieldName, string codeFieldName, string codeValueField);

        /// <summary>
        /// Resets the automatic increment.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="startIncrementNumber">The start increment number.</param>
        /// <returns></returns>
        bool ResetAutoIncrement(string tableName, int startIncrementNumber);

        /// <summary>
        /// Updates the amount exchange.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        int UpdateAmountExchange(decimal exchangeRate, short currencyDecimalDigits, DateTime fromDate, DateTime toDate);

        #endregion

        #region Role

        /// <summary>
        /// Department
        /// Gets the roles.
        /// </summary>
        /// <returns>
        /// IList{RoleModel}.
        /// </returns>
        IList<RoleModel> GetRoles();

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<RoleModel> GetRoles(bool isActive);

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// RoleModel.
        /// </returns>
        RoleModel GetRole(int roleId);

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddRole(RoleModel role);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateRole(RoleModel role);

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteRole(int roleId);

        #endregion

        #region Site

        /// <summary>
        /// Department
        /// Gets the sites.
        /// </summary>
        /// <returns>
        /// IList{SiteModel}.
        /// </returns>
        IList<SiteModel> GetSites();

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<SiteModel> GetSites(bool isActive);

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>
        /// SiteModel.
        /// </returns>
        SiteModel GetSite(int siteId);

        /// <summary>
        /// Adds the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddSite(SiteModel site);

        /// <summary>
        /// Updates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateSite(SiteModel site);

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteSite(int siteId);

        #endregion

        #region Permission

        /// <summary>
        /// Department
        /// Gets the permissions.
        /// </summary>
        /// <returns>
        /// IList{PermissionModel}.
        /// </returns>
        IList<PermissionModel> GetPermissions();

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<PermissionModel> GetPermissions(bool isActive);

        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns>
        /// PermissionModel.
        /// </returns>
        PermissionModel GetPermission(int permissionId);

        /// <summary>
        /// Adds the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddPermission(PermissionModel permission);

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdatePermission(PermissionModel permission);

        /// <summary>
        /// Deletes the permission.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeletePermission(int permissionId);

        #endregion

        #region UserProfile

        /// <summary>
        /// Department
        /// Gets the userProfiles.
        /// </summary>
        /// <returns>
        /// IList{UserProfileModel}.
        /// </returns>
        IList<UserProfileModel> GetUserProfiles();

        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        IList<UserProfileModel> GetUserProfiles(bool isActive);

        /// <summary>
        /// Gets the userProfile.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns>
        /// UserProfileModel.
        /// </returns>
        UserProfileModel GetUserProfile(int userProfileId);

        /// <summary>
        /// Gets the name of the user profile by user profile.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserProfileModel GetUserProfileByUserProfileName(string userProfileName, string password);

        /// <summary>
        /// Adds the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddUserProfile(UserProfileModel userProfile);

        /// <summary>
        /// Updates the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateUserProfile(UserProfileModel userProfile);

        /// <summary>
        /// Deletes the userProfile.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteUserProfile(int userProfileId);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        int ChangePassword(string userProfileName, string oldPassword, string newPassword);

        #endregion

        #region OpeningInventoryEntry

        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries();

        /// <summary>
        /// Gets the opening account entry.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries(string accountCode);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingInventoryEntry">The opening account entry.</param>
        /// <returns></returns>
        long UpdateOpeningInventoryEntry(List<OpeningInventoryEntryModel> openingInventoryEntry);



        #endregion

        #region EmployeeLeasing

        /// <summary>
        /// Gets the employeeLeasings.
        /// </summary>
        /// <returns>
        /// IList{EmployeeLeasingModel}.
        /// </returns>
        IList<EmployeeLeasingModel> GetEmployeeLeasings();

        /// <summary>
        /// Gets the employee leasings.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <returns></returns>
        IList<EmployeeLeasingModel> GetEmployeeLeasings(bool isLeasing);

        /// <summary>
        /// Gets the employeeLeasings active.
        /// </summary>
        /// <returns>
        /// IList{EmployeeLeasingModel}.
        /// </returns>
        IList<EmployeeLeasingModel> GetEmployeeLeasingsActive();

        /// <summary>
        /// Gets the employeeLeasings non active.
        /// </summary>
        /// <returns>
        /// IList{EmployeeLeasingModel}.
        /// </returns>
        IList<EmployeeLeasingModel> GetEmployeeLeasingsNonActive();

        /// <summary>
        /// Gets the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        /// <returns>
        /// EmployeeLeasingModel.
        /// </returns>
        EmployeeLeasingModel GetEmployeeLeasing(int employeeLeasingId);

        /// <summary>
        /// Adds the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddEmployeeLeasing(EmployeeLeasingModel employeeLeasing);

        /// <summary>
        /// Updates the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateEmployeeLeasing(EmployeeLeasingModel employeeLeasing);

        /// <summary>
        /// Deletes the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteEmployeeLeasing(int employeeLeasingId);

        #endregion

        #region Building

        /// <summary>
        /// Gets the buildings.
        /// </summary>
        /// <returns>
        /// IList{BuildingModel}.
        /// </returns>
        IList<BuildingModel> GetBuildings();

        /// <summary>
        /// Gets the buildings active.
        /// </summary>
        /// <returns>
        /// IList{BuildingModel}.
        /// </returns>
        IList<BuildingModel> GetBuildingsActive();

        /// <summary>
        /// Gets the buildings non active.
        /// </summary>
        /// <returns>
        /// IList{BuildingModel}.
        /// </returns>
        IList<BuildingModel> GetBuildingsNonActive();

        /// <summary>
        /// Gets the building.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns>
        /// BuildingModel.
        /// </returns>
        BuildingModel GetBuilding(int buildingId);

        /// <summary>
        /// Adds the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddBuilding(BuildingModel building);

        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateBuilding(BuildingModel building);

        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteBuilding(int buildingId);

        #endregion

        #region BudgetSourceCategory

        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceCategoryModel}.
        /// </returns>
        IList<BudgetSourceCategoryModel> GetBudgetSourceCategories();

        /// <summary>
        /// Gets the budgetSourceCategories active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceCategoryModel}.
        /// </returns>
        IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesActive();

        /// <summary>
        /// Gets the budgetSourceCategories non active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceCategoryModel}.
        /// </returns>
        IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesNonActive();

        /// <summary>
        /// Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        /// BudgetSourceCategoryModel.
        /// </returns>
        BudgetSourceCategoryModel GetBudgetSourceCategory(int budgetSourceCategoryId);

        /// <summary>
        /// Adds the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        /// Siestem.Int32.
        /// </returns>
        int AddBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory);

        /// <summary>
        /// Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        /// Siestem.Int32.
        /// </returns>
        int UpdateBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory);

        /// <summary>
        /// Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        /// Siestem.Int32.
        /// </returns>
        int DeleteBudgetSourceCategory(int budgetSourceCategoryId);

        #endregion

        #region EstimateDetailStatementInfo

        /// <summary>
        /// Gets the payment estimates.
        /// </summary>
        /// <returns></returns>
        IList<EstimateDetailStatementInfoModel> GetEstimateDetailStatementInfos();

        /// <summary>
        /// Gets the payment estimate.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        EstimateDetailStatementInfoModel GetEstimateDetailStatementInfo(bool isActive);

        /// <summary>
        /// Gets the company profile information.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        EstimateDetailStatementInfoModel GetCompanyProfileInfo(bool isActive);

        /// <summary>
        /// Adds the estimate.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimate detail statement.</param>
        /// <returns></returns>
        int AddEstimateDetailStatementInfo(EstimateDetailStatementInfoModel estimateDetailStatement);

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimate detail statement.</param>
        /// <returns></returns>
        int UpdateEstimateDetailStatementInfo(EstimateDetailStatementInfoModel estimateDetailStatement);

        /// <summary>
        /// Deletes the estimate.
        /// </summary>
        /// <param name="estimateDetailStatementId">The estimate detail statement identifier.</param>
        /// <returns></returns>
        long DeleteEstimateDetailStatementInfo(int estimateDetailStatementId);

        #endregion

        #region EstimateDetailStatementPartB

        /// <summary>
        /// Gets the payment estimates.
        /// </summary>
        /// <returns></returns>
        IList<EstimateDetailStatementPartBModel> GetEstimateDetailStatementPartBs();

        /// <summary>
        /// Adds the estimate.
        /// </summary>
        /// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        /// <returns></returns>
        int AddEstimateDetailStatementPartB(IList<EstimateDetailStatementPartBModel> estimateDetailStatementPartB);

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        /// <returns></returns>
        int UpdateEstimateDetailStatementPartB(IList<EstimateDetailStatementPartBModel> estimateDetailStatementPartB);

        #endregion

        #region EstimateDetailStatementFixedAsset

        /// <summary>
        /// Gets the payment estimates.
        /// </summary>
        /// <returns></returns>
        IList<EstimateDetailStatementFixedAssetModel> GetEstimateDetailStatementFixedAssets();

        /// <summary>
        /// Adds the estimate.
        /// </summary>
        /// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        /// <returns></returns>
        int AddEstimateDetailStatementFixedAsset(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementPartB);

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        /// <returns></returns>
        int UpdateEstimateDetailStatementFixedAsset(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementPartB);

        #endregion

        #region FixedAssetHousingReport

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetHousingReportModel}.
        /// </returns>
        IList<FixedAssetHousingReportModel> GetFixedAssetHousingReports();

        /// <summary>
        /// Gets the budget chapters active.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetHousingReportModel}.
        /// </returns>
        IList<FixedAssetHousingReportModel> GetFixedAssetHousingReportsActive();

        /// <summary>
        /// Gets the budget chapters non active.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetHousingReportModel}.
        /// </returns>
        IList<FixedAssetHousingReportModel> GetFixedAssetHousingReportsNonActive();

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// FixedAssetHousingReportModel.
        /// </returns>
        FixedAssetHousingReportModel GetFixedAssetHousingReport(bool isActive);
        /// <summary>
        /// Adds the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget source property.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int AddFixedAssetHousingReport(FixedAssetHousingReportModel fixedAssetHousingReport);

        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget source property.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int UpdateFixedAssetHousingReport(FixedAssetHousingReportModel fixedAssetHousingReport);

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReportId">The budget source property identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int DeleteFixedAssetHousingReport(int fixedAssetHousingReportId);

        #endregion

        #region ElectricalWork

        ElectricalWorkModel GetElectricalWork(int postedDate);
        int UpdateInsertElectricalWork(ElectricalWorkModel electricalWorkModel);

        #endregion

        #region Mutual
        IList<MutualModel> GetMutuals();
        MutualModel GetMutual(int mutualId);

        List<MutualModel> GetMutualByIsActive(bool isActive);
        List<MutualModel> GetMutualByMutualCode(string mutualCode);

        int AddMutual(MutualModel mutual);

        int UpdateMutual(MutualModel mutual);

        int DeleteMutual(int mutualId);

        #endregion

        #region AutoNumberList
        IList<AutoNumberListModel> GetAutoNumberLists();
        AutoNumberListModel GetAutoNumberList(string tableCode);
        string UpdateAutoNumberList(List<AutoNumberListModel> autoNumberLists);
        #endregion

        #region SalaryVoucher

        List<SalaryVoucherModel> SalaryVoucherByMonthDate(string monthDate);

        List<SalaryVoucherModel> SalaryVoucherByMonthDateIsPostedDate(string monthDate);

        List<SalaryVoucherModel> SalaryVoucherByMonthDateIsRetail(string monthDate, bool isRetail, int refTypeId);

        string SaveSalaryVoucher(string postedDate, string refNo, int refTypeId);

        string CancelCalc(string postedDate, string refNo, int refTypeId);

        string CancelSalaryVoucher(string postedDate, string refNo, int refTypeId);

        string SalaryVoucherByCash(string postedDate, string refNo, int refTypeId);

        string SalaryVoucherByDeposit(string postedDate, string refNo, int refTypeId);

        long GetEmployeePayroll_VoucherID(string refNo, int refTypeId);

        #endregion

        #region lock

        LockModel GetLock();

        string SaveLock(LockModel model);

        LockModel CheckLock(int refId, int refTypeId, DateTime refDate);

        LockModel CheckLock(int refId, int refTypeId);

        #endregion

        #region JouralEntryAccount

        /// <summary>
        /// Gets the journal entry accounts.
        /// </summary>
        /// <param name="exportType">Type of the export.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<JournalEntryAccountModel> GetJournalEntryAccounts(int exportType, DateTime fromDate, DateTime toDate);

        #endregion

        #region RefType

        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        IList<RefTypeModel> GetRefTypes();

        /// <summary>
        /// Gets the reference type model.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        RefTypeModel GetRefTypeModel(int refTypeId);

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeModel">The reference type model.</param>
        /// <returns></returns>
        int UpdateRefType(RefTypeModel refTypeModel);

        ///// <summary>
        ///// Gets the reference types search.
        ///// </summary>
        ///// <returns></returns>
        //IList<RefTypeModel> GetRefTypesSearch();

        #endregion

        #region SUIncrementDecrement

        /// <summary>
        /// Gets the sUIncrementDecrements.
        /// </summary>
        /// <returns>
        /// IList{SUIncrementDecrementModel}.
        /// </returns>
        IList<SUIncrementDecrementModel> GetSUIncrementDecrements();

        /// <summary>
        /// Gets the sUIncrementDecrements by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByYearOfPostDate(int refTypeId, DateTime refDate);

        /// <summary>
        /// Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{SUIncrementDecrementModel}.
        /// </returns>
        IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        SUIncrementDecrementModel GetSUIncrementDecrement(long refId, bool hasDetail);

        decimal GetSUIncrementDecrementQuantity(string currencyCode, int inventoryItemId, int departmentId, long refId, DateTime postedDate);

        /// <summary>
        /// Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        SUIncrementDecrementModel GetSUIncrementDecrementByRefNo(string refNo, bool hasDetail);

        /// <summary>
        /// Adds the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        long AddSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement);

        /// <summary>
        /// Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        /// System.Int64.
        /// </returns>
        long UpdateSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement);

        /// <summary>
        /// Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        long DeleteSUIncrementDecrement(long refId);

        #endregion

        #region ReportDataTemplate

        ReportDataTemplateModel GetReportDataTemplate(string dataTemplateCode);
        long InsertOrUpdateReportDataTemplate(ReportDataTemplateModel reportDataTemplate);

        #endregion
    }
}