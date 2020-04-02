/***********************************************************************
 * <copyright file="GeneralVouchersCapitalAllocate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 17 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.General;


namespace TSD.AccountingSoft.View.General
{
    /// <summary>
    /// interface IAccountTranferVouchersView
    /// </summary>
    public interface IAccountTranferVouchersView
    {
        /// <summary>
        /// Sets the get captital allocate vouchers for update or insert.
        /// </summary>
        /// <value>
        /// The get captital allocate vouchers for update or insert.
        /// </value>
        IList<AccountTranferVourcherModel> GetAccountTranferVourchersUpdateOrInsert { set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        DateTime PostedDate { get; set; }
    }
}
