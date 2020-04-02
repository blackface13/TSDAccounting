using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IAccountingObjectCategoryDao
    {
        List<AccountingObjectCategoryEntity> GetAccountingObjectCategories();
        AccountingObjectCategoryEntity GetAccountingObjectCategory(int accountingObjectCategoryId);
    }
}
