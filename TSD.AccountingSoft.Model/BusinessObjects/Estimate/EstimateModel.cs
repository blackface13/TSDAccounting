using System.Collections.Generic;

namespace TSD.AccountingSoft.Model.BusinessObjects.Estimate
{
    public class EstimateModel
    {
        public long RefId { get; set; }

        public int RefTypeId { get; set; }

        public string RefNo { get; set; }

        public string RefDate { get; set; }

        public string PostedDate { get; set; }

        public int PlanTemplateListId { get; set; }

        public short YearOfPlaning { get; set; }

        public string CurrencyCode { get; set; }

        public float ExchangeRate { get; set; }

        public decimal TotalEstimateAmount { get; set; }

        public decimal NextYearOfTotalEstimateAmount { get; set; }

        public string JournalMemo { get; set; }

        public int? BudgetSourceCategoryId { get; set; }

        public decimal ExchangeRateLastYear { get; set; }

        public decimal ExchangeRateThisYear { get; set; }

        public IList<EstimateDetailModel> EstimateDetails { get; set; }
    }
}
