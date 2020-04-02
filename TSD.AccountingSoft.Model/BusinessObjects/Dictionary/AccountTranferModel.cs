/***********************************************************************
 * <copyright file="AccountTranferModel.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// AccountTranferModel
    /// </summary>
    public class AccountTranferModel
    {
        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        public int AccountTranferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        public string AccountTranferCode { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the account source code.
        /// </summary>
        /// <value>
        /// The account source code.
        /// </value>
        public string AccountSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the account destination code.
        /// </summary>
        /// <value>
        /// The account destination code.
        /// </value>
        public string AccountDestinationCode { get; set; }

        public int? BudgetSourceId { get; set; }

        public string ReferentAccount { get; set; }

        /// <summary>
        /// Gets or sets the side of tranfer.
        /// </summary>
        /// <value>
        /// The side of tranfer.
        /// </value>
        public int SideOfTranfer { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
