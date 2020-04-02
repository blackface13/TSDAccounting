/***********************************************************************
 * <copyright file="PayItemsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.PayItem
{
    /// <summary>
    /// PayItemsPresenter
    /// </summary>
    public class PayItemsPresenter : Presenter<IPayItemsView>
    {
        /// <summary>
        /// PayItems the presenter.
        /// </summary>
        /// <param name="view">The view.</param>
        public PayItemsPresenter(IPayItemsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.PayItems = Model.GetPayItems();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.PayItems = Model.GetPayItemsActive();
        }

    }
}
