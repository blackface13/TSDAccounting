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

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateItem
{
    /// <summary>
    /// Class PlanTemplateItemsPresenter.
    /// </summary>
    public class PlanTemplateItemsPresenter : Presenter<IPlanTemplateItemsView>
    {
        public PlanTemplateItemsPresenter(IPlanTemplateItemsView view)
            : base(view)
        {
        }

        public void Display()
        {
            View.PlanTemplateItems = Model.GetPlanTemplateItems();
        }

        public void DisplayByPlanTemplateListId(int planTemplateListId)
        {
            View.PlanTemplateItems = Model.GetPlanTemplateItemsByPlanTemplateListId(planTemplateListId);
        }

        public void DisplayForEstimate(int planTemplateListId, short planYear, int budgetSourceCategoryId)
        {
            View.PlanTemplateItems = Model.GetPlanTemplateItemsForEstimate(planTemplateListId, planYear, budgetSourceCategoryId);
        }

        public void DisplayForEstimateUpdate(int planTemplateListId, short planYear, int budgetSourceCategoryId,int option)
        {
            View.PlanTemplateItems = Model.GetPlanTemplateItemsForEstimateUpdate(planTemplateListId, planYear, budgetSourceCategoryId, option);
        }

        /// <summary>
        /// LinhMC kiểm tra nếu mẫu dự toán đã được dùng trong chứng từ dự toán thì ko cho sửa 1 số thông tin
        /// chỉ cho phép thêm chỉ tiêu.
        /// Checks the constraint data.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns></returns>
        public bool CheckConstraintData(int planTemplateListId)
        {
            return Model.CheckConstraintPlanTemplateList(planTemplateListId);
        }
    }
}
