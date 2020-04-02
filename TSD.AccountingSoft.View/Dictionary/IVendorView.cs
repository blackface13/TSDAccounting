/***********************************************************************
 * <copyright file="IVendorView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IVendorView: IView
    {
        int VendorId { get; set; }
        string VendorCode { get; set; }
        string VendorName { get; set; }
        string Address { get; set; }
        string ContactName { get; set; }
        string ContactRegency { get; set; }
        string Phone { get; set; }
        string Mobile { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
        string TaxCode { get; set; }
        string Website { get; set; }
        string Province { get; set; }
        string City { get; set; }
        string ZipCode { get; set; }
        string Area { get; set; }
        string Country { get; set; }
        string BankNumber { get; set; }
        string BankName { get; set; }
        int? BankId { get; set; }
        bool IsActive { get; set; }
    }
}
