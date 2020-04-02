/***********************************************************************
 * <copyright file="ResponseBase.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.BusinessComponents.Messages.MessageBase
{
    /// <summary>
    /// class ResponseBase
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// The message
        /// </summary>
        public string Message;

        /// <summary>
        /// The acknowledge
        /// </summary>
        public AcknowledgeType Acknowledge = AcknowledgeType.Success;

        /// <summary>
        /// The rows affected
        /// </summary>
        public int RowsAffected;
    }
}