/***********************************************************************
 * <copyright file="IVendorsView.cs" company="BUCA JSC">
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
    /// IVendorsView interface
    /// </summary>
    public interface IVendorsView: IView
    {
        /// <summary>
        /// Sets the vendors.
        /// </summary>
        /// <value>
        /// The vendors.
        /// </value>
        IList<VendorModel> Vendors { set; }
    }
}
