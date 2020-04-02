/***********************************************************************
 * <copyright file="SqlServerEstimateDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataHelpers;
using System.Data;
using System;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// SqlServerEstimateDao
    /// </summary>
    public class SqlServerEstimateDao : IEstimateDao
    {
        public EstimateEntity GetEstimate(long refId)
        {
            const string procedures = @"uspGet_Estimate_ByID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        public EstimateEntity CheckConstraintPlanTemplateList(int planTemplateListId)
        {
            const string sql = @"uspCheckConstraint_PlanTemplateList";
            object[] parms = { "@PlanTemplateListID", planTemplateListId };
            return Db.Read(sql, true, Make, parms);
        }

        public List<EstimateEntity> GetEstimatesByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_Estimate_ByRefType";

            object[] parms = { "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<EstimateEntity> GetEstimates()
        {
            const string procedures = @"uspGet_All_Estimate";
            return Db.ReadList(procedures, true, Make);
        }

        public List<EstimateEntity> GetEstimatesByYearOfRefDate(int refTypeId, short yearOfRefDate)
        {
            const string procedures = @"uspGet_Estimates_By_YearOfRefDate";
            object[] parms = { "@YearOfRefDate", yearOfRefDate, "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<EstimateEntity> GetEstimatesByYearOfPlaning(int refTypeId, short yearOfPlaning)
        {
            const string procedures = @"uspGet_Estimates_By_YearOfPlaning";
            object[] parms = { "@YearOfPlaning", yearOfPlaning, "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<EstimateEntity> GetEstimatesByYearOfPlaning(int refTypeId, short yearOfPlaning, int budgetSourceCategoryId)
        {
            const string procedures = @"uspGet_Estimates_By_YearOfPlaning_AND_BudgetSourceCategoryID";
            object[] parms = { "@YearOfPlaning", yearOfPlaning, "@RefTypeID", refTypeId, "@BudgetSourceCategoryID", budgetSourceCategoryId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InsertEstimate(EstimateEntity estimate)
        {
            const string sql = @"uspInsert_Estimate";
            return Db.Insert(sql, true, Take(estimate));
        }

        public string UpdateEstimate(EstimateEntity estimate)
        {
            const string sql = @"uspUpdate_Estimate";
            return Db.Update(sql, true, Take(estimate));
        }

        public string DeleteEstimate(EstimateEntity estimate)
        {
            const string sql = @"uspDelete_Estimate";

            object[] parms = { "@RefID", estimate.RefId };
            return Db.Delete(sql, true, parms);
        }

        private static readonly Func<IDataReader, EstimateEntity> Make = reader => new EstimateEntity
        {
            RefId = reader["RefID"].AsLong(),
            RefTypeId = reader["RefTypeID"].AsInt(),
            RefNo = reader["RefNo"].AsString(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            PlanTemplateListId = reader["PlanTemplateListID"].AsInt(),
            YearOfPlaning = reader["YearOfPlaning"].AsShort(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsFloat(),
            TotalEstimateAmount = reader["TotalEstimateAmount"].AsDecimal(),
            NextYearOfTotalEstimateAmount = reader["NextYearOfTotalEstimateAmount"].AsDecimal(),
            JournalMemo = reader["JournalMemo"].AsString(),
            BudgetSourceCategoryId = reader["BudgetSourceCategoryId"].AsString().AsIntForNull(),
            ExchangeRateLastYear = reader["ExchangeRateLastYear"].AsDecimal(),
            ExchangeRateThisYear = reader["ExchangeRateThisYear"].AsDecimal()
        };

        private object[] Take(EstimateEntity estimate)
        {
            return new object[]
            {
                "@RefId", estimate.RefId,
                "@RefTypeId", estimate.RefTypeId,
                "@RefNo", estimate.RefNo,
                "@RefDate", estimate.RefDate,
                "@PostedDate", estimate.PostedDate,
                "@PlanTemplateListId", estimate.PlanTemplateListId,
                "@YearOfPlaning", estimate.YearOfPlaning,
                "@CurrencyCode", estimate.CurrencyCode,
                "@ExchangeRate", estimate.ExchangeRate,
                "@TotalEstimateAmount", estimate.TotalEstimateAmount,
                "@NextYearOfTotalEstimateAmount", estimate.NextYearOfTotalEstimateAmount,
                "@JournalMemo", estimate.JournalMemo,
                "@BudgetSourceCategoryID", estimate.BudgetSourceCategoryId,
                "@ExchangeRateLastYear", estimate.ExchangeRateLastYear,
                "@ExchangeRateThisYear", estimate.ExchangeRateThisYear
            };
        }
    }
}