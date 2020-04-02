/***********************************************************************
 * <copyright file="SqlServerCustomerDao.cs" company="BUCA JSC">
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

    /// <summary>
    /// SqlServerCustomerDao
    /// </summary>
    public class SqlServerCustomerDao : ICustomerDao
    {

        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CustomerEntity GetCustomerById(int customerId)
        {
            const string sql = @"uspGet_Customer_ByID";
            object[] parms = { "@CustomerId", customerId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="customerCode">The customer code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CustomerEntity GetCustomerByCode(string customerCode)
        {
            const string sql = @"uspGet_Customer_ByCode";
            object[] parms = { "@CustomerCode", customerCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<CustomerEntity> GetCustomers()
        {
            const string sql = @"uspGet_All_Customer";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<CustomerEntity> GetCustomerByActives(bool isActive)
        {
            const string sql = @"uspGet_Customer_ByActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="customerEntity">The customer entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int InsertCustomer(CustomerEntity customerEntity)
        {
            const string sql = @"uspInsert_Customer";
            return Db.Insert(sql, true, Take(customerEntity));
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="customerEntity">The customer entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateCustomer(CustomerEntity customerEntity)
        {
            const string sql = @"uspUpdate_Customer";
            return Db.Update(sql, true, Take(customerEntity));
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="customerEntity">The customer entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteCustomer(CustomerEntity customerEntity)
        {
            const string sql = @"uspDelete_Customer";
            object[] parms = { "@CustomerId", customerEntity.CustomerId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CustomerEntity> Make = reader =>
            new CustomerEntity
                {
                CustomerId = reader["CustomerID"].AsId(),
                CustomerCode = reader["CustomerCode"].AsString(),
                CustomerName = reader["CustomerName"].AsString(),
                Address = reader["Address"].AsString(),
                ContactName = reader["ContactName"].AsString(),
                ContactRegency = reader["ContactRegency"].AsString(),
                Phone = reader["Phone"].AsString(),
                Mobile = reader["Mobile"].AsString(),
                Fax = reader["Fax"].AsString(),
                Email = reader["Email"].AsString(),
                TaxCode = reader["TaxCode"].AsString(),
                Website = reader["Website"].AsString(),
                Province = reader["Province"].AsString(),
                City = reader["City"].AsString(),
                ZipCode = reader["ZipCode"].AsString(),
                Area = reader["Area"].AsString(),
                Country = reader["Country"].AsString(),
                BankNumber = reader["BankNumber"].AsString(),
                BankName = reader["BankName"].AsString(),
                BankId = reader["BankId"].AsId(),
                IsActive = reader["IsActive"].AsBool(),
            };

        /// <summary>
        /// Takes the specified customer Entity.
        /// </summary>
        /// <param name="customerEntity">The take.</param>
        /// <returns></returns>
        private object[] Take(CustomerEntity customerEntity)
        {
            return new object[]  
            {
                "@CustomerID",customerEntity.CustomerId
                ,"@CustomerCode" , customerEntity.CustomerCode
                ,"@CustomerName" , customerEntity.CustomerName
                ,"@Address" , customerEntity.Address
                ,"@ContactName" , customerEntity.ContactName
                ,"@ContactRegency" , customerEntity.ContactRegency
                ,"@Phone" , customerEntity.Phone
                ,"@Mobile" , customerEntity.Mobile
                ,"@Fax" , customerEntity.Fax
                ,"@Email" , customerEntity.Email
                ,"@TaxCode" , customerEntity.TaxCode
                ,"@Website" , customerEntity.Website
                ,"@Province" , customerEntity.Province
                ,"@City" , customerEntity.City
                ,"@ZipCode" , customerEntity.ZipCode
                ,"@Area" , customerEntity.Area
                ,"@Country" , customerEntity.Country
                ,"@BankNumber" , customerEntity.BankNumber
                , "@BankName", customerEntity.BankName
                ,"@BankId" , customerEntity.BankId
                ,"@IsActive" , customerEntity.IsActive
            };
        }
    }
}
