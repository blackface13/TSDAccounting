/***********************************************************************
 * <copyright file="BuildingPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
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


namespace TSD.AccountingSoft.Presenter.Dictionary.Mutual
{
    /// <summary>
    /// class BuildingPresenter
    /// </summary>
    public class MutualPresenter : Presenter<IMutualView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public MutualPresenter(IMutualView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified building identifier.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        public void Display(string mutualId)
        {
            if (mutualId == null)
            {
                View.MutualId = 0;
                return;
            }

            var mutual = Model.GetMutual(int.Parse(mutualId));
            View.Description = mutual.Description;
            View.IsActive = mutual.IsActive;
            View.Address = mutual.Address;
            View.Area = mutual.Area;
            View.TotalFloor = mutual.TotalFloor;
            View.UseDate = mutual.UseDate;
            View.State = mutual.State;
            View.MutualName = mutual.MutualName;
            View.MutualId = mutual.MutualId;
            View.MutualCode = mutual.MutualCode;
            View.JobCandidate = mutual.JobCandidate;
            
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var mutual = new MutualModel
            {

                Description = View.Description,
                IsActive = View.IsActive,
                Address = View.Address,
                Area = View.Area,
                UseDate = View.UseDate,
                TotalFloor =View.TotalFloor,
                MutualName =View.MutualName,
                MutualId = View.MutualId,
                JobCandidate = View.JobCandidate,
                 MutualCode=View.MutualCode,
                 State = View.State  
            };

            return View.MutualId == 0 ? Model.AddMutual(mutual) : Model.UpdateMutual(mutual);
        }


        public int Delete(int mutualId)
        {
            return Model.DeleteMutual(mutualId);
        }
    }
}
