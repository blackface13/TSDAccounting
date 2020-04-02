/***********************************************************************
 * <copyright file="IAccountTranferView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IAccountTranferView
    /// </summary>
    public interface IAccountTranferView : IView
    {
        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        int AccountTranferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        string AccountTranferCode { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the account source code.
        /// </summary>
        /// <value>
        /// The account source code.
        /// </value>
        string AccountSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the account destination code.
        /// </summary>
        /// <value>
        /// The account destination code.
        /// </value>
        string AccountDestinationCode { get; set; }

        int? BudgetSourceId { get; set; }

        string ReferentAccount { get; set; }

        /// <summary>
        /// Gets or sets the side of tranfer.
        /// </summary>
        /// <value>
        /// The side of tranfer.
        /// </value>
        int SideOfTranfer { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        int Type { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
