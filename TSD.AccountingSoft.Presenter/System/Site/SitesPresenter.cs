/***********************************************************************
 * <copyright file="SitesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 23 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.Site
{
    /// <summary>
    /// SitesPresenter
    /// </summary>
    public class SitesPresenter : Presenter<ISitesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SitesPresenter(ISitesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Sites = Model.GetSites();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void Display(bool isActive)
        {
            View.Sites = Model.GetSites(isActive);
        }
    }
}
