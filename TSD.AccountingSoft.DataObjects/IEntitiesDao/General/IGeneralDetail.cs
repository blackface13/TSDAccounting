/***********************************************************************
 * <copyright file="IGeneralDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.General;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.General
{
    /// <summary>
    /// Interface IGeneralDetailDao
    /// </summary>
    public  interface IGeneralDetailDao
    {

        /// <summary>
        /// Gets the general details by general.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;GeneralDetailEntity&gt;.</returns>
        List<GeneralDetailEntity> GetGeneralDetailsByGeneral(long refId);

        /// <summary>
        /// Inserts the general detail.
        /// </summary>
        /// <param name="generalDetail">The general detail.</param>
        /// <returns>System.Int32.</returns>
        int InsertGeneralDetail(GeneralDetailEntity generalDetail);

        /// <summary>
        /// Deletes the general details by general.
        /// </summary>
        /// <param name="generalDetail">The general detail.</param>
        /// <returns>System.String.</returns>
        string DeleteGeneralDetailsByGeneral(GeneralDetailEntity generalDetail);

        List<GeneralParalellDetailEntity> GetGeneralParalellDetailsByGeneral(long refId);

        int InsertGeneralParalellDetail(GeneralParalellDetailEntity generalParalellDetail);

        string DeleteGeneralParalellDetailsByGeneral(long refId);


    }
}
