/***********************************************************************
 * <copyright file="SqlServerJournalEntryAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer
{
    /// <summary>
    /// SqlServerJournalEntryAccountDao
    /// </summary>
    public class SqlServerJournalEntryAccountDao : IJournalEntryAccountDao
    {
        /// <summary>
        /// Inserts the receipt voucher.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        public int InsertJournalEntryAccount(JournalEntryAccountEntity journalEntryAccount)
        {
            const string sql = @"uspInsert_JournalEntryAccount";
            return Db.Insert(sql, true, Take(journalEntryAccount));
        }

        /// <summary>
        /// Inserts the double journal entry account.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        public int InsertDoubleJournalEntryAccount(JournalEntryAccountEntity journalEntryAccount)
        {
            const string sql = @"uspInsertDouble_JournalEntryAccount";
            return Db.Insert(sql, true, Take(journalEntryAccount));
        }

        /// <summary>
        /// Deletes the journal entry account.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        public string DeleteJournalEntryAccount(JournalEntryAccountEntity journalEntryAccount)
        {
            const string sql = @"uspDelete_JournalEntryAccount";

            object[] parms = { "@RefTypeID", journalEntryAccount.RefTypeId, "@RefID", journalEntryAccount.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Gets the journal entry account for capital allocate.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        public List<JournalEntryAccountEntity> GetJournalEntryAccountForCapitalAllocate(JournalEntryAccountEntity journalEntryAccount)
        {

            const string sql = @"uspGet_JournalEntryAccount_ForCapitalAllocate";
            object[] parms =
                {
                    "@AccountNumber",journalEntryAccount.AccountNumber,
                    "@CorrespondingAccountNumber", journalEntryAccount.CorrespondingAccountNumber,
                    "@CurrencyCode", journalEntryAccount.CurrencyCode,
                    "@BudgetSourceCode", journalEntryAccount.BudgetSourceCode,
                    "@BudgetItemCode",journalEntryAccount.BudgetItemCode,
                    "@FromDate",journalEntryAccount.RefDate,
                    "@ToDate", journalEntryAccount.PostedDate,
                    "@JournalType", journalEntryAccount.JournalType
                };
            return Db.ReadList(sql, true, Make, parms);

        }

        /// <summary>
        /// Deletes the journal entry account.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteJournalEntryAccount(long refId, int refTypeId)
        {
            const string sql = @"uspDelete_JournalEntryAccount";

            object[] parms = { "@RefID", refId, "@RefTypeID", refTypeId };
            return Db.Delete(sql, true, parms);
        }


        public string DeleteJournalEntryAccountByPostedDateAndRefType(DateTime posdate, int refTypeId)
        {
            const string sql = @"uspDelete_OpeningJournalEntryAccount";
            object[] parms = { "@PostedDate", posdate, "@RefTypeID", refTypeId };
            return Db.Delete(sql, true, parms);
        }


        /// <summary>
        /// Deletes the journal entry account by acount number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteJournalEntryAccountByAcountNumber(string accountNumber, int refTypeId)
        {
            const string sql = @"uspDelete_JournalEntryAccountByAccountNumber";

            object[] parms = { "@AccountNumber", accountNumber, "@RefTypeID", refTypeId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the journal entry account by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteJournalEntryAccountByFixedAssetId(int fixedAssetId, long refTypeId)
        {
            const string procedures = @"uspDelete_JournalEntryAccountForFixedAsset";
            object[] parms = { "@FixedAssetID", fixedAssetId, "@RefTypeID", refTypeId };
            return Db.Delete(procedures, true, parms);
        }
        
        /// <summary>
        /// Gets the journal entry account by reference no reference date.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<JournalEntryAccountEntity> GetJournalEntryAccountByRefNoRefDate(string refNo, DateTime refDate)
        {
            const string sql = @"uspGet_JournalEntryAccount_ByRefNoRefDate";
            object[] parms = { "@RefNo", refNo, "@RefDate", refDate };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the journal entry accounts.
        /// </summary>
        /// <param name="exportType">Type of the export.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public List<JournalEntryAccountEntity> GetJournalEntryAccounts(int exportType, DateTime fromDate, DateTime toDate)
        {
            //const string sql = @"uspGet_JournalEntryAccount_ByDate";
            string sql;
            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate };

            switch (exportType)
            {
                case 1:
                    sql = @"uspGet_JournalEntryAccount_ForReceiveFinalization";
                    return Db.ReadList(sql, true, MakeForReceiveFinalization, parms);
                    break;
                case 2:
                    sql = @"uspGet_JournalEntryAccount_ForExpenseFinalization";
                    return Db.ReadList(sql, true, MakeForExpenseFinalization, parms);
                    break;
                default:
                    sql = @"uspGet_JournalEntryAccount_ForBalanceSheet";
                    return Db.ReadList(sql, true, MakeForBalanceSheet, parms);
                    break;
            }
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, JournalEntryAccountEntity> Make = reader =>
            new JournalEntryAccountEntity
            {
                CustomerId = reader["CustomerID"].AsId(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                VoucherTypeId = reader["VoucherTypeId"].AsInt(),
                EmployeeId = reader["EmployeeId"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                VendorId = reader["VendorId"].AsInt(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AccountingObjectId = reader["AccountingObjectId"].AsInt(),
                AccountNumber = reader["AccountNumber"].AsString(),
                Description = reader["Description"].AsString(),
                MergerFundId = reader["MergerFundId"].AsInt(),
                RefId = reader["RefId"].AsLong(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                AmountOc = reader["AmountOc"].AsDecimal(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                JournalEntryId = reader["JournalEntryId"].AsLong(),
                JournalMemo = reader["JournalMemo"].AsString(),
                JournalType = reader["JournalType"].AsInt(),
                ProjectId = reader["ProjectId"].AsInt(),
                Quantity = reader["Quantity"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                RefDetailId = reader["RefDetailId"].AsLong(),
                RefNo = reader["RefNo"].AsString(),
                RefTypeId = reader["RefTypeId"].AsInt(),
                InventoryItemId = reader["InventoryItemId"].AsInt(),
                BankId = reader["InventoryItemId"].AsIntForNull()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, JournalEntryAccountEntity> MakeForExpenseFinalization = reader =>
            new JournalEntryAccountEntity
            {
                CurrencyCode = reader["CurrencyCode"].AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                AmountOc = reader["AmountOc"].AsDecimal(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                Description = reader["Description"].AsString()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, JournalEntryAccountEntity> MakeForReceiveFinalization = reader =>
            new JournalEntryAccountEntity
            {
                CurrencyCode = reader["CurrencyCode"].AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                AmountOc = reader["AmountOc"].AsDecimal(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                Description = reader["Description"].AsString()
            };

        private static readonly Func<IDataReader, JournalEntryAccountEntity> MakeForBalanceSheet = reader =>
           new JournalEntryAccountEntity
           {
               CurrencyCode = reader["CurrencyCode"].AsString(),
               AccountNumber = reader["AccountNumber"].AsString(),
               BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
               MovementDebitAmountOC = reader["MovementDebitAmountOC"].AsDecimal(),
               MovementDebitAmountExchange = reader["MovementDebitAmountExchange"].AsDecimal(),
               MovementCreditAmountOC = reader["MovementCreditAmountOC"].AsDecimal(),
               MovementCreditAmountExchange = reader["MovementCreditAmountExchange"].AsDecimal()
           };

        /// <summary>
        /// Takes the specified journal entry account.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        private static object[] Take(JournalEntryAccountEntity journalEntryAccount)
        {
            return new object[]  
            {
                @"JournalEntryID", journalEntryAccount.JournalEntryId,
                @"RefID", journalEntryAccount.RefId,
                @"RefDetailID", journalEntryAccount.RefDetailId,
                @"RefTypeID", journalEntryAccount.RefTypeId,
                @"RefNo", journalEntryAccount.RefNo,
                @"RefDate", journalEntryAccount.RefDate,
                @"PostedDate", journalEntryAccount.PostedDate,
                @"Description", journalEntryAccount.Description,
                @"JournalMemo", journalEntryAccount.JournalMemo,
                @"CurrencyCode", journalEntryAccount.CurrencyCode,
                @"ExchangeRate", journalEntryAccount.ExchangeRate,
                @"AccountNumber", journalEntryAccount.AccountNumber,
                @"CorrespondingAccountNumber", journalEntryAccount.CorrespondingAccountNumber,
                @"Quantity", journalEntryAccount.Quantity,
                @"JournalType", journalEntryAccount.JournalType,
                @"AmountOC", journalEntryAccount.AmountOc,
                @"AmountExchange", journalEntryAccount.AmountExchange,
                @"BudgetChapterCode", journalEntryAccount.BudgetChapterCode,
                @"BudgetCategoryCode", journalEntryAccount.BudgetCategoryCode,
                @"BudgetSourceCode", journalEntryAccount.BudgetSourceCode,
                @"BudgetItemCode", journalEntryAccount.BudgetItemCode,
                @"CustomerID", journalEntryAccount.CustomerId,
                @"VendorID", journalEntryAccount.VendorId,
                @"VoucherTypeID", journalEntryAccount.VoucherTypeId,
                @"BankAccount", journalEntryAccount.BankAccount,
                @"EmployeeID", journalEntryAccount.EmployeeId,
                @"AccountingObjectID", journalEntryAccount.AccountingObjectId,
                @"MergerFundID", journalEntryAccount.MergerFundId,
                @"ProjectID", journalEntryAccount.ProjectId,
                @"InventoryItemID", journalEntryAccount.InventoryItemId,
                @"BankID", journalEntryAccount.BankId
            };
        }



    }
}
