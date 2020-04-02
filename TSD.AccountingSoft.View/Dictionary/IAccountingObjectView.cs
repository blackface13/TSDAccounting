/***********************************************************************
 * <copyright file="IAccountingObjectView.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IAccountingObjectView : IView
    {
        int AccountingObjectId { get; set; }
        string AccountingObjectCode { get; set; }
        int? AccountingObjectCategoryId { get; set; }
        int? Type { get; set; }
        string FullName { get; set; }
        string Address { get; set; }
        string TaxCode { get; set; }
        string BankAcount { get; set; }
        string BankName { get; set; }
        int? BankId { get; set; }
        string ContactName { get; set; }
        string ContactAddress { get; set; }
        string ContactIdNumber { get; set; }
        DateTime? IssueDate { get; set; }
        string IssueAddress { get; set; }
        bool IsActive { get; set; }
    }
}
