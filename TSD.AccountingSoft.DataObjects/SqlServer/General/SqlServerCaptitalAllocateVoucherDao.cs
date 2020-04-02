/***********************************************************************
 * <copyright file="SqlServerGeneralDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 18 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.General
{
    /// <summary>
    /// SqlServerCaptitalAllocateVoucherDao
    /// </summary>
    public class SqlServerCaptitalAllocateVoucherDao : ICaptitalAllocateVoucherDao
    {

        /// <summary>
        /// Gets the captital allocate voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
        public IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVoucherByRefId(long refId)
        {
            const string procedures = @"uspGet_CaptitalAllocateVoucher_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }


        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CaptitalAllocateVoucherEntity> Make = reader =>
            new CaptitalAllocateVoucherEntity
            {
                RefDetailId = reader["RefDetailId"].AsLong(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                ActivityId = reader["Activityid"].AsString(),
                AllocatePercent = reader["AllocatePercent"].AsDecimal(),
                AllocateType = reader["AllocateType"].AsShort(),
                DeterminedDate = reader["FromDate"].AsDateTime(),
                CapitalAccountCode = reader["CapitalAccountCode"].AsString(),
                RevenueAccountCode = reader["RevenueAccountCode"].AsString(),
                ExpenseAccountCode = reader["ExpenseAccountCode"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                WaitBudgetSourceCode = reader["WaitBudgetSourceCode"].AsString(),
                CapitalAllocateCode = reader["CapitalAllocateCode"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                ExpenseAmount = reader["ExpenseAmount"].AsDecimal(),
                ToDate = reader["ToDate"].AsDateTime(),
                FromDate = reader["FromDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                RefId = reader["RefId"].AsLong(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal()


            };

        /// <summary>
        /// Takes the specified captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(CaptitalAllocateVoucherEntity captitalAllocateVoucher)
        {
            return new object[]  
            {
                "@RefDetailID", captitalAllocateVoucher.RefDetailId,
                "@BudgetItemCode", captitalAllocateVoucher.BudgetItemCode,
                "@BudgetSourceCode", captitalAllocateVoucher.BudgetSourceCode,
                "@ActivityID", captitalAllocateVoucher.ActivityId,
                "@AllocatePercent", captitalAllocateVoucher.AllocatePercent,
                "@AllocateType", captitalAllocateVoucher.AllocateType,
                "@DeterminedDate", captitalAllocateVoucher.FromDate,
                "@CapitalAccountCode", captitalAllocateVoucher.CapitalAccountCode,
                "@RevenueAccountCode", captitalAllocateVoucher.RevenueAccountCode,
                "@ExpenseAccountCode", captitalAllocateVoucher.ExpenseAccountCode,
                "@Description", captitalAllocateVoucher.Description,
                "@IsActive", captitalAllocateVoucher.IsActive,
                "@WaitBudgetSourceCode", captitalAllocateVoucher.WaitBudgetSourceCode,
                "@CapitalAllocateCode", captitalAllocateVoucher.CapitalAllocateCode,
                "@Amount",captitalAllocateVoucher.Amount,
                "@TotalAmount",captitalAllocateVoucher.TotalAmount,
                "@ExpenseAmount",captitalAllocateVoucher.ExpenseAmount,
                "@Todate",captitalAllocateVoucher.ToDate,
                "@FromDate",captitalAllocateVoucher.FromDate,
                "@CurrencyCode",captitalAllocateVoucher.CurrencyCode,
                "@RefID",captitalAllocateVoucher.RefId,
                "@BudgetSourceName",captitalAllocateVoucher.BudgetSourceName,
                "@ExchangeRate",captitalAllocateVoucher.AsDecimal()
            };
        }



        /// <summary>
        /// Inserts the captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns>System.Int32.</returns>
        public int InsertCaptitalAllocateVoucher(CaptitalAllocateVoucherEntity captitalAllocateVoucher)
        {
            const string procedures = @"uspInsert_CaptitalAllocateVoucher";
            return Db.Insert(procedures, true, Take(captitalAllocateVoucher));
        }

        /// <summary>
        /// Updates the captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateCaptitalAllocateVoucher(CaptitalAllocateVoucherEntity captitalAllocateVoucher)
        {
            const string procedures = @"uspInsert_CaptitalAllocateVoucher";
            return Db.Insert(procedures, true, Take(captitalAllocateVoucher));
        }

        /// <summary>
        /// Deletes the captital allocate voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCaptitalAllocateVoucher(long refId)
        {
            const string procedures = @"uspDelete_CaptitalAllocateVoucher_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the captital allocate voucher for update or insert.
        /// </summary>
        /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
        public IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVoucherForUpdateOrInsert()
        {
            const string procedures = @"uspGet_CaptitalAllocateVoucher_ByCaptitalAllocate";
            object[] parms = { };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the captital allocate vouchers from date to to date.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
        public IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchersFromDateToToDate(DateTime fromDate, DateTime toDate, int activityId, string currencyCode)
        {
            const string procedures = @"uspGet_CaptitalAllocateVoucher_ByFromDateToDate";
            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@CurrencyCode", currencyCode, "@ActivityID", activityId };
            return Db.ReadList(procedures, true, Make, parms);
        }



        /// <summary>
        /// Gets the captital allocate vouchers by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
        public IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchersByRefId(long refId)
        {
            const string procedures = @"uspGet_CaptitalAllocateVoucher_ByRefId";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the captital allocate vouchers from date to to date for update.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
        public IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchersFromDateToToDateForUpdate(DateTime fromDate, DateTime toDate, string currencyCode, int activityId, int refTypeId, long refId)
        {
            const string procedures = @"uspGet_CaptitalAllocateVoucher_ByFromDateToDateForUpdate";
            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@CurrencyCode", currencyCode, "@ActivityID", activityId, "@RefID", refId, @"RefTypeId", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }
    }
}
