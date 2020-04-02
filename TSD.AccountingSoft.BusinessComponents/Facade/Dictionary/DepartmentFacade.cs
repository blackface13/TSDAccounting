/***********************************************************************
 * <copyright file="DepartmentFacade.cs" company="BUCA JSC">
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

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// DepartmentFacade
    /// </summary>
    public class DepartmentFacade
    {
        private static readonly IDepartmentDao DepartmentDao = DataAccess.DataAccess.DepartmentDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public DepartmentResponse GetDepartments(DepartmentRequest request)
        {
            var response = new DepartmentResponse();

            if (request.LoadOptions.Contains("Departments"))
            {
                if (request.LoadOptions.Contains("IsActive")) 
                    response.Departments = DepartmentDao.GetDepartmentsByActive(true);
                else 
                    response.Departments = DepartmentDao.GetDepartments();
            }
            if (request.LoadOptions.Contains("Department")) 
                response.Department = DepartmentDao.GetDepartment(request.DepartmentId);

            return response;
        }

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public DepartmentResponse SetDepartments(DepartmentRequest request)
        {
            var response = new DepartmentResponse();

            var departmentEntity = request.Department;
            if (request.Action != PersistType.Delete)
            {
                if (!departmentEntity.Validate())
                {
                    foreach (string error in departmentEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var departments = DepartmentDao.GetDepartmentsByDepartmentCode(departmentEntity.DepartmentCode);
                    if (departments.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã phòng ban " + departmentEntity.DepartmentCode + @" đã tồn tại !";
                        return response;
                    }
                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Department");
                    departmentEntity.DepartmentId = DepartmentDao.InsertDepartment(departmentEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = DepartmentDao.UpdateDepartment(departmentEntity);
                else
                {
                    var departmentForUpdate = DepartmentDao.GetDepartment(request.DepartmentId);
                    response.Message = DepartmentDao.DeleteDepartment(departmentForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.DepartmentId = departmentEntity != null ? departmentEntity.DepartmentId : 0;
            if (response.Message == null)
            {
                response.Acknowledge = AcknowledgeType.Success;
                response.RowsAffected = 1;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure; 
                response.RowsAffected = 0;
            }

            return response;
        }
    }
}
