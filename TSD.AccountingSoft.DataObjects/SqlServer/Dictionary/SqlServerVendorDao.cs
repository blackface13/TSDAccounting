/***********************************************************************
 * <copyright file="SqlServerVendorDao.cs" company="BUCA JSC">
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
    /// SqlServerVendorDao class
    /// </summary>
    public class SqlServerVendorDao:IVendorDao
    {

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, VendorEntity> Make = reader =>
            new VendorEntity
            {
                VendorId = reader["VendorID"].AsId(),
                VendorCode = reader["VendorCode"].AsString(),
                VendorName = reader["VendorName"].AsString(),
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
                BankId = reader["BankID"].AsId(),
                IsActive = reader["IsActive"].AsBool(),
            };

        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns></returns>
        private object[] Take(VendorEntity vendor)
        {
            return new object[]  
            {
                "@VendorID" , vendor.VendorId
                ,"@VendorCode" , vendor.VendorCode
                ,"@VendorName" , vendor.VendorName
                ,"@Address" , vendor.Address
                ,"@ContactName" , vendor.ContactName
                ,"@ContactRegency" , vendor.ContactRegency
                ,"@Phone" , vendor.Phone
                ,"@Mobile" , vendor.Mobile
                ,"@Fax" , vendor.Fax
                ,"@Email" , vendor.Email
                ,"@TaxCode" , vendor.TaxCode
                ,"@Website" , vendor.Website
                ,"@Province" , vendor.Province
                ,"@City" , vendor.City
                ,"@ZipCode" , vendor.ZipCode
                ,"@Area" , vendor.Area
                ,"@Country" , vendor.Country
                ,"@BankNumber" , vendor.BankNumber
                , "@BankName", vendor.BankName
                ,"@BankID" , vendor.BankId
                ,"@IsActive" , vendor.IsActive
            };
        }

        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public VendorEntity GetVendorById(int vendorId)
        {
            const string sql = @"uspGet_Vendor_ById";
            object[] parms = { "@VendorID", vendorId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="vendorCode">The vendor code.</param>
        /// <returns></returns>
        public VendorEntity GetVendorByCode(string vendorCode)
        {
            const string sql = @"uspGet_Vendor_ByCode";
            object[] parms = { "@VendorCode", vendorCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<VendorEntity> GetVendors()
        {
            const string sql = @"uspGet_All_Vendor";            
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<VendorEntity> GetVendorByActives(bool isActive)
        {
            const string sql = @"uspGet_Vendor_ByActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="vendorEntity">The vendor entity.</param>
        /// <returns></returns>
        public int InsertVendor(VendorEntity vendorEntity)
        {
            const string sql = @"uspInsert_Vendor";
            return Db.Insert(sql, true, Take(vendorEntity));
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="vendorEntity">The vendor entity.</param>
        /// <returns></returns>
        public string UpdateVendor(VendorEntity vendorEntity)
        {
            const string sql = @"uspUpdate_Vendor";
            return Db.Update(sql, true, Take(vendorEntity));
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="vendorEntity">The vendor entity.</param>
        /// <returns></returns>
        public string DeleteVendor(VendorEntity vendorEntity)
        {
            const string sql = @"uspDelete_Vendor";
            object[] parms = { "@VendorID", vendorEntity.VendorId };
            return Db.Delete(sql, true, parms);
        }
    }
}
