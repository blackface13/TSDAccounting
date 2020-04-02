/***********************************************************************
 * <copyright file="EmployeeLeasingFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 June 2014
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
    /// EmployeeLeasingFacade
    /// </summary>
    public class EmployeeLeasingFacade
    {
        private static readonly IEmployeeLeasingDao EmployeeLeasingDao = DataAccess.DataAccess.EmployeeLeasingDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the employeeLeasings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EmployeeLeasingResponse GetEmployeeLeasings(EmployeeLeasingRequest request)
        {
            var response = new EmployeeLeasingResponse();

            if (request.LoadOptions.Contains("EmployeeLeasings"))
            {
                if (request.LoadOptions.Contains("IsLeasing"))
                    response.EmployeeLeasings = EmployeeLeasingDao.GetEmployeeLeasings(request.IsLeasing);
                else
                    response.EmployeeLeasings = request.LoadOptions.Contains("IsActive")
                                                    ? EmployeeLeasingDao.GetEmployeeLeasingsByActive(true)
                                                    : EmployeeLeasingDao.GetEmployeeLeasings();
            }
            if (request.LoadOptions.Contains("EmployeeLeasing"))
                response.EmployeeLeasing = EmployeeLeasingDao.GetEmployeeLeasing(request.EmployeeLeasingId);

            return response;
        }

        /// <summary>
        /// Sets the employeeLeasings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EmployeeLeasingResponse SetEmployeeLeasings(EmployeeLeasingRequest request)
        {
            var response = new EmployeeLeasingResponse();

            var employeeLeasingEntity = request.EmployeeLeasing;
            if (request.Action != PersistType.Delete)
            {
                if (!employeeLeasingEntity.Validate())
                {
                    foreach (string error in employeeLeasingEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var GetEmployeeLeasingsByEmployeeLeasingCode = EmployeeLeasingDao.GetEmployeeLeasingsByEmployeeLeasingCode(employeeLeasingEntity.EmployeeLeasingCode);
                    if (GetEmployeeLeasingsByEmployeeLeasingCode != null && GetEmployeeLeasingsByEmployeeLeasingCode.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã nhân viên " + employeeLeasingEntity.EmployeeLeasingCode + @" đã tồn tại !";
                        return response;
                    }

                    if (employeeLeasingEntity.IsLeasing)
                        AutoNumberListDao.UpdateIncreateAutoNumberListByValue("EmployeeContract");
                    else
                        AutoNumberListDao.UpdateIncreateAutoNumberListByValue("EmployeeLeasing"); 

                    employeeLeasingEntity.EmployeeLeasingId = EmployeeLeasingDao.InsertEmployeeLeasing(employeeLeasingEntity);
                    if (employeeLeasingEntity.EmployeeLeasingId == 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    var employeeLeasingsByEmployeeLeasingCode = EmployeeLeasingDao.GetEmployeeLeasingsByEmployeeLeasingCode(employeeLeasingEntity.EmployeeLeasingCode);
                    if (employeeLeasingsByEmployeeLeasingCode != null && employeeLeasingsByEmployeeLeasingCode.Count > 0)
                    {
                        if (employeeLeasingsByEmployeeLeasingCode.Where(w => w.EmployeeLeasingId != employeeLeasingEntity.EmployeeLeasingId).Count() > 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã nhân viên " + employeeLeasingEntity.EmployeeLeasingCode + @" đã tồn tại !";
                            return response;
                        }
                    }

                    response.Message = EmployeeLeasingDao.UpdateEmployeeLeasing(employeeLeasingEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                }
                else
                {
                    var employeeLeasingForUpdate = EmployeeLeasingDao.GetEmployeeLeasing(request.EmployeeLeasingId);
                    response.Message = EmployeeLeasingDao.DeleteEmployeeLeasing(employeeLeasingForUpdate);
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
            response.EmployeeLeasingId = employeeLeasingEntity != null ? employeeLeasingEntity.EmployeeLeasingId : 0;
            response.Acknowledge = AcknowledgeType.Success;

            return response;
        }
    }
}
