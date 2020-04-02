/***********************************************************************
 * <copyright file="SqlServerSiteDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.System
{
    /// <summary>
    ///  class SqlServerSiteDao
    /// </summary>
    public class SqlServerLockDao : ILockDao
    {
      
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, LockEntity> Make = reader =>
            new LockEntity
            {
                Content = reader["Content"].AsString(),
                LockDate = reader["LockDate"].AsDateTime(),
                IsLock = reader["IsLock"].AsBool()
            };


        private object[] Take(LockEntity entity)
        {
            return new object[]  
            {
                @"Content", entity.Content,
                @"LockDate", entity.LockDate,
                @"IsLock", entity.IsLock
            };
        }

        public LockEntity GetLock()
        {
            const string procedures = @"uspGet_Lock";
            object[] parms={};
            return Db.Read(procedures, true, Make, parms);
        }

        public string ExcuteUnLock(LockEntity entity)
        {
            const string sql = @"uspExcute_Lock";
            return Db.Update(sql, true, Take(entity));
        }



        public LockEntity CheckLock(int refId, int refTypeId, DateTime refDate)
        {
            const string procedures = @"uspGet_CheckLock_ByRefDate";
            object[] parms = { "RefID", refId, "RefTypeID", refTypeId, "RefDate", refDate };
            return Db.Read(procedures, true, Make, parms);
        }

        public LockEntity CheckLock(int refId, int refTypeId)
        {
            const string procedures = @"uspGet_CheckLock_ByRefID";
            object[] parms = { "RefID", refId, "RefTypeID", refTypeId};
            return Db.Read(procedures, true, Make, parms);
        }
    }
}
