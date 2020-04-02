using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Opening
{
    public class OpeningFixedAssetEntryResponse : ResponseBase
    {
        /// <summary>
        /// The fAIncrements
        /// </summary>
        public IList<OpeningFixedAssetEntryEntity> OpeningFixedAssetEntries;

        /// <summary>
        /// The fAIncrement
        /// </summary>
        public OpeningFixedAssetEntryEntity OpeningFixedAssetEntry;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;


    }
}
