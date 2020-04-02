/***********************************************************************
 * <copyright file="MergerFundPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.MergerFund
{
    /// <summary>
    /// Class MergerFundPresenter.
    /// </summary>
    public class MergerFundPresenter : Presenter<IMergerFundView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MergerFundPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public MergerFundPresenter(IMergerFundView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified mergerFund identifier.
        /// </summary>
        /// <param name="mergerFundId">The mergerFund identifier.</param>
        public void Display(string mergerFundId)
        {
            if (mergerFundId == null) { View.MergerFundId = 0; return; }
            var mergerFund = Model.GetMergerFund(int.Parse(mergerFundId));
            View.MergerFundId = mergerFund.MergerFundId;
            View.MergerFundCode = mergerFund.MergerFundCode;
            View.MergerFundName = mergerFund.MergerFundName;
            View.ParentId = mergerFund.ParentId;
            View.Description = mergerFund.Description;
            View.IsActive = mergerFund.IsActive;
            View.IsSystem = mergerFund.IsSystem;
            View.Grade = mergerFund.Grade;
            View.ForeignName = mergerFund.ForeignName;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var mergerFund = new MergerFundModel
            {
                MergerFundId = View.MergerFundId,
                MergerFundCode = View.MergerFundCode,
                MergerFundName = View.MergerFundName,
                ParentId = View.ParentId,
                Description = View.Description,
                IsActive = View.IsActive,
                IsSystem = View.IsSystem,
                Grade = View.Grade,
                ForeignName = View.ForeignName
            };
            if (View.MergerFundId == 0)
                return Model.AddMergerFund(mergerFund);
            return Model.UpdateMergerFund(mergerFund);
        }

        /// <summary>
        /// Deletes the specified mergerFund identifier.
        /// </summary>
        /// <param name="mergerFundId">The mergerFund identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int mergerFundId)
        {
            return Model.DeleteMergerFund(mergerFundId);
        }
    }
}