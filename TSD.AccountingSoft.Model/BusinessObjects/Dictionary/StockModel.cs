/***********************************************************************
 * <copyright file="StockModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class StockModel.
    /// </summary>
    public class StockModel
    {
        /// <summary>
        /// Gets or sets the StockId identifier.
        /// </summary>
        /// <value>
        /// The StockId identifier.
        /// </value>
        public int StockId { get; set; }

        /// <summary>
        /// Gets or sets the StockCode identifier.
        /// </summary>
        /// <value>
        /// The StockCode identifier.
        /// </value>
        public string StockCode { get; set; }

        /// <summary>
        /// Gets or sets the StockName identifier.
        /// </summary>
        /// <value>
        /// The StockName identifier.
        /// </value>
        public string StockName { get; set; }

        /// <summary>
        /// Gets or sets the Description identifier.
        /// </summary>
        /// <value>
        /// The Description identifier.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the IsActive identifier.
        /// </summary>
        /// <value>
        /// The IsActive identifier.
        /// </value>
        public bool IsActive { get; set; }

    }
}
