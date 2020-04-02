using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    public class SqlServerFixedAssetIncrementDetailDao : IFixedAssetIncrementDetailDao
    {
        public List<FAIncrementDetailEntity> GetFAIncrementDetailByFAIncrement(long refId)
        {
            const string procedures = @"uspGet_FixedAssetIncrementDetail_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }



        public int InsertFAIncrementDetail(FAIncrementDetailEntity faIncrementDetail)
        {
            const string sql = @"uspInsert_FixedAssetIncrementDetail";
            return Db.Insert(sql, true, Take(faIncrementDetail));
        }

        public string DeleteFAIncrementDetailByFAIncrement(long refId)
        {
            const string procedures = @"uspDelete_FixedAssetIncrementDetail_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAIncrementDetailEntity> Make = reader =>
            new FAIncrementDetailEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefDetailId = reader["RefDetailID"].AsLong(),
                FixedAssetId = reader["FixedAssetID"].AsInt(),
                AccountNumber = reader["AccountNumber"].AsString(),
                CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                Description = reader["Description"].AsString(),
                Quantity = reader["Quantity"].AsInt(),
                UnitPriceExchange = reader["UnitPriceExchange"].AsDecimal(),
                UnitPriceOC = reader["UnitPriceOC"].AsDecimal(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                AmountOC = reader["AmountOC"].AsDecimal(),
                VoucherTypeId = reader["VoucherTypeID"].AsString().AsIntForNull(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                AutoBusinessId = reader["AutoBusinessID"].AsString().AsIntForNull(),
                ProjectId = reader["ProjectID"].AsString().AsIntForNull(),
                DepartmentId = reader["DepartmentID"].AsString().AsIntForNull()
            };

        /// <summary>
        /// Takes the specified receipt voucher.
        /// </summary>
        /// <param name="faIncrementDetail">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(FAIncrementDetailEntity faIncrementDetail)
        {
            return new object[]  
            {
                @"RefId", faIncrementDetail.RefId,
                @"RefDetailID", faIncrementDetail.RefDetailId,
                @"AccountNumber", faIncrementDetail.AccountNumber,
                @"CorrespondingAccountNumber", faIncrementDetail.CorrespondingAccountNumber,
                @"BudgetSourceCode", faIncrementDetail.BudgetSourceCode,
                @"BudgetCategoryCode", faIncrementDetail.BudgetCategoryCode,
                @"BudgetChapterCode", faIncrementDetail.BudgetChapterCode,
                @"BudgetItemCode", faIncrementDetail.BudgetItemCode,
                @"AutoBusinessID", faIncrementDetail.AutoBusinessId,
                @"FixedAssetID",faIncrementDetail.FixedAssetId,
                @"ProjectID",faIncrementDetail.ProjectId,
                @"VoucherTypeID",faIncrementDetail.VoucherTypeId,
                @"AmountOC",faIncrementDetail.AmountOC,
                @"AmountExchange", faIncrementDetail.AmountExchange,
                @"DepartmentId",faIncrementDetail.DepartmentId,
                @"Description",faIncrementDetail.Description,
                @"Quantity",faIncrementDetail.Quantity,
                @"UnitPriceOC",faIncrementDetail.UnitPriceOC,
                @"UnitPriceExchange",faIncrementDetail.UnitPriceExchange
            };
        }
    }
}
