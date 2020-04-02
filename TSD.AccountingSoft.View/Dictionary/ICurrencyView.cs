/***********************************************************************
 * <copyright file="ICurrencyView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface ICurrencyView
    /// </summary>
    public interface ICurrencyView : IView 
    {
        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
         int CurrencyId { get; set; }

         /// <summary>
         /// Gets or sets the currency code.
         /// </summary>
         /// <value>The currency code.</value>
         string CurrencyCode { get; set; }

         /// <summary>
         /// Gets or sets the name of the currency.
         /// </summary>
         /// <value>The name of the currency.</value>
         string CurrencyName { get; set; }

         /// <summary>
         /// Gets or sets the prefix.
         /// </summary>
         /// <value>The prefix.</value>
         string Prefix { get; set; }

         /// <summary>
         /// Gets or sets the suffix.
         /// </summary>
         /// <value>The suffix.</value>
         string Suffix { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether this instance is main.
         /// </summary>
         /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
         bool IsMain { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether this instance is active.
         /// </summary>
         /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
         bool IsActive { get; set; }
    }
}
