/***********************************************************************
 * <copyright file="BuildingFacade.cs" company="BUCA JSC">
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


using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// BuildingFacade
    /// </summary>
    public class BuildingFacade
    {
        private static readonly IBuildingDao BuildingDao = DataAccess.DataAccess.BuildingDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the buildings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BuildingResponse GetBuildings(BuildingRequest request)
        {
            var response = new BuildingResponse();

            if (request.LoadOptions.Contains("Buildings"))
            {
                response.Buildings = request.LoadOptions.Contains("IsActive")
                                                ? BuildingDao.GetBuildingsByActive(true)
                                                : BuildingDao.GetBuildings();
            }
            if (request.LoadOptions.Contains("Building"))
                response.Building = BuildingDao.GetBuilding(request.BuildingId);

            return response;
        }

        /// <summary>
        /// Sets the buildings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BuildingResponse SetBuildings(BuildingRequest request)
        {
            var response = new BuildingResponse();

            var buildingEntity = request.Building;
            if (request.Action != PersistType.Delete)
            {
                if (!buildingEntity.Validate())
                {
                    foreach (string error in buildingEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var buildingByCode = BuildingDao.GetBuildingsByBuildingCode(buildingEntity.BuildingCode);
                    if (buildingByCode != null && buildingByCode.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã thuê nhà " + buildingEntity.BuildingCode + @" đã tồn tại !";
                        return response;
                    }

                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Building");
                    buildingEntity.BuildingId = BuildingDao.InsertBuilding(buildingEntity);
                    if (buildingEntity.BuildingId == 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    var buildingByCode = BuildingDao.GetBuildingsByBuildingCode(buildingEntity.BuildingCode);
                    if (buildingByCode != null && buildingByCode.Count > 0)
                    {
                        if (buildingByCode.Where(w => w.BuildingId != buildingEntity.BuildingId).Count() > 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã thuê nhà " + buildingByCode.FirstOrDefault().BuildingCode + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = BuildingDao.UpdateBuilding(buildingEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                }
                else
                {
                    var buildingForUpdate = BuildingDao.GetBuilding(request.BuildingId);
                    response.Message = BuildingDao.DeleteBuilding(buildingForUpdate);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.BuildingId = buildingEntity != null ? buildingEntity.BuildingId : 0;
            response.Acknowledge = AcknowledgeType.Success;

            return response;
        }
    }
}
