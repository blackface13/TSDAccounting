/***********************************************************************
 * <copyright file="CommonResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, May 30, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;

namespace TSD.AccountingSoft.BusinessComponents.Messages
{
    /// <summary>
    /// class CommonResponse
    /// </summary>
    public class CommonResponse : ResponseBase
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int? Id;

        /// <summary>
        /// The reset increment success
        /// </summary>
        public bool ResetIncrementSuccess;
    }
}
