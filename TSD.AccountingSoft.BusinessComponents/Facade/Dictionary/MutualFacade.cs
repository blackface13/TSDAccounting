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

    public class MutualFacade
    {
        private static readonly IMutualDao MutualDao = DataAccess.DataAccess.MutualDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        public MutualResponse GetMutuals(MutualRequest request)
        {
            var response = new MutualResponse();

            if (request.LoadOptions.Contains("Mutuals"))
            {
                response.Mutuals = request.LoadOptions.Contains("IsActive")
                                                ? MutualDao.GetMutualsByActive(true)
                                                : MutualDao.GetMutuals();
            }
            if (request.LoadOptions.Contains("Mutual"))
                response.Mutual = MutualDao.GetMutual(request.MutualId);

            return response;
        }

        public MutualResponse SetMutuals(MutualRequest request)
        {
            var response = new MutualResponse();

            var mutualEntity = request.Mutual;
            if (request.Action != PersistType.Delete)
            {
                if (!mutualEntity.Validate())
                {
                    foreach (string error in mutualEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    mutualEntity.MutualId = MutualDao.InsertMutual(mutualEntity);
                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Mutual");
                    if (mutualEntity.MutualId == 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = MutualDao.UpdateMutual(mutualEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                }
                else
                {
                    var mutualForUpdate = MutualDao.GetMutual(request.MutualId);
                    response.Message = MutualDao.DeleteBuilding(mutualForUpdate);
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
            response.MutualId = mutualEntity != null ? mutualEntity.MutualId : 0;
            response.Acknowledge = AcknowledgeType.Success;

            return response;
        }
    }
}
