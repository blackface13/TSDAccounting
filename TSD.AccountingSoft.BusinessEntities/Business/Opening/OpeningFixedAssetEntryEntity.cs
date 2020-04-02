/***********************************************************************
 * <copyright file="FixedAssetIncrementEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace TSD.AccountingSoft.BusinessEntities.Business.Opening
{
    /// <summary>
    /// 
    /// </summary>
    public class OpeningFixedAssetEntryEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningFixedAssetEntryEntity" /> class.
        /// </summary>
        public OpeningFixedAssetEntryEntity()
        {
            //AddRule(new ValidateRequired("RefTypeId"));
            //AddRule(new ValidateRequired("RefNo"));
            //AddRule(new ValidateRequired("RefDate"));
            //AddRule(new ValidateRequired("PostedDate"));
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningFixedAssetEntryEntity" /> class.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <param name="incrementDate">The increment date.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="usedDate">The used date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="orgPriceAccount">The org price account.</param>
        /// <param name="orgPriceDebitAmount">The org price debit amount.</param>
        /// <param name="orgPriceDebitAmountUSD">The org price debit amount usd.</param>
        /// <param name="depreciationAccount">The depreciation account.</param>
        /// <param name="depreciationCreditAmount">The depreciation credit amount.</param>
        /// <param name="depreciationCreditAmountUSD">The depreciation credit amount usd.</param>
        /// <param name="capitalAccount">The capital account.</param>
        /// <param name="capitalCreditAmount">The capital credit amount.</param>
        /// <param name="capitalCreditAmountUSD">The capital credit amount usd.</param>
        /// <param name="remainingAmount">The remaining amount.</param>
        /// <param name="remainingAmountUSD">The remaining amount usd.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="description">The description.</param>
        /// <param name="quantity">The quantity.</param>
        public OpeningFixedAssetEntryEntity(int? accountId, int? parentId, string accountNumber, string accountName, decimal amountOc, decimal amountExchange,  
                            long refId, string refNo, DateTime postedDate, int refTypeId, int fixedAssetId, int departmentId, int lifeTime,
                             DateTime incrementDate, string unit, DateTime usedDate, string currencyCode, decimal exchangeRate,
                             string orgPriceAccount, decimal orgPriceDebitAmount, decimal orgPriceDebitAmountUSD,string depreciationAccount,
                               decimal depreciationCreditAmount,decimal depreciationCreditAmountUSD, string capitalAccount, decimal capitalCreditAmount,
                             decimal capitalCreditAmountUSD, decimal remainingAmount, decimal remainingAmountUSD, string budgetChapterCode, string description, int quantity)
        {
            AccountId = accountId;
            ParentId = parentId;
            AccountNumber = accountNumber;
            AccountName = accountName;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            RefId = refId;
            RefNo = refNo;
            RefTypeId = refTypeId;
            PostedDate = postedDate;
            FixedAssetId = fixedAssetId;
            DepartmentId = departmentId;
            LifeTime = lifeTime;
            IncrementDate = incrementDate;
            Unit = unit;
            UsedDate = usedDate;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            OrgPriceAccount = orgPriceAccount;
            OrgPriceDebitAmount = orgPriceDebitAmount;
            OrgPriceDebitAmountUSD = orgPriceDebitAmountUSD;
            DepreciationAccount = depreciationAccount;
            DepreciationCreditAmount = depreciationCreditAmount;
            DepreciationCreditAmountUSD = depreciationCreditAmountUSD;
            CapitalAccount = capitalAccount;
            CapitalCreditAmount = capitalCreditAmount;
            CapitalCreditAmountUSD = capitalCreditAmountUSD;
            RemainingAmount = remainingAmount;
            RemainingAmountUSD = remainingAmountUSD;
            BudgetChapterCode = budgetChapterCode;
            Description = description;
            Quantity = quantity;

        }
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountNumber { get; set; }

        
        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        /// The org price debit amount.
        /// </value>
        public decimal AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount usd.
        /// </summary>
        /// <value>
        /// The org price debit amount usd.
        /// </value>
        public decimal AmountExchange { get; set; }


        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public int LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the increment date.
        /// </summary>
        /// <value>
        /// The increment date.
        /// </value>
        public DateTime IncrementDate { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the used date.
        /// </summary>
        /// <value>
        /// The used date.
        /// </value>
        public DateTime UsedDate { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        public string OrgPriceAccount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        /// The org price debit amount.
        /// </value>
        public decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount usd.
        /// </summary>
        /// <value>
        /// The org price debit amount usd.
        /// </value>
        public decimal OrgPriceDebitAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        public string DepreciationAccount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        /// The depreciation credit amount.
        /// </value>
        public decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount usd.
        /// </summary>
        /// <value>
        /// The depreciation credit amount usd.
        /// </value>
        public decimal DepreciationCreditAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.
        /// </value>
        public string CapitalAccount { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount.
        /// </summary>
        /// <value>
        /// The capital credit amount.
        /// </value>
        public decimal CapitalCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount usd.
        /// </summary>
        /// <value>
        /// The capital credit amount usd.
        /// </value>
        public decimal CapitalCreditAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount usd.
        /// </summary>
        /// <value>
        /// The remaining amount usd.
        /// </value>
        public decimal RemainingAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }
    }
}
