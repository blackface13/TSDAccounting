/***********************************************************************
 * <copyright file="AutoBusinessModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// AutoBusinessModel
    /// </summary>
    public class AutoBusinessModel
    {
        public int AutoBusinessId { get; set; }

        public string AutoBusinessCode { get; set; }

        public string AutoBusinessName { get; set; }

        public int RefTypeId { get; set; }

        public int? VoucherTypeId { get; set; }

        public string DebitAccountNumber { get; set; }

        public string CreditAccountNumber { get; set; }

        public string BudgetSourceCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string Description { get; set; }

        public string CurrencyCode { get; set; }

        public bool IsActive { get; set; }
    }
}
