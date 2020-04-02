using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;

namespace TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset
{

    /// <summary>
    /// FixedAssetLedgerResponse
    /// </summary>
    public class FixedAssetLedgerResponse: ResponseBase
    {
        /// <summary>
        /// The fAIncrements
        /// </summary>
        public IList<FixedAssetLedgerEntity> FixedAssetLedgers;

        /// <summary>
        /// The fAIncrement
        /// </summary>
        public FixedAssetLedgerResponse FixedAssetLedger;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
