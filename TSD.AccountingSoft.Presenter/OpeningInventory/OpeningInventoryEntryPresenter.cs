/***********************************************************************
 * <copyright file="OpeningInventoryEntryPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Opening;
using TSD.AccountingSoft.View.OpeningInventoryEntry;
using TSD.AccountingSoft.View.OpeningInventoryEntry;

namespace TSD.AccountingSoft.Presenter.OpeningInventory
{
    public class OpeningInventoryEntryPresenter : Presenter<IOpeningInventoryEntryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningInventoryEntryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningInventoryEntryPresenter(IOpeningInventoryEntryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns> 
        public long Save()
        {
            var openingInventoryEntryModel = new List<OpeningInventoryEntryModel>()
            {
                new OpeningInventoryEntryModel() {
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                PostedDate = View.PostedDate,
                AccountNumber = View.AccountNumber,
                AmountExchange = View.AmountExchange,
                ExchangeRate = View.ExchangeRate,
                AmountOc = View.AmountOc,
                CurrencyCode = View.CurrencyCode,
                Quantity = View.Quantity,
                RefNo = View.RefNo,
                InventoryItemId = View.InventoryItemId,
                StockId = View.StockId,
                UnitPriceExchange = View.UnitPriceExchange,
                UnitPriceOc = View.UnitPriceOc      
                }
            };
            return Model.UpdateOpeningInventoryEntry(openingInventoryEntryModel);
        }

        /// <summary>
        /// Displays the specified account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void Display(string accountCode)
        {
            var openingInventoryEntry = Model.GetOpeningInventoryEntries(accountCode);


            //View.AccountName = openingInventoryEntry.AccountName;
            //View.AccountId = openingInventoryEntry.AccountId;
            //View.ParentId = openingInventoryEntry.ParentId;

            //View.RefId = openingInventoryEntry.RefId;
            //View.RefTypeId = openingInventoryEntry.RefTypeId;
            //View.PostedDate = openingInventoryEntry.PostedDate;
            //View.AccountNumber = openingInventoryEntry.AccountNumber;
            //View.AmountExchange = openingInventoryEntry.AmountExchange;
            //View.ExchangeRate = openingInventoryEntry.ExchangeRate;
            //View.AmountOc = openingInventoryEntry.AmountOc;
            //View.CurrencyCode = openingInventoryEntry.CurrencyCode;
            //View.Quantity = openingInventoryEntry.Quantity;
            //View.RefNo = openingInventoryEntry.RefNo;
            //View.InventoryItemId = openingInventoryEntry.InventoryItemId;
            //View.StockId = openingInventoryEntry.StockId;
            //View.UnitPriceExchange = openingInventoryEntry.UnitPriceExchange;
            //View.UnitPriceOc = openingInventoryEntry.UnitPriceOc;


            View.OpeningInventoryEntries = openingInventoryEntry;
        }
    }
}
