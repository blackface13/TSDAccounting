/***********************************************************************
 * <copyright file="GeneralEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.General
{
    /// <summary>
    /// GeneralEntity
    /// </summary>
    public class GeneralEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralEntity" /> class.
        /// </summary>
        public GeneralEntity()
        {
            AddRule(new ValidateId("RefId"));
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralEntity"/> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="journalMemo">The journal memo.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="totalAmountOc">The total amount oc.</param>
        /// <param name="totalAmountExchange">The total amount exchange.</param>
        public GeneralEntity(int refId, string refNo, DateTime refDate, DateTime postedDate, string journalMemo,
                             int refTypeId,decimal totalAmountOc, decimal totalAmountExchange)
        {
            RefId = refId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            JournalMemo = journalMemo;
            RefTypeId = refTypeId;
            TotalAmountOc = totalAmountOc;
            TotalAmountExchange = totalAmountExchange;
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string  RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>The post date.</value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOc { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>The total amount exchange.</value>
        public decimal TotalAmountExchange { get; set; }

        public long? DepositId { get; set; }

        public long? CashId { get; set; }

        /// <summary>
        /// Gets or sets the general details.
        /// </summary>
        /// <value>The general details.</value>
        public IList<GeneralDetailEntity> GeneralDetails { get; set; } 
        public IList<GeneralParalellDetailEntity> GeneralParalellDetails { get; set; }
    }
}
