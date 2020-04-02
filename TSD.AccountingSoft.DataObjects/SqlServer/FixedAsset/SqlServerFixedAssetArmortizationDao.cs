/***********************************************************************
 * <copyright file="SqlServerFixedAssetArmortizationDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.FixedAsset
{
    /// <summary>
    /// SqlServerFixedAssetArmortizationDao
    /// </summary>
    public class SqlServerFixedAssetArmortizationDao : IFixedAssetArmortizationDao
    {
        /// <summary>
        /// Gets the fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public FAArmortizationEntity GetFAArmortization(long refId)
        {
            const string procedures = @"uspGet_FixedAssetArmortization_ByID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa armortizations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<FAArmortizationEntity> GetFAArmortizationsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_FAArmortization_ByRefType";

            object[] parms = { "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa armortizations.
        /// </summary>
        /// <returns></returns>
        public List<FAArmortizationEntity> GetFAArmortizations()
        {
            const string procedures = @"uspGet_All_FixedAssetArmortization";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the fa armortizations by year of planing.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<FAArmortizationEntity> GetFAArmortizationsByRefDate(DateTime refDate)
        {
            const string procedures = @"uspGet_FixedAssetArmortization_ByRefDate";
            object[] parms = { "@RefDate", refDate };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<FAArmortizationEntity> GetFAArmortizationsByRefDate(DateTime refDate, string currencyCode)
        {
            const string procedures = @"uspGet_FixedAssetArmortization_ByRefDateAndCurrencyCode";
            object[] parms = { "@RefDate", refDate, "CurrencyCode", currencyCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        public int InsertFAArmortization(FAArmortizationEntity fAArmortization)
        {
            const string sql = @"uspInsert_FixedAssetArmortization";
            return Db.Insert(sql, true, Take(fAArmortization));
        }

        /// <summary>
        /// Updates the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        public string UpdateFAArmortization(FAArmortizationEntity fAArmortization)
        {
            const string sql = @"uspUpdate_FixedAssetArmortization";
            return Db.Update(sql, true, Take(fAArmortization));
        }

        /// <summary>
        /// Deletes the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        public string DeleteFAArmortization(FAArmortizationEntity fAArmortization)
        {
            const string sql = @"uspDelete_FixedAssetArmortization";

            object[] parms = { "@RefID", fAArmortization.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAArmortizationEntity> Make = reader =>
            new FAArmortizationEntity
            {
                RefId = reader["RefID"].AsLong(),
                RefTypeId = reader["RefTypeID"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                JournalMemo = reader["JournalMemo"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString()
            };

        /// <summary>
        /// Takes the specified f a armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        private object[] Take(FAArmortizationEntity fAArmortization)
        {
            return new object[]  
            {
                @"@RefID", fAArmortization.RefId,
                @"RefTypeID", fAArmortization.RefTypeId,
                @"RefNo", fAArmortization.RefNo,
                @"RefDate", fAArmortization.RefDate,
                @"PostedDate", fAArmortization.PostedDate,
                @"TotalAmountExchange", fAArmortization.TotalAmountExchange,
                @"TotalAmountOC", fAArmortization.TotalAmountOC,
                @"JournalMemo", fAArmortization.JournalMemo,
                @"CurrencyCode", fAArmortization.CurrencyCode
            };
        }
    }
}
