/***********************************************************************
 * <copyright file="IVoucherListDao.cs" company="BUCA JSC">
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
    /// IVoucherListDao interface
    /// </summary>
    public interface IVoucherListDao
    {
        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="voucherId">The voucher identifier.</param>
        /// <returns></returns>
        VoucherListEntity GetVoucherListById(int voucherId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        List<VoucherListEntity> GetVoucherLists();

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        int InsertVoucherList(VoucherListEntity voucherListEntity);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        string UpdateVoucherList(VoucherListEntity voucherListEntity);

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        string DeleteVoucherList(VoucherListEntity voucherListEntity);
    }
}
