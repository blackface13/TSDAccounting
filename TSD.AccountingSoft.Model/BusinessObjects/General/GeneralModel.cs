/***********************************************************************
 * <copyright file="GeneralModel.cs" company="BUCA JSC">
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
namespace TSD.AccountingSoft.Model.BusinessObjects.General
{
    public class GeneralVocherModel
    {
        public GeneralVocherModel()
        {
            GeneralVoucherDetails = new List<GeneralDetailModel>();
            GeneralParalellDetails = new List<GeneralParalellDetailModel>();
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
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOc { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>
        /// The total amount exchange.
        /// </value>
        public decimal TotalAmountExchange { get; set; }

        public long? DepositId { get; set; }

        public long? CashId { get; set; }

        public IList<GeneralDetailModel> GeneralVoucherDetails { set; get; }
        public IList<GeneralParalellDetailModel> GeneralParalellDetails { get; set; }

    }
}
