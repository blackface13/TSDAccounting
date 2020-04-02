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
    /// Class GeneralReponse.
    /// </summary>
 public   class GeneralReponse : ResponseBase
    {

        /// <summary>
        /// The receipt vouchers
        /// </summary>
        public IList<GeneralEntity> Generals;

        /// <summary>
        /// The receipt voucher
        /// </summary>
        public GeneralEntity General;

        /// <summary>
        /// The cash detail
        /// </summary>
        public GeneralDetailEntity GeneralDetail;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId; 


    }
}
