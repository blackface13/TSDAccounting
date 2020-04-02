/***********************************************************************
 * <copyright file="IPaymentCashDao.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.Business.Cash;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash
{

    /// <summary>
    /// IPaymentCashDao interface
    /// </summary>
    public interface ICashDao
    {
        /// <summary>
        /// Gets the cash.
        /// </summary>
        /// <param name="refNo">The cash identifier.</param>
        /// <returns></returns>
        CashEntity GetCashForSalaryByRefNo(string refNo);

        CashEntity GetCashForSalaryByDateMonth(DateTime dateMonth);

        /// <summary>
        /// Gets the cash.
        /// </summary>
        /// <param name="cashId">The cash identifier.</param>
        /// <returns></returns>
        CashEntity GetCash(long cashId);

        /// <summary>
        /// Gets the cash by refdate and reftype.
        /// </summary>
        /// <param name="obCashEntity">The ob cash entity.</param>
        /// <returns></returns>
        CashEntity GetCashByRefdateAndReftype(CashEntity obCashEntity);

        /// <summary>
        /// Gets the cash by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        List<CashEntity> GetCashByRefNo(string refNo);

        /// <summary>
        /// Gets the cashs.
        /// </summary>
        /// <returns></returns>
        List<CashEntity> GetCashes();

        /// <summary>
        /// Gets the cashes by reference type identifier.
        /// </summary>
        /// <returns></returns>
        List<CashEntity> GetCashesByRefTypeId(int refTypeId,int year);

        /// <summary>
        /// Inserts the cash.
        /// </summary>
        /// <param name="cash">The cash.</param>
        /// <returns></returns>
        int InsertCash(CashEntity cash);

        /// <summary>
        /// Updates the cash entity.
        /// </summary>
        /// <param name="cash">The cash.</param>
        /// <returns></returns>
        string UpdateCash(CashEntity cash);

        string UpdateEmployeePayroll(string orgrefNo,string replaceRefNo, string monthDate);

        string DeleteEmployeePayroll(string refNo, string postedDate);

        /// <summary>
        /// Deletes the cash entity.
        /// </summary>
        /// <param name="cash">The cash.</param>
        /// <returns></returns>
        string DeleteCash(CashEntity cash);

        List<CashEntity> GetCashesByRefNoAndRefDate(int refTypeId,DateTime refDate,string refNo,string currencyCode );

        CashEntity GetCashBySalary(int refTypeId, string postedDate, string refNo, string currencyCode);

    }
}
