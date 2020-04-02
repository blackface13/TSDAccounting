/***********************************************************************
 * <copyright file="EstimateDetailStatementFixedAssetsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Thursday, June 23, 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;
using TSD.AccountingSoft.View.Estimate;


namespace TSD.AccountingSoft.Presenter.Estimate.EstimateDetailStatementFixedAsset
{
    /// <summary>
    /// class EstimateDetailStatementFixedAssetsPresenter 
    /// </summary>
    public class EstimateDetailStatementFixedAssetsPresenter : Presenter<IEstimateDetailStatementFixedAssetView>
    {
        public EstimateDetailStatementFixedAssetsPresenter(IEstimateDetailStatementFixedAssetView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.EstimateDetailStatementFixedAsset = Model.GetEstimateDetailStatementFixedAssets();
        }

        /// <summary>
        /// Saves the specified estimate detail statement part b.
        /// </summary>
        /// <param name="estimateDetailStatementFixedAsset">The estimate detail statement part b.</param>
        /// <returns></returns>
        public int Save(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementFixedAsset)
        {
            return Model.UpdateEstimateDetailStatementFixedAsset(estimateDetailStatementFixedAsset);
        }
    }
}
