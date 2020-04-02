/***********************************************************************
 * <copyright file="SqlServerFixedAssetCategoryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
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
    public class SqlServerFixedAssetCategoryDao : IFixedAssetCategoryDao
    {

        #region IFixedAssetCategoryDao Members

        /// <summary>
        /// Gets the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        public FixedAssetCategoryEntity GetFixedAssetCategory(int fixedAssetCategoryId)
        {
            const string sql = @"uspGet_FixedAssetCategory_ByID";

            object[] parms = { "@FixedAssetCategoryID", fixedAssetCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset categorys.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetCategoryEntity> GetFixedAssetCategories()
        {
            const string procedures = @"uspGet_All_FixedAssetCategory";
            return Db.ReadList(procedures, true, Make);
        }

        public List<FixedAssetCategoryEntity> GetFixedAssetCategoriesComboCheck()
        {
            const string procedures = @"uspGet_All_FixedAssetCategory_Tree";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the fixed asset categorys for combo tree.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        public List<FixedAssetCategoryEntity> GetFixedAssetCategoriesForComboTree(int fixedAssetCategoryId)
        {
            const string sql = @"uspGet_FixedAssetCategory_ByID";

            object[] parms = { "@FixedAssetCategoryID", fixedAssetCategoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public FixedAssetCategoryEntity GetFixedAssetCategoriesForComboTree(string fixedAssetCategoryCode)
        {
            const string sql = @"uspGet_FixedAssetCategory_ByCode";

            object[] parms = { "@FixedAssetCategoryCode", fixedAssetCategoryCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset categorys active.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetCategoryEntity> GetFixedAssetCategoriesActive()
        {
            const string procedures = @"uspGet_FixedAssetCategory_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns></returns>
        public int InsertFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory)
        {
            const string sql = "uspInsert_FixedAssetCategory";
            return Db.Insert(sql, true, Take(fixedAssetCategory));
        }

        /// <summary>
        /// Updates the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns></returns>
        public string UpdateFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory)
        {
            const string sql = "uspUpdate_FixedAssetCategory";
            return Db.Update(sql, true, Take(fixedAssetCategory));
        }

        /// <summary>
        /// Deletes the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns></returns>
        public string DeleteFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory)
        {
            const string sql = @"uspDelete_FixedAssetCategory";

            object[] parms = { "@FixedAssetCategoryID", fixedAssetCategory.FixedAssetCategoryId };
            return Db.Delete(sql, true, parms);
        }

        #endregion

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetCategoryEntity> Make = reader =>
            new FixedAssetCategoryEntity
            {
                FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsInt(),
                ParentId = reader["ParentID"].AsIntForNull(),
                FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
                FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
                FixedAssetCategoryForeignName = reader["FixedAssetCategoryForeignName"].AsString(),
                DepreciationRate = reader["DepreciationRate"].AsDecimal(),
                LifeTime = reader["LifeTime"].AsDecimal(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                OrgPriceAccountCode = reader["OrgPriceAccountCode"].AsString(),
                DepreciationAccountCode = reader["DepreciationAccountCode"].AsString(),
                CapitalAccountCode = reader["CapitalAccountCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BudgetGroupCode = reader["BudgetGroupCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                Unit = reader["Unit"].AsString()
            };

        /// <summary>
        /// Takes the specified fixedAssetCategory.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixedAssetCategory.</param>
        /// <returns></returns>
        private object[] Take(FixedAssetCategoryEntity fixedAssetCategory)
        {
            return new object[]  
            {
                "@FixedAssetCategoryID", fixedAssetCategory.FixedAssetCategoryId,
                "@ParentID", fixedAssetCategory.ParentId,
                "@FixedAssetCategoryCode", fixedAssetCategory.FixedAssetCategoryCode,
                "@FixedAssetCategoryName", fixedAssetCategory.FixedAssetCategoryName,
                "@FixedAssetCategoryForeignName", fixedAssetCategory.FixedAssetCategoryForeignName,
                "@DepreciationRate", fixedAssetCategory.DepreciationRate,
                "@LifeTime", fixedAssetCategory.LifeTime,
                "@Grade", fixedAssetCategory.Grade,
                "@IsParent", fixedAssetCategory.IsParent,
                "@OrgPriceAccountCode", fixedAssetCategory.OrgPriceAccountCode,
                "@DepreciationAccountCode", fixedAssetCategory.DepreciationAccountCode,
                "@CapitalAccountCode", fixedAssetCategory.CapitalAccountCode,
                "@BudgetChapterCode", fixedAssetCategory.BudgetChapterCode,
                "@BudgetCategoryCode", fixedAssetCategory.BudgetCategoryCode,
                "@BudgetGroupCode", fixedAssetCategory.BudgetGroupCode,
                "@BudgetItemCode", fixedAssetCategory.BudgetItemCode,
                "@IsActive", fixedAssetCategory.IsActive,
                "@Unit", fixedAssetCategory.Unit
            };
        }
    }
}
