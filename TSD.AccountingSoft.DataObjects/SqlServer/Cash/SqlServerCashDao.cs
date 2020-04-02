/***********************************************************************
 * <copyright file="SqlServerCashDao.cs" company="BUCA JSC">
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
    /// SqlServerCashDao class
    /// </summary>
    public  class SqlServerCashDao: ICashDao
    {

        /// <summary>
        /// Gets the cash.
        /// </summary>
        /// <param name="cashId">The cash identifier.</param>
        /// <returns></returns>
        public CashEntity GetCash(long cashId)
        {
            const string procedures = @"uspGet_Cash_ByRefID";
            object[] parms = { "@RefID", cashId };
            return Db.Read(procedures, true, Make, parms);
        }


        public List<CashEntity> GetCashesByRefTypeId(int refTypeId,int year)
        {
            const string procedures = @"uspGet_Cash_ByRefTypeID";
            object[] parms = { "@RefTypeID", refTypeId};
            return Db.ReadList(procedures, true, Make,parms);
        }


        public List<CashEntity> GetCashByRefNo(string refNo)
        {
            const string procedures = @"uspGet_Cash_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the cashs.
        /// </summary>
        /// <returns></returns>
        public List<CashEntity> GetCashes()
        {
            const string procedures = @"uspGet_All_Cash";            
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the cash.
        /// </summary>
        /// <param name="cash">The cash.</param>
        /// <returns></returns>
        public int InsertCash(CashEntity cash)
        {
            const string procedures = @"uspInsert_Cash";            
            return Db.Insert(procedures, true,Take(cash));
        }

        /// <summary>
        /// Updates the cash entity.
        /// </summary>
        /// <param name="cash">The cash.</param>
        /// <returns></returns>
        public string UpdateCash(CashEntity cash)
        {
            const string procedures = @"uspUpdate_Cash";
            return Db.Update(procedures, true, Take(cash));
        }

        /// <summary>
        /// Deletes the cash entity.
        /// </summary>
        /// <param name="cash">The cash.</param>
        /// <returns></returns>
        public string DeleteCash(CashEntity cash)
        {
            const string procedures = @"uspDelete_Cash";
            object[] parms = { "@RefID", cash.RefId };
            return Db.Delete(procedures, true, parms);
        }

        public  string UpdateEmployeePayroll(string orgrefNo,string replaceRefNo, string monthDate)
        {
            const string procedures = @"uspUpdate_CashSalaryReNo";
            object[] parms = { "@RefNo", orgrefNo, "@ReplaceRefNo", replaceRefNo, "@MonthDate", monthDate };
            return Db.Update(procedures, true, parms);
        }






        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CashEntity> Make = reader => new CashEntity
           {
               RefId = reader["RefID"].AsLong(),
               RefTypeId = reader["RefTypeID"].AsInt(),
               RefNo = reader["RefNo"].AsString(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               AccountingObjectId = reader["AccountingObjectID"].AsString().AsIntForNull(),
               CustomerId = reader["CustomerID"].AsString().AsIntForNull(),
               VendorId = reader["VendorID"].AsString().AsIntForNull(),
               EmployeeId = reader["EmployeeID"].AsString().AsIntForNull(),
               Trader = reader["Trader"].AsString(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               AccountNumber = reader["AccountNumber"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
               JournalMemo = reader["JournalMemo"].AsString(),
               DocumentInclude = reader["DocumentInclude"].AsString(),
               AccountingObjectType = reader["AccountingObjectType"].AsInt(),
               BankId = reader["BankID"].AsIntForNull(),
               IsIncludeCharge = reader["IsIncludeCharge"].AsBool()
           };

        /// <summary>
        /// Takes the specified take.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        private object[] Take(CashEntity take)
        {
            return new object[]
             {
                 "@RefID",take.RefId,
                 "@RefTypeID",take.RefTypeId,
                 "@RefNo",take.RefNo,
                 "@RefDate",take.RefDate,
                 "@PostedDate",take.PostedDate,
                 "@AccountingObjectID",take.AccountingObjectId,
                 "@CustomerID",take.CustomerId,
                 "@VendorID",take.VendorId,
                 "@EmployeeID",take.EmployeeId,
                 "@Trader",take.Trader,
                 "@CurrencyCode",take.CurrencyCode,
                 "@AccountNumber",take.AccountNumber,
                 "@TotalAmount",take.TotalAmount,
                 "@ExchangeRate",take.ExchangeRate,
                 "@TotalAmountExchange",take.TotalAmountExchange,
                 "@JournalMemo",take.JournalMemo,
                 "@DocumentInclude",take.DocumentInclude,
                 "@AccountingObjectType",take.AccountingObjectType,
                 "@BankID",take.BankId,
                 "@IsIncludeCharge", take.IsIncludeCharge
             };
        }


        public CashEntity GetCashByRefdateAndReftype(CashEntity obCashEntity) 
        {
            const string procedures = @"uspGet_Cash_ForSalary";
            object[] parms = { "@RefTypeID", obCashEntity.RefTypeId, "@PostedDate", obCashEntity.PostedDate,"@RefNo" , obCashEntity.RefNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public CashEntity GetCashForSalaryByRefNo(string refNo)  
        {
            const string procedures = @"uspGet_Cash_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }


        public List<CashEntity> GetCashesByRefNoAndRefDate(int refTypeId, DateTime refDate, string refNo, string currencyCode)
        {
            const string procedures = @"uspGet_Cash_ByRefNo_RefDate";
            object[] parms = { "@RefTypeID", refTypeId, "@RefDate", refDate, "RefNo", refNo,"@CurrencyCode",currencyCode};
            return Db.ReadList(procedures, true, Make, parms);
        }


        public CashEntity GetCashForSalaryByDateMonth(DateTime dateMonth)
        {
            const string procedures = @"uspGet_Cash_BySalaryDateMonth";
            object[] parms = { "@DateMonth", dateMonth.Month + "/" + dateMonth.Day + "/" + dateMonth.Year};
            return Db.Read(procedures, true, Make, parms);
        }


        public CashEntity GetCashBySalary(int refTypeId, string postedDate, string refNo, string currencyCode)
        {
            const string procedures = @"uspGet_Cash_BySalaryDateMonthAndRefNoAndCurrencyCode";
            object[] parms = { "@PostedDate", postedDate, "@RefTypeID", refTypeId, "@RefNo", refNo, "@CurrencyCode", currencyCode };
            return Db.Read(procedures, true, Make, parms);
        }


        public string DeleteEmployeePayroll(string refNo, string postedDate)
        {
            const string sql = @"uspDelete_EmployeePayroll";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Delete(sql, true, parms);
        }
    }
}
