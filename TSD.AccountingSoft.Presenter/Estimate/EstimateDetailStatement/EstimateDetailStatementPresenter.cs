/***********************************************************************
 * <copyright file="EstimateDetailStatementPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, June 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;


namespace TSD.AccountingSoft.Presenter.Estimate.EstimateDetailStatement
{
    /// <summary>
    /// class EstimateDetailStatementPresenter
    /// </summary>
    public class EstimateDetailStatementPresenter : Presenter<IEstimateDetailStatementView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailStatementPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public EstimateDetailStatementPresenter(IEstimateDetailStatementView view) : base(view)
        {
        }
        
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        /// 
        public long Save()
        {
            var estimateDetailStatement = new EstimateDetailStatementInfoModel
            {
                EstimateDetailStatementId = View.EstimateDetailStatementId,
                GeneralDescription = View.GeneralDescription,
                EmployeeContractDescription = View.EmployeeContractDescription,
                EmployeeLeasingDescription = View.EmployeeLeasingDescription,
                InventoryDescription = View.InventoryDescription,
                BuildingOfFixedAssetDescription = View.BuildingOfFixedAssetDescription,
                CarDescription = View.CarDescription,
                DescriptionForBuilding = View.DescriptionForBuilding,
                PartC = View.PartC,
                PartC1 = View.PartC1,
                IsActive = View.IsActive,
                Type = View.Type
                
            };
            return View.EstimateDetailStatementId = Model.UpdateEstimateDetailStatementInfo(estimateDetailStatement);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="isActive">The estimate detail statement identifier.</param>
        public void Display(bool isActive)
        {
            var estimateDetailStatement = Model.GetEstimateDetailStatementInfo(isActive);
            if (estimateDetailStatement == null) return;
            
            View.EstimateDetailStatementId = estimateDetailStatement.EstimateDetailStatementId;
            View.GeneralDescription = estimateDetailStatement.GeneralDescription;
            View.EmployeeContractDescription = estimateDetailStatement.EmployeeContractDescription;
            View.EmployeeLeasingDescription = estimateDetailStatement.EmployeeLeasingDescription;
            View.BuildingOfFixedAssetDescription = estimateDetailStatement.BuildingOfFixedAssetDescription;
            View.CarDescription = estimateDetailStatement.CarDescription;
            View.DescriptionForBuilding = estimateDetailStatement.DescriptionForBuilding;
            View.PartC = estimateDetailStatement.PartC;
            View.PartC1 = estimateDetailStatement.PartC1;
            View.InventoryDescription = estimateDetailStatement.InventoryDescription;
            View.IsActive = estimateDetailStatement.IsActive;
        }

        public void DisplayCompanyProfileInfo(bool isActive)
        {
            var estimateDetailStatement = Model.GetCompanyProfileInfo(isActive);
            if (estimateDetailStatement == null) return;

            View.EstimateDetailStatementId = estimateDetailStatement.EstimateDetailStatementId;
            View.GeneralDescription = estimateDetailStatement.GeneralDescription;
            View.EmployeeContractDescription = estimateDetailStatement.EmployeeContractDescription;
            View.EmployeeLeasingDescription = estimateDetailStatement.EmployeeLeasingDescription;
            View.BuildingOfFixedAssetDescription = estimateDetailStatement.BuildingOfFixedAssetDescription;
            View.CarDescription = estimateDetailStatement.CarDescription;
            View.DescriptionForBuilding = estimateDetailStatement.DescriptionForBuilding;
            View.PartC = estimateDetailStatement.PartC;
            View.InventoryDescription = estimateDetailStatement.InventoryDescription;
            View.IsActive = estimateDetailStatement.IsActive;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(int refId)
        {
            return Model.DeleteEstimateDetailStatementInfo(refId);
        }
    }
}
