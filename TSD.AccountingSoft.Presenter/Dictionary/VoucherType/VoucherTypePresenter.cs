/***********************************************************************
 * <copyright file="VoucherTypePresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.VoucherType
{
    /// <summary>
    /// class VoucherTypePresenter
    /// </summary>
    public class VoucherTypePresenter : Presenter<IVoucherTypeView>
    {
        public VoucherTypePresenter(IVoucherTypeView view) : base(view)
        {
        }

        public VoucherTypeModel GetVoucherTypeByCode(string code)
        {
            return Model.GetVoucherTypeByCode(code) ?? new VoucherTypeModel();
        }
    }
}
