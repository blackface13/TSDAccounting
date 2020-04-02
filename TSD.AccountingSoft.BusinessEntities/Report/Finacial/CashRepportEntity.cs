/***********************************************************************
 * <copyright file="RepportCashEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 15 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * Lớp này dùng chung cho tất cả các báo cáo 
 * ******** Sổ chi tiết tiền gửi ngân hàng
 * ******** Sổ tiền gửi ngân hàng
 * ******** Sổ quỹ tiền mặt
 * ******** Sổ chi tiết  quỹ tiền mặt  
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    /// <summary>
    /// RepportCashEntity
    /// </summary>
  public  class CashReportEntity : BusinessEntities
    {

        /// <summary>
        /// Gets or sets the vourcher no.
        /// </summary>
        /// <value>The vourcher no.</value>
        public string  RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string  Description { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>The corresponding account number.</value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the receipt amount.
        /// </summary>
        /// <value>The receipt amount.</value>
        public decimal ReceiptAmount { get; set; }

        /// <summary>
        /// Gets or sets the pay amount.
        /// </summary>
        /// <value>The pay amount.</value>
        public decimal PayAmount { get; set; }

        /// <summary>
        /// Gets or sets the rest amount.
        /// </summary>
        /// <value>The rest amount.</value>
        public decimal RestAmount { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string  FromDate { get; set; }


        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string  ToDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the amoun.
        /// </summary>
        /// <value>The type of the amount.</value>
        public int AmountType { get; set; }

        /// <summary>
        /// Gets or sets the accumulated receipt amount.
        /// </summary>
        /// <value>The accumulated receipt amount.</value>
        public decimal AccumulatedReceiptAmount { get; set; }

        /// <summary>
        /// Gets or sets the accumulated pay amount.
        /// </summary>
        /// <value>The accumulated pay amount.</value>
        public decimal AccumulatedPayAmount { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public int RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int RefTypeId { get; set; }

  
    }
}
