using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAsset;

namespace TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset
{
    /// <summary>
    /// FixedAssetVoucherResponse
    /// </summary>
    public class FixedAssetVoucherResponse : ResponseBase
    {
        /// <summary>
        /// The fAIncrements
        /// </summary>
        public IList<FixedAssetVoucherEntity> FixedAssetVouchers;

        /// <summary>
        /// The fAIncrement
        /// </summary>
        public FixedAssetVoucherResponse FixedAssetVoucher;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}
