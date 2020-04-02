using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Opening
{
    public class OpeningFixedAssetEntryRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }


        public int FixedAssetId { get; set; }

        public int RefTypeId { get; set; }

        /// <summary>
        /// The fa armortization
        /// </summary>
        public OpeningFixedAssetEntryEntity OpeningFixedAssetEntry;

        /// <summary>
        /// The fa increments
        /// </summary>
        public IList<OpeningFixedAssetEntryEntity> OpeningFixedAssetEntries;

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

        public string AccountNumber { get; set; } 
    }
}
