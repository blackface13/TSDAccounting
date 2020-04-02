using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit
{
    public interface IDepositDetailParallelDao
    {
        string DeleteDepositDetailParallelById(long refId);

        List<DepositDetailParallelEntity> GetDepositDetailParallelByRefId(long refId);

        int InsertDepositDetailParallel(DepositDetailParallelEntity depositDetail);

        string UpdateDepositDetailParallel(DepositDetailParallelEntity depositDetail);
    }
}
