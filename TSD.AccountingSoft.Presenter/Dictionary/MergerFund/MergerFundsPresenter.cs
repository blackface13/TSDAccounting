/***********************************************************************
 * <copyright file="MergerFundsPresenter.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.MergerFund
{
    /// <summary>
    /// Class MergerFundsPresenter.
    /// </summary>
    public class MergerFundsPresenter : Presenter<IMergerFundsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MergerFundsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public MergerFundsPresenter(IMergerFundsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.MergerFunds = Model.GetMergerFunds();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.MergerFunds = Model.GetMergerFundsActive();
        }

        /// <summary>
        /// Get List MergerFunds by Active
        /// </summary>
        /// <returns></returns>
        public IList<Model.BusinessObjects.Dictionary.MergerFundModel> GetMergerFunds()
        {
            return Model.GetMergerFunds();
        }

        /// <summary>
        /// Displays for combo tree.
        /// </summary>
        /// <param name="mergerFundId">The account identifier.</param>
        public void DisplayForComboTree(int mergerFundId)
        {
            View.MergerFunds = Model.GetMergerFundsForComboTree(mergerFundId);
        }

    }
}