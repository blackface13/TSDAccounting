/***********************************************************************
 * <copyright file="StockPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.AutoNumberList
{
    public class AutoNumberListsPresenter : Presenter<IAutoNumberListsView>
    {

        public AutoNumberListsPresenter(IAutoNumberListsView view)
            : base(view)
        {
        }

        public void Display()
        {
            View.AutoNumberLists = Model.GetAutoNumberLists();
        }

        public string Save()
        {
            var autoNumbers = View.AutoNumberLists;
            return Model != null ? Model.UpdateAutoNumberList((List<AutoNumberListModel>) autoNumbers) : null;
        }
    }
}
