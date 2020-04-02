/***********************************************************************
 * <copyright file="SqlServerBuildingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerMutualDao :IMutualDao
    {
        private static readonly Func<IDataReader, MutualEntity> Make = reader =>
            new MutualEntity
            {
                Address = reader["Address"].AsString(),
                Area = reader["Area"].AsDecimal(),
                Description = reader["Description"].AsString(),
                IsActive =reader["IsActive"].AsBool(),
                JobCandidate = reader["JobCandidate"].AsString(),
                MutualCode = reader["MutualCode"].AsString(),
                MutualId = reader["MutualId"].AsInt(),
                MutualName = reader["MutualName"].AsString(),
                State = reader["State"].AsInt(),
                TotalFloor = reader["TotalFloor"].AsInt(),
                UseDate = reader["UseDate"].AsDateTime()
            };

        private static object[] Take(MutualEntity mutual)
        {
            return new object[]  
            {
                "@Address", mutual.Address,
                "@Area", mutual.Area,
                "@Description", mutual.Description,
                "@JobCandidate", mutual.JobCandidate,
                "@MutualCode", mutual.MutualCode,
                "@MutualId", mutual.MutualId,
                "@IsActive", mutual.IsActive,
                "@MutualName", mutual.MutualName,
                "@State", mutual.State,
                "@TotalFloor", mutual.TotalFloor,
                "@UseDate", mutual.UseDate

            };
        }

        public MutualEntity GetMutual(int mutualId)
        {
            const string sql = @"uspGet_Mutual_ByID";

            object[] parms = { "@MutualID", mutualId };
            return Db.Read(sql, true, Make, parms);
        }

        public List<MutualEntity> GetMutuals()
        {
            const string procedures = @"uspGet_All_Mutual";
            return Db.ReadList(procedures, true, Make);
        }

        public List<MutualEntity> GetMutualsByMutualCode(string mutualCode)
        {
            const string sql = @"uspGet_Mutual_ByMutualCode";

            object[] parms = { "@MutualCode", mutualCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<MutualEntity> GetMutualsByActive(bool isActive)
        {
            const string sql = @"uspGet_Mutual_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        public int InsertMutual(MutualEntity mutual)
        {
            const string sql = @"uspInsert_Mutual";
            return Db.Insert(sql, true, Take(mutual));
        }

        public string UpdateMutual(MutualEntity mutual)
        {
            const string sql = @"uspUpdate_Mutual";
            return Db.Update(sql, true, Take(mutual));
        }

        public string DeleteBuilding(MutualEntity mutual)
        {
            const string sql = @"uspDelete_Mutual";

            object[] parms = { "@MutualID", mutual.MutualId };
            return Db.Delete(sql, true, parms);
        }


        public List<MutualEntity> GetMutualsForEstimate(bool isActive)
        {
            const string sql = @"uspGet_Mutual_ForEstimate";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
    }
}
