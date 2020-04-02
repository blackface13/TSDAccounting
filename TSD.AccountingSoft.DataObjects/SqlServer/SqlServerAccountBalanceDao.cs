/***********************************************************************
 * <copyright file="SqlServerAccountBalanceDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataHelpers;
using System.Data;

namespace TSD.AccountingSoft.DataAccess.SqlServer
{
    /// <summary>
    /// SqlServerAccountBalanceDao
    /// </summary>
    public class SqlServerAccountBalanceDao : IAccountBalanceDao
    {
        /// <summary>
        /// Gets the accountBalance.
        /// </summary>
        /// <param name="accountBalanceId">The accountBalance identifier.</param>
        /// <returns></returns>
        public AccountBalanceEntity GetAccountBalance(int accountBalanceId)
        {
            const string sql = @"uspGet_AccountBalance_ByID";

            object[] parms = { "@AccountBalanceId", accountBalanceId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account balance by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns></returns>
        public AccountBalanceEntity GetAccountBalanceByAccountNumber(string accountNumber)
        {
            const string sql = @"uspGet_AccountBalance_ByAccountNumber";

            object[] parms = { "@AccountNumber", accountNumber };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the exits account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        public AccountBalanceEntity GetExitsAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspGet_Exist_AccountBalance";

            object[] parms = { "@BalanceDate", accountBalance.BalanceDate,
                               "@CurrencyCode", accountBalance.CurrencyCode,
                               "@AccountNumber", accountBalance.AccountNumber,
                               "@BudgetChapterCode", accountBalance.BudgetChapterCode,
                               "@BudgetCategoryCode", accountBalance.BudgetCategoryCode,
                               "@BudgetSourceCode", accountBalance.BudgetSourceCode,
                               "@BudgetItemCode", accountBalance.BudgetItemCode,
                               "@MergerFundID", accountBalance.MergerFundId,
                               "@BankID", accountBalance.BankId,
                               "@ProjectID", accountBalance.ProjectId,
                               "@VendorId", accountBalance.VendorId,
                               "@AccountingObjectID", accountBalance.AccountingObjectId,
                               "@CustomerID", accountBalance.CustomerId,
                               "@InventoryItemID",accountBalance.InventoryItemId
                             };

            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        public int InsertAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspInsert_AccountBalance";
            return Db.Insert(sql, true, Take(accountBalance));
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalance">The journal entry account.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspUpdate_AccountBalance";
            return Db.Update(sql, true, Take(accountBalance));
        }

        /// <summary>
        /// Deletes the account balance.
        /// </summary>
        /// <param name="accountBalance">The journal entry account.</param>
        /// <returns></returns>
        public string DeleteAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspDelete_AccountBalance";

            object[] parms = { "@AccountBalanceID", accountBalance.AccountBalanceId };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// Deletes the account balance.
        /// </summary>
        /// <returns></returns>
        public string DeleteAccountBalance()
        {
            const string sql = @"uspDelete_AccountBalance_SumAmountNull";
            return Db.Delete(sql, true);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountBalanceEntity> Make = reader =>
            new AccountBalanceEntity
            {
                AccountBalanceId = reader["AccountBalanceID"].AsInt(),
                BalanceDate = reader["BalanceDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AccountNumber = reader["AccountNumber"].AsString(),
                MovementCreditAmountExchange = reader["MovementCreditAmountExchange"].AsDecimal(),
                MovementCreditAmountOC = reader["MovementCreditAmountOC"].AsDecimal(),
                MovementDebitAmountExchange = reader["MovementDebitAmountExchange"].AsDecimal(),
                MovementDebitAmountOC = reader["MovementDebitAmountOC"].AsDecimal(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                CustomerId = reader["CustomerID"].AsString().AsIntForNull(),
                VendorId = reader["VendorID"].AsString().AsIntForNull(),
                EmployeeId = reader["EmployeeID"].AsString().AsIntForNull(),
                AccountingObjectId = reader["AccountingObjectID"].AsString().AsIntForNull(),
                MergerFundId = reader["MergerFundID"].AsString().AsIntForNull(),
                BankId = reader["BankID"].AsString().AsIntForNull(),
                ProjectId = reader["ProjectID"].AsString().AsIntForNull(),
                InventoryItemId = reader["InventoryItemID"].AsIntForNull(),
            };

        /// <summary>
        /// Takes the specified account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        private static object[] Take(AccountBalanceEntity accountBalance)
        {
            return new object[]  
            {
                @"AccountBalanceID", accountBalance.AccountBalanceId,
                @"BalanceDate", accountBalance.BalanceDate,
                @"CurrencyCode", accountBalance.CurrencyCode,
                @"ExchangeRate", accountBalance.ExchangeRate,
                @"AccountNumber", accountBalance.AccountNumber,
                @"MovementCreditAmountExchange", accountBalance.MovementCreditAmountExchange,
                @"MovementCreditAmountOC", accountBalance.MovementCreditAmountOC,
                @"MovementDebitAmountExchange", accountBalance.MovementDebitAmountExchange,
                @"MovementDebitAmountOC", accountBalance.MovementDebitAmountOC,
                @"BudgetChapterCode", accountBalance.BudgetChapterCode,
                @"BudgetCategoryCode", accountBalance.BudgetCategoryCode,
                @"BudgetSourceCode", accountBalance.BudgetSourceCode,
                @"BudgetItemCode", accountBalance.BudgetItemCode,
                @"CustomerID", accountBalance.CustomerId,
                @"VendorID", accountBalance.VendorId,
                @"EmployeeID", accountBalance.EmployeeId,
                @"AccountingObjectID", accountBalance.AccountingObjectId,
                @"MergerFundID", accountBalance.MergerFundId,
                @"BankID", accountBalance.BankId,
                @"ProjectID", accountBalance.ProjectId,
                @"InventoryItemID",accountBalance.InventoryItemId
            };
        }
    }
}