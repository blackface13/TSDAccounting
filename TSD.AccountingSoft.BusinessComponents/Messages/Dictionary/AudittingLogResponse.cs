/***********************************************************************
 * <copyright file="AudittingLogResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// AudittingLogResponse
    /// </summary>
    public class AudittingLogResponse : ResponseBase
    {
        /// <summary>
        /// The auditting logs
        /// </summary>
        public IList<AudittingLogEntity> AudittingLogs;

        /// <summary>
        /// The auditting log
        /// </summary>
        public AudittingLogEntity AudittingLog;

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }
    }
}
