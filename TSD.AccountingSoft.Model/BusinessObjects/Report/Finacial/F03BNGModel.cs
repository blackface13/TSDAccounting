/***********************************************************************
 * <copyright file="F03BNGModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Saturday, August 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class F03BNGModel
    {
        public string BudgetItemId { get; set; }
        public string ParentId { get; set; }
        public int Grade { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string Content { get; set; }
        public decimal ThisMonthAutonomyBudgetAmount { get; set; }
        public decimal ThisMonthNonAutonomyBudgetAmount { get; set; }
        public decimal ThisMonthProjectBudgetAmount { get; set; }
        public decimal ThisMonthAutonomyOtherAmount { get; set; }
        public decimal ThisMonthNonAutonomyOtherAmount { get; set; }
        public decimal ThisMonthRegulateOtherAmount { get; set; }
        public decimal ThisMonthDiplomaticBudgetAmount { get; set; }
        public decimal ThisMonthTotalAmount { get; set; }
        public decimal AccumulatedAutonomyBudgetAmount { get; set; }
        public decimal AccumulatedNonAutonomyBudgetAmount { get; set; }
        public decimal AccumulatedProjectBudgetAmount { get; set; }
        public decimal AccumulatedAutonomyOtherAmount { get; set; }
        public decimal AccumulatedNonAutonomyOtherAmount { get; set; }
        public decimal AccumulatedRegulateOtherAmount { get; set; }
        public decimal AccumulatedDiplomaticBudgetAmount { get; set; }
        public decimal AccumulatedTotalAmount { get; set; }
        public byte BudgetItemType { get; set; }
        public string FontStyle { get; set; }
    }
}
