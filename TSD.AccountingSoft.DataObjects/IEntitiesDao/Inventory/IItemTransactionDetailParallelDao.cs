using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory
{
    public interface IItemTransactionDetailParallelDao
    {
        List<ItemTransactionDetailParallelEntity> GetItemTransactionDetailParallelByRefId(long refId, int refTypeId);
        string DeleteItemTransactionDetailParallelById(long refId);
        string DeleteItemTransactionDetailParallelByDetailId(long refDetailId);
        int InsertItemTransactionDetailParallel(ItemTransactionDetailParallelEntity depositDetail);
        string UpdateItemTransactionDetailParallel(ItemTransactionDetailParallelEntity depositDetail);
    }
}
