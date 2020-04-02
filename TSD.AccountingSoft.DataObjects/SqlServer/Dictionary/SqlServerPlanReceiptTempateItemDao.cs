using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerPlanReceiptTempateItemDao : IPlanReceiptTempateItemDao
    {
        public IList<PlanReceiptTempateItemEntity> GetPlanReceiptTempateItems()
        {
            throw new NotImplementedException();
        }

        public PlanReceiptTempateItemEntity GetPlanReceiptTempateItem(int planReceiptTempateItemId)
        {
            throw new NotImplementedException();
        }
    }
}
