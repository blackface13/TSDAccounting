using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    public class SqlServerFixedAssetIncrementDao : IFixedAssetIncrementDao
    {
        public FAIncrementEntity GetFAIncrement(long refId)
        {
            const string procedures = @"uspGet_FixedAssetIncrement_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        //public FAIncrementEntity GetFAIncrementByRefNo(string refNo)
        //{
        //    throw new NotImplementedException();
        //}

        public List<FAIncrementEntity> GetFAIncrementes()
        {
            const string procedures = @"uspGet_All_FixedAssetIncrement";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the FAIncrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public FAIncrementEntity GetFAIncrementByRefNo(string refNo)
        {
            const string procedures = @"uspGet_FixedAssetIncrement_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<FAIncrementEntity> GetFAIncrementesByRefTypeId(int refTypeId)
        {
            throw new NotImplementedException();
        }

        public List<FAIncrementEntity> GetFAIncrementsByYearOfRefDate(int refTypeId, short yearOfRefDate)
        {
            const string procedures = @"uspGet_FixedAssetIncrement_By_PostedYear";

            object[] parms = { "@PostedYear", yearOfRefDate };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InsertFAIncrement(FAIncrementEntity faIncrement)
        {
            const string sql = @"uspInsert_FixedAssetIncrement";
            return Db.Insert(sql, true, Take(faIncrement));
        }

        public string UpdateFAIncrement(FAIncrementEntity faIncrement)
        {
            const string sql = @"uspUpdate_FixedAssetIncrement";
            return Db.Update(sql, true, Take(faIncrement));
        }

        public string DeleteFAIncrement(FAIncrementEntity faIncrement)
        {
            const string sql = @"uspDelete_FixedAssetIncrement";
            object[] parms = { "@RefID", faIncrement.RefId };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAIncrementEntity> Make = reader =>
            new FAIncrementEntity
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
                Trader = reader["Trader"].AsString().AsString(),
                DocumentInclude = reader["DocumentInclude"].AsString(),
                AccountingObjectId = reader["AccountingObjectID"].AsString().AsIntForNull(),
                TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                BankId = reader["BankID"].AsIntForNull()

            };

        /// <summary>
        /// Takes the specified receipt voucher.
        /// </summary>
        /// <param name="faIncrement">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(FAIncrementEntity faIncrement)
        {
            return new object[]  
            {
                @"RefId", faIncrement.RefId,
                @"RefTypeId", faIncrement.RefTypeId,
                @"RefNo", faIncrement.RefNo,
                @"RefDate", faIncrement.RefDate,
                @"PostedDate", faIncrement.PostedDate,
                @"CurrencyCode", faIncrement.CurrencyCode,
                @"ExchangeRate", faIncrement.ExchangeRate,
                @"AccountingObjectType", faIncrement.AccountingObjectType,
                @"CustomerID", faIncrement.CustomerId,
                @"VendorID", faIncrement.VendorId,
                @"AccountingObjectID",faIncrement.AccountingObjectId,
                @"EmployeeID",faIncrement.EmployeeId,
                @"Trader",faIncrement.Trader,
                @"DocumentInclude",faIncrement.DocumentInclude,
                @"TotalAmountOC",faIncrement.TotalAmountOC,
                @"TotalAmountExchange",faIncrement.TotalAmountExchange,
                @"JournalMemo", faIncrement.JournalMemo,
                @"BankID", faIncrement.BankId
            };
        }
    }
}
