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
    /// class SqlServerFixedAssetDecrementDetailDao
    /// </summary>
    public class SqlServerFixedAssetDecrementDetailDao : IFixedAssetDecrementDetailDao
    {
        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        public List<FADecrementDetailEntity> GetFADecresementDetailByFADecresement(long refId)
        {
            const string procedures = @"uspGet_FixedAssetDecrementDetail_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        public List<FADecrementDetailEntity> GetFADecrementByFAIncrement(long refId)
        {
            const string procedures = @"uspCheck_FADecrementVoucher";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="faDecreasementDetail">The cash detail.</param>
        /// <returns></returns>
        public int InsertFADecreasementDetail(FADecrementDetailEntity faDecreasementDetail)
        {
            const string sql = @"uspInsert_FixedAssetDecrementDetail";
            return Db.Insert(sql, true, Take(faDecreasementDetail));
        }

        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        public string DeleteFADecreasementDetailByFADecreasement(long refId)
        {
            const string procedures = @"uspDelete_FixedAssetDecrementDetail_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FADecrementDetailEntity> Make = reader =>
            new FADecrementDetailEntity
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
        /// <param name="faDecrementDetail">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(FADecrementDetailEntity faDecrementDetail)
        {
            return new object[]  
            {
                @"RefId", faDecrementDetail.RefId,
                @"RefDetailID", faDecrementDetail.RefDetailId,
                @"AccountNumber", faDecrementDetail.AccountNumber,
                @"CorrespondingAccountNumber", faDecrementDetail.CorrespondingAccountNumber,
                @"BudgetSourceCode", faDecrementDetail.BudgetSourceCode,
                @"BudgetCategoryCode", faDecrementDetail.BudgetCategoryCode,
                @"BudgetChapterCode", faDecrementDetail.BudgetChapterCode,
                @"BudgetItemCode", faDecrementDetail.BudgetItemCode,
                @"AutoBusinessID", faDecrementDetail.AutoBusinessId,
                @"FixedAssetID",faDecrementDetail.FixedAssetId,
                @"ProjectID",faDecrementDetail.ProjectId,
                @"VoucherTypeID",faDecrementDetail.VoucherTypeId,
                @"AmountOC",faDecrementDetail.AmountOC,
                @"AmountExchange", faDecrementDetail.AmountExchange,
                @"DepartmentId",faDecrementDetail.DepartmentId,
                @"Description",faDecrementDetail.Description,
                @"Quantity",faDecrementDetail.Quantity,
                @"UnitPriceOC",faDecrementDetail.UnitPriceOC,
                @"UnitPriceExchange",faDecrementDetail.UnitPriceExchange
            };
        }
    }
}
