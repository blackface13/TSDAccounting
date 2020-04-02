/***********************************************************************
 * <copyright file="AccountCategoryModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class AccountCategoryModel.
    /// </summary>
    public class AccountCategoryModel
    {
        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public int AccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the account category code.
        /// </summary>
        /// <value>The account category code.</value>
        public string AccountCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the account category.
        /// </summary>
        /// <value>The name of the account category.</value>
        public string AccountCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is detail.
        /// </summary>
        /// <value><c>true</c> if this instance is detail; otherwise, <c>false</c>.</value>
        public bool IsDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
