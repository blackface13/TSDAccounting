/***********************************************************************
 * <copyright file="AccountingObjectPresenter.cs" company="BUCA JSC">
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
using System.Linq;

namespace TSD.AccountingSoft.Presenter.Dictionary.AccountingObject
{
    public class AccountingObjectPresenter : Presenter<IAccountingObjectView>
    {
        public AccountingObjectPresenter(IAccountingObjectView view)
            : base(view)
        {
        }

        public void Display(int accountingObjectId)
        {
            var accountingObject = Model.GetAccountingObject(accountingObjectId);
            View.AccountingObjectId = accountingObject.AccountingObjectId;
            View.AccountingObjectCode = accountingObject.AccountingObjectCode;
            View.AccountingObjectCategoryId = 2;
            View.Type = accountingObject.Type;
            View.FullName = accountingObject.FullName;
            View.Address = accountingObject.Address;
            View.TaxCode = accountingObject.TaxCode;
            View.BankAcount = accountingObject.BankAcount;
            View.BankName = accountingObject.BankName;
            View.BankId = accountingObject.BankId;
            View.ContactName = accountingObject.ContactName;
            View.ContactAddress = accountingObject.ContactAddress;
            View.ContactIdNumber = accountingObject.ContactIdNumber;
            View.IssueDate = accountingObject.IssueDate;
            View.IssueAddress = accountingObject.IssueAddress;
            View.IsActive = accountingObject.IsActive;
        }

        public int Save()
        {
            var accountingObject = new AccountingObjectModel();
            accountingObject.AccountingObjectId = View.AccountingObjectId;
            accountingObject.AccountingObjectCode = View.AccountingObjectCode;
            accountingObject.AccountingObjectCategoryId = 1;
            accountingObject.Type = View.Type;
            accountingObject.FullName = View.FullName;
            accountingObject.Address = View.Address;
            accountingObject.TaxCode = View.TaxCode;
            accountingObject.BankAcount = View.BankAcount;
            accountingObject.BankName = View.BankName;
            accountingObject.BankId = View.BankId;
            accountingObject.ContactName = View.ContactName;
            accountingObject.ContactAddress = View.ContactAddress;
            accountingObject.ContactIdNumber = View.ContactIdNumber;
            accountingObject.IssueDate = View.IssueDate;
            accountingObject.IssueAddress = View.IssueAddress;
            accountingObject.IsActive = View.IsActive;

            return accountingObject.AccountingObjectId == 0 ? Model.InsertAccountingObject(accountingObject) : Model.UpdateAccountingObject(accountingObject);
        }

        public int Delete(int accountingObjectId)
        {
            return Model.DeleteAccountingObject(accountingObjectId);
        }

        public bool CodeIsExist(int? accountingObjectId, string accountingObjectCode)
        {
            var lstAccountingObjects = Model.GetAccountingObjectsForList();
            if (accountingObjectId == null && lstAccountingObjects.Where(w => w.AccountingObjectCode == accountingObjectCode).Count() == 0)
                    return false;
            else if (accountingObjectId != null && lstAccountingObjects.Where(w => w.AccountingObjectCode == accountingObjectCode && w.AccountingObjectId != accountingObjectId).Count() == 0)
                    return false;
            return true;
        }
    }
}
