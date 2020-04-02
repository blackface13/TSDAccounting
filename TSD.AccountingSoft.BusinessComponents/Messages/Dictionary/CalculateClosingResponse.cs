/***********************************************************************
 * <copyright file="CalculateClosingResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, December 23, 2014
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
    /// CaculateClosingResponse
    /// </summary>
    public class CaculateClosingResponse : ResponseBase
    {
        /// <summary>
        /// The Calculate Closings
        /// </summary>
        public IList<CalculateClosingEntity> CalculateClosings;

        /// <summary>
        /// The Calculate Closing Entity
        /// </summary>
        public CalculateClosingEntity CalculateClosing;
    }
}
