/***********************************************************************
 * <copyright file="IBudgetCategoryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 March 2014
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
    /// interface IProjectDao
    /// </summary>
    public interface IProjectDao
    {
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        ProjectEntity GetProject(int projectId);

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        List<ProjectEntity> GetProjects();

        /// <summary>
        /// Gets the projects by project code.
        /// </summary>
        /// <param name="projectCode">The project code.</param>
        /// <returns></returns>
        List<ProjectEntity> GetProjectsByProjectCode(string projectCode);

        /// <summary>
        /// Gets the projects by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<ProjectEntity> GetProjectsByActive(bool isActive);

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        int InsertProject(ProjectEntity project);

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        string UpdateProject(ProjectEntity project);

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        string DeleteProject(ProjectEntity project);
    }
}
