/***********************************************************************
 * <copyright file="CustomerEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{

    /// <summary>
    /// CustomerEntity class
    /// </summary>
    public class CustomerEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerEntity"/> class.
        /// </summary>
        public CustomerEntity()
        {
            AddRule(new ValidateId("CustomerId"));
            AddRule(new ValidateRequired("CustomerCode"));
            AddRule(new ValidateLength("CustomerName", 1, 255));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerEntity"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerCode">The customer code.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="address">The address.</param>
        /// <param name="contactName">Name of the contact.</param>
        /// <param name="contactRegency">The contact regency.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="mobile">The mobile.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="email">The email.</param>
        /// <param name="taxCode">The tax code.</param>
        /// <param name="website">The website.</param>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="country">The country.</param>
        /// <param name="bankNumber">The bank number.</param>
        /// <param name="area">The area.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public CustomerEntity(int customerId, string customerCode, string customerName, string address, string contactName, string contactRegency, string phone,
            string mobile, string fax, string email, string taxCode, string website, string province, string city, string zipCode, string country, string bankNumber,
            string area, int? bankId, bool isActive)
            : this()
        {
            CustomerId = customerId;
            CustomerCode = customerCode;
            CustomerName = customerName;
            Address = address;
            ContactName = contactName;
            ContactRegency = contactRegency;
            Phone = phone;
            Mobile = mobile;
            Fax = fax;
            Email = email;
            TaxCode = taxCode;
            Website = website;
            Province = province;
            City = city;
            ZipCode = zipCode;
            Country = country;
            BankNumber = bankNumber;
            Area = area;
            BankId = bankId;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The name of the contact.
        /// </value>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the contact regency.
        /// </summary>
        /// <value>
        /// The contact regency.
        /// </value>
        public string ContactRegency { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the tax code.
        /// </summary>
        /// <value>
        /// The tax code.
        /// </value>
        public string TaxCode { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>
        /// The province.
        /// </value>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the bank number.
        /// </summary>
        /// <value>
        /// The bank number.
        /// </value>
        public string BankNumber { get; set; }
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
