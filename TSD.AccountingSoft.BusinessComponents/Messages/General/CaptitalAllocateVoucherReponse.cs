/***********************************************************************
 * <copyright file="GeneralReponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.General;


namespace TSD.AccountingSoft.BusinessComponents.Messages.General
{
    /// <summary>
    /// Class CaptitalAllocateVoucherReponse.
    /// </summary>
    public class CaptitalAllocateVoucherReponse : ResponseBase
    {
        /// <summary>
        /// The get captital allocate voucher for update or insert
        /// </summary>
        public IList<CaptitalAllocateVoucherEntity> GetCaptitalAllocateVouchers;

        /// <summary>
        /// The captital allocate voucher identifier
        /// </summary>
        public int CaptitalAllocateVoucherId;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;

        /// <summary>
        /// The captital allocate voucher
        /// </summary>
        public CaptitalAllocateVoucherEntity CaptitalAllocateVoucher;
    }
}
