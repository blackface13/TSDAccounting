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
    public class SqlServerAutoNumberListDao : IAutoNumberListDao
    {


        public AutoNumberListEntity GetAutoNumberList(string tableCode)
        {
            const string procedures = @"uspGet_AutoNumberList_ByTableCode";
            object[] parms = { "@TableCode", tableCode };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<AutoNumberListEntity> GetAutoNumberLists()
        {
            const string procedures = @"uspGet_All_AutoNumberList";
            return Db.ReadList(procedures, true, Make);
        }

        public string UpdateAutoNumberList(AutoNumberListEntity autoNumberList)
        {
            const string sql = @"uspUpdate_AutoNumberList";
            return Db.Update(sql, true, Take(autoNumberList));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AutoNumberListEntity> Make = reader =>
            new AutoNumberListEntity
            {
                TableCode = reader["TableCode"].AsString(),
                TableName = reader["TableName"].AsString(),
                Prefix = reader["Prefix"].AsString(),
                Value = reader["Value"].AsInt(),
                LengthOfValue = reader["LengthOfValue"].AsInt(),
                Suffix = reader["Suffix"].AsString()
            };

        /// <summary>
        /// Takes the specified automatic number.
        /// </summary>
        /// <param name="autoNumber">The automatic number.</param>
        /// <returns></returns>
        private static object[] Take(AutoNumberListEntity autoNumber)
        {
            return new object[]  
            {
                "@TableCode", autoNumber.TableCode,
                "@TableName", autoNumber.TableName,
                "@Prefix", autoNumber.Prefix,
                "@Suffix", autoNumber.Suffix,
                "@Value", autoNumber.Value,
                "@LengthOfValue", autoNumber.LengthOfValue
            };
        }

        public void UpdateIncreateAutoNumberListByValue(string tableCode)
        {
            const string procedures = @"uspIncreate_AutoNumberList";
            object[] parms = { "@TableCode", tableCode };
             Db.Read(procedures, true, Make, parms);
        }
    }
}
