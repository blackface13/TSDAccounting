/***********************************************************************
 * <copyright file="SqlVoucherListDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
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
    /// SqlServerVoucherListDao
    /// </summary>
    public class SqlServerVoucherListDao : IVoucherListDao
    {

        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="voucherId">The voucher identifier.</param>
        /// <returns></returns>
        public VoucherListEntity GetVoucherListById(int voucherId)
        {
            const string sql = @"uspGet_VoucherList_ById";
            object[] parms = { "@VoucherListID", voucherId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        public List<VoucherListEntity> GetVoucherLists()
        {
            const string sql = @"uspGet_All_VoucherList";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        public int InsertVoucherList(VoucherListEntity voucherListEntity)
        {
            const string sql = @"uspInsert_VoucherList";
            return Db.Insert(sql, true, Take(voucherListEntity));
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        public string UpdateVoucherList(VoucherListEntity voucherListEntity)
        {
            const string sql = @"uspUpdate_VoucherList";
            return Db.Update(sql, true, Take(voucherListEntity));
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        public string DeleteVoucherList(VoucherListEntity voucherListEntity)
        {
            const string sql = @"uspDelete_VoucherList";
            object[] parms = { "@VoucherListID", voucherListEntity.VoucherListId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, VoucherListEntity> Make = reader =>
            new VoucherListEntity
            {
                VoucherListId = reader["VoucherListID"].AsId(),
                VoucherListCode = reader["VoucherListCode"].AsString(),
                VoucherDate = reader["VoucherDate"].AsDateTime(),
                PostDate = reader["PostDate"].AsDateTime(),
                Description = reader["Description"].AsString(),
                DocAttach = reader["DocAttach"].AsString()
            };

        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="voucherList">The voucherList.</param>
        /// <returns></returns>
        private static object[] Take(VoucherListEntity voucherList)
        {
            return new object[]
             {
                 "@VoucherListID",voucherList.VoucherListId,
                 "@VoucherListCode",voucherList.VoucherListCode,
                 "@VoucherDate",voucherList.VoucherDate,
                 "@PostDate",voucherList.PostDate,
                 "@Description",voucherList.Description,
                 "@DocAttach",voucherList.DocAttach			
             };
        }
    }
}
