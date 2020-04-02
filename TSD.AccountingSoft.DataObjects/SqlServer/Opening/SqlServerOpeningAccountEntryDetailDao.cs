/***********************************************************************
 * <copyright file="SqlServerOpeningAccountEntryDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Opening
{
    /// <summary>
    /// SqlServerOpeningAccountEntryDetailDao
    /// </summary>
    public class SqlServerOpeningAccountEntryDetailDao : IOpeningAccountEntryDetailDao
    {
        /// <summary>
        /// Gets the opening account entry details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<OpeningAccountEntryDetailEntity> GetOpeningAccountEntryDetailsByRefId(long refId)
        {
            const string procedures = @"uspGet_OpeningAccountEntryDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the opening account entry detail.
        /// </summary>
        /// <param name="openingAccountEntryDetail">The opening account entry detail.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int InsertOpeningAccountEntryDetail(OpeningAccountEntryDetailEntity openingAccountEntryDetail)
        {
            const string sql = @"uspInsert_OpeningAccountEntryDetail";
            return Db.Insert(sql, true, Take(openingAccountEntryDetail));
        }

        /// <summary>
        /// Deletes the opening account entry detail by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteOpeningAccountEntryDetailByAccountCode(string accountCode)
        {
            const string procedures = @"uspDelete_OpeningAccountEntryDetail_ByAccountCode";
            object[] parms = { "@AccountCode", accountCode };

            return Db.Update(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the opening account entry detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteOpeningAccountEntryDetailByRefId(long refId)
        {
            const string procedures = @"uspDelete_OpeningAccountEntryDetail_ByRefID";
            object[] parms = { "@RefID", refId };

            return Db.Update(procedures, true, parms);
        }

        /// <summary>
        /// Takes the specified opening account entry detail.
        /// </summary>
        /// <param name="openingAccountEntryDetail">The opening account entry detail.</param>
        /// <returns></returns>
        private static object[] Take(OpeningAccountEntryDetailEntity openingAccountEntryDetail)
        {
            return new object[]  
            {
                @"RefDetailID", openingAccountEntryDetail.RefDetailId,
                @"RefID", openingAccountEntryDetail.RefId,
                @"RefTypeID", openingAccountEntryDetail.RefTypeId,
                @"PostedDate", openingAccountEntryDetail.PostedDate,
                @"AccountBeginningDebitAmountOC", openingAccountEntryDetail.AccountBeginningDebitAmountOC,
                @"AccountBeginningCreditAmountOC", openingAccountEntryDetail.AccountBeginningCreditAmountOC,
                @"DebitAmountOC", openingAccountEntryDetail.DebitAmountOC,
                @"CreditAmountOC", openingAccountEntryDetail.CreditAmountOC,
                @"AccountBeginningDebitAmountExchange", openingAccountEntryDetail.AccountBeginningDebitAmountExchange,
                @"AccountBeginningCreditAmountExchange", openingAccountEntryDetail.AccountBeginningCreditAmountExchange,
                @"DebitAmountExchange", openingAccountEntryDetail.DebitAmountExchange,
                @"CreditAmountExchange", openingAccountEntryDetail.CreditAmountExchange,
                @"CurrencyCode", openingAccountEntryDetail.CurrencyCode,
                @"ExchangeRate", openingAccountEntryDetail.ExchangeRate,
                @"BudgetSourceCode", openingAccountEntryDetail.BudgetSourceCode,
                @"BudgetChapterCode", openingAccountEntryDetail.BudgetChapterCode,
                @"BudgetCategoryCode", openingAccountEntryDetail.BudgetCategoryCode,
                @"BudgetGroupItemCode", openingAccountEntryDetail.BudgetGroupItemCode,
                @"BudgetItemCode", openingAccountEntryDetail.BudgetItemCode,
                @"MergerFundID", openingAccountEntryDetail.MergerFundId,
                @"EmployeeID", openingAccountEntryDetail.EmployeeId,
                @"CustomerID", openingAccountEntryDetail.CustomerId,
                @"VendorID", openingAccountEntryDetail.VendorId,
                @"AccountingObjectID", openingAccountEntryDetail.AccountingObjectId,
                @"ProjectID", openingAccountEntryDetail.ProjectId,
                @"BankID", openingAccountEntryDetail.BankId
            };
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningAccountEntryDetailEntity> Make = reader =>
            new OpeningAccountEntryDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsLong(),
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                AccountBeginningDebitAmountOC = reader["AccountBeginningDebitAmountOC"].AsDecimal(),
                AccountBeginningCreditAmountOC = reader["AccountBeginningCreditAmountOC"].AsDecimal(),
                DebitAmountOC = reader["DebitAmountOC"].AsDecimal(),
                CreditAmountOC = reader["CreditAmountOC"].AsDecimal(),
                AccountBeginningDebitAmountExchange = reader["AccountBeginningDebitAmountExchange"].AsDecimal(),
                AccountBeginningCreditAmountExchange = reader["AccountBeginningCreditAmountExchange"].AsDecimal(),
                DebitAmountExchange = reader["DebitAmountExchange"].AsDecimal(),
                CreditAmountExchange = reader["CreditAmountExchange"].AsDecimal(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsFloat(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                MergerFundId = reader["MergerFundID"].AsString().AsIntForNull(),
                EmployeeId = reader["EmployeeID"].AsString().AsIntForNull(),
                CustomerId = reader["CustomerID"].AsString().AsIntForNull(),
                VendorId = reader["VendorID"].AsString().AsIntForNull(),
                AccountingObjectId = reader["AccountingObjectID"].AsString().AsIntForNull(),
                ProjectId = reader["ProjectID"].AsString().AsIntForNull(),
                BankId = reader["BankID"].AsString().AsIntForNull()
            };
    }
}
