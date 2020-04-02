/***********************************************************************
 * <copyright file="SqlServerBankDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Search;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Search;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Search
{
    /// <summary>
    /// SqlServerBankDao
    /// </summary>
    public class SqlServerSearchDao : ISearchDao 
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, SearchEntity> Make = reader =>
            new SearchEntity
            {
                RefId = reader["RefID"].AsInt(),
               // RefId = 1,
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsString(),
                PostedDate = reader["PostedDate"].AsString(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                AmountOc = reader["AmountOC"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                CustomerId = reader["CustomerID"].AsIntForNull(),
                VendorId = reader["VendorID"].AsIntForNull(),
                AccountingObjectId = reader["AccountingObjectID"].AsIntForNull(),
                EmployeeId = reader["EmployeeID"].AsIntForNull(),
                CustomerCode = reader["CustomerCode"].AsString(),
                VendorCode = reader["VendorCode"].AsString(),
                AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
                EmployeeCode = reader["EmployeeCode"].AsString(),
                ProjectId = reader["ProjectID"].AsIntForNull(),
                ProjectCode = reader["ProjectCode"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsIntForNull(),
                InventoryItemCode = reader["InventoryItemCode"].AsString(),
                VoucherTypeId = reader["VoucherTypeID"].AsIntForNull(),
                VoucherTypeName = reader["VoucherTypeName"].AsString(),
                RefTypeName = reader["RefTypeName"].AsString(),
                BudgetGroupCode = reader["BudgetGroupCode"].AsString(),
                DepartmentCode = reader["DepartmentCode"].AsString(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal()
            };

        /// <summary>
        /// Takes the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        private static object[] Take(BankEntity bank)
        {
            return new object[]  
            {
                "@BankID", bank.BankId,
                "@BankAccount", bank.BankAccount,
                "@BankAddress", bank.BankAddress,
                "@BankName", bank.BankName,
                "@Description", bank.Description,
                "@IsActive", bank.IsActive
            };
        }

    /// <summary>
    ///  Tìm kiểm chứng từ
    /// </summary>
    /// <param name="whereClause"></param>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <param name="currencyCode"></param>
    /// <param name="departmentCode"></param>
    /// <param name="fixedAssetCode"></param>
    /// <returns></returns>
        public IList<SearchEntity> GetSearch(string whereClause, string fromDate, string toDate, string currencyCode, string departmentCode, string fixedAssetCode, string budgetGroupCode)  
        {
            try
            {
                    if (fromDate == "")
                    {
                        fromDate = DateTime.Now.AddYears(-100).ToShortDateString();
                        toDate = DateTime.Now.AddYears(100).ToShortDateString();
                    }
                        const string procedures = @"uspSearch";
                        whereClause = whereClause + " 1=1";
                        object[] parms =
                            {"@WhereClause", whereClause,
                             "@FromDate", DateTime.Parse(fromDate),
                             "@ToDate", DateTime.Parse(toDate),
                             "@FixedAssetCode",fixedAssetCode,
                             "@DepartmentCode",departmentCode,
                             "@BudgetGroupCode",budgetGroupCode
                            };


                        return Db.ReadList(procedures, true, Make, parms);
              }

            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// Gets the search.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public IList<SearchEntity> GetSearch(string whereClause)
        {
            const string procedures = @"uspSearch";
            object[] parms = { "@WhereClause", whereClause };
            return Db.ReadList(procedures, true, Make, parms);
        }
    }
}
