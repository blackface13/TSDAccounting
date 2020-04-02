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
    public class F331BNGModel
    {
        public string BudgetItemId { get; set; }
        public string ParentId { get; set; }
        public int Grade { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string Content { get; set; }
        public decimal ThisMonthAmount { get; set; }
        public decimal AccumulatedAmount { get; set; }
        public byte BudgetItemType { get; set; }
        public string FontStyle { get; set; }
    }
}
