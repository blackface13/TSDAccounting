
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.RefType
{
    /// <summary>
    ///     RefTypePresenter
    /// </summary>
    /// <seealso cref="TSD.AccountingSoft.Presenter.Presenter{IRefTypeView}" />
    public class RefTypePresenter : Presenter<IRefTypeView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RefTypePresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public RefTypePresenter(IRefTypeView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            if (refTypeId == 0)
            {
                View.DefaultCreditAccountCategoryId = string.Empty;
                View.DefaultCreditAccountId = string.Empty;
                View.RefTypeId = 0;
                View.DefaultDebitAccountCategoryId = string.Empty;
                View.DefaultDebitAccountId = string.Empty;
                View.DefaultTaxAccountCategoryId = string.Empty;
                View.DefaultTaxAccountId = string.Empty;
                View.RefTypeName = string.Empty;
                return;
            }

            var refType = Model.GetRefTypeModel(refTypeId);

            View.RefTypeId = refType.RefTypeId;
            View.DefaultCreditAccountCategoryId = refType.DefaultCreditAccountCategoryId ?? "";
            View.DefaultCreditAccountId = refType.DefaultCreditAccountId ?? "";
            View.DefaultDebitAccountCategoryId = refType.DefaultDebitAccountCategoryId ?? "";
            View.DefaultDebitAccountId = refType.DefaultDebitAccountId ?? "";
            View.DefaultTaxAccountCategoryId = refType.DefaultTaxAccountCategoryId ?? "";
            View.DefaultTaxAccountId = refType.DefaultTaxAccountId ?? "";
            View.RefTypeName = refType.RefTypeName ?? "";
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var refTypeModel = new RefTypeModel
            {
                RefTypeId = View.RefTypeId,
                DefaultCreditAccountCategoryId = View.DefaultCreditAccountCategoryId,
                DefaultCreditAccountId = View.DefaultCreditAccountId,
                DefaultDebitAccountCategoryId = View.DefaultDebitAccountCategoryId,
                DefaultDebitAccountId = View.DefaultDebitAccountId,
                DefaultTaxAccountCategoryId = View.DefaultTaxAccountCategoryId,
                DefaultTaxAccountId = View.DefaultTaxAccountId,
                RefTypeName = View.RefTypeName
            };

            return View.RefTypeId > 0 ? Model.UpdateRefType(refTypeModel) : 0;
        }
    }
}