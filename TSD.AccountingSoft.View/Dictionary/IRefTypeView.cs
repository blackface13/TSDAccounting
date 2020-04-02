
namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    ///     IRefTypeView
    /// </summary>
    /// <seealso cref="TSD.AccountingSoft.View.IView" />
    public interface IRefTypeView : IView
    {
        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        int RefTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the reference type.
        /// </summary>
        /// <value>
        ///     The name of the reference type.
        /// </value>
        string RefTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the default debit account category Identifier.
        /// </summary>
        /// <value>
        ///     The default debit account category Identifier.
        /// </value>
        string DefaultDebitAccountCategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the default debit account Identifier.
        /// </summary>
        /// <value>
        ///     The default debit account Identifier.
        /// </value>
        string DefaultDebitAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the default credit account category Identifier.
        /// </summary>
        /// <value>
        ///     The default credit account category Identifier.
        /// </value>
        string DefaultCreditAccountCategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the default credit account Identifier.
        /// </summary>
        /// <value>
        ///     The default credit account Identifier.
        /// </value>
        string DefaultCreditAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the default tax account category Identifier.
        /// </summary>
        /// <value>
        ///     The default tax account category Identifier.
        /// </value>
        string DefaultTaxAccountCategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the default tax account Identifier.
        /// </summary>
        /// <value>
        ///     The default tax account Identifier.
        /// </value>
        string DefaultTaxAccountId { get; set; }
    }
}