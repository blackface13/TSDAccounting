/***********************************************************************
 * <copyright file="IDBOptionDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// IDBOptionDao
    /// </summary>
    public interface IDBOptionDao
    {
        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="dBOptionId">The d b option identifier.</param>
        /// <returns></returns>
        DBOptionEntity GetDBOption(string dBOptionId);

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns></returns>
        List<DBOptionEntity> GetDBOptions();

        /// <summary>
        /// Gets the database options by system.
        /// </summary>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <returns></returns>
        List<DBOptionEntity> GetDBOptionsBySystem(bool isSystem);

        /// <summary>
        /// Gets the type of the database options by value.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns></returns>
        List<DBOptionEntity> GetDBOptionsByValueType(int valueType);

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dBOption">The d b option.</param>
        /// <returns></returns>
        string UpdateDBOption(DBOptionEntity dBOption);
    }
}
