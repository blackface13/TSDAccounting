/***********************************************************************
 * <copyright file="SqlServerAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerAccountDao : IAccountDao
    {
        public AccountEntity GetAccount(int accountId)
        {
            const string sql = @"uspGet_Account_ByID";

            object[] parms = { "@AccountID", accountId };
            return Db.Read(sql, true, Make, parms);
        }

        public AccountEntity GetAccountCode(string accountCode)
        {
            const string sql = @"uspGet_Account_ByCode";

            object[] parms = { "@AccountCode", accountCode };
            return Db.Read(sql, true, Make, parms);
        }

        public AccountEntity GetAccountByAccountCode(string accountCode)
        {
            const string sql = @"uspGet_Account_ByAccountCode";

            object[] parms = { "@AccountCode", accountCode };
            return Db.Read(sql, true, Make, parms);
        }


        public List<AccountEntity> GetAccountsForComboTree(int accountId)
        {
            const string sql = @"uspGet_Account_ForComboTreee";

            object[] parms = { "@AccountID", accountId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<AccountEntity> GetAccounts()
        {
            const string procedures = @"uspGet_All_Account";
            return Db.ReadList(procedures, true, Make);
        }

        public List<AccountEntity> GetAccountsActive()
        {
            const string procedures = @"uspGet_Account_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        public List<AccountEntity> GetAccountsIsDetail(bool isDetail)
        {
            const string procedures = @"uspGet_Account_ByDetail";
            object[] parms = { "@IsDetail", isDetail };
            return Db.ReadList(procedures, true, Make,parms);
        }

        public int InsertAccount(AccountEntity account)
        {
            const string sql = "uspInsert_Account";
            return Db.Insert(sql, true, Take(account));
        }

        public string UpdateAccount(AccountEntity account)
        {
            const string sql = "uspUpdate_Account";
            return Db.Update(sql, true, Take(account));
        }

        public string DeleteAccount(AccountEntity account)
        {
            const string sql = @"uspDelete_Account";

            object[] parms = { "@AccountID", account.AccountId };
            return Db.Delete(sql, true, parms);
        }

        public List<AccountEntity> GetAccountsForIsInventoryItem()
        {
            const string procedures = @"uspGet_Account_ByInventoryItem";
            return Db.ReadList(procedures, true, Make);
        }

        private static readonly Func<IDataReader, AccountEntity> Make = reader => new AccountEntity
        {
            AccountId = reader["AccountID"].AsInt(),
            AccountCategoryId = reader["AccountCategoryID"].AsInt(),
            AccountCode = reader["AccountCode"].AsString(),
            AccountName = reader["AccountName"].AsString(),
            ForeignName = reader["ForeignName"].AsString(),
            ParentId = reader["ParentID"].AsIntForNull(),
            Grade = reader["Grade"].AsInt(),
            IsDetail = reader["IsDetail"].AsBool(),
            Description = reader["Description"].AsString(),
            BalanceSide = reader["Balanceside"].AsInt(),
            ConcomitantAccount = reader["ConcomitantAccount"].AsString(),
            BankId = reader["BankID"].AsInt(),
            IsChapter = reader["IsChapter"].AsBool(),
            IsBudgetCategory = reader["IsBudgetCategory"].AsBool(),
            IsBudgetItem = reader["IsBudgetItem"].AsBool(),
            IsBudgetGroup = reader["IsBudgetGroup"].AsBool(),
            IsBudgetSource = reader["IsBudgetSource"].AsBool(),
            IsActivity = reader["IsActivity"].AsBool(),
            IsCurrency = reader["IsCurrency"].AsBool(),
            IsCustomer = reader["IsCustomer"].AsBool(),
            IsVendor = reader["IsVendor"].AsBool(),
            IsEmployee = reader["IsEmployee"].AsBool(),
            IsAccountingObject = reader["IsAccountingObject"].AsBool(),
            IsInventoryItem = reader["IsInventoryItem"].AsBool(),
            IsFixedAsset = reader["IsFixedasset"].AsBool(),
            IsSystem = reader["IsSystem"].AsBool(),
            IsActive = reader["IsActive"].AsBool(),
            IsCapitalAllocate = reader["IsCapitalAllocate"].AsBool(),
            IsAllowinputcts = reader["IsAllowinputcts"].AsBool(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            IsProject = reader["IsProject"].AsBool(),
            IsBank = reader["IsBank"].AsBool(),
            IsBudgetSubItem = reader["IsBudgetSubItem"].AsBool()
        };

        private object[] Take(AccountEntity account)
        {
            return new object[] {
                "@AccountID", account.AccountId,
                "@AccountCategoryID", account.AccountCategoryId,
                "@AccountCode" , account.AccountCode,
                "@AccountName" , account.AccountName,
                "@ForeignName" , account.ForeignName ,
                "@ParentID" , account.ParentId ,
                "@Grade" , account.Grade ,
                "@IsDetail" , account.IsDetail ,
                "@Description", account.Description ,
                "@Balanceside" , account.BalanceSide ,
                "@ConcomitantAccount", account.ConcomitantAccount ,
                "@BankID" , account.BankId ,
                "@IsChapter" , account.IsChapter ,
                "@IsBudgetCategory" , account.IsBudgetCategory ,
                "@IsBudgetItem" , account.IsBudgetItem ,
                "@IsBudgetGroup" , account.IsBudgetGroup ,
                "@IsBudgetSource" , account.IsBudgetSource ,
                "@IsActivity" , account.IsActive ,
                "@IsCurrency" , account.IsCurrency ,
                "@IsCustomer" , account.IsCustomer ,
                "@IsVendor" , account.IsVendor ,
                "@IsEmployee" , account.IsEmployee ,
                "@IsAccountingObject" , account.IsAccountingObject ,
                "@IsInventoryItem" , account.IsInventoryItem ,
                "@IsFixedasset" , account.IsFixedAsset ,
                "@IsCapitalAllocate" , account.IsCapitalAllocate ,
                "@CurrencyCode" , account.CurrencyCode ,
                "@IsProject" , account.IsProject ,
                "@IsAllowinputcts" , account.IsAllowinputcts ,
                "@IsActive" , account.IsActive ,
                "@IsSystem" , account.IsSystem ,
                "@IsBudgetSubItem" , account.IsBudgetSubItem ,
                "@IsBank" , account.IsBank
            };
        }
    }
}
