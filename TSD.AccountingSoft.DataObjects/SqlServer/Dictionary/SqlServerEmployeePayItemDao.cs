/***********************************************************************
 * <copyright file="SqlServerEmployeePayItemDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerEmployeePayItemDao
    /// </summary>
    public class SqlServerEmployeePayItemDao : IEmployeePayItemDao
    {
        public IList<EmployeePayItemEntity> GetEmployeePayItemsByEmployeeId(int employeeId)
        {
            const string sql = @"uspGet_EmployeePayItem_ByEmployeeID";

            object[] parms = { "@EmployeeID", employeeId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public IList<EmployeePayItemEntity> GetEmployeeForEditPayItemsByEmployeeId(int employeeId)
        {
            const string sql = @"uspGet_EmployeePayItem_ByEmployeeIDForEdit";

            object[] parms = { "@EmployeeID", employeeId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public EmployeePayItemEntity GetEmployeePayItemByEmployeePayItemId(int employeePayItemId)
        {
            const string sql = @"uspGet_EmployeePayItem_EmployeePayItemID";

            object[] parms = { "@EmployeePayItemID", employeePayItemId };
            return Db.Read(sql, true, Make, parms);
        }

        public int InsertEmployeePayItem(EmployeePayItemEntity payItemEntity)
        {
            const string sql = @"uspInsert_EmployeePayItem";
            return Db.Insert(sql, true, Take(payItemEntity));
        }

        public string DeleteEmployeePayItemByEmployeeId(int employeeId)
        {
            const string sql = @"uspDelete_EmployeePayItem_EmployeeID";

            object[] parms = { "@EmployeeID", employeeId };
            return Db.Update(sql, true, parms);
        }

        public string DeleteEditEmployeePayItemByEmployeeId(int employeeId)
        {
            const string sql = @"uspDelete_EmployeePayItem_ByEmployeeID";

            object[] parms = { "@EmployeeID", employeeId };
            return Db.Update(sql, true, parms);
        }

        private static readonly Func<IDataReader, EmployeePayItemEntity> Make = reader =>
            new EmployeePayItemEntity
            {
                EmployeePayItemId = reader["EmployeePayItemID"].AsInt(),
                EmployeeId = reader["EmployeeID"].AsInt(),
                PayItemId = reader["PayItemID"].AsInt(),
                SalaryRatio = reader["SalaryRatio"].AsFloat(),
                Amount = reader["Amount"].AsDecimal()
            };

        private static object[] Take(EmployeePayItemEntity employeePayItem)
        {
            return new object[]  
            {
                "@EmployeePayItemID", employeePayItem.EmployeeId,
                "@PayItemID", employeePayItem.PayItemId,
                "@EmployeeID", employeePayItem.EmployeeId,
                "@SalaryRatio", employeePayItem.SalaryRatio,
                "@Amount", employeePayItem.Amount
            };
        }

        public IList<EmployeePayItemEntity> GetEmployeeForViewtEmployeePayItem(int employeeId, DateTime refDateSalary, decimal exchangeRate)
        {
            const string sql = @"uspGet_EmployeePayItem_ViewtEmployeePayItem";

            object[] parms = { "@EmployeeID", employeeId, "@RefDate", refDateSalary, "@VoucherExchangeRate", exchangeRate };

            return Db.ReadList(sql, true, Make1, parms);
        }

        // xu ly rieng cho tinh luong tren chung tu
        private static readonly Func<IDataReader, EmployeePayItemEntity> Make1 = reader1 =>
            new EmployeePayItemEntity
            {
                EmployeePayItemId = reader1["EmployeePayItemID"].AsInt(),
                EmployeeId = reader1["EmployeeID"].AsInt(),
                PayItemId = reader1["PayItemID"].AsInt(),
                SalaryRatio = reader1["SalaryRatio"].AsString().AsFloat(),
                Amount = reader1["Amount"].AsDecimal(),
                AmountExchange = reader1["AmountExchange"].AsDecimal()
            };

        private static object[] Take1(EmployeePayItemEntity employeePayItem)
        {
            return new object[]  
            {
                "@EmployeePayItemID", employeePayItem.EmployeeId,
                "@PayItemID", employeePayItem.PayItemId,
                "@EmployeeID", employeePayItem.EmployeeId,
                "@SalaryRatio", employeePayItem.SalaryRatio,
                "@Amount", employeePayItem.Amount,
                "@AmountExchange", employeePayItem.AmountExchange
            };
        }











    }
}
