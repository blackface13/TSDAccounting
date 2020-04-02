using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.General
{
    public class SqlServerEstimateExchangeRateDao : IEstimateExchangeRateDao
    {
        public EstimateExchangeRateEntity GetEstimateExchangeRate(int year)
        {
            const string procedures = @"uspGet_EstimateExchangeRate";
            object[] parms = { "@ThisYear", year };
            return Db.Read(procedures, true, Make, parms);
        }

        private static readonly Func<IDataReader, EstimateExchangeRateEntity> Make = reader => new EstimateExchangeRateEntity
        {
            ExchangeRateThisYear = reader["ExchangeRateThisYear"].AsDecimal(),
            ExchangeRateLastYear = reader["ExchangeRateLastYear"].AsDecimal()
        };
    }
}
