/***********************************************************************
 * <copyright file="SqlServerDepositDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 21, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Deposit
{
    /// <summary>
    /// SqlServerDepositDetailDao
    /// </summary>
    public class SqlServerDepositDetailDao : IDepositDetailDao
    {
        /// <summary>
        /// Gets the deposit details by deposit.
        /// </summary>
        /// <param name="refId">The deposit identifier.</param>
        /// <returns></returns>
        public List<DepositDetailEntity> GetDepositDetailsByDeposit(long refId)
        {
            const string procedures = @"uspGet_DepositDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the deposit detail.
        /// </summary>
        /// <param name="depositDetail">The deposit detail.</param>
        /// <returns></returns>
        public int InsertDepositDetail(DepositDetailEntity depositDetail)
        {
            const string sql = @"uspInsert_DepositDetail";
            return Db.Insert(sql, true, Take(depositDetail));
        }

        /// <summary>
        /// Deletes the deposit detail by deposit identifier.
        /// </summary>
        /// <param name="refId">The deposit identifier.</param>
        /// <returns></returns>
        public string DeleteDepositDetailByDepositId(long refId)
        {
            const string procedures = @"uspDelete_DepositDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, DepositDetailEntity> Make = reader => new DepositDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            RefId = reader["RefID"].AsLong(),
            Description = reader["Description"].AsString(),
            AccountNumber = reader["AccountNumber"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            AmountOc = reader["AmountOC"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            Charge = reader["Charge"].AsDecimal(),
            ChargeExchange = reader["ChargeExchange"].AsDecimal(),
            VoucherTypeId = reader["VoucherTypeID"].AsIntForNull(),
            BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
            AccountingObjectId = reader["AccountingObjectID"].AsInt(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            DepartmentId = reader["DepartmentID"].AsIntForNull(),
            MergerFundId = reader["MergerFundID"].AsIntForNull(),
            ProjectId = reader["ProjectID"].AsIntForNull(),
            AutoBusinessId = reader["AutoBusinessID"].AsIntForNull()
        };

        /// <summary>
        /// Takes the specified deposit.
        /// </summary>
        /// <param name="depositDetail">The deposit.</param>
        /// <returns></returns>
        private object[] Take(DepositDetailEntity depositDetail)
        {
            return new object[]  
            {
                @"RefDetailID", depositDetail.RefDetailId,
                @"RefID", depositDetail.RefId,
                @"Description", depositDetail.Description,
                @"AccountNumber", depositDetail.AccountNumber,
                @"CorrespondingAccountNumber", depositDetail.CorrespondingAccountNumber,
                @"AmountOC", depositDetail.AmountOc,
                @"AmountExchange", depositDetail.AmountExchange,
                @"Charge", depositDetail.Charge,
                @"ChargeExchange", depositDetail.ChargeExchange,
                @"VoucherTypeID", depositDetail.VoucherTypeId,
                @"BudgetSourceCode", depositDetail.BudgetSourceCode,
                @"AccountingObjectID", depositDetail.AccountingObjectId,
                @"BudgetItemCode", depositDetail.BudgetItemCode,
                @"DepartmentID", depositDetail.DepartmentId,
                @"MergerFundID", depositDetail.MergerFundId,
                @"ProjectID", depositDetail.ProjectId,
                @"AutoBusinessID", depositDetail.AutoBusinessId

            };
        }
    }
}
