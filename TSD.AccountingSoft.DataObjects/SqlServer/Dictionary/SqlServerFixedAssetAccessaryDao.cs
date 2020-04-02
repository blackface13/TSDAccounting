using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerFixedAssetAccessaryDao : IFixedAssetAccessaryDao
    {
        public IList<FixedAssetAccessaryEntity> GetFixedAssetAccessarysByFixedAssetId(int fixedAssetId)
        {
            const string sql = @"uspGet_FixedAssetAccessary_ByFixedAssetId";

            object[] parms = { "@FixedAssetId", fixedAssetId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public FixedAssetAccessaryEntity GetFixedAssetAccessaryByFixedAssetAccessaryId(int FixedAssetAccessaryId)
        {
            const string sql = @"uspGet_FixedAssetAccessary_ByFixedAssetAccessaryId";

            object[] parms = { "@FixedAssetAccessaryId", FixedAssetAccessaryId };
            return Db.Read(sql, true, Make, parms);
        }

        public int InsertFixedAssetAccessary(FixedAssetAccessaryEntity fixedAssetAccessaryEntity)
        {
            const string sql = @"uspInsert_FixedAssetAccessary";
            return Db.Insert(sql, true, Take(fixedAssetAccessaryEntity));
        }

        public string DeleteFixedAssetAccessaryByFixedAssetId(int fixedAssetId)
        {
            const string sql = @"uspDelete_FixedAssetAccessary_ByFixedAssetID";

            object[] parms = { "@FixedAssetId", fixedAssetId };
            return Db.Update(sql, true, parms);
        }

        private static readonly Func<IDataReader, FixedAssetAccessaryEntity> Make = reader => 
        {
            var fixedAssetAccessary = new FixedAssetAccessaryEntity();
            fixedAssetAccessary.FixedAssetAccessaryId = reader["FixedAssetAccessaryId"].AsInt();
            fixedAssetAccessary.FixedAssetId = reader["FixedAssetId"].AsInt();
            fixedAssetAccessary.FixedAssetAccessaryName = reader["FixedAssetAccessaryName"].AsString();
            fixedAssetAccessary.Quantity = reader["Quantity"].AsInt();
            fixedAssetAccessary.Unit = reader["Unit"].AsString();
            fixedAssetAccessary.CurrencyCode = reader["CurrencyCode"].AsString();
            fixedAssetAccessary.ExchangeRate = reader["ExchangeRate"].AsDecimal();
            fixedAssetAccessary.AmountOc = reader["AmountOc"].AsDecimal();
            fixedAssetAccessary.AmountEx = reader["AmountEx"].AsDecimal();
            return fixedAssetAccessary;
        };

        private static object[] Take(FixedAssetAccessaryEntity fixedAssetCurrency)
        {
            return new object[]
            {
                "@FixedAssetAccessaryId", fixedAssetCurrency.FixedAssetAccessaryId,
                "@FixedAssetId", fixedAssetCurrency.FixedAssetId,
                "@FixedAssetAccessaryName", fixedAssetCurrency.FixedAssetAccessaryName,
                "@Quantity", fixedAssetCurrency.Quantity,
                "@Unit", fixedAssetCurrency.Unit,
                "@CurrencyCode", fixedAssetCurrency.CurrencyCode,
                "@ExchangeRate", fixedAssetCurrency.ExchangeRate,
                "@AmountOc", fixedAssetCurrency.AmountOc,
                "@AmountEx", fixedAssetCurrency.AmountEx
            };
        }
    }
}
