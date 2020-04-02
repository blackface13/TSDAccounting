/***********************************************************************
 * <copyright file="CustomerModel.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string ContactRegency { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TaxCode { get; set; }
        public string Website { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public int? BankId { get; set; }
        public bool IsActive { get; set; }
    }
}
