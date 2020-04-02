using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IAutoBusinessParallelDao
    {
        AutoBusinessParallelEntity GetAutoBusinessParallel(int autoBusinessParallelId);

        List<AutoBusinessParallelEntity> GetAutoBusinessParallels();

        List<AutoBusinessParallelEntity> GetAutoBusinessParallels(string autoBusinessParallelCode);

        List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByActive(bool isActive);

        AutoBusinessParallelEntity GetAutoBusinessParallelsByAutoBussinessInformation(string debitAccount, string creditAccount, int budgetSourceId, int budgetItemId, int budgetSubItemId, int voucherTypeId);

        List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByAutoBussinessInformations(string debitAccount, string creditAccount, int budgetSourceId, int budgetItemId, int budgetSubItemId, int voucherTypeId);

        int InsertAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel);

        string UpdateAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel);

        string DeleteAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel);

        string DeleteAutoBusinessParallelConvert();
    }
}
