using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    public interface IFixedAssetDecrementDetailParallelDao
    {
        List<FADecrementDetailParallelEntity> GetFixedAssetDecrementDetailParallelByRefId(long refId);
        string DeleteFixedAssetDecrementDetailParallelById(long refId);
        string DeleteFixedAssetDecrementDetailParallelByDetailId(long refDetailId);
        int InsertFixedAssetDecrementDetailParallel(FADecrementDetailParallelEntity detail);
        string UpdateFixedAssetDecrementDetailParallel(FADecrementDetailParallelEntity detail);
    }
}
