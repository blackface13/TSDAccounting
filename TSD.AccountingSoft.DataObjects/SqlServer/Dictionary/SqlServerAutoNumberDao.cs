/***********************************************************************
 * <copyright file="SqlServerAutoNumberDao.cs" company="BUCA JSC">
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
    /// SqlServerAutoNumberDao
    /// </summary>
    public class SqlServerAutoNumberDao : IAutoNumberDao
    {
        /// <summary>
        /// Gets the type of the automatic number by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="currDate">The reference type identifier.</param>
        /// <returns></returns>
        public AutoNumberEntity GetAutoNumberByRefType(int refTypeId)
        {
            const string procedures = @"uspGet_AutoNumber_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <returns></returns>
        public List<AutoNumberEntity> GetAutoNumbers()
        {
            const string procedures = @"uspGet_All_AutoNumber";

            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Updates the automatic number.
        /// </summary>
        /// <param name="autoNumber">The automatic number.</param>
        /// <returns></returns>
        public string UpdateAutoNumber(AutoNumberEntity autoNumber)
        {
            const string sql = @"uspUpdate_AutoNumber";
            return Db.Update(sql, true, Take(autoNumber));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AutoNumberEntity> Make = reader =>
        {
            var autoNumber = new AutoNumberEntity();
            autoNumber.RefTypeId = reader["RefTypeID"].AsInt();
            autoNumber.Prefix = reader["Prefix"].AsString();
            autoNumber.Value = reader["Value"].AsInt();
            autoNumber.ValueLocalCurency = reader["ValueLocalCurency"].AsInt();
            autoNumber.LengthOfValue = reader["LengthOfValue"].AsInt();
            autoNumber.Suffix = reader["Suffix"].AsString();

            return autoNumber;
        };

        /// <summary>
        /// Takes the specified automatic number.
        /// </summary>
        /// <param name="autoNumber">The automatic number.</param>
        /// <returns></returns>
        private static object[] Take(AutoNumberEntity autoNumber)
        {
            return new object[]
            {
                "@RefTypeID", autoNumber.RefTypeId,
                "@Prefix", autoNumber.Prefix,
                "@Suffix", autoNumber.Suffix,
                "@Value", autoNumber.Value,
                "@ValueLocalCurency", autoNumber.ValueLocalCurency,
                "@LengthOfValue", autoNumber.LengthOfValue
            };
        }




        public AutoNumberEntity GetAutoNumberByRefTypeSalary(int refTypeId, string currDate)
        {
            const string procedures = @"uspGet_AutoNumber_ByRefTypeSalary";
            object[] parms = { "@RefType", refTypeId, "@CurrDate", currDate };
            return Db.Read(procedures, true, Make, parms);
        }
    }
}
