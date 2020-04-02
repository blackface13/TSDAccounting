/***********************************************************************
 * <copyright file="VoucherListResponse.cs" company="BUCA JSC">
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
 * Date         Author              Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// VoucherListResponse class
    /// </summary>
    public class VoucherListResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int VoucherListId { get; set; }

        /// <summary>
        /// The voucher list
        /// </summary>
        public VoucherListEntity VoucherList;

        /// <summary>
        /// The voucher lists
        /// </summary>
        public IList<VoucherListEntity> VoucherLists;
    }
}
