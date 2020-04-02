/***********************************************************************
 * <copyright file="IBuildingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
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
    /// IBuildingDao
    /// </summary>
    public interface IBuildingDao
    {
        /// <summary>
        /// Gets the building.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns></returns>
        BuildingEntity GetBuilding(int buildingId);

        /// <summary>
        /// Gets the buildings.
        /// </summary>
        /// <returns></returns>
        List<BuildingEntity> GetBuildings();

        /// <summary>
        /// Gets the buildings by building code.
        /// </summary>
        /// <param name="buildingCode">The building code.</param>
        /// <returns></returns>
        List<BuildingEntity> GetBuildingsByBuildingCode(string buildingCode);

        /// <summary>
        /// Gets the buildings by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BuildingEntity> GetBuildingsByActive(bool isActive);

        /// <summary>
        /// Gets the buildings for estimate report.
        /// </summary>
        /// <returns></returns>
        List<BuildingEntity> GetBuildingsForEstimateReport(bool isCompanyProfile);

        /// <summary>
        /// Inserts the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        int InsertBuilding(BuildingEntity building);

        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        string UpdateBuilding(BuildingEntity building);

        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        string DeleteBuilding(BuildingEntity building);
    }
}
