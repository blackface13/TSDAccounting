/***********************************************************************
 * <copyright file="ICustomerDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{

    /// <summary>
    /// ICustomerDao interface
    /// </summary>
    public interface ICustomerDao
    {

        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        CustomerEntity GetCustomerById(int customerId);

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="customerCode">The customer code.</param>
        /// <returns></returns>
        CustomerEntity GetCustomerByCode(string customerCode);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        List<CustomerEntity> GetCustomers();

        /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<CustomerEntity> GetCustomerByActives(bool isActive);

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="customerEntity">The customer entity.</param>
        /// <returns></returns>
        int InsertCustomer(CustomerEntity customerEntity);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="customerEntity">The customer entity.</param>
        /// <returns></returns>
        string UpdateCustomer(CustomerEntity customerEntity);

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="customerEntity">The customer entity.</param>
        /// <returns></returns>
        string DeleteCustomer(CustomerEntity customerEntity);

    }
}
