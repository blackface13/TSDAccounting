/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Thodd           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;


namespace TSD.AccountingSoft.View.Deposit
{
    /// <summary>
    /// Interface IReceiptDepositsView
    /// </summary>
    public interface IPaymentDepositsView : IView
    {
        /// <summary>
        /// Sets the receipt deposits.
        /// </summary>
        /// <value>
        /// The receipt deposits.
        /// </value>
        IList<DepositModel> PaymentDeposits { set; }

        IList<DepositDetailModel> PaymentDepositDetails { set; }
    }
}
