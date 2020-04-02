/***********************************************************************
 * <copyright file="SqlServerDepositDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataHelpers;
using System.Data;
using System;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Deposit
{
    /// <summary>
    /// SqlServerDepositDao
    /// </summary>
    public class SqlServerDepositDao : IDepositDao
    {
        /// <summary>
        /// Gets the deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DepositEntity GetDeposit(long refId)
        {
            const string procedures = @"uspGet_Deposit_ByID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<DepositEntity> GetDepositsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_Deposit_ByRefType";

            object[] parms = { "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<DepositEntity> GetDepositsByYearOfRefDate(int refTypeId, short yearOfRefDate)
        {
            const string procedures = @"uspGet_Deposit_ByRefType_By_PostedYear";
            object[] parms = { "@PostedYear", yearOfRefDate, "@RefTypeID", refTypeId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<DepositEntity> GetDepositsByRefNoAndRefDate(int refTypeId, string refNo, DateTime refDate,string currencyCode)
        {
            const string procedures = @"uspGet_Deposit_ByRefNoAndRefDate";
            object[] parms = { "@RefTypeID", refTypeId,"@RefNo",refNo,"@RefDate",refDate,"CurrencyCode",currencyCode};
            return Db.ReadList(procedures, true, Make, parms);
        }


        /// <summary>
        /// Gets the Deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public DepositEntity GetDepositByRefNo(string refNo)
        {
            const string procedures = @"uspGet_Deposit_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public DepositEntity GetDepositBySalary(DateTime dateMonth)
        {
            const string procedures = @"uspGet_Deposit_BySalaryDateMonth";
            object[] parms = { "@DateMonth", dateMonth.Month + "/" + dateMonth.Day + "/" + dateMonth.Year};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the deposits.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<DepositEntity> GetDeposits()
        {
            const string procedures = @"uspGet_All_Deposit";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the deposit by refdate and reftype.
        /// </summary>
        /// <param name="obDepositEntity">The ob deposit entity.</param>
        /// <returns></returns>
        public DepositEntity GetDepositByRefdateAndReftype(DepositEntity obDepositEntity) 
        {
            const string procedures = @"uspGet_Deposit_ForSalary";
            object[] parms = { "@RefTypeID", obDepositEntity.RefTypeId, "@PostedDate", obDepositEntity.PostedDate, "@RefNo", obDepositEntity.RefNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int InsertDeposit(DepositEntity deposit)
        {
            const string sql = @"uspInsert_Deposit";
            return Db.Insert(sql, true, Take(deposit));
        }

        /// <summary>
        /// Updates the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string UpdateDeposit(DepositEntity deposit)
        {
            const string sql = @"uspUpdate_Deposit";
            return Db.Update(sql, true, Take(deposit));
        }


        public string DeleteDeposit(DepositEntity deposit)
        {
            const string sql = @"uspDelete_Deposit";

            object[] parms = { "@RefID", deposit.RefId };
            return Db.Delete(sql, true, parms);
        }


        public DepositEntity GetDepositsBySalary(int refTypeId, string postedDate, string refNo, string currencyCode)
        {
            const string procedures = @"uspGet_Deposit_BySalaryDateMonthAndRefNoAndCurrencyCode";
            object[] parms = { "@PostedDate", postedDate, "@RefTypeID", refTypeId, "@RefNo", refNo, "@CurrencyCode", currencyCode };
            return Db.Read(procedures, true, Make, parms);
        }

        public string DeleteEmployeePayroll(string refNo, string postedDate)
        {
            const string sql = @"uspDelete_EmployeePayroll";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Delete(sql, true, parms);
        }




        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, DepositEntity> Make = reader => new DepositEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                AccountingObjectType = reader["AccountingObjectType"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsIntForNull(),
                Trader = reader["Trader"].AsString(),
                CustomerId = reader["CustomerID"].AsIntForNull(),
                VendorId = reader["VendorID"].AsIntForNull(),
                EmployeeId = reader["EmployeeID"].AsIntForNull(),
                BankAccountCode = reader["BankAccountCode"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                TotalAmountOc = reader["TotalAmountOC"].AsDecimal(),
                TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                BankId = reader["BankId"].AsIntForNull(),
                IsIncludeCharge = reader["IsIncludeCharge"].AsBool()
            };

        /// <summary>
        /// Takes the specified receipt voucher.
        /// </summary>
        /// <param name="deposit">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(DepositEntity deposit)
        {
            return new object[]  
            {
                @"RefID", deposit.RefId,
                @"RefTypeID", deposit.RefTypeId,
                @"RefNo", deposit.RefNo,
                @"RefDate", deposit.RefDate,
                @"PostedDate", deposit.PostedDate,
                @"AccountingObjectType", deposit.AccountingObjectType,
                @"AccountingObjectID", deposit.AccountingObjectId,
                @"Trader", deposit.Trader,
                @"CustomerID", deposit.CustomerId,
                @"VendorID", deposit.VendorId,
                @"EmployeeID", deposit.EmployeeId,
                @"BankAccountCode", deposit.BankAccountCode,
                @"CurrencyCode", deposit.CurrencyCode,
                @"ExchangeRate", deposit.ExchangeRate,
                @"TotalAmountOC", deposit.TotalAmountOc,
                @"TotalAmountExchange", deposit.TotalAmountExchange,
                @"JournalMemo", deposit.JournalMemo,
                @"BankID", deposit.BankId,
                @"IsIncludeCharge", deposit.IsIncludeCharge
            };
        }

        public string UpdateEmployeePayroll(string orgrefNo, string replaceRefNo, string monthDate)
        {
            //Dung chung ham Store Cash
            const string procedures = @"uspUpdate_CashSalaryReNo";
            object[] parms = { "@RefNo", orgrefNo, "@ReplaceRefNo", replaceRefNo, "@MonthDate", monthDate };
            return Db.Update(procedures, true, parms);
        }
    }
}