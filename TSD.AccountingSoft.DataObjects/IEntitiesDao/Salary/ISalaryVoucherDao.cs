/***********************************************************************
 * <copyright file="StockEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Salary;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary
{
    public interface ISalaryVoucherDao
    {
        List<SalaryVoucherEntity> GetSalaryVoucherMonthDate(string monthDate);

        List<SalaryVoucherEntity> GetSalaryVoucherMonthDateIsPostedDate(string monthDate);

        List<SalaryVoucherEntity> GetSalaryVoucherIsRetail(string monthDate,bool isRetail,int refTypeId);

        string Update_EmployeePayroll_Voucher(string refNo, long? cashId, long? depositID);

        long GetEmployeePayroll_VoucherID(string refNo, int RefTypeId);

        string CanclCalc(string monthDate, string refNo);
        
    }
}
