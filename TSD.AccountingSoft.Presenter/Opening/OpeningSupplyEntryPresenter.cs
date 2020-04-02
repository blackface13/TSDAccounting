/***********************************************************************
 * <copyright file="openingsupplyentrypresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.View.OpeningSupplyEntry;
using System.Text;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;

namespace TSD.AccountingSoft.Presenter.Opening
{
    /// <summary>
    /// Class OpeningSupplyEntryPresenter.
    /// </summary>
    /// <seealso cref="TSD.AccountingSoft.Presenter.Presenter{TSD.AccountingSoft.View.OpeningSupplyEntry.IOpeningSupplyEntryView}" />
    public class OpeningSupplyEntryPresenter : Presenter<IOpeningSupplyEntryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSupplyEntryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningSupplyEntryPresenter(IOpeningSupplyEntryView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var openingSupplyEntry = Model.GetOpeningSupplyEntryVoucher(refId, true) ?? new OpeningSupplyEntryModel();
            View.RefId = openingSupplyEntry.RefId;
            View.RefType = openingSupplyEntry.RefType;
            View.PostedDate = openingSupplyEntry.PostedDate;
            View.RefDate = openingSupplyEntry.RefDate;
            View.CurrencyCode = openingSupplyEntry.CurrencyCode;
            View.ExchangeRate = openingSupplyEntry.ExchangeRate;
            View.AccountNumber = openingSupplyEntry.AccountNumber;
            View.InventoryItemId = openingSupplyEntry.InventoryItemId;
            View.DepartmentId = openingSupplyEntry.DepartmentId;
            View.Quantity = openingSupplyEntry.Quantity;
            View.UnitPriceOc = openingSupplyEntry.UnitPriceOc;
            View.UnitPriceExchange = openingSupplyEntry.UnitPriceExchange;
            View.AmountOc = openingSupplyEntry.AmountOc;
            View.AmountExchange = openingSupplyEntry.AmountExchange;
            View.SortOrder = openingSupplyEntry.SortOrder;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string Delete(long refId)
        {
            return Model.DeleteOpeningSupplyEntry(refId);
        }

    }
}
