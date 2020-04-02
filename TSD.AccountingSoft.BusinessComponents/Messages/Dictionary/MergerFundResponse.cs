/***********************************************************************
 * <copyright file="MergerFundResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// Class MergerFundResponse.
    /// </summary>
    public class MergerFundResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MergerFundResponse"/> class.
        /// </summary>
        public MergerFundResponse() { }

        /// <summary>
        /// The merger funds
        /// </summary>
        public IList<MergerFundEntity> MergerFunds;

        /// <summary>
        /// The merger fund
        /// </summary>
        public MergerFundEntity MergerFund;

        /// <summary>
        /// The merger fund identifier
        /// </summary>
        public int MergerFundId;
    }
}
