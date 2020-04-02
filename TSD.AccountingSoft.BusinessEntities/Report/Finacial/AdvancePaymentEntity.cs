using System;


namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    /// <summary>
    /// Class S33HEntity.
    /// </summary>
    public class AdvancePaymentEntity
    {
        public int Type { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeID { get; set; }
        public decimal OpeningAmountOC { get; set; }
        public decimal OpeningAmountExchange { get; set; }
        public decimal AdvanceAmountOC { get; set; }
        public decimal AdvanceAmountExchange { get; set; }
        public decimal AdvancePaymentAmountOC { get; set; }
        public decimal AdvancePaymentAmountExchange { get; set; }
        public decimal RemainingAmountOC { get; set; }
        public decimal RemainingAmountExchange { get; set; }

    }
}
