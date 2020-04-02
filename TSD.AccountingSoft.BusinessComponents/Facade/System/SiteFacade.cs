/***********************************************************************
 * <copyright file="SiteFacade.cs" company="BUCA JSC">
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
    /// class SiteFacade
    /// </summary>
    public class SiteFacade
    {
        private static readonly ISiteDao SiteDao = DataAccess.DataAccess.SiteDao;
        private static readonly IPermissionSiteDao PermissionSiteDao = DataAccess.DataAccess.PermissionSiteDao;

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SiteResponse GetSites(SiteRequest request)
        {
            var response = new SiteResponse();

            if (request.LoadOptions.Contains("Sites"))
            {
                if (request.LoadOptions.Contains("Active"))
                {
                    response.Sites = SiteDao.GetSites(request.IsActive);
                    if (request.LoadOptions.Contains("Permissions"))
                    {
                        foreach (var site in response.Sites)
                            site.PermissionSiteEntities = PermissionSiteDao.GetPermissionSitesBySiteId(site.SiteId);
                    }
                }
                else
                    response.Sites = SiteDao.GetSites();
            }
            if (request.LoadOptions.Contains("Site"))
            {
                response.Site = SiteDao.GetSite(request.SiteId);
                if (request.LoadOptions.Contains("PermissionSite"))
                    response.Site.PermissionSiteEntities = PermissionSiteDao.GetPermissionSitesBySiteId(request.SiteId);
            }
            return response;
        }

        /// <summary>
        /// Sets the sites.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SiteResponse SetSites(SiteRequest request)
        {
            var response = new SiteResponse();

            var siteEntity = request.Site;
            if (request.Action != PersistType.Delete)
            {
                if (!siteEntity.Validate())
                {
                    foreach (var error in siteEntity.ValidationErrors)
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
                        siteEntity.SiteId = SiteDao.InsertSite(siteEntity);
                        if (siteEntity.SiteId == 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var permissionSite in siteEntity.PermissionSiteEntities)
                        {
                            permissionSite.SiteId = siteEntity.SiteId;
                            if (!permissionSite.Validate())
                            {
                                foreach (var error in permissionSite.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            permissionSite.PermissionSiteId = PermissionSiteDao.InsertPermissionSite(permissionSite);
                            if (permissionSite.PermissionId == 0)
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
                        response.Message = SiteDao.UpdateSite(siteEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //delete detail
                        response.Message = PermissionSiteDao.DeletePermissionSiteBySiteId(siteEntity.SiteId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var permissionSite in siteEntity.PermissionSiteEntities)
                        {
                            permissionSite.SiteId = siteEntity.SiteId;
                            if (!permissionSite.Validate())
                            {
                                foreach (var error in permissionSite.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            permissionSite.PermissionSiteId = PermissionSiteDao.InsertPermissionSite(permissionSite);
                            if (permissionSite.PermissionId == 0)
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
                    var siteForDelete = SiteDao.GetSite(request.SiteId);
                    response.Message = SiteDao.DeleteSite(siteForDelete);
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
            response.SiteId = siteEntity != null ? siteEntity.SiteId : 0;
            return response;
        }
    }
}
