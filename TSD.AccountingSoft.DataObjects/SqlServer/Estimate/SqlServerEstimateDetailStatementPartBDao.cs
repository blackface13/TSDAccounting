/***********************************************************************
 * <copyright file="SqlServerEstimateDetailStatementPartBDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 19 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// class SqlServerEstimateDetailStatementPartBDao
    /// </summary>
    public class SqlServerEstimateDetailStatementPartBDao : IEstimateDetailStatementPartBDao
    {
        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        public List<EstimateDetailStatementPartBEntity> GetEstimateDetailStatementPartBs()
        {
            const string procedures = @"uspGet_All_EstimateDetailStatementPartB";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        public int InsertEstimateDetailStatementPartB(EstimateDetailStatementPartBEntity estimateDetailStatement)
        {
            const string sql = @"uspInsert_EstimateDetailStatementPartB";
            return Db.Insert(sql, true, Take(estimateDetailStatement));
        }

        /// <summary>
        /// Updates the estimate detail statement.
        /// </summary>
        /// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        /// <returns></returns>
        public string UpdateEstimateDetailStatementPartB(EstimateDetailStatementPartBEntity estimateDetailStatementPartB)
        {
            const string sql = @"uspUpdate_EstimateDetailStatementPartB";
            return Db.Update(sql, true, Take(estimateDetailStatementPartB));
        }

        /// <summary>
        /// Deletes the estimateDetailStatement.
        /// </summary>
        /// <returns></returns>
        public string DeleteEstimateDetailStatementPartB()
        {
            const string sql = @"uspDelete_EstimateDetailStatementPartB";
            return Db.Delete(sql, true);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EstimateDetailStatementPartBEntity> Make = reader =>
             new EstimateDetailStatementPartBEntity
             {
                 EstimateDetailStatementPartBId = reader["EstimateDetailStatementPartBId"].AsInt(),
                 OrderNumber = reader["OrderNumber"].AsShort(),
                 Description = reader["Description"].AsString(),
                 Note = reader["Note"].AsString(),
                 Amount = reader["Amount"].AsDecimal(),
                 IsActive = reader["IsActive"].AsBool()
             };

        /// <summary>
        /// Takes the specified budgetSourceCategory.
        /// </summary>
        /// <param name="estimateDetailStatementPartB">The estimate detail statement part b.</param>
        /// <returns></returns>
        private static object[] Take(EstimateDetailStatementPartBEntity estimateDetailStatementPartB)
        {
            return new object[]  
            {
                "@EstimateDetailStatementPartBID", estimateDetailStatementPartB.EstimateDetailStatementPartBId,
                "@OrderNumber", estimateDetailStatementPartB.OrderNumber,
                "@Description", estimateDetailStatementPartB.Description,
                "@Note", estimateDetailStatementPartB.Note,
                "@Amount", estimateDetailStatementPartB.Amount,
                "@IsActive",estimateDetailStatementPartB.IsActive
            };
        }
    }
}
