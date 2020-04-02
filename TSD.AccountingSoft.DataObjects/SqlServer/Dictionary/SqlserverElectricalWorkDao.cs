/***********************************************************************
 * <copyright file="SqlserverStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
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
    /// <summary>
    /// Class SqlserverStockDao.
    /// </summary>
    public class SqlserverElectricalWorkDao : IElectricalWorkDao
    {

        public ElectricalWorkEntity GetElectricalWork(int yearPosted)
        {
            const string sql = @"uspGet_ElectricalWork_ByPosteDate";
            object[] parms = { "@PostedDate", yearPosted };
            return Db.Read(sql, true, Make, parms);

        }

        public string  UpdateInsertElectricalWork(ElectricalWorkEntity electricalWorkEntity)
        {
            const string sql = @"uspInsertUpdate_ElectricalWork";
            return Db.Update(sql, true, Take(electricalWorkEntity));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ElectricalWorkEntity> Make = reader =>
             new ElectricalWorkEntity
             {
                 ElectricalWorkId = reader["ElectricalWorkId"].AsInt(),
                 Name = reader["Name"].AsString(),
                 PostedDate = reader["PostedDate"].AsInt(),

             };


        private object[] Take(ElectricalWorkEntity electricalWorkEntity)
        {
            return new object[]  
            {
                "@ElectricalWorkID" , electricalWorkEntity.ElectricalWorkId,
                "@Name" , electricalWorkEntity.Name,
                "@PostedDate" , electricalWorkEntity.PostedDate
            };
        }










    }
}
