/***********************************************************************
 * <copyright file="FAArmortizationEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization
{
    /// <summary>
    /// FAArmortizationEntity
    /// </summary>
    public class FAArmortizationEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FAArmortizationEntity" /> class.
        /// </summary>
        public FAArmortizationEntity()
        {
            AddRule(new ValidateRequired("RefNo"));
            AddRule(new ValidateRequired("RefDate"));
            AddRule(new ValidateRequired("PostedDate"));
            AddRule(new ValidateRequired("RefTypeId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FAArmortizationEntity" /> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="totalAmountExchange">The total amount exchange.</param>
        /// <param name="totalAmountOC">The total amount oc.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="journalMemo">The journal memo.</param>
        public FAArmortizationEntity(long refId, string refNo, DateTime refDate, DateTime postedDate, decimal totalAmountExchange, decimal totalAmountOC, int refTypeId, string journalMemo)
            : this()
        {
            RefId = refId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            TotalAmountOC = totalAmountOC;
            TotalAmountExchange = totalAmountExchange;
            RefTypeId = refTypeId;
            JournalMemo = journalMemo;
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>
        /// The total amount exchange.
        /// </value>
        public decimal TotalAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the fa armortization details.
        /// </summary>
        /// <value>
        /// The fa armortization details.
        /// </value>
        public IList<FAArmortizationDetailEntity> FAArmortizationDetails { get; set; }
    }
}