/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;


namespace TSD.AccountingSoft.View.Estimate
{
    public interface IPaymentEstimateView : IView
    {
        long RefId { get; set; }

        int RefTypeId { get; set; }

        string RefNo { get; set; }

        string RefDate { get; set; }

        string PostedDate { get; set; }

        int PlanTemplateListId { get; set; }

        short YearOfPlaning { get; set; }

        string CurrencyCode { get; set; }

        float ExchangeRate { get; set; }

        decimal TotalEstimateAmount { get; set; }

        decimal NextYearOfTotalEstimateAmount { get; set; }

        string JournalMemo { get; set; }

        int? BudgetSourceCategoryId { get; set; }

        decimal ExchangeRateLastYear { get; set; }

        decimal ExchangeRateThisYear { get; set; }

        IList<EstimateDetailModel> PaymentEstimateDetails { get; set; }
    }
}
