using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    public class SqlServerFixedAssetIncrementDetailParallelDao : IFixedAssetIncrementDetailParallelDao
    {
        public string DeleteFixedAssetIncrementDetailParallelByDetailId(long refDetailId)
        {
            const string procedures = @"uspDelete_FixedAssetIncrementDetailParallel_ByRefDetailID";
            object[] parms = { "@RefDetailID", refDetailId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteFixedAssetIncrementDetailParallelById(long refId)
        {
            const string procedures = @"uspDelete_FixedAssetIncrementDetailParallel_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<FAIncrementDetailParallelEntity> GetFixedAssetIncrementDetailParallelByRefId(long refId)
        {
            const string procedures = @"uspGet_FixedAssetIncrementDetailParallel_ByRefId";
            object[] parms = {
                "@RefID", refId
            };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InsertFixedAssetIncrementDetailParallel(FAIncrementDetailParallelEntity detail)
        {
            const string procedures = @"uspInsert_FixedAssetIncrementDetailParallel";
            return Db.Insert(procedures, true, Take(detail));
        }

        public string UpdateFixedAssetIncrementDetailParallel(FAIncrementDetailParallelEntity detail)
        {
            const string procedures = @"uspUpdate_FixedAssetIncrementDetailParallel";
            return Db.Update(procedures, true, Take(detail));
        }

        #region Make & Take

        private static readonly Func<IDataReader, FAIncrementDetailParallelEntity> Make = reader =>
        {
            var detail = new FAIncrementDetailParallelEntity();
            detail.RefDetailId = reader["RefDetailID"].AsLong();
            detail.RefId = reader["RefID"].AsLong();
            detail.RefTypeId = reader["RefTypeID"].AsInt();
            detail.Description = reader["Description"].AsString();
            detail.AccountNumber = reader["AccountNumber"].AsString();
            detail.CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString();
            detail.Quantity = reader["Quantity"].AsInt();
            detail.Price = reader["Price"].AsDecimal();
            detail.PriceExchange = reader["PriceExchange"].AsDecimal();
            detail.AmountOc = reader["AmountOc"].AsDecimal();
            detail.AmountExchange = reader["AmountExchange"].AsDecimal();
            detail.BudgetSourceCode = reader["BudgetSourceCode"].AsString();
            detail.BudgetItemCode = reader["BudgetItemCode"].AsString();
            detail.VoucherTypeId = reader["VoucherTypeID"].AsIntForNull();
            detail.DepartmentId = reader["DepartmentID"].AsIntForNull();
            detail.ProjectId = reader["ProjectID"].AsIntForNull();
            detail.FixedAssetId = reader["FixedAssetID"].AsIntForNull();
            detail.InventoryItemId = reader["InventoryItemID"].AsIntForNull();
            detail.MergerFundId = reader["MergerFundID"].AsIntForNull();
            detail.AccountingObjectId = reader["AccountingObjectID"].AsIntForNull();
            detail.EmployeeId = reader["EmployeeID"].AsIntForNull();
            detail.CustomerId = reader["CustomerID"].AsIntForNull();
            detail.VendorId = reader["VendorID"].AsIntForNull();
            detail.AutoBusinessId = reader["AutoBusinessID"].AsIntForNull();

            return detail;
        };

        private static object[] Take(FAIncrementDetailParallelEntity detail)
        {
            return new object[]
            {
                "@RefDetailID", detail.RefDetailId,
                "@RefID", detail.RefId,
                "@RefTypeID", detail.RefTypeId,
                "@Description", detail.Description,
                "@AccountNumber", detail.AccountNumber,
                "@CorrespondingAccountNumber", detail.CorrespondingAccountNumber,
                "@Quantity", detail.Quantity,
                "@Price", detail.Price,
                "@PriceExchange", detail.PriceExchange,
                "@AmountOc", detail.AmountOc,
                "@AmountExchange", detail.AmountExchange,
                "@BudgetSourceCode", detail.BudgetSourceCode,
                "@BudgetItemCode", detail.BudgetItemCode,
                "@VoucherTypeID", detail.VoucherTypeId,
                "@DepartmentID", detail.DepartmentId,
                "@ProjectID", detail.ProjectId,
                "@FixedAssetID", detail.FixedAssetId,
                "@InventoryItemID", detail.InventoryItemId,
                "@MergerFundID", detail.MergerFundId,
                "@AccountingObjectID", detail.AccountingObjectId,
                "@EmployeeID", detail.EmployeeId,
                "@CustomerID", detail.CustomerId,
                "@VendorID", detail.VendorId,
                "@AutoBusinessID", detail.AutoBusinessId,
            };
        }

        #endregion
    }
}
