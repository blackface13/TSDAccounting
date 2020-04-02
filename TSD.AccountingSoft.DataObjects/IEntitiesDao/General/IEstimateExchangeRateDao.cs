using TSD.AccountingSoft.BusinessEntities.Business.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.General
{
    public interface IEstimateExchangeRateDao
    {
        EstimateExchangeRateEntity GetEstimateExchangeRate(int year);
    }
}
