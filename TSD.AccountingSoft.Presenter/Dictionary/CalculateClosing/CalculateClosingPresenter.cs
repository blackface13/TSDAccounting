/***********************************************************************
 * <copyright file="CalculateClosingPresenter.cs" company="BUCA JSC">
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


using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.CalculateClosing
{

    /// <summary>
    /// CalculateClosingPresenter class
    /// </summary>
    public class CalculateClosingPresenter : Presenter<ICalculateClosingView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateClosingPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CalculateClosingPresenter(ICalculateClosingView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified voucher identifier.
        /// </summary>
        /// <param name="paymentAccountcode">The payment accountcode.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="isApproximate">if set to <c>true</c> [is approximate].</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(string paymentAccountcode,string whereClause,string currencyCode, string todate, bool isApproximate, long refId, int refTypeId)
        {
            if (paymentAccountcode == null) return;
            var CalcClo = Model.GetCalculateClosing(paymentAccountcode, whereClause, currencyCode, todate, isApproximate, refId, refTypeId);
            if (CalcClo == null) return;
            View.AccountId = CalcClo.AccountId;
            View.AccountCode = CalcClo.AccountCode;
            View.ClosingAmount = CalcClo.ClosingAmount;
            View.AccountName = CalcClo.AccountName;
        }

        public void DisplayCapitalBalance(string debitAccount, string creditAccount, string whereClause, string currencyCode, string todate, bool isApproximate, long refId, int refTypeId)
        {
            if (debitAccount == null) return;
            var CalcClo = Model.GetCalculateClosing(debitAccount, whereClause, currencyCode, todate, isApproximate, refId, refTypeId);
            if (CalcClo == null) return;
            View.AccountId = CalcClo.AccountId;
            View.AccountCode = CalcClo.AccountCode;
            View.ClosingAmount = CalcClo.ClosingAmount;
            View.AccountName = CalcClo.AccountName;
        }


        public decimal AmountExist(string accountCode,string currencyCode)
        {
            var obj = Model.AmountExist(accountCode, currencyCode);
            if (obj == null) return 0;
            return obj.ClosingAmount;
        }

   }
}
