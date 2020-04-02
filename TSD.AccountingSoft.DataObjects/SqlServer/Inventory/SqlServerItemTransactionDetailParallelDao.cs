using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Inventory
{
    public class SqlServerItemTransactionDetailParallelDao : IItemTransactionDetailParallelDao
    {
        public string DeleteItemTransactionDetailParallelByDetailId(long refDetailId)
        {
            const string procedures = @"uspDelete_ItemTransactionDetailParallel_ByRefDetailID";
            object[] parms = { "@RefDetailID", refDetailId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteItemTransactionDetailParallelById(long refId)
        {
            const string procedures = @"uspDelete_ItemTransactionDetailParallel_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<ItemTransactionDetailParallelEntity> GetItemTransactionDetailParallelByRefId(long refId, int refTypeId)
        {
            const string procedures = @"uspGet_ItemTransactionDetailParallel_ByRefIdAndRefTypeId";
            object[] parms = {
                "@RefID", refId
                , "@RefTypeID", refTypeId
            };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InsertItemTransactionDetailParallel(ItemTransactionDetailParallelEntity depositDetail)
        {
            const string procedures = @"uspInsert_ItemTransactionDetailParallel";
            return Db.Insert(procedures, true, Take(depositDetail));
        }

        public string UpdateItemTransactionDetailParallel(ItemTransactionDetailParallelEntity depositDetail)
        {
            const string procedures = @"uspUpdate_ItemTransactionDetailParallel";
            return Db.Update(procedures, true, Take(depositDetail));
        }

        #region Make & Take

        private static readonly Func<IDataReader, ItemTransactionDetailParallelEntity> Make = reader =>
        {
            var itemTransactionDetailParallel = new ItemTransactionDetailParallelEntity();
            itemTransactionDetailParallel.RefDetailId = reader["RefDetailID"].AsLong();
            itemTransactionDetailParallel.RefId = reader["RefID"].AsLong();
            itemTransactionDetailParallel.RefTypeId = reader["RefTypeID"].AsInt();
            itemTransactionDetailParallel.Description = reader["Description"].AsString();
            itemTransactionDetailParallel.AccountNumber = reader["AccountNumber"].AsString();
            itemTransactionDetailParallel.CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString();
            itemTransactionDetailParallel.TotalQuantity = reader["TotalQuantity"].AsInt();
            itemTransactionDetailParallel.Price = reader["Price"].AsDecimal();
            itemTransactionDetailParallel.PriceExchange = reader["PriceExchange"].AsDecimal();
            itemTransactionDetailParallel.AmountOc = reader["AmountOc"].AsDecimal();
            itemTransactionDetailParallel.AmountExchange = reader["AmountExchange"].AsDecimal();
            itemTransactionDetailParallel.BudgetSourceCode = reader["BudgetSourceCode"].AsString();
            itemTransactionDetailParallel.BudgetItemCode = reader["BudgetItemCode"].AsString();
            itemTransactionDetailParallel.VoucherTypeId = reader["VoucherTypeID"].AsIntForNull();
            itemTransactionDetailParallel.DepartmentId = reader["DepartmentID"].AsIntForNull();
            itemTransactionDetailParallel.ProjectId = reader["ProjectID"].AsIntForNull();
            itemTransactionDetailParallel.FixedAssetId = reader["FixedAssetID"].AsIntForNull();
            itemTransactionDetailParallel.InventoryItemId = reader["InventoryItemID"].AsIntForNull();
            itemTransactionDetailParallel.MergerFundId = reader["MergerFundID"].AsIntForNull();
            itemTransactionDetailParallel.AccountingObjectId = reader["AccountingObjectID"].AsIntForNull();
            itemTransactionDetailParallel.EmployeeId = reader["EmployeeID"].AsIntForNull();
            itemTransactionDetailParallel.CustomerId = reader["CustomerID"].AsIntForNull();
            itemTransactionDetailParallel.VendorId = reader["VendorID"].AsIntForNull();
            itemTransactionDetailParallel.AutoBusinessId = reader["AutoBusinessID"].AsIntForNull();

            return itemTransactionDetailParallel;
        };

        private static object[] Take(ItemTransactionDetailParallelEntity itemTransactionDetailParallel)
        {
            return new object[]
            {
                "@RefDetailID", itemTransactionDetailParallel.RefDetailId,
                "@RefID", itemTransactionDetailParallel.RefId,
                "@RefTypeID", itemTransactionDetailParallel.RefTypeId,
                "@Description", itemTransactionDetailParallel.Description,
                "@AccountNumber", itemTransactionDetailParallel.AccountNumber,
                "@CorrespondingAccountNumber", itemTransactionDetailParallel.CorrespondingAccountNumber,
                "@TotalQuantity", itemTransactionDetailParallel.TotalQuantity,
                "@Price", itemTransactionDetailParallel.Price,
                "@PriceExchange", itemTransactionDetailParallel.PriceExchange,
                "@AmountOc", itemTransactionDetailParallel.AmountOc,
                "@AmountExchange", itemTransactionDetailParallel.AmountExchange,
                "@BudgetSourceCode", itemTransactionDetailParallel.BudgetSourceCode,
                "@BudgetItemCode", itemTransactionDetailParallel.BudgetItemCode,
                "@VoucherTypeID", itemTransactionDetailParallel.VoucherTypeId,
                "@DepartmentID", itemTransactionDetailParallel.DepartmentId,
                "@ProjectID", itemTransactionDetailParallel.ProjectId,
                "@FixedAssetID", itemTransactionDetailParallel.FixedAssetId,
                "@InventoryItemID", itemTransactionDetailParallel.InventoryItemId,
                "@MergerFundID", itemTransactionDetailParallel.MergerFundId,
                "@AccountingObjectID", itemTransactionDetailParallel.AccountingObjectId,
                "@EmployeeID", itemTransactionDetailParallel.EmployeeId,
                "@CustomerID", itemTransactionDetailParallel.CustomerId,
                "@VendorID", itemTransactionDetailParallel.VendorId,
                "@AutoBusinessID", itemTransactionDetailParallel.AutoBusinessId,
            };
        }

        #endregion
    }
}
