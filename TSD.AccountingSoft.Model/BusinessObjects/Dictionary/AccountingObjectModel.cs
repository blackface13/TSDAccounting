/***********************************************************************
 * <copyright file="AccountingObjectModel.cs" company="BUCA JSC">
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

using System;


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class AccountingObjectModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int AccountingObjectId { get; set; }
        /// <summary>
        /// mã đối tượng
        /// </summary>
        public string AccountingObjectCode { get; set; }
        /// <summary>
        /// tên đối tượng
        /// </summary>
        public string FullName { get; set; }
        public int AccountingObjectCategoryId { get; set; }
        public int? Type { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }
        public string TaxCode { get; set; }
        /// <summary>
        /// tài khoản ngân hàng
        /// </summary>
        public string BankAcount { get; set; }
        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string BankName { get; set; }
        public int? BankId { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactIdNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssueAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
