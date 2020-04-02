/***********************************************************************
 * <copyright file="GenveralVouchersPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.View.General;


namespace TSD.AccountingSoft.Presenter.General
{
    public class CapitalAllocateVouchersPresenter : Presenter<ICaptitalAllocateVouchersView>
    {
        public CapitalAllocateVouchersPresenter(ICaptitalAllocateVouchersView view)
            : base(view)
        {
        }


        /// <summary>
        /// Displays the specified fromdate.
        /// </summary>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        public void Display(DateTime fromdate, DateTime toDate, int activityId, string currencyCode)
        {
            View.GetCaptitalAllocateVouchersForUpdateOrInsert = Model.CaptitalAllocateVouchersToDateToFromDate(
                fromdate, toDate, activityId,currencyCode);
        }




        public void Display(DateTime fromdate, DateTime toDate, string currencyCode, int activityId,int refTypeId,long refId)
        {
            View.GetCaptitalAllocateVouchersForUpdateOrInsert = Model.CaptitalAllocateVouchersToDateToFromDateForUpdate(
                fromdate, toDate, currencyCode,activityId,refTypeId,refId);
        }


        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            View.GetCaptitalAllocateVouchersForUpdateOrInsert = Model.CaptitalAllocateVouchersByRefId(refId);
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteCaptitalAllocateVoucher(refId);
        }


        public long Save(IList<CaptitalAllocateVoucherModel> lstcaptitalAllocateVoucherModel,long refId)
        {
            long  intObj=0;
            if (refId > 0)
            {
                Model.DeleteCaptitalAllocateVoucher(refId);
                foreach (var captitalAllocateVoucherModel in lstcaptitalAllocateVoucherModel)
                {
                    intObj = Model.AddGCaptitalAllocateVoucher(captitalAllocateVoucherModel);
                }

            }
            else
            {
                foreach (var captitalAllocateVoucherModel in lstcaptitalAllocateVoucherModel)
                {
                    intObj = Model.AddGCaptitalAllocateVoucher(captitalAllocateVoucherModel);
                }
            }

            return intObj;

        }



    }
}
