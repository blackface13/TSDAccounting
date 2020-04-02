/***********************************************************************
 * <copyright file="SqlServerOpeningInventoryEntryDao.cs" company="BUCA JSC">
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
    /// SqlServerOpeningInventoryEntryDao
    /// </summary>
    public class SqlServerOpeningInventoryEntryDao : IOpeningInventoryEntryDao 
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        public List<OpeningInventoryEntryEntity> GetOpeningInventoryEntries() 
        {
            const string procedures = @"uspGet_All_OpeningInventoryEntry";
            return Db.ReadList(procedures, true, MakeIncludeAccountDetail);
        }

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<OpeningInventoryEntryEntity> GetOpeningInventoryEntryEntityByAccountCode(string accountCode)
        {
            const string procedures = @"uspGet_OpeningInventoryEntry_ByAccountCode";

            object[] parms = { "@AccountCode", accountCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public long InsertOpeningInventoryEntry(OpeningInventoryEntryEntity openingAccountEntryEntity)
        {
            try
            {

                const string sql = @"uspInsert_OpeningInventoryEntry";
                return Db.Insert(sql, true, Take(openingAccountEntryEntity));
            }
            catch (Exception e)
            {
                return 0;
            }

         
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public string UpdateOpeningInventoryEntry(OpeningInventoryEntryEntity openingAccountEntryEntity)
        {
            const string sql = @"uspUpdate_OpeningInventoryEntry";
            return Db.Update(sql, true, Take(openingAccountEntryEntity));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningInventoryEntryEntity> MakeIncludeAccountDetail = reader =>
            new OpeningInventoryEntryEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                AccountNumber = reader["AccountCode"].AsString(), //AccountNumber
                UnitPriceOc = reader["UnitPriceOc"].AsDecimal(),
                UnitPriceExchange = reader["UnitPriceExchange"].AsDecimal(),
                Quantity = reader["Quantity"].AsString().AsInt(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AmountOc = reader["AmountOC"].AsDecimal(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsInt(),
                StockId = reader["StockID"].AsInt(),
              //  TotalDebitAmountExchange = reader["TotalDebitAmountExchange"].AsDecimal(),
               // TotalCreditAmountExchange = reader["TotalCreditAmountExchange"].AsDecimal(),
                AccountName = reader["AccountName"].AsString(),
                AccountId = reader["AccountId"].AsInt(),
                ParentId = reader["ParentId"].AsString().AsIntForNull(),
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningInventoryEntryEntity> Make = reader =>
            new OpeningInventoryEntryEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                AccountNumber = reader["AccountNumber"].AsString(),
                UnitPriceOc = reader["UnitPriceOc"].AsDecimal(),
                UnitPriceExchange = reader["UnitPriceExchange"].AsDecimal(),
                Quantity = reader["Quantity"].AsString().AsInt(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AmountOc = reader["AmountOC"].AsDecimal(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsInt(),
                StockId = reader["StockID"].AsInt(),
            };

        /// <summary>
        /// Takes the specified opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        private static object[] Take(OpeningInventoryEntryEntity openingAccountEntry)
        {
            return new object[]  
            {
                @"RefID", openingAccountEntry.RefId,
                @"RefTypeID", openingAccountEntry.RefTypeId,
                @"PostedDate", openingAccountEntry.PostedDate,
                @"AccountNumber", openingAccountEntry.AccountNumber,
                @"UnitPriceExchange", openingAccountEntry.UnitPriceExchange,
                @"UnitPriceOC", openingAccountEntry.UnitPriceOc,
                @"Quantity", openingAccountEntry.Quantity,
                @"ExchangeRate", openingAccountEntry.ExchangeRate,
                @"AmountOC", openingAccountEntry.AmountOc,
                @"AmountExchange", openingAccountEntry.AmountExchange,
                @"CurrencyCode", openingAccountEntry.CurrencyCode,
                @"InventoryItemID", openingAccountEntry.InventoryItemId,
                @"StockId", openingAccountEntry.StockId
            };
        }


        public OpeningInventoryEntryEntity GetOpeningInventoryEntryEntityByAccountCodeForMaster(string accountCode)
        {
            const string procedures = @"uspGet_OpeningInventoryEntry_ByAccountCode";

            object[] parms = { "@AccountCode", accountCode };
            return Db.Read(procedures, true, Make, parms);
        }


        public string DeleteOpeningInventoryEntryByAccountCode(OpeningInventoryEntryEntity openingAccountEntryEntity)
        {
            const string sql = @"uspDelet_OpeningInventoryEntryByAccountNumber";

            object[] parms = { "@AccountNumber", openingAccountEntryEntity.AccountNumber };
            return Db.Delete(sql, true, parms);
        }
    }
}
