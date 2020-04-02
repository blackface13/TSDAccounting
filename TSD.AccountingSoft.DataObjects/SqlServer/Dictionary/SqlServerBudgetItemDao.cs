/***********************************************************************
 * <copyright file="SqlServerBudgetItemDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
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
    /// Class SqlServerBudgetItemDao.
    /// </summary>
    public class SqlServerBudgetItemDao : IBudgetItemDao
    {
        /// <summary>
        /// Gets the Budget item.
        /// </summary>
        /// <param name="budgetItemId">The Budget item identifier.</param>
        /// <returns>BudgetItemEntity.</returns>
        public BudgetItemEntity GetBudgetItem(int budgetItemId)
        {
            const string sql = @"uspGet_BudgetItem_ByID";

            object[] parms = { "@BudgetItemID", budgetItemId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItems()
        {
            const string procedures = @"uspGet_All_BudgetItem";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the Budget items for combo tree.
        /// </summary>
        /// <param name="budgetItemId">The Budget item identifier.</param>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItemsForComboTree(int budgetItemId)
        {
            const string sql = @"uspGet_BudgetItem_ForComboTree";

            object[] parms = { "@BudgetItemID", budgetItemId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items active.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItemsActive()
        {
            const string procedures = @"uspGet_BudgetItem_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the Budget items by code.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItemsByCode(string budgetItemCode)
        {
            const string procedures = @"uspGet_BudgetItem_ByCode";
            object[] parms = { "@BudgetItemCode", budgetItemCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the Budget items active.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItemsByIsReceipt(bool isReceipt)
        {
            const string procedures = @"uspGet_BudgetItem_By_IsReceipt";
            object[] parms = { "@IsReceipt", isReceipt };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the budget items by capital allocate.
        /// </summary>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByCapitalAllocate()
        {
            const string procedures = @"uspGet_BudgetItemByCapitalAllocate";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget items by pay voucher.
        /// </summary>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByPayVoucher()
        {
            const string procedures = @"uspGet_BudgetItem_For_PayVoucher";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget items by is receipt for estimate.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByIsReceiptForEstimate(bool isReceipt)
        {
            //const string procedures = @"uspGet_BudgetItem_By_IsReceipt_For_Estimate";
            const string procedures = @"uspGet_BudgetItem_For_ReceiptEstimate";
            object[] parms = { "@IsReceipt", isReceipt };
            return Db.ReadList(procedures, true, MakeForReceipt, parms);
        }

        /// <summary>
        /// Gets the budget item and sub items.
        /// </summary>
        /// <param name="isBudgetItemType">Type of the is budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemAndSubItems(int isBudgetItemType, bool isActive)
        {
            const string procedures = @"uspGet_BudgetItem_AndSubItem";
            object[] parms = { "@BudgetItemType", isBudgetItemType, "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.Int32.</returns>
        public int InsertBudgetItem(BudgetItemEntity budgetItem)
        {
            const string sql = "uspInsert_BudgetItem";
            return Db.Insert(sql, true, Take(budgetItem));
        }

        /// <summary>
        /// Updates the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.String.</returns>
        public string UpdateBudgetItem(BudgetItemEntity budgetItem)
        {
            const string sql = "uspUpdate_BudgetItem";
            return Db.Update(sql, true, Take(budgetItem));
        }

        /// <summary>
        /// Deletes the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.String.</returns>
        public string DeleteBudgetItem(BudgetItemEntity budgetItem)
        {
            const string sql = @"uspDelete_BudgetItem";

            object[] parms = { "@BudgetItemID", budgetItem.BudgetItemId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List{BudgetItemEntity}.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BudgetItemEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the budget item by type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>List{BudgetItemEntity}.</returns>
        public List<BudgetItemEntity> GetBudgetItems(int type)
        {
            const string sql = @"uspGet_BudgetItem_ByType";
            object[] parms = { "@BudgetItemType", type };
            return Db.ReadList(sql, true, Make, parms);
        }

        private static readonly Func<IDataReader, BudgetItemEntity> Make = reader => new BudgetItemEntity
        {
            BudgetItemId = reader["BudgetItemID"].AsInt(),
            BudgetGroupId = reader["BudgetGroupID"].AsIntForNull(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            ParentId = reader["ParentID"].AsIntForNull(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            ForeignName = reader["ForeignName"].AsString(),
            IsParent = reader["IsParent"].AsBool(),
            IsFixedItem = reader["IsFixedItem"].AsBool(),
            IsExpandItem = reader["IsExpandItem"].AsBool(),
            IsNoAllocate = reader["IsNoAllocate"].AsBool(),
            IsOrganItem = reader["IsOrganItem"].AsBool(),
            IsActive = reader["IsActive"].AsBool(),
            BudgetItemType = reader["BudgetItemType"].AsInt(),
            IsReceipt = reader["IsReceipt"].AsBool(),
            Rate = reader["Rate"].AsDecimal(),
            IsShowOnVoucher = reader["IsShowOnVoucher"].AsBool()
        };

        private static readonly Func<IDataReader, BudgetItemEntity> MakeForReceipt = reader => new BudgetItemEntity
        {
            BudgetItemId = reader["BudgetItemID"].AsInt(),
            BudgetGroupId = reader["BudgetGroupID"].AsIntForNull(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            ParentId = reader["ParentID"].AsIntForNull(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            ForeignName = reader["ForeignName"].AsString(),
            IsParent = reader["IsParent"].AsBool(),
            IsFixedItem = reader["IsFixedItem"].AsBool(),
            IsExpandItem = reader["IsExpandItem"].AsBool(),
            IsNoAllocate = reader["IsNoAllocate"].AsBool(),
            IsOrganItem = reader["IsOrganItem"].AsBool(),
            IsActive = reader["IsActive"].AsBool(),
            BudgetItemType = reader["BudgetItemType"].AsInt(),
            IsReceipt = reader["IsReceipt"].AsBool(),
            Rate = reader["Rate"].AsDecimal(),
            NumberOrder = reader["NumberOrder"].AsString(),
            IsShowOnVoucher = reader["IsShowOnVoucher"].AsBool()
        };

        /// <summary>
        /// Takes the specified Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(BudgetItemEntity budgetItem)
        {
            return new object[]
            {
                "@BudgetItemID", budgetItem.BudgetItemId,
                "@BudgetGroupID", budgetItem.BudgetGroupId,
                "@BudgetItemCode", budgetItem.BudgetItemCode,
                "@BudgetItemName", budgetItem.BudgetItemName,
                "@ParentID", budgetItem.ParentId,
                "@ForeignName", budgetItem.ForeignName,
                "@IsFixedItem",budgetItem.IsFixedItem,
                "@IsExpandItem",budgetItem.IsExpandItem,
                "@IsNoAllocate",budgetItem.IsNoAllocate,
                "@IsOrganItem",budgetItem.IsOrganItem,
                "@IsActive", budgetItem.IsActive,
                "@IsReceipt",budgetItem.IsReceipt,
                "@IsSystem",budgetItem.IsSystem,
                "@BudgetItemType",budgetItem.BudgetItemType,
                "@Grade",budgetItem.Grade,
                "@IsParent",budgetItem.IsParent,
                "@Rate",budgetItem.Rate,
                "@IsShowOnVoucher",budgetItem.IsShowOnVoucher
            };
        }
    }
}
