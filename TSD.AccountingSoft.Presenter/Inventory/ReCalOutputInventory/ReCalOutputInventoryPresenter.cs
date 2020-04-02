/***********************************************************************
 * <copyright file="OutputInventoryPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.Presenter.Inventory.OutputInventory;
using TSD.AccountingSoft.View.Inventory;

namespace TSD.AccountingSoft.Presenter.Inventory.ReCalOutputInventory 
{
    /// <summary>
    /// OutputInventoryPresenter
    /// </summary>
    public class ReCalOutputInventoryPresenter : Presenter<IReCalItemTransactionView> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputInventoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReCalOutputInventoryPresenter(IReCalItemTransactionView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            Model.ReCalOutputStock(DateTime.Parse(View.FromDate), DateTime.Parse(View.ToDate), View.StockId,
                                   View.CurrencyCode,View.currencyDecimalDigits);
        }

        public bool ChecklOutputInventory() 
        {

            var listOutputInventory = Model.GetOutputItemTransactionsByDate(DateTime.Parse(View.FromDate), DateTime.Parse(View.ToDate));
            if (listOutputInventory.Count > 0)return true;
            return false;

        }

        //ThangNK Sửa lại 26/08/2014
        public bool CheckReCalOutputInventory()
        {

            var listOutputInventory = Model.GetOutputItemTransactionsByArisePeriod(DateTime.Parse(View.FromDate), DateTime.Parse(View.ToDate),View.StockId,View.CurrencyCode);
            if (listOutputInventory.Count > 0) return true;
            return false;
        }

        //TuânHM
        //public bool CheckReCalOutputInventory() 
        //{

        //   var listOutputInventory = Model.GetItemTransactionsByDate(DateTime.Parse(View.FromDate), DateTime.Parse(View.ToDate));
        //   if (listOutputInventory.Count>0)
        //   {
        //       return true;
        //   }
        //   else
        //   {
        //       return false;
        //   }
        //}
    }
}
