/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateList
{
    /// <summary>
    /// Class PlanTemplateListPresenter.
    /// </summary>
    public class PlanTemplateListPresenter : Presenter<IPlanTemplateListView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanTemplateListPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PlanTemplateListPresenter(IPlanTemplateListView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified plan template list identifier.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        public void Display(string planTemplateListId)
        {
            if (planTemplateListId == null) { View.PlanTemplateListId = 0; return; }

            var planTemplateList = Model.GetPlanTemplateList(int.Parse(planTemplateListId));
            View.PlanTemplateListId = planTemplateList.PlanTemplateListId;
            View.PlanTemplateListCode = planTemplateList.PlanTemplateListCode;
            View.PlanTemplateListName = planTemplateList.PlanTemplateListName;
            View.PlanType = planTemplateList.PlanType;
            View.PlanYear = planTemplateList.PlanYear;
            View.PlanTemplateItems = planTemplateList.PlanTemplateItems;
            View.ParentId = planTemplateList.ParentId;
        }

        /// <summary>
        /// Displays the specified plan template list identifier.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <param name="keyValue">The key value.</param>
        public void DisplayDetail(string planTemplateListId, string keyValue)
        {
            if (planTemplateListId == null) { View.PlanTemplateListId = 0; return; }

            var planTemplateList = Model.GetPlanTemplateList(int.Parse(planTemplateListId));
            View.PlanTemplateItems = planTemplateList.PlanTemplateItems;
            View.PlanTemplateListId = keyValue == null ? 0 : int.Parse(keyValue);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var planTemplateList = new PlanTemplateListModel
                {
                    PlanTemplateListId = View.PlanTemplateListId,
                    PlanTemplateListCode = View.PlanTemplateListCode,
                    PlanTemplateListName = View.PlanTemplateListName,
                    PlanType = View.PlanType,
                    PlanYear = View.PlanYear,
                    PlanTemplateItems = View.PlanTemplateItems,
                    ParentId = View.ParentId
                };

            return View.PlanTemplateListId == 0 ? Model.AddPlanTemplateList(planTemplateList) : Model.UpdatePlanTemplateList(planTemplateList);
        }

        /// <summary>
        /// Deletes the specified budget item identifier.
        /// </summary>
        /// <param name="planTemplateListId">The budget item identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int planTemplateListId)
        {
            return Model.DeletePlanTemplateList(planTemplateListId);
        }
    }
}
