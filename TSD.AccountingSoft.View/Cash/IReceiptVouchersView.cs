/***********************************************************************
 * <copyright file="IReceiptVouchersView.cs" company="BUCA JSC">
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
    /// IReceiptVouchersView class
    /// </summary>
    public interface IReceiptVouchersView : IView
    {
        /// <summary>
        /// Sets the receipt vouchers.
        /// </summary>
        /// <value>
        /// The receipt vouchers.
        /// </value>
        IList<ReceiptVoucherModel> ReceiptVouchers { set; }

        IList<ReceiptVoucherDetailModel> ReceiptVoucherDetails { set; }
       

        
    }
}
