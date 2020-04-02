using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    public class AccountingObjectCategoryFacade
    {
        private static readonly IAccountingObjectCategoryDao AccountingObjectCategoryDao = DataAccess.DataAccess.AccountingObjectCategoryDao;
        public IList<AccountingObjectCategoryEntity> GetAccountingObjectCategories()
        {
            return AccountingObjectCategoryDao.GetAccountingObjectCategories();
        }
    }
}
