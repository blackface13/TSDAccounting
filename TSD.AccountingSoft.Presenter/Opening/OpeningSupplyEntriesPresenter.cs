/***********************************************************************
 * <copyright file="OpeningSupplyEntriesPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.View.OpeningSupplyEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Opening
{
    public class OpeningSupplyEntriesPresenter : Presenter<IOpeningSupplyEntriesView>
    {
        public OpeningSupplyEntriesPresenter(IOpeningSupplyEntriesView view)
            : base(view)
        {
        }
        public void Display()
        {
            View.OpeningSupplyEntries = Model.GetOpeningSupplyEntry();
        }
        //public void Display(string accountNumber)
        //{
        //    var openingAccountEntries = Model.GetOpeningSupplyEntryEntriesByAccountNumber(accountNumber);
        //    View.OpeningSupplyEntryEntries = openingAccountEntries == null ? new List<OpeningSupplyEntryEntryModel>() : openingAccountEntries;
        //}

        public string Save(IList<OpeningSupplyEntryModel> openingSupplyEntries)
        {
            return Model.UpdateOpeningSupplyEntry(openingSupplyEntries);
        }

        public string Delete(long refId)
        {
            return Model.DeleteOpeningSupplyEntry(refId);
        }
    }
}
