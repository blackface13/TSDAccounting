/***********************************************************************
 * <copyright file="CashResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Cash
{

    /// <summary>
    /// CashResponse class
    /// </summary>
    public class CashResponse : ResponseBase
    {
        /// <summary>
        /// The receipt vouchers
        /// </summary>
        public IList<CashEntity> Cashes;

        /// <summary>
        /// The receipt voucher
        /// </summary>
        public CashEntity Cash;

        /// <summary>
        /// The cash detail
        /// </summary>
        public CashDetailEntity CashDetail;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
