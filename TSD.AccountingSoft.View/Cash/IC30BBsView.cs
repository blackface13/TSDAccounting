/***********************************************************************
 * <copyright file="IReceiptVouchersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;

namespace TSD.AccountingSoft.View.Cash
{
    /// <summary>
    /// interface IC30BBsVie
    /// </summary>
    public interface IC30BBsView : IView
    {
        /// <summary>
        /// Sets the C30 b bs.
        /// </summary>
        /// <value>
        /// The C30 b bs.
        /// </value>
        IList<C30BBModel> C30BBs { set; }
    }
}
