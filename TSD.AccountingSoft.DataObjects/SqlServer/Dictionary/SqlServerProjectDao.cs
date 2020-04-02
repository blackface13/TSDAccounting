/***********************************************************************
 * <copyright file="SqlServerAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// class SqlServerProjectDao
    /// </summary>
    public class SqlServerProjectDao : IProjectDao
    {
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public ProjectEntity GetProject(int projectId)
        {
            const string sql = @"uspGet_Project_ByID";

            object[] parms = { "@ProjectID", projectId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        public List<ProjectEntity> GetProjects()
        {
            const string procedures = @"uspGet_All_Project";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the projects by project code.
        /// </summary>
        /// <param name="projectCode">The project code.</param>
        /// <returns></returns>
        public List<ProjectEntity> GetProjectsByProjectCode(string projectCode)
        {
            const string sql = @"uspGet_Project_ByProjectCode";

            object[] parms = { "@ProjectCode", projectCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the projects by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<ProjectEntity> GetProjectsByActive(bool isActive)
        {
            const string sql = @"uspGet_Project_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public int InsertProject(ProjectEntity project)
        {
            const string sql = @"uspInsert_Project";
            return Db.Insert(sql, true, Take(project));
        }

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public string UpdateProject(ProjectEntity project)
        {
            const string sql = @"uspUpdate_Project";
            return Db.Update(sql, true, Take(project));
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public string DeleteProject(ProjectEntity project)
        {
            const string sql = @"uspDelete_Project";

            object[] parms = { "@ProjectId", project.ProjectId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ProjectEntity> Make = reader =>
            new ProjectEntity
            {
                ProjectId = reader["ProjectID"].AsInt(),
                ProjectCode = reader["ProjectCode"].AsString(),
                ProjectName = reader["ProjectName"].AsString(),
                ParentId = reader["ParentID"].AsString().AsIntForNull(),
                ForeignName = reader["ForeignName"].AsString(),
                Grade = reader["Grade"].AsInt(),
                IsParent = reader["IsParent"].AsBool(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
            };

        /// <summary>
        /// Takes the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        private object[] Take(ProjectEntity account)
        {
            return new object[]  
            {
            "@ProjectID", account.ProjectId,    
            "@ProjectCode", account.ProjectCode,   
            "@ProjectName" , account.ProjectName,
            "@ForeignName" , account.ForeignName,
            "@ParentID" , account.ParentId ,
            "@Grade" , account.Grade ,
            "@IsParent" , account.IsParent ,
            "@Description", account.Description ,
            "@IsActive" , account.IsActive
            };
        }

    }
}
