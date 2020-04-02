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
    /// AccountTranferVoucherReponse
    /// </summary>
    public class AccountTranferVourcherReponse : ResponseBase
    {

        /// <summary>
        /// The get account tranfer vourchers
        /// </summary>
        public IList<AccountTranferVourcherEntity> GetAccountTranferVourchers;

        /// <summary>
        /// The reference detail
        /// </summary>
        public long  RefDetailId;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;

        /// <summary>
        /// The account tranfer vourcher
        /// </summary>
        public AccountTranferVourcherEntity AccountTranferVourcher;
    }
}
