/***********************************************************************
 * <copyright file="VoucherTypeRequest.cs" company="BUCA JSC">
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
    /// 
    /// </summary>
    public class VoucherTypeRequest : RequestBase
    {
        /// <summary>
        /// The voucherTypes
        /// </summary>
        public IList<VoucherTypeEntity> VoucherTypes;

        /// <summary>
        /// The voucherType
        /// </summary>
        public VoucherTypeEntity VoucherType;

        /// <summary>
        /// Gets or sets the voucherType identifier.
        /// </summary>
        /// <value>
        /// The voucherType identifier.
        /// </value>
        public int VoucherTypeId { get; set; }

        public string Code { get; set; }
    }
}
