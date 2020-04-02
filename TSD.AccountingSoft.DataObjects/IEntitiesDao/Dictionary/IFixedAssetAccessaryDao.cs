using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IFixedAssetAccessaryDao
    {
        IList<FixedAssetAccessaryEntity> GetFixedAssetAccessarysByFixedAssetId(int fixedAssetId);

        FixedAssetAccessaryEntity GetFixedAssetAccessaryByFixedAssetAccessaryId(int FixedAssetAccessaryId);

        int InsertFixedAssetAccessary(FixedAssetAccessaryEntity fixedAssetAccessaryEntity);

        string DeleteFixedAssetAccessaryByFixedAssetId(int fixedAssetId);
    }
}
