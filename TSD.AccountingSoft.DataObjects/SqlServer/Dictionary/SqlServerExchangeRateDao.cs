/***********************************************************************
 * <copyright file="SqlServerExchangeRateDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerExchangeRateDao
    /// </summary>
    public class SqlServerExchangeRateDao : IExchangeRateDao
    {
        public ExchangeRateEntity GetExchangeRate(int exchangeRateId)
        {
            const string sql = @"uspGet_ExchangeRate_ByID";

            object[] parms = { "@ExchangeRateID", exchangeRateId };
            return Db.Read(sql, true, Make, parms);
        }

        public ExchangeRateEntity GetExchangeRatesByDateAndBudgetSource(DateTime fromdate, DateTime todate, string budgetSourceCode)
        {
            const string sql = @"uspGet_ExchangeRate_ByDateAndBudgetSource";

            object[] parms = { "@FromDate", fromdate, "@ToDate", todate, "@BudgetSourceCode", budgetSourceCode };
            return Db.Read(sql, true, Make, parms);
        }

        public List<ExchangeRateEntity> GetExchangeRates()
        {
            const string procedures = @"uspGet_All_ExchangeRate";
            return Db.ReadList(procedures, true, Make);
        }

        public List<ExchangeRateEntity> GetExchangeRatesByDate(DateTime fromdate, DateTime todate)
        {
            const string sql = @"uspGet_ExchangeRate_ByDate";

            object[] parms = { "@FromDate", fromdate, "@ToDate", todate };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<ExchangeRateEntity> GetExchangeRatesByActive(bool isActive)
        {
            const string sql = @"uspGet_ExchangeRate_IsActive";

            object[] parms = { "@Inactive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        public int InsertExchangeRate(ExchangeRateEntity exchangeRate)
        {
            const string sql = @"uspInsert_ExchangeRate";
            return Db.Insert(sql, true, Take(exchangeRate));
        }

        public string UpdateExchangeRate(ExchangeRateEntity exchangeRate)
        {
            const string sql = @"uspUpdate_ExchangeRate";
            return Db.Update(sql, true, Take(exchangeRate));
        }

        public string DeleteExchangeRate(ExchangeRateEntity exchangeRate)
        {
            const string sql = @"uspDelete_ExchangeRate";

            object[] parms = { "@ExchangeRateId", exchangeRate.ExchangeRateId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ExchangeRateEntity> Make = reader =>
            new ExchangeRateEntity
            {
                ExchangeRateId = reader["ExchangeRateID"].AsInt(),
                Description = reader["Description"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                FromDate = reader["FromDate"].AsDateTime(),
                ToDate = reader["ToDate"].AsDateTime(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                Inactive = reader["Inactive"].AsBool()
            };

        private static object[] Take(ExchangeRateEntity exchangeRate)
        {
            return new object[]  
            {
                "@ExchangeRateID", exchangeRate.ExchangeRateId,
                "@FromDate", exchangeRate.FromDate,
                "@ToDate", exchangeRate.ToDate,
                "@BudgetSourceCode", exchangeRate.BudgetSourceCode,
                "@ExchangeRate", exchangeRate.ExchangeRate,
                "@Description", exchangeRate.Description,
                "@Inactive", exchangeRate.Inactive
            };
        }
    }
}
