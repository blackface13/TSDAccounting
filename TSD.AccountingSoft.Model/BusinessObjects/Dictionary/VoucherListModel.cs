/***********************************************************************
 * <copyright file="VoucherListModel.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{

    /// <summary>
    /// VoucherListModel
    /// </summary>
    public class VoucherListModel
    {

        /// <summary>
        /// Gets or sets the voucher identifier.
        /// </summary>
        /// <value>
        /// The voucher identifier.
        /// </value>
        public int VoucherListId { get; set; }

        /// <summary>
        /// Gets or sets the voucher list code.
        /// </summary>
        /// <value>
        /// The voucher list code.
        /// </value>
        public string VoucherListCode { get; set; }

        /// <summary>
        /// Gets or sets the voucher date.
        /// </summary>
        /// <value>
        /// The voucher date.
        /// </value>
        public DateTime VoucherDate { get; set; }

        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        public DateTime PostDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the document attach.
        /// </summary>
        /// <value>
        /// The document attach.
        /// </value>
        public string DocAttach { get; set; }
    }
}
