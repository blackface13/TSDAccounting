/***********************************************************************
 * <copyright file="SqlServerAutoBusinessDao.cs" company="BUCA JSC">
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
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerAutoBusinessDao
    /// </summary>
    public class SqlServerAutoBusinessDao : IAutoBusinessDao
    {
        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        public AutoBusinessEntity GetAutoBusiness(int autoBusinessId)
        {
            const string sql = @"uspGet_AutoBusiness_ByID";

            object[] parms = { "@AutoBusinessId", autoBusinessId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinesss()
        {
            const string procedures = @"uspGet_All_AutoBusiness";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the autoBusinesss by autoBusiness account.
        /// </summary>
        /// <param name="autoBusinessAccount">The autoBusiness account.</param>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinesssByAutoBusinessAccount(string autoBusinessAccount)
        {
            const string sql = @"uspGet_AutoBusiness_ByAutoBusinessCode";

            object[] parms = { "@AutoBusinessCode", autoBusinessAccount };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the autoBusinesss by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinesssByActive(bool isActive)
        {
            const string sql = @"uspGet_AutoBusiness_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the automatic business.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<AutoBusinessEntity> GetAutoBusinessByRefType(int refTypeId, bool isActive)
        {
            const string sql = @"uspGet_AutoBusiness_ByRefType";

            object[] parms = { "@RefTypeID", refTypeId, "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        public int InsertAutoBusiness(AutoBusinessEntity autoBusiness)
        {
            const string sql = @"uspInsert_AutoBusiness";
            return Db.Insert(sql, true, Take(autoBusiness));
        }

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        public string UpdateAutoBusiness(AutoBusinessEntity autoBusiness)
        {
            const string sql = @"uspUpdate_AutoBusiness";
            return Db.Update(sql, true, Take(autoBusiness));
        }

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        public string DeleteAutoBusiness(AutoBusinessEntity autoBusiness)
        {
            const string sql = @"uspDelete_AutoBusiness";

            object[] parms = { "@AutoBusinessId", autoBusiness.AutoBusinessId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AutoBusinessEntity> Make = reader =>
            new AutoBusinessEntity
            {
                AutoBusinessId = reader["AutoBusinessID"].AsInt(),
                AutoBusinessCode = reader["AutoBusinessCode"].AsString(),
                AutoBusinessName = reader["AutoBusinessName"].AsString(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                VoucherTypeId = reader["VoucherTypeID"].AsString().AsIntForNull(),
                DebitAccountNumber = reader["DebitAccountNumber"].AsString(),
                CreditAccountNumber = reader["CreditAccountNumber"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                Description = reader["Description"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        private static object[] Take(AutoBusinessEntity autoBusiness)
        {
            return new object[]  
            {
                "@AutoBusinessID", autoBusiness.AutoBusinessId,
                "@AutoBusinessCode", autoBusiness.AutoBusinessCode,
                "@AutoBusinessName", autoBusiness.AutoBusinessName,
                "@RefTypeID", autoBusiness.RefTypeId,
                "@VoucherTypeID", autoBusiness.VoucherTypeId,
                "@DebitAccountNumber", autoBusiness.DebitAccountNumber,
                "@CreditAccountNumber", autoBusiness.CreditAccountNumber,
                "@BudgetSourceCode", autoBusiness.BudgetSourceCode,
                "@BudgetItemCode", autoBusiness.BudgetItemCode,
                "@Description", autoBusiness.Description,
                "@CurrencyCode", autoBusiness.CurrencyCode,
                "@IsActive", autoBusiness.IsActive
            };
        }
    }
}
