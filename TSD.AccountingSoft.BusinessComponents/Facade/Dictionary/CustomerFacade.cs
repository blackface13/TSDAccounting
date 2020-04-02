/***********************************************************************
 * <copyright file="CustomerFacade.cs" company="BUCA JSC">
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

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{

    /// <summary>
    /// CustomerFacade class
    /// </summary>
    public class CustomerFacade
    {
        /// <summary>
        /// The customer DAO
        /// </summary>
        private static readonly ICustomerDao CustomerDao = DataAccess.DataAccess.CustomerDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CustomerResponse GetCustomers(CustomerRequest request)
        {
            var response = new CustomerResponse();

            if (request.LoadOptions.Contains("Customers"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    response.Customers = CustomerDao.GetCustomerByActives(request.IsActive);
                else response.Customers = CustomerDao.GetCustomers();
            }
            if (request.LoadOptions.Contains("Customer"))
                response.Customer = CustomerDao.GetCustomerById(request.CustomerId);

            return response;
        }

        /// <summary>
        /// Sets the customers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CustomerResponse SetCustomers(CustomerRequest request)
        {
            var response = new CustomerResponse();
            var customerEntity = request.Customer;
            if (request.Action != PersistType.Delete)
            {
                if (!customerEntity.Validate())
                {
                    foreach (string error in customerEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Delete)
                {
                    var customerForDelete = CustomerDao.GetCustomerById(request.CustomerId);
                    response.Message = CustomerDao.DeleteCustomer(customerForDelete);
                }
                else
                {
                    var customer = CustomerDao.GetCustomerByCode(customerEntity.CustomerCode);
                    if (request.Action == PersistType.Insert)
                    {
                        if (customer != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã khách hàng " + customer.CustomerCode + @" đã tồn tại !";
                            return response;
                        }
                        customerEntity.CustomerId = CustomerDao.InsertCustomer(customerEntity);
                        if(customerEntity.CustomerId != 0)
                            AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Customer");
                        response.Message = null;
                    }
                    if (request.Action == PersistType.Update)
                    {
                        if (customer != null)
                        {
                            if (customer.CustomerId != customerEntity.CustomerId)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                response.Message = @"Mã khách hàng " + customer.CustomerCode + @" đã tồn tại !";
                                return response;
                            }
                        }
                        response.Message = CustomerDao.UpdateCustomer(customerEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.CustomerId = customerEntity != null ? customerEntity.CustomerId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}
