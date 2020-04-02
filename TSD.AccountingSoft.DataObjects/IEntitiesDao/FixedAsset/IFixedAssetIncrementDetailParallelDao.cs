using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    public interface IFixedAssetIncrementDetailParallelDao
    {
        List<FAIncrementDetailParallelEntity> GetFixedAssetIncrementDetailParallelByRefId(long refId);
        string DeleteFixedAssetIncrementDetailParallelById(long refId);
        string DeleteFixedAssetIncrementDetailParallelByDetailId(long refDetailId);
        int InsertFixedAssetIncrementDetailParallel(FAIncrementDetailParallelEntity detail);
        string UpdateFixedAssetIncrementDetailParallel(FAIncrementDetailParallelEntity detail);
    }
}
