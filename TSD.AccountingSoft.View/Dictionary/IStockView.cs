/***********************************************************************
 * <copyright file="IStockView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface IStockView
    /// </summary>
    public interface IStockView : IView
    {
        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        int StockId { get; set; }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        string StockCode { get; set; }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        string StockName { get; set; }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        bool IsActive { get; set; }
    }
}
