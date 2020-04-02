/***********************************************************************
 * <copyright file="AccountBalancePresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Cash;


namespace TSD.AccountingSoft.Presenter.Cash.AccountBalance
{
    /// <summary>
    /// class AccountBalancePresenter
    /// </summary>
    public class AccountBalancePresenter : Presenter<IAccountBalancesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalancePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountBalancePresenter(IAccountBalancesView view)
            : base(view)
        {
        }
    }
}
