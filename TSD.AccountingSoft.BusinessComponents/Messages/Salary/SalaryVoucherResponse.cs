/***********************************************************************
 * <copyright file="GeneralLedgerRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangNK@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Salary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Salary
{
    public class SalaryVoucherResponse : ResponseBase
    {
        public int ReftypeId { get; set; }
        public string RefNo { get; set; }
        public string PostedDate { get; set; }
        public List<SalaryVoucherEntity> SalaryVouchers { get; set; }
        public SalaryVoucherEntity SalaryVoucher { get; set; }

    }
}
