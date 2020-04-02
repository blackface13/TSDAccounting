using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAsset;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    public class SqlServerFixedAssetVoucherDao : IFixedAssetVoucherDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="fixedAssetId"> </param>
        /// <returns></returns>
      
        public List<FixedAssetVoucherEntity> GetFixedAssetVoucherByFixedAssetId(int fixedAssetId)
        {
            const string procedures = @"uspGetListFixedAssetVoucher";

            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetVoucherEntity> Make = reader =>
            new FixedAssetVoucherEntity
            {
                RefId = reader["RefID"].AsLong(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                RefTypeId = reader["RefTypeId"].AsInt(),
                AccountNumber = reader["AccountNumber"].AsString(),
                CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                Description = reader["Description"].AsString(),
                AmountExchange = reader["AmountExchange"].AsDecimal(),
                AmountOC = reader["AmountOC"].AsDecimal(),
                AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
                AccumDepreciationAmountUSD = reader["AccumDepreciationAmountUSD"].AsDecimal(),
                RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                RemainingAmountUSD = reader["RemainingAmountUSD"].AsDecimal(),
                AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
                AnnualDepreciationAmountUSD = reader["AnnualDepreciationAmountUSD"].AsDecimal(),
            };
    }
}
