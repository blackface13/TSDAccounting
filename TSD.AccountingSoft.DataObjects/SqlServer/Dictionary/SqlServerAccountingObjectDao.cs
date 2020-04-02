/***********************************************************************
 * <copyright file="SqlServerAccountingObjectDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
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
    public class SqlServerAccountingObjectDao : IAccountingObjectDao
    {
        public AccountingObjectEntity GetAccountingObjectById(int accountingObjectId)
        {
            const string sql = @"uspGet_AccountingObject_ByID";
            object[] parms = { "@AccountingObjectID", accountingObjectId };
            return Db.Read(sql, true, Make, parms);
        }

        public AccountingObjectEntity GetAccountingObjectByCode(string accountingObjectCode)
        {
            const string sql = @"uspGet_AccountingObject_ByCode";
            object[] parms = { "@AccountingObjectCode", accountingObjectCode };
            return Db.Read(sql, true, Make, parms);
        }

        public IList<AccountingObjectEntity> GetAccountingObjects()
        {
            const string sql = @"uspGet_All_AccountingObject";
            return Db.ReadList(sql, true, Make);
        }

        public IList<AccountingObjectEntity> GetAccountingObjectsForList()
        {
            const string sql = @"uspGet_All_AccountingObject";
            object[] parms = { "@Option", 1 };
            return Db.ReadList(sql, true, Make, parms);
        }

        public IList<AccountingObjectEntity> GetAccountingObjectByActives(bool isActive)
        {
            const string sql = @"uspGet_AccountingObject_IsActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        public IList<AccountingObjectEntity> GetAccountingObjectByCodes(string code)
        {
            const string sql = @"uspGet_AccountingObject_ByCode";
            object[] parms = { "@AccountingObjectCode", code };
            return Db.ReadList(sql, true, Make, parms);
        }

        public IList<AccountingObjectEntity> GetAccountingObjectByAccountingObjectCategoryIds(int categoryId)
        {
            const string sql = @"uspGet_AccountingObject_ByAccountingObjectCategoryId";
            object[] parms = { "@AccountingObjectCategoryId", categoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public int InsertAccountingObject(AccountingObjectEntity accountingObject)
        {
            const string sql = @"uspInsert_AccountingObject";
            return Db.Insert(sql, true, Take(accountingObject));
        }

        public string UpdateAccountingObject(AccountingObjectEntity accountingObject)
        {
            const string sql = @"uspUpdate_AccountingObject";
            return Db.Update(sql, true, Take(accountingObject));
        }

        public string DeleteAccountingObject(AccountingObjectEntity accountingObject)
        {
            const string sql = @"uspDelete_AccountingObject";
            object[] parms = { "@AccountingObjectID", accountingObject.AccountingObjectId };
            return Db.Delete(sql, true, parms);
        }

        #region Make and Take

        private static readonly Func<IDataReader, AccountingObjectEntity> Make = reader => new AccountingObjectEntity
        {
            AccountingObjectId = reader["AccountingObjectId"].AsId(),
            AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
            AccountingObjectCategoryId = reader["AccountingObjectCategoryId"].AsInt(),
            Type = reader["Type"].AsInt(),
            FullName = reader["FullName"].AsString(),
            Address = reader["Address"].AsString(),
            TaxCode = reader["TaxCode"].AsString(),
            BankAcount = reader["BankAcount"].AsString(),
            BankId = reader["BankId"].AsInt(),
            BankName = reader["bankName"].AsString(),
            ContactName = reader["ContactName"].AsString(),
            ContactAddress = reader["ContactAddress"].AsString(),
            ContactIdNumber = reader["ContactIdNumber"].AsString(),
            IssueDate = reader["IssueDate"].AsDateTime(),
            IssueAddress = reader["IssueAddress"].AsString(),
            IsActive = reader["IsActive"].AsBool()
        };

        private static object[] Take(AccountingObjectEntity accountingObjectEntity)
        {
            return new object[]  
            {
                "@AccountingObjectId" , accountingObjectEntity.AccountingObjectId,
                "@AccountingObjectCode" , accountingObjectEntity.AccountingObjectCode,
                "@Type" , accountingObjectEntity.Type,
                "@FullName" , accountingObjectEntity.FullName,
                "@Address" , accountingObjectEntity.Address,
                "@TaxCode" , accountingObjectEntity.TaxCode,
                "@BankAcount" , accountingObjectEntity.BankAcount,
                "@BankId" , accountingObjectEntity.BankId,
                "@BankName", accountingObjectEntity.BankName,
                "@ContactName" , accountingObjectEntity.ContactName,
                "@ContactAddress" , accountingObjectEntity.ContactAddress,
                "@ContactIdNumber" , accountingObjectEntity.ContactIdNumber,
                "@IssueDate" , accountingObjectEntity.IssueDate,
                "@IssueAddress", accountingObjectEntity.IssueAddress,
                "@IsActive", accountingObjectEntity.IsActive
            };
        }

        #endregion
    }
}
