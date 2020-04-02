/***********************************************************************
 * <copyright file="IGeneralVoucherView.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.General;

namespace TSD.AccountingSoft.View.General
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeneralVoucherView
    {


        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        string RefNo { get; set; }


        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        int RefTypeId { get; set; }


        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
         decimal TotalAmountOc { get; set; }

         /// <summary>
         /// Gets or sets the total amount exchange.
         /// </summary>
         /// <value>
         /// The total amount exchange.
         /// </value>
         decimal TotalAmountExchange { get; set; } 

        long? DepositId { get; set; }

        long? CashId { get; set; }

        /// <summary>
        /// Gets or sets the general details.
        /// </summary>
        /// <value>
        /// The general details.
        /// </value>
        IList<GeneralDetailModel> GeneralDetails { get; set; }

        IList<GeneralParalellDetailModel> GeneralParalellDetails { get; set; }

    }
}
