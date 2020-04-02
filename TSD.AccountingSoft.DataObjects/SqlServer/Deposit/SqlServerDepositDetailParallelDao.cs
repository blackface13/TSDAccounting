using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Deposit
{
    public class SqlServerDepositDetailParallelDao : IDepositDetailParallelDao
    {
        public string DeleteDepositDetailParallelById(long refId)
        {
            const string procedures = @"uspDelete_DepositDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<DepositDetailParallelEntity> GetDepositDetailParallelByRefId(long refId)
        {
            const string procedures = @"uspGet_DepositDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InsertDepositDetailParallel(DepositDetailParallelEntity depositDetail)
        {
            const string procedures = @"uspInsert_DepositDetailParallel";
            return Db.Insert(procedures, true, Take(depositDetail));
        }

        public string UpdateDepositDetailParallel(DepositDetailParallelEntity depositDetail)
        {
            const string procedures = @"uspUpdate_DepositDetailParallel";
            return Db.Update(procedures, true, Take(depositDetail));
        }

        private static readonly Func<IDataReader, DepositDetailParallelEntity> Make = reader =>
        {
            var depositDetailParallel = new DepositDetailParallelEntity();
            depositDetailParallel.RefDetailId = reader["RefDetailId"].AsLong();
            depositDetailParallel.RefId = reader["RefId"].AsLong();
            depositDetailParallel.Description = reader["Description"].AsString();
            depositDetailParallel.AccountNumber = reader["AccountNumber"].AsString();
            depositDetailParallel.CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString();
            depositDetailParallel.AmountExchange = reader["AmountExchange"].AsDecimal();
            depositDetailParallel.AmountOc = reader["AmountOC"].AsDecimal();
            depositDetailParallel.BudgetSourceCode = reader["BudgetSourceCode"].AsString();
            depositDetailParallel.BudgetItemCode = reader["BudgetItemCode"].AsString();
            depositDetailParallel.AccountingObjectId = reader["AccountingObjectID"].AsIntForNull();
            depositDetailParallel.ProjectId = reader["ProjectID"].AsIntForNull();
            depositDetailParallel.DepartmentId = reader["DepartmentId"].AsIntForNull();
            depositDetailParallel.MergerFundId = reader["MergerFundId"].AsIntForNull();
            depositDetailParallel.VoucherTypeId = reader["VoucherTypeId"].AsIntForNull();
            depositDetailParallel.FixedAssetId = reader["FixedAssetId"].AsIntForNull();
            depositDetailParallel.InventoryItemId = reader["InventoryItemId"].AsIntForNull();
            depositDetailParallel.EmployeeId = reader["EmployeeId"].AsIntForNull();
            depositDetailParallel.CustomerId = reader["CustomerId"].AsIntForNull();
            depositDetailParallel.VendorId = reader["VendorId"].AsIntForNull();

            return depositDetailParallel;
        };

        private static object[] Take(DepositDetailParallelEntity depositDetailParallel)
        {
            return new object[]
            {
                "@RefDetailID", depositDetailParallel.RefDetailId,
                "@RefID", depositDetailParallel.RefId,
                "@Description", depositDetailParallel.Description,
                "@AccountNumber", depositDetailParallel.AccountNumber,
                "@CorrespondingAccountNumber", depositDetailParallel.CorrespondingAccountNumber,
                "@AmountOc", depositDetailParallel.AmountOc,
                "@AmountExchange", depositDetailParallel.AmountExchange,
                "@VoucherTypeId", depositDetailParallel.VoucherTypeId,
                "@BudgetSourceCode", depositDetailParallel.BudgetSourceCode,
                "@AccountingObjectId", depositDetailParallel.AccountingObjectId,
                "@BudgetItemCode", depositDetailParallel.BudgetItemCode,
                "@DepartmentId", depositDetailParallel.DepartmentId,
                "@MergerFundId", depositDetailParallel.MergerFundId,
                "@ProjectId", depositDetailParallel.ProjectId,
                "@FixedAssetId", depositDetailParallel.FixedAssetId,
                "@InventoryItemId", depositDetailParallel.InventoryItemId,
                "@EmployeeId", depositDetailParallel.EmployeeId,
                "@CustomerId", depositDetailParallel.CustomerId,
                "@VendorId", depositDetailParallel.VendorId,
            };
        }
    }
}
