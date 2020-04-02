/***********************************************************************
 * <copyright file="GeneralRequest.cs" company="BUCA JSC">
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

using System;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.General;


namespace TSD.AccountingSoft.BusinessComponents.Messages.General
{
    /// <summary>
    /// Class CaptitalAllocateVoucherRequest.
    /// </summary>
    public class CaptitalAllocateVoucherRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the general entity.
        /// </summary>
        /// <value>The general entity.</value>
        public CaptitalAllocateVoucherEntity CaptitalAllocateVoucherEntity { get; set; }

        /// <summary>
        /// From date
        /// </summary>
        public DateTime FromDate;

        /// <summary>
        /// To date
        /// </summary>
        public DateTime ToDate;

        /// <summary>
        /// The currency code
        /// </summary>
        public string CurrencyCode;

        /// <summary>
        /// The activity identifier
        /// </summary>
        public int ActivityId;

        /// <summary>
        /// The reference type identifier
        /// </summary>
        public int RefTypeId;
    }
}
