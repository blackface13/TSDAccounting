/***********************************************************************
 * <copyright file="SqlServerBudgetSourceCategoryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerBudgetSourceCategoryDao
    /// </summary>
    public class SqlServerBudgetSourceCategoryDao : IBudgetSourceCategoryDao
    {
        /// <summary>
        /// Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns></returns>
        public BudgetSourceCategoryEntity GetBudgetSourceCategory(int budgetSourceCategoryId)
        {
            const string sql = @"uspGet_BudgetSourceCategory_ByID";

            object[] parms = { "@BudgetSourceCategoryID", budgetSourceCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategories()
        {
            const string procedures = @"uspGet_All_BudgetSourceCategory";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budgetSourceCategories by budgetSourceCategory code.
        /// </summary>
        /// <param name="budgetSourceCategoryCode">The budgetSourceCategory code.</param>
        /// <returns></returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategoriesByBudgetSourceCategoryCode(string budgetSourceCategoryCode)
        {
            const string sql = @"uspGet_BudgetSourceCategory_ByBudgetSourceCategoryCode";

            object[] parms = { "@BudgetSourceCategoryCode", budgetSourceCategoryCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetSourceCategories by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetSourceCategoryEntity> GetBudgetSourceCategoriesByActive(bool isActive)
        {
            const string sql = @"uspGet_BudgetSourceCategory_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        public int InsertBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            const string sql = @"uspInsert_BudgetSourceCategory";
            return Db.Insert(sql, true, Take(budgetSourceCategory));
        }

        /// <summary>
        /// Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        public string UpdateBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            const string sql = @"uspUpdate_BudgetSourceCategory";
            return Db.Update(sql, true, Take(budgetSourceCategory));
        }

        /// <summary>
        /// Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        public string DeleteBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            const string sql = @"uspDelete_BudgetSourceCategory";

            object[] parms = { "@BudgetSourceCategoryId", budgetSourceCategory.BudgetSourceCategoryId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetSourceCategoryEntity> Make = reader =>
            new BudgetSourceCategoryEntity
            {
                BudgetSourceCategoryId = reader["BudgetSourceCategoryID"].AsInt(),
                BudgetSourceCategoryCode = reader["BudgetSourceCategoryCode"].AsString(),
                BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                IsSummaryEstimateReport = reader["IsSummaryEstimateReport"].AsBool()
            };

        /// <summary>
        /// Takes the specified budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        private static object[] Take(BudgetSourceCategoryEntity budgetSourceCategory)
        {
            return new object[]  
            {
                "@BudgetSourceCategoryID", budgetSourceCategory.BudgetSourceCategoryId,
                "@BudgetSourceCategoryCode", budgetSourceCategory.BudgetSourceCategoryCode,
                "@BudgetSourceCategoryName", budgetSourceCategory.BudgetSourceCategoryName,
                "@Description", budgetSourceCategory.Description,
                "@IsActive", budgetSourceCategory.IsActive,
                "@IsSummaryEstimateReport", budgetSourceCategory.IsSummaryEstimateReport
            };
        }
    }
}
