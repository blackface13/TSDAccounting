/***********************************************************************
 * <copyright file="FixedAssetVoucherFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;


namespace TSD.AccountingSoft.BusinessComponents.Facade.FixedAsset
{
    /// <summary>
    /// class FixedAssetVoucherFacade
    /// </summary>
    public class FixedAssetVoucherFacade
    {
        /// <summary>
        /// The fixed asset voucher DAO
        /// </summary>
        private static readonly IFixedAssetVoucherDao FixedAssetVoucherDao = DataAccess.DataAccess.FixedAssetVoucherDao;

        /// <summary>
        /// Gets the fixed asset vouchers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FixedAssetVoucherResponse GetFixedAssetVouchers(FixedAssetVoucherRequest request)
        {
            var response = new FixedAssetVoucherResponse();
            if (request.LoadOptions.Contains("FixedAssetVouchers"))
            {
                if (request.LoadOptions.Contains("FixedAssetId"))
                    response.FixedAssetVouchers = FixedAssetVoucherDao.GetFixedAssetVoucherByFixedAssetId(request.FixedAssetId);
            }
            return response;
        }
    }
}
