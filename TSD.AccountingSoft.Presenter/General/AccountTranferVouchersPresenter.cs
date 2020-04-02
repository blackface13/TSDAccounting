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
    /// <summary>
    /// 
    /// </summary>
    public class AccountTranferVouchersPresenter : Presenter<IAccountTranferVouchersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranferVouchersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountTranferVouchersPresenter(IAccountTranferVouchersView view)
            : base(view)
        {
        }


        /// <summary>
        /// Displays the specified posted date.
        /// </summary>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="currencyCode">The currency code.</param>
        public void Display(DateTime postedDate, string currencyCode)
        {
            View.GetAccountTranferVourchersUpdateOrInsert = Model.AccountTranferVouchersByPostedDateAndCurrencyCode(postedDate, currencyCode);
        }

        /// <summary>
        /// Displays the specified posted date.
        /// </summary>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(DateTime postedDate, string currencyCode, int refTypeId)
        {
            View.GetAccountTranferVourchersUpdateOrInsert = Model.AccountTranferVouchersByEdit(postedDate, currencyCode, refTypeId);
        }


        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            View.GetAccountTranferVourchersUpdateOrInsert = Model.AccountTranferVouchersByRefId(refId);
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteAccountTranferVoucher(refId);
        }
        /// <summary>
        /// Saves the specified LST account tranfer vourcher.
        /// </summary>
        /// <param name="lstAccountTranferVourcher">The LST account tranfer vourcher.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Save(IList<AccountTranferVourcherModel> lstAccountTranferVourcher,long refId)
        {
            long  longObj=0;
            if (refId > 0)
            {
                Model.DeleteAccountTranferVoucher(refId);
                foreach (var accountTranferVourcher in lstAccountTranferVourcher)
                {
                    longObj = Model.AddAccountTranferVoucher(accountTranferVourcher);
                }

            }
            else
            {
                foreach (var accountTranferVourcher in lstAccountTranferVourcher)
                {
                    longObj = Model.AddAccountTranferVoucher(accountTranferVourcher);
                }
            }

            return longObj;

        }
    }
}
