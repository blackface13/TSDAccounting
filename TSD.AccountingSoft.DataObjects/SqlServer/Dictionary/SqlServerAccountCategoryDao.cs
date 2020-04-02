/***********************************************************************
 * <copyright file="SqlServerAccountCategoryDao.cs" company="BUCA JSC">
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
    
    public class SqlServerAccountCategoryDao : IAccountCategoryDao
    {
        #region IAccountCategoryDao Members

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryEntity.</returns>
        public AccountCategoryEntity GetAccountCategory(int accountCategoryId)
        {
            
            const string sql = @"uspGet_AccountCategory_ByID";
            object[] parms = { "@AccountCategoryID", accountCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account categorys.
        /// </summary>
        /// <returns>List{AccountCategoryEntity}.</returns>
        public List<AccountCategoryEntity> GetAccountCategories()
        {
            const string procedures = @"uspGet_All_AccountCategory";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the accounts for combo tree.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>List{AccountCategoryEntity}.</returns>
        public List<AccountCategoryEntity> GetAccountsForComboTree(int accountCategoryId)
        {
          
            const string sql = @"uspGet_AccountCategory_ForComboTreee";

            object[] parms = { "@AccountCategoryID", accountCategoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account categorys active.
        /// </summary>
        /// <returns>List{AccountCategoryEntity}.</returns>
        public List<AccountCategoryEntity> GetAccountCategoriesActive()
        {

            const string procedures = @"uspGet_AccountCategory_ByActive";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.Int32.</returns>
        public int InsertAccountCategory(AccountCategoryEntity accountCategory)
        {

            const string sql = "uspInsert_AccountCategory";
            return Db.Insert(sql, true, Take(accountCategory));
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.String.</returns>
        public string UpdateAccountCategory(AccountCategoryEntity accountCategory)
        {
            
            const string sql = "uspUpdate_AccountCategory";
            return Db.Update(sql, true, Take(accountCategory));
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.String.</returns>
        public string DeleteAccountCategory(AccountCategoryEntity accountCategory)
        {
           
            const string sql = @"uspDelete_AccountCategory";
            object[] parms = { "@AccountCategoryID", accountCategory.AccountCategoryId };
            return Db.Delete(sql, true, parms);
        }

        #endregion

        /// <summary>
        /// Takes the specified account categories.
        /// </summary>
        /// <param name="accountCategories">The account categories.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(AccountCategoryEntity accountCategories)
        {
            return new object[]  
            {
                "@AccountCategoryID", accountCategories.AccountCategoryId,
                "@AccountCategoryCode", accountCategories.AccountCategoryCode,
                "@AccountCategoryName", accountCategories.AccountCategoryName,
                "@ForeignName", accountCategories.ForeignName,
                "@ParentID", accountCategories.ParentId,
                "@Grade", accountCategories.Grade ,
                "@IsDetail", accountCategories.IsDetail,
                "@IsActive", accountCategories.IsActive               
            };
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountCategoryEntity> Make = reader =>
          new AccountCategoryEntity
          {
              AccountCategoryId  = reader["AccountCategoryID"].AsInt(),
              AccountCategoryCode = reader["AccountCategoryCode"].AsString(),
              AccountCategoryName = reader["AccountCategoryName"].AsString(),
              ForeignName = reader["ForeignName"].AsString(),
              ParentId = reader["ParentID"].AsInt(),
              Grade = reader["Grade"].AsInt(),
              IsDetail = reader["IsDetail"].AsBool(),
              IsActive = reader["IsActive"].AsBool()
          };
    }
}
