/***********************************************************************
 * <copyright file="IGeneralDao.cs" company="BUCA JSC">
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
using  TSD.AccountingSoft.BusinessEntities.Business.General;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.General
{
    /// <summary>
    /// Interface ICaptitalAllocateVoucherDao
    /// </summary>
  public  interface  ICaptitalAllocateVoucherDao
  {
      /// <summary>
      /// Gets the captital allocate voucher by reference identifier.
      /// </summary>
      /// <param name="refId">The reference identifier.</param>
      /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
      IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVoucherByRefId(long refId);

      /// <summary>
      /// Inserts the captital allocate voucher.
      /// </summary>
      /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
      /// <returns>System.Int32.</returns>
      int InsertCaptitalAllocateVoucher(CaptitalAllocateVoucherEntity captitalAllocateVoucher);

      /// <summary>
      /// Updates the captital allocate voucher.
      /// </summary>
      /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
      /// <returns>System.Int32.</returns>
      int UpdateCaptitalAllocateVoucher(CaptitalAllocateVoucherEntity captitalAllocateVoucher);

      /// <summary>
      /// Deletes the captital allocate voucher.
      /// </summary>
      /// <param name="refId">The reference identifier.</param>
      /// <returns>System.String.</returns>
      string  DeleteCaptitalAllocateVoucher( long refId);

      /// <summary>
      /// Gets the captital allocate voucher for update or insert.
      /// </summary>
      /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
      IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVoucherForUpdateOrInsert();



      /// <summary>
      /// Gets the captital allocate vouchers from date to to date.
      /// </summary>
      /// <param name="fromDate">From date.</param>
      /// <param name="toDate">To date.</param>
      /// <param name="activity">The activity.</param>
      /// <param name="currencyCode">The currency code.</param>
      /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
      IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchersFromDateToToDate(DateTime fromDate, DateTime toDate, int activity, string currencyCode);



      /// <summary>
      /// Gets the captital allocate vouchers from date to to date for update.
      /// </summary>
      /// <param name="fromDate">From date.</param>
      /// <param name="toDate">To date.</param>
      /// <param name="currencyCode">The currency code.</param>
      /// <param name="activity">The activity.</param>
      /// <param name="refTypeId">The reference type identifier.</param>
      /// <param name="refId">The reference identifier.</param>
      /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
      IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchersFromDateToToDateForUpdate(DateTime fromDate, DateTime toDate, string currencyCode, int activity, int refTypeId, long refId);


      /// <summary>
      /// Gets the captital allocate vouchers by reference identifier.
      /// </summary>
      /// <param name="refId">The reference identifier.</param>
      /// <returns>IList&lt;CaptitalAllocateVoucherEntity&gt;.</returns>
      IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchersByRefId(long refId);

  }
}
