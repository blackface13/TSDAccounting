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

using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.AutoNumberList
{
    public class AutoNumberListPresenter :Presenter<IAutoNumberListView>
    {
        public AutoNumberListPresenter(IAutoNumberListView view)
            : base(view)
        {
        }

        public void DisplayByTableCode(string tableCode)
        {

            var autoId = Model.GetAutoNumberList(tableCode);
            if (autoId == null) return;
            View.TableCode = autoId.TableCode;
            View.TableName = autoId.TableName;
            View.Value = autoId.Value;
            View.LengthOfValue = autoId.LengthOfValue;
            View.Suffix = autoId.Suffix;
            View.Prefix = autoId.Prefix;
            
        }

    }
}
