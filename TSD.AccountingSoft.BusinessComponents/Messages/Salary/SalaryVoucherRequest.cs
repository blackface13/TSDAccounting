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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Salary
{
    public class SalaryVoucherRequest : RequestBase
    {

        public int ReftypeId { get; set; }
        public string RefNo { get; set; }
        public string PostedDate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool IsRetail { get; set; }
    }
}
