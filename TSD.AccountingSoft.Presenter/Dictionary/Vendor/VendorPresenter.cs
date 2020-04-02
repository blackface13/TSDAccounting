/***********************************************************************
 * <copyright file="VendorPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Saturday, March 8, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Vendor
{
    /// <summary>
    /// VendorPresenter class
    /// </summary>
    public class VendorPresenter : Presenter<IVendorView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public VendorPresenter(IVendorView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        public void Display(string vendorId)
        {
            if (vendorId == null) { View.VendorId = 0; return; }
            var vendor = Model.GetVendor(int.Parse(vendorId));
            View.VendorId = vendor.VendorId;
            View.VendorCode = vendor.VendorCode;
            View.Address = vendor.Address;
            View.VendorName = vendor.VendorName;
            View.ContactName = vendor.ContactName;
            View.ContactRegency = vendor.ContactRegency;
            View.Phone = vendor.Phone;
            View.Mobile = vendor.Mobile;
            View.Fax = vendor.Fax;
            View.Email = vendor.Email;
            View.TaxCode = vendor.TaxCode;
            View.Website = vendor.Website;
            View.Province = vendor.Province;
            View.City = vendor.City;
            View.ZipCode = vendor.ZipCode;
            View.Area = vendor.Area;
            View.Country = vendor.Country;
            View.BankNumber = vendor.BankNumber;
            View.BankName = vendor.BankName;
            View.BankId = vendor.BankId;
            View.IsActive = vendor.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var vendor = new VendorModel
                             {
                                 VendorId = View.VendorId,
                                 VendorCode = View.VendorCode,
                                 VendorName = View.VendorName,
                                 Address = View.Address,
                                 ContactName = View.ContactName,
                                 ContactRegency = View.ContactRegency,
                                 Phone = View.Phone,
                                 Mobile = View.Mobile,
                                 Fax = View.Fax,
                                 Email = View.Email,
                                 TaxCode = View.TaxCode,
                                 Website = View.Website,
                                 Province = View.Province,
                                 City = View.City,
                                 ZipCode = View.ZipCode,
                                 Area = View.Area,
                                 Country = View.Country,
                                 BankNumber = View.BankNumber,
                                 BankName = View.BankName,
                                 BankId = View.BankId,
                                 IsActive = View.IsActive
                             };
            return View.VendorId == 0 ? Model.InsertVendor(vendor) : Model.UpdateVendor(vendor);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public int Delete(int vendorId)
        {
            return Model.DeleteVendor(vendorId);
        }
    }
}
