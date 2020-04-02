/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
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
    /// Class SqlServerPlanTemplateItemDao.
    /// </summary>
    public class SqlServerPlanTemplateItemDao : IPlanTemplateItemDao
    {
        /// <summary>
        /// Gets the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItemId">The PlanTemplateItem identifier.</param>
        /// <returns>PlanTemplateItemEntity.</returns>
        public PlanTemplateItemEntity GetPlanTemplateItem(int planTemplateItemId)
        {
            const string sql = @"uspGet_PlanTemplateItem_ByID";
            object[] parms = { "@PlanTemplateItemID", planTemplateItemId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateListId">The PlanTemplateItem identifier.</param>
        /// <returns>IList{PlanTemplateItemEntity}.</returns>
        public IList<PlanTemplateItemEntity> GetPlanTemplateItemByPlanTemplateList(int planTemplateListId)
        {
            const string sql = @"uspGet_PlanTemplateItem_PlanTemplateListID";
            object[] parms = { "@PlanTemplateListID", planTemplateListId };
            return Db.ReadList(sql, true, MakeIncludeBudgetItem, parms);
        }


        public IList<PlanTemplateItemEntity> GetPlanTemplateItemByPlanTemplateListForEstimate(int planTemplateListId, short planYear, int budgetSourceCategoryId)
        {
            const string sql = @"uspGet_Estimate_PreviousYear";
            object[] parms = { "@PlanTemplateListID", planTemplateListId, "@YearOfPlaning", planYear, "@BudgetSourceCategoryID", budgetSourceCategoryId };
            return Db.ReadList(sql, true, MakeForReceiptEstimate, parms);
        }

        /// <summary>
        /// Gets the PlanTemplateItems.
        /// </summary>
        /// <returns>List{PlanTemplateItemEntity}.</returns>
        public List<PlanTemplateItemEntity> GetPlanTemplateItems()
        {
            const string procedures = @"uspGet_All_PlanTemplateItem";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItem">The PlanTemplateItem.</param>
        /// <returns>System.Int32.</returns>
        public int InsertPlanTemplateItem(PlanTemplateItemEntity planTemplateItem)
        {
            const string sql = "uspInsert_PlanTemplateItem";
            return Db.Insert(sql, true, Take(planTemplateItem));
        }

        /// <summary>
        /// Updates the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItem">The PlanTemplateItem.</param>
        /// <returns>System.String.</returns>
        public string UpdatePlanTemplateItem(PlanTemplateItemEntity planTemplateItem)
        {
            const string sql = "uspUpdate_PlanTemplateItem";
            return Db.Update(sql, true, Take(planTemplateItem));
        }

        /// <summary>
        /// Deletes the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItem">The PlanTemplateItem.</param>
        /// <returns>System.String.</returns>
        public string DeletePlanTemplateItem(PlanTemplateItemEntity planTemplateItem)
        {
            const string sql = @"uspDelete_PlanTemplateItem";
            object[] parms = { "@PlanTemplateItemID", planTemplateItem.PlanTemplateItemId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateListId">The PlanTemplateItem.</param>
        /// <returns>System.String.</returns>
        public string DeletePlanTemplateItemByPlanTemplateListId(int planTemplateListId)
        {
            const string sql = @"uspDelete_PlanTemplateItem_ByPlanTemplateListID";
            object[] parms = { "@PlanTemplateListID", planTemplateListId };
            return Db.Update(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PlanTemplateItemEntity> Make = reader =>
            new PlanTemplateItemEntity
            {
                PlanTemplateListId = reader["PlanTemplateListID"].AsInt(),
                PlanTemplateItemId = reader["PlanTemplateItemID"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PlanTemplateItemEntity> MakeIncludeBudgetItem = reader =>
            new PlanTemplateItemEntity
            {
                PlanTemplateListId = reader["PlanTemplateListID"].AsInt(),
                PlanTemplateItemId = reader["PlanTemplateItemID"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemName = reader["BudgetItemName"].AsString(),
                NumberOrder = reader["NumberOrder"].AsString()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PlanTemplateItemEntity> MakeForEstimate = reader =>
            new PlanTemplateItemEntity
            {
                PlanTemplateListId = reader["PlanTemplateListID"].AsInt(),
                PlanTemplateItemId = reader["PlanTemplateItemID"].AsInt(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetItemName = reader["BudgetItemName"].AsString(),
                PreviousYearOfEstimateAmount = reader["PreviousYearOfEstimateAmount"].AsDecimal(),
                PreviousYearOfEstimateAmountUSD = reader["PreviousYearOfEstimateAmountUSD"].AsDecimal(),
                PreviousYearOfAutonomyBudget = reader["PreviousYearOfAutonomyBudget"].AsDecimal(),
                PreviousYearOfNonAutonomyBudget = reader["PreviousYearOfNonAutonomyBudget"].AsDecimal(),
                SixMonthBeginingAutonomyBudget = reader["SixMonthBeginingAutonomyBudget"].AsDecimal(),
                SixMonthBeginingNonAutonomyBudget = reader["SixMonthBeginingNonAutonomyBudget"].AsDecimal(),
                TotalAmountSixMonthBegining = reader["TotalAmountSixMonthBegining"].AsDecimal(),
                TotalAmountThisYear = reader["TotalAmountThisYear"].AsDecimal()
            };

        private static readonly Func<IDataReader, PlanTemplateItemEntity> MakeForReceiptEstimate = reader =>
        {
            PlanTemplateItemEntity planTemplateItem = new PlanTemplateItemEntity();
            planTemplateItem.PlanTemplateListId = reader["PlanTemplateListID"].AsInt();
            planTemplateItem.PlanTemplateItemId = reader["PlanTemplateItemID"].AsInt();
            planTemplateItem.BudgetItemCode = reader["BudgetItemCode"].AsString();
            planTemplateItem.BudgetItemName = reader["BudgetItemName"].AsString();
            planTemplateItem.PreviousYearOfEstimateAmount = reader["PreviousYearOfEstimateAmount"].AsDecimal();
            planTemplateItem.PreviousYearOfEstimateAmountUSD = reader["PreviousYearOfEstimateAmountUSD"].AsDecimal();
            planTemplateItem.PreviousYearOfAutonomyBudget = reader["PreviousYearOfAutonomyBudget"].AsDecimal();
            planTemplateItem.PreviousYearOfNonAutonomyBudget = reader["PreviousYearOfNonAutonomyBudget"].AsDecimal();
            planTemplateItem.SixMonthBeginingAutonomyBudget = reader["SixMonthBeginingAutonomyBudget"].AsDecimal();
            planTemplateItem.SixMonthBeginingNonAutonomyBudget = reader["SixMonthBeginingNonAutonomyBudget"].AsDecimal();
            planTemplateItem.TotalAmountSixMonthBegining = reader["TotalAmountSixMonthBegining"].AsDecimal();
            planTemplateItem.TotalAmountThisYear = reader["TotalAmountThisYear"].AsDecimal();
            planTemplateItem.ItemCodeList = reader["ItemCodeList"].AsString();
            planTemplateItem.NumberOrder = reader["NumberOrder"].AsString();
            planTemplateItem.FontStyle = reader["FontStyle"].AsString();
            return planTemplateItem;
        };

        /// <summary>
        /// Takes the specified PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateItem.</param>
        /// <returns>System.Object[][].</returns>
        private static object[] Take(PlanTemplateItemEntity planTemplateList)
        {
            return new object[]
            {
                "@PlanTemplateItemID", planTemplateList.PlanTemplateItemId,
                "@PlanTemplateListID", planTemplateList.PlanTemplateListId,
                "@BudgetItemCode", planTemplateList.BudgetItemCode
            };
        }


        public IList<PlanTemplateItemEntity> GetPlanTemplateItemByPlanTemplateListForEstimateUpdate(int planTemplateListId, short planYear, int budgetSourceCategoryId, int option)
        {
            const string sql = @"uspGet_Estimate_PreviousYearAndOption";
            object[] parms = { "@PlanTemplateListID", planTemplateListId, "@YearOfPlaning", planYear, "@BudgetSourceCategoryID", budgetSourceCategoryId, "@Option", option };
            return Db.ReadList(sql, true, MakeForEstimate, parms);
        }
    }
}
