using TSD.AccountingSoft.BusinessEntities.Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Tool
{
    public interface ISUIncrementDecrementDao 
    {
        SUIncrementDecrementEntity GetSUIncrementDecrement(long refId);

        SUIncrementDecrementEntity GetSUIncrementDecrementByRefdateAndReftype(SUIncrementDecrementEntity sUIncrementDecrement);

        List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId);

        List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByYearOfRefDate(int refTypeId, short yearOfRefDate);

        List<SUIncrementDecrementEntity> GetSUIncrementDecrements();

        decimal GetSUIncrementDecrementQuantity(string currencyCode, int inventoryItemId, int departmentId, long refId, DateTime postedDate);

        long InsertSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement);

        string UpdateSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement);

        string DeleteSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrement);

        SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo);

        SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo, DateTime postedDate);
    }
}
