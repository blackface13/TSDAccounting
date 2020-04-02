/***********************************************************************
 * <copyright file="SqlserverStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using TSD.AccountingSoft.BusinessEntities.Salary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Salary
{
    public class SqlServerSalaryVoucherDao:ISalaryVoucherDao
    {
        public List<SalaryVoucherEntity> GetSalaryVoucherMonthDate(string monthDate)
        {
            const string procedures = @"uspGet_SalaryVoucher_ByMonthDate";
            object[] parms = { "@PostedDate", Convert.ToDateTime(monthDate) };
            return Db.ReadList(procedures, true, Make2, parms);
        }

        public string Update_EmployeePayroll_Voucher(string refNo, long? cashId, long? depositID)
        {
            const string procedures = @"uspUpdate_EmployeePayroll_Voucher";
            object[] parms = { "@RefNo", refNo, "@CashID", cashId, "@DepositID", depositID };
            return Db.Update(procedures, true, parms);
        }

        public long GetEmployeePayroll_VoucherID(string refNo, int RefTypeId)
        {
            const string procedures = @"uspGet_EmployeePayroll_VoucherID";
            object[] parms = { "@RefNo", refNo, "@RefTypeID", RefTypeId };
            return Db.Read(procedures, true, MakeId, parms);
        }

        public string CanclCalc(string monthDate, string refNo)
        {
            const string procedures = @"uspDelete_EmployeePayroll";
            object[] parms = { "@PostedDate", Convert.ToDateTime(monthDate), "@RefNo", refNo };
            return Db.Delete(procedures,true,parms);
        }

        private static readonly Func<IDataReader, SalaryVoucherEntity> Make = reader =>new SalaryVoucherEntity
        {
            RefTypeId = reader["RefTypeID"].AsInt(),
            RefNo = reader["RefNo"].AsString(),
            PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
        };

        public List<SalaryVoucherEntity>SalaryVoucherGetByParameter(int employeeId, string postedDate)
        {
            const string procedures = @"uspGet_SalaryVoucher_GetByParameter";
            object[] parms = { "@EmployeeID", employeeId, "@PostedDate", postedDate };
            return Db.ReadList(procedures, true, Make2, parms);
        }
        
        private static readonly Func<IDataReader, SalaryVoucherEntity> Make2 = reader => new SalaryVoucherEntity
        {
            RefTypeId = reader["RefTypeID"].AsInt(),
            RefNo = reader["RefNo"].AsString(),
            PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal()
        };

        private static readonly Func<IDataReader, long> MakeId = reader => reader["RefID"].AsLong();

        private object[] Take(SalaryVoucherEntity salaryVoucher)
        {
            return new object[]  
            {
                @"PostedDate", salaryVoucher.PostedDate,
                @"RefTypeID", salaryVoucher.RefTypeId,
                @"RefNo", salaryVoucher.RefNo
            };
        }



        public List<SalaryVoucherEntity> GetSalaryVoucherMonthDateIsPostedDate(string monthDate)
        {
            const string procedures = @"uspGet_SalaryVoucher_ByMonthDateIsPostedDate";
            object[] parms = { "@PostedDate", Convert.ToDateTime(monthDate) };
            return Db.ReadList(procedures, true, Make2, parms);
        }


        public List<SalaryVoucherEntity> GetSalaryVoucherIsRetail(string monthDate, bool isRetail, int refTypeId)
        {
            const string procedures = @"uspGet_SalaryVoucher_ByMonthDateIsRetail";
            object[] parms = { "@PostedDate", DateTime.ParseExact(monthDate, "MM/dd/yyyy", CultureInfo.InvariantCulture), "@IsRetail", isRetail, "@RefTypeID", refTypeId };
            //object[] parms = { "@PostedDate", Convert.ToDateTime(monthDate), "@IsRetail", isRetail, "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make2, parms);
        }



    }
}
