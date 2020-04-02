/***********************************************************************
 * <copyright file="AutoNumberResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
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
    /// AutoNumberResponse
    /// </summary>
    public class AutoNumberResponse : ResponseBase
    {
        /// <summary>
        /// The automatic numbers
        /// </summary>
        public IList<AutoNumberEntity> AutoNumbers;

        /// <summary>
        /// The automatic number
        /// </summary>
        public AutoNumberEntity AutoNumber;
    }
}
