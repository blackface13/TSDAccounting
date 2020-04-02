/***********************************************************************
 * <copyright file="VoucherListEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{

    /// <summary>
    /// VoucherListEntity
    /// </summary>
    public class VoucherListEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListEntity"/> class.
        /// </summary>
        public VoucherListEntity()
        {
            AddRule(new ValidateId("VoucherListId"));
            AddRule(new ValidateRequired("VoucherListCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListEntity"/> class.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <param name="voucherListCode">The voucher list code.</param>
        /// <param name="voucherDate">The voucher date.</param>
        /// <param name="postDate">The post date.</param>
        /// <param name="description">The description.</param>
        /// <param name="docAttach">The document attach.</param>
        public VoucherListEntity(int voucherListId, string voucherListCode, DateTime voucherDate, DateTime postDate, string description, string docAttach)
            : this()
        {
            VoucherListId = voucherListId;
            VoucherListCode = voucherListCode;
            VoucherDate = voucherDate;
            PostDate = postDate;
            Description = description;
            DocAttach = docAttach;
        }

        /// <summary>
        /// Gets or sets the voucher identifier.
        /// </summary>
        /// <value>
        /// The voucher identifier.
        /// </value>
        public int VoucherListId { get; set; }

        /// <summary>
        /// Gets or sets the voucher no.
        /// </summary>
        /// <value>
        /// The voucher no.
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
