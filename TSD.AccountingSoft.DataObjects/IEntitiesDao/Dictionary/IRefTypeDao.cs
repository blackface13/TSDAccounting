/***********************************************************************
 * <copyright file="IRefTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
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
    /// IRefTypeDao
    /// </summary>
    public interface IRefTypeDao
    {
        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        List<RefTypeEntity> GetRefTypes();

        /// <summary>
        /// Gets the reference type search.
        /// </summary>
        /// <returns></returns>
        List<RefTypeEntity> GetRefTypeSearch();


        RefTypeEntity GetRefType(int refTypeId);

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeEntity">The reference type entity.</param>
        /// <returns></returns>
        string UpdateRefType(RefTypeEntity refTypeEntity);

        string DeleteRefTypeConvert();

        string InsertReftype(RefTypeEntity refTypeEntity);
    }
}
