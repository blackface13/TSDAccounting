/***********************************************************************
 * <copyright file="PaymentEstimateEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;
using System;


namespace TSD.AccountingSoft.BusinessEntities.Business.Estimate
{
    /// <summary>
    /// EstimateEntity
    /// </summary>
    public class EstimateEntity : BusinessEntities
    {
        public EstimateEntity()
        {
            AddRule(new ValidateRequired("RefTypeId"));
            AddRule(new ValidateRequired("RefNo"));
            AddRule(new ValidateRequired("RefDate"));
            AddRule(new ValidateRequired("PostedDate"));
        }

        public EstimateEntity(long refId, int refTypeId, string refNo, DateTime refDate, DateTime postedDate, int planTemplateListId,
            short yearOfPlaning, string currencyCode, float exchangeRate, decimal totalEstimateAmount, decimal nextYearOfTotalEstimateAmount,
            string journalMemo, int? budgetSourceCategoryId, decimal exchangeRateLastYear, decimal exchangeRateThisYear)
            : this()
        {
            RefId = refId;
            RefTypeId = refTypeId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            PlanTemplateListId = planTemplateListId;
            YearOfPlaning = yearOfPlaning;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            TotalEstimateAmount = totalEstimateAmount;
            NextYearOfTotalEstimateAmount = nextYearOfTotalEstimateAmount;
            JournalMemo = journalMemo;
            BudgetSourceCategoryId = budgetSourceCategoryId;
            ExchangeRateLastYear = exchangeRateLastYear;
            ExchangeRateThisYear = exchangeRateThisYear;
        }

        public long RefId { get; set; }

        public int RefTypeId { get; set; }

        public string RefNo { get; set; }

        public DateTime RefDate { get; set; }

        public DateTime PostedDate { get; set; }

        public int PlanTemplateListId { get; set; }

        public short YearOfPlaning { get; set; }

        public string CurrencyCode { get; set; }

        public float ExchangeRate { get; set; }

        public decimal TotalEstimateAmount { get; set; }

        public decimal NextYearOfTotalEstimateAmount { get; set; }

        public string JournalMemo { get; set; }

        public IList<EstimateDetailEntity> EstimateDetails { get; set; }

        public int? BudgetSourceCategoryId { get; set; }

        public decimal ExchangeRateLastYear { get; set; }

        public decimal ExchangeRateThisYear { get; set; }
    }
}