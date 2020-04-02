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
    public class SqlServerSUIncrementDecrementDetailDao : ISUIncrementDecrementDetailDao
    {
        public List<SUIncrementDecrementDetailEntity> GetSUIncrementDecrementDetailsByRefId(long refId)
        {
            const string procedures = @"uspGet_SUIncrementDecrementDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public long InsertSUIncrementDecrementDetail(SUIncrementDecrementDetailEntity sUIncrementDecrementDetail)
        {
            const string sql = @"uspInsert_SUIncrementDecrementDetail";
            return Db.Insert(sql, true, Take(sUIncrementDecrementDetail));
        }

        public string DeleteSUIncrementDecrementDetailByRefId(long refId)
        {
            const string procedures = @"uspDelete_SUIncrementDecrementDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        #region Make & Take

        private static readonly Func<IDataReader, SUIncrementDecrementDetailEntity> Make = reader => new SUIncrementDecrementDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            RefId = reader["RefID"].AsLong(),
            DebitAccount = reader["DebitAccount"].AsString(),
            CreditAccount = reader["CreditAccount"].AsString(),
            Description = reader["Description"].AsString(),
            InventoryItemId = reader["InventoryItemID"].AsInt(),
            DepartmentId = reader["DepartmentID"].AsInt(),
            Quantity = reader["Quantity"].AsDecimal(),
            UnitPriceOc = reader["UnitPriceOc"].AsDecimal(),
            UnitPriceExchange = reader["UnitPriceExchange"].AsDecimal(),
            AmountOc = reader["AmountOc"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            AccountingObjectId = reader["AccountingObjectID"].AsIntForNull(),
            CustomerId = reader["CustomerID"].AsIntForNull(),
            VendorId = reader["VendorID"].AsIntForNull(),
            EmployeeId = reader["EmployeeID"].AsIntForNull(),
            SortOrder = reader["SortOrder"].AsIntForNull(),
            BudgetSourceId = reader["BudgetSourceID"].AsIntForNull()
        };

        private object[] Take(SUIncrementDecrementDetailEntity sUIncrementDecrementDetail)
        {
            return new object[]
            {
                "@RefDetailID", sUIncrementDecrementDetail.RefDetailId,
                "@RefID", sUIncrementDecrementDetail.RefId,
                "@DebitAccount", sUIncrementDecrementDetail.DebitAccount,
                "@CreditAccount", sUIncrementDecrementDetail.CreditAccount,
                "@Description", sUIncrementDecrementDetail.Description,
                "@InventoryItemID", sUIncrementDecrementDetail.InventoryItemId,
                "@DepartmentID", sUIncrementDecrementDetail.DepartmentId,
                "@Quantity", sUIncrementDecrementDetail.Quantity,
                "@UnitPriceOc", sUIncrementDecrementDetail.UnitPriceOc,
                "@UnitPriceExchange", sUIncrementDecrementDetail.UnitPriceExchange,
                "@AmountOc", sUIncrementDecrementDetail.AmountOc,
                "@AmountExchange", sUIncrementDecrementDetail.AmountExchange,
                "@AccountingObjectID", sUIncrementDecrementDetail.AccountingObjectId,
                "@CustomerID", sUIncrementDecrementDetail.CustomerId,
                "@VendorID", sUIncrementDecrementDetail.VendorId,
                "@EmployeeID", sUIncrementDecrementDetail.EmployeeId,
                "@SortOrder", sUIncrementDecrementDetail.SortOrder,
                "@BudgetSourceID", sUIncrementDecrementDetail.BudgetSourceId
            };
        }

        #endregion
    }
}
