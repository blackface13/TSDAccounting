using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAsset;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    public interface IFixedAssetVoucherDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="FixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetVoucherEntity> GetFixedAssetVoucherByFixedAssetId(int FixedAssetId);
    }
}
