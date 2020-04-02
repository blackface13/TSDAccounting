/***********************************************************************
 * <copyright file="BuildingPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Building
{
    /// <summary>
    /// class BuildingPresenter
    /// </summary>
    public class BuildingPresenter : Presenter<IBuildingView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BuildingPresenter(IBuildingView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified building identifier.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        public void Display(string buildingId)
        {
            if (buildingId == null)
            {
                View.BuildingId = 0;
                return;
            }

            var building = Model.GetBuilding(int.Parse(buildingId));

            View.BuildingId = building.BuildingId;
            View.BuildingCode = building.BuildingCode;
            View.BuildingName = building.BuildingName;
            View.JobCandidate = building.JobCandidate;
            View.StartDate = building.StartDate;
            View.EndDate = building.EndDate;
            View.Description = building.Description;
            View.IsActive = building.IsActive;
            View.Address = building.Address;
            View.Area = building.Area;
            View.UnitPrice = building.UnitPrice;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var building = new BuildingModel
            {
                BuildingId = View.BuildingId,
                BuildingCode = View.BuildingCode,
                BuildingName = View.BuildingName,
                JobCandidate = View.JobCandidate,
                StartDate = View.StartDate,
                EndDate = View.EndDate,
                Description = View.Description,
                IsActive = View.IsActive,
                Address = View.Address,
                Area = View.Area,
                UnitPrice = View.UnitPrice
            };

            return View.BuildingId == 0 ? Model.AddBuilding(building) : Model.UpdateBuilding(building);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="accountId">The accont identifier.</param>
        /// <returns></returns>
        public int Delete(int accountId)
        {
            return Model.DeleteBuilding(accountId);
        }
    }
}
