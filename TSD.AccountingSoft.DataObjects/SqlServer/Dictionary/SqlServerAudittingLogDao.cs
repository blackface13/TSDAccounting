/***********************************************************************
 * <copyright file="SqlServerAudittingLogDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System.Data;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerAudittingLogDao.
    /// </summary>
    public class SqlServerAudittingLogDao : IAudittingLogDao
    {
        /// <summary>
        /// Gets the auditting logs.
        /// </summary>
        /// <returns></returns>
        public List<AudittingLogEntity> GetAudittingLogs()
        {
            const string procedures = @"uspGet_All_AudittingLog";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the auditting log.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        public AudittingLogEntity GetAudittingLog(int eventId)
        {
            const string sql = @"uspGet_AudittingLog_ByID";

            object[] parms = { "@EventId", eventId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        public int InsertAudittingLog(AudittingLogEntity audittingLog)
        {
            const string sql = @"uspAudittingLog";
            return Db.Insert(sql, true, Take(audittingLog));
        }

        /// <summary>
        /// Deletes the auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        public string DeleteAudittingLog(AudittingLogEntity audittingLog)
        {
            const string sql = @"uspDelete_AudittingLog";

            object[] parms = { "@EventID", audittingLog.EventId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AudittingLogEntity> Make = reader =>
            new AudittingLogEntity
            {
                EventId = reader["EventId"].AsInt(),
                Amount = reader["Amount"].AsDecimal(),
                Reference = reader["Reference"].AsString(),
                ComponentName = reader["ComponentName"].AsString(),
                ComputerName = reader["ComputerName"].AsString(),
                EventAction = reader["EventAction"].AsInt(),
                EventTime = reader["EventTime"].AsDateTime(),
                LoginName = reader["LoginName"].AsString(),
            };

        /// <summary>
        /// Takes the specified auditting log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        private static object[] Take(AudittingLogEntity audittingLog)
        {
            return new object[]  
            {
                "@ComponentName", audittingLog.ComponentName,
                "@EventAction", audittingLog.EventAction,
                "@Reference", audittingLog.Reference,
                "@Amount", audittingLog.Amount,
                "@LoginName", audittingLog.LoginName
            };
        }
    }
}
