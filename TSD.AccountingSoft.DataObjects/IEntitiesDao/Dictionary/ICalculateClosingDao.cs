/***********************************************************************
 * <copyright file="ICalculateClosingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, December 23, 2014
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
    /// ICalculateClosingDao
    /// </summary>
    public interface ICalculateClosingDao
    {
        /// <summary>
        /// Lấy tổng tiền dư để kiểm tra số tiền chi có thể chi
        /// </summary>
        /// <param name="PaymentAccountCode">The payment account code.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="currentcyCode">The currentcy code.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isApproximate">if set to <c>true</c> [is approximate].</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        CalculateClosingEntity GetCalculateClosing(string PaymentAccountCode, string whereClause, string currentcyCode, string toDate, bool isApproximate, long refId,int refTypeId);
        CalculateClosingEntity AmountExist(string accountCode,string currentcyCode);
    }
}
