/***********************************************************************
 * <copyright file="CustomerPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Customer
{
    /// <summary>
    /// CustomerPresenter class
    /// </summary>
    public class CustomerPresenter : Presenter<ICustomerView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CustomerPresenter(ICustomerView view)
            : base(view)
        {

        }

        /// <summary>
        /// Displays the specified account identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public void Display(string customerId)
        {
            if (customerId == null) { View.CustomerId = 0; return; }
            var customer = Model.GetCustomer(int.Parse(customerId));
            View.CustomerId = customer.CustomerId;
            View.CustomerCode = customer.CustomerCode;
            View.CustomerName = customer.CustomerName;
            View.Address = customer.Address;
            View.ContactName = customer.ContactName;
            View.ContactRegency = customer.ContactRegency;
            View.Phone = customer.Phone;
            View.Mobile = customer.Mobile;
            View.Fax = customer.Fax;
            View.Email = customer.Email;
            View.TaxCode = customer.TaxCode;
            View.Website = customer.Website;
            View.Province = customer.Province;
            View.City = customer.City;
            View.ZipCode = customer.ZipCode;
            View.Area = customer.Area;
            View.Country = customer.Country;
            View.BankNumber = customer.BankNumber;
            View.BankName = customer.BankName;
            View.BankId = customer.BankId;
            View.IsActive = customer.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var customer = new CustomerModel
                               {
                CustomerId = View.CustomerId,
                CustomerCode = View.CustomerCode,
                CustomerName = View.CustomerName,
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
            return View.CustomerId == 0 ? Model.InsertCustomer(customer) : Model.UpdateCustomer(customer);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public int Delete(int customerId)
        {            
            return Model.DeleteCustomer(customerId);
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public CustomerModel GetCustomerById(int customerId)
        {
            return Model.GetCustomer(customerId);
        }
    }
}
