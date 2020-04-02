/***********************************************************************
 * <copyright file="PermissionFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;


namespace TSD.AccountingSoft.BusinessComponents.Facade.System
{
    /// <summary>
    /// class PermissionFacade
    /// </summary>
    public class PermissionFacade
    {
        private static readonly IPermissionDao PermissionDao = DataAccess.DataAccess.PermissionDao;

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public PermissionResponse GetPermissions(PermissionRequest request)
        {
            var response = new PermissionResponse();

            if (request.LoadOptions.Contains("Permissions"))
                response.Permissions = request.LoadOptions.Contains("Active") ? PermissionDao.GetPermissions(request.IsActive) : PermissionDao.GetPermissions();
            if (request.LoadOptions.Contains("Permission"))
                response.Permission = PermissionDao.GetPermission(request.PermissionId);

            return response;
        }

        /// <summary>
        /// Sets the permissions.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public PermissionResponse SetPermissions(PermissionRequest request)
        {
            var response = new PermissionResponse();

            var permissionEntity = request.Permission;
            if (request.Action != PersistType.Delete)
            {
                if (!permissionEntity.Validate())
                {
                    foreach (var error in permissionEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    permissionEntity.PermissionId = PermissionDao.InsertPermission(permissionEntity);
                    if (permissionEntity.PermissionId == 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = PermissionDao.UpdatePermission(permissionEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                }
                else
                {
                    var permissionForDelete = PermissionDao.GetPermission(request.PermissionId);
                    response.Message = PermissionDao.DeletePermission(permissionForDelete);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.RowsAffected = 0;
                        return response;
                    }
                    response.RowsAffected = 1;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.PermissionId = permissionEntity != null ? permissionEntity.PermissionId : 0;
            return response;
        }
    }
}
