/***********************************************************************
 * <copyright file="SqlServerMergerFundDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerMergerFundDao.
    /// </summary>
    public class SqlServerMergerFundDao : IMergerFundDao
    {
        /// <summary>
        /// Gets the mergerFund.
        /// </summary>
        /// <param name="mergerFundId">The mergerFund identifier.</param>
        /// <returns></returns>
        public MergerFundEntity GetMergerFund(int mergerFundId)
        {
            const string sql = @"uspGet_MergerFund_ByID";

            object[] parms = { "@MergerFundID", mergerFundId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the mergerFunds for combo tree.
        /// </summary>
        /// <param name="mergerFundId">The mergerFund identifier.</param>
        /// <returns></returns>
        public List<MergerFundEntity> GetMergerFundsForComboTree(int mergerFundId)
        {
            const string sql = @"uspGet_MergerFund_ForComboTreee";

            object[] parms = { "@MergerFundID", mergerFundId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the mergerFunds.
        /// </summary>
        /// <returns></returns>
        public List<MergerFundEntity> GetMergerFunds()
        {
            const string procedures = @"uspGet_All_MergerFund";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the mergerFunds active.
        /// </summary>
        /// <returns></returns>
        public List<MergerFundEntity> GetMergerFundsByActive(bool isActive)
        {
            const string procedures = @"uspGet_MergerFund_ByActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the mergerFund.
        /// </summary>
        /// <param name="mergerFund">The mergerFund.</param>
        /// <returns></returns>
        public int InsertMergerFund(MergerFundEntity mergerFund)
        {
            const string sql = "uspInsert_MergerFund";
            return Db.Insert(sql, true, Take(mergerFund));
        }

        /// <summary>
        /// Updates the mergerFund.
        /// </summary>
        /// <param name="mergerFund">The mergerFund.</param>
        /// <returns></returns>
        public string UpdateMergerFund(MergerFundEntity mergerFund)
        {
            const string sql = "uspUpdate_MergerFund";
            return Db.Update(sql, true, Take(mergerFund));
        }

        /// <summary>
        /// Deletes the mergerFund.
        /// </summary>
        /// <param name="mergerFund">The mergerFund.</param>
        /// <returns></returns>
        public string DeleteMergerFund(MergerFundEntity mergerFund)
        {
            const string sql = @"uspDelete_MergerFund";

            object[] parms = { "@MergerFundID", mergerFund.MergerFundId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, MergerFundEntity> Make = reader =>
            new MergerFundEntity
            {
                MergerFundId = reader["MergerFundID"].AsInt(),
                MergerFundCode = reader["MergerFundCode"].AsString(),
                MergerFundName = reader["MergerFundName"].AsString(),
                ParentId = reader["ParentID"].AsInt(),
                Description = reader["Description"].AsString(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                Grade = reader["Grade"].AsInt(),
                ForeignName = reader["ForeignName"].AsString()
            };

        /// <summary>
        /// Takes the specified mergerFund.
        /// </summary>
        /// <param name="mergerFund">The mergerFund.</param>
        /// <returns></returns>
        private object[] Take(MergerFundEntity mergerFund)
        {
            return new object[]  
            {
                "@MergerFundID", mergerFund.MergerFundId,
                "@MergerFundCode", mergerFund.MergerFundCode,
                "@MergerFundName", mergerFund.MergerFundName,
                "@ParentID", mergerFund.ParentId,
                "@Description", mergerFund.Description,
                "@IsSystem", mergerFund.IsSystem,
                "@IsActive", mergerFund.IsActive,
                "@Grade", mergerFund.Grade,
                "@ForeignName", mergerFund.ForeignName
            };
        }
    }
}
