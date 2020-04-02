/***********************************************************************
 * <copyright file="RoleFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;


namespace TSD.AccountingSoft.BusinessComponents.Facade.System
{
    /// <summary>
    /// class RoleFacade
    /// </summary>
    public class RoleFacade
    {
        private static readonly IRoleDao RoleDao = DataAccess.DataAccess.RoleDao;
        private static readonly IRoleSiteDao RoleSiteDao = DataAccess.DataAccess.RoleSiteDao;

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RoleResponse GetRoles(RoleRequest request)
        {
            var response = new RoleResponse();

            if (request.LoadOptions.Contains("Roles"))
                response.Roles = request.LoadOptions.Contains("Active") ? RoleDao.GetRoles(request.IsActive) : RoleDao.GetRoles();
            if (request.LoadOptions.Contains("Role"))
            {
                response.Role = RoleDao.GetRole(request.RoleId);
                if (request.LoadOptions.Contains("RoleSite"))
                    response.Role.RoleSiteEntities = RoleSiteDao.GetRoleSiteByRoleId(request.RoleId);
            }

            return response;
        }

        /// <summary>
        /// Sets the roles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RoleResponse SetRoles(RoleRequest request)
        {
            var response = new RoleResponse();

            var roleEntity = request.Role;
            if (request.Action != PersistType.Delete)
            {
                if (!roleEntity.Validate())
                {
                    foreach (var error in roleEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    using (var scope = new TransactionScope())
                    {
                        roleEntity.RoleId = RoleDao.InsertRole(roleEntity);
                        if (roleEntity.RoleId == 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var roleSite in roleEntity.RoleSiteEntities)
                        {
                            roleSite.RoleId = roleEntity.RoleId;
                            if (!roleSite.Validate())
                            {
                                foreach (var error in roleSite.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            roleSite.RoleSiteId = RoleSiteDao.InsertRoleSite(roleSite);
                            if (roleSite.RoleSiteId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                        }
                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        response.Message = RoleDao.UpdateRole(roleEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //delete & insert new role in site
                        response.Message = RoleSiteDao.DeleteRoleSiteByRoleId(roleEntity.RoleId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var roleSite in roleEntity.RoleSiteEntities)
                        {
                            roleSite.RoleId = roleEntity.RoleId;
                            if (!roleSite.Validate())
                            {
                                foreach (var error in roleSite.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            roleSite.RoleSiteId = RoleSiteDao.InsertRoleSite(roleSite);
                            if (roleSite.RoleSiteId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                        }
                        scope.Complete();
                    }
                }
                else
                {
                    var roleForDelete = RoleDao.GetRole(request.RoleId);
                    response.Message = RoleDao.DeleteRole(roleForDelete);
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
            response.RoleId = roleEntity != null ? roleEntity.RoleId : 0;
            return response;
        }
    }
}
