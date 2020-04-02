/***********************************************************************
 * <copyright file="SqlServerBankDao.cs" company="BUCA JSC">
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
    /// SqlServerBankDao
    /// </summary>
    public class SqlServerBankDao : IBankDao
    {
        /// <summary>
        /// Gets the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        public BankEntity GetBank(int bankId)
        {
            const string sql = @"uspGet_Bank_ByID";

            object[] parms = { "@BankId", bankId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <returns></returns>
        public List<BankEntity> GetBanks()
        {
            const string procedures = @"uspGet_All_Bank";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the banks by bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns></returns>
        public List<BankEntity> GetBanksByBankAccount(string bankAccount)
        {
            const string sql = @"uspGet_Bank_ByBankAccount";

            object[] parms = { "@BankAccount", bankAccount };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the banks by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BankEntity> GetBanksByActive(bool isActive)
        {
            const string sql = @"uspGet_Bank_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        public int InsertBank(BankEntity bank)
        {
            const string sql = @"uspInsert_Bank";
            return Db.Insert(sql, true, Take(bank));
        }

        /// <summary>
        /// Updates the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        public string UpdateBank(BankEntity bank)
        {
            const string sql = @"uspUpdate_Bank";
            return Db.Update(sql, true, Take(bank));
        }

        /// <summary>
        /// Deletes the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        public string DeleteBank(BankEntity bank)
        {
            const string sql = @"uspDelete_Bank";

            object[] parms = { "@BankId", bank.BankId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BankEntity> Make = reader =>
            new BankEntity
            {
                BankId = reader["BankID"].AsInt(),
                BankAccount = reader["BankAccount"].AsString(),
                BankAddress = reader["BankAddress"].AsString(),
                BankName = reader["BankName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        private static object[] Take(BankEntity bank)
        {
            return new object[]  
            {
                "@BankID", bank.BankId,
                "@BankAccount", bank.BankAccount,
                "@BankAddress", bank.BankAddress,
                "@BankName", bank.BankName,
                "@Description", bank.Description,
                "@IsActive", bank.IsActive
            };
        }
    }
}
