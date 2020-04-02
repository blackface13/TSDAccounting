using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;

namespace TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset
{

    /// <summary>
    /// FixedAssetLedgerRequest
    /// </summary>
    public class FixedAssetLedgerRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        /// The fa armortization
        /// </summary>
        public FixedAssetLedgerEntity FixedAssetLedger;

        /// <summary>
        /// The fa increments
        /// </summary>
        public IList<FixedAssetLedgerEntity> FixedAssetLedgers;

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string RefDate { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string RefNo { get; set; }


    }
}
