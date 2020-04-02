/***********************************************************************
 * <copyright file="IPaymentVouchersView.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;


namespace TSD.AccountingSoft.View.Cash
{

    /// <summary>
    /// IPaymentVouchersView interface
    /// </summary>
    public interface IPaymentVouchersView : IView
    {
        /// <summary>
        /// Sets the payment vouchers.
        /// </summary>
        /// <value>
        /// The payment vouchers.
        /// </value>
        IList<CashModel> PaymentVouchers { set; }

        IList<CashDetailModel> PaymentVoucherDetails { set; }
    }
}
