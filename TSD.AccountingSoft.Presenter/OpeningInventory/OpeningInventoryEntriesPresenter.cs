/***********************************************************************
 * <copyright file="OpeningAccountEntriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Opening;
using TSD.AccountingSoft.View.OpeningAccountEntry;
using TSD.AccountingSoft.View.OpeningInventoryEntry;

namespace TSD.AccountingSoft.Presenter.OpeningInventory
{
    /// <summary>
    /// OpeningAccountEntriesPresenter
    /// </summary>
    public class OpeningInventoryEntriesPresenter : Presenter<IOpeningInventoryEntriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningInventoryEntriesPresenter(IOpeningInventoryEntriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display(string accountCode)
        {
            View.OpeningInventoryEntries = Model.GetOpeningInventoryEntries(accountCode);
          //  var openingInventoryEntry = Model.GetOpeningInventoryEntries(accountCode);
        }
        public void Display( )
        {
            View.OpeningInventoryEntries = Model.GetOpeningInventoryEntries();
            //  var openingInventoryEntry = Model.GetOpeningInventoryEntries(accountCode);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns> 
        public long Save()
        {
            var openingInventoryEntryModel = View.OpeningInventoryEntries;// new List<OpeningInventoryEntryModel>()
            //{
            //    new OpeningInventoryEntryModel() {
            //    RefId = View.RefId,
            //    RefTypeId = View.RefTypeId,
            //    PostedDate = View.PostedDate,
            //    AccountNumber = View.AccountNumber,
            //    AmountExchange = View.AmountExchange,
            //    ExchangeRate = View.ExchangeRate,
            //    AmountOc = View.AmountOc,
            //    CurrencyCode = View.CurrencyCode,
            //    Quantity = View.Quantity,
            //    RefNo = View.RefNo,
            //    InventoryItemId = View.InventoryItemId,
            //    StockId = View.StockId,
            //    UnitPriceExchange = View.UnitPriceExchange,
            //    UnitPriceOc = View.UnitPriceOc      
            //    }
            //};
            return Model.UpdateOpeningInventoryEntry(openingInventoryEntryModel.ToList());
        }
    }
}
