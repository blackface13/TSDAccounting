/***********************************************************************
 * <copyright file="IGeneralDao.cs" company="BUCA JSC">
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
    /// Interface IGeneralDao
    /// </summary>
    public interface IGeneralDao
    {

        /// <summary>
        /// Gets the general.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>GeneralEntity.</returns>
        GeneralEntity GetGeneral(long refId);

        /// <summary>
        /// Gets the general by reference type identifier.
        /// </summary>
        /// <param name="reftypeId">The reftype identifier.</param>
        /// <returns>List&lt;GeneralEntity&gt;.</returns>
        List<GeneralEntity> GetGeneralByRefTypeId(int reftypeId);

        /// <summary>
        /// Gets the general by is capital allocate.
        /// </summary>
        /// <returns>List&lt;GeneralEntity&gt;.</returns>
        List<GeneralEntity> GetGeneralByIsCapitalAllocate();

        /// <summary>
        /// Gets the general by refdate and reftype.
        /// </summary>
        /// <param name="objGeneralEntity">The object general entity.</param>
        /// <returns>GeneralEntity.</returns>
        GeneralEntity GetGeneralByRefdateAndReftype(GeneralEntity objGeneralEntity);


        /// <summary>
        /// Gets the general by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;GeneralEntity&gt;.</returns>
        List<GeneralEntity> GetGeneralByRefNo(string refNo);


        /// <summary>
        /// Gets the generals.
        /// </summary>
        /// <returns>List&lt;GeneralEntity&gt;.</returns>
        List<GeneralEntity> GetGenerals();

        GeneralEntity GetGeneralVoucher(int refType, long refForeignId);


        /// <summary>
        /// Inserts the general.
        /// </summary>
        /// <param name="general">The general.</param>
        /// <returns>System.Int32.</returns>
        int InsertGeneral(GeneralEntity general);


        /// <summary>
        /// Updates the general.
        /// </summary>
        /// <param name="general">The general.</param>
        /// <returns>System.String.</returns>
        string UpdateGeneral(GeneralEntity general);


        /// <summary>
        /// Deletes the general.
        /// </summary>
        /// <param name="general">The general.</param>
        /// <returns>System.String.</returns>
        string DeleteGeneral(GeneralEntity general);


        /// <summary>
        /// Deletes the general detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteGeneralDetail(long refId);
    }
}
