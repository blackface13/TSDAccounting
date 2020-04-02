/***********************************************************************
 * <copyright file="AccountTranfersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.AccountTranfer
{
    /// <summary>
    /// AccountTranfersPresenter
    /// </summary>
    public class AccountTranfersPresenter : Presenter<IAccountTranfersView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranfersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountTranfersPresenter(IAccountTranfersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AccountTranfers = Model.GetAccountTranfers();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.AccountTranfers = Model.GetAccountTranfersActive();
        }
    }
}
