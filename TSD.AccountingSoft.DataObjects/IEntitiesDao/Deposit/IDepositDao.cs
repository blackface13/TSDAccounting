/***********************************************************************
 * <copyright file="IDepositDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit
{
    /// <summary>
    /// IDepositDao
    /// </summary>
    public interface IDepositDao
    {
        /// <summary>
        /// Gets the deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>DepositEntity.</returns>
        DepositEntity GetDeposit(long refId);

        /// <summary>
        /// Gets the deposit by refdate and reftype.
        /// </summary>
        /// <param name="deposit">The ob deposit entity.</param>
        /// <returns></returns>
        DepositEntity GetDepositByRefdateAndReftype(DepositEntity deposit); 

        /// <summary>
        /// Gets the deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List{DepositEntity}.</returns>
        List<DepositEntity> GetDepositsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the deposits by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        List<DepositEntity> GetDepositsByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        /// Gets the deposits by reference no and reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<DepositEntity> GetDepositsByRefNoAndRefDate(int refTypeId, string refNo, DateTime refDate, string currencyCode);

        /// <summary>
        /// Gets the deposits.
        /// </summary>
        /// <returns>List{DepositEntity}.</returns>
        List<DepositEntity> GetDeposits();

        /// <summary>
        /// Inserts the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns>System.Int32.</returns>
        int InsertDeposit(DepositEntity deposit);

        /// <summary>
        /// Updates the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns>System.String.</returns>
        string UpdateDeposit(DepositEntity deposit);

        /// <summary>
        /// Deletes the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns>System.String.</returns>
        string DeleteDeposit(DepositEntity deposit);

        /// <summary>
        /// Gets the Deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        DepositEntity GetDepositByRefNo(string refNo);

        DepositEntity GetDepositBySalary(DateTime dateMonth);


        DepositEntity GetDepositsBySalary(int refTypeId,string postedDate, string refNo, string currencyCode);

        string DeleteEmployeePayroll(string refNo, string postedDate);

        string UpdateEmployeePayroll(string orgrefNo, string replaceRefNo, string monthDate);



    }
}