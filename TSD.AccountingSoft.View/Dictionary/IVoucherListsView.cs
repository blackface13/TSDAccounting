/***********************************************************************
 * <copyright file="IVoucherListsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{

    /// <summary>
    /// IVoucherListsView interface
    /// </summary>
    public interface IVoucherListsView:IView
    {
        /// <summary>
        /// Sets the voucher lists.
        /// </summary>
        /// <value>
        /// The voucher lists.
        /// </value>
        IList<VoucherListModel> VoucherLists { set; }
    }
}
