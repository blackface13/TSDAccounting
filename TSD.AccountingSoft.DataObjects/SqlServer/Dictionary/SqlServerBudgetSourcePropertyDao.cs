using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerBudgetSourcePropertyDao : IBudgetSourcePropertyDao
    {
        /// <summary>
        /// Gets the budget source property.
        /// </summary>
        /// <param name="budgetSourcePropertyID">The budget source property identifier.</param>
        /// <returns></returns>
        public BudgetSourcePropertyEntity GetBudgetSourceProperty(int budgetSourcePropertyID)
        {
            const string sql = @"Get_BudgetSourceProperty_ByID";

            object[] parms = { "@BudgetSourcePropertyID", budgetSourcePropertyID };
            return Db.Read(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the budget source properties.
        /// </summary>
        /// <returns></returns>
        public List<BudgetSourcePropertyEntity> GetBudgetSourceProperties()
        {
            const string procedures = @"Get_All_BudgetSourceProperty";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the budget source property.
        /// </summary>
        /// <param name="budgetSourceproperty">The budget sourceproperty.</param>
        public int InsertBudgetSourceProperty(BudgetSourcePropertyEntity budgetSourceproperty)
        {
            const string sql = "Insert_BudgetSourceProperty";
            return Db.Insert(sql, true, Take(budgetSourceproperty));
        }

        /// <summary>
        /// Updates the budget source property.
        /// </summary>
        /// <param name="budgetSourceproperty">The budget sourceproperty.</param>
        public string UpdateBudgetSourceProperty(BudgetSourcePropertyEntity budgetSourceproperty)
        {
            const string sql = "Update_BudgetSourceProperty";
            return Db.Update(sql, true, Take(budgetSourceproperty));
        }

        /// <summary>
        /// Deletes the budget source property.
        /// </summary>
        /// <param name="budgetSourceproperty">The budget sourceproperty.</param>
        public string DeleteBudgetSourceProperty(BudgetSourcePropertyEntity budgetSourceproperty)
        {
            const string sql = @"Delete_BudgetSourceProperty";

            object[] parms = { "@BudgetSourcePropertyID", budgetSourceproperty.BudgetSourcePropertyID };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BudgetSourcePropertyEntity> Make = reader =>
            new BudgetSourcePropertyEntity
            {
                BudgetSourcePropertyID = reader["BudgetSourcePropertyID"].AsInt(),
                BudgetSourcePropertyCode = reader["Code"].AsString(),
                BudgetSourcePropertyName = reader["Name"].AsString(),
                Description = reader["Description"].AsString(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };
        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="budgetSourceProperty">The budget source property.</param>
        /// <returns></returns>
        private object[] Take(BudgetSourcePropertyEntity budgetSourceProperty)
        {
            return new object[]  
            {
                "@BudgetSourcePropertyID", budgetSourceProperty.BudgetSourcePropertyID,
                "@Code", budgetSourceProperty.BudgetSourcePropertyCode,
                "@Name", budgetSourceProperty.BudgetSourcePropertyName,
                "@Description", budgetSourceProperty.Description,
                "@IsSystem", budgetSourceProperty.IsSystem,
                "@IsActive", budgetSourceProperty.IsActive
            };
        }
    }
}
