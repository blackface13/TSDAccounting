/***********************************************************************
 * <copyright file="ProjectFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
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
    public class ProjectFacade
    {
        private static readonly IProjectDao ProjectDao = DataAccess.DataAccess.ProjectDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ProjectResponse GetProjects(ProjectRequest request)
        {
            var response = new ProjectResponse();

            if (request.LoadOptions.Contains("Projects"))
            {
                response.Projects = request.LoadOptions.Contains("IsActive") ? ProjectDao.GetProjectsByActive(true) : ProjectDao.GetProjects();
            }
            if (request.LoadOptions.Contains("Project"))
                response.Project = ProjectDao.GetProject(request.ProjectId);

            return response;
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ProjectResponse SetProjects(ProjectRequest request)
        {
            var response = new ProjectResponse();

            var projectEntity = request.Project;
            if (request.Action != PersistType.Delete)
            {
                if (!projectEntity.Validate())
                {
                    foreach (string error in projectEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var projects = ProjectDao.GetProjectsByProjectCode(projectEntity.ProjectCode);
                    if (projects.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã dự án " + projectEntity.ProjectCode + @" đã tồn tại !";
                        return response;
                    }
                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Project");
                    projectEntity.ProjectId = ProjectDao.InsertProject(projectEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = ProjectDao.UpdateProject(projectEntity);
                else
                {
                    var projectForUpdate = ProjectDao.GetProject(request.ProjectId);
                    response.Message = ProjectDao.DeleteProject(projectForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.ProjectId = projectEntity != null ? projectEntity.ProjectId : 0;
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
