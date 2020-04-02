/***********************************************************************
 * <copyright file="SqlServerFixedAssetArmortizationDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    /// <summary>
    /// SqlServerFixedAssetArmortizationDetailDao
    /// </summary>
    public class SqlServerFixedAssetArmortizationDetailDao : IFixedAssetArmortizationDetailDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<FAArmortizationDetailEntity> GetFAArmortizationDetailsByFAArmortization(long refId)
        {
            const string procedures = @"uspGet_FixedAssetArmortizationDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa decrement by fa increment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<FAArmortizationDetailEntity> GetFAArmortizationByFAIncrement(long refId)
        {
            const string procedures = @"uspCheck_FArmortizationVoucher";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        public List<FAArmortizationDetailEntity> GetAutoFAArmortizationDetailsByCurrencyCode(string currencyCode, int yearOfDeprecation)
        {
            const string procedures = @"uspGet_Auto_FixedAssetArmortizationDetail_ByCurrenyCode";

            object[] parms = { "@CurrencyCode", currencyCode, "YearOfDepreciation", yearOfDeprecation };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="fAArmortizationDetail">The f a armortization detail.</param>
        /// <returns></returns>
        public int InsertFAArmortizationDetail(FAArmortizationDetailEntity fAArmortizationDetail)
        {
            const string sql = @"uspInsert_FixedAssetArmortizationDetail";
            return Db.Insert(sql, true, Take(fAArmortizationDetail));
        }

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteFAArmortizationDetailByFAArmortizationId(long refId)
        {
            const string procedures = @"uspDelete_FixedAssetArmortizationDetail_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAArmortizationDetailEntity> Make = reader =>
        {
            var armortizationDetail = new FAArmortizationDetailEntity();
            armortizationDetail.RefDetailId = reader["RefDetailID"].AsLong();
            armortizationDetail.RefId = reader["RefID"].AsLong();
            armortizationDetail.FixedAssetId = reader["FixedAssetID"].AsInt();
            armortizationDetail.AccountNumber = reader["AccountNumber"].AsString();
            armortizationDetail.CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString();
            armortizationDetail.Description = reader["Description"].AsString();
            armortizationDetail.Quantity = reader["Quantity"].AsInt();
            armortizationDetail.CurrencyCode = reader["CurrencyCode"].AsString();
            armortizationDetail.ExchangeRate = reader["ExchangeRate"].AsDouble();
            armortizationDetail.AmountOC = reader["AmountOC"].AsDecimal();
            armortizationDetail.AmountExchange = reader["AmountExchange"].AsDecimal();
            armortizationDetail.VoucherTypeId = reader["VoucherTypeID"].AsString().AsIntForNull();
            armortizationDetail.BudgetSourceCode = reader["BudgetSourceCode"].AsString();
            armortizationDetail.BudgetItemCode = reader["BudgetItemCode"].AsString();
            armortizationDetail.BudgetChapterCode = reader["BudgetChapterCode"].AsString();
            armortizationDetail.BudgetCategoryCode = reader["BudgetCategoryCode"].AsString();
            armortizationDetail.DepartmentId = reader["DepartmentID"].AsString().AsIntForNull();
            armortizationDetail.ProjectId = reader["ProjectID"].AsString().AsIntForNull();
            armortizationDetail.AutoBusinessId = reader["AutoBusinessId"].AsString().AsIntForNull();
            return armortizationDetail;
        };

        /// <summary>
        /// Takes the specified f a armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        private static object[] Take(FAArmortizationDetailEntity fAArmortization)
        {
            return new object[]
            {
                @"RefDetailID", fAArmortization.RefDetailId,
                @"RefID", fAArmortization.RefId,
                @"FixedAssetID", fAArmortization.FixedAssetId,
                @"AccountNumber", fAArmortization.AccountNumber,
                @"CorrespondingAccountNumber", fAArmortization.CorrespondingAccountNumber,
                @"Description", fAArmortization.Description,
                @"Quantity", fAArmortization.Quantity,
                @"CurrencyCode", fAArmortization.CurrencyCode,
                @"ExchangeRate", fAArmortization.ExchangeRate,
                @"AmountOC", fAArmortization.AmountOC,
                @"AmountExchange", fAArmortization.AmountExchange,
                @"VoucherTypeID", fAArmortization.VoucherTypeId,
                @"BudgetSourceCode", fAArmortization.BudgetSourceCode,
                @"BudgetItemCode", fAArmortization.BudgetItemCode,
                @"BudgetChapterCode", fAArmortization.BudgetChapterCode,
                @"BudgetCategoryCode", fAArmortization.BudgetCategoryCode,
                @"DepartmentID", fAArmortization.DepartmentId,
                @"ProjectID", fAArmortization.ProjectId,
                @"AutoBusinessId", fAArmortization.AutoBusinessId
            };
        }
    }
}
