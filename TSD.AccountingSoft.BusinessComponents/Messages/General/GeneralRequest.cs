/***********************************************************************
 * <copyright file="GeneralRequest.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.General;


namespace TSD.AccountingSoft.BusinessComponents.Messages.General
{
    /// <summary>
    /// Class GeneralRequest.
    /// </summary>
  public  class GeneralRequest:RequestBase
    {

        /// <summary>
        /// Gets or sets the postdate.
        /// </summary>
        /// <value>The postdate.</value>
      public DateTime Postdate { get; set; }

      /// <summary>
      /// Gets or sets the reference identifier.
      /// </summary>
      /// <value>The reference identifier.</value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is capital allocate.
        /// </summary>
        /// <value><c>true</c> if this instance is capital allocate; otherwise, <c>false</c>.</value>
        public bool IsCapitalAllocate { get; set; }

        /// <summary>
        /// Gets or sets the general entity.
        /// </summary>
        /// <value>The general entity.</value>
        public GeneralEntity GeneralEntity { get; set; }

        public bool IsGenerateParalell { get; set; }
      
    }
}
