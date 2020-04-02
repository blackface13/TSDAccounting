/***********************************************************************
 * <copyright file="DepositEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Deposit
{
    /// <summary>
    /// Class DepositEntity.
    /// </summary>
    public class DepositEntity : BusinessEntities
    {
        public DepositEntity()
        {
            AddRule(new ValidateRequired("RefTypeId"));
            AddRule(new ValidateRequired("RefNo"));
            AddRule(new ValidateRequired("RefDate"));
            AddRule(new ValidateRequired("PostedDate"));
        }

        public DepositEntity(long refId, int refTypeId, DateTime refDate, DateTime postedDate, string refNo,
                             int accountingObjectType, int? accountingObjectId,
                             string trader, int? customerId, int? vendorId, int? employeeId, string bankAccountCode,
                             string currencyCode, decimal exchangeRate, decimal totalAmountOc,
                             decimal totalAmountExchange, string journalMemo,int? bankId)
        {
            RefId = refId;
            RefTypeId = refTypeId;
            RefDate = refDate;
            PostedDate = postedDate;
            RefNo = refNo;
            AccountingObjectType = accountingObjectType;
            AccountingObjectId = accountingObjectId;
            Trader = trader;
            CustomerId = customerId;
            VendorId = vendorId;
            EmployeeId = employeeId;
            BankAccountCode = bankAccountCode;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            TotalAmountOc = totalAmountOc;
            TotalAmountExchange = totalAmountExchange;
            JournalMemo = journalMemo;
            BankId = bankId;
        }

        public long RefId { get; set; }

        public int RefTypeId { get; set; }

        public DateTime? RefDate { get; set; }

        public DateTime? PostedDate { get; set; }

        public string RefNo { get; set; }

        public int? AccountingObjectType { get; set; }

        public int? AccountingObjectId { get; set; }

        public string Trader { get; set; }

        public int? CustomerId { get; set; }

        public int? VendorId { get; set; }

        public int? EmployeeId { get; set; }

        public int? BankId { get; set; }

        public string BankAccountCode { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal TotalAmountOc { get; set; }

        public decimal TotalAmountExchange { get; set; }

        public string JournalMemo { get; set; }

        public bool IsIncludeCharge { get; set; }

        public IList<DepositDetailEntity> DepositDetails { get; set; }

        public IList<DepositDetailParallelEntity> DepositDetailParallels { get; set; }
    }
}
