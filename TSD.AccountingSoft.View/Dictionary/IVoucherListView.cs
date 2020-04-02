/***********************************************************************
 * <copyright file="IVoucherListView.cs" company="BUCA JSC">
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

using System;


namespace TSD.AccountingSoft.View.Dictionary
{

    /// <summary>
    /// IVoucherListView interface
    /// </summary>
    public interface IVoucherListView : IView
    {
        /// <summary>
        /// Gets or sets the voucher identifier.
        /// </summary>
        /// <value>
        /// The voucher identifier.
        /// </value>
        int VoucherListId { get; set; }

        /// <summary>
        /// Gets or sets the voucher no.
        /// </summary>
        /// <value>
        /// The voucher no.
        /// </value>
        string VoucherListCode { get; set; }

        /// <summary>
        /// Gets or sets the voucher date.
        /// </summary>
        /// <value>
        /// The voucher date.
        /// </value>
        DateTime VoucherDate { get; set; }

        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        DateTime PostDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the document attach.
        /// </summary>
        /// <value>
        /// The document attach.
        /// </value>
        string DocAttach { get; set; }
    }
}
