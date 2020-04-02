/***********************************************************************
 * <copyright file="IStocksView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.View.Dictionary
{
  public  interface IAutoNumberListsView : IView
    {
       IList<AutoNumberListModel> AutoNumberLists { get; set; }
    }
}
