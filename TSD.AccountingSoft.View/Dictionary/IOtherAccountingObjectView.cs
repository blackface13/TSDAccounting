using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IOtherAccountingObjectView: IView
    {
        /// <summary>
        /// Gets or sets the accounting identifier.
        /// </summary>
        /// <value>
        /// The accounting identifier.
        /// </value>
         int AccountingId { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
         int Type { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
         string FullName { get; set; }
        /// <summary>
        /// Gets or sets the adress.
        /// </summary>
        /// <value>
        /// The adress.
        /// </value>
         string Address { get; set; }
        /// <summary>
        /// Gets or sets the tax code.
        /// </summary>
        /// <value>
        /// The tax code.
        /// </value>
         string TaxCode { get; set; }
        /// <summary>
        /// Gets or sets the bank acount.
        /// </summary>
        /// <value>
        /// The bank acount.
        /// </value>
         string BankAcount { get; set; }
        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
         int BankId { get; set; }
        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The name of the contact.
        /// </value>
         string ContactName { get; set; }
        /// <summary>
        /// Gets or sets the contact address.
        /// </summary>
        /// <value>
        /// The contact address.
        /// </value>
         string ContactAddress { get; set; }
        /// <summary>
        /// Gets or sets the contact identifier number.
        /// </summary>
        /// <value>
        /// The contact identifier number.
        /// </value>
         string ContactIdNumber { get; set; }
        /// <summary>
        /// Gets or sets the date of issue.
        /// </summary>
        /// <value>
        /// The date of issue.
        /// </value>
         DateTime DateOfIssue { get; set; }
        /// <summary>
        /// Gets or sets the issue address.
        /// </summary>
        /// <value>
        /// The issue address.
        /// </value>
         string IssueAddress { get; set; }        

    }
}
