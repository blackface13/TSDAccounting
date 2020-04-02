/***********************************************************************
 * <copyright file="SqlServerEstimateDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// SqlServerEstimateDetailDao
    /// </summary>
    public class SqlServerEstimateDetailDao : IEstimateDetailDao
    {
        /// <summary>
        /// Gets the estimate details by estimate.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<EstimateDetailEntity> GetEstimateDetailsByEstimate(long refId)
        {
            const string procedures = @"uspGet_EstimateDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, MakeIncludeName, parms);
        }

        /// <summary>
        /// Gets the estimate details by estimate include budget item name.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<EstimateDetailEntity> GetEstimateDetailsByEstimateIncludeBudgetItemName(long refId)
        {
            const string procedures = @"uspGet_EstimateDetail_ByMaster_IncludeBudgetItemName";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, MakeIncludeName, parms);
        }


        public List<EstimateDetailEntity> GetEstimateDetailsByEstimateOption(long refId, int option, int budgetSourceCategoryId, int yearOfPlaning)
        {
            const string procedures = @"uspGet_EstimateDetail_ByMaster_OptionUpdate";

            object[] parms = { "@RefID", refId, "@Option", option, "@BudgetSourceCategoryID", budgetSourceCategoryId, "@YearOfPlaning", yearOfPlaning };
            return Db.ReadList(procedures, true, MakeIncludeName, parms);
        }

        public List<EstimateDetailEntity> GetEstimateDetailsByEstimateOption(int planTemplateListId)
        {
            const string procedures = @"uspPaymentEstimateDetail";

            object[] parms = { "@PlanTemplateListId", planTemplateListId };
            return Db.ReadList(procedures, true, MakeInclude, parms);
        }

        /// <summary>
        /// Inserts the estimate detail.
        /// </summary>
        /// <param name="estimateDetail">The estimate detail.</param>
        /// <returns></returns>
        public int InsertEstimateDetail(EstimateDetailEntity estimateDetail)
        {
            const string sql = @"uspInsert_EstimateDetail";
            return Db.Insert(sql, true, Take(estimateDetail));
        }

        /// <summary>
        /// LINHMC - 21/8/2015
        /// Updates the estimate detail.
        /// </summary>
        /// <param name="estimateDetail">The estimate detail.</param>
        /// <returns></returns>
        public string UpdateEstimateDetail(EstimateDetailEntity estimateDetail)
        {
            const string sql = @"uspUpdate_EstimateDetail";
            return Db.Update(sql, true, Take(estimateDetail));
        }

        /// <summary>
        /// Deletes the estimate detail by estimate identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteEstimateDetailByRefId(long refId)
        {
            const string procedures = @"uspDelete_EstimateDetail_By_RefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EstimateDetailEntity> MakeIncludeName = reader => new EstimateDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            RefId = reader["RefID"].AsLong(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            PreviousYearOfEstimateAmount = reader["PreviousYearOfEstimateAmount"].AsDecimal(),
            PreviousYearOfEstimateAmountUSD = reader["PreviousYearOfEstimateAmountUSD"].AsDecimal(),
            TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
            YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
            NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
            AutonomyBudget = reader["AutonomyBudget"].AsDecimal(),
            NonAutonomyBudget = reader["NonAutonomyBudget"].AsDecimal(),
            TotalNextYearOfEstimateAmount = reader["TotalNextYearOfEstimateAmount"].AsDecimal(),
            Description = reader["Description"].AsString(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            PreviousYearOfAutonomyBudget = reader["PreviousYearOfAutonomyBudget"].AsDecimal(),
            PreviousYearOfNonAutonomyBudget = reader["PreviousYearOfNonAutonomyBudget"].AsDecimal(),
            YearOfAutonomyBudget = reader["YearOfAutonomyBudget"].AsDecimal(),
            YearOfNonAutonomyBudget = reader["YearOfNonAutonomyBudget"].AsDecimal(),
            SixMonthBeginingAutonomyBudget = reader["SixMonthBeginingAutonomyBudget"].AsDecimal(),
            SixMonthBeginingNonAutonomyBudget = reader["SixMonthBeginingNonAutonomyBudget"].AsDecimal(),
            TotalAmountSixMonthBegining = reader["TotalAmountSixMonthBegining"].AsDecimal(),
            SixMonthEndingAutonomyBudget = reader["SixMonthEndingAutonomyBudget"].AsDecimal(),
            SixMonthEndingNonAutonomyBudget = reader["SixMonthEndingNonAutonomyBudget"].AsDecimal(),
            TotalAmountSixMonthEnding = reader["TotalAmountSixMonthEnding"].AsDecimal(),
            PreviousYeaOfAutonomyBudgetBalance = reader["PreviousYeaOfAutonomyBudgetBalance"].AsDecimal(),
            PreviousYeaOfNonAutonomyBudgetBalance = reader["PreviousYeaOfNonAutonomyBudgetBalance"].AsDecimal(),
            TotalPreviousYearBalance = reader["TotalPreviousYearBalance"].AsDecimal(),
            ThisYearOfAutonomyBudget = reader["ThisYearOfAutonomyBudget"].AsDecimal(),
            ThisYearOfNonAutonomyBudget = reader["ThisYearOfNonAutonomyBudget"].AsDecimal(),
            TotalAmountThisYear = reader["TotalAmountThisYear"].AsDecimal(),
            ItemCodeList = reader["ItemCodeList"].AsString(),
            NumberOrder = reader["NumberOrder"].AsString(),
            FontStyle = reader["FontStyle"].AsString()
        };

        private static readonly Func<IDataReader, EstimateDetailEntity> MakeInclude= reader => new EstimateDetailEntity
        {
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            PreviousYearOfAutonomyBudget = reader["PreviousYearOfAutonomyBudget"].AsDecimal(),
            PreviousYearOfNonAutonomyBudget = reader["PreviousYearOfNonAutonomyBudget"].AsDecimal(),
            TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
            SixMonthBeginingAutonomyBudget = reader["SixMonthBeginingAutonomyBudget"].AsDecimal(),
            SixMonthBeginingNonAutonomyBudget = reader["SixMonthBeginingNonAutonomyBudget"].AsDecimal(),
            TotalAmountSixMonthBegining = reader["TotalAmountSixMonthBegining"].AsDecimal(),
            SixMonthEndingAutonomyBudget = reader["SixMonthEndingAutonomyBudget"].AsDecimal(),
            SixMonthEndingNonAutonomyBudget = reader["SixMonthEndingNonAutonomyBudget"].AsDecimal(),
            TotalAmountSixMonthEnding = reader["TotalAmountSixMonthEnding"].AsDecimal(),
            ThisYearOfAutonomyBudget = reader["ThisYearOfAutonomyBudget"].AsDecimal(),
            ThisYearOfNonAutonomyBudget = reader["ThisYearOfNonAutonomyBudget"].AsDecimal(),
            TotalAmountThisYear = reader["TotalAmountThisYear"].AsDecimal(),
        };

        /// <summary>
        /// Takes the specified estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        private static object[] Take(EstimateDetailEntity estimate)
        {
            return new object[]
            {
                "@RefDetailID", estimate.RefDetailId,
                "@RefID", estimate.RefId,
                "@BudgetItemCode", estimate.BudgetItemCode,
                "@PreviousYearOfEstimateAmount", estimate.PreviousYearOfEstimateAmount,
                "@PreviousYearOfEstimateAmountUSD", estimate.PreviousYearOfEstimateAmountUSD,
                "@TotalEstimateAmountUSD", estimate.TotalEstimateAmountUSD,
                "@YearOfEstimateAmount", estimate.YearOfEstimateAmount,
                "@NextYearOfEstimateAmount", estimate.NextYearOfEstimateAmount,
                "@AutonomyBudget", estimate.AutonomyBudget,
                "@NonAutonomyBudget", estimate.NonAutonomyBudget,
                "@TotalNextYearOfEstimateAmount", estimate.TotalNextYearOfEstimateAmount,
                "@Description", estimate.Description,
                "@PreviousYearOfAutonomyBudget",estimate.PreviousYearOfAutonomyBudget,
                "@PreviousYearOfNonAutonomyBudget",estimate.PreviousYearOfNonAutonomyBudget,
                "@YearOfAutonomyBudget",estimate.YearOfAutonomyBudget,
                "@YearOfNonAutonomyBudget",estimate.YearOfNonAutonomyBudget,
                "@SixMonthBeginingAutonomyBudget",estimate.SixMonthBeginingAutonomyBudget,
                "@SixMonthBeginingNonAutonomyBudget",estimate.SixMonthBeginingNonAutonomyBudget,
                "@TotalAmountSixMonthBegining",estimate.TotalAmountSixMonthBegining,
                "@SixMonthEndingAutonomyBudget",estimate.SixMonthEndingAutonomyBudget,
                "@SixMonthEndingNonAutonomyBudget",estimate.SixMonthEndingNonAutonomyBudget,
                "@TotalAmountSixMonthEnding",estimate.TotalAmountSixMonthEnding,
                "@PreviousYeaOfAutonomyBudgetBalance",estimate.PreviousYeaOfAutonomyBudgetBalance,
                "@PreviousYeaOfNonAutonomyBudgetBalance",estimate.PreviousYeaOfNonAutonomyBudgetBalance,
                "@TotalPreviousYearBalance",estimate.TotalPreviousYearBalance,
                "@ThisYearOfAutonomyBudget",estimate.ThisYearOfAutonomyBudget,
                "@ThisYearOfNonAutonomyBudget",estimate.ThisYearOfNonAutonomyBudget,
                "@TotalAmountThisYear",estimate.TotalAmountThisYear,
                "@ItemCodeList",estimate.ItemCodeList
            };
        }



    }
}
