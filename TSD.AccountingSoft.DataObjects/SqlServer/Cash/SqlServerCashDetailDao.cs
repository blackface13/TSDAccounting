/***********************************************************************
 * <copyright file="SqlCashDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Cash
{
    /// <summary>
    /// SqlCashDetail class
    /// </summary>
    public class SqlServerCashDetailDao : ICashDetailDao
    {

        public List<CashDetailEntity> GetCashDetailsByCash(long cashId)
        {
            const string procedures = @"uspGet_CashDetail_ByRefID";
            object[] parms = { "@RefID", cashId };
            return Db.ReadList(procedures, true, Make, parms);

        }

        public int InsertCashDetail(CashDetailEntity cashDetail)
        {
            const string procedures = @"uspInsert_CashDetail";
            return Db.Insert(procedures, true, Take(cashDetail));
        }
        
        public string DeleteCashDetailByCash(long cashId)
        {
            const string procedures = @"uspDelete_CashDetail_ByRefID";
            object[] parms = { "@RefId", cashId };
            return Db.Delete(procedures, true, parms);
        }

        public List<CashParalellDetailEntity> GetReceiptDetailsParalellbyCash(long cashId)
        {
            const string procedures = @"uspGet_CashParalellDetail_ByRefID";
            object[] parms = { "@RefID", cashId };
            return Db.ReadList(procedures, true, MakeParalell, parms);
        }

        public int InsertReceiptDetailParalell(CashParalellDetailEntity cashParalellDetailEntity)
        {
            const string procedures = @"uspInsert_CashParalellDetail";
            return Db.Insert(procedures, true, TakeParalell(cashParalellDetailEntity));
        }

        public string DeleteReceipDetailParalellByCash(long cashId)
        {
            const string procedures = @"uspDelete_CashParalellDetail_ByRefID";
            object[] parms = { "@RefId", cashId };
            return Db.Delete(procedures, true, parms);
        }

        #region Make and Take

        private static readonly Func<IDataReader, CashDetailEntity> Make = reader => new CashDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            AccountNumber = reader["AccountNumber"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            Description = reader["Description"].AsString(),
            AmountOc = reader["AmountOC"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            Charge = reader["Charge"].AsDecimal(),
            ChargeExchange = reader["ChargeExchange"].AsDecimal(),
            VoucherTypeId = reader["VoucherTypeID"].AsIntForNull(),
            BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            AccountingObjectId = reader["AccountingObjectID"].AsIntForNull(),
            MergerFundId = reader["MergerFundID"].AsIntForNull(),
            ProjectId = reader["ProjectID"].AsIntForNull(),
            RefId = reader["RefID"].AsLong(),
            AutoBusinessId = reader["AutoBusinessID"].AsIntForNull()
        };

        private object[] Take(CashDetailEntity info)
        {
            return new object[]
             {
                 "@RefDetailID",info.RefDetailId,
                 "@AccountNumber",info.AccountNumber,
                 "@CorrespondingAccountNumber",info.CorrespondingAccountNumber,
                 "@Description",info.Description,
                 "@AmountOC",info.AmountOc,
                 "@AmountExchange",info.AmountExchange,
                 "@Charge", info.Charge,
                 "@ChargeExchange", info.ChargeExchange,
                 "@VoucherTypeID",info.VoucherTypeId,
                 "@BudgetSourceCode",info.BudgetSourceCode,
                 "@BudgetItemCode",info.BudgetItemCode,
                 "@AccountingObjectID",info.AccountingObjectId,
                 "@MergerFundID",info.MergerFundId,
                 "@ProjectID",info.ProjectId,
                 "@RefID",info.RefId,
                 "@AutoBusinessID",info.AutoBusinessId
             };
        }

        private static readonly Func<IDataReader, CashParalellDetailEntity> MakeParalell = reader => new CashParalellDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            AccountNumber = reader["AccountNumber"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            Description = reader["Description"].AsString(),
            AmountOc = reader["AmountOC"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            VoucherTypeId = reader["VoucherTypeID"].AsIntForNull(),
            BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            AccountingObjectId = reader["AccountingObjectID"].AsIntForNull(),
            MergerFundId = reader["MergerFundID"].AsIntForNull(),
            ProjectId = reader["ProjectID"].AsIntForNull(),
            RefId = reader["RefID"].AsLong(),
            AutoBusinessId = reader["AutoBusinessID"].AsIntForNull()
        };

        private object[] TakeParalell(CashParalellDetailEntity info)
        {
            return new object[]
             {
                 "@RefDetailID",info.RefDetailId,
                 "@AccountNumber",info.AccountNumber,
                 "@CorrespondingAccountNumber",info.CorrespondingAccountNumber,
                 "@Description",info.Description,
                 "@AmountOC",info.AmountOc,
                 "@AmountExchange",info.AmountExchange,
                 "@VoucherTypeID",info.VoucherTypeId,
                 "@BudgetSourceCode",info.BudgetSourceCode,
                 "@BudgetItemCode",info.BudgetItemCode,
                 "@AccountingObjectID",info.AccountingObjectId,
                 "@MergerFundID",info.MergerFundId,
                 "@ProjectID",info.ProjectId,
                 "@RefID",info.RefId,
                 "@AutoBusinessID",info.AutoBusinessId
             };
        }

        #endregion
    }
}
