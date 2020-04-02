/***********************************************************************
 * <copyright file="ICalculateClosingView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, December 25, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IAutoNumberView
    /// </summary>
    public interface ICalculateClosingView : IView
    {
        /// <summary>
        /// Gets or sets the Account Id.
        /// </summary>
        /// <value>
        /// The Account Id.
        /// </value>
        int AccountId { get; set;}

        /// <summary>
        /// Gets or sets the Account Code.
        /// </summary>
        /// <value>
        /// The Account Code.
        /// </value>
        string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the Account Name.
        /// </summary>
        /// <value>
        /// The Account Name.
        /// </value>
        string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the Parent Id.
        /// </summary>
        /// <value>
        /// The Parent Id.
        /// </value>
        int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the Closing Amount.
        /// </summary>
        /// <value>
        /// The Closing Amount.
        /// </value>
        decimal ClosingAmount { get; set; }
  
    }
}
