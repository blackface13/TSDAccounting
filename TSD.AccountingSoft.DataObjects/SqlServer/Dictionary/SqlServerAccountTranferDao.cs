/***********************************************************************
 * <copyright file="SqlServerAccountTranferDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// SqlServerAccountTranferDao
    /// </summary>
    public class SqlServerAccountTranferDao : IAccountTranferDao
    {
        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        public AccountTranferEntity GetAccountTranfer(int accountTranferId)
        {
            const string sql = @"uspGet_AccountTranfer_ByID";

            object[] parms = { "@AccountTranferID", accountTranferId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns></returns>
        public List<AccountTranferEntity> GetAccountTranfers()
        {
            const string procedures = @"uspGet_All_AccountTranfer";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the account tranfers by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AccountTranferEntity> GetAccountTranfersByActive(bool isActive)
        {
            const string sql = @"uspGet_AccountTranfer_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account tranfers by account tranfer code.
        /// </summary>
        /// <param name="accountTranferCode">The account tranfer code.</param>
        /// <returns></returns>
        public List<AccountTranferEntity> GetAccountTranfersByAccountTranferCode(string accountTranferCode)
        {
            const string sql = @"uspGet_AccountTranfer_ByAccountTranferCode";

            object[] parms = { "@AccountTranferCode", accountTranferCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        public int InsertAccountTranfer(AccountTranferEntity accountTranfer)
        {
            const string sql = "uspInsert_AccountTranfer";
            return Db.Insert(sql, true, Take(accountTranfer));
        }

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        public string UpdateAccountTranfer(AccountTranferEntity accountTranfer)
        {
            const string sql = "uspUpdate_AccountTranfer";
            return Db.Update(sql, true, Take(accountTranfer));
        }

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        public string DeleteAccountTranfer(AccountTranferEntity accountTranfer)
        {
            const string sql = @"uspDelete_AccountTranfer";

            object[] parms = { "@AccountTranferID", accountTranfer.AccountTranferId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountTranferEntity> Make = reader =>
            new AccountTranferEntity
            {
                AccountTranferId = reader["AccountTranferID"].AsInt(),
                AccountTranferCode = reader["AccountTranferCode"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                AccountDestinationCode = reader["AccountDestinationCode"].AsString(),
                AccountSourceCode = reader["AccountSourceCode"].AsString(),
                ReferentAccount = reader["ReferentAccount"].AsString(),
                BudgetSourceId = reader["BudgetSourceId"].AsInt(),
                SideOfTranfer = reader["SideOfTranfer"].AsInt(),
                Type = reader["Type"].AsInt(),
                IsActive = reader["IsActive"].AsBool(),
                Description = reader["Description"].AsString()
            };

        /// <summary>
        /// Takes the specified account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        private static object[] Take(AccountTranferEntity accountTranfer)
        {
            return new object[]  
            {
                "@AccountTranferID", accountTranfer.AccountTranferId,
                "@AccountTranferCode", accountTranfer.AccountTranferCode,
                "@SortOrder", accountTranfer.SortOrder,
                "@AccountSourceCode", accountTranfer.AccountSourceCode,
                "@AccountDestinationCode", accountTranfer.AccountDestinationCode,
                "@ReferentAccount", accountTranfer.ReferentAccount,
                "@BudgetSourceId", accountTranfer.BudgetSourceId,
                "@SideOfTranfer", accountTranfer.SideOfTranfer,
                "@Type", accountTranfer.Type,
                "@IsActive", accountTranfer.IsActive,
                "@Description", accountTranfer.Description
            };
        }
    }
}