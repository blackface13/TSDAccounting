/***********************************************************************
 * <copyright file="SqlServerOpeningAccountEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
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
    /// SqlServerOpeningAccountEntryDao
    /// </summary>
    public class SqlServerOpeningAccountEntryDao : IOpeningAccountEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        public List<OpeningAccountEntryEntity> GetOpeningAccountEntries()
        {
            const string procedures = @"uspGet_All_OpeningAccountEntry";
            return Db.ReadList(procedures, true, MakeIncludeAccountDetail);
        }

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public OpeningAccountEntryEntity GetOpeningAccountEntryEntityByAccountCode(string accountCode)
        {
            const string procedures = @"uspGet_OpeningAccountEntry_ByAccountCode";

            object[] parms = { "@AccountCode", accountCode };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public long InsertOpeningAccountEntry(OpeningAccountEntryEntity openingAccountEntryEntity)
        {
            const string sql = @"uspInsert_OpeningAccountEntry";
            return Db.Insert(sql, true, Take(openingAccountEntryEntity));
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public string UpdateOpeningAccountEntry(OpeningAccountEntryEntity openingAccountEntryEntity)
        {
            const string sql = @"uspUpdate_OpeningAccountEntry";
            return Db.Update(sql, true, Take(openingAccountEntryEntity));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningAccountEntryEntity> MakeIncludeAccountDetail = reader =>
            new OpeningAccountEntryEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                AccountCode = reader["AccountCode"].AsString(),
                AccountName = reader["AccountName"].AsString(),
                AccountId = reader["AccountId"].AsInt(),
                ParentId = reader["ParentId"].AsString().AsIntForNull(),
                TotalAccountBeginningDebitAmountOC = reader["TotalAccountBeginningDebitAmountOC"].AsDecimal(),
                TotalAccountBeginningCreditAmountOC = reader["TotalAccountBeginningCreditAmountOC"].AsDecimal(),
                TotalDebitAmountOC = reader["TotalDebitAmountOC"].AsDecimal(),
                TotalCreditAmountOC = reader["TotalCreditAmountOC"].AsDecimal(),
                TotalAccountBeginningDebitAmountExchange = reader["TotalAccountBeginningDebitAmountExchange"].AsDecimal(),
                TotalAccountBeginningCreditAmountExchange = reader["TotalAccountBeginningCreditAmountExchange"].AsDecimal(),
                TotalDebitAmountExchange = reader["TotalDebitAmountExchange"].AsDecimal(),
                TotalCreditAmountExchange = reader["TotalCreditAmountExchange"].AsDecimal(),
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningAccountEntryEntity> Make = reader =>
            new OpeningAccountEntryEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                AccountCode = reader["AccountCode"].AsString(),
                TotalAccountBeginningDebitAmountOC = reader["TotalAccountBeginningDebitAmountOC"].AsDecimal(),
                TotalAccountBeginningCreditAmountOC = reader["TotalAccountBeginningCreditAmountOC"].AsDecimal(),
                TotalDebitAmountOC = reader["TotalDebitAmountOC"].AsDecimal(),
                TotalCreditAmountOC = reader["TotalCreditAmountOC"].AsDecimal(),
                TotalAccountBeginningDebitAmountExchange = reader["TotalAccountBeginningDebitAmountExchange"].AsDecimal(),
                TotalAccountBeginningCreditAmountExchange = reader["TotalAccountBeginningCreditAmountExchange"].AsDecimal(),
                TotalDebitAmountExchange = reader["TotalDebitAmountExchange"].AsDecimal(),
                TotalCreditAmountExchange = reader["TotalCreditAmountExchange"].AsDecimal(),
            };

        /// <summary>
        /// Takes the specified opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        private static object[] Take(OpeningAccountEntryEntity openingAccountEntry)
        {
            return new object[]  
            {
                @"RefID", openingAccountEntry.RefId,
                @"RefTypeID", openingAccountEntry.RefTypeId,
                @"PostedDate", openingAccountEntry.PostedDate,
                @"AccountCode", openingAccountEntry.AccountCode,
                @"TotalAccountBeginningDebitAmountOC", openingAccountEntry.TotalAccountBeginningDebitAmountOC,
                @"TotalAccountBeginningCreditAmountOC", openingAccountEntry.TotalAccountBeginningCreditAmountOC,
                @"TotalDebitAmountOC", openingAccountEntry.TotalDebitAmountOC,
                @"TotalCreditAmountOC", openingAccountEntry.TotalCreditAmountOC,
                @"TotalAccountBeginningDebitAmountExchange", openingAccountEntry.TotalAccountBeginningDebitAmountExchange,
                @"TotalAccountBeginningCreditAmountExchange", openingAccountEntry.TotalAccountBeginningCreditAmountExchange,
                @"TotalDebitAmountExchange", openingAccountEntry.TotalDebitAmountExchange,
                @"TotalCreditAmountExchange", openingAccountEntry.TotalCreditAmountExchange
            };
        }
    }
}
