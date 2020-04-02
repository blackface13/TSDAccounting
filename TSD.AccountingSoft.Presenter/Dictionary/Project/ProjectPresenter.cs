/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Project
{
    /// <summary>
    /// class ProjectPresenter
    /// </summary>
    public class ProjectPresenter : Presenter<IProjectView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ProjectPresenter(IProjectView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget item identifier.
        /// </summary>
        /// <param name="projectId">The budget item identifier.</param>
        public void Display(string projectId)
        {
            if (projectId == null) { View.ProjectId = 0; return; }

            var project = Model.GetProject(int.Parse(projectId));
            View.ProjectId = project.ProjectId;
            View.ProjectCode = project.ProjectCode;
            View.ProjectName = project.ProjectName;
            View.ForeignName = project.ForeignName;
            View.ParentId = project.ParentId;
            View.IsParent = project.IsParent;
            View.IsActive = project.IsActive;
            View.Grade = project.Grade;
            View.Description = project.Description;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var project = new ProjectModel
            {
                ProjectId = View.ProjectId,
                ProjectName = View.ProjectName,
                ProjectCode = View.ProjectCode,
                ForeignName = View.ForeignName,
                ParentId = View.ParentId,
                IsActive = View.IsActive,
                IsParent = View.IsParent,
                Description = View.Description,
                Grade = View.Grade
            };

            return View.ProjectId == 0 ? Model.AddProject(project) : Model.UpdateProject(project);
        }

        /// <summary>
        /// Deletes the specified budget item identifier.
        /// </summary>
        /// <param name="projectId">The budget item identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int projectId)
        {
            return Model.DeleteProject(projectId);
        }
    }
}
