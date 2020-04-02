/***********************************************************************
 * <copyright file="IReceiptVoucherView.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;


namespace TSD.AccountingSoft.View.Cash
{

    /// <summary>
    /// IC30BBView
    /// </summary>
    public interface IC30BBView : IView
    {
        /// <summary>
        /// Gets or sets the C30 bb list.
        /// </summary>
        /// <value>
        /// The C30 bb list.
        /// </value>
        List<C30BBModel> C30BBList { get; set; }
    }
}
