/***********************************************************************
 * <copyright file="SqlServerBudgetSourceDao.cs" company="BUCA JSC">
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
    /// Class SqlServerBudgetSourceDao.
    /// </summary>
    public class SqlServerBudgetSourceDao : IBudgetSourceDao
    {
        /// <summary>
        /// Gets the budgetSource.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns>BudgetSourceEntity.</returns>
        public BudgetSourceEntity GetBudgetSource(int budgetSourceId)
        {
            const string sql = @"uspGet_BudgetSource_ByID";

            object[] parms = { "@BudgetSourceID", budgetSourceId };
            return Db.Read(sql, true, Make, parms);
        }

        public BudgetSourceEntity GetBudgetSourceByBudgetSourceCode(string budgetSourceCode)
        {
            const string sql = @"uspGet_BudgetSource_ByBudgetSourceCode";

            object[] parms = { "@BudgetSourceCode", budgetSourceCode };
            return Db.Read(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSourcesByFund()
        {
            const string procedures = @"uspGet_BudgetSource_By_Fund";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budgetSources for combo tree.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSourcesForComboTree(int budgetSourceId)
        {
            const string sql = @"uspGet_BudgetSource_ForComboTreee";

            object[] parms = { "@BudgetSourceID", budgetSourceId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSources()
        {
            const string procedures = @"uspGet_All_BudgetSource";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budgetSources active.
        /// </summary>
        /// <returns>List{BudgetSourceEntity}.</returns>
        public List<BudgetSourceEntity> GetBudgetSourcesActive()
        {
            const string procedures = @"uspGet_BudgetSource_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        public List<BudgetSourceEntity> GetBudgetSourcesIsParent(bool isParent)
        {
            const string procedures = @"uspGet_BudgetSource_ByIsParent";
            object[] parms = { "@IsParent", isParent };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns>System.Int32.</returns>
        public int InsertBudgetSource(BudgetSourceEntity budgetSource)
        {
            const string sql = "uspInsert_BudgetSource";
            return Db.Insert(sql, true, Take(budgetSource));
        }

        /// <summary>
        /// Updates the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetSource(BudgetSourceEntity budgetSource)
        {
            const string sql = "uspUpdate_BudgetSource";
            return Db.Update(sql, true, Take(budgetSource));
        }

        /// <summary>
        /// Deletes the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetSource(BudgetSourceEntity budgetSource)
        {
            const string sql = @"uspDelete_BudgetSource";

            object[] parms = { "@BudgetSourceID", budgetSource.BudgetSourceId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetSourceEntity> Make = reader =>
            new BudgetSourceEntity
            {
                BudgetSourceId = reader["BudgetSourceID"].AsInt(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                ForeignName = reader["ForeignName"].AsString(),
                ParentId = reader["ParentID"].AsString().AsIntForNull(),
                Description = reader["Description"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                Type = reader["Type"].AsInt(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                Allocation = reader["Allocation"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                IsFund = reader["IsFund"].AsBool(),
                IsExpense = reader["IsExpense"].AsBool(),
                AccountCode = reader["AccountCode"].AsString(),
                AutonomyBudgetType = reader["AutonomyBudgetType"].AsString().AsShortForNull(),
                BudgetCode = reader["BudgetCode"].AsInt(),
            };

        /// <summary>
        /// Takes the specified budget source.
        /// </summary>
        /// <param name="budgetSource">The budget source.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(BudgetSourceEntity budgetSource)
        {
            return new object[]
            {
                "@BudgetSourceID", budgetSource.BudgetSourceId,
                "@BudgetSourceCode", budgetSource.BudgetSourceCode,
                "@BudgetSourceName", budgetSource.BudgetSourceName,
                "@ForeignName", budgetSource.ForeignName,
                "@ParentID", budgetSource.ParentId,
                "@Description", budgetSource.Description,
                "@Grade", budgetSource.Grade,
                "@IsParent", budgetSource.IsParent,
                "@Type", budgetSource.Type,
                "@IsSystem", budgetSource.IsSystem,
                "@IsActive", budgetSource.IsActive,
                "@Allocation", budgetSource.Allocation,
                "@BudgetItemCode", budgetSource.BudgetItemCode,
                "@IsFund", budgetSource.IsFund,
                "@IsExpense", budgetSource.IsExpense,
                "@AccountCode", budgetSource.AccountCode,
                "@AutonomyBudgetType", budgetSource.AutonomyBudgetType,
                "BudgetCode", budgetSource.BudgetCode,
            };
        }
    }
}
