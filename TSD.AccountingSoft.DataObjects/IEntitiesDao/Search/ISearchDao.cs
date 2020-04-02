using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.Search;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Search
{
   public interface ISearchDao
   {
       IList<SearchEntity> GetSearch(string whereClause, string fromDate, string toDate, string currencyCode,string departmentCode,string fixedAssetCode, string budgetGroupCode);
   }
}
