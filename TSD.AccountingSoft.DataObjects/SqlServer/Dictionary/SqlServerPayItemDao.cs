/***********************************************************************
 * <copyright file="SqlServerPayItemDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// SqlServerPayItemDao
    /// </summary>
    public class SqlServerPayItemDao : IPayItemDao
    {
        public PayItemEntity GetPayItem(int payItemId)
        {
            const string sql = @"uspGet_PayItem_ByID";

            object[] parms = { "@PayItemID", payItemId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the payItems.
        /// </summary>
        /// <returns></returns>
        public List<PayItemEntity> GetPayItems()
        {
            const string procedures = @"uspGet_All_PayItem";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the pay items is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<PayItemEntity> GetPayItemsIsActive(bool isActive)
        {
            const string sql = @"uspGet_PayItem_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the pay items by pay item code.
        /// </summary>
        /// <param name="payItemCode">The pay item code.</param>
        /// <returns></returns>
        public List<PayItemEntity> GetPayItemsByPayItemCode(string payItemCode)
        {
            const string sql = @"uspGet_PayItem_ByPayItemCode";

            object[] parms = { "@PayItemCode", payItemCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the payItem.
        /// </summary>
        /// <param name="payItem">The payItem.</param>
        /// <returns></returns>
        public int InsertPayItem(PayItemEntity payItem)
        {
            const string sql = @"uspInsert_PayItem";
            return Db.Insert(sql, true, Take(payItem));
        }

        /// <summary>
        /// Updates the payItem.
        /// </summary>
        /// <param name="payItem">The payItem.</param>
        /// <returns></returns>
        public string UpdatePayItem(PayItemEntity payItem)
        {
            const string sql = @"uspUpdate_PayItem";
            return Db.Update(sql, true, Take(payItem));
        }

        /// <summary>
        /// Deletes the payItem.
        /// </summary>
        /// <param name="payItem">The payItem.</param>
        /// <returns></returns>
        public string DeletePayItem(PayItemEntity payItem)
        {
            const string sql = @"uspDelete_PayItem";

            object[] parms = { "@PayItemID", payItem.PayItemId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PayItemEntity> Make = reader =>
            new PayItemEntity
            {
                PayItemId = reader["PayItemID"].AsInt(),
                PayItemCode = reader["PayItemCode"].AsString(),
                PayItemName = reader["PayItemName"].AsString(),
                Type = reader["Type"].AsInt(),
                IsCalculateRatio = reader["IsCalculateRatio"].AsBool(),
                IsSocialInsurance = reader["IsSocialInsurance"].AsString().AsBoolForNull(),
                IsCareInsurance = reader["IsCareInsurance"].AsString().AsBoolForNull(),
                IsTradeUnionFee = reader["IsTradeUnionFee"].AsString().AsBoolForNull(),
                Description = reader["Description"].AsString(),
                DebitAccountCode = reader["DebitAccountCode"].AsString(),
                CreditAccountCode = reader["CreditAccountCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                IsDefault = reader["IsDefault"].AsBool(),
                IsActive = reader["IsActive"].AsBool(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetCategoryCode = reader["BudgetCategoryCode"].AsString(),
                BudgetGroupCode = reader["BudgetGroupCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString()
            };

        /// <summary>
        /// Takes the specified pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns></returns>
        private static object[] Take(PayItemEntity payItem)
        {
            return new object[]  
            {
                "@PayItemID", payItem.PayItemId,
                "@PayItemCode", payItem.PayItemCode,
                "@PayItemName", payItem.PayItemName,
                "@Type" , payItem.Type,
                "@IsCalculateRatio", payItem.IsCalculateRatio,
                "@IsSocialInsurance", payItem.IsSocialInsurance,
                "@IsCareInsurance", payItem.IsCareInsurance,
                "@IsTradeUnionFee", payItem.IsTradeUnionFee,
                "@Description", payItem.Description,
                "@DebitAccountCode", payItem.DebitAccountCode,
                "@CreditAccountCode", payItem.CreditAccountCode,
                "@BudgetChapterCode", payItem.BudgetChapterCode,
                "@IsDefault", payItem.IsDefault,
                "@IsActive", payItem.IsActive,
                "@BudgetSourceCode", payItem.BudgetSourceCode,
                "@BudgetCategoryCode", payItem.BudgetCategoryCode,
                "@BudgetGroupCode", payItem.BudgetGroupCode,
                "@BudgetItemCode", payItem.BudgetItemCode
            };
        }
    }
}