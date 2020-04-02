/***********************************************************************
 * <copyright file="RefTypeModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// RefTypeModel
    /// </summary>
    public class RefTypeModel
    {
        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the reference type.
        /// </summary>
        /// <value>
        /// The name of the reference type.
        /// </value>
        public string RefTypeName { get; set; }

        /// <summary>
        /// Gets or sets the function Identifier.
        /// </summary>
        /// <value>
        /// The function Identifier.
        /// </value>
        public string FunctionId { get; set; }

        /// <summary>
        /// Gets or sets the reference type category Identifier.
        /// </summary>
        /// <value>
        /// The reference type category Identifier.
        /// </value>
        public int? RefTypeCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the master table.
        /// </summary>
        /// <value>
        /// The name of the master table.
        /// </value>
        public string MasterTableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the detail table.
        /// </summary>
        /// <value>
        /// The name of the detail table.
        /// </value>
        public string DetailTableName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [layout master].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [layout master]; otherwise, <c>false</c>.
        /// </value>
        public bool LayoutMaster { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [layout detail].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [layout detail]; otherwise, <c>false</c>.
        /// </value>
        public bool LayoutDetail { get; set; }

        /// <summary>
        /// Gets or sets the default debit account category Identifier.
        /// </summary>
        /// <value>
        /// The default debit account category Identifier.
        /// </value>
        public string DefaultDebitAccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the default debit account Identifier.
        /// </summary>
        /// <value>
        /// The default debit account Identifier.
        /// </value>
        public string DefaultDebitAccountId { get; set; }

        /// <summary>
        /// Gets or sets the default credit account category Identifier.
        /// </summary>
        /// <value>
        /// The default credit account category Identifier.
        /// </value>
        public string DefaultCreditAccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the default credit account Identifier.
        /// </summary>
        /// <value>
        /// The default credit account Identifier.
        /// </value>
        public string DefaultCreditAccountId { get; set; }

        /// <summary>
        /// Gets or sets the default tax account category Identifier.
        /// </summary>
        /// <value>
        /// The default tax account category Identifier.
        /// </value>
        public string DefaultTaxAccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the default tax account Identifier.
        /// </summary>
        /// <value>
        /// The default tax account Identifier.
        /// </value>
        public string DefaultTaxAccountId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow default setting].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow default setting]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowDefaultSetting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [postable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [postable]; otherwise, <c>false</c>.
        /// </value>
        public bool Postable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [searchable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [searchable]; otherwise, <c>false</c>.
        /// </value>
        public bool Searchable { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the sub system.
        /// </summary>
        /// <value>
        /// The sub system.
        /// </value>
        public string SubSystem { get; set; }
    }
}
