/***********************************************************************
 * <copyright file="IVoucherTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
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
    /// 
    /// </summary>
    public interface IVoucherTypeDao
    {
        /// <summary>
        /// Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        List<VoucherTypeEntity> GetVoucherTypes();

        /// <summary>
        /// Gets the voucher types by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<VoucherTypeEntity> GetVoucherTypesByIsActive(bool isActive);

        VoucherTypeEntity GetVoucherTypeByCode(string code);
    }
}
