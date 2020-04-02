/***********************************************************************
 * <copyright file="ICashDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash
{

    /// <summary>
    /// ICashDetailDao interface
    /// </summary>
    public interface ICashDetailDao
    {
        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="cashId">The cash identifier.</param>
        /// <returns></returns>
        List<CashDetailEntity> GetCashDetailsByCash(long cashId);

        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="cashDetail">The cash detail.</param>
        /// <returns></returns>
        int InsertCashDetail(CashDetailEntity cashDetail);

        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="cashId">The cash identifier.</param>
        /// <returns></returns>
        string DeleteCashDetailByCash(long cashId);

        List<CashParalellDetailEntity> GetReceiptDetailsParalellbyCash (long cashId);

        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="cashDetail">The cash detail.</param>
        /// <returns></returns>
        int InsertReceiptDetailParalell(CashParalellDetailEntity cashParalellDetailEntity);

        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="cashId">The cash identifier.</param>
        /// <returns></returns>
        string DeleteReceipDetailParalellByCash(long cashId);
    }
}
