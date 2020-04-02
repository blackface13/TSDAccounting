/***********************************************************************
 * <copyright file="StockEntity.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    public class StockEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockEntity"/> class.
        /// </summary>
        public StockEntity()
        {
            AddRule(new ValidateId("StockId"));
            AddRule(new ValidateLength("StockName", 1, 255));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockEntity"/> class.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="stockCode">The stock code.</param>
        /// <param name="stockName">Name of the stock.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public StockEntity(int stockId, string stockCode, string stockName, string description, bool isActive)
        {
            StockId = stockId;
            StockCode = stockCode;
            StockName = stockName;
            Description = description;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        public int StockId { get; set; }

        /// <summary>
        /// Gets or sets the stock code.
        /// </summary>
        /// <value>The stock code.</value>
        public string StockCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>The name of the stock.</value>
        public string StockName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

    }
}
