using TSD.AccountingSoft.BusinessEntities.Business.Tool;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Tool;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Tool
{
    public class SqlServerSUIncrementDecrementDao : ISUIncrementDecrementDao
    {
        public SUIncrementDecrementEntity GetSUIncrementDecrement(long refId)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefdateAndReftype(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefdateAndReftype";
            object[] parms =
            {
                "@RefType", sUIncrementDecrement.RefType, "@RefDate", sUIncrementDecrement.RefDate, "@RefNo",
                sUIncrementDecrement.RefNo
            };
            return Db.Read(procedures, true, Make, parms);
        }

        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<SUIncrementDecrementEntity> GetSUIncrementDecrements()
        {
            const string procedures = @"uspGet_All_SUIncrementDecrement";
            return Db.ReadList(procedures, true, Make);
        }

        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByYearOfRefDate(int refTypeId, short yearOfRefDate)
        {
            const string procedures = @"uspGet_SUIncrementDecrement_ByRefType_By_PostedYear";
            object[] parms = { "@PostedDate", yearOfRefDate, "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public decimal GetSUIncrementDecrementQuantity(string currencyCode, int inventoryItemId, int departmentId, long refId, DateTime postedDate)
        {
            const string sql = "uspSUIncrementDecrement_GetQuantity";
            object[] parms = { "@CurrencyCode", currencyCode, "@InventoryItemID", inventoryItemId, "@DepartmentID", departmentId, "@PostDate", postedDate, "@RefID", refId };
            return Db.GetScalar(sql, true, parms).AsDecimal();
        }

        public long InsertSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string sql = @"uspInsert_SUIncrementDecrement";
            return Db.Insert(sql, true, Take(sUIncrementDecrement));
        }

        public string UpdateSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string sql = @"uspUpdate_SUIncrementDecrement";
            return Db.Update(sql, true, Take(sUIncrementDecrement));
        }

        public string DeleteSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement)
        {
            const string sql = @"uspDelete_SUIncrementDecrement";

            object[] parms = { "@RefID", sUIncrementDecrement.RefId };
            return Db.Delete(sql, true, parms);
        }

        #region Make & Take

        private static readonly Func<IDataReader, SUIncrementDecrementEntity> Make = reader => new SUIncrementDecrementEntity
        {
            RefId = reader["RefID"].AsLong(),
            RefType = reader["RefType"].AsInt(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            RefNo = reader["RefNo"].AsString(),
            JournalMemo = reader["JournalMemo"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            TotalAmountOc = reader["TotalAmountOc"].AsDecimal(),
            TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal()
        };

        private object[] Take(SUIncrementDecrementEntity sUIncrementDecrementDetail)
        {
            return new object[]
            {
                "@RefID", sUIncrementDecrementDetail.RefId,
                "@RefType", sUIncrementDecrementDetail.RefType,
                "@RefDate", sUIncrementDecrementDetail.RefDate,
                "@PostedDate", sUIncrementDecrementDetail.PostedDate,
                "@RefNo", sUIncrementDecrementDetail.RefNo,
                "@JournalMemo", sUIncrementDecrementDetail.JournalMemo,
                "@CurrencyCode", sUIncrementDecrementDetail.CurrencyCode,
                "@ExchangeRate", sUIncrementDecrementDetail.ExchangeRate,
                "@TotalAmountOc", sUIncrementDecrementDetail.TotalAmountOc,
                "@TotalAmountExchange", sUIncrementDecrementDetail.TotalAmountExchange
            };
        }

        #endregion
    }
}
