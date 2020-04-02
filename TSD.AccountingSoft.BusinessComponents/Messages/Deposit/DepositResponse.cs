/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Deposit
{
    /// <summary>
    /// Class DepositResponse.
    /// </summary>
    public class DepositResponse : ResponseBase
    {
        /// <summary>
        /// The estimates
        /// </summary>
        public IList<DepositEntity> Deposits;

        /// <summary>
        /// The estimate
        /// </summary>
        public DepositEntity Deposit;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
