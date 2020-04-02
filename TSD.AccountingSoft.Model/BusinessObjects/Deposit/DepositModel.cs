/***********************************************************************
 * <copyright file="DepositModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.BaseModel;
using System;
using System.Collections.Generic;


namespace TSD.AccountingSoft.Model.BusinessObjects.Deposit
{
    public class DepositModel : BaseVoucherModel
    {
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

        public IList<DepositDetailModel> DepositDetails { get; set; }

        public IList<DepositDetailParallelModel> DepositDetailParallels { get; set; }
    }
}
