/***********************************************************************
 * <copyright file="SqlServerGeneralDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.General
{
    /// <summary>
    /// SqlServerAccountTranferVourcherDao
    /// </summary>
    public class SqlServerAccountTranferVourcherDao:IAccountTranferVourcherDao
    {
        private static readonly Func<IDataReader, AccountTranferVourcherEntity> Make = reader => new AccountTranferVourcherEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            RefId = reader["RefId"].AsLong(),
            AccountNumber = reader["AccountNumber"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            Description = reader["Description"].AsString(),
            AmountOc = reader["AmountOC"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            VoucherTypeId = reader["VoucherTypeID"].AsIntForNull()
        };

        private object[] Take(AccountTranferVourcherEntity info)
        {
            return new object[]
             {
                "@RefDetailID",info.RefDetailId,
                "@RefID",info.RefId,
                "@AccountNumber",info.AccountNumber,
                "@CorrespondingAccountNumber",info.CorrespondingAccountNumber,
                "@AmountOC",info.AmountOc,
                "@AmountExchange",info.AmountExchange,
                "@CurrencyCode",info.CurrencyCode,
                "@Description",info.Description,
                "@ExchangeRate",info.ExchangeRate,
                "@BudgetSourceCode",info.BudgetSourceCode,
                "@PostedDate",info.PostedDate,
                "@VoucherTypeID",info.VoucherTypeId
             };
        }


        public IList<AccountTranferVourcherEntity> GetAccountTranferVourchersByRefId(long refId)
        {
            const string procedures = @"uspGet_AccountTranferVourcherVouchers_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InserAccountTranferVourcher(AccountTranferVourcherEntity accountTranferVourcher)
        {
            const string procedures = @"uspInsert_AccountTranferVourcher";
            return Db.Insert(procedures, true, Take(accountTranferVourcher));
        }

        public IList<AccountTranferVourcherEntity> GetAccountTranferVourchersByPostedDateAndCurrencyCode(DateTime postedDate, string currencyCode)
        {
            const string procedures = @"uspGet_AccountTranferVourcher_ByPostedDateAndCurrencyCode";
            object[] parms = { "@PostedDate", postedDate, "@CurrencyCode", currencyCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Deletes the account tranfer detail vourchers.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteAccountTranferDetailVourchers(long refId)
        {
            const string procedures = @"uspDelete_AccountTranferVourcher_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }


        public IList<AccountTranferVourcherEntity> GetAccountTranferVourchersByEdit(DateTime postedDate, string currencyCode, int refTypeId)
        {

            const string procedures = @"uspGet_AccountTranferVourcher_ByEdit";
            object[] parms = { "@PostedDate", postedDate, "@CurrencyCode", currencyCode, @"RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }
    }
}
