/***********************************************************************
 * <copyright file="SitePresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.Site
{
    /// <summary>
    /// class SitePresenter
    /// </summary>
    public class SitePresenter : Presenter<ISiteView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SitePresenter(ISiteView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        public void Display(string siteId)
        {
            if (siteId == null) { View.SiteId = 0; return; }

            var site = Model.GetSite(int.Parse(siteId));

            View.SiteId = site.SiteId;
            View.SiteCode = site.SiteCode;
            View.SiteName = site.SiteName;
            View.ParentId = site.ParentId;
            View.Description = site.Description;
            View.IsActive = site.IsActive;
            View.Order = site.Order;
            View.PermissionSiteModels = site.PermissionSiteModels;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var site = new SiteModel
            {
                SiteId = View.SiteId,
                SiteCode = View.SiteCode,
                SiteName = View.SiteName,
                ParentId  = View.ParentId,
                Description = View.Description,
                IsActive = View.IsActive,
                Order = View.Order,
                PermissionSiteModels = View.PermissionSiteModels,
            };

            return View.SiteId == 0 ? Model.AddSite(site) : Model.UpdateSite(site);
        }

        /// <summary>
        /// Deletes the specified site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        public int Delete(int siteId)
        {
            return Model.DeleteSite(siteId);
        }
    }
}
