/***********************************************************************
 * <copyright file="FixedAssetDecrementModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;


namespace TSD.AccountingSoft.Model.BusinessObjects.FixedAsset
{
    /// <summary>
    ///  class FixedAssetDecrementModel
    /// </summary>
    public class FixedAssetDecrementModel
    {
        public FixedAssetDecrementModel()
        {
            FixedAssetDecrementDetails = new List<FixedAssetDecrementDetailModel>();
            FixedAssetDecrementDetailParallels = new List<FixedAssetDecrementDetailParallelModel>();
        }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public string RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the accounting object.
        /// </summary>
        /// <value>The type of the accounting object.</value>
        public int? AccountingObjectType { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>The vendor identifier.</value>
        public int? VendorId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public int? EmployeeId { get; set; }

        public int? BankId { get; set; }
        
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>The total amount exchange.</value>
        public decimal TotalAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document include.
        /// </summary>
        /// <value>
        /// The document include.
        /// </value>
        public string DocumentInclude { get; set; }

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string Trader { get; set; }

        /// <summary>
        /// Gets or sets the estimate details.
        /// </summary>
        /// <value>
        /// The deposit details.
        /// </value>
        public IList<FixedAssetDecrementDetailModel> FixedAssetDecrementDetails { get; set; }

        public IList<FixedAssetDecrementDetailParallelModel> FixedAssetDecrementDetailParallels { get; set; }
    }
}
