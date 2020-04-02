/***********************************************************************
 * <copyright file="SqlServerCalculateClosingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, December 25, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerAutoNumberDao
    /// </summary>
    public class SqlServerCalculateClosingDao : ICalculateClosingDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CalculateClosingEntity> Make = reader =>
            new CalculateClosingEntity
            {
                AccountId = reader["AccountID"].AsInt(),
                AccountCode = reader["AccountCode"].AsString(),
                AccountName = reader["AccountName"].AsString(),
                ParentId = reader["ParentID"].AsInt(),
                ClosingAmounts = reader["ClosingAmount"].AsDecimal()
            };

        /// <summary>
        /// Gets the type of the automatic number by reference.
        /// </summary>
        /// <param name="paymnetaccountCode">The paymnetaccount code.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isApproximate">if set to <c>true</c> [is approximate].</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public CalculateClosingEntity GetCalculateClosing(string paymnetaccountCode, string whereClause,
            string currencyCode, string toDate, bool isApproximate, long refId, int refTypeId)
        {
            const string procedures = @"uspPaymentCalculateClosing";

            object[] parms =
            {
                "@AccountCode", paymnetaccountCode,
                "@IsApproximate", isApproximate,
                "@CurrencyCode", currencyCode,
                "@WhereClause", whereClause,
                "@AmountType", 2,
                "@ToDate", toDate,
                "@FromTable", null,
                "@RefID", refId,
                "@RefTypeID", refTypeId
            };
            return Db.Read(procedures, true, Make, parms);
        }


        public CalculateClosingEntity AmountExist(string accountCode, string currencyCode)
        {
            const string procedures = @"uspAmountExist";
            object[] parms =
            {
                "@AccountCode", accountCode,
                "@CurrencyCode", currencyCode
            };
            return Db.Read(procedures, true, Make, parms);
        }
    }
}