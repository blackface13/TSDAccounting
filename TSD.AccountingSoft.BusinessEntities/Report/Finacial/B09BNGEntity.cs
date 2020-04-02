/***********************************************************************
 * <copyright file="B09BNGEntity.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    public class B09BNGEntity
    {
        public string ItemId { get; set; }
        public string ParentId { get; set; }
        public int Grade { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public decimal AccumulatedAmount { get; set; }
        public string FontStyle { get; set; }
        public int QuarterB09 { get; set; }
    }
}
