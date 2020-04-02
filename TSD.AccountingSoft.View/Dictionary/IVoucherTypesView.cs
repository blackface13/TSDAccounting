/***********************************************************************
 * <copyright file="IVoucherTypesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
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
    public interface IVoucherTypesView : IView
    {
        /// <summary>
        /// Sets the voucher types.
        /// </summary>
        /// <value>
        /// The voucher types.
        /// </value>
        IList<VoucherTypeModel> VoucherTypes { set; }
    }
}
