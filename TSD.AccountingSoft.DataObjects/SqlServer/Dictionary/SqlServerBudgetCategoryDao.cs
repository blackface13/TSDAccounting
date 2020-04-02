/***********************************************************************
 * <copyright file="SqlServerBudgetCategoryDao.cs" company="BUCA JSC">
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
    /// Class SqlServerBudgetCategoryDao.
    /// </summary>
    public class SqlServerBudgetCategoryDao : IBudgetCategoryDao
    {

        /// <summary>
        /// Gets the budgetCategory.
        /// </summary>
        /// <param name="budgetCategoryId">The budgetCategory identifier.</param>
        /// <returns>BudgetCategoryEntity.</returns>
        public BudgetCategoryEntity GetBudgetCategory(int budgetCategoryId)
        {
            const string sql = @"uspGet_BudgetCategory_ByID";

            object[] parms = { "@BudgetCategoryID", budgetCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetCategorys for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The budgetCategory identifier.</param>
        /// <returns>List{BudgetCategoryEntity}.</returns>
        public List<BudgetCategoryEntity> GetBudgetCategoriesForComboTree(int budgetCategoryId)
        {
            const string sql = @"uspGet_BudgetCategory_ForComboTreee";

            object[] parms = { "@BudgetCategoryID", budgetCategoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the budgetCategorys.
        /// </summary>
        /// <returns>List{BudgetCategoryEntity}.</returns>
        public List<BudgetCategoryEntity> GetBudgetCategories()
        {
            const string procedures = @"uspGet_All_BudgetCategory";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{BudgetCategoryEntity}.</returns>
        public List<BudgetCategoryEntity> GetBudgetCategoriesByActive(bool isActive)
        {
            const string procedures = @"uspGet_BudgetCategory_ByActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budgetCategory.
        /// </summary>
        /// <param name="budgetCategory">The budgetCategory.</param>
        /// <returns>System.Int32.</returns>
        public int InsertBudgetCategory(BudgetCategoryEntity budgetCategory)
        {
            const string sql = "uspInsert_BudgetCategory";
            return Db.Insert(sql, true, Take(budgetCategory));
        }

        /// <summary>
        /// Updates the budgetCategory.
        /// </summary>
        /// <param name="budgetCategory">The budgetCategory.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetCategory(BudgetCategoryEntity budgetCategory)
        {
            const string sql = "uspUpdate_BudgetCategory";
            return Db.Update(sql, true, Take(budgetCategory));
        }

        /// <summary>
        /// Deletes the budgetCategory.
        /// </summary>
        /// <param name="budgetCategory">The budgetCategory.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetCategory(BudgetCategoryEntity budgetCategory)
        {
            const string sql = @"uspDelete_BudgetCategory";

            object[] parms = { "@BudgetCategoryID", budgetCategory.BudgetCategoryId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetCategoryEntity> Make = reader =>
            new BudgetCategoryEntity
            {
                BudgetCategoryId = reader["BudgetCategoryID"].AsInt(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BudgetCategoryName = reader["BudgetCategoryName"].AsString(),
                ParentId = reader["ParentID"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                Description = reader["Description"].AsString(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                Grade = reader["Grade"].AsInt(),
                ForeignName = reader["ForeignName"].AsString()
            };

        /// <summary>
        /// Takes the specified budget category.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(BudgetCategoryEntity budgetCategory)
        {
            return new object[]  
            {
                "@BudgetCategoryID", budgetCategory.BudgetCategoryId,
                "@BudgetCategoryCode", budgetCategory.BudgetCategoryCode,
                "@BudgetCategoryName", budgetCategory.BudgetCategoryName,
                "@ParentID", budgetCategory.ParentId,
                "@IsParent",budgetCategory.IsParent,
                "@Description", budgetCategory.Description,
                "@IsSystem", budgetCategory.IsSystem,
                "@IsActive", budgetCategory.IsActive,
                "@Grade", budgetCategory.Grade,
                "@ForeignName", budgetCategory.ForeignName
            };
        }
    }
}
