/***********************************************************************
 * <copyright file="AutoBusinessEntity.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// class AutoBusinessEntity
    /// </summary>
    public class AutoBusinessEntity : BusinessEntities
    {
        public AutoBusinessEntity()
        {
            AddRule(new ValidateRequired("AutoBusinessCode"));
            AddRule(new ValidateRequired("AutoBusinessName"));
        }

        public AutoBusinessEntity(int autoBusinessId, string autoBusinessCode, string autoBusinessName, int refTypeId, int? voucherTypeId, string debitAccountNumber, string creditAccountNumber, string budgetSourceCode, string budgetItemCode, string description, string currencyCode, bool isActive)
            : this()
        {
            AutoBusinessId = autoBusinessId;
            AutoBusinessCode = autoBusinessCode;
            AutoBusinessName = autoBusinessName;
            RefTypeId = refTypeId;
            VoucherTypeId = voucherTypeId;
            DebitAccountNumber = debitAccountNumber;
            CreditAccountNumber = creditAccountNumber;
            BudgetSourceCode = budgetSourceCode;
            BudgetItemCode = budgetItemCode;
            Description = description;
            CurrencyCode = currencyCode;
            IsActive = isActive;
        }

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
