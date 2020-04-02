using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Salary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Salary
{
    public class SqlServerSalaryDao : ISalaryDao
    {
        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        //public SalaryEntity GetSalary(long refId)
        //{
        //    const string procedures = @"uspGet_Salary_ByID";
        //    object[] parms = { "@SalaryID", refId };
        //    return Db.Read(procedures, true, Make, parms);
        //}

        /// <summary>
        /// Inserts the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
        public int CalSalary(SalaryEntity salary)
        {
            const string sql = @"uspInsert_CalSalary_EmployeePayroll";
            return Db.Insert(sql, true, Take(salary));
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, SalaryEntity> MakeForMonth = reader => 
            new SalaryEntity
            {
                TotalAmountOc = reader["Amount"].AsDecimal(), 
                JournalMemo = reader["JournalMemo"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                RefDate = reader["RefDate"].AsDateTime(),
            };
 
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, SalaryEntity> Make = reader =>
            new SalaryEntity
            {
                EmployeePayrollId = reader["EmployeePayrollID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                TotalAmountOc = reader["TotalAmountOC"].AsDecimal(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                EmployeeId = reader["EmployeeID"].AsInt(),
                //  EmployeePayItemId = reader["EmployeePayItemID"].AsInt(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                TotalAmountExchange = reader["TotalAmountExchange"].AsInt()
            };

        /// <summary>
        /// Takes the specified receipt voucher.
        /// </summary>
        /// <param name="salary">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(SalaryEntity salary)
        {
            return new object[]  
            {
                @"EmployeePayrollID", salary.EmployeePayrollId,
                @"RefTypeID", salary.RefTypeId,
                @"RefNo", salary.RefNo,
                @"RefDate", salary.RefDate,
                @"PostedDate", salary.PostedDate,
                @"TotalAmountOC", salary.TotalAmountOc,
                @"JournalMemo", salary.JournalMemo,
                @"CurrencyCode", salary.CurrencyCode,
                @"EmployeeID", salary.EmployeeId,
                @"EmployeePayItemID", salary.EmployeePayItemId,
                @"ExchangeRate", salary.ExchangeRate,
                @"TotalAmountExchange", salary.TotalAmountExchange

            };
        }

        /// <summary>
        /// Gets the salary by reference date and employ identifier.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="employId">The employ identifier.</param>
        /// <returns>
        /// List{SalaryEntity}.
        /// </returns>
        public List<SalaryEntity> GetSalaryByRefDateAndEmployId(DateTime refDate, int employId)
        {
            const string procedures = @"uspGet_EmployeePayroll_ByID";

            object[] parms = { "@RefDate", refDate,
                                "@EmployeeID", employId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the salary by reference date and employ identifier.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="employId">The employ identifier.</param>
        /// <returns>
        /// List{SalaryEntity}.
        /// </returns>
        public List<SalaryEntity> GetSalaryPostedByRefDateAndEmployId(DateTime refDate, int employId) 
        {
            const string procedures = @"uspGet_EmployeePayroll_Posted_ByRefDate";

            object[] parms = { "@RefDate", refDate,
                                "@EmployeeID", employId};
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <returns></returns>
        public List<SalaryEntity> GetSalaryByMoth() 
        {
            const string procedures = @"uspGet_EmployeePayroll_ByMoth";
            return Db.ReadList(procedures, true, MakeForMonth);
        }

       

        /// <summary>
        /// Inserts the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
        public int DeleteCalSalary(SalaryEntity salary)
        {
            const string sql = @"uspDelete_CalSalary_EmployeePayroll";
            return Db.Insert(sql, true, Take(salary));
        }




        public List<SalaryEntity> GetSalaryByRefNo(string refNo) 
        {
            const string procedures = @"uspGet_EmployeePayroll_ByRefNo";

            object[] parms = { "@RefNo", refNo }; 
            return Db.ReadList(procedures, true, Make, parms);
        }


        public List<SalaryEntity> GetSalaryByDayDate(string daydate)
        {
            const string procedures = @"uspGet_EmployeePayroll_ByDayDate";

            object[] parms = { "@DayDate", daydate };
            return Db.ReadList(procedures, true, Make, parms);
        }


        public List<SalaryEntity> GetSalaryExistRefNoInDay(string daydate, string refNo)
        {
            const string procedures = @"uspGet_EmployeePayroll_ByInDayRefNo";
            object[] parms = { "@DayDate", Convert.ToDateTime(daydate), "@RefNo", refNo };
            return Db.ReadList(procedures, true, Make, parms);
        }
    }
}
