using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerAccoutingDao : IAccountingObjectDao
    {
        public AccountingObjectEntity Get(int id)
        {
            const string sql = @"Get_Customer_ByID";
            object[] parms = { "@CusId", id };
            return Db.Read(sql, true, Make, parms);
        }

        public AccountingObjectEntity Get(string code)
        {
            throw new NotImplementedException();
        }

        public IList<AccountingObjectEntity> Gets()
        {
            throw new NotImplementedException();
        }

        public IList<AccountingObjectEntity> GetByActives(bool isActive)
        {
            throw new NotImplementedException();
        }

        public int Insert(AccountingObjectEntity obj)
        {
            throw new NotImplementedException();
        }

        public string Update(AccountingObjectEntity obj)
        {
            throw new NotImplementedException();
        }

        public string Delete(AccountingObjectEntity obj)
        {
            throw new NotImplementedException();
        }
        private static readonly Func<IDataReader, AccountingObjectEntity> Make = reader =>
            new AccountingObjectEntity()
            {
                AccountingId = reader["AccountingId"].AsId(),
                Code = reader["Code"].AsString(),
                Type = reader["Type"].AsInt(),
                FullName = reader["FullName"].AsString(),
                Address = reader["Address"].AsString(),
                TaxCode = reader["TaxCode"].AsString(),
                BankAcount = reader["BankAcount"].AsString(),
                BankId = reader["BankId"].AsInt(),
                ContactName = reader["ContactName"].AsString(),
                ContactAddress = reader["ContactAddress"].AsString(),
                ContactIdNumber = reader["ContactIdNumber"].AsString(),
                DateOfIssue = reader["DateOfIssue"].AsDateTime(),
                IssueAddress = reader["IssueAddress"].AsString()
            };
        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        private object[] Take(AccountingObjectEntity take)
        {
            return new object[]  
            {
                "@AccountingId" , take.AccountingId,
                "@Code" , take.Code,
                "@Type" , take.Type,
                "@FullName" , take.FullName,
                "@Address" , take.Address,
                "@TaxCode" , take.TaxCode,
                "@BankAcount" , take.BankAcount,
                "@BankId" , take.BankId,
                "@ContactName" , take.ContactName,
                "@ContactAddress" , take.ContactAddress,
                "@ContactIdNumber" , take.ContactIdNumber,
                "@DateOfIssue" , take.DateOfIssue,
                "@IssueAddress" , take.IssueAddress
            };
        }
    }
}
