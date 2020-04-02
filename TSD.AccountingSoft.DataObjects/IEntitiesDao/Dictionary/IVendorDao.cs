/***********************************************************************
 * <copyright file="IVendorDao.cs" company="BUCA JSC">
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
    /// IVendorDao interface
    /// </summary>
    public interface IVendorDao
    {

        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        VendorEntity GetVendorById(int vendorId);

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="vendorCode">The vendor code.</param>
        /// <returns></returns>
        VendorEntity GetVendorByCode(string vendorCode);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        List<VendorEntity> GetVendors();

        /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<VendorEntity> GetVendorByActives(bool isActive);

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="vendorEntity">The vendor entity.</param>
        /// <returns></returns>
        int InsertVendor(VendorEntity vendorEntity);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="vendorEntity">The vendor entity.</param>
        /// <returns></returns>
        string UpdateVendor(VendorEntity vendorEntity);

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="vendorEntity">The vendor entity.</param>
        /// <returns></returns>
        string DeleteVendor(VendorEntity vendorEntity);
    }
}
