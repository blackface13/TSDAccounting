/***********************************************************************
 * <copyright file="SqlServerCapitalAllocateDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
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
    /// Class SqlServerCapitalAllocateDao.
    /// </summary>
    public class SqlServerCapitalAllocateDao : ICapitalAllocateDao
    {
        /// <summary>
        /// Gets the CapitalAllocate.
        /// </summary>
        /// <param name="capitalAllocateId">The CapitalAllocate identifier.</param>
        /// <returns>CapitalAllocateEntity.</returns>
        public CapitalAllocateEntity GetCapitalAllocate(int capitalAllocateId)
        {
            const string sql = @"uspGet_CapitalAllocate_ByID";
            object[] parms = { "@CapitalAllocateID", capitalAllocateId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets CapitalAllocates.
        /// </summary>
        /// <returns>List{CapitalAllocateEntity}.</returns>
        public List<CapitalAllocateEntity> GetCapitalAllocates()
        {
            const string procedures = @"uspGet_All_CapitalAllocate";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capital allocate.</param>
        /// <returns>System.Int32.</returns>
        public int InsertCapitalAllocate(CapitalAllocateEntity capitalAllocate)
        {
            const string sql = "uspInsert_CapitalAllocate";
            return Db.Insert(sql, true, Take(capitalAllocate));
        }

        /// <summary>
        /// Updates the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capital allocate.</param>
        /// <returns>System.String.</returns>
        public string UpdateCapitalAllocate(CapitalAllocateEntity capitalAllocate)
        {
            const string sql = "uspUpdate_CapitalAllocate";
            return Db.Update(sql, true, Take(capitalAllocate));
        }

        /// <summary>
        /// Deletes the capital allocate.
        /// </summary>
        /// <param name="capitalAllocate">The capital allocate.</param>
        /// <returns>System.String.</returns>
        public string DeleteCapitalAllocate(CapitalAllocateEntity capitalAllocate)
        {
            const string sql = @"uspDelete_CapitalAllocate";
            object[] parms = { "@CapitalAllocateID", capitalAllocate.CapitalAllocateId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CapitalAllocateEntity> Make = reader =>
            new CapitalAllocateEntity
            {
                CapitalAllocateId = reader["CapitalAllocateID"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                Activityid = reader["Activityid"].AsInt(),
                AllocatePercent = reader["AllocatePercent"].AsShort(),
                AllocateType = reader["AllocateType"].AsShort(),
                DeterminedDate = reader["DeterminedDate"].AsDateTimeForNull(),
                CapitalAccountCode = reader["CapitalAccountCode"].AsString(),
                RevenueAccountCode = reader["RevenueAccountCode"].AsString(),
                ExpenseAccountCode = reader["ExpenseAccountCode"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                WaitBudgetSourceCode = reader["WaitBudgetSourceCode"].AsString(),
                CapitalAllocateCode = reader["CapitalAllocateCode"].AsString(),
                FromDate = reader["FromDate"].AsDateTime(),
                ToDate = reader["ToDate"].AsDateTime(),
            };

        /// <summary>
        /// Takes the specified CapitalAllocate.
        /// </summary>
        /// <param name="capitalAllocate">The CapitalAllocate.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(CapitalAllocateEntity capitalAllocate)
        {
            return new object[]  
            {
                "@CapitalAllocateID", capitalAllocate.CapitalAllocateId,
                "@BudgetItemCode", capitalAllocate.BudgetItemCode,
                "@BudgetSourceCode", capitalAllocate.BudgetSourceCode,
                "@ActivityID", capitalAllocate.Activityid,
                "@AllocatePercent", capitalAllocate.AllocatePercent,
                "@AllocateType", capitalAllocate.AllocateType,
                "@DeterminedDate", capitalAllocate.DeterminedDate,
                "@CapitalAccountCode", capitalAllocate.CapitalAccountCode,
                "@RevenueAccountCode", capitalAllocate.RevenueAccountCode,
                "@ExpenseAccountCode", capitalAllocate.ExpenseAccountCode,
                "@Description", capitalAllocate.Description,
                "@IsActive", capitalAllocate.IsActive,
                "@WaitBudgetSourceCode", capitalAllocate.WaitBudgetSourceCode,
                "@CapitalAllocateCode", capitalAllocate.CapitalAllocateCode,
                "@FromDate", capitalAllocate.FromDate,
                "@ToDate", capitalAllocate.ToDate,
            };
        }

        /// <summary>
        /// Gets CapitalAllocates.
        /// </summary>
        /// <returns>List{CapitalAllocateEntity}.</returns>
        public List<CapitalAllocateEntity> GetCapitalAllocatesByActive()
        {
            const string procedures = @"uspGet_CapitalAllocate_ByActive";
            return Db.ReadList(procedures, true, Make);
        }


        public List<CapitalAllocateEntity> GetCapitalAllocatesByCapitalAllocateCode(string capitalAllocateCode)
        {
            const string sql = @"uspGet_CapitalAllocate_ByCode";

            object[] parms = { "@CapitalAllocateCode", capitalAllocateCode }; 
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<CapitalAllocateEntity> GetCapitalAllocatesByDate(DateTime fromDate, DateTime toDate)
        {
            const string sql = @"uspGet_CapitalAllocate_ByDate";

            object[] parms = { "@FromDate", fromDate, 
                             "@ToDate", toDate};
            return Db.ReadList(sql, true, Make, parms);
        }
    }
}
