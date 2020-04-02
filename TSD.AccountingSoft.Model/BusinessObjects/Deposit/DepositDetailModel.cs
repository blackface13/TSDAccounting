/***********************************************************************
 * <copyright file="DepositDetailModel.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.BaseModel;

namespace TSD.AccountingSoft.Model.BusinessObjects.Deposit
{
    [Serializable]
    public class DepositDetailModel : BaseVoucherModel
    {
        public long RefDetailId { get; set; }
        public long RefId { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public decimal AmountOc { get; set; }
        public decimal AmountExchange { get; set; }
        /// <summary>
        /// Lệ phí
        /// </summary>
        public decimal Charge { get; set; }
        /// <summary>
        /// Lệ phí quy đổi
        /// </summary>
        public decimal ChargeExchange { get; set; }
        public int? VoucherTypeId { get; set; }
        public string BudgetSourceCode { get; set; }
        public int? AccountingObjectId { get; set; }
        public string BudgetItemCode { get; set; }
        public int? MergerFundId { get; set; }
        public int? ProjectId { get; set; }
        public int? AutoBusinessId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
