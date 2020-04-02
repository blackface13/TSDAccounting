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
    public class SqlServerAccountingObjectCategoryDao : IAccountingObjectCategoryDao
    {
        public List<AccountingObjectCategoryEntity> GetAccountingObjectCategories()
        {
            const string sql = @"uspGet_All_AccountingObjectCategory";
            return Db.ReadList(sql, true, Make);
        }

        public AccountingObjectCategoryEntity GetAccountingObjectCategory(int accountingObjectCategoryId)
        {
            const string sql = @"uspGet_AccountingObjectCategory_ByID";
            object[] parms = { "@AccountingObjectCategoryID", accountingObjectCategoryId };
            return Db.Read(sql, true, Make, parms);
        }
        private static readonly Func<IDataReader, AccountingObjectCategoryEntity> Make = reader =>
           new AccountingObjectCategoryEntity
           {
               AccountingObjectCategoryId = reader["AccountingObjectCategoryID"].AsInt(),
               AccountingObjectCategoryCode = reader["AccountingObjectCategoryCode"].AsString(),
               AccountingObjectCategoryName = reader["AccountingObjectCategoryName"].AsString(),
               IsActive = reader["IsActive"].AsBool(),
               IsSystem = reader["IsSystem"].AsBool()
           };

        private static object[] Take(AccountingObjectCategoryEntity accountingObjectCategoryEntity)
        {
            return new object[]
            {
                "@AccountingObjectCategoryId", accountingObjectCategoryEntity.AccountingObjectCategoryId,
                "@AccountingObjectCategoryCode", accountingObjectCategoryEntity.AccountingObjectCategoryCode,
                "@AccountingObjectCategoryName", accountingObjectCategoryEntity.AccountingObjectCategoryName,
                "@IsActive", accountingObjectCategoryEntity.IsActive,
                "@IsSystem",accountingObjectCategoryEntity.IsSystem
            };
        }
    }
}
