/***********************************************************************
 * <copyright file="SqlServerVoucherTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
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
    /// SqlServerVoucherTypeDao
    /// </summary>
    public class SqlServerVoucherTypeDao : IVoucherTypeDao
    {
        /// <summary>
        /// Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        public List<VoucherTypeEntity> GetVoucherTypes()
        {
            const string procedures = @"uspGet_All_VoucherType";
            return Db.ReadList(procedures, true, Make);
        }

        public VoucherTypeEntity GetVoucherTypeByCode(string code)
        {
            const string procedures = @"uspGet_VoucherType_ByCode";

            object[] parms = { "@Code", code };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the voucher types by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<VoucherTypeEntity> GetVoucherTypesByIsActive(bool isActive)
        {
            const string procedures = @"uspGet_VoucherType_ByIsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, VoucherTypeEntity> Make = reader =>
           new VoucherTypeEntity
           {
               VoucherTypeId = reader["VoucherTypeID"].AsInt(),
               VoucherTypeName = reader["VoucherTypeName"].AsString(),
               IsActive = reader["IsActive"].AsBool()
           };
    }
}