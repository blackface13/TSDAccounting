using TSD.AccountingSoft.BusinessEntities.Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Tool
{
    public interface ISUIncrementDecrementDetailDao
    {
        List<SUIncrementDecrementDetailEntity> GetSUIncrementDecrementDetailsByRefId(long refId);

        long InsertSUIncrementDecrementDetail(SUIncrementDecrementDetailEntity sUIncrementDecrementDetail);

        string DeleteSUIncrementDecrementDetailByRefId(long refId);
    }
}
