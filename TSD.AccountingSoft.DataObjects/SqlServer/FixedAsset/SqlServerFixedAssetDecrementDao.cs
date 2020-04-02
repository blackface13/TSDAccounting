/***********************************************************************
 * <copyright file="SqlServerFixedAssetDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    /// <summary>
    /// class SqlServerFixedAssetDecrementDao
    /// </summary>
    public class SqlServerFixedAssetDecrementDao : IFixedAssetDecrementDao
    {
        /// <summary>
        /// Gets the FADecrement.
        /// </summary>
        /// <param name="refId">The FADecrement identifier.</param>
        /// <returns></returns>
        public FADecrementEntity GetFADecrement(long refId)
        {
            const string procedures = @"uspGet_FixedAssetDecrement_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the FADecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public List<FADecrementEntity> GetFADecrementByRefNo(string refNo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the FADecrements.
        /// </summary>
        /// <returns></returns>
        public List<FADecrementEntity> GetFADecrementes()
        {
            const string procedures = @"uspGet_All_FixedAssetDecrement";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the FADecrementes by reference type identifier.
        /// </summary>
        /// <param name="yearOfRefDate"></param>
        /// <returns></returns>
        public List<FADecrementEntity> GetFADecrementsByYearOfRefDate(short yearOfRefDate)
        {
            const string procedures = @"uspGet_FixedAssetDecrement_By_PostedYear";

            object[] parms = { "@PostedYear", yearOfRefDate };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the FADecrementes by reference type identifier.
        /// </summary>
        /// <param name="refTypeId"></param>
        /// <returns></returns>
        public List<FADecrementEntity> GetFADecrementesByRefTypeId(int refTypeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the fa decrementes by reference reference no and reference date.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<FADecrementEntity> GetFADecrementesByRefRefNoAndRefDate(string currencyCode, string refNo, DateTime refDate)
        {
            const string procedures = @"uspGet_FixedAssetDecrement_By_RefNo";

            object[] parms = { "@RefDate", refDate, "@RefNo", refNo, "@CurrencyCode", currencyCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the FADecrement.
        /// </summary>
        /// <param name="faDecrement">The FADecrement.</param>
        /// <returns></returns>
        public int InsertFADecrement(FADecrementEntity faDecrement)
        {
            const string sql = @"uspInsert_FixedAssetDecrement";
            return Db.Insert(sql, true, Take(faDecrement));
        }

        /// <summary>
        /// Updates the FADecrement entity.
        /// </summary>
        /// <param name="faDecrement">The FADecrement.</param>
        /// <returns></returns>
        public string UpdateFADecrement(FADecrementEntity faDecrement)
        {
            const string sql = @"uspUpdate_FixedAssetDecrement";
            return Db.Update(sql, true, Take(faDecrement));
        }

        /// <summary>
        /// Deletes the FADecrement entity.
        /// </summary>
        /// <param name="faDecrement">The FADecrement.</param>
        /// <returns></returns>
        public string DeleteFADecrement(FADecrementEntity faDecrement)
        {
            const string sql = @"uspDelete_FixedAssetDecrement";

            object[] parms = { "@RefID", faDecrement.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FADecrementEntity> Make = reader =>
            new FADecrementEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AccountingObjectType = reader["AccountingObjectType"].AsString().AsShortForNull(),
                CustomerId = reader["CustomerID"].AsString().AsIntForNull(),
                EmployeeId = reader["EmployeeID"].AsString().AsIntForNull(),
                VendorId = reader["VendorID"].AsString().AsIntForNull(),
                AccountingObjectId = reader["AccountingObjectID"].AsString().AsIntForNull(),
                TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                DocumentInclude = reader["DocumentInclude"].AsString(),
                Trader = reader["Trader"].AsString(),
                BankId = reader["BankID"].AsIntForNull()
            };

        /// <summary>
        /// Takes the specified receipt voucher.
        /// </summary>
        /// <param name="faDecrement">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(FADecrementEntity faDecrement)
        {
            return new object[]  
            {
                @"RefId", faDecrement.RefId,
                @"RefTypeId", faDecrement.RefTypeId,
                @"RefNo", faDecrement.RefNo,
                @"RefDate", faDecrement.RefDate,
                @"PostedDate", faDecrement.PostedDate,
                @"CurrencyCode", faDecrement.CurrencyCode,
                @"ExchangeRate", faDecrement.ExchangeRate,
                @"AccountingObjectType", faDecrement.AccountingObjectType,
                @"CustomerID", faDecrement.CustomerId,
                @"VendorID", faDecrement.VendorId,
                @"AccountingObjectID",faDecrement.AccountingObjectId,
                @"EmployeeID",faDecrement.EmployeeId,
                @"TotalAmountOC",faDecrement.TotalAmountOC,
                @"TotalAmountExchange",faDecrement.TotalAmountExchange,
                @"JournalMemo", faDecrement.JournalMemo,
                @"DocumentInclude", faDecrement.DocumentInclude,
                @"Trader",faDecrement.Trader,
                @"BankID",faDecrement.BankId
            };
        }
    }
}
