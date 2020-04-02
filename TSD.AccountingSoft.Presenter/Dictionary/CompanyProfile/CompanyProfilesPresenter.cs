/***********************************************************************
 * <copyright file="BanksPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.CompanyProfile
{
    /// <summary>
    /// BanksPresenter
    /// </summary>
    public class CompanyProfilesPresenter : Presenter<IBanksView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyProfilesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CompanyProfilesPresenter(IBanksView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Banks = Model.GetBanks();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.Banks = Model.GetBanksActive();
        }
    }
}
