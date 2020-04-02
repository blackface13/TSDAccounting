/***********************************************************************
 * <copyright file="SqlServerDBOptionDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerDBOptionDao
    /// </summary>
    public class SqlServerDBOptionDao : IDBOptionDao
    {
        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="dBOptionId">The d b option identifier.</param>
        /// <returns></returns>
        public DBOptionEntity GetDBOption(string dBOptionId)
        {
            const string sql = @"uspGet_DBOption_ByID";

            object[] parms = { "@OptionID", dBOptionId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns></returns>
        public List<DBOptionEntity> GetDBOptions()
        {
            const string procedures = @"uspGet_All_DBOption";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the database options by system.
        /// </summary>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <returns></returns>
        public List<DBOptionEntity> GetDBOptionsBySystem(bool isSystem)
        {
            const string procedures = @"uspGet_DBOption_IsSystem";

            object[] parms = { "@IsSystem", isSystem };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the type of the database options by value.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns></returns>
        public List<DBOptionEntity> GetDBOptionsByValueType(int valueType)
        {
            const string procedures = @"uspGet_DBOption_ByValueType";

            object[] parms = { "@ValueType", valueType };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dBOption">The d b option.</param>
        /// <returns></returns>
        public string UpdateDBOption(DBOptionEntity dBOption)
        {
            const string sql = @"uspUpdate_DBOption";
            return Db.Update(sql, true, Take(dBOption));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, DBOptionEntity> Make = reader =>
        {
            var dBOption = new DBOptionEntity();
            dBOption.OptionId = reader["OptionID"].AsString();
            dBOption.OptionValue = reader["OptionValue"].AsString();
            dBOption.ValueType = reader["ValueType"].AsInt();
            dBOption.Description = reader["Description"].AsString();
            dBOption.IsSystem = reader["IsSystem"].AsBool();
            return dBOption;
        };

        /// <summary>
        /// Takes the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        private static object[] Take(DBOptionEntity bank)
        {
            return new object[]  
            {
                "@OptionID", bank.OptionId,
                "@OptionValue", bank.OptionValue,
                "@ValueType", bank.ValueType,
                "@Description", bank.Description,
                "@IsSystem", bank.IsSystem
            };
        }
    }
}