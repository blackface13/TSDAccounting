/***********************************************************************
 * <copyright file="VoucherTypeResponse.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// class VoucherTypeResponse
    /// </summary>
    public class VoucherTypeResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>
        /// The voucher type identifier.
        /// </value>
        public int VoucherTypeId { get; set; }

        /// <summary>
        /// The voucher type
        /// </summary>
        public VoucherTypeEntity VoucherType;

        /// <summary>
        /// The voucher types
        /// </summary>
        public IList<VoucherTypeEntity> VoucherTypes;
    }
}
